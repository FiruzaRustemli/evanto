import { AccountApi as api } from '../../../services/controllers'
import { hashHistory } from 'react-router'

const ACTION_HANDLERS = {}
const initialState = { requestPending: false }

// ------------------------------------
// Constants
// ------------------------------------
export const GET_VENDOR_DETAILS_REQUEST = 'GET_VENDOR_DETAILS_REQUEST'
export const GET_VENDOR_DETAILS_SUCCESS = 'GET_VENDOR_DETAILS_SUCCESS'
export const GET_VENDOR_DETAILS_ERROR = 'GET_VENDOR_DETAILS_ERROR'
export const UPDATE_CONTACT_INFO_REQUEST = 'UPDATE_CONTACT_INFO_REQUEST'
export const UPDATE_CONTACT_INFO_SUCCESS = 'UPDATE_CONTACT_INFO_SUCCESS'
export const UPDATE_CONTACT_INFO_ERROR = 'UPDATE_CONTACT_INFO_ERROR'
export const UPDATE_PERSONAL_INFO_REQUEST = 'UPDATE_PERSONAL_INFO_REQUEST'
export const UPDATE_PERSONAL_INFO_SUCCESS = 'UPDATE_PERSONAL_INFO_SUCCESS'
export const UPDATE_PERSONAL_INFO_ERROR = 'UPDATE_PERSONAL_INFO_ERROR'
export const UPLOAD_AVATAR_REQUEST = 'UPLOAD_AVATAR_REQUEST'
export const UPLOAD_AVATAR_SUCCESS = 'UPLOAD_AVATAR_SUCCESS'
export const UPLOAD_AVATAR_ERROR = 'UPLOAD_AVATAR_ERROR'
export const UPDATE_USER_SETTINGS_REQUEST = 'UPDATE_USER_SETTINGS_REQUEST'
export const UPDATE_USER_SETTINGS_SUCCESS = 'UPDATE_USER_SETTINGS_SUCCESS'
export const UPDATE_USER_SETTINGS_ERROR = 'UPDATE_USER_SETTINGS_ERROR'
export const CHANGE_PASSWORD_REQUEST = 'CHANGE_PASSWORD_REQUEST'
export const CHANGE_PASSWORD_SUCCESS = 'CHANGE_PASSWORD_SUCCESS'
export const CHANGE_PASSWORD_ERROR = 'CHANGE_PASSWORD_ERROR'
export const LOG_OUT = 'LOG_OUT'

export const getVendorDetails = (args) => {
    return (dispatch) => {
        return new Promise((resolve, reject) => {
            dispatch({
                type: GET_VENDOR_DETAILS_REQUEST
            })
            api.getVendorDetails()
                .then(vendor => {
                    dispatch({
                        type: GET_VENDOR_DETAILS_SUCCESS,
                        payload: vendor,
                        connect: args.connect
                    })
                })
                .catch(error => {
                    dispatch({
                        type: GET_VENDOR_DETAILS_ERROR,
                        error
                    })
                })
        })
    }
}

export const updatePersonalInfo = (args) => {
    return (dispatch) => {
        return new Promise((resolve, reject) => {
            dispatch({
                type: UPDATE_PERSONAL_INFO_REQUEST
            })
            api.updatePersonalInfo(args)
                .then(vendor => {
                    dispatch({
                        type: UPDATE_PERSONAL_INFO_SUCCESS,
                        payload: {
                            vendor,
                            notify: true,
                            type: 'success',
                            message: ['##successfullyUpdated']
                        }
                    })
                })
                .catch(error => {
                    dispatch({
                        type: UPDATE_PERSONAL_INFO_ERROR,
                        error: {
                            error,
                            notify: true,
                            type: 'error',
                            message: (error.data && error.data.errorList && error.data.errorList.length > 0) ? error.data.errorList : ['##unhandledError']
                        }
                    })
                })
        })
    }
}

export const updateContactInfo = (args) => {
    return (dispatch) => {
        return new Promise((resolve, reject) => {
            dispatch({
                type: UPDATE_CONTACT_INFO_REQUEST
            })
            api.updateContactInfo(args)
                .then(vendor => {
                    dispatch({
                        type: UPDATE_CONTACT_INFO_SUCCESS,
                        payload: {
                            vendor,
                            notify: true,
                            type: 'success',
                            message: ['##successfullyUpdated']
                        }
                    })
                })
                .catch(error => {
                    dispatch({
                        type: UPDATE_CONTACT_INFO_ERROR,
                        error: {
                            error,
                            notify: true,
                            type: 'error',
                            message: (error.data && error.data.errorList && error.data.errorList.length > 0) ? error.data.errorList : ['##unhandledError']
                        }
                    })
                })
        })
    }
}

export const uploadAvatar = (args) => {
    return (dispatch) => {
        return new Promise((resolve, reject) => {
            dispatch({
                type: UPLOAD_AVATAR_REQUEST
            })
            api.uploadAvatar(args)
                .then(response => {
                    dispatch({
                        type: UPLOAD_AVATAR_SUCCESS,
                        payload: response
                    })
                })
                .catch(error => {
                    dispatch({
                        type: UPLOAD_AVATAR_ERROR,
                        error
                    })
                })
        })
    }
}

