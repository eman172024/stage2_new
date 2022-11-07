import axios from 'axios';

export default {
    Login(Login) {
        return axios.post(`/api/Auth/LoginUser`, Login)
      //  return axios.post(`http://mail:82/api/Auth/LoginUser`, Login)
    },
    Logout() {
        return axios.post('/api/Security/Logout');
     //  return axios.post('http://mail:82/api/Security/Logout');
     },
    CheckLogin() {
       return axios.get('/api/Security/CheckLogin');
     //   return axios.get('http://mail:82/api/Security/CheckLogin');
     },
}