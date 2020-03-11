import React, { Component } from 'react'
import SendCodeOption from '../components/sendCodeOption'
import { connect } from 'react-redux'
import { verifyAccount } from '../../../store/coreModule'

class VerifyAccount extends Component {
    verifyAccount = (args) => {
        const { verifyAccount } = this.props
        verifyAccount(args)
    }

    render() {
        const { userInformation } = this.props
        if (userInformation) {
            return <SendCodeOption initialValues={{
                username: userInformation && userInformation.username,
                passwordString: userInformation && userInformation.passwordString
            }} onSubmit={this.verifyAccount} userInfo={userInformation} />
        } else {
            return <div></div>
        }
    }
}

const mapDispatchToProps = {
    verifyAccount
}
const mapStateToProps = (state) => ({
    userInformation: state.account.userInformation
})

export default connect(mapStateToProps, mapDispatchToProps)(VerifyAccount)