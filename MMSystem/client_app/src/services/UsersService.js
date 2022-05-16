import axios from 'axios';

export default {

    

    GetUsersByName(UserName) {
        return axios.get(`http://172.16.0.12:82/api/Administrator/GetByUserName?username=${UserName}`);
    },

    StopUser(StopActive) {
        return axios.put(`http://172.16.0.12:82/api/Administrator/Delete/`,StopActive)
    },

    GetAllRoles1() {

    
        return axios.get(`http://172.16.0.12:82/api/Role/GetAll`);
    },

    GetAllRoles() {

        
        return axios.get(`http://172.16.0.12:82/api/Role/GetAll`);
    },
    
    Add_user(user){
                            
        return axios.post(`http://172.16.0.12:82/api/Administrator/Add`,user);

    },

    Edite_user(user){
                            
        return axios.put(`http://172.16.0.12:82/api/Administrator/Update`,user);

    },

    GetUserById(id){

        return axios.get(`http://172.16.0.12:82/api/Administrator/Get/${id}`);

    },

    
}