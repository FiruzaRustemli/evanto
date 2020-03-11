import axios from 'axios'
import { oauth } from '../config'

const http = () => {
  return axios.create({
    headers: {
      Authorization: `Bearer ${localStorage.getItem(oauth.localStorageTokenKey)}`
    }
  })
}

export default http