import { ServiceApi as api } from '../../../services/controllers'
import { push } from 'react-router-redux'
import { hashHistory } from 'react-router'

const ACTION_HANDLERS = {}
const initialState = { requestPending: false }

// ------------------------------------
// Constants
// ------------------------------------
export const GET_ALL_SERVICE_PACKETS_REQUEST = 'GET_ALL_SERVICE_PACKETS_REQUEST'
export const GET_ALL_SERVICE_PACKETS_SUCCESS = 'GET_ALL_SERVICE_PACKETS_SUCCESS'
export const GET_ALL_SERVICE_PACKETS_ERROR = 'GET_ALL_SERVICE_PACKETS_ERROR'

// ------------------------------------
// Actions
// ------------------------------------
function getAllServicePacketsRequest() {
  return {
    type: GET_ALL_SERVICE_PACKETS_REQUEST
  }
}

function getAllServicePacketsSuccess(packets) {
  return {
    type: GET_ALL_SERVICE_PACKETS_SUCCESS,
    payload: packets
  }
}

function getAllServicePacketsError(error) {
  return {
    type: GET_ALL_SERVICE_PACKETS_ERROR,
    error
  }
}

export const getAllServicePackets = (args) => {
  return (dispatch) => {
    return new Promise((resolve, reject) => {
      dispatch(getAllServicePacketsRequest())
      api.getVendorServicePackets(args)
        .then(servicePackets => {
          dispatch(getAllServicePacketsSuccess(servicePackets))
        })
        .catch(error => {
          dispatch(getAllServicePacketsError(error))
        })
    })
  }
}


// ------------------------------------
// Action Handlers
// ------------------------------------
Object.assign(ACTION_HANDLERS, {
  [GET_ALL_SERVICE_PACKETS_REQUEST]: (state) => {
    return {
      ...state,
      requestPendingServicePackets: true
    }
  },
  [GET_ALL_SERVICE_PACKETS_SUCCESS]: (state, action) => {
    return {
      ...state,
      requestPendingServicePackets: false,
      servicePackets: action.payload.vendorServicePackets
    }
  },
  [GET_ALL_SERVICE_PACKETS_ERROR]: (state, action) => {
    return {
      ...state,
      requestPendingServicePackets: false,
      error: action.error
    }
  }
})

const CHANGE_SERVICE_STATUS_REQUEST = 'CHANGE_SERVICE_STATUS_REQUEST'
const CHANGE_SERVICE_STATUS_SUCCESS = 'CHANGE_SERVICE_STATUS_SUCCESS'
const CHANGE_SERVICE_STATUS_ERROR = 'CHANGE_SERVICE_STATUS_ERROR'

function changeServiceStatusRequest() {
  return {
    type: CHANGE_SERVICE_STATUS_REQUEST
  }
}
function changeServiceStatusSuccess(vendorService) {
  return {
    type: CHANGE_SERVICE_STATUS_SUCCESS,
    payload: vendorService
  }
}
function changeServiceStatusError(error) {
  return {
    type: CHANGE_SERVICE_STATUS_ERROR,
    error
  }
}

export const changeServiceStatus = (args) => {
  return (dispatch) => {
    return new Promise((resolve, reject) => {
      dispatch(changeServiceStatusRequest())
      api.changeServiceStatus(args)
        .then(vendorService => {
          dispatch(changeServiceStatusSuccess({
            vendorService,
            notify: true,
            type: 'success',
            message: ['##successfullyUpdate']
          }))
        })
        .catch(error => {
          dispatch(changeServiceStatusError({
            error,
            notify: true,
            type: 'error',
            message: (error.data && error.data.errorList && error.data.errorList.length > 0) ? error.data.errorList : ['##unhandledError']
          }))
        })
    })
  }
}

