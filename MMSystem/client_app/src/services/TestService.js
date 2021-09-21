import axios from 'axios';
export default {


    GetDocmentsDetails(mailId) {
        return axios.get(`/api/Documents/GetDocmentsDetails`, {
            params: {
                mailId: mailId
            }
        });
    },


    test() {
        return axios.get('/api/WeatherForecast/test');
    },



}