import axios from 'axios';

export default {

    AllClassifications() {
        return axios.get(`/api/Service/GetAllClassification`);
    },

    AllMeasures() {
        return axios.get(`/api/Service/GetAllMeasures`);
    },

    AllDepartments() {
        return axios.get(`/api/WeatherForecast/GetAllDepartments`);
    },

    SaveMail(info) {
        return axios.post(`/api/Mail/AddMail`, info)
    },

    SendMail(mailId) {
        return axios.put(`/api/Mail/Send?mailid=${mailId}`)
    },



    // UploadMail(id, resourse) {
    //     return axios.post(`/api/Mail/Uplode`, {
    //         params: {
    //             id: id,
    //             resourse: resourse,
    //         }
    //     })
    // },



    UploadImagesMail(id, list) {
        return axios.post(`/api/Mail/Uplode`, { mail_id: Number(id), list: list, })
    },

    DeleteMail(mailId) {
        return axios.delete(`/api/Mail/Delete/${mailId}`);
    },

    // GetMailById(mailId) {
    //     return axios.get(`/api/Mail/GetMailById/${mailId}`);
    // },

    GetMailById(id, type) {
        return axios.get(`/api/Mail/GetMailById?id=${id}&type=${type}`);
    },

    DeleteDocument(id) {
        return axios.delete(`/api/Mail/DeleteDocument/${id}`)
    },

    UpdateMail(Mail) {
        return axios.put(`/api/Mail/UpdateMail`, Mail)
    },



































    GetMails(filter, role) {
        return axios.get(`/api/Mails/GetMails`, {
            params: {
                pageSize: filter.pageSize,
                pageNo: filter.pageNo,
                role: role,
            }
        })
    },





    ReplyMail(ReplyMail) {
        return axios.post(`/api/Documents/ReplyMail`, ReplyMail)
    },





    GetReports() {
        return axios.get(`/api/Reports/GetReports`);
    },


    BossSee(mailId) {
        return axios.put(`/api/Mails/BossSee?mailId=${mailId}`);
    },

    EmploySee(mailId) {
        return axios.put(`/api/Mails/EmploySee?mailId=${mailId}`);
    },

    GetSearchList(searchTerm) {
        return axios.get(`/api/Mails/GetSearchList`, {
            params: {
                searchTerm: searchTerm
            }
        });
    },



}