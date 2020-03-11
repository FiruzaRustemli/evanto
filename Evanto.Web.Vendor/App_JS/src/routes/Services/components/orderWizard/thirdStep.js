import React from 'react'
import Ink from 'react-ink'
import FlatButton from 'material-ui/FlatButton'
import './thirdStep.css'

const ThirdStep = (props) => {
    return (
        <div style={{ marginTop: '30px' }}>
            <a onClick={() => {
                props.closeModal()
                props.addServices(Object.assign({}, props.addModel, { VendorServicePacketStatusId: 2 })) //TODO: move to json - deactive
            }}>
            <div className='col-md-4'>
                    <div className='card'>
                        <div className='dvCash card-body style-primary large-padding text-center'>Cash<br /><small></small></div>
                    </div>
                </div></a>
            <a onClick={() => {
                props.closeModal()
                props.addServices(Object.assign({}, props.addModel, { VendorServicePacketStatusId: 1 })) //TODO: move to json - waiting
            }}>
            <div className='col-md-4'>
                    <div className='card'>
                        <div className='dvCash card-body style-primary large-padding text-center'>Trial<br /><small></small></div>
                    </div>
                </div></a>
            <div className='col-md-4'>
                <div className='card'>
                    <div className='dvCard card-body style-primary large-padding text-center'>Card<br /><small>Tezliklə</small></div>
                </div>
            </div>

            <div className='dvActions'>
                <FlatButton label='cancel' primary={true} onClick={props.closeModal} />
            </div>
        </div>
    )
}

export default ThirdStep
