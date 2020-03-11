
import ServicesView from './view/services'
import NewService from './routes/newService'
import EditService from './routes/editService'
import Services from './routes/services'

export const makeServiceRoutes = (store) => ({
  path: 'services',
  component: ServicesView,
  indexRoute: Services(store),
  childRoutes: [
    NewService(store),
    EditService(store)
  ]
})

export default makeServiceRoutes