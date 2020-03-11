import React, { Component } from 'react'
import { connect } from 'react-redux'

import Snackbar from 'react-md/lib/Snackbars'
import './notification.scss'

class Notification extends Component {
    constructor(props) {
        super(props)
        this.state = {
            autoHideTimeOut: 3000
        }
    }

    componentWillMount() {
        const { removeNotification } = this.props
        setTimeout(() => {
            removeNotification()
        }, 2500)
    }

    render() {
        const { notification, removeNotification } = this.props
        return (
            <Snackbar
                id='notificationBar'
                className={`${notification.type === 'success' ? 'notificationBarSuccess' : 'notificationBarError'}`}
                toasts={[{ text: notification.message, action: 'Bağla' }]}
                autohide={notification.type === 'success'}
                autoHideTimeout={this.state.autoHideTimeOut}
                onDismiss={removeNotification}
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
    notification: state.common.notification
})

export default connect(mapStateToProps, mapDispatchToProps)(Notification)