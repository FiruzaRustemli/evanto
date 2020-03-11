import React, { Component } from 'react'
import { connect } from 'react-redux'
import { Link } from 'react-router'
import { getPendingBookings, updateBookingStatus, getUserInfo } from '../../routes/Bookings/modules/bookings'
import { bookingStatus } from '../../config'
import { getTranslate } from 'react-localize-redux'
import { BookingRequest } from '../../routes/Bookings/containers'
import PendingList from './pendingList'
import FloatingActionButton from 'material-ui/FloatingActionButton';
import renderModalButtons from '../../routes/Bookings/components/requestDialogActions'
import renderModalButtonsMobile from '../../routes/Bookings/components/requestDialogActionsMobile'
import Button from 'react-md/lib/Buttons';
import './alert.scss'

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
        const { getPendingBookings } = this.props
        getPendingBookings()
    }

    componentDidMount () {
        document.addEventListener('mousedown', this.handleMouseEvent)
    }

    componentWillUnmount () {
        document.removeEventListener('mousedown', this.handleMouseEvent)
    }

    handleMouseEvent = (e) => {
        if(this.bookingAlertRef && !this.bookingAlertRef.contains(e.target)) {
            this.setState({
                showAlert: false
            })
        }
    }

    setBookingAlertRef = (node) => {
        this.bookingAlertRef = node
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

    eventClicked = (event) => {
        const { getUserInfo } = this.props
        getUserInfo({ bookingId: event.id })
        this.setState({
            eventClicked: true,
            clickedEventStatus: event.statusId,
            event
        })
    }

    cancel = () => {
        this.setState({
            eventClicked: false
        })
    }

    renderBookingRequest = (event) => {
        const { updateBookingStatus, requestUserInfo, translate } = this.props
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
        const { pendingBookings, closeDrawer, width } = this.props
        return (
            <div ref={this.setBookingAlertRef} className='alert_div' style={{ float: `${width < 1090 ? 'left' : 'inherit'}` }}>
                {/* Notification button with star */}
                <Button
                    onTouchTap={() => {
                        this.setState({
                            showAlert: true
                        })
                    }} icon secondary iconClassName='fa fa-calendar-check-o' >
                    {pendingBookings && <sup className='badge badge_color'>
                        {pendingBookings.bookings && pendingBookings.bookings.length > 0 && pendingBookings.bookings.length}
                    </sup>}
                </Button>
                {/* Notification list */}
                {pendingBookings && this.state.showAlert && <PendingList onMouseLeave={() => {
                    this.setState({
                        showAlert: false
                    })
                }}
                    onReject={this.reject}
                    onApprove={this.approve}
                    eventClicked={this.eventClicked}
                    pendingBookings={pendingBookings.bookings} />}
                {/*  */}
                {this.state.eventClicked && this.renderBookingRequest(this.state.event)}
            </div>
        )
    }
}
const mapStateToProps = (state) => ({
    pendingBookings: state.bookings.pendingBookings,
    requestUserInfo: state.bookings.requestUserInfo,
    width: state.events.width,
    translate: getTranslate(state.locale)
})

const mapDispachToProps = {
    getPendingBookings,
    updateBookingStatus,
    getUserInfo
}
export default connect(mapStateToProps, mapDispachToProps)(Alert)