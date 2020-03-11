import React, { Component } from 'react'
import { connect } from 'react-redux'
import Cover from '../components/cover'
import PersonalInfo from './personalInfo'
import ContactInfo from './contactInfo'
import { updateContactInfo, updatePersonalInfo, uploadAvatar } from '../modules/account'
import ChangePassword from './changePassword'

class Account extends Component {
    render() {
        const { updateContactInfo, updatePersonalInfo, vendor, uploadAvatar, width } = this.props
        return (
            <section className='md-cell md-cell--12'>
                {vendor && <Cover width={width} uploadAvatar={(args) => {
                    let argsWithRelationalId = Object.assign({}, args, { relationalId: vendor.userId })
                    uploadAvatar(argsWithRelationalId)
                }} vendor={this.props.vendor} />}
                {vendor &&
                    <div className='md-grid md-cell md-cell--12'>
                        <PersonalInfo update={updatePersonalInfo} vendor={this.props.vendor} />
                        <ContactInfo update={updateContactInfo} vendor={this.props.vendor} />
                        <ChangePassword />
                    </div>
                }
            </section>
        )
    }
}

const mapStateToProps = (state) => ({
    vendor: state.account.vendor,
    width: state.events.width
})
const mapDispacthToProps = {
    updateContactInfo,
    updatePersonalInfo,
    uploadAvatar
}

export default connect(mapStateToProps, mapDispacthToProps)(Account)
