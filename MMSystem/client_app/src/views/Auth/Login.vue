<template>
  <div>
    <div
      class="min-h-screen flex items-center justify-center bg-gray-50 py-12 px-4 sm:px-6 lg:px-8"
    >
      <div class="max-w-md w-full space-y-8">
        <div>
          <img
            class="mx-auto h-36 w-auto object-cover"
            src="../../assets/img/logo-aca.png"
            alt="logo"
          />
          <h2 class="mt-6 text-center text-3xl font-extrabold text-gray-900">
            منظومة البريد الداخلي
          </h2>
        </div>
        <div v-on:keyup.enter="submit" class="mt-8 space-y-6">
          <input type="hidden" name="remember" value="true" />
          <div class="rounded-md shadow-sm">
            <div class="">
              <label
                for="department"
                class="block text-base font-semibold text-gray-800"
              >
                الإدارات
              </label>

              <div class="relative">
                <button
                  @click="departmentselect = !departmentselect"
                  id="department"
                  class="text-right block mt-2 w-full rounded-md h-12 border text-sm bg-white border-gray-300 hover:shadow-sm focus:outline-none focus:border-gray-300 p-2"
                >
                  {{ departmentNameSelected }}
                </button>

                <div
                  v-if="departmentselect"
                  class="border text-sm bg-white border-gray-300 p-2 absolute w-full z-20 shadow h-40 overflow-y-scroll rounded-b-md"
                >
                  <button
                    class="block focus:outline-none w-full duration-500 px-1 py-2 text-right hover:bg-gray-200"
                    @click="
                      selectdepartment(
                        department.id,
                        department.departmentName
                      );
                      departmentselect = !departmentselect;
                    "
                    v-for="department in departments"
                    :key="department.id"
                  >
                    <!--  <a  class="w-full block " :id="department.id" @click="test(department.id)" > {{ department.departmentName }}</a>-->

                    {{ department.departmentName }}
                  </button>
                </div>
              </div>
            </div>

            <div class="my-4">
              <label
                for="email"
                class="block text-base font-semibold text-gray-800"
              >
                المستخدمين
              </label>

              <div class="relative">
                <button
                  @click="usersSelect = !usersSelect"
                  id="email"
                  class="text-right block mt-2 w-full rounded-md h-10 border text-sm bg-white border-gray-300 hover:shadow-sm focus:outline-none focus:border-gray-300 p-2"
                >
                  {{ userNameSelected }}
                </button>

                <div
                  v-if="usersSelect"
                  class="border text-sm bg-white border-gray-300 p-2 absolute w-full z-20 shadow h-24 overflow-y-scroll rounded-b-md"
                >
                  <button
                    class="block focus:outline-none w-full my-1 text-right"
                    @click="
                      selectUser(user.userId, user.userName);
                      usersSelect = !usersSelect;
                    "
                    v-for="user in users"
                    :key="user.id"
                  >
                    {{ user.userName }}
                  </button>
                </div>
              </div>
            </div>

            <div>
              <label
                for="password"
                class="block text-base font-semibold text-gray-800"
              >
                كلمه المرور
              </label>

              <!-- <label for="password" class="sr-only">كلمه المرور</label> -->
              <!--   placeholder="كلمه المرور" -->
              <input
                id="password"
                name="password"
                type="password"
                autocomplete="password"
                required
                v-model="Password"
                class="appearance-none rounded-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-b-md focus:outline-none focus:ring-green-500 focus:border-green-500 focus:z-10 sm:text-sm"
              />
            </div>
          </div>
          <div>
            <button
              @click="submit()"
              type="submit"
              class="group relative w-8/12 mx-auto flex justify-center py-3 px-4 border border-transparent shadow-sm text-sm font-bold rounded-md border-green-600 text-white bg-green-600 hover:shadow-lg focus:shadow-none duration-300 focus:outline-none"
            >
              <span class="absolute left-0 inset-y-0 flex items-center pl-3">
                <svg
                  class="h-5 w-5 text-white fill-current"
                  id="_x31__x2C_5"
                  enable-background="new 0 0 24 24"
                  height="512"
                  viewBox="0 0 24 24"
                  width="512"
                >
                  <path
                    d="m18.75 24h-13.5c-1.24 0-2.25-1.009-2.25-2.25v-10.5c0-1.241 1.01-2.25 2.25-2.25h13.5c1.24 0 2.25 1.009 2.25 2.25v10.5c0 1.241-1.01 2.25-2.25 2.25zm-13.5-13.5c-.413 0-.75.336-.75.75v10.5c0 .414.337.75.75.75h13.5c.413 0 .75-.336.75-.75v-10.5c0-.414-.337-.75-.75-.75z"
                  />
                  <path
                    d="m17.25 10.5c-.414 0-.75-.336-.75-.75v-3.75c0-2.481-2.019-4.5-4.5-4.5s-4.5 2.019-4.5 4.5v3.75c0 .414-.336.75-.75.75s-.75-.336-.75-.75v-3.75c0-3.309 2.691-6 6-6s6 2.691 6 6v3.75c0 .414-.336.75-.75.75z"
                  />
                  <path
                    d="m12 17c-1.103 0-2-.897-2-2s.897-2 2-2 2 .897 2 2-.897 2-2 2zm0-2.5c-.275 0-.5.224-.5.5s.225.5.5.5.5-.224.5-.5-.225-.5-.5-.5z"
                  />
                  <path
                    d="m12 20c-.414 0-.75-.336-.75-.75v-2.75c0-.414.336-.75.75-.75s.75.336.75.75v2.75c0 .414-.336.75-.75.75z"
                  />
                </svg>
              </span>
              تسجيل الدخول
            </button>
          </div>
        </div>
      </div>
    </div>

    <div
      v-if="screenFreeze"
      class="w-screen h-screen bg-black bg-opacity-30 absolute inset-0 z-50 flex justify-center items-center"
    >
      <div v-if="loading" class="">
        <svgLoadingComponent></svgLoadingComponent>
      </div>
      <div v-else>
        <div v-if="loginSuccess" class="shadow-2xl">
          <div
            class="w-96 h-60 bg-white rounded-lg p-4 flex flex-col justify-between items-center"
          >
            <div class="flex justify-center items-center h-full">
              <span class="font-bold"> {{ user.name }} &nbsp; </span>
              مرحبا بك مجدداَ في منظومة البريد.
            </div>

            <div class="">
              <router-link
                v-if="this.user.administrator.departmentId != 19"
                :to="{ name: 'dashboard' }"
                class="py-2 px-8 border border-transparent shadow-sm text-sm font-medium rounded-md text-green-600 border-green-600 hover:bg-green-600 hover:text-white duration-300 focus:outline-none"
              >
                دخول
              </router-link>

              <router-link
                v-else
                :to="{ name: 'Archives' }"
                class="py-2 px-8 border border-transparent shadow-sm text-sm font-medium rounded-md text-green-600 border-green-600 hover:bg-green-600 hover:text-white duration-300 focus:outline-none"
              >
                دخول
              </router-link>
            </div>
          </div>
        </div>

        <div v-else class="shadow-2xl">
          <div
            class="w-96 h-60 bg-white rounded-lg p-4 flex flex-col justify-between items-center"
          >
            <div class="flex justify-between items-center w-full">
              <p class="text-lg font-medium text-green-600">
                فشل في عملية الدخول
              </p>
              <button
                @click="
                  screenFreeze = false;
                  loading = false;
                "
                class="focus:outline-none"
              >
                <svg
                  class="w-6 h-6 stroke-current text-base hover:text-red-500 duration-300"
                  width="24"
                  height="24"
                  viewBox="0 0 24 24"
                  fill="none"
                  xmlns="http://www.w3.org/2000/svg"
                >
                  <path
                    d="M7.86 2H16.14L22 7.86V16.14L16.14 22H7.86L2 16.14V7.86L7.86 2Z"
                    stroke-width="2"
                    stroke-linecap="round"
                    stroke-linejoin="round"
                  />
                  <path
                    d="M15 9L9 15"
                    stroke-width="2"
                    stroke-linecap="round"
                    stroke-linejoin="round"
                  />
                  <path
                    d="M9 9L15 15"
                    stroke-width="2"
                    stroke-linecap="round"
                    stroke-linejoin="round"
                  />
                </svg>
              </button>
            </div>

            <div
              class="flex justify-center items-center h-full text-center leading-8"
            >
              يبدو أنك أخطأت في إدخال أحد الحقول.
              <br />
              يرجى التحقق من البيانات والمحاولة مرة أخرى.
            </div>

            <div class="">
              <button
                @click="
                  screenFreeze = false;
                  loading = false;
                "
                class="py-2 px-8 border border-transparent shadow-sm text-sm font-medium rounded-md text-green-600 border-green-600 hover:bg-green-600 hover:text-white duration-300 focus:outline-none"
              >
                المحاولة مرة اخرى
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import svgLoadingComponent from "@/components/svgLoadingComponent.vue";

export default {
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

    GetUsersOfDepartment() {
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
            sessionStorage.setItem("id", this.user.administrator.userId);
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
};
</script>
