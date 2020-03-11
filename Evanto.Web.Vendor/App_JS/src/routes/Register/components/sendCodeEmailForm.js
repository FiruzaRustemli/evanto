import React from 'react'
import { Field, reduxForm, change } from 'redux-form'
import { Link } from 'react-router'

const renderTextField = ({ input, label, meta: { touched, error }, labelClass, ...custom }) => (
    <label className={`${(touched && error) ? 'invalid' : ''} ${labelClass}`}>
        <span className='label-text'>{`${label}`}</span>
        {touched && error && <i className='fa fa-exclamation-triangle tooltip2'>
            <span className='tooltiptext'>{error}</span>
        </i>}
        {/*{touched && error && <span className='label-text'>error</span>}*/}
        <input {...input} {...custom} name='firstName' />
    </label>
)

const SendCodeEmailForm = props => {
    const { register, handleSubmit, pristine, reset, submitting, cancel, currentDate, requestPendingLogin } = props
    return (
        <form onSubmit={handleSubmit}>
            <Field disabled name='email' type='text' labelClass='tbx-send-code-address disabled'  component={renderTextField} label='Email' />
            <button className='submit btn-send-code' type='submit' name='register'>Send code</button>
        </form>
    )

}

export default reduxForm({
    form: 'sendCodeEmailForm',
    enableReinitialize: true
})(SendCodeEmailForm)