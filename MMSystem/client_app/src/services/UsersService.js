import axios from 'axios';

export default {

    

    GetUsersByName(UserName) {
        return axios.get(`/api/Administrator/GetByUserName?username=${UserName}`);
      //  return axios.get(`http://mail:82/api/Administrator/GetByUserName?username=${UserName}`);
    },

    StopUser(StopActive) {
        return axios.put(`/api/Administrator/Delete/`,StopActive)
      //  return axios.put(`http://mail:82/api/Administrator/Delete/`, StopActive)
     },

    GetAllRoles1() {

    
        return axios.get(`/api/Role/GetAll`);
      //  return axios.get(`http://mail:82/api/Role/GetAll`);
     },

    GetAllRoles() {

        
        return axios.get(`/api/Role/GetAll`);
     //  return axios.get(`http://mail:82/api/Role/GetAll`);
   },
    
    Add_user(user){
                            
        return axios.post(`/api/Administrator/Add`,user);
     //   return axios.post(`http://mail:82/api/Administrator/Add`, user);

    },

    Edite_user(user){
                            
        return axios.put(`/api/Administrator/Update`,user);
     //   return axios.put(`http://mail:82/api/Administrator/Update`, user);

    },

    GetUserById(id){

        return axios.get(`/api/Administrator/Get/${id}`);
      //  return axios.get(`http://mail:82/api/Administrator/Get/${id}`);

    },

    
}