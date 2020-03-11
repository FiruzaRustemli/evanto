import React, { Component } from 'react'
import { connect } from 'react-redux'
import urlConfig from '../../config/urlConfig'
import moment from 'moment'
import { getTranslate } from 'react-localize-redux'
import NotificationListPhone from './notificationListPhone'
import { push } from 'react-router-redux'

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

class notificationList extends Component {
    constructor(props) {
        super(props)
        this.state = {
            btnDisabled: true,
            page: 1
        }
    }

    componentDidMount() {
        setTimeout(() => {
            this.setState({
                btnDisabled: false
            })
        }, 500)
    }

    render() {
        const { width, notifications, onMouseLeave, notificationClick, translate, push } = this.props
        if (width > 1090) {
            return (
                <List onMouseLeave={onMouseLeave} className='menu-example menu-example--static'>
                    {(notifications && notifications.length > 0)
                        ? notifications.filter((i, index) => (index < 10)).map((item, key) => {
                            let additionalData = JSON.parse(item.additionalData)
                            return (
                                <ListItem
                                    id={`${item.statusId === 1 ? 'notificationRead' : 'notificationUnread'}`}
                                    style={{ textAlign: 'left' }}
                                    key={key}
                                    onTouchTap={() => {
                                        notificationClick(item)
                                        onMouseLeave()
                                    }}
                                    primaryText={translate(`##${additionalData.ResourceKey}`)
                                        .replace('{userName}', `${additionalData.UserName}`)
                                        .replace('{serviceName}', `${additionalData.VendorServiceName}`)}
                                />
                            )
                        }) : <p style={{ textAlign: 'center' }}>No notification</p>
                    }
                    {(notifications && notifications.length > 0) && <Button onClick={() => push('/notifications') } flat primary label='See all' />}
                </List>

            )
        } else {
            return (
                <NotificationListPhone btnDisabled={this.state.btnDisabled}
                    onMouseLeave={onMouseLeave}
                    notificationClick={notificationClick}
                    notifications={notifications} />
            )
        }
    }
}

const mapStateToProps = (state) => ({
    width: state.events.width,
    translate: getTranslate(state.locale)
})

const mapDispatchToProps = {
    push
}
export default connect(mapStateToProps, mapDispatchToProps)(notificationList)