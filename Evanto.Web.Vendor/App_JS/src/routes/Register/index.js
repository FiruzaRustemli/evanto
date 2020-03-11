import { injectReducer } from '../../store/reducers'

export default (store) => ({
  path : '',
  getComponent (nextState, cb) {
    require.ensure([], (require) => {
      const Bookings = require('./containers/register').default
      const reducer = require('./modules/index').default
      injectReducer(store, { key: 'login', reducer })
      cb(null, Bookings)
    }, 'register')
  }
})