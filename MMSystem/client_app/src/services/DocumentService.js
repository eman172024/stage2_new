import axios from 'axios';

export default {

    GetAllDocN(mail_id, page_number) {
        return axios.get(`/api/Resources/GetAllDoc?mail_id=${mail_id}&page_number=${page_number}`);
    },


    AddDocument(newDocuments) {
        return axios.post(`/api/Documents/AddDocuments`, newDocuments)


    },

    GetDocmentForMail(mailId, marginalized) {
        return axios.get(`/api/Documents/GetDocments/`, {
            params: {
                mailId: mailId,
                marginalized: marginalized
            }
        })
    },

    DeleteDocument(documentId) {
        return axios.delete(`/api/Documents/DeleteDocument/`, {
            params: {
                documentId: documentId
            }
        })
    },






}