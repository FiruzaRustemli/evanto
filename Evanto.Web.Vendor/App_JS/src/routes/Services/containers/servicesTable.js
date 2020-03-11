import React, { Component } from 'react'
import PropTypes from 'prop-types'
import { connect } from 'react-redux'
import { changeServiceStatus, updateVendorService } from '../modules/services'
import moment from 'moment'
import { Modal } from '../../../components/UIComponents/'
import { destroy } from 'redux-form'
import EditServiceForm from './editService'
import { hashHistory } from 'react-router'
import { getTranslate } from 'react-localize-redux'

import Button from 'react-md/lib/Buttons/Button'
import Switch from 'react-md/lib/SelectionControls/Switch'
import CircularProgress from 'react-md/lib/Progress/CircularProgress'
import LinearProgress from 'react-md/lib/Progress/LinearProgress'
import DataTable from 'react-md/lib/DataTables/DataTable'
import TableHeader from 'react-md/lib/DataTables/TableHeader'
import TableBody from 'react-md/lib/DataTables/TableBody'
import TableRow from 'react-md/lib/DataTables/TableRow'
import TableColumn from 'react-md/lib/DataTables/TableColumn'
import Paper from 'react-md/lib/Papers'
import Card from 'react-md/lib/Cards/Card';
import CardTitle from 'react-md/lib/Cards/CardTitle';
import CardActions from 'react-md/lib/Cards/CardActions';
import CardText from 'react-md/lib/Cards/CardText'

class ServicesTable extends Component {
    constructor(props) {
        super(props)
        this.state = {
            completed: 0,
            showCircularProgress: false,
            openEditModal: false,
            editClicked: false,
            vendorServiceId: 0,
            formValues: {}
        }
    }

    cancel = () => {
        const { destroy } = this.props
        destroy('editServiceForm')
        this.setState({
            editClicked: false
        })
    }

    openEditModal = ({ id, priceMin, priceMax, dailyQuantity, description }) => {
        this.setState({
            editClicked: true,
            vendorServiceId: id,
            formValues: {
                priceMin,
                priceMax,
                dailyQuantity,
                description
            }
        })
    }

    updateService = (args) => {
        const { updateVendorService, destroy } = this.props
        let model = Object.assign({}, args, { VendorServiceId: this.state.vendorServiceId })
        updateVendorService(model)
        destroy('editServiceForm')
        this.setState({
            editClicked: false
        })
    }

    renderEditServiceModal = ({ priceMin, priceMax, dailyQuantity, description }) => {
        let initialValues = {
            initialValues: {
                PriceMin: priceMin,
                PriceMax: priceMax,
                DailyQuantity: dailyQuantity,
                Description: description
            }
        }
        return (
            <EditServiceForm {...initialValues} onSubmit={this.updateService} editClicked={this.state.editClicked} cancel={this.cancel} />
        )
    }
    renderDesktopTable = () => {
        const styles = {
            toggle: {
                marginBottom: 16,
            }
        }
        const { vendorServices, translate, changeServiceStatus, changeStatusRequestPending, width } = this.props
        return (
            <div>
                {this.state.showCircularProgress && <LinearProgress id='changeStatusProgress' key='progress' />}
                <table className='table'>
                    <thead>
                        <tr>
                            <td>#</td>
                            <td>{translate('##name')}</td>
                            <td>{translate('##expireDate')}</td>
                            <td>{translate('##priceRange')}</td>
                            <td>{translate('##description')}</td>
                            <td>{translate('##status')}
                                {/*{changeStatusRequestPending && <CircularProgress size={15} tdickness={3} />}                                */}
                            </td>
                            <td></td>
                        </tr>
                    </thead>
                    <tbody>
                        {vendorServices && vendorServices.map((item, key) => {
                            return (
                                <tr key={key}>
                                    <td>
                                        {key + 1}
                                    </td>
                                    <td><span>{item.name}</span></td>
                                    <td>{item.status && item.endDate && moment(item.endDate).locale('az').endOf('day').fromNow()}</td>
                                    <td>{item.priceMin && item.priceMax && `${item.priceMin + ' - ' + item.priceMax}`}</td>
                                    <td>{item.description}</td>
                                    <td>
                                        <Switch id="toggleStatus"
                                            name="lights"
                                            disabled={this.state.showCircularProgress || item.vendorServicePacket.statusId !== 1}  //TODO: move to json - active
                                            checked={item.status}
                                            onChange={() => {
                                                if (!(this.state.showCircularProgress || item.vendorServicePacket.statusId !== 1)) {
                                                    this.setState({
                                                        showCircularProgress: true
                                                    })
                                                    setTimeout(() => {
                                                        this.setState({
                                                            showCircularProgress: false
                                                        })
                                                    }, 2000)
                                                    changeServiceStatus({
                                                        VendorServiceId: item.id,
                                                        Status: !item.status
                                                    })
                                                }
                                            }}
                                            style={styles.toggle} />
                                    </td>
                                    <td>
                                        <Button onTouchTap={() =>
                                            hashHistory.replace(`services/edit/${item.id}`)
                                        } icon tooltipLabel="Edit" tooltipPosition="bottom" >mode_edit</Button>
                                    </td>
                                </tr>
                            )
                        })}
                    </tbody>
                </table>
                {this.state.vendorServiceId !== 0 && this.renderEditServiceModal({
                    priceMin: this.state.formValues.priceMin,
                    priceMax: this.state.formValues.priceMax,
                    dailyQuantity: this.state.formValues.dailyQuantity,
                    description: this.state.formValues.description
                })}
            </div>
        )
    }

