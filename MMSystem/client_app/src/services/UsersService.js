import axios from 'axios';

export default {

    

    GetUsersByName(UserName) {
        return axios.get(`/api/Administrator/GetByUserName?username=${UserName}`);
    },

    StopUser(id,CurrentUser) {
        return axios.put(`/api/Administrator/Delete/${id}/${CurrentUser}`)
    },

    GetAllRoles1() {

    
        return axios.get(`/api/Role/GetAll`);
    },

    GetAllRoles() {

        
        return axios.get(`/api/Role/GetAll`);
    },
    
    Add_user(user){
                            
        return axios.post(`/api/Administrator/Add`,user);

    },

    Edite_user(user){
                            
        return axios.put(`/api/Administrator/Update`,user);

    },

    GetUserById(id){

        return axios.get(`/api/Administrator/Get/${id}`);

    },

    
}