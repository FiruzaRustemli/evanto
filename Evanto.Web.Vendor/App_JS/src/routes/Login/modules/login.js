import { LoginApi as api } from '../../../services/controllers'
import { hashHistory } from 'react-router'
import { oauth, languageKey } from '../../../config'
import { getVendorDetails } from '../../Account/modules/account'
import { AccountApi } from '../../../services/controllers'

const ACTION_HANDLERS = {}
const initialState = {
  requestPending: false
}

//-------------------------------------------------------------
//login start
//-------------------------------------------------------------
export const LOGIN_REQUEST = 'LOGIN_REQUEST'
export const LOGIN_SUCCESS = 'LOGIN_SUCCESS'
export const LOGIN_ERROR = 'LOGIN_ERROR'
export const CLEAR_ERROR = 'CLEAR_ERROR'

export const loginRequest = () => {
  return {
    type: LOGIN_REQUEST
  }
}

export const loginSuccess = (token) => {
  return {
    type: LOGIN_SUCCESS,
    payload: token
  }
}

export const loginError = (error) => {
  return {
    type: LOGIN_ERROR,
    error
  }
}

export const clearError = () => {
  return (dispatch, getState) => {
    return new Promise((resolve, reject) => {
      dispatch({ type: CLEAR_ERROR })
    })
  }
}

export const login = (params) => {
  return (dispatch, getState) => {
    return new Promise((resolve, reject) => {
      dispatch(loginRequest())
      api.login(params)
        .then(response => {
          window.localStorage.setItem(oauth.localStorageTokenKey, response.access_token)
          AccountApi.getVendorDetails()
            .then(vendorDetails => {
              dispatch(loginSuccess({
                token: response.access_token,
                vendorId: vendorDetails.vendor.userId,
                notify: false,
                type: 'success',
                message: ['Xoş gəldiniz.']
              }))
              hashHistory.push('/')
            })
            .catch(error => {
              dispatch(loginError({
                error,
                notify: true,
                type: 'error',
                message: (error.data && error.data.errorList && error.data.errorList.length > 0) ? error.data.errorList : ['##unhandledError']
              }))
            })
        }).catch(error => {
          const err = error.responseJSON
          const errorJson = err && JSON.parse(err.error)
          const errorList = errorJson && errorJson.map(item => {
            return `##${item.Code}`
          })
          if (errorJson && errorJson[0].Code === 'UserAccountNotVerified') {
            dispatch({
              type: 'SIGN_ME_UP_EXECUTED',
              payload: { passwordString: params.password, username: params.username }
            })
            hashHistory.push('/verify')
          }
          dispatch(loginError({
            error,
            notify: true,
            type: 'error',
            message: (errorList && errorList.length > 0) ? errorList : ['##unhandledError']
          }))
        })
    })
  }
}

Object.assign(ACTION_HANDLERS, {
  [LOGIN_REQUEST]: (state) => {
    return {
      ...state,
      requestPendingLogin: true,
      error: undefined
    }
  },
  [LOGIN_SUCCESS]: (state, action) => {
    return {
      ...state,
      requestPendingLogin: false,
      accessToken: action.payload.token,
      vendorId: action.payload.vendorId
    }
  },
  [LOGIN_ERROR]: (state, action) => {
    return {
      ...state,
      requestPendingLogin: false,
      error: action.error.error
    }
  }
})
//-------------------------------------------------------------
//login end
//-------------------------------------------------------------

export default function accountReducer(state = initialState, action) {
  const handler = ACTION_HANDLERS[action.type]

  return handler ? handler(state, action) : state
}
