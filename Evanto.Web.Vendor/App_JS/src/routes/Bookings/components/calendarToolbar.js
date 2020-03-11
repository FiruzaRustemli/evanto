import React, { Component } from 'react'
import { connect } from 'react-redux'
import BookingType from './bookingType'
import BookingTypeTablet from './bookingTypeTablet'
import { getTranslate } from 'react-localize-redux'

import Toolbar from 'react-md/lib/Toolbars'
import Button from 'react-md/lib/Buttons/Button'
import bookingStatus from '../../../config/bookingStatus'
import MenuItemBigger from './calendarMenuItemsBigger'
import MenuItemPhone from './calendarMenuItemsPhone'
import ListItem from 'react-md/lib/Lists/ListItem'
import MenuButton from 'react-md/lib/Menus/MenuButton'
import Divider from 'react-md/lib/Dividers'
import Subheader from 'react-md/lib/Subheaders'

class CalendarToolbar extends Component {
    constructor(props) {
        super(props)
        this.state = {
            selectedChip: bookingStatus.all,
            drawerIsOpen: false
        }
    }

    openDrawer = () => {
        this.setState({
            drawerIsOpen: true
        })
    }
    closeDrawer = () => {
        this.setState({
            drawerIsOpen: false
        })
    }
    drawerToggle = (drawerIsOpen) => {
        this.setState({
            drawerIsOpen
        })
    }

    render() {
        const { bookingStatusClick, translate, todayClick, rightClick, leftClick, calendarViewClick, calendarViewTitle } = this.props
        const actions = []
        const { width } = this.props
        if (width < 1090 && width > 1030) {
            BookingTypeTablet({
                selectedChip: this.state.selectedChip,
                onClickAll: () => {
                    this.setState({
                        selectedChip: bookingStatus.all
                    })
                    bookingStatusClick(bookingStatus.all)
                },
                onClickWaiting: () => {
                    this.setState({
                        selectedChip: bookingStatus.waiting
                    })
                    bookingStatusClick(bookingStatus.waiting)
                },
                onClickApproved: () => {
                    this.setState({
                        selectedChip: bookingStatus.approved
                    })
                    bookingStatusClick(bookingStatus.approved)
                },
                onClickRejected: () => {
                    this.setState({
                        selectedChip: bookingStatus.rejected
                    })
                    bookingStatusClick(bookingStatus.rejected)
                },
                onClickOwn: () => {
                    this.setState({
                        selectedChip: bookingStatus.createdByVendor
                    })
                    bookingStatusClick(bookingStatus.createdByVendor)
                },
                ...translate([
                    '##allBookings',
                    '##waiting',
                    '##approved',
                    '##rejected',
                    '##owner'
                ])
            }).map(item => {
                actions.push(item)
            })
        }
        if (width > 1030) {
            actions.push(<Button onClick={todayClick} style={{ verticalAlign: 'top' }} flat primary label={translate('##today')}></Button>)
        } else {
            actions.push(<Button onClick={todayClick} style={{ verticalAlign: 'top' }} icon primary iconClassName='fa fa-calendar-check-o'></Button>)
        }
        actions.push(<Button onClick={leftClick} key='left' icon>chevron_left</Button>)
        actions.push(<Button onClick={rightClick} key='right' icon>chevron_right</Button>)

        if (width > 1030) {
            actions.push(<MenuItemBigger
                {...translate([
                    '##calendarMenu',
                    '##month',
                    '##week',
                    '##day'
                ])}
                bookingStatusClick={bookingStatusClick}
                calendarViewClick={calendarViewClick}
            />)
        } else {
            actions.push(<Button onClick={this.openDrawer} key='menu' icon>more_vert</Button>)
        }

        const nav = <Button key='nav' icon>menu</Button>
        return (
            <div className='md-cell md-cell--12'>
                {width > 1090 && <BookingType bookingStatusClick={bookingStatusClick} />}
                <div className='md-cell md-cell--12'>
                    <Toolbar
                        id='calendarToolbar'
                        colored
                        title={calendarViewTitle}
                        actions={actions}
                    />
                    <MenuItemPhone
                        toggle={this.drawerToggle}
                        closeDrawer={this.closeDrawer}
                        isOpen={this.state.drawerIsOpen}
                        bookingStatusClick={bookingStatusClick}
                        calendarViewClick={calendarViewClick}
                    />
                </div>
            </div>
        )
    }
}

const mapStateToProps = (state) => ({
    width: state.events.width,
    calendarViewTitle: state.bookings.calendarViewTitle,
    translate: getTranslate(state.locale)
})

export default connect(mapStateToProps)(CalendarToolbar)
