export default (await import('vue')).defineComponent({
components: {
svgLoadingComponent,
},

mounted() {
if (localStorage.getItem("p_v") != "v1") {
localStorage.setItem("p_v", "v1");
location.reload(true);
}

this.GetAllDepartments();


//**********8/1/2023 stop websocket
//*********************websocket 13/12/2022
/*this.conn = new WebSocket("ws://localhost:58316/ws");
// this.conn = new WebSocket("ws://mail:82/ws");
 
 
this.conn.onmessage = (event) => {
let data_mac = event.data;
let mgs = JSON.parse(data_mac);
this.macaddress = mgs;
var ind = this.macaddress.index;
 
if (ind == 1) {
this.keyid = this.macaddress.keyid;
}
else
{
console.log("mac address="+this.macaddress.mac);
console.log("keyid="+this.macaddress.keyid);
}
}*/
//*************End 13/12/2022
//*******end stop websocket 8/1/2023
},

watch: {
departmentIdSelected: function () {
this.GetBranchOfDepartment();
this.GetUsersOfDepartmentA();
},



branchIdSelected: function () {
this.GetUsersOfDepartment();
},
},

data() {
return {
reload_page: 0,
//******13/12/2022
keyid1: "",
macaddress: [],
//****13/12/2022
loading: true,
screenFreeze: true,
loginSuccess: false,

UserName: "",
Password: "",

user: {},

clear_text: 0,

departments: [],
departmentselect: false,
departmentNameSelected: "",
departmentIdSelected: "",

AdministrativesecretariatSelect: false,
Administrativesecretariat: false,


branches: [],
branchdepartmentdelect: false,
branchdepartmentNameSelected: "",
branchIdSelected: "",

branchdepartment: true,

users: [],
usersSelect: false,
userNameSelected: "",
userIdSelected: "",
};
},
methods: {
clear_textf() {
if (this.clear_text == 0) {
this.departmentNameSelected = "";
this.clear_text++;
}

},


//********13/12/2022
//*****************29/3/2022
test(id) {
var link1 = document.getElementById(id);

var keyid = this.keyid;
link1.href = "MMac:flag=2" + "keyid=" + keyid;
},
test1() {
console.log("maaaac address");
var link1 = document.getElementById("a9");

var keyid = this.keyid;
link1.href = "MMac:flag=2" + "keyid=" + keyid;
},

//***********End 13/12/2022
testSS() {
this.Administrativesecretariat = true;
this.branchdepartment = false;
},

testkk() {
this.Administrativesecretariat = false;
this.branchdepartment = true;
},
GetBranchOfDepartment() {
// console.log(this.departmentIdSelected)
this.loading = true;
this.screenFreeze = true;

this.$http.mailService
.GetBranchOfDepartment(this.departmentIdSelected)
.then((res) => {
this.loading = false;
this.screenFreeze = false;
this.branches = [];
this.branches = res.data;
})
.catch((err) => {
this.branches = [];
this.loading = false;
this.screenFreeze = false;
console.log(err);
});
},

selectbranchdepartment(id, name) {
this.userNameSelected = "";
this.branchdepartmentNameSelected = name;
this.branchIdSelected = id;
},



GetUsersOfDepartment() {
// console.log(this.departmentIdSelected)
this.loading = true;
this.screenFreeze = true;

this.$http.mailService
.GetUsersOfDepartment(this.branchIdSelected)
.then((res) => {
this.loading = false;
this.screenFreeze = false;
this.users = res.data;
})
.catch((err) => {
console.log(err);
this.loading = false;
this.screenFreeze = false;
});
},

GetUsersOfDepartmentA() {
// console.log(this.departmentIdSelected)
this.loading = true;
this.screenFreeze = true;

this.$http.mailService
.GetUsersOfDepartment(this.departmentIdSelected)
.then((res) => {
this.loading = false;
this.screenFreeze = false;
this.users = res.data;
})
.catch((err) => {
console.log(err);
this.loading = false;
this.screenFreeze = false;
});
},


selectUser(id, name) {
this.userNameSelected = name;
this.UserName = name;
this.userIdSelected = id;
},


GetAllDepartments() {
this.$http.mailService
.AllDepartments()
.then((res) => {
console.log(res);
this.loading = false;
this.screenFreeze = false;
this.departments = res.data;
})
.catch((err) => {
this.loading = false;
this.screenFreeze = false;
console.log(err);
});
},


selectdepartment(id, name) {
this.userNameSelected = "";
this.departmentNameSelected = name;
this.departmentIdSelected = id;
},






totest() {
console.log("IN");
this.$router.push({ name: "dashboard" });
},

submit() {
this.screenFreeze = true;
this.loading = true;
if (this.branchdepartmentNameSelected != "") {
var Login = {
Password: this.Password,
DepartmentId: this.branchIdSelected,
UserId: Number(this.userIdSelected),

//******21/12/2022
Mac: this.macaddress.mac,
//*****end 21/12/2022
};
}

this.$http.securityService
.Login(Login)
.then((res) => {
setTimeout(() => {
this.loading = false;
// this.screenFreeze = false;
this.loginSuccess = true;
console.log(res.data);

this.user = res.data;

this.$authenticatedUser.userId = this.user.administrator.userId;
this.$authenticatedUser.name = this.user.administrator.userName;
this.$authenticatedUser.departmentId =
this.user.administrator.departmentId;

localStorage.setItem("AY_LW", this.user.administrator.userId);
localStorage.setItem(
"current_department_name",
this.departmentNameSelected
);
localStorage.setItem(
"chrome",
this.user.administrator.departmentId
);
localStorage.setItem("Az07", this.user.listrole);

setTimeout(() => {
if (this.user.administrator.departmentId != 19) {
this.$router.push({ name: "dashboard" });
} else {
this.$router.push({ name: "Archives" });
}
}, 400);
// this.$authenticatedUser.userName = this.user.username
// this.$authenticatedUser.validity = this.user.validity
}, 10);
})
.catch((err) => {
setTimeout(() => {
this.loading = false;
// this.screenFreeze = false;
this.loginSuccess = false;

console.log(err);
}, 10);
});
},
submit2() {
this.screenFreeze = true;
this.loading = true;
var Login = {
Password: this.Password,
DepartmentId: this.departmentIdSelected,
UserId: Number(this.userIdSelected),

//******21/12/2022
Mac: this.macaddress.mac,
//*****end 21/12/2022
};

this.$http.securityService
.Login(Login)
.then((res) => {
setTimeout(() => {
this.loading = false;
// this.screenFreeze = false;
this.loginSuccess = true;
console.log(res.data);

this.user = res.data;

this.$authenticatedUser.userId = this.user.administrator.userId;
this.$authenticatedUser.name = this.user.administrator.userName;
this.$authenticatedUser.departmentId =
this.user.administrator.departmentId;

localStorage.setItem("AY_LW", this.user.administrator.userId);
localStorage.setItem(
"current_department_name",
this.departmentNameSelected
);
localStorage.setItem(
"chrome",
this.user.administrator.departmentId
);
localStorage.setItem("Az07", this.user.listrole);

setTimeout(() => {
if (this.user.administrator.departmentId != 19) {
this.$router.push({ name: "dashboard" });
} else {
this.$router.push({ name: "Archives" });
}
}, 400);
// this.$authenticatedUser.userName = this.user.username
// this.$authenticatedUser.validity = this.user.validity
}, 10);
})
.catch((err) => {
setTimeout(() => {
this.loading = false;
// this.screenFreeze = false;
this.loginSuccess = false;

console.log(err);
}, 10);
});
},
},
});
