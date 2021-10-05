import axios from 'axios';

export default {

    LastMails() {
        return axios.get(`api/Mail/GetLastMails`);
    },

    NumbersOfReports(id) {
        return axios.get(`api/DashBords/GetTotal?ManagementId=${id}`);
    },

    // NumbersOfReports() {
    //     return axios.get(`/Dashboard/Numbers_Of_Reports`)
    // },








}