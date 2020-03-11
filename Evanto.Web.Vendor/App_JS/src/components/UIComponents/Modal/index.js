import React from 'react'
import PropTypes from 'prop-types'

const Modal = ({
  children,
    confirm,
    cancel,
    header,
    show,
    confirmText,
    cancelText
}) => (
        <div
            className='modal'
            tabIndex='-1'
            role='dialog'
            style={{
                display: `${show
                    ? 'block'
                    : 'none'}`
            }}>
            <div className='modal-dialog' role='document'>
                <div className='modal-content'>
                    <div className='modal-header'>
                        <button onClick={cancel} type='button' className='close' data-dismiss='modal' aria-label='Close'>
                            <span aria-hidden='true' style={{fontStyle: 'lowerCase !important'}}>x</span>
                        </button>
                        <h4 className='modal-title' id='myModalLabel'>{header}</h4>
                    </div>
                    <div className='modal-body'>
                        {children}
                    </div>
                    <div className='modal-footer'>
                        {cancelText && <button onClick={cancel}
                            type='button'
                            className='btn btn-default btn-simple'
                            data-dismiss='modal'>{cancelText}</button>}
                        { confirmText && <button onClick={confirm} type='button' className='btn btn-success btn-fill'>{confirmText}</button>}
                    </div>
                </div>
            </div>
        </div>
    )

Modal.propTypes = {
    children: PropTypes.node.isRequired
}

export default Modal