const urlConfig = {
    getServiceAddress: (url) => {
        // return `http://localhost:51676/api/v1/${url}`
        return `http://www.brono.az:8763/api/v1/${url}`
    },
    getLoginAddress: () => {
        // return `http://localhost:56487/oauth2/token`
        return `http://www.brono.az:8093/oauth2/token`
    },
    getCurrentProjectAddress: () => {
        // return `http://localhost:3006/`
        return `http://vendor.brono.az:8354/`
    },
    getSignalRUrl: () => {
        // return 'http://localhost:51676/signalr'
        return 'http://www.brono.az:8763/signalr'
    }
}

export default urlConfig
