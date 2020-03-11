import React, { Component } from 'react'
import { connect } from 'react-redux'
import FlatButton from 'material-ui/FlatButton'

class SecondStep extends Component {
    render() {
        const { calculatedDiscountResult, closeModal, nextSnd, couponMessage } = this.props
        return (
            <div>
                <h2>{calculatedDiscountResult && calculatedDiscountResult.totalMoney} AZN</h2>
                {couponMessage && <small>{couponMessage}</small>}                
                <div className='dvActions'>
                    <FlatButton label='cancel' primary={true} onClick={closeModal} />
                    <FlatButton label='Next' primary={true} onClick={nextSnd} />
                </div>
            </div>
        )
    }
}

const mapStateToProps = (state) => ({
    calculatedDiscountResult: state.services.calculatedDiscountResult,
    couponMessage: state.services.couponMessage
})

export default connect(mapStateToProps, null)(SecondStep)