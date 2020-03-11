import http from '../customAxios'
import { urlConfig } from '../../config/'

const accountApi = {
    getVendorDetails: (args) => {
        return new Promise((resolve, reject) => {
            http().get(urlConfig.getServiceAddress(`vendors/vendor`))
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

    updateContactInfo: (args) => {
        return new Promise((resolve, reject) => {
            http().post(urlConfig.getServiceAddress('vendors/vendor/info/contact'), args)
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
    updatePersonalInfo: (args) => {
        return new Promise((resolve, reject) => {
            http().post(urlConfig.getServiceAddress('vendors/vendor/info/basic'), args)
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
    uploadAvatar: (args) => {
        return new Promise((resolve, reject) => {
            http().post(urlConfig.getServiceAddress('files/avatar'), args)
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
    register: (args) => {
        const vendor = {
            name: args.name,
            userInput: {
                firstName: args.firstName,
                lastName: args.lastName,
                phone: args.phone,
                username: args.username,
                passwordString: args.passwordString,
                verificationTypeId: 1,
                genderId: 1
            }
        }

        return new Promise((resolve, reject) => {
            http().post(urlConfig.getServiceAddress('vendors/vendor'), vendor)
                .then(response => {
                    console.log('response', response)
                    response.data.isSuccess
                        ? resolve(response.data.output)
                        : reject(response)
                })
                .catch(error => {
                    console.log('error', error)
                    reject(error)
                })
        })
    },

    sendVerificationCode: (args) => {
        return new Promise((resolve, reject) => {
            http().post(urlConfig.getServiceAddress('users/account/verificationCode'))
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

    updateUserSettings: (args) => {
        return new Promise((resolve, reject) => {
            http().put(urlConfig.getServiceAddress('users/user/settings'), args)
                .then(response => {
                    response.data.isSuccess
                        ? resolve(response.data)
                        : reject(response)
                })
                .catch(error => {
                    reject(error)
                })
        })
    },
    verifyAccount: (args) => {
        return new Promise((resolve, reject) => {
            http().post(urlConfig.getServiceAddress('users/account/verify'), args)
            .then(response => {
                response.data.isSuccess
                    ? resolve(response.data)
                    : reject(response)
            })
            .catch(error => {
                reject(error)
            })
        })
    },
    sendCode: (args) => {
        return new Promise((resolve, reject) => {
            http().post(urlConfig.getServiceAddress('users/account/verificationCode'), args)
            .then(response => {
                response.data.isSuccess
                    ? resolve(response.data)
                    : reject(response)
            })
            .catch(error => {
                reject(error)
            })
        })
    },
    changePassword: (args) => {
        return new Promise((resolve, reject) => {
            http().put(urlConfig.getServiceAddress('users/account/changePassword'), args)
            .then(response => {
                response.data.isSuccess
                    ? resolve(response.data)
                    : reject(response)
            })
            .catch(error => {
                reject(error)
            })
        })
    },
}

export default accountApi