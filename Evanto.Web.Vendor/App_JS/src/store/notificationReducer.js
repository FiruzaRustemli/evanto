import { NotificationApi as api } from '../services/controllers'
import { hashHistory } from 'react-router'

const ACTION_HANDLERS = {}
const initialState = { error: undefined, isNotificationLoading: false }

// ------------------------------------
// Constants
// ------------------------------------
export const NOTIFY = 'NOTIFY'
export const GET_BOOKING_NOTIFICATIONS_REQUEST = 'GET_BOOKING_NOTIFICATIONS_REQUEST'
export const GET_BOOKING_NOTIFICATIONS_SUCCESS = 'GET_BOOKING_NOTIFICATIONS_SUCCESS'
export const GET_BOOKING_NOTIFICATIONS_ERROR = 'GET_BOOKING_NOTIFICATIONS_ERROR'
export const GET_NEW_BOOKING_NOTIFICATIONS_REQUEST = 'GET_NEW_BOOKING_NOTIFICATIONS_REQUEST'
export const GET_NEW_BOOKING_NOTIFICATIONS_SUCCESS = 'GET_NEW_BOOKING_NOTIFICATIONS_SUCCESS'
export const GET_NEW_BOOKING_NOTIFICATIONS_ERROR = 'GET_NEW_BOOKING_NOTIFICATIONS_ERROR'
export const UPDATE_BOOKING_NOTIFICATION_REQUEST = 'UPDATE_BOOKING_NOTIFICATION_REQUEST'
export const UPDATE_BOOKING_NOTIFICATION_SUCCESS = 'UPDATE_BOOKING_NOTIFICATION_SUCCESS'
export const UPDATE_BOOKING_NOTIFICATION_ERROR = 'UPDATE_BOOKING_NOTIFICATION_ERROR'
export const RESET_NOTIFICATIONS = 'RESET_NOTIFICATIONS'

export const getAllBookingNotifications = (args) => {
  console.log('nuasdf gerli mi')
  return (dispatch) => {
    return new Promise((resolve, reject) => {
      dispatch({
        type: GET_BOOKING_NOTIFICATIONS_REQUEST
      })
      api.getBookingNotifications(args)
        .then(notifications => {
          dispatch({
            type: GET_BOOKING_NOTIFICATIONS_SUCCESS,
            payload: notifications,
            firstly: (args && args.firstly)
          })
        })
        .catch(error => {
          dispatch({
            type: GET_BOOKING_NOTIFICATIONS_ERROR,
            error
          })
        })
    })
  }
}

export const getNewBookingNotifications = (args) => {
  return (dispatch) => {
    return new Promise((resolve, reject) => {
      dispatch({
        type: GET_NEW_BOOKING_NOTIFICATIONS_REQUEST
      })
      api.getBookingNotifications(args)
        .then(notifications => {
          dispatch({
            type: GET_NEW_BOOKING_NOTIFICATIONS_SUCCESS,
            payload: notifications
          })
        })
        .catch(error => {
          dispatch({
            type: GET_NEW_BOOKING_NOTIFICATIONS_ERROR,
            error
          })
        })
    })
  }
}

export const updateBookingNotifications = (args) => {
  return (dispatch) => {
    return new Promise((resolve, reject) => {
      dispatch({
        type: UPDATE_BOOKING_NOTIFICATION_REQUEST
      })
      api.updateBookingNotification(args)
        .then(notification => {
          dispatch({
            type: UPDATE_BOOKING_NOTIFICATION_SUCCESS,
            payload: notification
          })
        })
        .catch(error => {
          dispatch({
            type: UPDATE_BOOKING_NOTIFICATION_ERROR,
            error
          })
        })
    })
  }
}

export const notify = (payload) => {
  return {
    type: NOTIFY,
    payload
  }
}

export const resetNotifications = () => {
  return dispatch => {
    return new Promise((resolve, reject) => {
      dispatch({
        type: RESET_NOTIFICATIONS
      })
    })
  }
}
// ------------------------------------
// Action Handlers
// ------------------------------------
Object.assign(ACTION_HANDLERS, {
  [NOTIFY]: (state, action) => {
    return {
      ...state,
      type: action.payload.type,
      message: action.payload.message,
      notify: action.payload.notify
    }
  },
  [RESET_NOTIFICATIONS]: (state, action) => {
    let bookingNotifications = state.notifications && state.notifications.bookingNotifications.slice(0, 10)
    return {
      ...state,
      notifications: { bookingNotifications }
    }
  },
  ['REMOVE_NOTIFICATION']: (state, action) => {
    return {
      ...state,
      notify: false
    }
  },
  [GET_BOOKING_NOTIFICATIONS_REQUEST]: (state, action) => {
    return {
      ...state,
      isNotificationLoading: true
    }
  },
  [GET_BOOKING_NOTIFICATIONS_SUCCESS]: (state, action) => {
    let bookingNotifications = (state.notifications
      && state.notifications.bookingNotifications
      && state.notifications.bookingNotifications.length > 0 && !action.firstly)
      ? state.notifications.bookingNotifications : []
    let newBNots = bookingNotifications.concat(action.payload.bookingNotifications)
    return {
      ...state,
      notifications: { bookingNotifications: newBNots },
      unreadCount: action.payload.unreadCount,
      isNotificationLoading: false
    }
  },
  [GET_BOOKING_NOTIFICATIONS_ERROR]: (state, action) => {
    return {
      ...state,
      error: action.error,
      isNotificationLoading: false
    }
  },
  [UPDATE_BOOKING_NOTIFICATION_REQUEST]: (state, action) => {
    return {
      ...state
    }
  },
  [UPDATE_BOOKING_NOTIFICATION_ERROR]: (state, action) => {
    return {
      ...state,
      error: action.error
    }
  },
  [UPDATE_BOOKING_NOTIFICATION_SUCCESS]: (state, action) => {
    let index = state.notifications.bookingNotifications.findIndex(x => x.id === action.payload.bookingNotification.id)
    let some = state.notifications.bookingNotifications.map((item, key) => {
      if (item.id === action.payload.bookingNotification.id) {
        item = action.payload.bookingNotification
      }
      return item
    })
    return {
      ...state,
      notifications: { bookingNotifications: some },
      unreadCount: state.unreadCount - 1
    }
  },
  [GET_NEW_BOOKING_NOTIFICATIONS_REQUEST]: (state, action) => {
    return {
      ...state
    }
  },
  [GET_NEW_BOOKING_NOTIFICATIONS_SUCCESS]: (state, action) => {
    let bookingNotifications = action.payload
      && action.payload.bookingNotifications
      && action.payload.bookingNotifications
        .concat(state.notifications.bookingNotifications)
    return {
      ...state,
      notifications: { bookingNotifications },
      unreadCount: action.payload.unreadCount
    }
  },
  [GET_NEW_BOOKING_NOTIFICATIONS_ERROR]: (state, action) => {
    return {
      ...state,
      error: action.error
    }
  }
})

// ------------------------------------
// Reducer
// --------------------
export default function notificationReducer(state = initialState, action) {
  const handler = ACTION_HANDLERS[action.type]

  return handler ? handler(state, action) : state
}

