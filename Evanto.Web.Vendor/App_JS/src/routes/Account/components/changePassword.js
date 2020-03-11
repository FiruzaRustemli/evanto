import React, { Component } from 'react'
import { Field, reduxForm } from 'redux-form'
import { connect } from 'react-redux'
import { getTranslate } from 'react-localize-redux'

import TextField from 'react-md/lib/TextFields'
import DatePicker from 'react-md/lib/Pickers/DatePickerContainer'
import Button from 'react-md/lib/Buttons/Button'
import Card from 'react-md/lib/Cards/Card'
import CardTitle from 'react-md/lib/Cards/CardTitle'
import CardActions from 'react-md/lib/Cards/CardActions'
import CardText from 'react-md/lib/Cards/CardText'
import FontIcon from 'react-md/lib/FontIcons'

const validate = values => {
    const errors = {}
    if (!values.oldpassword) {
        errors.oldpassword = '##required'
    }
    if (!values.newpassword) {
        errors.newpassword = '##required'
    }
    if (!values.newpasswordRepeat) {
        errors.newpasswordRepeat = '##required'
    }
    if (values.newpassword !== values.newpasswordRepeat) {
        errors.newpasswordRepeat = '##passwordsMustBeTheSame'
    }
    return errors
}

class ChangePasswordForm extends Component {

    renderTextField = ({ input, label, meta: { touched, error }, ...custom }) => {
        return (
            <TextField label={label}
                placeholder={label}
                error={touched && error}
                errorText={touched && error && this.props.translate(error)}
                {...input}
                {...custom}
            />
        )
    }

    render() {
        const { handleSubmit, pristine, reset, submitting, translate } = this.props
        return (
            <form className='md-cell md-cell--12' onSubmit={handleSubmit}>
                <Card>
                    <CardTitle
                        title={translate('##changePassword')}
                    />
                    <CardText>
                        <ul className='list'>
                            <li className='tile'>
                                <a className='tile-content ink-reaction'>
                                    <div className='tile-icon'>
                                        <FontIcon>dialpad</FontIcon>
                                    </div>
                                    <div className='tile-text'>
                                        <Field id='tbxOld' type='password' name='oldpassword' label={translate('##oldPassword')} component={this.renderTextField} />
                                    </div>
                                </a>
                            </li>
                            <li className='tile'>
                                <a className='tile-content ink-reaction'>
                                    <div className='tile-icon'>
                                        <FontIcon>dialpad</FontIcon>
                                    </div>
                                    <div className='tile-text'>
                                        <Field id='tbxNew' type='password' name='newpassword' label={translate('##newPassword')} component={this.renderTextField} />
                                    </div>
                                </a>
                            </li>
                            <li className='tile'>
                                <a className='tile-content ink-reaction'>
                                    <div className='tile-icon'>
                                        <FontIcon>dialpad</FontIcon>
                                    </div>
                                    <div className='tile-text'>
                                        <Field id='tbxRepeatNew' type='password' name='newpasswordRepeat' label={translate('##repeatNewPassword')} component={this.renderTextField} />
                                    </div>
                                </a>
                            </li>
                        </ul>
                    </CardText >
                    <CardActions>
                        <Button
                            type='submit'
                            label={translate('##update')}
                            flat />
                    </CardActions>
                </Card>
            </form>
        )
    }
}

const mapStateToProps = (state) => ({
    translate: getTranslate(state.locale)
})

export default connect(mapStateToProps)(
    reduxForm({
        form: 'changePasswordForm',
        validate
    })(ChangePasswordForm)
)