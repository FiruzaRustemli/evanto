import React, { Component } from 'react'
import { connect } from 'react-redux'
import urlConfig from '../../../config/urlConfig'
import moment from 'moment'
import { getTranslate } from 'react-localize-redux'
import { resetNotifications } from '../../../store/notificationReducer'

import Dialog from 'react-md/lib/Dialogs'
import List from 'react-md/lib/Lists/List'
import ListItem from 'react-md/lib/Lists/ListItem'
import Avatar from 'react-md/lib/Avatars'
import FontIcon from 'react-md/lib/FontIcons'
import Divider from 'react-md/lib/Dividers'
import Subheader from 'react-md/lib/Subheaders'
import Menu from 'react-md/lib/Menus/Menu'
import Toolbar from 'react-md/lib/Toolbars'
import Button from 'react-md/lib/Buttons/Button'
import DataTable from 'react-md/lib/DataTables/DataTable';
import TableHeader from 'react-md/lib/DataTables/TableHeader';
import TableBody from 'react-md/lib/DataTables/TableBody';
import TableRow from 'react-md/lib/DataTables/TableRow';
import TableColumn from 'react-md/lib/DataTables/TableColumn';
import CircularProgress from 'react-md/lib/Progress/CircularProgress'

class NotificationList extends Component {
    constructor(props) {
        super(props)
    }
    componentWillUnmount () {
        const { resetNotifications, resetPage } = this.props
        resetNotifications()
        resetPage()
    }

    render() {
        const { width, notifications, notificationClick, translate, isNotificationLoading } = this.props
        return (
            <DataTable plain>
                <TableHeader>
                    <TableRow>
                        <TableColumn style={{ borderBottom: '1px solid #0aa89e' }}>{translate('##notifications')}</TableColumn>
                    </TableRow>
                </TableHeader>
                <TableBody>
                    {notifications && notifications.map((item, key) => {
                        var additionalData = JSON.parse(item.additionalData)
                        return (
                            <TableRow style={{ cursor: 'pointer'}} onClick={() => notificationClick(item)}>
                                <TableColumn id={`${item.statusId === 1 ? 'notificationRead' : 'notificationUnread'}`}>
                                    {translate(`##${additionalData.ResourceKey}`)
                                        .replace('{userName}', `${additionalData.UserName}`)
                                        .replace('{serviceName}', `${additionalData.VendorServiceName}`)}
                                </TableColumn>
                            </TableRow>
                        )
                    })}
                    {isNotificationLoading && <TableRow>
                        <TableColumn>
                            <CircularProgress id='loadingNotifications' />
                        </TableColumn>
                    </TableRow>}
                </TableBody>
            </DataTable>
        )
    }
}

const mapStateToProps = (state) => ({
    translate: getTranslate(state.locale)
})

export default connect(mapStateToProps, { resetNotifications })(NotificationList)