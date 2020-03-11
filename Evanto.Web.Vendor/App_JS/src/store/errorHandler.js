import { AccountApi as api } from '../services/controllers'
import { hashHistory } from 'react-router'

const ACTION_HANDLERS = {}
const initialState = { error: undefined }

// ------------------------------------
// Constants
// ------------------------------------
export const UNAUTHORIZED = 'UNAUTHORIZED'
export const INVALID_LOGIN_INPUT = 'INVALID_LOGIN_INPUT'
export const VALIDATION_ERR = 'VALIDATION_ERR'
export const INTERNAL_ERR = 'INTERNAL_ERR'
export const OTHER = 'OTHER'
export const RESET = 'RESET'

export const unauthorized = (error) => {
  return {
    type: UNAUTHORIZED,
    error
  }
}
export const invalidLoginInput = (error) => {
  return {
    type: INVALID_LOGIN_INPUT,
    error
  }
}
export const validationError = (error) => {
  return {
    type: VALIDATION_ERR,
    error
  }
}
export const internalError = (error) => {
  return {
    type: INTERNAL_ERR,
    error
  }
}
export const other = (error) => {
  return {
    type: OTHER,
    error
  }
}

export const reset = (error) => {
  return {
    type: RESET,
    error
  }
}
// ------------------------------------
// Action Handlers
// ------------------------------------
Object.assign(ACTION_HANDLERS, {
  [INVALID_LOGIN_INPUT]: (state, action) => {
    return {
      ...state,
      error: action.error
    }
  },
  [UNAUTHORIZED]: (state, action) => {
    return {
      ...state,
      error: action.error
    }
  },
  [RESET]: (state) => {
    return {
      ...state,
      error: undefined
    }
  }
})

// ------------------------------------
// Reducer
// --------------------
export default function errorReducer(state = initialState, action) {
  const handler = ACTION_HANDLERS[action.type]

  return handler ? handler(state, action) : state
}

