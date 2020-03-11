import React from 'react'
import { Field, reduxForm } from 'redux-form'
import TextField from 'material-ui/TextField'
import { Link } from 'react-router'
import LanguageSelection from '../../../containers/LanguageSelection'

const renderTextField = ({ input, label, meta: { touched, error }, labelClass, ...custom }) => (
    <label className={`${labelClass} ${touched && error}`}>
        <span className='label-text'>{label}</span>
        <input {...input} {...custom} name='firstName' />
    </label>
)

const validate = values => {
    const errors = {}
    if (!values.username) {
        errors.username = 'Required'
    } else if (values.username.length > 30 || values.username.length < 3) {
        errors.username = 'Must be between 30 and 3 characters'
    }

    if (!values.password) {
        errors.password = 'Required'
    } else if (values.password.length > 20 || values.password.length < 5) {
        errors.password = 'Must be between 20 and 5 characters'
    }
    return errors
}

const warn = values => {
    const warnings = {}
    if (values.age < 19) {
        warnings.age = 'Hmm, you seem a bit young...'
    }
    return warnings
}

const LoginForm = (props) => {
    const { handleSubmit, pristine, reset, submitting, cancel, currentDate, requestPendingLogin } = props
    return (
        <div className='containerx'>
            <LanguageSelection isLoggedOut={true} />
            <h1 className='text-center'>{props['##login']}</h1>
            <form className='formx registration-form'>
                <Field name='username' label={props['##username']} component={renderTextField} />
                <Field name='password' type='password' label={props['##password']} component={renderTextField} />                
                <label className='checkbox'>
                    {/*<input type='checkbox' name='newsletter' />*/}
                    <span id='spnNav'>{props['##donthaveanaccount']}<Link to='/register'>{props['##register']}</Link></span>
                </label>
                <div className='text-center'>
                    <button className='submit' type='button' onClick={handleSubmit} name='register'>{props['##login']}</button>
                </div>
            </form>
        </div>
    )
}

export default reduxForm({
    form: 'loginForm',
    validate
})(LoginForm)