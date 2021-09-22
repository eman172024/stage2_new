import Vue from "vue";

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
    if (status === 1) statusName = "border-blue-200 ";
    else if (status === 2) statusName = "border-red-700 ";
    else if (status === 3) statusName = "border-red-200 ";
    else if (status === 4) statusName = "border-blue-800 ";
    else if (status === 5) statusName = "border-yellow-800 ";
    else if (status === 6) statusName = "border-green-800 ";
    return statusName;
});