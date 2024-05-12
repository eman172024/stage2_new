import axios from 'axios';

export default {


    delete_reply(id, userid) {

        return axios.put(`/api/Reply/DeleteReply?id=${id}&&UserId=${userid}`);

    },

    cancel_sending_to_sector_side(id, userId) {
        return axios.delete(`/api/Mail/delete_sector?id=${id}&userId=${userId}`);
        //  return axios.delete(`http://mail:82/api/Mail/DeleteMangament?mail_id=${mailId}&departmentId=${department_id}&userId=${userId}`);
    },

    testsss(page_num) {
        return axios.get(`/api/ExternalMails/GetMail?userid=5&mailNumType=0&mangment=1&date_from=2021-11-04&date_to=2023-01-07&Replay_Date=false&mailnum=&genral_incoming_num=&summary=&Department_filter=&&TheSection=&Measure_filter=&Classfication=&mail_state=&page_num=${page_num}&page_size=5`);


        //  return axios.get(`http://mail:82/api/Mail/GetMailById?id=${id}&type=${type}`);
    },

    GetMailById(id, type) {
        return axios.get(`/api/Mail/GetMailById?id=${id}&type=${type}`);
        //  return axios.get(`http://mail:82/api/Mail/GetMailById?id=${id}&type=${type}`);
    },

    SaveMail(info) {
        return axios.post(`/api/Mail/AddMail`, info)
            //  return axios.post(`http://mail:82/api/Mail/AddMail`, info)
    },

    SendMail(mailId, userId) {
        return axios.put(`/api/Mail/Send?mailid=${mailId}&userId=${userId}`)
            //  return axios.put(`http://mail:82/api/Mail/Send?mailid=${mailId}&userId=${userId}`)
    },

    DeleteMail(my_department_id, userId, mail_id) {
        return axios.delete(`/api/Mail/Delete?department_id=${my_department_id}&userId=${userId}&mail_id=${mail_id}`);
        //  return axios.delete(`http://mail:82/api/Mail/Delete?department_id=${my_department_id}&userId=${userId}&mail_id=${mail_id}`);
    },

    UpdateMail(Mail) {
        return axios.put(`/api/Mail/UpdateMail`, Mail)
            //  return axios.put(`http://mail:82/api/Mail/UpdateMail`, Mail)
    },

    cancel_sending_to_department(mailId, department_id, userId) {
        return axios.delete(`/api/Mail/DeleteMangament?mail_id=${mailId}&departmentId=${department_id}&userId=${userId}`);
        //  return axios.delete(`http://mail:82/api/Mail/DeleteMangament?mail_id=${mailId}&departmentId=${department_id}&userId=${userId}`);
    },


    inboxs(id, mailType, mangment_id, date_from, date_to, by_date_of_reply, mail_id, general_incoming_number, summary, department_id, side_id, measure_id, classification_id, mail_case_id,s_number, page_num, page_size) {
        return axios.get(`/api/ExternalMails/GetIncomingMail?userid=${id}&mailNumType=${mailType}&mangment=${mangment_id}&date_from=${date_from}&date_to=${date_to}&Replay_Date=${by_date_of_reply}&mailnum=${mail_id}&genral_incoming_num=${general_incoming_number}&summary=${summary}&Department_filter=${department_id}&TheSection=${side_id}&Measure_filter=${measure_id}&Classfication=${classification_id}&mail_state=${mail_case_id}&entity_reference_number=${s_number}&page_num=${page_num}&page_size=${page_size}`);
        // return axios.get(`http://mail:82/api/ExternalMails/GetIncomingMail?userid=${id}&mailNumType=${mailType}&mangment=${mangment_id}&date_from=${date_from}&date_to=${date_to}&Replay_Date=${by_date_of_reply}&mailnum=${mail_id}&genral_incoming_num=${general_incoming_number}&summary=${summary}&Department_filter=${department_id}&TheSection=${side_id}&Measure_filter=${measure_id}&Classfication=${classification_id}&mail_state=${mail_case_id}&page_num=${page_num}&page_size=${page_size}`);
    },

    sent(id, mailType, mangment_id, date_from, date_to, by_date_of_reply, mail_id, general_incoming_number, summary, department_id, side_id, measure_id, classification_id, mail_case_id,s_number,certified, page_num, page_size) {
        return axios.get(`/api/ExternalMails/GetMail?userid=${id}&mailNumType=${mailType}&mangment=${mangment_id}&date_from=${date_from}&date_to=${date_to}&Replay_Date=${by_date_of_reply}&mailnum=${mail_id}&genral_incoming_num=${general_incoming_number}&summary=${summary}&Department_filter=${department_id}&&TheSection=${side_id}&Measure_filter=${measure_id}&Classfication=${classification_id}&mail_state=${mail_case_id}&entity_reference_number=${s_number}&office_type=${certified}&page_num=${page_num}&page_size=${page_size}`);
        //  return axios.get(`http://mail:82/api/ExternalMails/GetMail?userid=${id}&mailNumType=${mailType}&mangment=${mangment_id}&date_from=${date_from}&date_to=${date_to}&Replay_Date=${by_date_of_reply}&mailnum=${mail_id}&genral_incoming_num=${general_incoming_number}&summary=${summary}&Department_filter=${department_id}&&TheSection=${side_id}&Measure_filter=${measure_id}&Classfication=${classification_id}&mail_state=${mail_case_id}&page_num=${page_num}&page_size=${page_size}`);
    },

    read_it_mail(id, department_id, userId) {
        return axios.put(`/api/ExternalMails/read_it_mail?mail_id=${id}&department_Id=${department_id}&userId=${userId}`);
        //   return axios.put(`http://mail:82/api/ExternalMails/read_it_mail?mail_id=${id}&department_Id=${department_id}&userId=${userId}`);

    },

    search(id, mailType, mangment_id, year) {
        return axios.get(`/api/Mail/search?id=${id}&type=${mailType}&year=${year}&department_Id=${mangment_id}`);
        //  return axios.get(`http://mail:82/api/Mail/search?id=${id}&type=${mailType}&year=${year}&department_Id=${mangment_id}`);
    },

    GetSentMailById(id, type) {
        return axios.get(`/api/Mail/GetMailById?id=${id}&type=${type}&page_number=1`);
        //  return axios.get(`http://mail:82/api/Mail/GetMailById?id=${id}&type=${type}&page_number=1`);
    },

    GetReplyByDepartment(department, mail) {
        return axios.get(`/api/Reply/GetReplyById?department_id=${department}&mail_id=${mail}`);
        //  return axios.get(`http://mail:82/api/Reply/GetReplyById?department_id=${department}&mail_id=${mail}`);
    },


    isExisiteGenaralInboxNumberFun(Genaral_inbox_Number) {
        return axios.get(`/api/mail/is_exisite_genaral_inbox_number?Genaral_inbox_Number_id=${Genaral_inbox_Number}`);
    },







    show_senders(id) {
        return axios.get(`/api/Mail/GetDetalies?mail_id=${id}`);
        //  return axios.get(`http://mail:82/api/Mail/GetDetalies?mail_id=${id}`);
    },

    AllClassifications() {
        return axios.get(`/api/Service/GetAllClassification`);
        //   return axios.get(`http://mail:82/api/Service/GetAllClassification`);
    },

    AllMeasures() {
        return axios.get(`/api/Service/GetAllMeasures`);
        //  return axios.get(`http://mail:82/api/Service/GetAllMeasures`);
    },

    AllStateSent() {
        return axios.get(`/api/Mail/GetAllMailStateWithId?flag=1`);
        //  return axios.get(`http://mail:82/api/Mail/GetAllMailStateWithId?flag=1`);
    },

    AllStateInbox() {
        return axios.get(`/api/Mail/GetAllMailStateWithId?flag=2`);
        //  return axios.get(`http://mail:82/api/Mail/GetAllMailStateWithId?flag=2`);
    },

    AllDepartments() {
        return axios.get(`/api/WeatherForecast/GetAllDepartments`);
        //  return axios.get(`http://mail:82/api/WeatherForecast/GetAllDepartments`);
    },

    AllSides() {
        return axios.get(`/api/ExternalMails/Get_Extirnl_Sections`);
        //  return axios.get(`http://mail:82/api/ExternalMails/Get_Extirnl_Sections`);
    },

    GetInboxMailById(id, department, type) {
        return axios.get(`/api/WeatherForecast/GetMailInfo?mail_id=${id}&Department_Id=${department}&type=${type}`);
        //  return axios.get(`http://mail:82/api/WeatherForecast/GetMailInfo?mail_id=${id}&Department_Id=${department}&type=${type}`);
    },

    GetAllDocuments(id, userId) {
        return axios.get(`/api/Resources/GetMailResources?mail_id=${id}&userId=${userId}`);
        //  return axios.get(`http://mail:82/api/Resources/GetMailResources?mail_id=${id}&userId=${userId}`);
    },

    NewAddReply(ReplyViewModel) {
        return axios.post(`/api/Reply/AddReplyWithPhoto`, ReplyViewModel)
            //   return axios.post(`http://mail:82/api/Reply/AddReplyWithPhoto`, ReplyViewModel)
    },

    //***********27/2/2023
    update_replay(ReplyViewModel){
        return axios.post(`/api/Reply/update_replay`, ReplyViewModel)
    },
    //********end 27/2/2023
    
    // UploadImagesMail(id, list) {
    //      return axios.post(`/api/Mail/Uplode`, { userId: 9, mail_id: Number(id), list: list, })
    //  return axios.post(`http://mail:82/api/Mail/Uplode`, { userId: 9, mail_id: Number(id), list: list, })
    UploadImagesMail(id, list, userId) {
        return axios.post(`/api/Mail/Uplode`, { userId: userId, mail_id: Number(id), list: list, })
            // return axios.post(`http://mail:82/api/Mail/Uplode`, { userId: userId, mail_id: Number(id), list: list, })

    },

    DeleteAllDocuments(id, userId) {
        return axios.delete(`/api/Resources/delete_all_image?id=${id}&userId=${userId}`)
            //   return axios.delete(`http://mail:82/api/Mail/DeleteDocument?id=${id}&userId=${userId}`)
    },


    DeleteDocument(id, userId) {
        return axios.delete(`/api/Mail/DeleteDocument?id=${id}&userId=${userId}`)
            //   return axios.delete(`http://mail:82/api/Mail/DeleteDocument?id=${id}&userId=${userId}`)
    },

    PrintOrShowDocument(id, userId, type) {
        return axios.post(`/api/Resources/print?mail_id=${id}&userId=${userId}&type=${type}`);
        //  return axios.post(`http://mail:82/api/Resources/print?mail_id=${id}&userId=${userId}&type=${type}`);
    },





















    // hussain function


    UpdateArchive(model) {
        return axios.put(`/api/Archive/Update`, model)
            //   return axios.put(`http://mail:82/api/Archive/Update`, model)
    },

    printHistory(model) {
        return axios.put(`/api/Archive/Updates`, model)
            //  return axios.put(`http://mail:82/api/Archive/Updates`, model)
    },

    GetMailForArchives(page, pageSize, mail_number, date_time_of_day, date_time_from, department_id, side_id, mail_summary, MailType, Perent) {
        return axios.get(`/api/Archive/GetAll?page=${page}&pageSize=${pageSize}&mail_number=${mail_number}&date_time_of_day=${date_time_of_day}&date_time_from=${date_time_from}&department_id=${department_id}&side_id=${side_id}&mail_summary=${mail_summary}&MailType=${MailType}&Perent=${Perent}`);
        //  return axios.get(`http://mail:82/api/Archive/GetAll?page=${page}&pageSize=${pageSize}&mail_number=${mail_number}&date_time_of_day=${date_time_of_day}&date_time_from=${date_time_from}&department_id=${department_id}&side_id=${side_id}&mail_summary=${mail_summary}&MailType=${MailType}&Perent=${Perent}`);
    },

    Add_user(user) {
        return axios.post(`/api/Administrator/Add`, user);
        //   return axios.post(`http://mail:82/api/Administrator/Add`, user);
    },

    GetAllRoles() {
        return axios.get(`/api/Role/GetAll`);
        //   return axios.get(`http://mail:82/api/Role/GetAll`);
    },

    GetUsersOfDepartment(id) {
        return axios.get(`/api/Administrator/GetByDepartmentId?department=${id}`);
        //   return axios.get(`http://mail:82/api/Administrator/GetByDepartmentId?department=${id}`);
    },

    GetUsersOfDepartmentControl(id) {
        return axios.get(`/api/Administrator/GetByDepartmentIdControl?department=${id}`);
        //   return axios.get(`http://mail:82/api/Administrator/GetByDepartmentIdControl?department=${id}`);
    },

    GetAllDocuments2(id) {
        return axios.get(`/api/Resources/GetAllRes?id=${id}`);
        //  return axios.get(`http://mail:82/api/Resources/GetAllRes?id=${id}`);
    },

    GetMails(filter, role) {
        return axios.get(`/api/Mails/GetMails`, {
            //   return axios.get(`http://mail:82/api/Mails/GetMails`, {
            params: {
                pageSize: filter.pageSize,
                pageNo: filter.pageNo,
                role: role,
            }
        })
    },

    BossSee(mailId) {
        return axios.put(`/api/Mails/BossSee?mailId=${mailId}`);
        //  return axios.put(`http://mail:82/api/Mails/BossSee?mailId=${mailId}`);
    },

    EmploySee(mailId) {
        return axios.put(`/api/Mails/EmploySee?mailId=${mailId}`);
        //   return axios.put(`http://mail:82/api/Mails/EmploySee?mailId=${mailId}`);
    },

    GetSearchList(searchTerm) {
        return axios.get(`/api/Mails/GetSearchList`, {
            //    return axios.get(`http://mail:82/api/Mails/GetSearchList`, {
            params: {
                searchTerm: searchTerm
            }
        });
    },


    GetMysectionReport(department_Id, fromdate, todate, mailtype) {



        return axios.get(`/api/Reports/GetMySectionReport?departmentid=${department_Id}&fromdate=${fromdate}&todate=${todate}&MailType=${mailtype}&SendedOrRecieved=${"sended"}`);
        //  return axios.get(`http://mail:82/api/Reports/GetMySectionReport?departmentid=${department_Id}&fromdate=${fromdate}&todate=${todate}&MailType=${mailtype}&SendedOrRecieved=${"sended"}`);
    },


    Get_sent_report_ayoub(department_Id, from, to, Department_filter, mailnum, summary, mail_type, Measure_filter, Classfication, mail_state, genral_incoming_num,side_selected,entity_ref_num,date_of_reply) {
       // return axios.get(`/api/Reports/GetReportDepartment?departmenti_d=${department_Id}&from=${from}&to=${to}&Department_filter=${Department_filter}&mailnum=${mailnum}&summary=${summary}&mail_type=${mail_type}&Measure_filter=${Measure_filter}&Classfication=${Classfication}&mail_state=${mail_state}&genral_incoming_num=${genral_incoming_num}`);
       return axios.get(`/api/Reports/GetReportDepartment?departmenti_d=${department_Id}&from=${from}&to=${to}&Department_filter=${Department_filter}&mailnum=${mailnum}&summary=${summary}&mail_type=${mail_type}&Measure_filter=${Measure_filter}&Classfication=${Classfication}&mail_state=${mail_state}&genral_incoming_num=${genral_incoming_num}&thesection=${side_selected}&entity_reference_number=${entity_ref_num}&Replay_Date=${date_of_reply}`);
       
        
        //  return axios.get(`http://mail:82/api/Reports/GetReportDepartment?departmenti_d=${department_Id}&from=${from}&to=${to}`);
    },



}