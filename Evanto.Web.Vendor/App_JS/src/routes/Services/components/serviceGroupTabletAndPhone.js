import React, { Component } from 'react'
import _ from 'lodash'
import { connect } from 'react-redux'
import { getTranslate } from 'react-localize-redux'

import Menu from 'react-md/lib/Menus/Menu'
import ListItem from 'react-md/lib/Lists/ListItem'
import MenuButton from 'react-md/lib/Menus/MenuButton'
import SelectField from 'react-md/lib/SelectFields'
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
        if (id !== 0) {
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
        } else {
            if (this.state.group.elements.find(x => x.isChecked == true)) {
                let newElements = this.state.group.elements.map(item => {
                    item.isChecked = false
                    return item
                })
                let group = {
                    name: this.state.group.name,
                    elements: newElements
                }
                this.setState({
                    group
                })
            }
            let mainGroup = {
                name: this.state.group.name
            }
            mainGroup.clickedItemId = -1
            clickService(mainGroup)
        }
    }

    render() {
        const { inKey, item, clickService, translate } = this.props
        return (
            <SelectField
                id="selectButtonStates"
                label={this.state.group.name}
                placeholder={this.state.group.name}
                menuItems={[{
                    text: translate('##none'),
                    value: 0
                }].concat(this.state.group.elements.map((itemService) => {
                    return {
                        text: `${itemService.price} - ${itemService.period.name.replace('_', ' ')}`,
                        value: itemService.id
                    }
                }))}
                defaultValue={this.state.group.elements.find(x => x.isChecked == true) ? this.state.group.elements.find(x => x.isChecked == true).id : 0}
                itemLabel="text"
                itemValue="value"
                position={SelectField.Positions.TOP_LEFT}
                className="md-cell"
                onChange={(id) => {
                    this.check(id)
                }}
            />
            // <div className={`servicePPPhone alert alert-callout alert-success no-margin ${(this.state.group.elements 
            // && this.state.group.elements.length > 0) ? 'checkedService' : ''}`}>
            //     <h2 className='text-xl'>{this.state.group.name}</h2>
            //      <MenuButton
            //         id="button-menu"
            //         label='Seç'
            //         flat
            //         secondary
            //         buttonChildren="chat"
            //         className='btn-price-menu'
            //     >
            //         <ListItem onClick={() => {
            //             this.check(0)
            //         }} primaryText='-' />
            //         {this.state.group.elements.map((itemService, keyService) => {
            //             return (
            //                 <ListItem key={keyService} onClick={() => {
            //                     this.check(itemService.id)
            //                 }} primaryText={itemService.price} secondaryText={itemService.period.name.replace('_', ' ')} />
            //             )
            //         })}
            //     </MenuButton> 
            // </div>
        )
    }
}

const mapStateToProps = (state) => ({
    mainSelectedServices: state.services.mainSelectedServices,
    translate: getTranslate(state.locale)
})
export default connect(mapStateToProps, null)(ServiceGroup)