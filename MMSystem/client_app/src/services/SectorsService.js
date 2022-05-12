import axios from 'axios';

export default {

    GetSectors(type) {
        return axios.get(`http://172.16.0.12:82/api/WeatherForecast/GetSectors/${type}`)
    },

    GetSides(id) {
        return axios.get(`http://172.16.0.12:82/api/WeatherForecast/GetSides/${id}`)
    },

}