import { injectReducer } from '../../store/reducers'

export default (store) => ({
  path : '',
  getComponent (nextState, cb) {
    require.ensure([], (require) => {
      const Bookings = require('./containers/login').default
      const reducer = require('./modules/login').default
      injectReducer(store, { key: 'login', reducer })
      cb(null, Bookings)
    }, 'login')
  }
})