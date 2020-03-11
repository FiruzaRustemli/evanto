import React, { Component } from 'react'
import { connect } from 'react-redux'
import _ from 'lodash'
import { getPendingBookings, updateBookingStatus, getUserInfo } from '../../routes/Bookings/modules/bookings'
import { getAllBookingNotifications, updateBookingNotifications } from '../../store/notificationReducer'
import { BookingRequest } from '../../routes/Bookings/containers'
import { bookingStatus } from '../../config'
import { Link } from 'react-router'
import Button from 'react-md/lib/Buttons';
import NotificationList from './notificationList'
import { getTranslate } from 'react-localize-redux'
import './generalAlert.scss'
import { push } from 'react-router-redux'
class Alert extends Component {
    constructor(props) {
        super(props)
        this.state = {
            showAlert: false,
            eventClicked: false,
            clickedEventStatus: 0,
            event: {}
        }
    }
    componentWillMount() {
        const { getAllBookingNotifications } = this.props
        getAllBookingNotifications({ firstly: true })
    }

    componentDidMount() {
        document.addEventListener('mousedown', this.handleMouseEvent)
    }

    componentWillUnmount() {
        document.removeEventListener('mousedown', this.handleMouseEvent)
    }

    handleMouseEvent = (e) => {
        if (this.generalAlertRef && !this.generalAlertRef.contains(e.target)) {
            this.setState({
                showAlert: false
            })
        }
    }

    setGeneralAlertRef = (node) => {
        this.generalAlertRef = node
    }
    approve = (item) => {
        const { updateBookingStatus } = this.props
        updateBookingStatus({
            id: item.id,
            statusId: bookingStatus.approved,
            isExternal: true
        })
    }

    reject = (item) => {
        const { updateBookingStatus } = this.props
        updateBookingStatus({
            id: item.id,
            statusId: bookingStatus.rejected,
            isExternal: true
        })
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
            eventClicked: true,
            clickedEventStatus: bookingStatus.waiting,
            event: { id: additionalData.BookingId }
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
        const { notifications, width, hashHistory, unreadCount } = this.props
        return (
            <div ref={this.setGeneralAlertRef} className='alert_div' style={{ float: `${width < 1090 ? 'left' : 'inherit'}` }}>
                <Button
                    onTouchTap={() => {
                        this.setState({
                            showAlert: true
                        })
                        push('/')
                    }} icon secondary iconClassName='fa fa-bell-o' >
                    {unreadCount > 0 && <sup className='badge badge_color'>
                        {unreadCount}
                    </sup>}
                </Button>
                {/* Notification list */}
                {notifications
                    && notifications.bookingNotifications
                    && this.state.showAlert
                    && <NotificationList
                        onMouseLeave={() => {
                            this.setState({
                                showAlert: false
                            })
                        }}
                        onReject={this.reject}
                        onApprove={this.approve}
                        notificationClick={this.notificationClick}
                        notifications={notifications.bookingNotifications} />}
                {this.state.eventClicked && this.renderBookingRequest(this.state.event)}
            </div>
        )
    }
}

const mapDispatchToProps = {
    getAllBookingNotifications,
    updateBookingStatus,
    getUserInfo,
    updateBookingNotifications,
    push
}

const mapStateToProps = (state) => ({
    notifications: state.notification.notifications,
    requestUserInfo: state.bookings.requestUserInfo,
    width: state.events.width,
    translate: getTranslate(state.locale),
    unreadCount: state.notification.unreadCount
})

export default connect(mapStateToProps, mapDispatchToProps)(Alert)