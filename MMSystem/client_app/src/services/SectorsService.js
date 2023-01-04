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


     add_sector(sector) {
        return axios.post(`/api/ExtrmalSection/Add`,sector)
       
    },

    edit_sector(sector) {
        return axios.put(`/api/ExtrmalSection/Update`,sector)
       
    },

    stop_sector(id) {
        return axios.put(`/api/ExtrmalSection/Delete?id=${id}`)
       
    },

    GetSide(id) {
        return axios.get(`/api/ExtrmalSection/GetSide?id=${id}`)
      
     },

    

}