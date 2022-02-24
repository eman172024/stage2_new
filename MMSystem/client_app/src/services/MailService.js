import axios from 'axios';

export default {

    GetMailById(id, type) {
        return axios.get(`/api/Mail/GetMailById?id=${id}&type=${type}`);
    },

    SaveMail(info) {
        return axios.post(`/api/Mail/AddMail`, info)
    },

    SendMail(mailId, userId) {
        return axios.put(`/api/Mail/Send?mailid=${mailId}&userId=${userId}`)
    },

    DeleteMail(my_department_id, userId, mail_id) {
        return axios.delete(`/api/Mail/Delete?department_id=${my_department_id}&userId=${userId}&mail_id=${mail_id}`);
    },

    UpdateMail(Mail) {
        return axios.put(`/api/Mail/UpdateMail`, Mail)
    },
    
    cancel_sending_to_department(mailId, department_id, userId) {
        return axios.delete(`/api/Mail/DeleteMangament?mail_id=${mailId}&departmentId=${department_id}&userId=${userId}`);
    },

    inboxs(id, mailType, mangment_id, date_from, date_to, by_date_of_reply, mail_id, general_incoming_number, summary, department_id, side_id, measure_id, classification_id, mail_case_id, page_num, page_size) {
        return axios.get(`/api/ExternalMails/GetIncomingMail?userid=${id}&mailNumType=${mailType}&mangment=${mangment_id}&date_from=${date_from}&date_to=${date_to}&Replay_Date=${by_date_of_reply}&mailnum=${mail_id}&genral_incoming_num=${general_incoming_number}&summary=${summary}&Department_filter=${department_id}&TheSection=${side_id}&Measure_filter=${measure_id}&Classfication=${classification_id}&mail_state=${mail_case_id}&page_num=${page_num}&page_size=${page_size}`);
    },

    sent(id, mailType, mangment_id, date_from, date_to, by_date_of_reply, mail_id, general_incoming_number, summary, department_id, side_id, measure_id, classification_id, mail_case_id, page_num, page_size) {
        return axios.get(`/api/ExternalMails/GetMail?userid=${id}&mailNumType=${mailType}&mangment=${mangment_id}&date_from=${date_from}&date_to=${date_to}&Replay_Date=${by_date_of_reply}&mailnum=${mail_id}&genral_incoming_num=${general_incoming_number}&summary=${summary}&Department_filter=${department_id}&&TheSection=${side_id}&Measure_filter=${measure_id}&Classfication=${classification_id}&mail_state=${mail_case_id}&page_num=${page_num}&page_size=${page_size}`);
    },

    read_it_mail(id, department_id, userId) {
        return axios.put(`/api/ExternalMails/read_it_mail?mail_id=${id}&department_Id=${department_id}&userId=${userId}`);
    },

    search(id, mailType, mangment_id, year) {
        return axios.get(`/api/Mail/search?id=${id}&type=${mailType}&year=${year}&department_Id=${mangment_id}`);
    },

    GetSentMailById(id, type) {
        return axios.get(`/api/Mail/GetMailById?id=${id}&type=${type}`);
    },

    GetReplyByDepartment(department, mail) {
        return axios.get(`/api/Reply/GetReplyById?department_id=${department}&mail_id=${mail}`);
    },
    
    show_senders(id) {
        return axios.get(`/api/Mail/GetDetalies?mail_id=${id}`);
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

    AllSides() {
        return axios.get(`/api/ExternalMails/Get_Extirnl_Sections`);
    },

    GetInboxMailById(id, department, type) {
        return axios.get(`/api/WeatherForecast/GetMailInfo?mail_id=${id}&Department_Id=${department}&type=${type}`);
    },

    GetAllDocuments(id,userId) {
        return axios.get(`/api/Resources/GetMailResources?mail_id=${id}&userId=${userId}`);
    },

    NewAddReply(ReplyViewModel) {
        return axios.post(`/api/Reply/AddReplyWithPhoto`, ReplyViewModel)
    },

    UploadImagesMail(id, list, userId) {
        return axios.post(`/api/Mail/Uplode`, { userId: userId, mail_id: Number(id), list: list, })
    },

    DeleteDocument(id,userId) {
        return axios.delete(`/api/Mail/DeleteDocument?id=${id}&userId=${userId}`)
    },

    PrintOrShowDocument(id, userId, type) {
        return axios.post(`/api/Resources/print?mail_id=${id}&userId=${userId}&type=${type}`);
    },

    



















    // hussain function


    UpdateArchive(model) {
        return axios.put(`/api/Archive/Update`,model)
    },

    printHistory(model) {
        return axios.put(`/api/Archive/Updates`,model)
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

    GetUsersOfDepartment(id) {
        return axios.get(`/api/Administrator/GetByDepartmentId?department=${id}`);
    },

    GetUsersOfDepartmentControl(id) {
        return axios.get(`/api/Administrator/GetByDepartmentIdControl?department=${id}`);
    },

    GetAllDocuments2(id) {
        return axios.get(`/api/Resources/GetAllRes?id=${id}`);
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


    GetMysectionReport(department_Id,fromdate,todate,mailtype) {
        return axios.get(`/api/Reports/GetMySectionReport?departmentid=${department_Id}&fromdate=${fromdate}&todate=${todate}&MailType=${mailtype}&SendedOrRecieved=${"sended"}`);
    },



}