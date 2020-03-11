import React, { Component } from 'react'
import PropTypes from 'prop-types'
import EventCalendar from 'react-event-calendar'
import { connect } from 'react-redux'
import '../../../styles/calendar.scss'
import '../styles/bookings.scss'
import { getAllBookings, createBooking, editToolbarTitle } from '../modules/bookings'
import moment from 'moment'
import { getBookingColor } from '../config'
import { bookingStatus, calendarStyle, bookingColorClass } from '../../../config'
import $ from 'jquery'
import CalendarToolbar from '../components/calendarToolbar'
import { getActiveLanguage } from 'react-localize-redux'
import 'fullcalendar/dist/fullcalendar.css'
import 'fullcalendar/dist/fullcalendar.js'

class Bookings extends Component {
    constructor(props) {
        super(props)
        this.state = {
            selectedDate: moment().format('L').toString(),
            selectedDay: moment().format('LL').toString(),
            open: false,
            eventClicked: false,
            defaultDate: moment().format('L'),
            currentBookingStatus: bookingStatus.all,
            currentCalendarStyle: calendarStyle.month,
            render: true
        }
    }
    componentWillMount() {
        const { getAllBookings } = this.props
        getAllBookings({ status: this.state.currentBookingStatus, date: this.state.defaultDate })
    }

    componentDidMount() {
        this.renderCalendar(this.state.defaultDate)
    }

    componentDidUpdate() {
        const { checkNewBookings, bookings, getAllBookings } = this.props
        if (checkNewBookings) {
            getAllBookings({ status: this.state.currentBookingStatus, date: this.state.defaultDate })
        }
        if (this.state.render && !checkNewBookings) {
            this.renderCalendar(this.state.defaultDate)
        }
    }

    componentWillReceiveProps(nextProps) {
        const { bookings } = this.props
        if (nextProps.bookings
            && bookings
            && nextProps.bookings.length > bookings.length
            && nextProps.checkNewBookings === true
            && this.props.checkNewBookings === false) {
            let eventSource = nextProps.bookings.filter(item => {
                return !bookings.some(bk => {
                    return bk.id === item.id
                })
            })
            const self = this
            console.log('event source', eventSource)
            $('#calendar').fullCalendar('addEventSource', self.renderEvents(eventSource))
            this.setState({
                render: false
            })
        } else {
            if (nextProps.checkNewBookings === false && this.props.checkNewBookings === true) {
                this.setState({
                    render: false
                })
            } else {
                this.setState({
                    render: true
                })
            }
        }
    }

    renderCalendar(defaultDate) {
        const { requestPending, width, editToolbarTitle, currentLanguage } = this.props
        $('#calendar').fullCalendar('destroy')
        const self = this
        const { bookings, dayClicked, eventClicked } = this.props
        if (!requestPending) {
            let config = {
                locale: currentLanguage,
                defaultDate,
                defaultView: self.state.currentCalendarStyle.name,
                header: false, // this allows things to be dropped onto the calendar
                events: self.renderEvents(bookings),
                dayClick: (e) => {
                    this.setState({
                        selectedDate: moment(e._d).format('L')
                    })
                    dayClicked(this.state.selectedDate)
                },
                viewRender: function (view) {
                    let calendarDate = $('#calendar').fullCalendar('getDate')
                    let CalendarMonth = calendarDate.month()

                    $('#viewTitle').html(view.title)
                    editToolbarTitle(view.title)
                },
                eventClick: function (calEvent, jsEvent, view) {
                    eventClicked(calEvent, jsEvent, view)
                },
                eventRender: function (event, element) {
                    console.log('element', element.find(".fc-day-grid-event"))
                    element.find(".fc-resizer").css('display', 'none');
                    element.find(".fc-end-resizer").css('display', 'none');
                    element.find(".fc-event-title").remove();
                    element.find(".fc-event-time").remove();
                    element.find(".fc-title").remove();
                    element.find(".fc-content").css('padding', '5px')
                    var new_description = ''
                    if (width > 800) {
                        new_description = '<div class="media-body">' +
                            '<div class="lgi-heading" style="font-size:8pt; color:white">' + event.title + '</div>' +
                            '<small class="lgi-text" style="font-size:8pt; color:white">' + event.phoneNumber + '</small>' +
                            '<div class="lgi-heading" style="font-size:8pt; color:white">' + event.serviceName + '</div>' +
                            '</div>'
                    } else {
                        new_description = '<div class="media-body"></div>'
                    }
                    if (event.statusId === 4) {
                        if (width > 800) {
                            new_description = '<div class="media-body">' +
                                '<div class="lgi-heading" style="font-size:8pt; color:white">' + event.description + '</div>' +
                                '</div>'
                        } else {
                            new_description = '<div class="media-body"></div>'
                        }
                    }
                    element.find(".fc-content").append(new_description);
                    element.find(".fc-content").addClass(`${bookingColorClass(event.statusId)}`);
                    element.find(".fc-event").css('background-color', 'none !important')
                },
            }
            if (width < 1030) {
                Object.assign(config, {
                    views: {
                        month: { // name of view
                            titleFormat: 'YYYY-MM'
                            // other view-specific options here
                        },
                        week: { // name of view
                            titleFormat: 'DD'
                            // other view-specific options here
                        },
                        day: { // name of view
                            titleFormat: 'DD'
                            // other view-specific options here
                        }
                    }
                })
            }
            $('#calendar').fullCalendar(config)
        }
    }