Object.assign(ACTION_HANDLERS, {
  [CHANGE_SERVICE_STATUS_REQUEST]: (state) => {
    return {
      ...state,
      changeStatusRequestPending: true
    }
  },
  [CHANGE_SERVICE_STATUS_SUCCESS]: (state, action) => {
    let selectedVendorServices = state.selectedVendorServices
    let vendorServices = state.selectedVendorServices
    const foundIndex = state.selectedVendorServices.findIndex(x => x.id == action.payload.vendorService.vendorServiceId)
    vendorServices[foundIndex].status = action.payload.vendorService.status
    selectedVendorServices = vendorServices
    return {
      ...state,
      changeStatusRequestPending: false,
      changedVendorService: action.payload.vendorService,
      selectedVendorServices: selectedVendorServices
    }
  },
  [CHANGE_SERVICE_STATUS_ERROR]: (state, action) => {
    return {
      ...state,
      changeStatusRequestPending: false,
      error: action.error.error
    }
  }
})


const GET_SERVICE_PERIOD_PRICES_REQUEST = 'GET_SERVICE_PERIOD_PRICES_REQUEST'
const GET_SERVICE_PERIOD_PRICES_SUCCESS = 'GET_SERVICE_PERIOD_PRICES_SUCCESS'
const GET_SERVICE_PERIOD_PRICES_ERROR = 'GET_SERVICE_PERIOD_PRICES_ERROR'

function getServicePeriodPricesRequest() {
  return {
    type: GET_SERVICE_PERIOD_PRICES_REQUEST
  }
}
function getServicePeriodPricesSuccess(servicePeriodPrices) {
  return {
    type: GET_SERVICE_PERIOD_PRICES_SUCCESS,
    payload: servicePeriodPrices
  }
}
function getServicePeriodPricesError(error) {
  return {
    type: GET_SERVICE_PERIOD_PRICES_ERROR,
    error
  }
}

export const getServicePeriodPrices = (args) => {
  return (dispatch) => {
    return new Promise((resolve, reject) => {
      dispatch(getServicePeriodPricesRequest())
      api.getServicePeriodPrices(args)
        .then(servicePeriodPrices => {
          dispatch(getServicePeriodPricesSuccess(servicePeriodPrices))
        })
        .catch(error => {
          console.log('NECI ERRORDU ALA BU', error)
          dispatch(getServicePeriodPricesError(error))
        })
    })
  }
}

Object.assign(ACTION_HANDLERS, {
  [GET_SERVICE_PERIOD_PRICES_REQUEST]: (state) => {
    return {
      ...state,
      requestPending: true
    }
  },
  [GET_SERVICE_PERIOD_PRICES_SUCCESS]: (state, action) => {
    return {
      ...state,
      requestPending: false,
      servicePeriodPrices: action.payload
    }
  },
  [GET_SERVICE_PERIOD_PRICES_ERROR]: (state, action) => {
    return {
      ...state,
      requestPending: false,
      error: action.error
    }
  }
})

// ------------------------------------
// Constants
// ------------------------------------
export const GET_VENDOR_SERVICES_REQUEST = 'GET_VENDOR_SERVICES_REQUEST'
export const GET_VENDOR_SERVICES_SUCCESS = 'GET_VENDOR_SERVICES_SUCCESS'
export const GET_VENDOR_SERVICES_ERROR = 'GET_VENDOR_SERVICES_ERROR'

// ------------------------------------
// Actions
// ------------------------------------
function getVendorServicesRequest() {
  return {
    type: GET_VENDOR_SERVICES_REQUEST
  }
}

function getVendorServicesSuccess(vendorServices) {
  return {
    type: GET_VENDOR_SERVICES_SUCCESS,
    payload: vendorServices
  }
}

function getVendorServicesError(error) {
  return {
    type: GET_VENDOR_SERVICES_ERROR,
    error
  }
}

