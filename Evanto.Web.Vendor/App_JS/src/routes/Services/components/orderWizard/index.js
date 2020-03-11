import React, { Component } from 'react'
import { connect } from 'react-redux'
import PropTypes from 'prop-types'
import { calculateDiscount, addServices } from '../../modules/services'
import FirstStep from './firstStep'
import SecondStep from './secondStep'
import ThirdStep from './thirdStep'
import Dialog from 'material-ui/Dialog'

class OrderWizard extends Component {
    constructor(props) {
        super(props)
        this.state = {
            step: 1,
            addServiceModel: {}
        }
    }
    addServicesClick = (args) => {
        const { addServices } = this.props
        addServices(args)
    }
    handleSubmit = (args) => {
        const { calculateDiscount } = this.props
        calculateDiscount(args)

        // generate model to add
        let addServiceModel = {
            Payment: {
                VendorId: 1, //TODO
                StatusId: 1,
                Amount: 0,
                PaymentTypeId: 1,
                Description: 'Test'//TODO
            },
            CouponNumber: args.couponNumber,
            VendorId: 1, //TODO
            VendorServices: []
        }

        args.ServicePeriodPrices.map((item, key) => {
            addServiceModel.VendorServices.push({
                Status: true,
                Name: item.name,
                Description: 'Test',//TODO
                ServicePeriodPriceId: item.Id
            })
        })

        this.setState({
            step: 2,
            addServiceModel
        })
    }
    nextSnd = () => {
        this.setState({
            step: 3
        })
    }
    renderDialogHeaders = () => {
        switch (this.state.step) {
            case 1:
                return "Services"
            case 2:
                return "Total money"
            case 3:
                return "Payment"
        }
    }
    render() {
        return (
            <Dialog
                title={this.renderDialogHeaders()}
                autoScrollBodyContent={true}
                open={this.props.open}
            >
                <div style={{ display: `${this.state.step !== 1 ? 'none' : 'block'}` }}>
                    <FirstStep onSubmit={this.handleSubmit} {...this.props} />
                </div>
                <div style={{ display: `${this.state.step !== 2 ? 'none' : 'block'}` }}>
                    <SecondStep nextSnd={this.nextSnd} {...this.props} />
                </div>
                <div style={{ display: `${this.state.step !== 3 ? 'none' : 'block'}` }}>
                    <ThirdStep addModel={this.state.addServiceModel} addServices={this.addServicesClick} {...this.props} />
                </div>
            </Dialog>

        )
    }
}

const mapDispatchToProps = {
    calculateDiscount,
    addServices
}

export default connect(null, mapDispatchToProps)(OrderWizard)