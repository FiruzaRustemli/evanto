import React, { Component } from 'react'
import { connect } from 'react-redux'
import { login, clearError } from '../modules/login'
import LoginComponent from '../components/loginForm'
import LinearProgress from 'material-ui/LinearProgress'
import { Notification } from '../../../components/UIComponents'
import { Link } from 'react-router'
import { NotificationContainer, NotificationManager } from 'react-notifications'
import { getTranslate } from 'react-localize-redux'

class LoginContainer extends Component {
    constructor(props) {
        super(props)
        this.state = {
            errorMainCount: 0,
            requestPendingLogin: false
        }
    }

    render() {
        const { login, error, clearError, translate } = this.props
        return (
            <LoginComponent {...translate(['##login',
                '##register',
                '##username',
                '##password',
                '##donthaveanaccount']) } onSubmit={(args) => {
                    login(args)
                    this.setState({
                        requestPendingLogin: true
                    })
                }} />
        )
    }
}

const mapDispatchToProps = {
    login,
    clearError
}
const mapStateToProps = (state) => ({
    error: state.login.error,
    errorMain: state.error.error,
    translate: getTranslate(state.locale)
})

export default connect(mapStateToProps, mapDispatchToProps)(LoginContainer)