export const getVendorServicesByPacketId = (args) => {
  return (dispatch) => {
    return new Promise((resolve, reject) => {
      dispatch(getVendorServicesRequest())
      api.getVendorServicesByPacketId(args)
        .then(vendorServices => {
          dispatch(getVendorServicesSuccess(vendorServices))
        })
        .catch(error => {
          dispatch(getVendorServicesError(error))
        })
    })
  }
}


// ------------------------------------
// Action Handlers
// ------------------------------------
Object.assign(ACTION_HANDLERS, {
  [GET_VENDOR_SERVICES_REQUEST]: (state) => {
    return {
      ...state,
      requestPendingVendorServices: true
    }
  },
  [GET_VENDOR_SERVICES_SUCCESS]: (state, action) => {
    return {
      ...state,
      requestPendingVendorServices: false,
      selectedVendorServices: action.payload.vendorServices
    }
  },
  [GET_VENDOR_SERVICES_ERROR]: (state, action) => {
    return {
      ...state,
      requestPendingVendorServices: false,
      error: action.error
    }
  }
})

export const CALCULATE_DISCOUNT_REQUEST = 'CALCULATE_DISCOUNT_REQUEST'
export const CALCULATE_DISCOUNT_SUCCESS = 'CALCULATE_DISCOUNT_SUCCESS'
export const CALCULATE_DISCOUNT_ERROR = 'CALCULATE_DISCOUNT_ERROR'

// ------------------------------------
// Actions
// ------------------------------------
function calculateDiscountRequest() {
  return {
    type: CALCULATE_DISCOUNT_REQUEST
  }
}

function calculateDiscountSuccess(payload) {
  return {
    type: CALCULATE_DISCOUNT_SUCCESS,
    payload
  }
}

function calculateDiscountError(error) {
  return {
    type: CALCULATE_DISCOUNT_ERROR,
    error
  }
}

export const calculateDiscount = (args) => {
  return (dispatch) => {
    return new Promise((resolve, reject) => {
      dispatch(calculateDiscountRequest())
      api.calculateDiscount(args)
        .then(result => {
          dispatch(calculateDiscountSuccess(result))
        })
        .catch(error => {
          dispatch(calculateDiscountError(error))
        })
    })
  }
}


// ------------------------------------
// Action Handlers
// ------------------------------------
Object.assign(ACTION_HANDLERS, {
  [CALCULATE_DISCOUNT_REQUEST]: (state) => {
    return {
      ...state,
      requestPending: true,
      couponMessage: undefined
    }
  },
  [CALCULATE_DISCOUNT_SUCCESS]: (state, action) => {
    return {
      ...state,
      requestPending: false,
      calculatedDiscountResult: action.payload
    }
  },
  [CALCULATE_DISCOUNT_ERROR]: (state, action) => {
    return {
      ...state,
      requestPending: false,
      error: action.error
    }
  }
})


export const ADD_SERVICES_REQUEST = 'ADD_SERVICES_REQUEST'
export const ADD_SERVICES_SUCCESS = 'ADD_SERVICES_SUCCESS'
export const ADD_SERVICES_ERROR = 'ADD_SERVICES_ERROR'

// ------------------------------------
// Actions
// ------------------------------------
function addServicesRequest() {
  return {
    type: ADD_SERVICES_REQUEST
  }
}

function addServicesSuccess(payload) {
  return {
    type: ADD_SERVICES_SUCCESS,
    payload
  }
}

function addServicesError(error) {
  return {
    type: ADD_SERVICES_ERROR,
    error
  }
}

export const addServices = (args) => {
  return (dispatch) => {
    return new Promise((resolve, reject) => {
      dispatch(addServicesRequest())
      api.addServices(args)
        .then(result => {
          dispatch(addServicesSuccess({
            result,
            notify: true,
            type: 'success',
            message: ["##successfullyAdded"]
          }))
          hashHistory.replace('/services')
        })
        .catch(error => {
          dispatch(addServicesError({
            error,
            notify: true,
            type: 'error',
            message: (error.data && error.data.errorList && error.data.errorList.length > 0) ? error.data.errorList : ['##unhandledError']
          }))
        })
    })
  }
}


