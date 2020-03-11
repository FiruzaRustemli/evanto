// We only need to import the modules necessary for initial render
import CoreLayout from '../layouts/CoreLayout'
import { oauth, languageKey } from '../config'
import { hashHistory } from 'react-router'
import CounterRoute from './Counter'
import Bookings from './Bookings'
import Account from './Account'
import Services from './Services'
import LoginLayout from '../layouts/LoginLayout'
import Login from './Login'
import Register from './Register'
import Notifications from './Notifications'
import VerifyAccount from './VerifyAccount'
/*  Note: Instead of using JSX, we recommend using react-router
    PlainRoute objects to build route definitions.   */
const requireAuth = () => {
  const token = localStorage.getItem(oauth.localStorageTokenKey)
  if (!token) {
    hashHistory.push('/login')
  }
}
export const createRoutes = (store) => ([
  {
    path: '/',
    component: CoreLayout,
    indexRoute: Bookings(store),
    onEnter: requireAuth,
    childRoutes: [
      CounterRoute(store),
      Account(store),
      Bookings(store),
      Services(store),
      Notifications(store)
    ]
  }, {
    path: '/login',
    component: LoginLayout,
    indexRoute: Login(store)
  }, {
    path: '/register',
    component: LoginLayout,
    indexRoute: Register(store)
  },
  {
    path: '/verify',
    component: LoginLayout,
    indexRoute: VerifyAccount(store)
  }
])

/*  Note: childRoutes can be chunked or otherwise loaded programmatically
    using getChildRoutes with the following signature:

    getChildRoutes (location, cb) {
      require.ensure([], (require) => {
        cb(null, [
          // Remove imports!
          require('./Counter').default(store)
        ])
      })
    }

    However, this is not necessary for code-splitting! It simply provides
    an API for async route definitions. Your code splitting should occur
    inside the route `getComponent` function, since it is only invoked
    when the route exists and matches.
*/

export default createRoutes
