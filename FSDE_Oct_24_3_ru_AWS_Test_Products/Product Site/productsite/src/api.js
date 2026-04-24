import axios from 'axios'

const api = axios.create({
    // baseURL: 'http://mogudasite-env.eba-exuziyet.eu-north-1.elasticbeanstalk.com/api',
    baseURL: 'http://localhost:5262/api',
})

export default api