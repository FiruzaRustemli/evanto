import React, { Component } from 'react'
import './login.scss'
import lightBaseTheme from '../../styles/lightBaseTheme'
import MuiThemeProvider from 'material-ui/styles/MuiThemeProvider'
import getMuiTheme from 'material-ui/styles/getMuiTheme'

class LoginLayout extends Component {
    componentWillMount() {
        localStorage.clear()
    }

    render() {
        const { children } = this.props
        return (
            <div id='bodyx' style={{ width: '100%', height: '111%' }}>
                {children}
            </div>
        )
    }
}


export default LoginLayout