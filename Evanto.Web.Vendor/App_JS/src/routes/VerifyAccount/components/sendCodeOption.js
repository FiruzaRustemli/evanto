import React, { Component } from 'react'
import { Field, reduxForm, change } from 'redux-form'
import { Link } from 'react-router'
import InputMask from 'react-input-mask'
import SendCodeEmailForm from './sendCodeEmailForm'
import SendCodePhoneForm from './sendCodePhoneForm'
import { connect } from 'react-redux'
import { sendCode } from '../../../store/coreModule'
import LanguageSelection from '../../../containers/LanguageSelection'
import { getTranslate } from 'react-localize-redux'

class SendCodeForm extends Component {

    handlePhoneSubmit = ({ phone }) => {
        const { sendCode, userInfo } = this.props
        sendCode({ verificationType: 2, phone })
    }

    handleEmailSubmit = ({ email }) => {
        const { sendCode, userInfo } = this.props
        sendCode({ verificationType: 1, email })
    }

    renderTextField = ({ input, label, meta: { touched, error }, labelClass, ...custom }) => (
        <label className={`${(touched && error) ? 'invalid' : ''} ${labelClass}`}>
            <span className='label-text'>{`${label}`}</span>
            {touched && error && <i className='fa fa-exclamation-triangle tooltip2'>
                <span className='tooltiptext'>{error}</span>
            </i>}
            {/*{touched && error && <span className='label-text'>error</span>}*/}
            <input {...input} {...custom} name='firstName' />
        </label>
    )

    flexContainer = {
        display: 'flex',
        flexDirection: 'row',
    };

    render() {
        const { translate ,sendCode, register, handleSubmit, pristine, reset, submitting, cancel, currentDate, requestPendingLogin, userInfo } = this.props
        return (
            <div className='containerx'>
                <LanguageSelection isLoggedOut={true} />
                <h1 className='text-center'>{translate('##verification')}</h1>
                <div className='formx registration-form'>
                    <SendCodeEmailForm {...translate(['##email', '##sendCode'])} onSubmit={this.handleEmailSubmit} initialValues={{ email: userInfo && userInfo.username }} />
                    <SendCodePhoneForm {...translate(['##phone', '##sendCode'])} onSubmit={this.handlePhoneSubmit} initialValues={{ phone: userInfo && userInfo.phone }} />
                    <br /><br />
                    <form onSubmit={handleSubmit}>
                        <Field onSubmit={handleSubmit} name='verificationCode' type='text' component={this.renderTextField} label={translate('##code')} />

                        <label className='checkbox'>
                            {/*<input type='checkbox' name='newsletter' />*/}
                            <span id='spnNav'>{translate('##alreadyhaveanaccount')}<Link to='/login'>{translate('##login')}</Link></span>
                        </label>
                        <div className='text-center'>
                            <button className='submit' type='submit' name='register'>{translate('##verify')}</button>
                        </div>
                    </form>
                </div>
            </div>
        )

    }
}

const mapStateToProps = (state) => ({
    translate: getTranslate(state.locale)
})

const mapDispatchToProps = {
    sendCode
}

export default connect(mapStateToProps, mapDispatchToProps)(
    reduxForm({
        form: 'sendCodeForm',
        returnRejectedSubmitPromise: true,
        enableReinitialize: true
    })(SendCodeForm)
)