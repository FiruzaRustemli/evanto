
const ACTION_HANDLERS = {}
const initialState = {
  requestPending: false
}

export const CLEAR_ERROR = 'CLEAR_ERROR'


Object.assign(ACTION_HANDLERS, {
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

export default function loginReducer(state = initialState, action) {
  const handler = ACTION_HANDLERS[action.type]

  return handler ? handler(state, action) : state
}
