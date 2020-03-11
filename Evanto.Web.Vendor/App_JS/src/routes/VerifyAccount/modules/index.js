import { AccountApi as api } from '../../../services/controllers'
import { hashHistory } from 'react-router'
import { oauth } from '../../../config'
import { SubmissionError } from 'redux-form'

const ACTION_HANDLERS = {}
const initialState = {
  requestPending: false
}

//-------------------------------------------------------------
//login start
//-------------------------------------------------------------
export const REGISTER_REQUEST = 'REGISTER_REQUEST'
export const REGISTER_SUCCESS = 'REGISTER_SUCCESS'
export const REGISTER_ERROR = 'REGISTER_ERROR'
export const CLEAR_ERROR = 'CLEAR_ERROR'

const registerRequest = () => {
  return {
    type: REGISTER_REQUEST
  }
}

const registerSuccess = ({response, meta}) => {
  return {
    type: REGISTER_SUCCESS,
    payload: response,
    meta
  }
}

const registerError = (error) => {
  return {
    type: REGISTER_ERROR,
    error
  }
}

export const register = (params) => {
  return (dispatch, getState) => {
    return new Promise((resolve, reject) => {
      dispatch(registerRequest())
      api.register(params)
        .then(response => {
          dispatch(registerSuccess({response, meta: {
            username: params.username,
            password: params.passwordString
          }}))
        }).catch(error => {
          dispatch(registerError(error.response))
        })
    })
  }
}

export const clearError = () => {
  return (dispatch, getState) => {
    return new Promise((resolve, reject) => {
      dispatch({ type: CLEAR_ERROR })
    })
  }
}

Object.assign(ACTION_HANDLERS, {
    [REGISTER_REQUEST]: (state) => {
      return {
        ...state,
        requestPendingRegister: true,
        error: undefined
      }
    },
    [REGISTER_SUCCESS]: (state, action) => {
      return {
        ...state,
        requestPendingRegister: false,
        meta: action.payload
      }
    },
    [REGISTER_ERROR]: (state, action) => {
      return {
        ...state,
        requestPendingRegister: false,
        error: action.error.error
      }
    },
    [CLEAR_ERROR]: (state, action) => {
      return {
        ...state,
        requestPendingRegister: false,
        error: false
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
