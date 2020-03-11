import React, { Component } from 'react'
import moment from 'moment'
import { connect } from 'react-redux'
import { getTranslate } from 'react-localize-redux'

import Button from 'react-md/lib/Buttons/Button'
import DataTable from 'react-md/lib/DataTables/DataTable'
import TableHeader from 'react-md/lib/DataTables/TableHeader'
import TableBody from 'react-md/lib/DataTables/TableBody'
import TableRow from 'react-md/lib/DataTables/TableRow'
import TableColumn from 'react-md/lib/DataTables/TableColumn'
import SelectField from 'react-md/lib/SelectFields'
import MenuButton from 'react-md/lib/Menus/MenuButton'
import ListItem from 'react-md/lib/Lists/ListItem'

class ServicePacketTable extends Component {
    constructor(props) {
        super(props)
        this.state = {
            selectedTable: 0
        }
    }


    renderServicePackets = ({ translate, servicePackets, showServices }) => {
        const { selectAll, selectedPacketName, selectPacket } = this.props
        const packetsArray = servicePackets && servicePackets.map((item, key) => {
            return {
                text: item.createdDate ? moment(item.createdDate).locale('az').format('ll') : moment().locale('az').format('ll'),
                value: item.id
            }
        })

        const packetsArrayListItem = servicePackets && servicePackets.map((item, key) => {
            return <ListItem onClick={() => {
                showServices(item.id)
                this.setState({
                    selectedTable: item.id
                })
                selectPacket(item.id)
            }} primaryText={`${item.createdDate ? moment(item.createdDate).locale('az').format('ll') : moment().locale('az').format('ll')}`} />
        })


        return (
            // <MenuButton
            //     id="button-menu"
            //     label="Service packets"
            //     className='packet-action-button'
            //     flat
            //     buttonChildren="storage"
            // >
            //     <ListItem primaryText="All" onClick={() => {
            //         showServices(0)
            //         this.setState({
            //             selectedTable: 0
            //         })
            //         selectPacket(0)
            //     }} />
            //     {servicePackets && servicePackets.map((item, key) => {
            //     return <ListItem onClick={() => {
            //             showServices(item.id)
            //             this.setState({
            //                 selectedTable: item.id
            //             })
            //             selectPacket(item.id)
            //         }} primaryText={`${item.createdDate ? moment(item.createdDate).locale('az').format('ll') : moment().locale('az').format('ll')}`} />
            //     })}
            // </MenuButton>
            <SelectField
                id="selectButtonNumbers"
                style={{ verticalAlign: 'middle', paddingRight:10 }}
                defaultValue={selectedPacketName}
                menuItems={[{
                    text: translate('##all'),
                    value: 0
                }].concat(packetsArray)
                }
                itemLabel='text'
                onChange={(value, index, event) => {
                    if (value === 0) {
                        selectAll()
                        selectPacket(value)
                    } else {
                        showServices(value)
                        this.setState({
                            selectedTable: value
                        })
                        selectPacket(value)
                    }
                }
                }
                itemValue='value'
                className="md-cell md-cell--2-desktop md-cell--2-tablet md-cell--2-phone"
            />
        )
    }
    render() {
        const { servicePackets, showServices, translate } = this.props
        return (
            this.renderServicePackets({ translate, servicePackets, showServices })
        )
    }
}

const mapStateToProps = (state) => ({
    selectedPacketName: state.services.selectedPacketName,
    translate: getTranslate(state.locale)
})
export default connect(mapStateToProps)(ServicePacketTable)