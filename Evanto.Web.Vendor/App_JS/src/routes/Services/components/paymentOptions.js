import React from 'react'
import { IconButton } from 'material-ui'
const PaymentOptions = (props) => {
    return (
        <div className='col-md-12'>
            <div className='card'>
                <div className='card-head'>
                    <header>{props['##paymentOption']}</header>
                    <div className='tools'>
                        <IconButton
                            tooltip={props['##back']}
                            tooltipPosition='top-right'
                            onTouchTap={stepBack}>
                            <i className='material-icons'>navigate_before</i>
                        </IconButton>
                    </div>
                </div>

                <div className='card-body'>
                    <div></div>
                </div>
            </div>
        </div>
    )
}

export default PaymentOptions