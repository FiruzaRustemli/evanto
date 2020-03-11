import { injectReducer } from '../../store/reducers'

export default (store) => ({
  path : '/',
  getComponent (nextState, cb) {
    require.ensure([], (require) => {
      const Bookings = require('./components/bookings').default
      const reducer = require('./modules/bookings').default
      injectReducer(store, { key: 'bookings', reducer })
      cb(null, Bookings)
    }, 'bookings')
  }
})