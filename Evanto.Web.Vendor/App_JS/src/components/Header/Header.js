import React, { Component } from 'react'
import { IndexLink, Link } from 'react-router'
import { connect } from 'react-redux'
import './Header.scss'
import UserPanel from '../../containers/UserPane'
import MenuBar from '../MenuBar'
import { Alert } from '../../containers/BookingAlert'
import { GeneralAlert } from '../../containers/GeneralAlert'
import AddBooking from '../../containers/AddBooking/index'
import BuyService from '../BuyService/index'
import FontIcon from 'react-md/lib/FontIcons'
import Paper from 'react-md/lib/Papers'
import Button from 'react-md/lib/Buttons/Button'
import Drawer from 'react-md/lib/Drawers'
import Toolbar from 'react-md/lib/Toolbars';
import { createBooking } from '../../routes/Bookings/modules/bookings'
import AddBookingForm from '../../routes/Bookings/containers/addBooking'
import NavListPhone from './navListPhone'
import { logOut } from '../../routes/Account/modules/account'
import { getTranslate, setActiveLanguage, getLanguages } from 'react-localize-redux'
import LanguageSelection from '../../containers/LanguageSelection'

class Header extends Component {
  constructor(props) {
    super(props)
    this.state = {
      visible: false,
      position: 'left',
      showAddBooking: false
    }
  }

  _closeAddBooking = () => {
    this.setState({ showAddBooking: false })
  }

  _showAddBooking = () => {
    this.setState({ showAddBooking: true })
  }

  _handleToggle = (visible) => {
    this.setState({ visible });
  }

  _closeDrawer = () => {
    this.setState({ visible: false });
  }

  _toggleLeft = () => {
    this.setState({ visible: !this.state.visible, position: 'left' });
  }

  _logout = () => {
    const { logOut } = this.props
    logOut()
    localStorage.removeItem(oauth.localStorageTokenKey)
    hashHistory.push('login')
    window.$.connection.hub.stop()
  }

  // componentWillMount() {
  //   const { setActiveLanguage } = this.props
  //   var arr = ['az', 'en', 'ru']
  //   var i = 0
  //   setInterval(() => {
  //     setActiveLanguage(arr[i++]);
  //     if (i > 2) {
  //       i = 0
  //     }
  //   }, 5000)
  // }

  renderList = () => {
    const { routeName } = this.props
    const { translate, currentLanguage, languages, setActiveLanguage } = this.props

    return (
      <div className='navigation_bar'>
        <ul>
          <li>
            <div>
              <Link to='/'>
                <Button
                  flat primary
                  label={translate('##bookings')}></Button></Link>
            </div>
          </li>
          <li>
            <div>
              <Link to='/services'>
                <Button
                  flat primary
                  label={translate('##services')}></Button></Link>
            </div>
          </li>
          <li>
            <div>
              <Link to='/services/new'>
                <Button
                  flat primary
                  label={translate('##buyServices')}>&#xE854;</Button></Link>
            </div>
          </li>
          <li>
            <Button
              onTouchTap={this._showAddBooking}
              flat primary
              label={translate('##addBookings')}>add</Button>
          </li>
          <li>
            <Alert />
          </li>
          <li>
            <GeneralAlert />
          </li>
          <li className='user_panel_li'><UserPanel /></li>
          <li className='user_panel_li'>
              <LanguageSelection />
          </li>
        </ul>
      </div>
    )
  }

  render() {
    const { createBooking, translate } = this.props
    const left = this.state.position === 'left'
    const close = <Button icon onClick={() => this.setState({ visible: false })}>
      {left ? 'arrow_back' : 'close'}
    </Button>
    const header = (
      <Toolbar
        nav={<div><Alert /><GeneralAlert /></div>}
        actions={left ? close : null}
        className="md-divider-border md-divider-border--bottom"
      />
    )

    return (
      <Paper className='paper_nav' zDepth={1} raiseOnHover={false}>
        <div className='navbar-header'>
          <Link to='/'><h2 className='md-headline .md-background--primary'>Brono</h2></Link>
        </div>

        <button
          onClick={() => this.setState({
            visible: true
          })}
          type='button'
          className='paper_nav_button'
          style={{ display: `${this.props.width > 1090 ? 'none' : 'block'}` }}>
          <i className='material-icons'>view_headline</i>
        </button>
        {this.state.showAddBooking && <AddBookingForm
          handleClose={this._closeAddBooking}
          show={this.state.showAddBooking}
          onSubmit={(args) => {
            createBooking(args)
          }} />}
        {(this.props.width > 1090) && this.renderList()}
        {(this.props.width < 1090) && <Drawer
          {...this.state}
          type={Drawer.DrawerTypes.TEMPORARY}
          navItems={NavListPhone({
            addBooking: this._showAddBooking, logout: this._logout,
            ...translate(['##bookings', '##services', '##profile', '##buyServices', '##addBookings', '##logOut'])
          })}
          onVisibilityToggle={this._handleToggle}
          header={header}
          style={{ zIndex: 100 }}
        />}
        {this.props.width < 1030 && <Button
          onClick={this._showAddBooking}
          floating
          secondary
          fixed
          style={{ marginRight: 5, marginBottom: 10 }}
        >
          add
        </Button>}
      </Paper>
    )
  }
}

const mapStateToProps = (state) => ({
  routeName: state.routing.locationBeforeTransitions.pathname,
  width: state.events.width,
  translate: getTranslate(state.locale),
  languages: getLanguages(state.locale)
})

const mapDispachToProps = {
  createBooking,
  logOut,
  setActiveLanguage
}

export default connect(mapStateToProps, mapDispachToProps)(Header)
