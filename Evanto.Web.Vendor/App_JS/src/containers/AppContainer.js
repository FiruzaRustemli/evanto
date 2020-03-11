import React, { Component, PropTypes } from 'react'
import { hashHistory, Router } from 'react-router'
import { Provider } from 'react-redux'
import 'react-notifications/lib/notifications.css'
import { syncHistoryWithStore } from 'react-router-redux'
import Notification from './Notification'

class AppContainer extends Component {
  static propTypes = {
    routes: PropTypes.array.isRequired,
    store: PropTypes.object.isRequired
  }

  shouldComponentUpdate() {
    return false
  }


  render() {
    
    const { routes, store } = this.props
    const history = syncHistoryWithStore(hashHistory, store)
    
    return (
        <Provider store={store}>
          <div style={{ height: '100%' }}>
            <Router history={history} children={routes} />
            <Notification />
          </div>
        </Provider>
    )
  }
}



export default AppContainer
