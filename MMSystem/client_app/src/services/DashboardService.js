import axios from 'axios';

export default {

    // GetCategories(pageNo, pageSize) {
    //     return axios.get(`/api/Home/GetCategories?pageNo=${pageNo}&pageSize=${pageSize}`)
    // },


    NumbersOfReports() {
        return axios.get(`/Dashboard/Numbers_Of_Reports`)
    },

    LastFiveTransactions() {
        return axios.get(`/Dashboard/LastFiveTransactions`)
    },

}