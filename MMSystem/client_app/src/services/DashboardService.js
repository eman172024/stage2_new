import axios from 'axios';

export default {

    LastMails(id) {
        return axios.get(`api/Mail/GetLastMails?department_Id=${id}`);
    },

    NumbersOfReports(id) {
        return axios.get(`api/DashBords/GetTotal?ManagementId=${id}`);
    },

    // NumbersOfReports() {
    //     return axios.get(`/Dashboard/Numbers_Of_Reports`)
    // },








}