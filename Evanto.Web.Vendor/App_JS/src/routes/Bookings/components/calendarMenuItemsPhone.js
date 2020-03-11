import React, { Component } from 'react'
import { bookingStatus, calendarStyle } from '../../../config'
import { connect } from 'react-redux'
import CalendarMenuDrawerItems from './calendarMenuDrawerItems'
import { getTranslate } from 'react-localize-redux'
import ListItem from 'react-md/lib/Lists/ListItem'
import MenuButton from 'react-md/lib/Menus/MenuButton'
import Divider from 'react-md/lib/Dividers'
import Subheader from 'react-md/lib/Subheaders'
import Avatar from 'react-md/lib/Avatars'
import FontIcon from 'react-md/lib/FontIcons'
import Drawer from 'react-md/lib/Drawers'
import Button from 'react-md/lib/Buttons/Button'
import Toolbar from 'react-md/lib/Toolbars'

class MenuItemsPhone extends Component {
    constructor(props) {
        super(props)
        this.state = {
            selectedType: bookingStatus.all,
            position: 'right'
        }
    }
    render() {
        const { bookingStatusClick, translate, calendarViewClick, width, closeDrawer, isOpen, toggle } = this.props
        const left = this.state.position === 'left';
        const close = <Button icon onClick={closeDrawer}>{left ? 'arrow_back' : 'close'}</Button>;
        const header = (
            <Toolbar
                nav={left ? null : close}
                actions={left ? close : null}
                className="md-divider-border md-divider-border--bottom"
            />
        )
        const mobileDrawerStyle = { zIndex: 100, maxWidth: 150, position: 'fixed', left:'calc(100vw - 150px)' }
        const desktopDrawerStyle = { zIndex: 100 }
        return (
            <Drawer
                {...this.state}
                visible={isOpen}
                navItems={CalendarMenuDrawerItems({ calendarViewClick, bookingStatusClick, ...translate([
                    '##bookingTypes',
                    '##allBookings',
                    '##waiting',
                    '##approved',
                    '##rejected',
                    '##owner',
                    '##views',
                    '##month',
                    '##week',
                    '##day'
                ]) })}
                onVisibilityToggle={toggle}
                type={Drawer.DrawerTypes.TEMPORARY}
                header={header}
                style={width > 1030 ? desktopDrawerStyle : mobileDrawerStyle}
            />
        )
    }
}

const mapStateToProps = (state) => ({
    width: state.events.width,
    translate: getTranslate(state.locale)
})

export default connect(mapStateToProps)(MenuItemsPhone)