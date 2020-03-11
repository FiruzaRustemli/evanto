import React, { Component } from 'react'
import { connect } from 'react-redux'
import { getTranslate } from 'react-localize-redux'

import Button from 'react-md/lib/Buttons/Button'

class servicePriceInfoButton extends Component {
    constructor(props) {
        super(props)
        this.state = {
            disabled: true
        }
    }
    componentWillMount () {
        setTimeout(() => {
            this.setState({ disabled: false})
        }, 500);
    }
    render() {
        const { stepBack, onNext, translate } = this.props
        const { disabled } = this.state
        return (
            <div className='md-cell md-cell--7 md-cell--5-offset'>
                <Button
                    label={translate('##back')}
                    flat
                    disabled={disabled}
                    default={true}
                    onClick={stepBack} />
                <Button
                    label={translate('##next')}
                    primary={true}
                    flat
                    disabled={disabled}
                    style={{ marginLeft: '10px' }}
                    onClick={onNext} />
            </div>
        )
    }
}

const mapStateToProps = (state) => ({
    translate: getTranslate(state.locale)
})

export default connect(mapStateToProps)(servicePriceInfoButton)