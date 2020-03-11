import { BookingApi as api } from '../../../services/controllers'
import { bookingStatus } from '../../../config'
import moment from 'moment'
import _ from 'lodash'

const ACTION_HANDLERS = {}
const initialState = { requestPending: false }


// --------------------
// Reducer
// --------------------
export default function notificationReducer(state = initialState, action) {
  const handler = ACTION_HANDLERS[action.type]

  return handler ? handler(state, action) : state
}