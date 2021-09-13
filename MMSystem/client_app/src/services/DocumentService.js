import axios from 'axios';

export default {

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