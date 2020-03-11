
import React from 'react'
import { bookingStatus } from '../../../config'

const renderModalButtons = (props) => {
    const { updateBookingStatus, cancel, type, event } = props
    switch (type) {
        case bookingStatus.waiting:
            return [{
                onClick: () => {
                    updateBookingStatus({
                        id: event.id,
                        statusId: bookingStatus.approved
                    })
                    cancel()
                },
                primary: true,
                label: props['##approve'],
            }, {
                onClick: () => {
                    updateBookingStatus({
                        id: event.id,
                        statusId: bookingStatus.rejected
                    })
                    cancel()
                },
                primary: true,
                label: props['##reject'],
            },
            {
                onClick: cancel,
                primary: true,
                label: props['##close'],
            }]
        case bookingStatus.approved:
            return [{
                onClick: () => {
                    updateBookingStatus({
                        id: event.id,
                        statusId: bookingStatus.rejected
                    })
                    cancel()
                },
                primary: true,
                label: props['##cancelBooking'],
            },
            {
                onClick: cancel,
                primary: true,
                label: props['##close'],
            }]
        case bookingStatus.rejected:
            return [{
                onClick: cancel,
                primary: true,
                label: props['##close'],
            }]
        case bookingStatus.createdByVendor:
            return [{
                onClick: cancel,
                primary: true,
                label: props['##close'],
            }]
    }
}

export default renderModalButtons