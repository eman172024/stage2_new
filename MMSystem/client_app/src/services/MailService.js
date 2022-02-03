import axios from 'axios';

export default {



    UpdateArchive(model) {
        return axios.put(`/api/Archive/Update`,model)
    },

    GetMailForArchives(page,pageSize,mail_number,date_time_of_day,date_time_from,department_id,side_id,mail_summary,MailType,Perent) {

        return axios.get(`/api/Archive/GetAll?page=${page}&pageSize=${pageSize}&mail_number=${mail_number}&date_time_of_day=${date_time_of_day}&date_time_from=${date_time_from}&department_id=${department_id}&side_id=${side_id}&mail_summary=${mail_summary}&MailType=${MailType}&Perent=${Perent}`);
    },



    Add_user(user){

        return axios.post(`/api/Administrator/Add`,user);

    },

    GetAllRoles() {

        return axios.get(`/api/Role/GetAll`);
    },

    AllClassifications() {
        return axios.get(`/api/Service/GetAllClassification`);
    },

    AllMeasures() {
        return axios.get(`/api/Service/GetAllMeasures`);
    },



    AllStateSent() {
        return axios.get(`/api/Mail/GetAllMailStateWithId?flag=1`);
    },
    AllStateInbox() {
        return axios.get(`/api/Mail/GetAllMailStateWithId?flag=2`);
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

    cancel_sending_to_department(mailId, department_id) {
        // return axios.delete(`/api/Mail/Delete` , { department_id: Number(mailId), userId: Number(userId), mail_id: Number(mail_id)});
        return axios.delete(`/api/Mail/DeleteMangament?mail_id=${mailId}&departmentId=${department_id}`);
        
    },





    DeleteMail(my_department_id, userId, mail_id) {
        // return axios.delete(`/api/Mail/Delete` , { department_id: Number(my_department_id), userId: Number(userId), mail_id: Number(mail_id)});
        return axios.delete(`/api/Mail/Delete?department_id=${my_department_id}&userId=${userId}&mail_id=${mail_id}`);
        
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


    GetUsersOfDepartment(id) {
        return axios.get(`/api/Administrator/GetByDepartmentId?department=${id}`);
    },





    inboxs(id, mailType, mangment_id, date_from, date_to, mail_id, summary, department_id, measure_id, classification_id, mail_case_id, page_num, page_size) {
        return axios.get(`/api/ExternalMails/GetIncomingMail?userid=${id}&mailNumType=${mailType}&mangment=${mangment_id}&date_from=${date_from}&date_to=${date_to}&mailnum=${mail_id}&summary=${summary}&Department_filter=${department_id}&Measure_filter=${measure_id}&Classfication=${classification_id}&mail_state=${mail_case_id}&page_num=${page_num}&page_size=${page_size}`);
        // return axios.get(`api/ExternalMails/GetIncomingMail?userid=1&mailNumType=1&mangment=2&pagenum=1&size=1`);  
    },

    GetInboxMailById(id, department, type) {
        return axios.get(`/api/WeatherForecast/GetMailInfo?mail_id=${id}&Department_Id=${department}&type=${type}`);
    },

    GetAllDocuments(id) {
        return axios.get(`/api/Resources/GetMailResources/${id}`);
    },

    GetAllDocuments2(id) {
        return axios.get(`/api/Resources/GetAllRes?id=${id}`);
    },

    

    AddReplyDocument(ReplyViewModel) {
        return axios.post(`/api/Reply/Uplode`, ReplyViewModel)
    },















    AddReply(ReplyViewModel) {
        return axios.post(`/api/Reply/AddReply`, ReplyViewModel)
    },

    NewAddReply(ReplyViewModel) {
        return axios.post(`/api/Reply/AddReplyWithPhoto`, ReplyViewModel)
    },







    sent(id, mailType, mangment_id, date_from, date_to, mail_id, summary, department_id, measure_id, classification_id, mail_case_id, page_num, page_size) {
        return axios.get(`/api/ExternalMails/GetMail?userid=${id}&mailNumType=${mailType}&mangment=${mangment_id}&date_from=${date_from}&date_to=${date_to}&mailnum=${mail_id}&summary=${summary}&Department_filter=${department_id}&Measure_filter=${measure_id}&Classfication=${classification_id}&mail_state=${mail_case_id}&page_num=${page_num}&page_size=${page_size}`);
        // return axios.get(`api/ExternalMails/GetIncomingMail?userid=1&mailNumType=1&mangment=2&pagenum=1&size=1`);  
    },

    GetSentMailById(id, type) {
        return axios.get(`/api/Mail/GetMailById?id=${id}&type=${type}`);
    },


    GetReplyByDepartment(department, mail) {
        return axios.get(`/api/Reply/GetReplyById?department_id=${department}&mail_id=${mail}`);
    },





    read_it_mail(id, department_id) {
        return axios.put(`/api/ExternalMails/read_it_mail?mail_id=${id}&department_Id=${department_id}`);
    },

    search(id, mailType, mangment_id, year) {
        return axios.get(`/api/Mail/search?id=${id}&type=${mailType}&year=${year}&department_Id=${mangment_id}`);
    },




    show_senders(id) {
        return axios.get(`/api/Mail/GetDetalies?mail_id=${id}`);
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