// ------------------------------------
// Action Handlers
// ------------------------------------
Object.assign(ACTION_HANDLERS, {
  [ADD_SERVICES_REQUEST]: (state) => {
    return {
      ...state,
      requestPending: true
    }
  },
  [ADD_SERVICES_SUCCESS]: (state, action) => {
    // let newState = Object.assign({}, state)
    // let newServices = newState.servicePackets 
    //   ? newState.servicePackets.concat(action.payload.result.vendorServicePacket)
    //   : [].concat(action.payload.result.vendorServicePacket)

    return {
      ...state,
      requestPending: false
      // selectedVendorServices
    }
  },
  [ADD_SERVICES_ERROR]: (state, action) => {
    return {
      ...state,
      requestPending: false,
      error: action.error.error
    }
  }
})

export const UPDATE_VENDOR_SERVICE_REQUEST = 'UPDATE_VENDOR_SERVICE_REQUEST'
export const UPDATE_VENDOR_SERVICE_SUCCESS = 'UPDATE_VENDOR_SERVICE_SUCCESS'
export const UPDATE_VENDOR_SERVICE_ERROR = 'UPDATE_VENDOR_SERVICE_ERROR'

// ------------------------------------
// Actions
// ------------------------------------
function updateVendorServiceRequest() {
  return {
    type: UPDATE_VENDOR_SERVICE_REQUEST
  }
}

function updateVendorServiceSuccess(payload) {
  return {
    type: UPDATE_VENDOR_SERVICE_SUCCESS,
    payload
  }
}

function updateVendorServiceError(error) {
  return {
    type: UPDATE_VENDOR_SERVICE_ERROR,
    error
  }
}

export const updateVendorService = (args) => {
  return (dispatch) => {
    return new Promise((resolve, reject) => {
      dispatch(updateVendorServiceRequest())
      api.updateVendorService(args)
        .then(result => {
          dispatch(updateVendorServiceSuccess({
            result,
            notify: true,
            type: 'success',
            message: ['##successfullyUpdated']
          }))
          // hashHistory.replace('/services')
        })
        .catch(error => {
          console.log('niye lan niye?', error)
          dispatch(updateVendorServiceError({
            error,
            notify: true,
            type: 'error',
            message: (error.data && error.data.errorList && error.data.errorList.length > 0) ? error.data.errorList : ['##unhandledError']
          }))
        })
    })
  }
}


// ------------------------------------
// Action Handlers
// ------------------------------------
Object.assign(ACTION_HANDLERS, {
  [UPDATE_VENDOR_SERVICE_REQUEST]: (state) => {
    return {
      ...state,
      requestPending: true
    }
  },
  [UPDATE_VENDOR_SERVICE_SUCCESS]: (state, action) => {
    // let some ={}
    // if(state.selectedVendorServices) {
    //   let index = state.selectedVendorServices.findIndex(x => x.id === action.payload.result.vendorService.id)
    //   some = state.selectedVendorServices.map((item, key) => {
    //     if (item.id === action.payload.result.vendorService.id) {
    //       item = action.payload.result.vendorService
    //     }
    //     return item
    //   })
    // }
    // return {
    //   ...state,
    //   requestPending: false,
    //   selectedVendorServices: some
    // }
    let vendorService = {}
    let newVendorService = Object.assign(vendorService, action.payload.result.vendorService)
    console.log('asdfasdf new vendorService', vendorService)
    newVendorService.images = action.payload.result.vendorService.images
    return {
      ...state,
      vendorService
    }
  },
  [UPDATE_VENDOR_SERVICE_ERROR]: (state, action) => {
    return {
      ...state,
      requestPending: false,
      error: action.error.error
    }
  }
})