export const logOut = (args) => {
    return (dispatch) => {
        return new Promise((resolve, reject) => {
            dispatch({
                type: LOG_OUT
            })
            hashHistory.replace('/login')
        })
    }
}

export const updateUserSettings = (args) => {
    return dispatch => {
        return new Promise((resolve, reject) => {
            debugger
            dispatch({
                type: UPDATE_USER_SETTINGS_REQUEST
            })
            api.updateUserSettings(args)
                .then(output => {
                    dispatch({
                        type: UPDATE_USER_SETTINGS_SUCCESS,
                        payload: args
                    })
                })
                .catch(error => {
                    console.log('ne lan bu error', error)
                    dispatch({
                        type: UPDATE_USER_SETTINGS_ERROR,
                        error
                    })
                })
        })
    }
}

export const changePass = (args) => {
    return dispatch => {
        return new Promise((resolve, reject) => {
            dispatch({
                type: CHANGE_PASSWORD_REQUEST
            })
            api.changePassword(args)
                .then(output => {
                    dispatch({
                        type: CHANGE_PASSWORD_SUCCESS,
                        payload: {
                            output,
                            notify: true,
                            type: 'success',
                            message: ['##successfullyUpdated']
                        }
                    })
                })
                .catch(error => {
                    console.log('err', error)
                    dispatch({
                        type: CHANGE_PASSWORD_ERROR,
                        error: {
                            error,
                            notify: true,
                            type: 'error',
                            message: error.response
                                && error.response.data
                                && error.response.data.errorList
                                && (error.response.data.errorList.length > 0)
                                ? error.response.data.errorList.map(er => {
                                    return er.code ? `##${er.code}` : er.text
                                })
                                : ['##unhandledError']
                        }
                    })
                })
        })
    }
}

// ------------------------------------
// Action Handlers
// ------------------------------------
Object.assign(ACTION_HANDLERS, {
    [GET_VENDOR_DETAILS_REQUEST]: (state) => {
        return {
            ...state,
            requestPending: true
        }
    },
    [GET_VENDOR_DETAILS_SUCCESS]: (state, action) => {
        return {
            ...state,
            requestPending: false,
            vendor: action.payload.vendor
        }
    },
    [GET_VENDOR_DETAILS_ERROR]: (state, action) => {
        return {
            ...state,
            requestPending: false,
            error: action.error
        }
    },
    [UPDATE_CONTACT_INFO_REQUEST]: (state) => {
        return {
            ...state,
            requestPending: true
        }
    },
    [UPDATE_CONTACT_INFO_SUCCESS]: (state, action) => {
        let user = Object.assign({}, state.vendor.user, {
            phone: action.payload.vendor.contactInformation.phone,
            username: action.payload.vendor.contactInformation.username
        })
        let newVendor = {
            address: action.payload.vendor.contactInformation.address,
            user
        }
        return {
            ...state,
            requestPending: false,
            vendor: Object.assign({}, state.vendor, newVendor)
        }
    },
    [UPDATE_CONTACT_INFO_ERROR]: (state, action) => {
        return {
            ...state,
            requestPending: false,
            error: action.error.error
        }
    },
    [UPDATE_PERSONAL_INFO_REQUEST]: (state) => {
        return {
            ...state,
            requestPending: true
        }
    },
    [UPDATE_PERSONAL_INFO_SUCCESS]: (state, action) => {
        let user = Object.assign({}, state.vendor.user, {
            firstName: action.payload.vendor.vendorBasicInformation.firstName,
            lastName: action.payload.vendor.vendorBasicInformation.lastName,
            birthday: action.payload.vendor.vendorBasicInformation.birthDate,
            maritalStatus: action.payload.vendor.vendorBasicInformation.maritalStatus
        })
        let newVendor = {
            user,
            name: action.payload.vendor.vendorBasicInformation.companyName
        }
        return {
            ...state,
            requestPending: false,
            vendor: Object.assign({}, state.vendor, newVendor)
        }
    },
    [UPDATE_PERSONAL_INFO_ERROR]: (state, action) => {
        return {
            ...state,
            requestPending: false,
            error: action.error.error
        }
    },
    [UPLOAD_AVATAR_REQUEST]: (state) => {
        return {
            ...state,
            requestPending: true
        }
    },
    [UPLOAD_AVATAR_SUCCESS]: (state, action) => {
        let file = Object.assign({}, state.vendor.file, {
            container: action.payload.container
        })
        let newVendor = {
            file
        }
        return {
            ...state,
            requestPending: false,
            vendor: Object.assign({}, state.vendor, newVendor)
        }
    },
    [UPLOAD_AVATAR_ERROR]: (state, action) => {
        return {
            ...state,
            requestPending: false,
            error: action.error
        }
    },
    [LOG_OUT]: (state, action) => {
        return {}
    }
})

// ------------------------------------
// Reducer
// --------------------
export default function accountReducer(state = initialState, action) {
    const handler = ACTION_HANDLERS[action.type]

    return handler ? handler(state, action) : state
}