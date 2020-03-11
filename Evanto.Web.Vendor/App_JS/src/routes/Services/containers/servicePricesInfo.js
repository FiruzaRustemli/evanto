import React, { Component } from 'react'
import { connect } from 'react-redux'
import { deleteSelectedServices } from '../modules/services'
import CalculateDiscountForm from '../components/calculateDiscountForm'
import Buttons from './servicePriceInfoButtons'
import { getTranslate } from 'react-localize-redux'

import Button from 'react-md/lib/Buttons/Button'
import SelectField from 'react-md/lib/SelectFields'
import ListItem from 'react-md/lib/Lists/ListItem'
import MenuButton from 'react-md/lib/Menus/MenuButton'
import Card from 'react-md/lib/Cards/Card'
import CardTitle from 'react-md/lib/Cards/CardTitle'
import CardActions from 'react-md/lib/Cards/CardActions'
import CardText from 'react-md/lib/Cards/CardText'
import FontIcon from 'react-md/lib/FontIcons'

class ServicePricesInfo extends Component {
    constructor(props) {
        super(props)
        this.state = {
            totalMoney: 0,
            discountAmount: 0,
            paymentOption: -1,
            selectFieldHasError: false
        }
    }
    componentWillMount() {
        const { mainSelectedServices } = this.props
        this.setState({
            totalMoney: _.sumBy(mainSelectedServices, 'price')
        })
    }

    // componentWillReceiveProps(nextProps) {
    //     const { calculatedDiscountResult, mainSelectedServices } = this.props
    //     if (nextProps.calculatedDiscountResult !== calculatedDiscountResult) {

    //     }
    // }
    paymentOptionChange = (value) => {
        this.setState({
            paymentOption: value,
            selectFieldHasError: false
        })
    }
    componentDidUpdate() {
        const { calculatedDiscountResult, mainSelectedServices } = this.props
        if (calculatedDiscountResult && calculatedDiscountResult.resultType === 0 && calculatedDiscountResult.discountAmount !== 0) {
            if (calculatedDiscountResult.totalMoney !== this.state.totalMoney) {
                this.setState({
                    totalMoney: calculatedDiscountResult.totalMoney
                })
            }
        } else {
            if (_.sumBy(mainSelectedServices, 'price') !== this.state.totalMoney) {
                this.setState({
                    totalMoney: _.sumBy(mainSelectedServices, 'price')
                })
            }
        }
    }

    renderDiscountLabel = () => {
        const { calculatedDiscountResult, translate } = this.props
        if (calculatedDiscountResult && calculatedDiscountResult.resultType === 0 && calculatedDiscountResult.discountAmount !== 0) {
            if (calculatedDiscountResult.discountType === 2) {
                return (
                    <span style={{ color: 'red', textAlign: 'center', float: 'right' }}>
                        <i className='fa fa-caret-down text-error fa-fw'></i>
                        {`${calculatedDiscountResult.discountAmount} ₼ ${translate('##discount')}`}
                    </span>
                )
            } else if (calculatedDiscountResult.discountType === 1) {
                return (
                    <span style={{ color: 'red', textAlign: 'center', float: 'right' }}>
                        <i className='fa fa-caret-down text-error fa-fw'></i>
                        {`${calculatedDiscountResult.discountAmount} % ${translate('##discount')}`}
                    </span>
                )
            }
        } else {
            return <span style={{ color: 'red', textAlign: 'center' }}>
                <i className='fa fa-times text-error fa-fw'></i>
                {`${calculatedDiscountResult && calculatedDiscountResult.discountMessage && translate('##invalidCoupon')}`}
            </span>
        }
    }

