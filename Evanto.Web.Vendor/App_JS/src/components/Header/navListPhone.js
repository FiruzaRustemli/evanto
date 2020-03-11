import React from 'react'
import { hashHistory } from 'react-router'
import { localize } from 'react-localize-redux'

import List from 'react-md/lib/Lists/List'
import ListItem from 'react-md/lib/Lists/ListItem'
import Avatar from 'react-md/lib/Avatars'
import FontIcon from 'react-md/lib/FontIcons'
import Divider from 'react-md/lib/Dividers'
import Subheader from 'react-md/lib/Subheaders'

const NavListPhone = (props) => {
    return [
        {
            key: 'bookings',
            primaryText: props['##bookings'],
            leftIcon: <FontIcon>inbox</FontIcon>,
            onClick: () => { hashHistory.push('/') }
        }, 
        {
            key: 'services',
            primaryText: props['##services'],
            leftIcon: <FontIcon>star</FontIcon>,
            onClick: () => { hashHistory.push('/services') }
        },
        {
            key: 'profile',
            primaryText: props['##profile'],
            leftIcon: <FontIcon>star</FontIcon>,
            onClick: () => { hashHistory.push('/account') }
        }, 
        { 
            key: 'divider', 
            divider: true 
        },
         {
            key: 'newservices',
            primaryText: props['##buyServices'],
            leftIcon: <FontIcon>mail</FontIcon>,
            onClick: () => { hashHistory.push('/services/new') }
        }, 
        {
            key: 'addbooking',
            primaryText: props['##addBookings'],
            leftIcon: <FontIcon>delete</FontIcon>,
            onClick: props.addBooking
        }, 
        {
            key: 'logout',
            primaryText: props['##logOut'],
            leftIcon: <FontIcon>info</FontIcon>,
            onClick: props.logout         
        }];
}

export default NavListPhone