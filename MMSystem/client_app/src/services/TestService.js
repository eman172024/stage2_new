import axios from 'axios';
export default {


    GetDocmentsDetails(mailId) {
        return axios.get(`http://172.16.0.12:82/api/Documents/GetDocmentsDetails`, {
            params: {
                mailId: mailId
            }
        });
    },


    test() {
        return axios.get('http://172.16.0.12:82/api/WeatherForecast/test');
    },



}