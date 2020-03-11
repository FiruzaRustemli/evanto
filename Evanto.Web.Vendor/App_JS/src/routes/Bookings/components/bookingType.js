import React, { Component } from 'react'
import { connect } from 'react-redux'
import bookingStatus from '../../../config/bookingStatus'
import { getTranslate } from 'react-localize-redux'

import Chip from 'react-md/lib/Chips'
import Avatar from 'react-md/lib/Avatars'
import FontIcon from 'react-md/lib/FontIcons'

class BookingType extends Component {
    constructor (props) {
        super(props)
        this.state = {
            selectedChip: bookingStatus.all
        }
    }
    render () {
        const { width, bookingStatusClick, translate } = this.props
        return (
            <div className='md-cell md-cell--12'>
                <div className='pull_right_chips'>
                <Chip label={translate('##allBookings')}
                onClick={() => {
                    this.setState({
                        selectedChip: bookingStatus.all
                    })
                    bookingStatusClick(bookingStatus.all)
                }}
                className={`margin-10 ${this.state.selectedChip === bookingStatus.all ? 'avatar_color_pink white_span' : ''}`}
                 avatar={<Avatar className='avatar_color_pink' icon={<FontIcon>line_style</FontIcon>} />} />
                
                <Chip label={translate('##waiting')}
                onClick={() => {
                    this.setState({
                        selectedChip: bookingStatus.waiting
                    })
                     bookingStatusClick(bookingStatus.waiting)
                }}
                className={`margin-10 ${this.state.selectedChip === bookingStatus.waiting ? 'avatar_color_amber white_span' : ''}`}
                 avatar={<Avatar className='avatar_color_amber' icon={<FontIcon>timelapse</FontIcon>} />} />
                
                <Chip label={translate('##approved')}
                onClick={() => {
                    this.setState({
                        selectedChip: bookingStatus.approved
                    })
                    bookingStatusClick(bookingStatus.approved)
                }}
                className={`margin-10 ${this.state.selectedChip === bookingStatus.approved ? 'avatar_color_green white_span' : ''}`}                
                 avatar={<Avatar className='avatar_color_green' icon={<FontIcon>done</FontIcon>} />} />
                <Chip label={translate('##rejected')}
                onClick={() => {
                    this.setState({
                        selectedChip: bookingStatus.rejected
                    })
                    bookingStatusClick(bookingStatus.rejected)
                }}
                className={`margin-10 ${this.state.selectedChip === bookingStatus.rejected ? 'avatar_color_red white_span' : ''}`}                
                 avatar={<Avatar className='avatar_color_red' icon={<FontIcon>clear</FontIcon>} />} />
                <Chip label={translate('##owner')}
                onClick={() => {
                    this.setState({
                        selectedChip: bookingStatus.createdByVendor
                    })
                    bookingStatusClick(bookingStatus.createdByVendor)
                }}
                className={`margin-10 ${this.state.selectedChip === bookingStatus.createdByVendor ? 'avatar_color_blue white_span' : ''}`}                
                 avatar={<Avatar className='avatar_color_blue' icon={<FontIcon>person_outline</FontIcon>} />} />
                </div>
            </div>
        )
    }
}

const mapStateToProps = (state) => ({
    width: state.events.width,
    translate: getTranslate(state.locale)
})

export default connect(mapStateToProps)(BookingType)