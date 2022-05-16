import axios from 'axios';

export default {

    GetMailById(id, type) {
        return axios.get(`http://172.16.0.12:82/api/Mail/GetMailById?id=${id}&type=${type}`);
    },

    SaveMail(info) {
        return axios.post(`http://172.16.0.12:82/api/Mail/AddMail`, info)
    },

    SendMail(mailId, userId) {
        return axios.put(`http://172.16.0.12:82/api/Mail/Send?mailid=${mailId}&userId=${userId}`)
    },

    DeleteMail(my_department_id, userId, mail_id) {
        return axios.delete(`http://172.16.0.12:82/api/Mail/Delete?department_id=${my_department_id}&userId=${userId}&mail_id=${mail_id}`);
    },

    UpdateMail(Mail) {
        return axios.put(`http://172.16.0.12:82/api/Mail/UpdateMail`, Mail)
    },
    
    cancel_sending_to_department(mailId, department_id, userId) {
        return axios.delete(`http://172.16.0.12:82/api/Mail/DeleteMangament?mail_id=${mailId}&departmentId=${department_id}&userId=${userId}`);
    },

    inboxs(id, mailType, mangment_id, date_from, date_to, by_date_of_reply, mail_id, general_incoming_number, summary, department_id, side_id, measure_id, classification_id, mail_case_id, page_num, page_size) {
        return axios.get(`http://172.16.0.12:82/api/ExternalMails/GetIncomingMail?userid=${id}&mailNumType=${mailType}&mangment=${mangment_id}&date_from=${date_from}&date_to=${date_to}&Replay_Date=${by_date_of_reply}&mailnum=${mail_id}&genral_incoming_num=${general_incoming_number}&summary=${summary}&Department_filter=${department_id}&TheSection=${side_id}&Measure_filter=${measure_id}&Classfication=${classification_id}&mail_state=${mail_case_id}&page_num=${page_num}&page_size=${page_size}`);
    },

    sent(id, mailType, mangment_id, date_from, date_to, by_date_of_reply, mail_id, general_incoming_number, summary, department_id, side_id, measure_id, classification_id, mail_case_id, page_num, page_size) {
        return axios.get(`http://172.16.0.12:82/api/ExternalMails/GetMail?userid=${id}&mailNumType=${mailType}&mangment=${mangment_id}&date_from=${date_from}&date_to=${date_to}&Replay_Date=${by_date_of_reply}&mailnum=${mail_id}&genral_incoming_num=${general_incoming_number}&summary=${summary}&Department_filter=${department_id}&&TheSection=${side_id}&Measure_filter=${measure_id}&Classfication=${classification_id}&mail_state=${mail_case_id}&page_num=${page_num}&page_size=${page_size}`);
    },

    read_it_mail(id, department_id, userId) {
        return axios.put(`http://172.16.0.12:82/api/ExternalMails/read_it_mail?mail_id=${id}&department_Id=${department_id}&userId=${userId}`);
    },

    search(id, mailType, mangment_id, year) {
        return axios.get(`http://172.16.0.12:82/api/Mail/search?id=${id}&type=${mailType}&year=${year}&department_Id=${mangment_id}`);
    },

    GetSentMailById(id, type) {
        return axios.get(`http://172.16.0.12:82/api/Mail/GetMailById?id=${id}&type=${type}`);
    },

    GetReplyByDepartment(department, mail) {
        return axios.get(`http://172.16.0.12:82/api/Reply/GetReplyById?department_id=${department}&mail_id=${mail}`);
    },
    
    show_senders(id) {
        return axios.get(`http://172.16.0.12:82/api/Mail/GetDetalies?mail_id=${id}`);
    },

    AllClassifications() {
        return axios.get(`http://172.16.0.12:82/api/Service/GetAllClassification`);
    },

    AllMeasures() {
        return axios.get(`http://172.16.0.12:82/api/Service/GetAllMeasures`);
    },

    AllStateSent() {
        return axios.get(`http://172.16.0.12:82/api/Mail/GetAllMailStateWithId?flag=1`);
    },

    AllStateInbox() {
        return axios.get(`http://172.16.0.12:82/api/Mail/GetAllMailStateWithId?flag=2`);
    },

    AllDepartments() {
        return axios.get(`http://172.16.0.12:82/api/WeatherForecast/GetAllDepartments`);
    },

    AllSides() {
        return axios.get(`http://172.16.0.12:82/api/ExternalMails/Get_Extirnl_Sections`);
    },

    GetInboxMailById(id, department, type) {
        return axios.get(`http://172.16.0.12:82/api/WeatherForecast/GetMailInfo?mail_id=${id}&Department_Id=${department}&type=${type}`);
    },

    GetAllDocuments(id,userId) {
        return axios.get(`http://172.16.0.12:82/api/Resources/GetMailResources?mail_id=${id}&userId=${userId}`);
    },

    NewAddReply(ReplyViewModel) {
        return axios.post(`http://172.16.0.12:82/api/Reply/AddReplyWithPhoto`, ReplyViewModel)
    },

    UploadImagesMail(id, list, userId) {
        return axios.post(`http://172.16.0.12:82/api/Mail/Uplode`, { userId: userId, mail_id: Number(id), list: list, })
    },

    DeleteDocument(id,userId) {
        return axios.delete(`http://172.16.0.12:82/api/Mail/DeleteDocument?id=${id}&userId=${userId}`)
    },

    PrintOrShowDocument(id, userId, type) {
        return axios.post(`http://172.16.0.12:82/api/Resources/print?mail_id=${id}&userId=${userId}&type=${type}`);
    },

    



















    // hussain function


    UpdateArchive(model) {
        return axios.put(`http://172.16.0.12:82/api/Archive/Update`,model)
    },

    printHistory(model) {
        return axios.put(`http://172.16.0.12:82/api/Archive/Updates`,model)
    },

    GetMailForArchives(page,pageSize,mail_number,date_time_of_day,date_time_from,department_id,side_id,mail_summary,MailType,Perent) {
        return axios.get(`http://172.16.0.12:82/api/Archive/GetAll?page=${page}&pageSize=${pageSize}&mail_number=${mail_number}&date_time_of_day=${date_time_of_day}&date_time_from=${date_time_from}&department_id=${department_id}&side_id=${side_id}&mail_summary=${mail_summary}&MailType=${MailType}&Perent=${Perent}`);
    },

    Add_user(user){
        return axios.post(`http://172.16.0.12:82/api/Administrator/Add`,user);
    },

    GetAllRoles() {
        return axios.get(`http://172.16.0.12:82/api/Role/GetAll`);
    },

    GetUsersOfDepartment(id) {
        return axios.get(`http://172.16.0.12:82/api/Administrator/GetByDepartmentId?department=${id}`);
    },

    GetUsersOfDepartmentControl(id) {
        return axios.get(`http://172.16.0.12:82/api/Administrator/GetByDepartmentIdControl?department=${id}`);
    },

    GetAllDocuments2(id) {
        return axios.get(`http://172.16.0.12:82/api/Resources/GetAllRes?id=${id}`);
    },

    GetMails(filter, role) {
        return axios.get(`http://172.16.0.12:82/api/Mails/GetMails`, {
            params: {
                pageSize: filter.pageSize,
                pageNo: filter.pageNo,
                role: role,
            }
        })
    },

    BossSee(mailId) {
        return axios.put(`http://172.16.0.12:82/api/Mails/BossSee?mailId=${mailId}`);
    },

    EmploySee(mailId) {
        return axios.put(`http://172.16.0.12:82/api/Mails/EmploySee?mailId=${mailId}`);
    },

    GetSearchList(searchTerm) {
        return axios.get(`http://172.16.0.12:82/api/Mails/GetSearchList`, {
            params: {
                searchTerm: searchTerm
            }
        });
    },


    GetMysectionReport(department_Id,fromdate,todate,mailtype) {


      
        return axios.get(`http://172.16.0.12:82/api/Reports/GetMySectionReport?departmentid=${department_Id}&fromdate=${fromdate}&todate=${todate}&MailType=${mailtype}&SendedOrRecieved=${"sended"}`);
    },



}