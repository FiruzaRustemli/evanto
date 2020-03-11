import StartSignalR from '../signalR/start'
import { makeRootReducer } from '../store/reducers'

const logger = store => next => action => {
    if (action.type) {
        if (action.type.includes('GET_VENDOR_DETAILS_SUCCESS') && action.connect) {
            StartSignalR(store, action.payload.vendor.userId,
            (success) => {
            },
            (error) => {
                // TODO: logout
            })
        } 
        else if (action.type.includes('LOG_OUT'))
        {
            window.$.connection.hub.stop()
        }
    }
    return next(action)
}

export default logger