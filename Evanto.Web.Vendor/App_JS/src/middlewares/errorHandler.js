import { invalidLoginInput, reset, unauthorized, UNAUTHORIZED } from '../store/errorHandler'
import { LoginApi } from '../services/controllers'
import { oauth, urlConfig } from '../config/index'
import { hashHistory } from 'react-router'
import { loginError, loginSuccess } from '../routes/Login/modules/login'
const logger = store => next => action => {
  if (action.type) {
    if (action.type.includes('ERROR') && action.error) {
      if (action.error.responseJSON && action.error.responseJSON.error === 'invalid_grant') {
        store.dispatch(invalidLoginInput(action.error))
      } else if (action.error.response && action.error.response.status === 401 && action.type !== UNAUTHORIZED) {
        hashHistory.push('/login')
        store.dispatch(unauthorized(action.error))
      }
    }

    if (action.type === 'VERIFY_ACCOUNT_SUCCESS') {
      debugger
      let arg = Object.assign({}, action.meta, {
        grant_type: oauth.grant_type,
        client_id: oauth.client_id,
        client_secret: oauth.client_secret
      })
      LoginApi.login(arg)
        .then(response => {
          localStorage.setItem(oauth.localStorageTokenKey, response.access_token)
          store.dispatch(loginSuccess(response.access_token))
          hashHistory.push('/')
        }).catch(error => {
          store.dispatch(loginError(error))
        })
    }
  }

  if (action.type) {
    if(action.type.includes('SUCCESS') && (action.payload && action.payload.notify)) {
      store.dispatch({
        type: 'NOTIFY',
        payload: {
          notify: action.payload.notify,
          type: action.payload.type,
          message: action.payload.message
        }
      })
    } else if(action.type.includes('ERROR') && (action.error && action.error.notify)) {
      store.dispatch({
        type: 'NOTIFY',
        payload: {
          notify: action.error.notify,
          type: action.error.type,
          message: action.error.message
        }
      })
    }

    // if(action.type.includes('LOCATION_CHANGE')){
    //   store.dispatch({
    //     type: 'NOTIFY',
    //     payload: {
    //       notify: false
    //     }
    //   })  
    // }
  }
  return next(action)
}

export default logger