    render() {
        const { mainSelectedServices, translate, deleteSelectedServices, stepBack, calculatedDiscountResult } = this.props
        return (
            <div className='md-cell md-cell--12' style={{ padding: '20px 20px 0px 20px' }}>
                <Card className='md-block-centered'>
                    <CardTitle expander
                        title={translate('##servicePricesCardTitle')}
                        subtitle={translate('##servicePricesCardSubTitle')}
                        className='md-cell md-cell--12'
                    >
                    </ CardTitle>
                    <CardText className='md-grid'>
                        <div className='md-cell md-cell--8'>
                            <fieldset className='fieldset-selected-prices'>
                                <legend>{translate('##table1')}</legend>
                                <table className='table table-responsive'>
                                    <thead>
                                        <tr>
                                            <td>{translate('##serviceName')}</td>
                                            <td>{translate('##timePeriod')}</td>
                                            <td>{translate('##price')}</td>
                                            <td></td>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        {mainSelectedServices && mainSelectedServices.map((item, key) => {
                                            return (
                                                <tr key={key}>
                                                    <td>{item.name}</td>
                                                    <td>{item.duration + translate('##days')}</td>
                                                    <td>{item.price + '₼'}</td>
                                                    <td><i style={{ verticalAlign: 'middle', cursor: 'pointer' }} className='material-icons'
                                                        onClick={() => {
                                                            if (mainSelectedServices.length !== 1) {
                                                                deleteSelectedServices(item.Id)
                                                            } else {
                                                                stepBack()
                                                            }
                                                            this.setState({
                                                                totalMoney: this.state.totalMoney - item.price
                                                            })
                                                        }}>close</i></td>
                                                </tr>
                                            )
                                        })}
                                    </tbody>
                                </table>
                            </fieldset>
                        </div>

                        <div className='md-cell md-cell--4 md-cell--12-tablet md-cell--12-phone no-padding'>
                            <CalculateDiscountForm initialValues={{
                                ServicePeriodPrices: mainSelectedServices
                            }} onSubmit={this.props.calculateDiscount} />

                            <div className='md-cell md-cell--12'>
                                <fieldset>
                                    <legend>{translate('##table3')}</legend>
                                    <div className='md-grid'>
                                        <div className='md-cell md-cell--5'>
                                            <p className='info-price'>
                                                <FontIcon iconClassName='fa fa-stop' />
                                                {translate('##infoServicePrice')}
                                            </p>
                                        </div>
                                        <div className='md-cell md-cell--middle md-cell--7'>
                                            <h2 className='price-h2'>
                                                {`${this.state.totalMoney} ₼`}
                                            </h2>
                                            {calculatedDiscountResult && this.renderDiscountLabel()}
                                        </div>
                                    </div>
                                </fieldset>
                            </div>

                            <div className='md-cell md-cell--12'>
                                <fieldset>
                                    <legend>Table</legend>
                                    <SelectField
                                        placeholder={translate('##paymentOption')}
                                        onChange={this.paymentOptionChange}
                                        itemLabel='text'
                                        helpOnFocus
                                        error={this.state.selectFieldHasError}
                                        required
                                        helpText={translate('##selectPaymentOption')}
                                        itemValue='value'
                                        menuItems={[{
                                            text: translate('##cash'),
                                            value: 1
                                        }, {
                                            text: translate('##online'),
                                            value: 1
                                        }]}
                                        className='md-cell md-cell--10 md-cell--12-phone md-cell--12-tablet md-cell--2-desktop-offset'
                                    />
                                    <Buttons onNext={() => {
                                        if (this.state.paymentOption !== -1) {
                                            debugger
                                            this.props.addServices({
                                                ServicePeriodPrices: mainSelectedServices,
                                                VendorServicePacketStatusId: this.state.paymentOption
                                            })
                                        } else {
                                            this.setState({
                                                selectFieldHasError: true
                                            })
                                        }
                                    }}
                                        stepBack={stepBack} />
                                </fieldset>
                            </div>
                        </div>
                    </CardText>
                </Card>
            </div>
        )
    }
}

const mapStateToProps = (state) => ({
    mainSelectedServices: state.services.mainSelectedServices,
    translate: getTranslate(state.locale),
    calculatedDiscountResult: state.services.calculatedDiscountResult
})

const mapDispatchToProps = {
    deleteSelectedServices
}

export default connect(mapStateToProps, mapDispatchToProps)(ServicePricesInfo)