    todayClick = () => {
        const { getAllBookings } = this.props
        getAllBookings({
            status: this.state.currentBookingStatus,
            date: moment().format('L')
        })
        this.setState({
            defaultDate: moment().format('L')
        })
    }

    leftClick = () => {
        const { getAllBookings } = this.props
        getAllBookings({
            status: this.state.currentBookingStatus,
            date: moment(this.state.defaultDate).subtract(1, this.state.currentCalendarStyle.subtract).format('L')
        })
        this.setState({
            defaultDate: moment(this.state.defaultDate).subtract(1, this.state.currentCalendarStyle.subtract).format('L')
        })
    }

    rightClick = () => {
        const { getAllBookings } = this.props
        getAllBookings({
            status: this.state.currentBookingStatus,
            date: moment(this.state.defaultDate).add(1, this.state.currentCalendarStyle.add).format('L')
        })
        this.setState({
            defaultDate: moment(this.state.defaultDate).add(1, this.state.currentCalendarStyle.add).format('L')
        })
    }

    bookingStatusClick = (bookingStatus) => {
        const { getAllBookings } = this.props
        this.setState({
            currentBookingStatus: bookingStatus
        })
        getAllBookings({ status: bookingStatus, date: this.state.defaultDate })
    }

    calendarViewClick = (calendarStyle) => {
        this.setState({
            currentCalendarStyle: calendarStyle
        })
    }

    renderEvents(bookings) {
        if (bookings && bookings.length >= 0) {
            return bookings.map(item => {
                return {
                    title: item.userFullName,
                    allDay: true,
                    start: item.bookDate,
                    statusId: item.statusId,
                    description: item.description,
                    id: item.id,
                    phoneNumber: item.phoneNumber,
                    userFullName: item.userFullName,
                    serviceName: item.serviceName
                }
            })
        } else {
            return []
        }
    }
    render() {
        const { bookings, dayClicked, getAllBookings, requestPending, currentBookingStatus } = this.props
        return (
            <div>
                <CalendarToolbar
                    bookingStatusClick={this.bookingStatusClick}
                    todayClick={this.todayClick}
                    leftClick={this.leftClick}
                    rightClick={this.rightClick}
                    calendarViewClick={this.calendarViewClick}
                />
                <div className='card-body no-padding'>
                    <div id='calendar' style={{ padding: '0px 10px', margin: '0px 16px', background: '#fff' }}></div>
                </div>
            </div>
        )
    }
}

Bookings.propTypes = {
    getAllBookings: PropTypes.func.isRequired,
    createBooking: PropTypes.func,
    dayClicked: PropTypes.func,
    eventClicked: PropTypes.func
}

const mapDispatchToProps = {
    getAllBookings,
    editToolbarTitle
}

const mapStateToProps = (state) => ({
    bookings: state.bookings.bookings,
    requestPending: state.bookings.requestPending,
    width: state.events.width,
    currentLanguage: getActiveLanguage(state.locale).code,
    checkNewBookings: state.bookings.checkNewBookings
})

export default connect(mapStateToProps, mapDispatchToProps)(Bookings)