export const SET_SELECTED_SERVICES = 'SET_SELECTED_SERVICES'
export const RESET_SELECTED_SERVICES = 'RESET_SELECTED_SERVICES'
export const DELETE_SELECTED_SERVICES = 'DELETE_SELECTED_SERVICES'
export const SELECT_PACKET = 'SELECT_PACKET'

export const setSelectedServices = (props) => {
  return dispatch => {
    return new Promise((resolve, reject) => {
      dispatch({
        type: SET_SELECTED_SERVICES,
        payload: props
      })
    })
  }
}

export const resetSelectedServices = (props) => {
  return dispatch => {
    return new Promise((resolve, reject) => {
      dispatch({
        type: RESET_SELECTED_SERVICES
      })
    })
  }
}

export const deleteSelectedServices = (props) => {
  return dispatch => {
    return new Promise((resolve, reject) => {
      dispatch({
        type: DELETE_SELECTED_SERVICES,
        payload: props
      })
    })
  }
}
export const selectPacket = (args) => {
  return dispatch => {
    return new Promise((resolve, reject) => {
      dispatch({
        type: SELECT_PACKET,
        payload: args
      })
    })
  }
}


Object.assign(ACTION_HANDLERS, {
  [SET_SELECTED_SERVICES]: (state, action) => {
    return {
      ...state,
      mainSelectedServices: action.payload
    }
  },
  [RESET_SELECTED_SERVICES]: (state, action) => {
    return {
      ...state,
      mainSelectedServices: undefined,
      calculatedDiscountResult: undefined,
      couponMessage: undefined
    }
  },
  [DELETE_SELECTED_SERVICES]: (state, action) => {
    let deleted = state.mainSelectedServices.filter(item => {
      return item.Id !== action.payload
    })
    return {
      ...state,
      mainSelectedServices: deleted
    }
  },
  [SELECT_PACKET]: (state, action) => {
    return {
      ...state,
      selectedPacketName: action.payload
    }
  }
})

export const GET_VENDOR_SERVICE_BY_ID_REQUEST = 'GET_VENDOR_SERVICE_BY_ID_REQUEST'
export const GET_VENDOR_SERVICE_BY_ID_SUCCESS = 'GET_VENDOR_SERVICE_BY_ID_SUCCESS'
export const GET_VENDOR_SERVICE_BY_ID_ERROR = 'GET_VENDOR_SERVICE_BY_ID_ERROR'

export const getVendorServiceById = (args) => {
  return dispatch => {
    return new Promise((resolve, reject) => {
      dispatch({
        type: GET_VENDOR_SERVICE_BY_ID_REQUEST
      })
      api.getVendorServiceById(args)
        .then(vendorService => dispatch({
          type: GET_VENDOR_SERVICE_BY_ID_SUCCESS,
          payload: vendorService
        }))
        .catch(error => {
          dispatch({
            type: GET_VENDOR_SERVICE_BY_ID_ERROR,
            error
          })
        })
    })
  }
}

Object.assign(ACTION_HANDLERS, {
  [GET_VENDOR_SERVICE_BY_ID_REQUEST]: (state, action) => {
    return {
      ...state,
      vendorService: undefined
    }
  },
  [GET_VENDOR_SERVICE_BY_ID_SUCCESS]: (state, action) => {
    return {
      ...state,
      vendorService: action.payload.vendorService
    }
  },
  [GET_VENDOR_SERVICE_BY_ID_ERROR]: (state, action) => {
    return {
      ...state,
      error: action.error
    }
  }
})

export const UPLOAD_VENDOR_SERVICE_IMAGES_REQUEST = 'UPLOAD_VENDOR_SERVICE_IMAGES_REQUEST'
export const UPLOAD_VENDOR_SERVICE_IMAGES_SUCCESS = 'UPLOAD_VENDOR_SERVICE_IMAGES_SUCCESS'
export const UPLOAD_VENDOR_SERVICE_IMAGES_ERROR = 'UPLOAD_VENDOR_SERVICE_IMAGES_ERROR'

