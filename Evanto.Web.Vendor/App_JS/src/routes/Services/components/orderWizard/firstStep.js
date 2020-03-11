import React from 'react'
import { Field, reduxForm } from 'redux-form'
import TextField from 'material-ui/TextField'
import { RadioButton, RadioButtonGroup } from 'material-ui/RadioButton'
import Checkbox from 'material-ui/Checkbox'
import FlatButton from 'material-ui/FlatButton';
import SelectField from 'material-ui/SelectField'
import MenuItem from 'material-ui/MenuItem'
import SelectedServices from '../selectedServices'
import './customActions/customActions.scss'

const renderTextField = ({ input, label, meta: { touched, error }, ...custom }) => (
    <TextField hintText={label}
        floatingLabelText={label}
        errorText={touched && error}
        {...input}
        {...custom}
    />
)

const FirstStep = props => {
    const { handleSubmit, pristine, reset, submitting, closeModal, currentDate } = props
    return (
        <form onSubmit={handleSubmit}>
            <SelectedServices services={props.groupes} />
            <Field name='couponNumber' label='Coupon Number' component={renderTextField} />
            <div className='dvActions'>
                <FlatButton label='cancel' primary={true} onClick={closeModal} />
                <FlatButton type='submit' label='Next' primary={true} />
            </div>
        </form>
    )
}

export default reduxForm({
    form: 'firstStep'
})(FirstStep)

