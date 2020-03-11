import React, { Component } from 'react'
import { connect } from 'react-redux'
import { Field, reduxForm } from 'redux-form'
import { RadioButton, RadioButtonGroup } from 'material-ui/RadioButton'
import Checkbox from 'material-ui/Checkbox'
import FlatButton from 'material-ui/FlatButton';
import { TimePicker } from 'redux-form-material-ui'
import MenuItem from 'material-ui/MenuItem'
import { getActiveVendorServices } from '../modules/bookings'
import { getTranslate } from 'react-localize-redux'

import Dialog from 'react-md/lib/Dialogs'
import Toolbar from 'react-md/lib/Toolbars'
import Button from 'react-md/lib/Buttons/Button'
import SelectField from 'react-md/lib/SelectFields'
import DatePicker from 'react-md/lib/Pickers/DatePickerContainer'
import TextField from 'react-md/lib/TextFields'

const validate = values => {
    const errors = {}
    const requiredFields = ['Description', 'BookHour', 'BookMinute', 'VendorServiceId']
    requiredFields.forEach(field => {
        if (!values[field]) {
            errors[field] = values['##required']
        }
    })
    return errors
}

const renderTextField = ({ input, label, meta: { touched, error }, ...custom }) => (
    <TextField
        label={label}
        placeholder={label}
        lineDirection='center'
        className='md-cell md-cell--12'
        error={(touched && error) && true}
        errorText={touched && error}
        {...input}
        {...custom}
    />
)

const selectField = ({ input, label, meta: { touched, error }, ...custom, menuItems }) => (
    <SelectField
        {...input}
        {...custom}
        label={label}
        placeholder={label}
        menuItems={menuItems}
        error={touched && error}
        errorText={touched && error}
    />
)

const datePicker = ({ input, label, meta: { touched, error }, ...custom }) => (
    <DatePicker
        {...input}
        {...custom}
        inline
        label={label}
        displayMode='portrait'
        error={touched && error}
        errorText={touched && error}
    />
)



const hours = [];
for (let i = 0; i < 24; i++) {
    hours.push(i);
}

const minutes = [];
for (let i = 0; i < 60; i = i + 15) {
    minutes.push(i);
}

const styleTime = {
    maxWidth: '100px'
}

class AddBooking extends Component {

    componentWillMount() {
        const { getActiveVendorServices } = this.props
        getActiveVendorServices()
    }

    render() {
        const { handleSubmit, translate, pristine, reset, submitting, cancel, currentDate, vendorServices, handleClose, show } = this.props
        const actions = [
            {
                onClick: () => {
                    handleSubmit()
                    handleClose()
                },
                primary: true,
                label: translate('##add'),
            },
            {
                onClick: handleClose,
                primary: true,
                label: translate('##close'),
            }
        ];
        const actionsMobile = [<Button
            flat primary onClick={() => {
                handleSubmit()
                handleClose()
            }}
            label={translate('##submit')}></Button>]
        const nav = <Button icon onClick={handleClose}>close</Button>
        const { activeVendorServices, width } = this.props
        return (
            <Dialog
                onHide={() => { }}
                id='add_booking_dialog'
                visible={true}
                title={`${translate('##addBooking')} ${currentDate ? currentDate : ''}`}
                actions={actions}
                fullPage={width < 1090}
            >
                {width < 1090 && <Toolbar
                    colored
                    nav={nav}
                    actions={actionsMobile}
                    title={`${translate('##addBooking')} ${currentDate ? currentDate : ''}`}
                />}
                <form className='md-cell md-cell--12'>
                    {(!activeVendorServices || activeVendorServices.vendorServices.length === 0) && <small style={{ color: 'red' }}>Aktiv servisiniz yoxdur.</small>}
                    {activeVendorServices && activeVendorServices.vendorServices && <Field
                        name='VendorServiceId'
                        component={selectField}
                        itemLabel="name"
                        placeholder={translate('##services')}
                        className="md-cell md-cell--12"
                        itemValue="id"
                        menuItems={
                            activeVendorServices.vendorServices.map((item, key) => {
                                return item
                            })
                        }
                    />}
                    <Field name='Description' label={translate('##description')} component={renderTextField} />
                    {!currentDate && <Field name='BookDate'
                        pickerStyle={{ marginLeft: -8 }}
                        className='md-cell md-cell--12'
                        id='book_date' component={datePicker} />}
                    <Field name='BookHour' label={translate('##hours')} placeholder={translate('##hours')} menuItems={hours} className='md-cell md-cell--6' component={selectField} />
                    <Field name='BookMinute' label={translate('##minutes')} placeholder={translate('##minutes')} menuItems={minutes} className='md-cell md-cell--6'  component={selectField} />
                </form >
            </Dialog >
        )
    }
}

const mapStateToProps = (state) => ({
    activeVendorServices: state.bookings.activeVendorServices,
    width: state.events.width,
    translate: getTranslate(state.locale)
})

const mapDistpachToProps = {
    getActiveVendorServices
}

export default connect(mapStateToProps, mapDistpachToProps)(reduxForm({
    form: 'addBooking',
    validate
})(AddBooking))
