import React, { Component } from 'react'
import {
    Step,
    Stepper,
    StepLabel,
} from 'material-ui/Stepper'
import RaisedButton from 'material-ui/RaisedButton'
import FlatButton from 'material-ui/FlatButton'
import NewServices from '../containers/newServices'

class Services extends Component {
    constructor(props) {
        super(props)
        this.state = {
            step: 0
        }
    }
    render() {
        return (
            <div style={{ width: '100%'}}>
                <Stepper activeStep={this.state.step}>
                    <Step>
                        <StepLabel>Select campaign settings</StepLabel>
                    </Step>
                    <Step>
                        <StepLabel>Create an ad group</StepLabel>
                    </Step>
                    <Step>
                        <StepLabel>Create an ad</StepLabel>
                    </Step>
                </Stepper>
                {this.renderStep(this.state.step)}
                <button onClick={() => {
                    this.setState({
                        step: 1
                    })}}>btnNext</button>
            </div>
        )
    }

    renderStep = (step) => {
        switch (step) {
            case 0:
                return <NewServices />
        }
    }
}

export default Services