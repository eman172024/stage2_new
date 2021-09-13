import axios from 'axios';

export default {

    AddUser(userInfo) {
        console.log("SSSSSSSSSSSSSS")
        return axios.post(`/api/Users/AddUser`, userInfo)
    },

    GetUsers() {
        return axios.get(`/api/Users/GetUsers`)
    },

    GetUserForEdit(UserId) {
        return axios.get(`/api/Users/GetUserForEdit?UserId=${UserId}`);
    },

    DeleteUser(UserId) {
        return axios.delete(`/api/Users/DeleteUser?UserId=${UserId}`);
    },


    EditUser(userInfo) {
        return axios.put(`/api/Users/EditUser`, userInfo)
    },

}