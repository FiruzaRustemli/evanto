import React, { Component } from 'react'
import ContactInfoForm from '../components/contactInfo'
import { getTranslate } from 'react-localize-redux'
import { connect } from 'react-redux'

class ContactInfo extends Component {
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
        return (
            <ContactInfoForm contactInfo={vendor}
                {...translate([
                    '##contactInfo',
                    '##forEditingClickButton',
                    '##address',
                    '##email',
                    '##phone',
                    '##update'
                ]) }
                initialValues={{
                    userId: vendor.userId,
                    address: vendor.address,
                    username: vendor.user.username,
                    phone: vendor.user.phone
                }}
                onSubmit={(args) => {
                    update(args)
                    this.editClicked()
                }}
                editing={this.state.editing} edit={this.editClicked} />
        )
    }
}

const mapStateToProps = (state) => ({
    translate: getTranslate(state.locale)
})

export default connect(mapStateToProps)(ContactInfo)