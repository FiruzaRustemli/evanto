import React, { Component } from 'react'
import { getServicePeriodPrices, } from '../modules/services'
import { connect } from 'react-redux'
import $ from 'jquery'
import _ from 'lodash'
import './services.scss'
import ServiceGroup from '../components/serviceGroup'
import ServiceGroupTabletAndPhone from '../components/serviceGroupTabletAndPhone'
import SelectedServices from '../components/selectedServices'
import { getTranslate } from 'react-localize-redux'

import Button from 'react-md/lib/Buttons/Button'
import CircularProgress from 'react-md/lib/Progress/CircularProgress'
import Card from 'react-md/lib/Cards/Card';
import CardTitle from 'react-md/lib/Cards/CardTitle';
import CardActions from 'react-md/lib/Cards/CardActions';
import CardText from 'react-md/lib/Cards/CardText';

class NewServices extends Component {
    constructor(props) {
        super(props)
        this.state = {
            openModal: 0,
            closeModal: 1,
            opened: false,
            groupes: []
        }
    }

    openModal = () => {
        this.setState({
            openModal: 1,
            closeModal: 0
        })
    }

    closeModal = () => {
        this.setState({
            openModal: 0,
            closeModal: 1,
            groupes: []
        })
    }

    componentWillMount() {
        const { mainSelectedServices } = this.props
        if (mainSelectedServices && mainSelectedServices.length > 0) {
            this.setState({
                groupes: mainSelectedServices
            })
        }
    }

    clickService = (clickedService) => {
        let groupes = this.state.groupes
        if (clickedService.clickedItemId === -1) {
            _.remove(groupes, (item) => {
                return item.name === clickedService.name
            })
        } else {
            if (this.state.groupes.length > 0) {
                if (groupes.find(x => x.name == clickedService.name)) {
                    groupes.find(x => x.name == clickedService.name).clickedItemId = clickedService.clickedItemId
                } else {
                    groupes.push(clickedService)
                }
            } else {
                groupes.push(clickedService)
            }
        }
        this.setState({
            groupes
        })
    }



    renderServicePeriodPricesDesktop(model) {
        const { translate } = this.props
        return model.servicePeriodPricesGrouped.map((item, key) => {
            return (
                <ServiceGroup {...translate(['##azn'])} clickService={this.clickService} key={key} inKey={key} item={item} />
            )
        })
    }

    renderServicePeriodPrices(model) {
        return model.servicePeriodPricesGrouped.map((item, key) => {
            return (
                <ServiceGroupTabletAndPhone clickService={this.clickService} key={key} inKey={key} item={item} />
            )
        })
    }

    openSlider = () => {
        this.setState({
            opened: !this.state.opened
        })
        $('#newServiceCardBody').slideToggle()
    }

    renderDesktopTable = () => {
        const { servicePeriodPrices, selectServices, translate } = this.props
        return (
            <CardText>
                <table className='table table-new-services' style={{ maxHeight: '300px' }}>
                    <thead>
                        <tr className='t-title'>
                            <th>#</th>
                            <th>{translate('##1month')}</th>
                            <th>{translate('##3month')}</th>
                            <th>{translate('##6month')}</th>
                            <th>{translate('##1year')}</th>
                        </tr>
                    </thead>
                    <tbody>
                        {servicePeriodPrices && this.state.closeModal === 1 && this.renderServicePeriodPricesDesktop(servicePeriodPrices)}
                    </tbody>
                </table>

                <div className='card-block'>
                    <Button raised disabled={this.state.groupes.length === 0} style={{ width: '100%' }} onTouchTap={() => {
                        {/* this.openModal() */ }
                        selectServices(this.state.groupes)
                    }} primary={true} label={translate('##order')} />
                    {this.state.closeModal === 0 && this.renderModal()}
                </div>
            </CardText>
        )
    }

    renderTable = () => {
        const { servicePeriodPrices, selectServices, translate } = this.props
        return (
            <CardText>
                {servicePeriodPrices && this.state.closeModal === 1 && this.renderServicePeriodPrices(servicePeriodPrices)}
                <div className='card-block'>
                    <Button raised disabled={this.state.groupes.length === 0} style={{ width: '100%' }} onTouchTap={() => {
                        {/* this.openModal() */ }
                        selectServices(this.state.groupes)
                    }} primary={true} label={translate('##order')} />
                    {this.state.closeModal === 0 && this.renderModal()}
                </div>
            </CardText>
        )
    }

    render() {
        const { servicePeriodPrices, selectServices, width, translate } = this.props
        if (!servicePeriodPrices || !servicePeriodPrices.servicePeriodPricesGrouped || servicePeriodPrices.servicePeriodPricesGrouped.length === 0) {
            return (
                <div className='md-cell md-cell--12'>
                    <h1><CircularProgress id='progressBuyServices' /></h1>
                </div>
            )
        } else {
            if (width > 700) {
                return (
                    <div className='md-cell md-cell--12'>
                        <Card style={{ margin: 20 }} className='md-block-centered'>
                            <CardTitle
                                title={translate('##serviceCardTitle')}
                                subtitle={translate('##serviceCardSubtitle')}
                            />
                            {this.renderDesktopTable()}
                        </Card>
                    </div>
                )
            } else {
                return (
                    <div className='md-cell md-cell--12'>
                        <Card style={{ margin: 20 }} className='md-block-centered'>
                            <CardTitle
                                title={translate('##serviceCardTitle')}
                                subtitle={translate('##serviceCardSubtitle')}
                            />
                            {this.renderTable()}
                        </Card>
                    </div>
                )
            }

        }
    }
}

const mapDispatchToProps = {
    getServicePeriodPrices
}

const mapStateToProps = (state) => ({
    mainSelectedServices: state.services.mainSelectedServices,
    servicePeriodPrices: state.services.servicePeriodPrices,
    width: state.events.width,
    translate: getTranslate(state.locale)
})

export default connect(mapStateToProps, mapDispatchToProps)(NewServices)