    renderTabletAndPhoneTable = () => {
        const styles = {
            toggle: {
                marginBottom: 16,
            }
        }
        const { vendorServices, translate, changeServiceStatus, changeStatusRequestPending, width } = this.props
        return (
            <div>

                {vendorServices && vendorServices.map((item, key) => {
                    return (
                        <Card key={key} style={{ borderBottom: '1px solid #ebebeb' }} className="card-services md-block-centered">
                            <CardTitle
                                titleStyle={{ fontSize: '10px' }}
                                title={`${item.name}`}
                                expander
                            />
                            <CardText expandable>
                                <table className='table-horizontal'>
                                    <tr>
                                        <th>{translate('##expireDate')}</th>
                                        <td>{item.status && item.endDate && moment(item.endDate).locale('az').endOf('day').fromNow()}</td>
                                    </tr>
                                    <tr>
                                        <th>{translate('##priceRange')}</th>
                                        <td>{item.priceMin && item.priceMax && `${item.priceMin + ' - ' + item.priceMax} ₼`}</td>
                                    </tr>
                                    <tr>
                                        <th>{translate('##description')}</th>
                                        <td>{item.description}</td>
                                    </tr>
                                    <tr>
                                        <th>{translate('##status')}</th>
                                        <td>
                                            <Switch id="toggleStatus"
                                                name="lights"
                                                disabled={this.state.showCircularProgress || item.vendorServicePacket.statusId !== 1}  //TODO: move to json - active
                                                checked={item.status}
                                                onChange={() => {
                                                    if (!(this.state.showCircularProgress || item.vendorServicePacket.statusId !== 1)) {
                                                        this.setState({
                                                            showCircularProgress: true
                                                        })
                                                        setTimeout(() => {
                                                            this.setState({
                                                                showCircularProgress: false
                                                            })
                                                        }, 2000)
                                                        changeServiceStatus({
                                                            VendorServiceId: item.id,
                                                            Status: !item.status
                                                        })
                                                    }
                                                }} />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>Actions</th>
                                        <td>
                                            <Button onTouchTap={() =>
                                                hashHistory.replace(`services/edit/${item.id}`)
                                            } icon tooltipLabel="Edit" tooltipPosition="bottom" >mode_edit</Button>
                                        </td>
                                    </tr>
                                </table>
                            </CardText>
                        </Card>
                    )
                })}
            </div>
        )
    }

    render() {
        const { width } = this.props
        if (width > 700) {
            return this.renderDesktopTable()
        } else {
            return this.renderTabletAndPhoneTable()
        }
    }
}

const mapDispatchToProps = {
    changeServiceStatus,
    destroy,
    updateVendorService
}

const mapStateToProps = (state) => ({
    changeStatusRequestPending: state.services.changeStatusRequestPending,
    width: state.events.width,
    translate: getTranslate(state.locale)
})


export default connect(mapStateToProps, mapDispatchToProps)(ServicesTable)