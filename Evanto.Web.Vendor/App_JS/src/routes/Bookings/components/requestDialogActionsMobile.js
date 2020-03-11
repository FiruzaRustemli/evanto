import React from 'react'
import { bookingStatus } from '../../../config'
import Button from 'react-md/lib/Buttons/Button'

const requestModalButtonsMobile = props => {
    const { updateBookingStatus, cancel, type, event } = props
    switch (type) {
        case bookingStatus.waiting:
            return [
                <Button icon onClick={() => {
                        updateBookingStatus({
                            id: event.id,
                            statusId: bookingStatus.approved
                        })
                        cancel()
                    }}>done</Button>,
                <Button icon onClick={() => {
                        updateBookingStatus({
                            id: event.id,
                            statusId: bookingStatus.rejected
                        })
                        cancel()
                    }}>close</Button>
            ]
        case bookingStatus.approved:
            return [
                <Button icon onClick={() => {
                        updateBookingStatus({
                            id: event.id,
                            statusId: bookingStatus.rejected
                        })
                        cancel()
                    }}>close</Button>
            ]
        case bookingStatus.own:
            return [
                <Button icon onClick={() => {
                        updateBookingStatus({
                            id: event.id,
                            statusId: bookingStatus.rejected
                        })
                        cancel()
                    }}>close</Button>
            ]
        }
    }
export default requestModalButtonsMobile