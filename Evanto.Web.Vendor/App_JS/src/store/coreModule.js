import { AccountApi as api } from '../services/controllers'
import { login } from '../routes/Login/modules/login'
import { hashHistory } from 'react-router'

const ACTION_HANDLERS = {}
const initialState = { requestPending: false }

// ------------------------------------
// Constants
// ------------------------------------
export const GET_VENDOR_DETAILS_REQUEST = 'GET_VENDOR_DETAILS_REQUEST'
export const GET_VENDOR_DETAILS_SUCCESS = 'GET_VENDOR_DETAILS_SUCCESS'
export const GET_VENDOR_DETAILS_ERROR = 'GET_VENDOR_DETAILS_ERROR'

export const VERIFY_ACCOUNT_REQUEST = 'VERIFY_ACCOUNT_REQUEST'
export const VERIFY_ACCOUNT_SUCCESS = 'VERIFY_ACCOUNT_SUCCESS'
export const VERIFY_ACCOUNT_ERROR = 'VERIFY_ACCOUNT_ERROR'

export const SEND_CODE_REQUEST = 'SEND_CODE_REQUEST'
export const SEND_CODE_SUCCESS = 'SEND_CODE_SUCCESS'
export const SEND_CODE_ERROR = 'SEND_CODE_ERROR'
// ------------------------------------
// Actions
// ------------------------------------
function getVendorDetailsRequest() {
  return {
    type: GET_VENDOR_DETAILS_REQUEST
  }
}

function getVendorDetailsSuccess(vendor) {
  return {
    type: GET_VENDOR_DETAILS_SUCCESS,
    payload: vendor
  }
}

function getVendorDetailsError(error) {
  return {
    type: GET_VENDOR_DETAILS_ERROR,
    error
  }
}

export const getVendorDetails = (currentBookingType) => {
  return (dispatch) => {
    return new Promise((resolve, reject) => {
      dispatch(getVendorDetailsRequest())
      api.getVendorDetails()
        .then(vendor => {
          dispatch(getVendorDetailsSuccess(vendor))
        })
        .catch(error => {
          dispatch(getVendorDetailsError(error))
        })
    })
  }
}

export const verifyAccount = (args) => {
  return dispatch => {
    return new Promise((resolve, reject) => {
      dispatch({
        type: VERIFY_ACCOUNT_REQUEST
      })
      api.verifyAccount(args)
        .then(response => {
          debugger
          dispatch({
            type: VERIFY_ACCOUNT_SUCCESS,
            payload: response,
            meta: {
              username: args.username,
              password: args.passwordString
            }
          })
        })
        .catch(error => {
          debugger
          dispatch({
            type: VERIFY_ACCOUNT_ERROR,
            error : {
              error,
              notify: true,
              type: 'error',
              message: error.response
              && error.response.data
              && error.response.data.errorList
              && (error.response.data.errorList.length > 0)
              ? error.response.data.errorList.map(er => {
                return er.code ? `##${er.code}` : er.text
              })
              : ['##unhandledError']
            }
          })
          hashHistory.push('/login')
        })
    })
  }
}

export const sendCode = (args) => {
  return dispatch => {
    return new Promise((resolve, reject) => {
      dispatch({
        type: SEND_CODE_REQUEST
      })
      api.sendCode(args)
        .then(response => {
          dispatch({
            type: SEND_CODE_SUCCESS,
            payload: {
              result: response,
              notify: true,
              type: 'success',
              message: ['##codeSuccessfullySended']
            }
          })
        })
        .catch(error => {
          dispatch({
            type: SEND_CODE_ERROR,
            error: {
              error,
              notify: true,
              type: 'error',
              message: error.response
              && error.response.data
              && error.response.data.errorList
              && (error.response.data.errorList.length > 0)
              ? error.response.data.errorList.map(er => {
                return er.code ? `##${er.code}` : er.text
              })
              : ['##unhandledError']
            }
          })
        })
    })
  }
}

// ------------------------------------
// Action Handlers
// ------------------------------------
Object.assign(ACTION_HANDLERS, {
  [GET_VENDOR_DETAILS_REQUEST]: (state) => {
    return {
      ...state,
      requestPending: true
    }
  },
  [GET_VENDOR_DETAILS_SUCCESS]: (state, action) => {
    return {
      ...state,
      requestPending: false,
      vendor: action.payload.vendor,
      userSettings: action.payload.vendor.userSettings
    }
  },
  [GET_VENDOR_DETAILS_ERROR]: (state, action) => {
    return {
      ...state,
      requestPending: false,
      error: action.error
    }
  },
  [`UPDATE_USER_SETTINGS_REQUEST`]: (state, action) => {
    return {
      ...state
    }
  },
  [`UPDATE_USER_SETTINGS_SUCCESS`]: (state, action) => {
    debugger
    let userSettings = state.userSettings
    userSettings.languageId = action.payload.languageId
    return {
      ...state,
      userSettings: {
        id: userSettings.id,
        languageId: userSettings.languageId,
        theme: userSettings.theme
      }
    }
  },
  [`UPDATE_USER_SETTINGS_ERROR`]: (state, action) => {
    return {
      ...state,
      error: action.error
    }
  },
  ['SIGN_ME_UP_EXECUTED']: (state, action) => {
    return {
      ...state,
      userInformation: action.payload
    }
  }
})

// ------------------------------------
// Reducer
// --------------------
export default function coreReducer(state = initialState, action) {
  const handler = ACTION_HANDLERS[action.type]

  return handler ? handler(state, action) : state
}

