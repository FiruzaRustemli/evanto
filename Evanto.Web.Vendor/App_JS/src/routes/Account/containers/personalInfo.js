import React, { Component } from 'react'
import PersonalInfoForm from '../components/personalInfo'
import moment from 'moment'
import { getTranslate } from 'react-localize-redux'
import { connect } from 'react-redux'
class PersonalInfo extends Component {
  constructor(props) {
    super(props)
    this.state = {
      editing: false
    }
  }
  editClicked = () => {
    this.setState({
      editing: !this.state.editing
    })
  }
  render() {
    const { vendor, update, translate } = this.props
    return <PersonalInfoForm
      {...translate([
        '##personalInfo',
        '##forEditingClickButton',
        '##name',
        '##surname',
        '##birthDate',
        '##companyName',
        '##update'
      ])}
      birthDate={vendor.user.birthday}
      initialValues={{
        firstName: vendor.user.firstName,
        lastName: vendor.user.lastName,
        maritalStatus: vendor.user.maritalStatus,
        birthDate: new Date(vendor.user.birthday),
        companyName: vendor.companyName ? vendor.companyName : vendor.name
      }}
      onSubmit={(args) => {
        update(args)
        this.editClicked()
      }}
      personalInfo={vendor} editing={this.state.editing} edit={this.editClicked} />
  }
}

const mapStateToProps = (state) => ({
  translate: getTranslate(state.locale)
})

export default connect(mapStateToProps)(PersonalInfo)
