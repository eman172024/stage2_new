import axios from 'axios';

export default {

    GetSectors(type) {
        return axios.get(`/api/WeatherForecast/GetSectors/${type}`)
       // return axios.get(`http://mail:82/api/WeatherForecast/GetSectors/${type}`)
    },

    GetSides(id) {
        return axios.get(`/api/WeatherForecast/GetSides/${id}`)
      //  return axios.get(`http://mail:82/api/WeatherForecast/GetSides/${id}`)
     },

}