import http from '../customAxios'
import { urlConfig } from '../../config/'

const notificationService = {
    getBookingNotifications: (args) => {
        return new Promise((resolve, reject) => {
            http().get(urlConfig.getServiceAddress(`notifications/booking/vendor?skip=${(args && args.skip) ? args.skip : 0}&isNew=${(args && args.isNew) ? args.isNew : 0}&lastNotificationId=${(args && args.lastNotificationId) ? args.lastNotificationId : 0}`))
                .then(response => {
                    console.log('asdasd', response)
                    response.data.isSuccess
                        ? resolve(response.data.output)
                        : reject(response)
                })
                .catch(error => {
                    console.log('asdasd', error)
                    reject(error)
                })
        })
    },
    updateBookingNotification: (args) => {
        return new Promise((resolve, reject) => {
            http().put(urlConfig.getServiceAddress('notifications/booking'), args)
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

export default notificationService