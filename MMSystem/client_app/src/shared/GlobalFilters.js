import Vue from "vue";

Vue.filter("flagMassageCC", function(status) {
    if (status === null) return "-";
    let statusName = "";
    if (status === 1) statusName = "لم تقرأ";
    else if (status === 2) statusName = "تم قراتها";
    else if (status === 3) statusName = "تم الرد";
    else if (status === 4) statusName = "تم عرض الرد";
    else status = "-";
    return statusName;
});

Vue.filter("flagColorCC", function(status) {
    if (status === null) return "-";
    let statusName = "";
    if (status === 1) statusName = "bg-yellow-400 text-black";
    else if (status === 2) statusName = "bg-yellow-600 text-green-800";
    else if (status === 3) statusName = "bg-green-500 text-black";
    else if (status === 4) statusName = "bg-green-800 text-black";
    return statusName;
});


Vue.filter("flagMassageOM", function(status) {
    if (status === null) return "-";
    let statusName = "";
    if (status === 0) statusName = "لم ترسل";
    else if (status === 1) statusName = "تم الارسال";
    else if (status === 2) statusName = "تم عرض البريد";
    else if (status === 3) statusName = "تم الرد";
    else if (status === 4) statusName = "تم عرض الرد";
    else status = "-";
    return statusName;
});

Vue.filter("flagColorOM", function(status) {
    if (status === null) return "-";
    let statusName = "";
    if (status === 0) statusName = "bg-yellow-400 text-black";
    else if (status === 1) statusName = "bg-yellow-600 text-green-800";
    else if (status === 2) statusName = "bg-yellow-800 text-black";
    else if (status === 3) statusName = "bg-red-600 text-white";
    else if (status === 4) statusName = "bg-green-800 text-black";
    return statusName;
});