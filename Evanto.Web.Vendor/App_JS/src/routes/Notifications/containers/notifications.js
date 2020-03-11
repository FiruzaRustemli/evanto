import React, { Component } from 'react'
import { connect } from 'react-redux'
import NotificationList from '../components/notifications'
import { updateBookingNotifications, getAllBookingNotifications } from '../../../store/notificationReducer'
import { getUserInfo } from '../../Bookings/modules/bookings'
import { getTranslate } from 'react-localize-redux'
import $ from 'jquery'
import BookingRequest from '../../Bookings/containers/bookingRequest'
import CircularProgress from 'react-md/lib/Progress/CircularProgress'

class Notifications extends Component {
    constructor(props) {
        super(props)
        this.state = {
            showAlert: true,
            event: {},
            page: 1,
            eventClicked: false
        }
    }

    componentWillReceiveProps(nextProps) {
        if (nextProps.isNotificationLoading === false && this.props.isNotificationLoading === true) {
            window.scroll(0, $(window).scrollTop() - 200)
        }
    }

    componentWillMount() {
        const { getAllBookingNotifications, isNotificationLoading, width, nots } = this.props
        const self = this
        $(window).scroll(() => {
            if ($(window).scrollTop() + $(window).height() == $(document).height()) {
                if (self.props.width > 1090
                    && self.props.nots
                    && self.props.nots.bookingNotifications
                    && self.props.nots.bookingNotifications.length > 9) {
                    getAllBookingNotifications({ skip: self.state.page * 10 })
                    self.setState({
                        page: self.state.page + 1
                    })
                }
            }
        });
    }

    cancel = () => {
        this.setState({
            eventClicked: false
        })
    }

    notificationClick = (args) => {
        var additionalData = JSON.parse(args.additionalData);
        const { getUserInfo, updateBookingNotifications } = this.props
        getUserInfo({ bookingId: additionalData.BookingId })
        if (args.statusId !== 1) {
            updateBookingNotifications({ id: args.id, statusId: 1 })
        }
        this.setState({
            event: { id: additionalData.BookingId },
            eventClicked: true
        })
    }

    renderBookingRequest = (event) => {
        const { updateBookingStatus, requestUserInfo } = this.props
        return (
            <BookingRequest
                show={this.state.eventClicked}
                event={event}
                requestUserInfo={requestUserInfo}
                type={this.state.clickedEventStatus}
                cancel={this.cancel} />
        )
    }

    render() {
        const { nots, isNotificationLoading, requestUserInfo } = this.props
        return (
            <div className='md-cell md-cell--12'>
                <div className='md-grid'>
                    <div style={{ marginBottom: 400 }} className='md-cell md-cell--6 md-cell--3-offset'>
                        {(nots && nots.bookingNotifications) ? <NotificationList
                            isNotificationLoading={isNotificationLoading}
                            resetPage={() => {
                                this.setState({
                                    page: 1
                                })
                            }}
                            notificationClick={this.notificationClick}
                            notifications={nots.bookingNotifications} />
                            : <CircularProgress id='notificationsProgress'/>}
                    </div>
                </div>
                {this.state.eventClicked && this.renderBookingRequest(this.state.event)}
            </div>
        )

    }
}

const mapDispatchToProps = {
    updateBookingNotifications,
    getUserInfo,
    getAllBookingNotifications
}

const mapStateToProps = (state) => ({
    nots: state.notification.notifications,
    requestUserInfo: state.bookings.requestUserInfo,
    width: state.events.width,
    isNotificationLoading: state.notification.isNotificationLoading,
    translate: getTranslate(state.locale),
    location: state.routing.locationBeforeTransitions.pathname
})

export default connect(mapStateToProps, mapDispatchToProps)(Notifications)