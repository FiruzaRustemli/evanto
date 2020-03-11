import http from '../customAxios'
import { urlConfig } from '../../config/'

const serviceApi = {
    getVendorServicePackets: (args) => {
        return new Promise((resolve, reject) => {
            http().post(urlConfig.getServiceAddress('services/vendor/servicePacket'), args)
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
    getVendorServicesByPacketId: (args) => {
        return new Promise((resolve, reject) => {
            http().get(urlConfig.getServiceAddress(`services/vendor/services?VendorServicePacketId=${args.VendorServicePacketId}`))
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
    changeServiceStatus: (args) => {
        return new Promise((resolve, reject) => {
            http().post(urlConfig.getServiceAddress('services/vendor/services/changeStatus'), args)
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
    getServicePeriodPrices: (args) => {
        return new Promise((resolve, reject) => {
            http().get(urlConfig.getServiceAddress('services/vendor/servicePeriodPrice'))
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
    calculateDiscount: (args) => {
        return new Promise((resolve, reject) => {
            http().post(urlConfig.getServiceAddress('promos/vendor/total'), args)
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
    addServices: (args) => {
        return new Promise((resolve, reject) => {
            http().post(urlConfig.getServiceAddress('services/vendor/services'), args)
                .then(response => {
                    response.data.isSuccess && response.data.output.isCreated
                        ? resolve(response.data.output)
                        : reject(response)
                })
                .catch(error => {
                    reject(error)
                })
        })
    },
    updateVendorService: (args) => {
        return new Promise((resolve, reject) => {
            http().put(urlConfig.getServiceAddress('vendors/vendorServices'), args)
                .then(response => {
                    console.log('REŞO', response)
                    response.data.isSuccess
                        ? resolve(response.data.output)
                        : reject(response)
                })
                .catch(error => {
                    console.log('ERŞO', error)
                    reject(error)
                })
        })
    },
    getVendorServiceById: (args) => {
        return new Promise((resolve, reject) => {
            http().get(urlConfig.getServiceAddress(`services/vendor/vendorService?id=${args.id}`))
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
    uploadVendorServiceImages: (args) => {
        return new Promise((resolve, reject) => {
            http().post(urlConfig.getServiceAddress(`files/images/vendorService`), args)
                .then(response => {
                    console.log('RESPONSE', response)
                    response.data.isSuccess
                        ? resolve(response.data.output)
                        : reject(response)
                })
                .catch(error => {
                    console.log('ERROR', error)
                    reject(error)
                })
        })
    },
    deleteVendorServiceImage: (args) => {
        return new Promise((resolve, reject) => {
            http().delete(urlConfig.getServiceAddress(`files/delete?id=${args && args.id}`))
                .then(response => {
                    console.log('RESPONSE', response)
                    response.data.isSuccess
                        ? resolve(response.data.output)
                        : reject(response)
                })
                .catch(error => {
                    console.log('ERROR', error)
                    reject(error)
                })
        })
    }

}

export default serviceApi