import React, { Component } from 'react'
import _ from 'lodash'
import { connect } from 'react-redux'

class ServiceGroup extends Component {
    constructor(props) {
        super(props)

        this.state = {
            group: {}
        }
    }

    componentWillMount() {
            const { clickService } = this.props
        const { item, mainSelectedServices } = this.props
        let elements = []
        item.servicePeriodPrices.map(s => {
            elements.push({
                ...s,
                isChecked: _.map(mainSelectedServices, 'Id').includes(s.id) ? true : false
            })
        })
        let group = {
            name: item.servicePeriodPrices[0].service.name,
            elements
        }
        this.setState({
            group
        })
    }

    check(id) {
        const { clickService } = this.props
        this.state.group.elements.map(item => {
            if (!(item.id === id && item.isChecked === true)) {
                item.isChecked = false
            }
        })
        _.find(this.state.group.elements, { id }).isChecked = !_.find(this.state.group.elements, { id }).isChecked;
        let group = {
            name: this.state.group.name,
            elements: this.state.group.elements
        }
        this.setState({
            group
        })
        let mainGroup = {
            name: this.state.group.name
        }
        if (this.state.group.elements.find(x => x.isChecked == true)) {
            let checkedService = this.state.group.elements.find(x => x.isChecked == true)
            mainGroup.Id = checkedService.id
            mainGroup.price = checkedService.price
            mainGroup.duration = checkedService.period.duration
        } else {
            mainGroup.clickedItemId = -1
        }
        clickService(mainGroup)
    }

    render() {
        const { inKey, item, clickService } = this.props
        return (
            <tr key={inKey} className='serviceTR'>
                <td>
                    <h2>{this.state.group.name}</h2>
                </td>
                {this.state.group.elements.map((itemService, keyService) => {
                    return (
                        <td className='table-prices' onClick={() => {
                            this.check(itemService.id)
                        }} key={keyService} style={{ padding: '0 !important' }}>
                            {/*<div className={`servicePP ${itemService.isChecked && 'checkedService'}`} value={itemService.id}
                                name={itemService.service.name}>
                                <h3>{itemService.price}AZN</h3>
                            </div>*/}
                            <div className={`servicePP alert alert-callout alert-success no-margin ${itemService.isChecked && 'checkedService'}`}>
                                <h1 className='pull-right text-success'></h1>
                                <strong className='text-xl'>{itemService.price}</strong>
                                <span className='opacity-50'>{this.props['##azn']}</span>
                            </div>
                        </td>
                    )
                })}
            </tr>
        )
    }
}

const mapStateToProps = (state) => ({
    mainSelectedServices: state.services.mainSelectedServices
})
export default connect(mapStateToProps, null)(ServiceGroup)