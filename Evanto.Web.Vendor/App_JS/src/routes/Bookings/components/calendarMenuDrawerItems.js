import React from 'react'
import { bookingStatus, calendarStyle } from '../../../config'

import ListItem from 'react-md/lib/Lists/ListItem'
import Divider from 'react-md/lib/Dividers'
import Subheader from 'react-md/lib/Subheaders'
import Avatar from 'react-md/lib/Avatars'
import FontIcon from 'react-md/lib/FontIcons'

const MenuItemsDrawer = props => {
    const { calendarViewClick, bookingStatusClick } = props
    return ([
        <Subheader primaryText={props['##bookingTypes']} />,
        <ListItem
        onClick={() => {
            bookingStatusClick(bookingStatus.all)
        }}
            leftAvatar={
                <Avatar style={{ backgroundColor: '#9c27b0'}} icon={
                    <FontIcon style={{ color: '#ffffff'}}>line_style</FontIcon>
                } />
            }
            primaryText={props['##allBookings']}
        />,
        <ListItem
        onClick={() => {
            bookingStatusClick(bookingStatus.waiting)
        }}
            leftAvatar={
                <Avatar style={{ backgroundColor: '#ff9800'}} icon={
                    <FontIcon style={{ color: '#ffffff'}}>timelapse</FontIcon>
                } />
            }
            primaryText={props['##waiting']}
        />,
        <ListItem
        onClick={() => {
            bookingStatusClick(bookingStatus.approved)
        }}
            leftAvatar={
                <Avatar style={{ backgroundColor: '#4caf50'}} icon={
                    <FontIcon style={{ color: '#ffffff'}}>done</FontIcon>
                } />
            }
            primaryText={props['##approved']}
        />,
        <ListItem
        onClick={() => {
            bookingStatusClick(bookingStatus.rejected)
        }}
            leftAvatar={
                <Avatar style={{ backgroundColor: '#f44336'}} icon={
                    <FontIcon style={{ color: '#ffffff'}}>clear</FontIcon>
                } />
            }
            primaryText={props['##rejected']}
        />,
        <ListItem
        onClick={() => {
            bookingStatusClick(bookingStatus.createdByVendor)
        }}
            leftAvatar={
                <Avatar style={{ backgroundColor: '#2196f3'}} icon={
                    <FontIcon style={{ color: '#ffffff'}}>person_outline</FontIcon>
                } />
            }
            primaryText={props['##owner']}
        />,
        <Divider />,
        <Subheader primaryText={props['##views']} />,
        <ListItem onClick={() => calendarViewClick(calendarStyle.month)} primaryText={props['##month']} />,
        <ListItem onClick={() => calendarViewClick(calendarStyle.week)} primaryText={props['##week']} />,
        <ListItem onClick={() => calendarViewClick(calendarStyle.day)} primaryText={props['##day']} />
    ])
}

export default MenuItemsDrawer