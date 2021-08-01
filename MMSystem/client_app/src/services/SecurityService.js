import axios from 'axios';

export default {
    //-------------------   Security -------------------//
    LoginFun(login) {
        return axios.post('/Auth/LoginUser', login);
    },

    Logout() {
        return axios.delete('/Auth/Logout');
    },

    CheckLogin() {
        return axios.get('/Auth/CheckLogin');
    },

}