import { BookingApi as api } from '../../../services/controllers'
import { bookingStatus } from '../../../config'
import moment from 'moment'
import _ from 'lodash'

const ACTION_HANDLERS = {}
const initialState = { requestPending: false, checkNewBookings: false }

// ------------------------------------
// Constants
// ------------------------------------
export const GET_ALL_BOOKINGS_REQUEST = 'GET_ALL_BOOKINGS_REQUEST'
export const GET_ALL_BOOKINGS_SUCCESS = 'GET_ALL_BOOKINGS_SUCCESS'
export const GET_ALL_BOOKINGS_ERROR = 'GET_ALL_BOOKINGS_ERROR'

// ------------------------------------
// Actions
// ------------------------------------
function getAllBookingsRequest() {
  return {
    type: GET_ALL_BOOKINGS_REQUEST
  }
}

function getAllBookingsSuccess(bookings) {
  return {
    type: GET_ALL_BOOKINGS_SUCCESS,
    payload: bookings
  }
}

function getAllBookingsError(error) {
  return {
    type: GET_ALL_BOOKINGS_ERROR,
    error
  }
}

export const getAllBookings = (args) => {
  return (dispatch) => {
    return new Promise((resolve, reject) => {
      dispatch(getAllBookingsRequest())
      api.getBookingsByStatus({ statusId: args.status, date: args.date })
        .then(bookings => {
          dispatch(getAllBookingsSuccess(bookings))
        })
        .catch(error => {
          dispatch(getAllBookingsError(error))
        })
    })
  }
}


// ------------------------------------
// Action Handlers
// ------------------------------------
Object.assign(ACTION_HANDLERS, {
  [GET_ALL_BOOKINGS_REQUEST]: (state) => {
    return {
      ...state,
      requestPending: true
    }
  },
  [GET_ALL_BOOKINGS_SUCCESS]: (state, action) => {
    return {
      ...state,
      requestPending: false,
      bookings: [].concat(action.payload.bookings)
    }
  },
  [GET_ALL_BOOKINGS_ERROR]: (state, action) => {
    return {
      ...state,
      requestPending: false,
      error: action.error
    }
  }
})


export const CREATE_BOOKING_REQUEST = 'CREATE_BOOKING_REQUEST'
export const CREATE_BOOKING_SUCCESS = 'CREATE_BOOKING_SUCCESS'
export const CREATE_BOOKING_ERROR = 'CREATE_BOOKING_ERROR'

// ------------------------------------
// Actions
// ------------------------------------
function createBookingRequest() {
  return {
    type: CREATE_BOOKING_REQUEST
  }
}

function createBookingSuccess(bookings) {
  return {
    type: CREATE_BOOKING_SUCCESS,
    payload: bookings
  }
}

function createBookingError(error) {
  return {
    type: CREATE_BOOKING_ERROR,
    error: error
  }
}

export const createBooking = (args) => {
  return (dispatch) => {
    return new Promise((resolve, reject) => {
      dispatch(createBookingRequest())
      api.createBooking(args)
        .then(bookings => {
          dispatch(createBookingSuccess({
            bookings,
            notify: true,
            type: 'success',
            message: ['##successfullyAdded']
          }))
        })
        .catch(error => {
          dispatch(createBookingError({
            error,
            notify: true,
            type: 'error',
            message: (error.data && error.data.errorList && error.data.errorList.length > 0) ? error.data.errorList : ['##unhandledError']
          }))
        })
    })
  }
}


// ------------------------------------
// Action Handlers
// ------------------------------------
Object.assign(ACTION_HANDLERS, {
  [CREATE_BOOKING_REQUEST]: (state) => {
    return {
      ...state,
      requestPending: true
    }
  },
  [CREATE_BOOKING_SUCCESS]: (state, action) => {
    return {
      ...state,
      requestPending: false,
      createdBooking: action.payload.bookings.booking,
      bookings: state.bookings 
      ? state.bookings.concat(action.payload.bookings.booking)
      : [].concat(action.payload.bookings.booking)
    }
  },
  [CREATE_BOOKING_ERROR]: (state, action) => {
    return {
      ...state,
      requestPending: false,
      error: action.error.error
    }
  }
})


const UPDATE_BOOKING_STATUS_REQUEST = 'UPDATE_BOOKING_STATUS_REQUEST'
const UPDATE_BOOKING_STATUS_SUCCESS = 'UPDATE_BOOKING_STATUS_SUCCESS'
const UPDATE_BOOKING_STATUS_ERROR = 'UPDATE_BOOKING_STATUS_ERROR'
const UPDATE_BOOKING_STATUS_EXTERNAL = 'UPDATE_BOOKING_STATUS_EXTERNAL'

