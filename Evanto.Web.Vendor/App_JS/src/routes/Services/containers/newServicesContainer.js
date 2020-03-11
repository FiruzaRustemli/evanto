import React, { Component } from 'react'
import NewServices from './newServices'
import { connect } from 'react-redux'
import ServicePriceInfo from './servicePricesInfo'
import { setSelectedServices, resetSelectedServices, getServicePeriodPrices, calculateDiscount, addServices } from '../modules/services'
import { hashHistory } from 'react-router'
class NewServicesContainer extends Component {
    constructor(props) {
        super(props)
        this.state = {
            step: 0,
            addServiceModel: {},
            couponNumber: ''
        }
    }
    componentWillMount() {
        const { resetSelectedServices, getServicePeriodPrices } = this.props
        resetSelectedServices()
        getServicePeriodPrices()
    }

    selectServices = (selectedGroupes) => {
        const { setSelectedServices } = this.props
        setSelectedServices(selectedGroupes)
        this.setState({
            step: 1
        })
    }

    stepFirst = () => {
        this.setState({
            step: 0
        })
    }

    calculateDiscount = (args) => {
        const { calculateDiscount } = this.props
        calculateDiscount(args)
        this.setState({
            couponNumber: args.couponNumber
        })
    }

    addServices = (args) => {
        const { addServices, vendor } = this.props
        // generate model to add
        let addServiceModel = {
            Payment: {
                StatusId: 1,
                Amount: 0,
                PaymentTypeId: 1,
                Description: 'Test'//TODO:Payment
            },
            CouponNumber: this.state.couponNumber,
            VendorServices: []
        }

        args.ServicePeriodPrices.map((item, key) => {
            addServiceModel.VendorServices.push({
                Status: true,
                Name: `${vendor.name} - ${item.name}`,
                Description: item.Description,//TODO
                ServicePeriodPriceId: item.Id
            })
        })

        addServices(Object.assign(addServiceModel, args.VendorServicePacketStatusId))
    }

    render() {
        return (
            <div>
                {this.state.step === 0 && <NewServices selectServices={this.selectServices} />}
                {this.state.step === 1 && <ServicePriceInfo
                    calculateDiscount={this.calculateDiscount}
                    stepBack={this.stepFirst}
                    addServices={this.addServices}
                />}

            </div>
        )
    }
}


const mapStateToProps = (state) => ({
    vendor: state.account.vendor
})

const mapDispatchToProps = {
    setSelectedServices,
    resetSelectedServices,
    getServicePeriodPrices,
    calculateDiscount,
    addServices
}

export default connect(mapStateToProps, mapDispatchToProps)(NewServicesContainer)