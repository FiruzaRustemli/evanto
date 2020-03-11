const ACTION_HANDLERS = {}
const initialState = { error: undefined, width: window.innerWidth, height: window.innerHeight }

// ------------------------------------
// Constants
// ------------------------------------
export const RESIZE = 'RESIZE'

export const resize = (payload) => {
  return {
    type: RESIZE,
    payload
  }
}
// ------------------------------------
// Action Handlers
// ------------------------------------
Object.assign(ACTION_HANDLERS, {
  [RESIZE]: (state, action) => {
    return {
      ...state,
      width: action.payload.width,
      height: action.payload.height
    }
  },
  ['ALERT']: (state, action) => {
    alert(`SIGNALR ${action.payload}`)
    return {
      ...state
    }
  }
})

// ------------------------------------
// Reducer
// --------------------
export default function eventListenerReducer(state = initialState, action) {
  const handler = ACTION_HANDLERS[action.type]

  return handler ? handler(state, action) : state
}

