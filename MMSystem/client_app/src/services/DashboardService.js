import axios from 'axios';

export default {

    NumbersOfReports(id) {
        return axios.get(`/api/DashBords/GetTotal?ManagementId=${id}`);
        
     //   return axios.get(`http://mail:82/api/DashBords/GetTotal?ManagementId=${id}`);
    },
    
}