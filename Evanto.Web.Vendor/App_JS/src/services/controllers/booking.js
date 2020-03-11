import http from '../customAxios'
import { urlConfig } from '../../config/'

const bookingApi = {
    getBookingsByStatus: (args) => {
        return new Promise((resolve, reject) => {
            http().get(urlConfig.getServiceAddress(`bookings/vendor?StatusId=${args.statusId}&Date=${args.date}`))
                .then(response => {
                    console.log('BOOKINGS', response)
                    response.data.isSuccess
                        ? resolve(response.data.output)
                        : reject(response)
                })
                .catch(error => {
                    reject(error)
                })
        })
    },
    createBooking: (args) => {
        return new Promise((resolve, reject) => {
            args.DeadLine = args.BookDate //TODO
            http().post(urlConfig.getServiceAddress('bookings/vendor'), args)
                .then(response => {
                    response.data.isSuccess
                        ? resolve(response.data.output)
                        : reject(response)
                })
                .catch(error => {
                    reject(error)
                })
        })
    },
    updateBookingStatus: (args) => {
        return new Promise((resolve, reject) => {
            http().post(urlConfig.getServiceAddress('bookings/vendor/changeStatus'), args)
                .then(response => {
                    response.data.isSuccess
                        ? resolve(response.data.output)
                        : reject(response)
                })
                .catch(error => {
                    reject(error)
                })
        })
    },
    getRequestUserInfo: (args) => {
        return new Promise((resolve, reject) => {
            http().post(urlConfig.getServiceAddress('bookings/vendor/userInfo'), args)
                .then(response => {
                    console.log('RESPONSEESESE', response)
                    response.data.isSuccess
                        ? resolve(response.data.output)
                        : reject(response)
                })
                .catch(error => {
                    reject(error)
                })
        })
    },
    getActiveVendorServices: (args) => {
        return new Promise((resolve, reject) => {
            http().get(urlConfig.getServiceAddress('vendors/vendorServices'))
                .then(response => {
                    response.data.isSuccess
                        ? resolve(response.data.output)
                        : reject(response)
                })
                .catch(error => {
                    reject(error)
                })
        })
    }
}

export default bookingApi