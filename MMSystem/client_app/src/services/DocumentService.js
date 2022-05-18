import axios from 'axios';

export default {

    AddDocument(newDocuments) {
        return axios.post(`http://172.16.0.12:82/api/Documents/AddDocuments`, newDocuments)


    },

    GetDocmentForMail(mailId, marginalized) {
        return axios.get(`http://172.16.0.12:82/api/Documents/GetDocments/`, {
            params: {
                mailId: mailId,
                marginalized: marginalized
            }
        })
    },

    DeleteDocument(documentId) {
        return axios.delete(`http://172.16.0.12:82/api/Documents/DeleteDocument/`, {
            params: {
                documentId: documentId
            }
        })
    },






}