function updateBookingStatusRequest() {
  return {
    type: UPDATE_BOOKING_STATUS_REQUEST
  }
}

function updateBookingStatusSuccess(booking) {
  return {
    type: UPDATE_BOOKING_STATUS_SUCCESS,
    payload: booking
  }
}

function updateBookingStatusError(error) {
  return {
    type: UPDATE_BOOKING_STATUS_ERROR,
    error: error
  }
}

function updateBookingStatusIsExternal(id) {
  return {
    type: UPDATE_BOOKING_STATUS_EXTERNAL,
    payload: id
  }
}

export const updateBookingStatus = (args) => {
  return (dispatch) => {
    return new Promise((resolve, reject) => {
      dispatch(updateBookingStatusRequest())
      api.updateBookingStatus(args)
        .then(response => {
          if(args.isExternal) {
            dispatch(updateBookingStatusIsExternal(args.id))
          }
          dispatch(updateBookingStatusSuccess({
            booking: Object.assign({}, response.booking, { id: args.id }),
            notify: true,
            type: 'success',
            message: ['##successfullyUpdated']
          }))
        })
        .catch(error => {
          dispatch(updateBookingStatusError({
            error,
            notify: true,
            type: 'error',
            message: (error.data && error.data.errorList && error.data.errorList.length > 0) ? error.data.errorList : ['##unhandledError']
          }))
        })
    })
  }
}

Object.assign(ACTION_HANDLERS, {
  [UPDATE_BOOKING_STATUS_REQUEST]: (state) => {
    return {
      ...state,
      requestPending: true
    }
  },
  [UPDATE_BOOKING_STATUS_SUCCESS]: (state, action) => {
    let bookings = state.bookings ? state.bookings : []
    const newBookings = bookings.map(item => {
      if(item.id === action.payload.booking.id){
        item.statusId = action.payload.booking.statusId
      }
      return item
    })
    let newPendings = []
    if(_.map(state.pendingBookings.bookings, 'id').includes(action.payload.booking.id)) {
      newPendings = state.pendingBookings.bookings.filter(item => {
        return item.id !== action.payload.booking.id
      })
    }
    return {
      ...state,
      bookings: newBookings,
      requestPending: false,
      updatedBooking: action.payload.booking,
      pendingBookings:  newPendings.length > 0 && { bookings: newPendings }
    }
  },
  [UPDATE_BOOKING_STATUS_ERROR]: (state, action) => {
    return {
      ...state,
      requestPending: false,
      error: action.error
    }
  },
  [UPDATE_BOOKING_STATUS_EXTERNAL]: (state, action) => {
    var newPendingBookings = state.pendingBookings.bookings.filter(item => {
      return item.id !== action.payload
    })
    return {
      ...state,
      requestPending: false,
      pendingBookings: { bookings: newPendingBookings }
    }
  }
})

const GET_USER_INFO_REQUEST = 'GET_USER_INFO_REQUEST'
const GET_USER_INFO_SUCCESS = 'GET_USER_INFO_SUCCESS'
const GET_USER_INFO_ERROR = 'GET_USER_INFO_ERROR'

function getUserInfoRequest() {
  return {
    type: GET_USER_INFO_REQUEST
  }
}

function getUserInfoSuccess(userInfo) {
  return {
    type: GET_USER_INFO_SUCCESS,
    payload: userInfo
  }
}

function getUserInfoError(error) {
  return {
    type: GET_USER_INFO_ERROR,
    error: error
  }
}

export const getUserInfo = (args) => {
  return (dispatch) => {
    return new Promise((resolve, reject) => {
      dispatch(getUserInfoRequest())
      api.getRequestUserInfo(args)
        .then(response => {
          dispatch(getUserInfoSuccess(response))
        })
        .catch(error => {
          dispatch(getUserInfoError(error))
        })
    })
  }
}

Object.assign(ACTION_HANDLERS, {
  [GET_USER_INFO_REQUEST]: (state) => {
    return {
      ...state,
      requestPending: true
    }
  },
  [GET_USER_INFO_SUCCESS]: (state, action) => {
    return {
      ...state,
      requestPending: false,
      requestUserInfo: action.payload    
    }
  },
  [GET_USER_INFO_ERROR]: (state, action) => {
    return {
      ...state,
      requestPending: false,
      error: action.error
    }
  }
})

