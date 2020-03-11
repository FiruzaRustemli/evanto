import React, { Component } from 'react'
import { getTranslate } from 'react-localize-redux'
import { connect } from 'react-redux'
import { getAllBookingNotifications, resetNotifications } from '../../store/notificationReducer'
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

class NotificationListPhone extends Component {
    constructor(props) {
        super(props)
        this.state = {
            page: 1
        }
    }
    componentWillUnmount() {
        const { resetNotifications } = this.props
        resetNotifications()
    }

    render() {
        const { btnDisabled, onMouseLeave, getAllBookingNotifications, notifications, notificationClick, translate } = this.props
        const nav = <Button disabled={btnDisabled} icon onClick={onMouseLeave}>close</Button>;
        return (
            <Dialog
                visible={true}
                fullPage
                aria-label='Pending events'
            >
                <Toolbar
                    colored
                    nav={nav}
                    title='Pending events'
                />
                <List>
                    {(notifications && notifications.length > 0) ? notifications.map((item, key) => {
                        let additionalData = JSON.parse(item.additionalData)
                        return (
                            <ListItem
                                id={`${item.statusId === 1 ? 'notificationRead' : 'notificationUnread'}`}
                                style={{ textAlign: 'left', borderBottom: '1px solid #d1d1d1' }}
                                key={key}
                                active={false}
                                className='notification-listitem'
                                onTouchTap={() => {
                                    notificationClick(item)
                                    onMouseLeave()
                                }}
                                primaryText={translate(`##${additionalData.ResourceKey}`)
                                    .replace('{userName}', `${additionalData.UserName}`)
                                    .replace('{serviceName}', `${additionalData.VendorServiceName}`)}
                            />
                        )
                    })
                        : <p style={{ textAlign: 'center' }}>{translate('##noPendingNotification')}</p>
                    }
                    {(notifications && notifications.length > 0) &&
                        <div style={{ textAlign: 'center' }}>
                            <Button onClick={() => {
                                getAllBookingNotifications({ skip: this.state.page * 10 })
                                this.setState({
                                    page: this.state.page + 1
                                })
                            }} flat primary label='See more' />
                        </div>}
                </List>
            </Dialog>
        )
    }
}

const mapStateToProps = (state) => ({
    translate: getTranslate(state.locale),
    width: state.events.width
})

const mapDispatchToProps = {
    getAllBookingNotifications,
    resetNotifications
}

export default connect(mapStateToProps, mapDispatchToProps)(NotificationListPhone)