import React, { Component } from 'react'
import { connect } from 'react-redux'
import urlConfig from '../../config/urlConfig'
import moment from 'moment'

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

class pendingList extends Component {
    constructor (props) {
        super(props)
        this.state = {
            btnDisabled: true
        }
    }

    componentDidMount () {
        setTimeout(() => {
            this.setState({
                btnDisabled: false
            })
        }, 500)
    }

    render () {
    const { pendingBookings, onMouseLeave, onReject, onApprove, eventClicked } = this.props
        if(this.props.width > 1090) {
            return (
                <List style={{ overflowX: 'auto', maxHeight: '440px '}} onMouseLeave={onMouseLeave} className='menu-example menu-example--static'>
                    {(pendingBookings && pendingBookings.length > 0) ? pendingBookings.map((item, key) => {
                        return (
                                <ListItem
                                id='pendingListItem'
                                style={{ textAlign: 'left' }}
                                key={key}
                                onClick={() => {
                                    eventClicked(item)
                                }}
                                leftAvatar={<Avatar role='presentation' src={`${item.userImagePath ? 'data:image/jpg;base64, ' + item.userImagePath : urlConfig.getCurrentProjectAddress() + '/assets/img/download.png'}`}></Avatar>}
                                primaryText={`${item.userFullName}`}
                                secondaryText={`${item.serviceName} -  ${moment(item.bookDate).format('LLLL')}`}
                            />
                        )
                    })
                        : <p style={{ textAlign: 'center' }}>No pending requests</p>
                    }

                </List>
            )
        } else {
            const nav = <Button disabled={this.state.btnDisabled} icon onClick={onMouseLeave}>close</Button>;
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
                    {(pendingBookings && pendingBookings.length > 0) ? pendingBookings.map((item, key) => {
                        return (
                            <ListItem
                                style={{ textAlign: 'left' }}
                                key={key}
                                id='pendingListItem'
                                onClick={() => {
                                    eventClicked(item)
                                    onMouseLeave()
                                }}
                                leftAvatar={<Avatar role='presentation' src={`${item.userImagePath ? 'data:image/jpg;base64, ' + item.userImagePath : urlConfig.getCurrentProjectAddress() + '/assets/img/download.png'}`}></Avatar>}
                                primaryText={`${item.userFullName}`}
                                secondaryText={`${item.serviceName} -  ${moment(item.bookDate).format('LLLL')}`}
                            />
                        )
                    })
                        : <p style={{ textAlign: 'center' }}>No pending requests</p>
                    }

                </List>
                </Dialog>
            )
        }
    }
}

const mapStateToProps = (state) => ({
    width: state.events.width
})

export default connect(mapStateToProps)(pendingList)