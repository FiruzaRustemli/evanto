import React, { Component } from 'react'
import Header from '../../components/Header'
import './CoreLayout.scss'
import '../../styles/core.scss'
import 'react-md/dist/react-md.teal-blue.min.scss'
import 'react-big-calendar/lib/css/react-big-calendar.css'
import MenuBar from '../../components/MenuBar'
import { connect } from 'react-redux'
import { getVendorDetails } from '../../routes/Account/modules/account'

class CoreLayout extends Component {

  componentWillMount() {
    const { getVendorDetails } = this.props
    getVendorDetails({ connect: true })
  }

  render() {
    const { width } = this.props
    return (
      <section id='mainSection' style={{
        padding: 0
      }}>
        <Header />
        <div id='content'>
          {this.props.children}
        </div>
      </section>
    )
  }
}

CoreLayout.propTypes = {
  children: React.PropTypes.element.isRequired
}


const mapDispatchToProps = {
  getVendorDetails
}

export default connect(null, mapDispatchToProps)(CoreLayout)
