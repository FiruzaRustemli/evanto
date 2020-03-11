import { oauth, urlConfig } from '../config'
import { getAllBookingNotifications, getNewBookingNotifications } from '../store/notificationReducer'
import { getAllBookings } from '../routes/Bookings/modules/bookings'

const signalRStart = (store, id, success, error) => {
    window.$ = $
    $.connection.hub.url = `${urlConfig.getSignalRUrl()}`
    $.connection.hub.qs = { UserId: id }

    let serviceHub = $.connection.serviceHub
    window._hub = serviceHub
    _hub.client.statusChanged = function (bookingId, statusId) {
        store.dispatch({
            type: 'ALERT',
            payload: 'SUCCESS'
        })
    }

    _hub.client.refreshNotifications = function () {
        let bookingNotifications = store.getState().notification 
        && store.getState().notification.notifications
        && store.getState().notification.notifications.bookingNotifications
        if(bookingNotifications && bookingNotifications.length > 0) {
            store.dispatch(getNewBookingNotifications({ lastNotificationId: bookingNotifications[0].id, isNew: 1}))
            store.dispatch({
                type: 'CHECK_NEW_BOOKINGS'
            })
            setTimeout(() => {
                store.dispatch({
                    type: 'CHECK_NEW_BOOKINGS_RESET'
                })
            }, 1000)
        }
    }

    _hub.client.sendClient = (e) => {
    }

    $.connection.hub.start()
        .done(() => success())
        .fail(() => error());
}

export default signalRStart