import { injectReducer } from '../../../store/reducers'

export default (store) => ({
  path : 'new',
  getComponent (nextState, cb) {
    require.ensure([], (require) => {
      const NewServices = require('../containers/newServicesContainer').default
      const reducer = require('../modules/services').default
      injectReducer(store, { key: 'services', reducer })
      cb(null, NewServices)
    }, 'newServices')
  }
})
