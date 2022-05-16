import axios from 'axios';

export default {

    NumbersOfReports(id) {
        return axios.get(`http://172.16.0.12:82/api/DashBords/GetTotal?ManagementId=${id}`);
    },
    
}