import React, { Component } from 'react'
import { Field, reduxForm, change } from 'redux-form'
import { Link } from 'react-router'
import InputMask from 'react-input-mask'
import { validate } from './validateRegisterForm'
import SendCodeEmailForm from './sendCodeEmailForm'
import SendCodePhoneForm from './sendCodePhoneForm'
import { connect } from 'react-redux'

class SendCodeForm extends Component {
 
    handlePhoneSubmit = () => {
        const { sendCode } = this.props
        sendCode({ verificationTypeId: 2 })
    }

    handleEmailSubmit = () => {
        const { sendCode } = this.props
        sendCode({ verificationTypeId: 1 })
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
        const { sendCode, register, handleSubmit, pristine, reset, submitting, cancel, currentDate, requestPendingLogin, userInfo } = this.props
        return (
            <div className='containerx'>
                <h1 className='text-center'>Verification</h1>
                <div className='formx registration-form'>
                    <SendCodeEmailForm onSubmit={this.handleEmailSubmit} initialValues={{ email: userInfo.username }} />
                    <SendCodePhoneForm onSubmit={this.handlePhoneSubmit} initialValues={{ phone: userInfo.phone }} />
                    <br /><br />
                    <form>
                        <Field onSubmit={handleSubmit} name='code' type='text' component={this.renderTextField} label='Code' />

                        <label className='checkbox'>
                            {/*<input type='checkbox' name='newsletter' />*/}
                            <span id='spnNav'>Already have an account? <Link to='/login'>Log in</Link></span>
                        </label>
                        <div className='text-center'>
                            <button className='submit' type='submit' name='register'>Verify account</button>
                        </div>
                    </form>
                </div>
            </div>
        )

    }
}

const mapStateToProps = (state) => ({

})

const mapDispatchToProps = {

}

export default connect()(
    reduxForm({
        form: 'sendCodeForm',
        validate,
        returnRejectedSubmitPromise: true,
        enableReinitialize: true
    })(SendCodeForm)
)