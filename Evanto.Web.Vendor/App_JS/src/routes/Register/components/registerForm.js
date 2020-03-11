import React, { Component } from 'react'
import { Field, reduxForm, change } from 'redux-form'
import { Link } from 'react-router'
import InputMask from 'react-input-mask'
import { validate } from './validateRegisterForm'
import LanguageSelection from '../../../containers/LanguageSelection'
import { connect } from 'react-redux'
import { getTranslate } from 'react-localize-redux'
import { SelectionControl } from 'react-md'
class RegisterForm extends Component {
    renderTextField = ({ input, label, meta: { touched, error }, labelClass, ...custom }) => {
        const { translate } = this.props
        return (
            <label className={`${(touched && error) ? 'invalid' : ''} ${labelClass}`}>
                <span className='label-text'>{`${label}`}</span>
                {touched && error && <i className='fa fa-exclamation-triangle tooltip2'>
                    <span className='tooltiptext'>{translate(error)}</span>
                </i>}
                {/*{touched && error && <span className='label-text'>error</span>}*/}
                <input {...input} {...custom} name='firstName' />
            </label>
        )
    }


    renderMask = ({ input, label, meta: { touched, error }, labelClass, ...custom }) => {
        const { translate } = this.props
        return (
            <label className={`${labelClass} ${(touched && error) ? 'invalid' : ''}`}>
                <span className='label-text'>{label}</span>
                {touched && error && <i className='fa fa-exclamation-triangle tooltip2'>
                    <span className='tooltiptext'>{translate(error)}</span>
                </i>}
                <InputMask onChange={(e) => {
                    change('phone', e.target.value)
                }} {...input} {...custom} mask='+\9\9\4 99 999 99 99' type='text' />
            </label>
        )
    }

    flexContainer = {
        display: 'flex',
        flexDirection: 'row',
    };

    render() {
        const { register, handleSubmit, pristine, reset, submitting, cancel, currentDate, requestPendingLogin, translate } = this.props
        return (
            <div className='containerx'>
                <LanguageSelection isLoggedOut={true} />
                <h1 className='text-center'>{translate('##register')}</h1>
                <form className='formx registration-form' onSubmit={handleSubmit(register)}>
                    <Field name='firstName' type='text' labelClass='col-one-half' component={this.renderTextField} label={translate('##firstname')} />
                    <Field name='lastName' type='text' labelClass='col-one-half' component={this.renderTextField} label={translate('##lastname')} />
                    <Field name='name' type='text' component={this.renderTextField} label={translate('##companyname')} />

                    <Field name='phone' label={translate('##phone')} component={this.renderMask} />

                    <Field name='username' component={this.renderTextField} label={translate('##email')} type='text' />
                    <Field name='passwordString' component={this.renderTextField} label={translate('##password')} type='password' />
                    {/* <label className='checkbox'>
                        <input type='checkbox' style={{ display: 'inline-block'}} name='newsletter' />
                        <span  id='cbxTerms' >{translate('##ireadandagree')}<b>{` ${translate('##termsandconditions')}`}</b></span>
                    </label> */}

                    <label className='checkbox'>
                        {/*<input type='checkbox' name='newsletter' />*/}
                        <span id='spnNav'>{`${translate('##alreadyhaveanaccount')} `}<Link to='/login'>{translate('##login')}</Link></span>
                    </label>
                    <div className='text-center'>
                        <button className='submit' type='submit' name='register'>{translate('##register')}</button>
                    </div>
                </form>
            </div>
        )
    }
}

const mapStateToProps = (state) => ({
    translate: getTranslate(state.locale)
})

export default connect(mapStateToProps)(reduxForm({
    form: 'registerForm',
    validate,
    returnRejectedSubmitPromise: true,
    enableReinitialize: true
})(RegisterForm))