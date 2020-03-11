import React, { Component } from 'react'
import { connect } from 'react-redux'

import Snackbar from 'react-md/lib/Snackbars'
import './notification.scss'
import { getTranslate } from 'react-localize-redux'

class Notification extends Component {
  constructor(props) {
    super(props)
    this.state = {
      autoHideTimeOut: 2000,
      toasts: []
    }
  }

  componentWillMount() {
    const { removeNotification } = this.props
    setTimeout(() => {
      removeNotification()
    }, 2000)
  }

  componentWillReceiveProps(nextProps) {
    const { translate } = this.props
    if (nextProps.notification && (nextProps.notification !== this.props.notification) && nextProps.notification.notify) {
      const toasts = this.state.toasts.slice()
      if (nextProps.notification.message.length > 0) {
        nextProps.notification.message.map(item => {
          toasts.push({ text: translate(item)})
        })
        this.setState({
          toasts
        })
      }
    }
  }

  remove = (args) => {
    let toasts = this.state.toasts.slice()
    toasts.shift()
    console.log('burda', this.state.toasts, toasts)
    this.setState({
      toasts
    })
  }

  render() {
    const { notification, removeNotification } = this.props
    return (
      <Snackbar
        id='notificationBar'
        className={`${notification.type === 'success' ? 'notificationBarSuccess' : 'notificationBarError'}`}
        toasts={this.state.toasts}
        autohide={true}
        autoHideTimeout={Snackbar.defaultProps.autohideTimeout}
        onDismiss={() => {
          this.remove()
          removeNotification()
        }}
      />
    )
  }
}

const removeNotification = () => {
  return dispatch => {
    return new Promise((resolve, reject) => {
      dispatch({
        type: 'REMOVE_NOTIFICATION'
      })
    })
  }
}


const mapDispatchToProps = {
  removeNotification
}

const mapStateToProps = (state) => ({
  notification: state.notification,
  translate: getTranslate(state.locale)
})

export default connect(mapStateToProps, mapDispatchToProps)(Notification)