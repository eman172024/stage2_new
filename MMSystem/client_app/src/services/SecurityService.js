import axios from 'axios';

export default {
    Login(Login) {
        return axios.post(`http://172.16.0.12:82/api/Auth/LoginUser`, Login)
    },
    Logout() {
        return axios.post('http://172.16.0.12:82/api/Security/Logout');
    },
    CheckLogin() {
        return axios.get('http://172.16.0.12:82/api/Security/CheckLogin');
    },
}