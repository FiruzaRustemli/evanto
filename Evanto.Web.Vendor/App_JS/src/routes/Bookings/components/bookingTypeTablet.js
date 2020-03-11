import React from 'react'
import bookingStatus from '../../../config/bookingStatus'

import Chip from 'react-md/lib/Chips'
import Avatar from 'react-md/lib/Avatars'
import FontIcon from 'react-md/lib/FontIcons'
import Button from 'react-md/lib/Buttons/Button'

const BookingType = props => {
    const { selectedChip, onClickAll, onClickWaiting, onClickApproved, onClickRejected, onClickOwn } = props
    return [
        <Chip
            key='all'
            onClick={onClickAll}
            label={props['##allBookings']}
            className={`chip-tablet margin-10 ${selectedChip === bookingStatus.all ? 'avatar_color_pink white_span' : ''}`}
            avatar={
                <Avatar
                    className='avatar_color_pink'
                    icon={
                        <FontIcon>line_style</FontIcon>
                    }
                />
            }
        />,
        <Chip
            key='waiting'
            onClick={onClickWaiting}
            label={props['##waiting']}
            className={`chip-tablet margin-10 ${selectedChip === bookingStatus.waiting ? 'avatar_color_amber white_span' : ''}`}
            avatar={
                <Avatar
                    className='avatar_color_amber'
                    icon={
                        <FontIcon>timelapse</FontIcon>
                    }
                />
            }
        />,
        <Chip
            key='approved'
            onClick={onClickApproved}
            label={props['##approved']}
            className={`chip-tablet margin-10 ${selectedChip === bookingStatus.approved ? 'avatar_color_green white_span' : ''}`}
            avatar={
                <Avatar
                    className='avatar_color_green'
                    icon={
                        <FontIcon>done</FontIcon>
                    }
                />
            }
        />,
        <Chip
            key='rejected'
            onClick={onClickRejected}
            label={props['##rejected']}
            className={`chip-tablet margin-10 ${selectedChip === bookingStatus.rejected ? 'avatar_color_red white_span' : ''}`}
            avatar={
                <Avatar
                    className='avatar_color_red'
                    icon={
                        <FontIcon>clear</FontIcon>
                    }
                />
            }
        />,
        <Chip
            key='own'
            onClick={onClickOwn}
            label={props['##owner']}
            className={`chip-tablet margin-10 ${selectedChip === bookingStatus.createdByVendor ? 'avatar_color_blue white_span' : ''}`}
            avatar={
                <Avatar
                    className='avatar_color_blue'
                    icon={
                        <FontIcon>person_outline</FontIcon>
                    }
                />
            }
        />
    ]
}

export default BookingType