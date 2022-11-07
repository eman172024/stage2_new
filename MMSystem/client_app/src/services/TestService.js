import axios from 'axios';
export default {


    GetDocmentsDetails(mailId) {
        return axios.get(`/api/Documents/GetDocmentsDetails`, {
        //    return axios.get(`http://mail:82/api/Documents/GetDocmentsDetails`, {
            params: {
                mailId: mailId
            }
        });
    },


    test() {
        return axios.get('/api/WeatherForecast/test');
     //  return axios.get('http://mail:82/api/WeatherForecast/test');
    },



}