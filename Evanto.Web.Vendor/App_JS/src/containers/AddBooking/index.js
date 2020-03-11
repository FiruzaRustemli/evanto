import React, { Component } from 'react'
import { connect } from 'react-redux'
import FlatButton from 'material-ui/FlatButton';
import FontIcon from 'material-ui/FontIcon';
import ActionAdd from 'material-ui/svg-icons/content/add';
import Dialog from 'material-ui/Dialog'
import AddBookingForm from '../../routes/Bookings/containers/addBooking'
import Button from 'react-md/lib/Buttons/Button';
import { createBooking, getActiveVendorServices } from '../../routes/Bookings/modules/bookings'

class AddBooking extends Component {
    constructor(props) {
        super(props)
        this.state = {
            show: false
        }
    }
    

    handleClose = () => {
        this.setState({ show: false })
    }

    render() {
        const { createBooking } = this.props
        return (
            <div>
                

                {this.state.show  
                && <AddBookingForm 
                handleClose={this.handleClose}
                show={this.state.show}
                onSubmit={(args) => {
                    createBooking(args)
                } } />}
            </div>
        )
    }
}


const mapDispatchToProps = {
    createBooking,
    getActiveVendorServices
}

export default connect(null, mapDispatchToProps)(AddBooking)