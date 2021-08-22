import axios from 'axios';

export default {
    Login(Login) {
        return axios.post(`/api/Security/Login`, Login)
    },
    Logout() {
        return axios.post('/api/Security/Logout');
    },
    CheckLogin() {
        return axios.get('/api/Security/CheckLogin');
    },
}