const GET_ACTIVE_VENDOR_SERVICES_REQUEST = 'GET_ACTIVE_VENDOR_SERVICES_REQUEST'
const GET_ACTIVE_VENDOR_SERVICES_SUCCESS = 'GET_ACTIVE_VENDOR_SERVICES_SUCCESS'
const GET_ACTIVE_VENDOR_SERVICES_ERROR = 'GET_ACTIVE_VENDOR_SERVICES_ERROR'

function getActiveVendorServicesRequest() {
  return {
    type: GET_ACTIVE_VENDOR_SERVICES_REQUEST
  }
}

function getActiveVendorServicesSuccess(vendorServices) {
  return {
    type: GET_ACTIVE_VENDOR_SERVICES_SUCCESS,
    payload: vendorServices
  }
}

function getActiveVendorServicesError(error) {
  return {
    type: GET_ACTIVE_VENDOR_SERVICES_ERROR,
    error: error
  }
}

export const getActiveVendorServices = (args) => {
  return (dispatch) => {
    return new Promise((resolve, reject) => {
      dispatch(getActiveVendorServicesRequest())
      api.getActiveVendorServices(args)
        .then(response => {
          dispatch(getActiveVendorServicesSuccess(response))
        })
        .catch(error => {
          dispatch(getActiveVendorServicesError(error))
        })
    })
  }
}

Object.assign(ACTION_HANDLERS, {
  [GET_ACTIVE_VENDOR_SERVICES_REQUEST]: (state) => {
    return {
      ...state,
      requestPending: true
    }
  },
  [GET_ACTIVE_VENDOR_SERVICES_SUCCESS]: (state, action) => {
    return {
      ...state,
      requestPending: false,
      activeVendorServices: action.payload    
    }
  },
  [GET_ACTIVE_VENDOR_SERVICES_ERROR]: (state, action) => {
    return {
      ...state,
      requestPending: false,
      error: action.error
    }
  }
})

const GET_PENDING_BOOKINGS_REQUEST = 'GET_PENDING_BOOKINGS_REQUEST'
const GET_PENDING_BOOKINGS_SUCCESS = 'GET_PENDING_BOOKINGS_SUCCESS'
const GET_PENDING_BOOKINGS_ERROR = 'GET_PENDING_BOOKINGS_ERROR'

function getPendingBookingsRequest() {
  return {
    type: GET_PENDING_BOOKINGS_REQUEST
  }
}

function getPendingBookingsSuccess(bookings) {
  return {
    type: GET_PENDING_BOOKINGS_SUCCESS,
    payload: bookings
  }
}

function getPendingBookingsError(error) {
  return {
    type: GET_PENDING_BOOKINGS_ERROR,
    error: error
  }
}

export const getPendingBookings = () => {
  return (dispatch) => {
    return new Promise((resolve, reject) => {
      dispatch(getPendingBookingsRequest())
      api.getBookingsByStatus({statusId: 7, date: moment().format('LLL')})
        .then(response => {
          dispatch(getPendingBookingsSuccess(response))
        })
        .catch(error => {
          dispatch(getPendingBookingsError(error))
        })
    })
  }
}

Object.assign(ACTION_HANDLERS, {
  [GET_PENDING_BOOKINGS_REQUEST]: (state) => {
    return {
      ...state,
      requestPending: true
    }
  },
  [GET_PENDING_BOOKINGS_SUCCESS]: (state, action) => {
    return {
      ...state,
      requestPending: false,
      pendingBookings: action.payload    
    }
  },
  [GET_PENDING_BOOKINGS_ERROR]: (state, action) => {
    return {
      ...state,
      requestPending: false,
      error: action.error
    }
  },
  ['CHANGE_CALENDAR_TOOLBAR_TITLE']: (state, action) => {
    return {
      ...state,
      calendarViewTitle: action.payload
    }
  },
  ['CHECK_NEW_BOOKINGS'] : (state, action) => {
    return {
      ...state,
      checkNewBookings: true
    }
  },
  ['CHECK_NEW_BOOKINGS_RESET']: (state, action) => {
    return {
      ...state,
      checkNewBookings: false
    }
  }
})

export const editToolbarTitle = (text) => {
  return (dispatch) => {
    return new Promise((resolve, reject) => {
      dispatch({
        type: 'CHANGE_CALENDAR_TOOLBAR_TITLE',
        payload: text
      })
    })
  }
}

// --------------------
// Reducer
// --------------------
export default function bookingReducer(state = initialState, action) {
  const handler = ACTION_HANDLERS[action.type]

  return handler ? handler(state, action) : state
}