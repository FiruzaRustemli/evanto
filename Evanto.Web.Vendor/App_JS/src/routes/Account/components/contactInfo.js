import React from 'react'
import { Field, reduxForm } from 'redux-form'


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


const ContactInfo = props => {
    const { editing, edit, contactInfo } = props
    const { handleSubmit, pristine, reset, submitting, cancel, currentDate } = props
    return (
        <form className='md-cell md-cell--6 md-cell--12-tablet md-cell--12-phone' onSubmit={handleSubmit}>
            <Card style={{ minHeight: 440 }} onExpanderClick={edit}>
                <CardTitle
                    expander
                    title={props['##contactInfo']}
                    subtitle={props['##forEditingClickButton']}
                />
                <CardText>
                    <ul className='list'>
                        <li className='tile'>
                            <a className='tile-content ink-reaction'>
                                <div className='tile-icon'>
                                    <FontIcon>map</FontIcon>
                                </div>
                                {editing
                                    ? <div className='tile-text'>
                                        <small>{props['##address']}</small>
                                        <Field name='address' component={renderTextField} />
                                    </div>
                                    : <div className='tile-text'>
                                        <small>{props['##address']}</small>
                                        {contactInfo.address}
                                    </div>}
                            </a>
                        </li>
                        <li className='tile'>
                            <a className='tile-content ink-reaction'>
                                <div className='tile-icon'>
                                    <FontIcon>local_post_office</FontIcon>
                                </div>
                                {editing
                                    ? <div className='tile-text'>
                                        <small>{props['##email']}</small>
                                        <Field name='username' component={renderTextField} />
                                    </div>
                                    : <div className='tile-text'>
                                        <small>{props['##email']}</small>
                                        {contactInfo.user.username}
                                    </div>}
                            </a>
                        </li>
                        {!editing && <li className='divider-inset'></li>}
                        <li className='tile'>
                            <a className='tile-content ink-reaction'>
                                <div className='tile-icon'>
                                    <FontIcon>local_phone</FontIcon>
                                </div>
                                {editing
                                    ? <div className='tile-text'>
                                        <small>{props['##phone']}</small>
                                        <Field name='phone' component={renderTextField} />
                                    </div>
                                    : <div className='tile-text'>
                                        <small>{props['##phone']}</small>
                                        {contactInfo.user.phone}
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
    form: 'contactInfo'
})(ContactInfo)