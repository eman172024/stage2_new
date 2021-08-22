import axios from 'axios';

export default {

    AddMail(mailInfo) {
        return axios.post(`/api/Mails/AddMail`, mailInfo)
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

    SendMail(mailId) {
        return axios.put(`/api/Mails/EmploySender?mailId=${mailId}`)
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