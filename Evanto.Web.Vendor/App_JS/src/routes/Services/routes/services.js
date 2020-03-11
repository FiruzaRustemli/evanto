import { injectReducer } from '../../../store/reducers'

export default (store) => ({
  path: 'services',
  getComponent(nextState, cb) {
    require.ensure([], (require) => {
      const Services = require('../containers/services').default
      const reducer = require('../modules/services').default
      injectReducer(store, { key: 'services', reducer })
      cb(null, Services)
    }, 'services')
  }
})
