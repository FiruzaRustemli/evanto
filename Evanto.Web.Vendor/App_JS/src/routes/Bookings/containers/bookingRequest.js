import React, { Component } from 'react'
import { connect } from 'react-redux'
import FlatButton from 'material-ui/FlatButton';
import moment from 'moment'
import Dialog from 'react-md/lib/Dialogs'
import { updateBookingStatus } from '../modules/bookings'
import { bookingStatus, urlConfig, requestColor, requestClass } from '../../../config'
import CSSTransitionGroup from 'react-addons-css-transition-group';
import CircularProgress from 'react-md/lib/Progress/CircularProgress';
import Toolbar from 'react-md/lib/Toolbars'
import Button from 'react-md/lib/Buttons/Button'
import { getTranslate } from 'react-localize-redux'
import renderModalButtons from '../components/requestDialogActions'
import renderModalButtonsMobile from '../components/requestDialogActionsMobile'

class BookingRequest extends Component {

  render() {
    const { updateBookingStatus, cancel, translate, requestPending, requestUserInfo, event, show, width } = this.props
    const config = {}
    if (width < 1090) {
      Object.assign(config, {}, {
        fullPage: true
      })
    }

    const type = requestUserInfo.booking.userId ? requestUserInfo.booking.statusId : 4

    const actions = requestUserInfo && renderModalButtons({
      ...translate([
        '##approve',
        '##reject',
        '##close',
        '##cancelBooking',
        '##close'
      ]),
      event,
      updateBookingStatus,
      cancel,
      type
    })
    const actionsMobile = requestUserInfo && renderModalButtonsMobile({
      ...translate([
        '##approve',
        '##reject',
        '##close',
        '##cancelBooking',
        '##close'
      ]),
      event,
      updateBookingStatus,
      cancel,
      type
    })

    const nav = <Button icon onClick={cancel}>close</Button>;
    console.log('burda eventin tipine baxmaq isteyirem o ye', requestUserInfo.booking)
    return (
      <Dialog
        id='bookingRequestDialog'
        visible={show}
        title={translate('##request')}
        onHide={cancel}
        className={`${width > 1090 ? requestUserInfo && ('dialog-request ' + requestClass(type)) : ''}`}
        actions={requestPending ? null : actions}
        {...config}
      >
        {width < 1090 && <Toolbar
          colored
          style={{ background: `${requestUserInfo && requestColor(type)}` }}
          nav={nav}
          titleStyle={{ color: 'white' }}
          actions={requestPending ? null : actionsMobile}
          title={translate('##request')}
        />}
        {requestUserInfo && !requestPending
          ? <div className='form-group'>
            <div className='modal-body'>
              {type !== 4 ?
                <center>
                  <img src={(requestUserInfo && requestUserInfo.user && requestUserInfo.user.url) ? 'data:image/jpg;base64,' + requestUserInfo.user.url :
                    `${urlConfig.getCurrentProjectAddress()}/assets/img/download.png`} style={{ marginBottom: '10px' }} name='aboutme' width='140' height='140' frameBorder='0' className='img-circle' />
                  <h3 className='media-heading'>{`${requestUserInfo.user.firstName} ${requestUserInfo.user.lastName}`}</h3>
                  <span><strong>{translate('##event')}: </strong></span>
                  <span style={{ fontSize: '10pt' }} className='label label-warning'>{requestUserInfo.eventName}</span>
                  <span style={{ marginLeft: '5px' }}><strong>{translate('##service')}: </strong></span>
                  <span style={{ fontSize: '10pt' }} className='label label-info'>{requestUserInfo.serviceName}</span> <br />
                </center>
                : <div></div>}
              <hr />
              <center>
                <p className='text-left'><strong>{translate('##datetime')}: </strong><br />
                  {requestUserInfo.booking.bookDate ? moment(requestUserInfo.booking.bookDate).locale('az').format('LLL') : ' --- '}
                </p>
                <p className='text-left'><strong>{translate('##description')}: </strong><br />
                  {requestUserInfo.booking.description ? requestUserInfo.booking.description : ' --- '}
                </p>
                <br />
              </center>
            </div>
          </div>
          : <CircularProgress key='progress' />}
      </Dialog>
    )
  }
}

const mapDispatchToProps = {
  updateBookingStatus
}

const mapStateToProps = (state) => ({
  requestPending: state.bookings.requestPending,
  width: state.events.width,
  translate: getTranslate(state.locale)
})

export default connect(mapStateToProps, mapDispatchToProps)(BookingRequest)