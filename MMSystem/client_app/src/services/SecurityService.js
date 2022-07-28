import axios from 'axios';

export default {
    Login(Login) {
        return axios.post(`/api/Auth/LoginUser`, Login)
    },
    Logout() {
        return axios.post('/api/Security/Logout');
    },
    CheckLogin() {
        return axios.get('/api/Security/CheckLogin');
    },
}