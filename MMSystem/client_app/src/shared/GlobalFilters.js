import Vue from "vue";

Vue.filter("mail_forwarding_filter", function(status) {
    if (status === null) return "-";
    let statusName = "";
    if (status === 1) statusName = "فروع الرقابة";
    else if (status === 2) statusName = "جهات عامة";
    else if (status === 3) statusName = "جهات خاصة";
    return statusName;
});

Vue.filter("mail_type", function(status) {
    if (status === null) return "-";
    let statusName = "";
    if (status === 1) statusName = "داخلي";
    else if (status === 2) statusName = "صادر خارجي";
    else if (status === 3) statusName = "وارد خارجي";
    else status = "-";
    return statusName;
});

Vue.filter("mail_state_inbox", function(status) {
    if (status === null) return "-";
    let statusName = "";
    if (status === 1) statusName = "border-yellow-300 ";
    else if (status === 2) statusName = "border-red-700 ";
    else if (status === 3) statusName = "border-pink-300 ";
    else if (status === 4) statusName = "border-blue-800 ";
    else if (status === 5) statusName = "border-yellow-800 ";
    else if (status === 6) statusName = "border-green-800 ";
    return statusName;
});

Vue.filter("mail_forwarding_sector_side_filter", function(status) {
    if (status === null) return "-";
    let statusName = "";
    if (status === 1) statusName = "فروع الرقابة";
    else if (status === 2) statusName = "جهات عامة";
    else if (status === 3) statusName = "جهات خاصة";
    return statusName;
});

Vue.filter("ward_to_filter", function(status) {
    if (status === null) return "-";
    let statusName = "";
    if (status === 1) statusName = "رئيس الهيئة";
    else if (status === 2) statusName = "وكيل الهيئة";
    else if (status === 3) statusName = "مدير  إدارة أو مكتب";
    return statusName;
});

Vue.filter("mail_ward_type_filter", function(status) {
    if (status === null) return "-";
    let statusName = "";
    if (status === 1) statusName = "مباشرة";
    else if (status === 2) statusName = "صورة";
    return statusName;
});

Vue.filter("procedure_type_filter", function(status) {
    if (status === null) return "-";
    let statusName = "";
    if (status === 1) statusName = "لم تعرض";
    else if (status === 2) statusName = "عرضت";
    return statusName;
});