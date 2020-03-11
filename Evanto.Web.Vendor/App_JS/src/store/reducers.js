import { combineReducers } from 'redux'
import { reducer as formReducer } from 'redux-form'
import locationReducer from './location'
import coreReducer from './coreModule'
import errorReducer from './errorHandler'
import loginReducer from './loginReducer'
import notificationReducer from './notificationReducer'
import bookingReducer from '../routes/Bookings/modules/bookings'
import { routerReducer } from 'react-router-redux'
import eventListenerReducer from './eventListenerReducer'
import { localeReducer } from 'react-localize-redux'

export const makeRootReducer = (asyncReducers) => {
  return combineReducers({
    location: locationReducer,
    account: coreReducer,
    login: loginReducer,  
    notification: notificationReducer,
    error: errorReducer,
    routing: routerReducer,
    bookings: bookingReducer,
    form: formReducer,
    events: eventListenerReducer,
    locale: localeReducer,
    ...asyncReducers
  })
}

export const injectReducer = (store, { key, reducer }) => {
  if (Object.hasOwnProperty.call(store.asyncReducers, key)) return

  store.asyncReducers[key] = reducer
  store.replaceReducer(makeRootReducer(store.asyncReducers))
}

export default makeRootReducer
