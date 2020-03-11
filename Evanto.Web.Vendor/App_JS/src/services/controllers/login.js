import axios from 'axios'
import qs from 'qs'
import $ from 'jquery'
import { urlConfig, oauth } from '../../config/'

const loginApi = {
    login: (args) => {
        const loginArgs = {
            username: args.username,
            password: args.password,
            grant_type: oauth.grant_type,
            client_id: oauth.client_id,
            client_secret: oauth.client_secret
        }
        
        return new Promise((resolve, reject) => {
            $.ajax({
                url: urlConfig.getLoginAddress(),
                data: loginArgs,
                type: 'POST',
                headers: {
                    'content-type': 'application/x-www-form-urlencoded'
                }
            })
                .done(response => {
                    resolve(response)
                })
                .fail(error => {
                    reject(error)
                })
        })
    }
}

export default loginApi