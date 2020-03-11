import { injectReducer } from '../../store/reducers'

export default (store) => ({
  path : '',
  getComponent (nextState, cb) {
    require.ensure([], (require) => {
      const Verify = require('./containers/verifyAccount').default
      const reducer = require('./modules/index').default
      injectReducer(store, { key: 'verifyAccount', reducer })
      cb(null, Verify)
    }, 'verifyAccount')
  }
})