export const uploadVendorServiceImages = (args) => {
  return dispatch => {
    return new Promise((resolve, reject) => {
      dispatch({
        type: UPLOAD_VENDOR_SERVICE_IMAGES_REQUEST
      })
      console.log('asrgarg', args)
      api.uploadVendorServiceImages(args)
        .then(output => dispatch({
          type: UPLOAD_VENDOR_SERVICE_IMAGES_SUCCESS,
          payload: output
        }))
        .catch(error => {
          console.log('EROOOOOR', error)
          dispatch({
            type: UPLOAD_VENDOR_SERVICE_IMAGES_ERROR,
            error,
            failedImages: error.data && error.data.output && error.data.output.failedImages
          })
        })
    })
  }
}

Object.assign(ACTION_HANDLERS, {
  [UPLOAD_VENDOR_SERVICE_IMAGES_REQUEST]: (state, action) => {
    return {
      ...state
    }
  },
  [UPLOAD_VENDOR_SERVICE_IMAGES_SUCCESS]: (state, action) => {
    console.log('ACTION AND STATE', action, state)
    const vendorService = state.vendorService
    const images = (vendorService.images
      && vendorService.images.length > 0)
      ?  action.payload.images.concat(vendorService.images)
      : [].concat(action.payload.images);

    const newObject = Object.assign({}, vendorService, { images })
    return {
      ...state,
      vendorService: newObject
    }
  },
  [UPLOAD_VENDOR_SERVICE_IMAGES_ERROR]: (state, action) => {
    return {
      ...state,
      error: action.error,
      failedImages: action.failedImages
    }
  }
})

export const DELETE_VENDOR_SERVICE_IMAGE_REQUEST = 'DELETE_VENDOR_SERVICE_IMAGE_REQUEST'
export const DELETE_VENDOR_SERVICE_IMAGE_SUCCESS = 'DELETE_VENDOR_SERVICE_IMAGE_SUCCESS'
export const DELETE_VENDOR_SERVICE_IMAGE_ERROR = 'DELETE_VENDOR_SERVICE_IMAGE_ERROR'

export const deleteVendorServiceImage = (args) => {
  return dispatch => {
    return new Promise((resolve, reject) => {
      dispatch({
        type: DELETE_VENDOR_SERVICE_IMAGE_REQUEST
      })
      api.deleteVendorServiceImage(args)
      .then(response => {
        dispatch({
          type: DELETE_VENDOR_SERVICE_IMAGE_SUCCESS,
          payload: Object.assign(response, args)
        })
      })
      .catch((error) => {
        dispatch({
          type: DELETE_VENDOR_SERVICE_IMAGE_ERROR,
          error
        })
      })
    })
  }
}

Object.assign(ACTION_HANDLERS, {
  [DELETE_VENDOR_SERVICE_IMAGE_REQUEST]: (state, action) => {
    return {
      ...state
    }
  },
  [DELETE_VENDOR_SERVICE_IMAGE_SUCCESS]: (state, action) => {
    console.log('ACTION AND STATE', action, state)
    const vendorService = state.vendorService
    const images = (vendorService.images
      && vendorService.images.length > 0)
      ? vendorService.images.filter(image => {
        return image.id !== action.payload.id
      })
      : [];

    const newObject = Object.assign({}, vendorService, { images })
    return {
      ...state,
      vendorService: newObject
    }
  },
  [DELETE_VENDOR_SERVICE_IMAGE_ERROR]: (state, action) => {
    return {
      ...state,
      error: action.error
    }
  }
})

// ------------------------------------
// Reducer
// --------------------
export default function serviceReducer(state = initialState, action) {
  const handler = ACTION_HANDLERS[action.type]

  return handler ? handler(state, action) : state
}