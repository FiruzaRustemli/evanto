import React, { Component } from 'react'
import ServicePacketTable from './servicePacketTable'
import ServicesTable from './servicesTable'
import NewServices from './newServices'
import { getVendorServicesByPacketId, getAllServicePackets, selectPacket } from '../modules/services'
import { connect } from 'react-redux'
import Button from 'react-md/lib/Buttons/Button'
import { replace } from 'react-router-redux'
import { hashHistory } from 'react-router'
import ReactCSSTransitionGroup from 'react-addons-css-transition-group'
import { getTranslate } from 'react-localize-redux'

import DataTable from 'react-md/lib/DataTables/DataTable';
import Card from 'react-md/lib/Cards/Card'
import TableCardHeader from 'react-md/lib/DataTables/TableCardHeader'
import CircularProgress from 'react-md/lib/Progress/CircularProgress'
import CardTitle from 'react-md/lib/Cards/CardTitle'
import CardActions from 'react-md/lib/Cards/CardActions'

class Services extends Component {
    constructor(props) {
        super(props)
    }

    componentWillMount() {
        const { getAllServicePackets, getVendorServicesByPacketId, selectPacket } = this.props
        getAllServicePackets()
        selectPacket(0)
        getVendorServicesByPacketId({ VendorServicePacketId: 0 })
    }

    showServices = (servicePacketId) => {
        const { getVendorServicesByPacketId } = this.props
        getVendorServicesByPacketId({ VendorServicePacketId: servicePacketId })
    }

    selectAll = () => {
        const { getVendorServicesByPacketId } = this.props
        getVendorServicesByPacketId({ VendorServicePacketId: 0 })
    }

    renderServicePackets = () => {
        const { requestPendingServicePackets, servicePackets, selectPacket } = this.props
        return (
            // <div className='packet-actions'>
                <ServicePacketTable selectPacket={selectPacket} selectAll={this.selectAll} servicePackets={servicePackets} showServices={this.showServices} />                                 
            // </div>
        )
    }

    renderServices = () => {
        const { requestPendingVendorServices, selectedVendorServices } = this.props
        if (selectedVendorServices) {
            return (
                <Card tableCard>
                    <CardTitle  className='md-cell md-cell--10-desktop md-cell--6-tablet md-cell--2-phone packets-title' title="Services" />
                    {this.renderServicePackets()}
                    {selectedVendorServices
                        && selectedVendorServices.length > 0
                        && <ServicesTable vendorServices={selectedVendorServices} />}
                </Card>
            )
        } else {
            return (
                <div className='row' style={{ textAlign: 'center' }}>
                    <h1><CircularProgress id='servicesProgress' key='progress' /></h1>
                </div>)
        }
    }

    renderServicesTables = () => {
        const { servicePackets, translate, selectedVendorServices, requestPendingVendorServices, requestPendingServicePackets } = this.props

        if (!requestPendingVendorServices && !requestPendingServicePackets) {
            if (selectedVendorServices &&
                servicePackets &&
                selectedVendorServices.length > 0 &&
                servicePackets.length > 0) {
                return (
                    <div>
                        <div className='md-cell md-cell--12'>
                            {this.renderServices()}
                        </div>
                    </div>

                )
            }
            else {
                return (
                    <div className='row' style={{ textAlign: 'center' }}>
                        <h1>{translate('##youDontHaveServices')}</h1>
                    </div>)
            }
        } else {
            return (
                <div className='row' style={{ textAlign: 'center' }}>
                    <h1><CircularProgress id='bothProgress' key='progress' /></h1>
                </div>)
        }

    }

    render() {
        const { servicePackets, selectedVendorServices, replace } = this.props
        return (
            <div>
                {this.renderServicesTables()}
            </div>
        )
    }
}

const mapDispatchToProps = {
    getVendorServicesByPacketId,
    getAllServicePackets,
    replace,
    selectPacket
}

const mapStateToProps = (state) => ({
    requestPendingVendorServices: state.services.requestPendingVendorServices,
    requestPendingServicePackets: state.services.requestPendingServicePackets,
    selectedVendorServices: state.services.selectedVendorServices,
    servicePackets: state.services.servicePackets,
    translate: getTranslate(state.locale)
})

export default connect(mapStateToProps, mapDispatchToProps)(Services)