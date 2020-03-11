import React, { Component } from 'react'
import { connect } from 'react-redux'
import RegisterForm from '../components/registerForm'
import SendCodeForm from '../components/sendCodeOption'
import { register, clearError, signMeUp } from '../modules/index'
import { Link } from 'react-router'
import { SubmissionError } from 'redux-form'
import { NotificationContainer, NotificationManager } from 'react-notifications'
import { getTranslate } from 'react-localize-redux'

class Register extends Component {
    constructor(props) {
        super(props)
        this.state = {
            page: 0,
            userInfo: {}
        }
    }

    handleRegister = (args) => {
        const { error, register, signMeUp } = this.props
        return new Promise((resovle, reject) => {
            args.phone = args.phone.replace('+', '').replace(/\s/g, "")
            register(args)
            if (error) {
                reject(error)
            }
        })
    }

    // sendCode = (args) => {
    //     const { userInfo } = this.state
    //     const { register } = this.props
    //     userInfo.verificationTypeId = args.verificationTypeId
    //     register(userInfo)
    // }

    render() {
        const { register, error, clearError, userInformation, translate } = this.props
        return (
            <RegisterForm {...translate(['##register', '##login',
            '##firstname', '##lastname',
            '##companyname', '##phone', '##email', '##password', '##alreadyhaveanaccount',
            '##ireadandagree', '##termsandconditions'])} initialValues={userInformation && userInformation} register={(args) => {
                this.handleRegister(args).catch(error => {
                    return;
                })
            }} />
        )
    }
}

const mapDispatchToProps = {
    register,
    clearError,
    signMeUp
}
const mapStateToProps = (state) => ({
    error: state.login.error,
    userInformation: state.account.userInformation,
    translate: getTranslate(state.locale)
})

export default connect(mapStateToProps, mapDispatchToProps)(Register)