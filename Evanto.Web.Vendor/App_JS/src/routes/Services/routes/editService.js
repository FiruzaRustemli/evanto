import { injectReducer } from '../../../store/reducers'

export default (store) => ({
  path: 'edit/:id',
  getComponent(nextState, cb) {
    require.ensure([], (require) => {
      const Services = require('../containers/editService').default
      const reducer = require('../modules/services').default
      injectReducer(store, { key: 'services', reducer })
      cb(null, Services)
    }, 'editServices')
  }
})
