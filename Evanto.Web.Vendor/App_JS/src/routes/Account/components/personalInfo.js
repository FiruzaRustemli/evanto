import React from 'react'
import { Field, reduxForm } from 'redux-form'
import moment from 'moment'

import TextField from 'react-md/lib/TextFields'
import DatePicker from 'react-md/lib/Pickers/DatePickerContainer'
import Button from 'react-md/lib/Buttons/Button'
import Card from 'react-md/lib/Cards/Card'
import CardTitle from 'react-md/lib/Cards/CardTitle'
import CardActions from 'react-md/lib/Cards/CardActions'
import CardText from 'react-md/lib/Cards/CardText'
import FontIcon from 'react-md/lib/FontIcons'

const renderTextField = ({ input, label, meta: { touched, error }, ...custom }) => (
    <TextField label={label}
        placeholder={label}
        error={touched && error}
        errorText={touched && error}
        {...input}
        {...custom}
    />
)

const renderDatePicker = ({ input, label, meta: { touched, error }, ...custom }) => (
    <DatePicker
        label={label}
        inline
        lineDirection='center'
        error={touched && error}
        errorText={touched && error}
        {...input}
        {...custom}
    />
)

const PersonalInfo = props => {
    const { editing, edit, personalInfo } = props
    const { handleSubmit, pristine, reset, submitting, cancel, currentDate } = props
    return (
        <form className='md-cell md-cell--6 md-cell--12-tablet md-cell--12-phone' onSubmit={handleSubmit}>
            <Card onExpanderClick={edit}>
                <CardTitle
                    expander
                    title={props['##personalInfo']}
                    subtitle={props['##forEditingClickButton']}
                />
                <CardText>
                    <ul className='list'>
                        <li className='tile'>
                            <a className='tile-content ink-reaction'>
                                <div className='tile-icon'>
                                    <FontIcon>person</FontIcon>
                                </div>
                                {editing
                                    ? <div className='tile-text'>
                                        <small>{props['##name']}</small>
                                        <Field name='firstName' component={renderTextField} />
                                    </div>
                                    : <div className='tile-text'>
                                        <small>{props['##name']}</small>
                                        {personalInfo.user.firstName}
                                    </div>}
                            </a>
                        </li>
                        <li className='tile'>
                            <a className='tile-content ink-reaction'>
                                <div className='tile-icon'>
                                    <FontIcon>person_outline</FontIcon>
                                </div>
                                {editing
                                    ? <div className='tile-text'>
                                        <small>{props['##surname']}</small>
                                        <Field name='lastName' component={renderTextField} />
                                    </div>
                                    : <div className='tile-text'>
                                        <small>{props['##surname']}</small>
                                        {personalInfo.user.lastName}
                                    </div>}
                            </a>
                        </li>
                        {!editing && <li className='divider-inset'></li>}
                        <li className='tile'>
                            <a className='tile-content ink-reaction'>
                                <div className='tile-icon'>
                                    <FontIcon>cake</FontIcon>
                                </div>
                                {editing
                                    ? <div className='tile-text'>
                                        <small>{props['##birthDate']}</small>
                                        <Field
                                        id='birth-date-picker'
                                        icon={false}
                                        pickerStyle={{ marginLeft: -90 }}
                                        displayMode='portrait'
                                            name='birthDate'
                                            component={renderDatePicker} />
                                    </div>
                                    : <div className='tile-text'>
                                        <small>{props['##birthDate']}</small>
                                        {personalInfo.user.birthday && moment(personalInfo.user.birthday).format('ll')}
                                    </div>}
                            </a>
                        </li>
                        <li className='tile'>
                            <a className='tile-content ink-reaction'>
                                <div className='tile-icon'>
                                    <FontIcon>domain</FontIcon>
                                </div>
                                {editing
                                    ? <div className='tile-text'>
                                        <small>{props['##companyName']}</small>
                                        <Field
                                            name='companyName'
                                            component={renderTextField} />
                                    </div>
                                    : <div className='tile-text'>
                                        <small>{props['##companyName']}</small>
                                        {personalInfo.name ? personalInfo.name : '--'}
                                    </div>}
                            </a>
                        </li>
                        <li className='tile'>
                            <a className='tile-content ink-reaction'>
                                <div className='tile-icon'></div>
                                <div className='tile-text'>

                                </div>
                            </a>
                        </li>

                    </ul>
                </CardText >
                {editing && <CardActions>
                    <Button
                        onTouchTap={handleSubmit}
                        type='submit'
                        label={props['##update']}
                        flat />
                </CardActions>}
            </Card>
        </form>
    )
}

export default reduxForm({
    form: 'personalInfo',
    enableReinitialize: true
})(PersonalInfo)
