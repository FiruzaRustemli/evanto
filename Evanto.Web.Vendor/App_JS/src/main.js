import React from 'react'
import ReactDOM from 'react-dom'
import createStore from './store/createStore'
import AppContainer from './containers/AppContainer'
import injectTapEventPlugin from 'react-tap-event-plugin';
import StartSignalR from './signalR/start'
import { initialize, addTranslationForLanguage  } from 'react-localize-redux'
import { resize } from './store/eventListenerReducer'
import { languageKey } from './config'
import { allStringReplace } from './helpers'
injectTapEventPlugin()
// ========================================================
// Store Instantiation
// ========================================================
const initialState = window.___INITIAL_STATE__
const store = createStore(initialState)

window.addEventListener('resize', () => {
    store.dispatch(resize({ width: window.innerWidth, height: window.innerHeight }));
});

//Initialize language
const languages = [languageKey.azerbaijani, languageKey.english, languageKey.russian];
store.dispatch(initialize(languages, { defaultLanguage: languageKey.azerbaijani }));

const az = require('./localization/az.json')
const en = require('./localization/en.json')
const ru = require('./localization/ru.json')
store.dispatch(addTranslationForLanguage(en, 'en'));
store.dispatch(addTranslationForLanguage(az, 'az'));
store.dispatch(addTranslationForLanguage(ru, 'ru'));
// ========================================================
// Render Setup
// ========================================================
const MOUNT_NODE = document.getElementById('root')
let render = () => {
  const routes = require('./routes/index').default(store)
  ReactDOM.render(
      <AppContainer store={store} routes={routes} />,
      MOUNT_NODE
    )

}

// This code is excluded from production bundle
if (__DEV__) {
  if (module.hot) {
    // Development render functions
    const renderApp = render
    const renderError = (error) => {
      const RedBox = require('redbox-react').default

      ReactDOM.render(<RedBox error={error} />, MOUNT_NODE)
    }

    // Wrap render in try/catch
    render = () => {
      try {
        renderApp()
      } catch (error) {
        console.error(error)
        renderError(error)
      }
    }

    // Setup hot module replacement
    module.hot.accept('./routes/index', () =>
      setImmediate(() => {
        ReactDOM.unmountComponentAtNode(MOUNT_NODE)
        render()
      })
    )
  }
}

// ========================================================
// Go!
// ========================================================
render()
