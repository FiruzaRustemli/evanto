import React, { Component } from 'react'
import ContactInfoForm from '../components/contactInfo'
import { connect } from 'react-redux'
import ChangePasswordForm from '../components/changePassword'
import { changePass } from '../modules/account'

class ChangePassword extends Component {
    constructor(props) {
        super(props)
        this.state = {
        }
    }

    changePassword = (args) => {
        const { changePass } = this.props
        console.log('submitted', args)
        let model = {
            currentPassword: args.oldpassword,
            newPassword: args.newpassword
        }
        changePass(model)
    }

    render() {
        const { vendor, update } = this.props
        return (
            <ChangePasswordForm
                onSubmit={this.changePassword} />
        )
    }
}

const mapStateToProps = (state) => ({
})

export default connect(mapStateToProps, {
    changePass
})(ChangePassword)