import axios from 'axios';

export default {

    NumbersOfReports(id) {
        return axios.get(`api/DashBords/GetTotal?ManagementId=${id}`);
    },
    
}