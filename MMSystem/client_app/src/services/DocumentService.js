import axios from 'axios';

export default {


    show_doc_for_order(id) {
        return axios.get(`/api/Resources/GetSingleImage?id=${id}`)
     //   return axios.post(`http://mail:82/api/Documents/AddDocuments`, newDocuments)

    },

    save_new_order(list) {
        return axios.put(`/api/Resources/update_mail_Resources_order`, list)
     //   return axios.post(`http://mail:82/api/Documents/AddDocuments`, newDocuments)

    },

    get_ordering_image(mail_id) {
        return axios.get(`/api/Resources/Get_Mail_Resourcescs_orders?mail_id=${mail_id}`);
      //  return axios.get(`http://mail:82/api/Resources/GetAllDoc?mail_id=${mail_id}&page_number=${page_number}`);
    },



    GetAllDocN(mail_id, page_number) {
        return axios.get(`/api/Resources/GetAllDoc?mail_id=${mail_id}&page_number=${page_number}`);
      //  return axios.get(`http://mail:82/api/Resources/GetAllDoc?mail_id=${mail_id}&page_number=${page_number}`);
    },


    GetResources_ById(id, page_number) {
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