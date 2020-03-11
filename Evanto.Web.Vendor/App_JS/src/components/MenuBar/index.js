import React, { Component } from 'react'
import NavLink from './NavLink'
const MenuBar = () => (
    <ul className="nav nav-tabs col-md-6" style={{marginTop: '-23px'}}>
        <NavLink to='/' role='presentation'>
            <span className='title'>Bookings</span>
        </NavLink>
        <NavLink to='/services' role='presentation'>
            <span className='title'>Services</span>
        </NavLink>
    </ul>
    /*<div id='menubar' className='menubar-inverse  animate' >
        <div className='menubar-fixed-panel'>
            <div>
                <a className='btn btn-icon-toggle btn-default menubar-toggle' data-toggle='menubar' href='javascript:void(0);'>
                    <i className='fa fa-bars'></i>
                </a>
            </div>
            <div className='expanded'>
                <a href='../dashboards/dashboard.html'>
                    <span className='text-lg text-bold text-primary '>MATERIAL&nbsp;ADMIN</span>
                </a>
            </div>
        </div>
        <div className='nano has-scrollbar' style={{height: '244px'}}>
            <div className='nano-content' tabIndex='0' style={{right: '-17px'}}>
                <div className='menubar-scroll-panel' style={{paddingBottom: '55pxx'}}>

            
            <div className='menubar-foot-panel'>
                <small className='no-linebreak hidden-folded'>
                    <span className='opacity-75'>Copyright © 2017</span> <strong>Vento</strong>
                </small>
            </div>
        </div>
        </div>
            <div className='nano-pane'>
                <div className='nano-slider' style={{height: '63px', transform: 'translate(0px, 0px)'}}>
                </div>
            </div>
        </div>
    </div >*/
)
export default MenuBar