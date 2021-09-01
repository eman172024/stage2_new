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



    UploadMail(list) {
        return axios.post(`/api/Mail/Up`, { list: list, })
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

    GetMailById(mailId) {
        return axios.get(`/api/Mails/GetMailForEdit?mailId=${mailId}`);
    },

    DeleteMail(mailId) {
        return axios.delete(`/api/Mails/DeleteMail?mailId=${mailId}`);
    },

    ReplyMail(ReplyMail) {
        return axios.post(`/api/Documents/ReplyMail`, ReplyMail)
    },



    EditMail(mailInfo) {
        return axios.put(`/api/Mails/EditMail`, mailInfo)
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