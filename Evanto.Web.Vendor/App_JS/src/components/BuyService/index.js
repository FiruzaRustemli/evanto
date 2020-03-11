import React from 'react'
import FlatButton from 'material-ui/FlatButton'
import ActionAdd from 'material-ui/svg-icons/action/add-shopping-cart';
import { hashHistory } from 'react-router'

const BuyService = props => (
    <li>
        <FlatButton
            label='BUY SERVICES'
            labelPosition="after"
            primary={true}
            onTouchTap={() => hashHistory.replace('/services/new')}
            icon={<ActionAdd />}
        />
    </li>
)

export default BuyService