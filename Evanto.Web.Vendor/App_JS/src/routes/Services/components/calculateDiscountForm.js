import React from 'react'
import { reduxForm, Field } from 'redux-form'

import TextField from 'react-md/lib/TextFields'
import Button from 'react-md/lib/Buttons/Button'

const validate = (values) => {
    const errors = {}
    if (!values.couponNumber) {
        errors.couponNumber = 'Required'
    }
    return errors
}

const renderTextField = ({
  input,
    label,
    meta: { touched, error },
    ...custom
}) =>
    <TextField
        label={label}
        placeholder={label}
        lineDirection='center'
        error={touched && error}
        errorText={touched && error}
        {...input}
        {...custom}
    />


const CalculateDiscountForm = props => {
    const { handleSubmit } = props
    return (
        <div className='md-cell md-cell--12'>
            <fieldset>
                <legend>Table</legend>
                <form className='md-grid' onSubmit={handleSubmit}>
                    <Field 
                        name='couponNumber' 
                        label={props['##couponNumber']}
                        className='md-cell md-cell--8 md-cell--bottom' 
                        component={renderTextField} 
                    />
                    <Button
                        flat
                        primary={true}
                        label={props['##calculate']}
                        className='md-cell md-cell--4 md-cell--12-phone md-cell-12-tablet md-cell--bottom'
                        onTouchTap={handleSubmit}
                    />
                </form>
            </fieldset>
        </div>
    )
}

export default reduxForm({
    form: 'calculateDiscountForm',
    validate,
    enableReinitialize: true
})(CalculateDiscountForm)