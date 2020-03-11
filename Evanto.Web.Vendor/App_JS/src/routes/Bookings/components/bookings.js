import React, { Component } from 'react'
import Bookings from '../containers/bookings'
import { connect } from 'react-redux'
import moment from 'moment'
import CalendarToolbar from './calendarToolbar'
import { getAllBookings, createBooking, updateBookingStatus, getUserInfo, getActiveVendorServices } from '../modules/bookings'
import { AddBooking, BookingRequest } from '../containers'
import { bookingStatus } from '../../../config'
import renderModalButtons from './requestDialogActions'
import renderModalButtonsMobile from './requestDialogActionsMobile'
import '../styles/bookings.scss'
import BookingType from './bookingType'
import Radio from 'react-md/lib/SelectionControls/Radio'
import Chip from 'react-md/lib/Chips'
import { getTranslate } from 'react-localize-redux'

class BookingsComponent extends Component {
    constructor(props) {
        super(props)
        this.state = {
            dayClicked: false,
            eventClicked: false,
            clickedEventStatus: bookingStatus.all,
            event: {},
        }
    }
    componentWillMount() {
        const { getActiveVendorServices } = this.props
        getActiveVendorServices()
    }

    handleSubmit(input) {
        const { createBooking, getAllBookings } = this.props
        input.BookDate = moment(`${input.BookDate} ${moment(input.BookTime).format('LT')}`).format('LLL')
        createBooking(input)
        getAllBookings(0)
        this.setState({
            dayClicked: false
        })
    }

    dayClicked = (e) => {
        this.setState({
            dayClicked: true,
            eventClicked: false,
            currentDate: moment(e).format('L')
        })
    }

    eventClicked = (calEvent, jsEvent, view) => {
        const { getUserInfo } = this.props
        getUserInfo({ bookingId: calEvent.id })
        this.setState({
            event: calEvent,
            dayClicked: false,
            eventClicked: true,
            clickedEventStatus: calEvent.statusId
        })
    }

    cancel = () => {
        this.setState({
            dayClicked: false,
            eventClicked: false
        })
    }
    renderAddBooking = (currentDate) => {
        const { activeVendorServices } = this.props
        let initialValues = {
            initialValues: {
                BookDate: currentDate
            }
        }
        if (activeVendorServices) {
            return (
                <AddBooking onSubmit={formData => {
                    this.handleSubmit(formData)
                }}
                    vendorServices={activeVendorServices.vendorServices}
                    currentDate={currentDate}
                    show={this.state.dayClicked}
                    handleClose={() => {
                        this.cancel()
                    }}
                    {...initialValues} />
            )
        }
    }

    renderBookingRequest = (event) => {
        const { updateBookingStatus, requestUserInfo, translate } = this.props
        return (
            <BookingRequest
                actions={renderModalButtons({
                    ...translate([
                        '##approve',
                        '##reject',
                        '##close',
                        '##cancelBooking',
                        '##close'
                    ]),
                    event,
                    updateBookingStatus,
                    cancel: this.cancel,
                    type: this.state.clickedEventStatus
                })}
                actionsMobile={renderModalButtonsMobile({
                    event,
                    updateBookingStatus,
                    cancel: this.cancel,
                    type: this.state.clickedEventStatus
                })}
                show={this.state.eventClicked}
                event={event}
                eventClicked={this.state.clickedEventStatus}
                requestUserInfo={requestUserInfo}
                approve={updateBookingStatus}
                reject={updateBookingStatus}
                type={this.state.clickedEventStatus}
                cancel={this.cancel} />
        )
    }
    render() {
        const { getAllBookings, requestUserInfo } = this.props
        return (
            <div>
                {this.state.dayClicked && this.renderAddBooking(this.state.currentDate)}

                {requestUserInfo && this.renderBookingRequest(this.state.event)}
                {/* <div className='md-cell'>
                        <h2 className='md-headline'>Booking planner</h2>
                        <p className='md-caption'>You can handle all your requests and bookings</p>
                    </div>
                    <br /> */}
                <Bookings eventClicked={this.eventClicked} dayClicked={this.dayClicked} />
            </div>
        )
    }
}

const mapDispatchToProps = {
    getAllBookings,
    createBooking,
    updateBookingStatus,
    getUserInfo,
    getActiveVendorServices
}

const mapStateToProps = (state) => ({
    bookings: state.bookings.bookings,
    requestUserInfo: state.bookings.requestUserInfo,
    activeVendorServices: state.bookings.activeVendorServices,
    translate: getTranslate(state.locale)
})

export default connect(mapStateToProps, mapDispatchToProps)(BookingsComponent)
