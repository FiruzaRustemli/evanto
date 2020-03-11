import React from 'react'
import { calendarStyle } from '../../../config'
import ListItem from 'react-md/lib/Lists/ListItem'
import MenuButton from 'react-md/lib/Menus/MenuButton'
import Divider from 'react-md/lib/Dividers'
import Subheader from 'react-md/lib/Subheaders'

const MenuItemsBigger = props => {
    const { calendarViewClick } = props
    return (
        <MenuButton
            id='calendar_menu'
            icon
            buttonChildren='more_vert'
            tooltipLabel={props['##calendarMenu']}
            style={{ bottom: '8px' }}
            >
            <ListItem onClick={() => calendarViewClick(calendarStyle.month)} primaryText={props['##month']} />
            <ListItem onClick={() => calendarViewClick(calendarStyle.month)} primaryText={props['##week']} />
            <ListItem onClick={() => calendarViewClick(calendarStyle.month)} primaryText={props['##day']} />
        </MenuButton>
    )
}

export default MenuItemsBigger