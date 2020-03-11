import React, { Component } from 'react'
import { connect } from 'react-redux'
import { oauth } from '../../config'
import { Link, hashHistory } from 'react-router'
import { urlConfig } from '../../config'
import { getVendorDetails, logOut } from '../../routes/Account/modules/account'
import { getTranslate } from 'react-localize-redux'

import List from 'react-md/lib/Lists/List';
import ListItem from 'react-md/lib/Lists/ListItem';
import Avatar from 'react-md/lib/Avatars';
import FontIcon from 'react-md/lib/FontIcons';
import Paper from 'react-md/lib/Papers'
import Subheader from 'react-md/lib/Subheaders';
import Menu from 'react-md/lib/Menus/Menu';
import Divider from 'react-md/lib/Dividers';

import './userPanel.scss'

class UserPane extends Component {
  constructor(props) {
    super(props)
    this.state = {
      open: false
    }
  }

  openYourMouth = (command) => {
    switch (command) {
      case 'open':
        this.setState({ open: true })
        break;
      case 'close':
        this.setState({ open: false })
        break;
    }
  }

  render() {
    const { vendor, logOut, translate } = this.props
    if (vendor) {
      return (
        <ul className='user_panel' onMouseOver={() => this.openYourMouth('open')} onMouseLeave={() => this.openYourMouth('close')}>
          <li>
            <Avatar src={(vendor && vendor.file && vendor.file.container)
              ? `data:${vendor.file.mediaType};base64, ${vendor.file.container}`
              : `${urlConfig.getCurrentProjectAddress()}/assets/img/download.png`} alt='' role='presentation' />
            <span className='profile-info' >
              {vendor && `${vendor.user.firstName} ${vendor.user.lastName}`}
            </span>
            <i className='material-icons'>keyboard_arrow_down</i>
            <br />
            
            <Menu isOpen={this.state.open} onClose={() => { }} className='menu-example menu-example--static' style={{ marginLeft: 150 }}
              onMouseLeave={() => this.openYourMouth('close')}>
              <ListItem primaryText={translate('##profile')} onClick={() => hashHistory.push('account')} style={{ marginTop: 10 }}
                leftIcon={<i className='fa fa-fw fa-cog'></i>} />
              <Divider />
              <ListItem leftIcon={<i className='fa fa-fw fa-power-off text-danger'></i>} primaryText={translate('##logOut')} onClick={() => {
                logOut()
                localStorage.removeItem(oauth.localStorageTokenKey)
                hashHistory.push('login')
                window.$.connection.hub.stop()
              }} />
            </Menu>
          </li>
        </ul>
      )
    } else {
      return <div></div>
    }
  }
}

const mapStateToProps = (state) => ({ 
  vendor: state.account.vendor,
  translate: getTranslate(state.locale)
})
const mapDispatchToProps = {
  getVendorDetails,
  logOut
}
export default connect(mapStateToProps, mapDispatchToProps)(UserPane)
