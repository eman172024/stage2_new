import axios from 'axios';

export default {

    LastMails() {
        return axios.get(`api/Mails/GetLastMails`);
    },

    NumbersOfReports() {
        return axios.get(`api/Service/GetAllClassFication`);
    },

    // NumbersOfReports() {
    //     return axios.get(`/Dashboard/Numbers_Of_Reports`)
    // },








}