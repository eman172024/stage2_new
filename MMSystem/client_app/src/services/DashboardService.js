import axios from 'axios';

export default {


    NumbersOfReports() {
        return axios.get(`api/Service/GetAllClassFication`);
    },

    // NumbersOfReports() {
    //     return axios.get(`/Dashboard/Numbers_Of_Reports`)
    // },








}