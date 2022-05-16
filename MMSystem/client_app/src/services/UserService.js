import axios from 'axios';

export default {

    AddUser(userInfo) {
        console.log("SSSSSSSSSSSSSS")
        return axios.post(`http://172.16.0.12:82/api/Users/AddUser`, userInfo)
    },

    GetUsers() {
        return axios.get(`http://172.16.0.12:82/api/Users/GetUsers`)
    },

    GetUserForEdit(UserId) {
        return axios.get(`http://172.16.0.12:82/api/Users/GetUserForEdit?UserId=${UserId}`);
    },

    DeleteUser(UserId) {
        return axios.delete(`http://172.16.0.12:82/api/Users/DeleteUser?UserId=${UserId}`);
    },


    EditUser(userInfo) {
        return axios.put(`http://172.16.0.12:82/api/Users/EditUser`, userInfo)
    },

    GetUsersByName() {
        // UserName
        console.log("ddddddddddddd")
        // return axios.get(`/api/Administrator/GetByUserName?username=${UserName}`);
    },


}