import axios from 'axios';

export default {

    GetAllDocN(mail_id, page_number,department_id) {
        return axios.get(`/api/Resources/GetAllDoc?mail_id=${mail_id}&page_number=${page_number}&department_id=${department_id}`);
      //  return axios.get(`http://mail:82/api/Resources/GetAllDoc?mail_id=${mail_id}&page_number=${page_number}`);
    },


    GetResources_ById(id, page_number,department_id) {
        return axios.get(`/api/Reply/GetResources_ById?id=${id}&page_number=${page_number}`);
     //  return axios.get(`http://mail:82/api/Reply/GetResources_ById?id=${id}&page_number=${page_number}`);
    },





    AddDocument(newDocuments) {
        return axios.post(`/api/Documents/AddDocuments`, newDocuments)
     //   return axios.post(`http://mail:82/api/Documents/AddDocuments`, newDocuments)

    },

    GetDocmentForMail(mailId, marginalized) {
        return axios.get(`/api/Documents/GetDocments/`, {
     //   return axios.get(`http://mail:82/api/Documents/GetDocments/`, {
            params: {
                mailId: mailId,
                marginalized: marginalized
            }
        })
    },

    DeleteDocument(documentId) {
        return axios.delete(`/api/Documents/DeleteDocument/`, {
   //   return axios.delete(`http://mail:82/api/Documents/DeleteDocument/`, {
            params: {
                documentId: documentId
            }
        })
    },






}