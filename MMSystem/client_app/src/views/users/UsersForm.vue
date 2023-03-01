<template>
  <div class="h-screen bg-gray-100  flex overflow-scroll">
    <asideComponent></asideComponent>

    <div class="bg-gray-200 h-screen w-full " dir="rtl">
      <logout class="pt-2 ml-12"></logout>
      <div
        class="
        min-h-full
        mx-auto
        max-w-4xl
        p-2
        flex flex-col
        
        
        relative
      "
      >
        <div
          v-if="isaddsuccess"
          class="w-96  z-50 p-4 bg-white rounded-lg absolute top-48 flex flex-col text-center items-center"
        >
          <span>{{ addsuccess }}</span>
          <button
            class="bg-green-800 text-white h-10 w-32 mt-6 rounded-md"
            @click="isaddsuccess = false"
          >
            موافق
          </button>
        </div>

        <div
          v-if="iseditesuccess"
          class="w-96  z-50 p-4 bg-white rounded-lg absolute top-48 flex flex-col text-center items-center"
        >
          <span>{{ editesuccess }}</span>
          <button
            class="bg-green-800 text-white h-10 w-32 mt-6 rounded-md"
            @click="iseditesuccess = false"
          >
            موافق
          </button>
        </div>

        <div class="w-full h-full">
          <h1 class="font-extrabold text-xl text-center">المستخدمين</h1>

          <div class="bg-gray-100 grid grid-cols-2 p-4 gap-3 text-sm mt-4">
            <div>
              <label for="network_user_name" class="font-medium text-gray-700">
                اسم المستخدم على الشبكة
              </label>

              <input
                id="network_user_name"
                type="text"
                v-model="UserNet"
                class="
                w-full
                mt-1
                focus:outline-none focus:border-green-300
                border
                rounded-md
                px-2
                py-1
              "
                placeholder="ادخل اسم المستخدم على الشبكة"
              />
            </div>

            <div>
              <label for="national_id" class="font-medium text-gray-700">
                الرقم الوطني
              </label>

              <label
                v-if="national_valid"
                for="national"
                class="font-medium text-red-700"
              >
                يجب أن يتكون الرقم الوطني من 12 خانة
              </label>

              <input
                id="national_id"
                type="text"
                name="price"  
                 onkeypress="return event.charCode >= 48 && event.charCode <= 57"
                v-model="num"
                class="
                w-full
                mt-1
                focus:outline-none focus:border-green-300
                border
                rounded-md
                px-2
                py-1
              "
                placeholder="ادخل الرقم الوطني"
              />
            </div>





            <div>
              <label for="Mac Address 1" class="font-medium text-gray-700">
                Mac Address 1
              </label>

              <label
                v-if="mac1_valid"
                for="Mac Address 1"
                class="font-medium text-red-700"
              >
               يجب أن يتكون ال Mac Address من 17 خانة
              </label>

              <input
                id="Mac Address 1"
                type="text"
               v-model="mac1"
                class="
                w-full
                mt-1
                focus:outline-none focus:border-green-300
                border
                rounded-md
                px-2
                py-1
              "
                placeholder="Mac Address 1"
              />
            </div>

            <div>
              <label for="Mac Address 2" class="font-medium text-gray-700">
               Mac Address 2
              </label>

              <label
                v-if="mac2_valid"
                for="Mac Address 2"
                class="font-medium text-red-700"
              >
               يجب أن يتكون ال Mac Address من 17 خانة
              </label>

              <input
                id="Mac Address 2"
                type="text"
                v-model="mac2"
                class="
                w-full
                mt-1
                focus:outline-none focus:border-green-300
                border
                rounded-md
                px-2
                py-1
              "
                placeholder="Mac Address 2"
              />
            </div>



            <div>
              <label for="user_name" class="font-medium text-gray-700">
                اسم المستخدم
              </label>

              <label v-if="username_valid" class="font-medium text-red-700">
                الرجاء إدخال الاسم ثلاثي
              </label>

              <input
                id="user_name"
                type="text"
                v-model="UserName"
                class="
                w-full
                mt-1
                focus:outline-none focus:border-green-300
                border
                rounded-md
                px-2
                py-1
              "
                placeholder="ادخل اسم المستخدم"
              />
            </div>

            <div class="flex justify-between ">
              <div class="ml-1 ">
                <label for="password" class="font-medium text-gray-700">
                  كلمة المرور
                </label>

                <input
                  id="password"
                  :type="fieldtyp"
                  v-model="pass"
                  class="
                w-full
                mt-1
                focus:outline-none focus:border-green-300
                border
                rounded-md
                px-2
                py-1
              "
                  placeholder="ادخل كلمة المرور"
                />
              </div>

              <div class="mr-1">
                <label
                  v-if="pass_true"
                  for="password"
                  class="font-medium text-gray-700"
                >
                  تأكيد
                </label>

                <label v-else for="password" class="font-medium text-red-700">
                  كلمة المرور غير متطابقة
                </label>

                <input
                  id="password"
                  :type="fieldtyp"
                  v-model="confir_pass"
                  class="
                w-full
                mt-1
                focus:outline-none focus:border-green-300
                border
                rounded-md
                px-2
                py-1
              "
                  placeholder="تأكيد كلمة المرور"
                />
              </div>

              <button
                class="w-8 h-8 self-end mr-1"
                @mousedown="switch_field"
                @mouseup="switch_field"
              >
                <svg
                  class="w-6 h-6"
                  fill="none"
                  stroke="currentColor"
                  viewBox="0 0 24 24"
                  xmlns="http://www.w3.org/2000/svg"
                >
                  <path
                    stroke-linecap="round"
                    stroke-linejoin="round"
                    stroke-width="2"
                    d="M15 12a3 3 0 11-6 0 3 3 0 016 0z"
                  ></path>
                  <path
                    stroke-linecap="round"
                    stroke-linejoin="round"
                    stroke-width="2"
                    d="M2.458 12C3.732 7.943 7.523 5 12 5c4.478 0 8.268 2.943 9.542 7-1.274 4.057-5.064 7-9.542 7-4.477 0-8.268-2.943-9.542-7z"
                  ></path>
                </svg>
              </button>
            </div>

            <div>
              <label for="management" class="font-medium text-gray-700">
                الإدارة
              </label>

              <div class="relative">
                <button
                  @click="departmentselect = !departmentselect"
                  @keyup.space.prevent
                  id="department"
                  class="
                  text-right
                  block
                  mt-2
                  w-full
                  rounded-md
                  h-8
                  border
                  text-sm
                  bg-white
                  border-gray-300
                  hover:shadow-sm
                  focus:outline-none focus:border-gray-300
                  p-2
                "
                >

                <input

                          @click="departmentNameSelected='',departmentIdSelected=''"
                          v-model="departmentNameSelected"
                          type="text"
                          class="h-6 w-full"
                        />

                  <!-- {{ departmentNameSelected }} -->
                </button>

                <div
                  v-if="departmentselect"
                  class="
                  border
                  text-sm
                  bg-white
                  border-gray-300
                  p-2
                  absolute
                  w-full
                  z-20
                  shadow
                  h-24
                  overflow-y-scroll
                  rounded-b-md
                "
                >
                  <button
                    class="block focus:outline-none w-full my-1 text-right"
                    @click="
                      selectdepartment(
                        department.id,
                        department.departmentName
                      );
                      departmentselect = !departmentselect;
                    "
                    v-for="department in filterByTerm1"
                    :key="department.id"
                  >
                    {{ department.departmentName }}
                  </button>
                </div>
              </div>
            </div>

            <div>
              <span class="font-medium text-gray-700">حالة الحساب</span>

              <div class="flex items-center mt-2 justify-around">
                <div class="flex items-center">
                  <input
                    id="active"
                    type="radio"
                    class="h-4 w-4 border-gray-300"
                    value="true"
                    v-model="state1"
                  />

                  <label
                    for="active"
                    class="mr-3 text-sm font-medium text-gray-700"
                  >
                    مفعل
                  </label>
                </div>

                <div class="flex items-center">
                  <input
                    id="deactive"
                    type="radio"
                    class="h-4 w-4"
                    value=""
                    v-model="state1"
                  />

                  <label
                    for="deactive"
                    class="mr-3 text-sm font-medium text-gray-700"
                  >
                    غير مفعل
                  </label>
                </div>
              </div>
            </div>

            <div>
              <label for="roles" class="font-medium text-gray-700">
                الصلاحيات
              </label>

              <div class="relative">
                <button
                  @click="roleselect = !roleselect"
                  id="roles"
                  class="
                  overflow-hidden
                  text-right
                  block
                  mt-2
                  w-full
                  rounded-md
                  h-10
                  border
                  bg-white
                  border-gray-200
                  hover:shadow-sm
                  focus:outline-none focus:border-gray-300
                  p-2
                "
                >
                  {{ roleNameselected }}
                </button>

                <div
                  v-if="roleselect"
                  class="
                  border
                  text-sm
                  bg-white
                  border-gray-200
                  p-2
                  absolute
                  w-full
                  z-20
                  shadow
                  h-36
                  overflow-y-scroll
                  rounded-b-md
                "
                >
                  <button
                    class="block focus:outline-none w-full my-1 text-right"
                    @click="
                      selectrole(role.roleId, role.name, index);
                      roleselect = !roleselect;
                    "
                    v-for="(role, index) in roles"
                    :key="role.roleId"
                  >
                    {{ role.name }}
                  </button>
                </div>
              </div>
            </div>

            <div>
              <span class="font-medium text-gray-700">الصلاحيات المتاحة</span>

              <div
                class="
                mt-2
                w-full
                max-h-40
                overflow-y-scroll
                grid grid-cols-2
                gap-2
                bg-white
                shadow-sm
                rounded-md
                px-1
              "
              >
                <span v-if="!pirms[0]" class="h-10"></span>

                <div
                  class="
                  flex
                  border
                  items-center
                  text-center
                  justify-around
                  border-green-300
                  rounded-md
                  p-1
                "
                  v-for="pirm in pirms"
                  :key="pirm.roleId"
                >
                  <span class="px-2 w-full p-1">{{ pirm.name }}</span>

                  <button
                    @click="remove_role(pirm.name, pirm.roleId)"
                    class="mr-1 ml-2 p-1 rounded-full"
                  >
                    <svg
                      aria-hidden="true"
                      focusable="false"
                      data-prefix="far"
                      data-icon="times-circle"
                      class="
                      w-5
                      h-5
                      stroke-current
                      text-red-400
                      hover:text-red-500
                      duration-200
                    "
                      role="img"
                      xmlns="http://www.w3.org/2000/svg"
                      viewBox="0 0 512 512"
                    >
                      <path
                        fill="currentColor"
                        d="M256 8C119 8 8 119 8 256s111 248 248 248 248-111 248-248S393 8 256 8zm0 448c-110.5 0-200-89.5-200-200S145.5 56 256 56s200 89.5 200 200-89.5 200-200 200zm101.8-262.2L295.6 256l62.2 62.2c4.7 4.7 4.7 12.3 0 17l-22.6 22.6c-4.7 4.7-12.3 4.7-17 0L256 295.6l-62.2 62.2c-4.7 4.7-12.3 4.7-17 0l-22.6-22.6c-4.7-4.7-4.7-12.3 0-17l62.2-62.2-62.2-62.2c-4.7-4.7-4.7-12.3 0-17l22.6-22.6c4.7-4.7 12.3-4.7 17 0l62.2 62.2 62.2-62.2c4.7-4.7 12.3-4.7 17 0l22.6 22.6c4.7 4.7 4.7 12.3 0 17z"
                      ></path>
                    </svg>
                  </button>
                </div>
              </div>
            </div>
          </div>

          <button
            v-if="!isedit"
            class="
            mx-auto
            w-96
            bg-green-700
            text-green-50
            rounded-md
            py-2
            border border-green-300
            hover:bg-green-800
            focus:outline-none
            flex
            items-center
            justify-center
            col-span-2
            mt-4
          "
            @click="add_user()"
          >
            <svg
              class="h-5 w-5 ml-1 text-white block"
              fill="none"
              stroke="currentColor"
              viewBox="0 0 24 24"
              xmlns="http://www.w3.org/2000/svg"
            >
              <path
                stroke-linecap="round"
                stroke-linejoin="round"
                stroke-width="2"
                d="M9 13h6m-3-3v6m-9 1V7a2 2 0 012-2h6l2 2h6a2 2 0 012 2v8a2 2 0 01-2 2H5a2 2 0 01-2-2z"
              ></path>
            </svg>

            <span class="text-sm font-bold block">حفظ</span>
          </button>

          <div v-if="isedit" class="flex justify-end ml-6">
            <button
              type="button"
              id="edit"
              @click="edit_user()"
              class="
              mx-auto
              w-96
              bg-green-700
              text-green-50
              rounded-md
              py-2
              border border-green-300
              hover:bg-green-800
              focus:outline-none
              flex
              items-center
              justify-center
              col-span-2
              mt-4
            "
            >
              <!-- onclick="change();" -->
              <svg
                class="w-4 h-4 stroke-current text-white ml-2 fill-current"
                version="1.1"
                id="Capa_1"
                xmlns="http://www.w3.org/2000/svg"
                xmlns:xlink="http://www.w3.org/1999/xlink"
                x="0px"
                y="0px"
                viewBox="0 0 477.873 477.873"
                style="enable-background: new 0 0 477.873 477.873"
                xml:space="preserve"
              >
                <g>
                  <g>
                    <path
                      d="M392.533,238.937c-9.426,0-17.067,7.641-17.067,17.067V426.67c0,9.426-7.641,17.067-17.067,17.067H51.2
                                        c-9.426,0-17.067-7.641-17.067-17.067V85.337c0-9.426,7.641-17.067,17.067-17.067H256c9.426,0,17.067-7.641,17.067-17.067
                                        S265.426,34.137,256,34.137H51.2C22.923,34.137,0,57.06,0,85.337V426.67c0,28.277,22.923,51.2,51.2,51.2h307.2
                                        c28.277,0,51.2-22.923,51.2-51.2V256.003C409.6,246.578,401.959,238.937,392.533,238.937z"
                    ></path>
                  </g>
                </g>
                <g>
                  <g>
                    <path
                      d="M458.742,19.142c-12.254-12.256-28.875-19.14-46.206-19.138c-17.341-0.05-33.979,6.846-46.199,19.149L141.534,243.937
                                        c-1.865,1.879-3.272,4.163-4.113,6.673l-34.133,102.4c-2.979,8.943,1.856,18.607,10.799,21.585
                                        c1.735,0.578,3.552,0.873,5.38,0.875c1.832-0.003,3.653-0.297,5.393-0.87l102.4-34.133c2.515-0.84,4.8-2.254,6.673-4.13
                                        l224.802-224.802C484.25,86.023,484.253,44.657,458.742,19.142z M434.603,87.419L212.736,309.286l-66.287,22.135l22.067-66.202
                                        L390.468,43.353c12.202-12.178,31.967-12.158,44.145,0.044c5.817,5.829,9.095,13.72,9.12,21.955
                                        C443.754,73.631,440.467,81.575,434.603,87.419z"
                    ></path>
                  </g>
                </g>
              </svg>
              تعديل
            </button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import asideComponent from "@/components/asideComponent.vue";
import logout from "@/components/logout.vue";
export default {
  name: "Add",

  mounted() {
    if (localStorage.getItem("AY_LW") == null || localStorage.getItem("AY_LW") !=29 || localStorage.getItem("chrome")!=17) {
      this.$router.push("/");
    }
    this.GetAllDepartments();
    this.GetAllRoles();

    if (this.$route.params.id) {
      this.isedit = true;
      this.GetUserById();
      this.departmentselect = false;
    }
  },

  components: {
    asideComponent,
    logout,
  },

  data() {
    return {
      departments: [],
      departmentselect: false,
      departmentNameSelected: "اختر الإدارة",
      departmentIdSelected: "",

      isedit: false,

      aa: null,

      mac1:"",
      mac2:"",

      UserNet: "",
      UserName: "",
      pass: null,
      num: null,
      mangement: "1",
      state1: "true",
      pirms: [],
      roles: [],
      roles1: [],

      roleId1: null,
      role: "",
      roleselect: false,
      roleNameselected: "اختر الصلاحيات",
      roleIdselected: "",

      addsuccess: "",
      editesuccess: "",
      isaddsuccess: false,
      iseditesuccess: false,

      fieldtyp: "password",
      pass_true: true,
      confir_pass: "",

      national_valid: false,
      mac1_valid: false,
      mac2_valid: false,
      username_valid: false,

      testarry:[],
    };
  },

  watch: {
    pass: function() {
      if (this.confir_pass != "" && this.pass != this.confir_pass) {
        this.pass_true = false;
      } else {
        this.pass_true = true;
      }
    },

    confir_pass: function() {
      if (this.confir_pass != "" && this.pass != this.confir_pass) {
        this.pass_true = false;
      } else {
        this.pass_true = true;
      }
    },

    num: function() {
      if (this.num.length != 12 && this.num.length != 0) {
        this.national_valid = true;
      } else {
        this.national_valid = false;
      }
    },

    mac1: function() {
      if (this.mac1.length != 17 && this.mac1.length != 0) {
        this.mac1_valid = true;
      } else {
        this.mac1_valid = false;
      }
    },

    mac2: function() {
      if (this.mac2.length != 17 && this.mac2.length != 0) {
        this.mac2_valid = true;
      } else {
        this.mac2_valid = false;
      }
    },



    UserName: function() {
      if (this.UserName.length < 12 && this.UserName.length != 0) {
        this.username_valid = true;
      } else {
        this.username_valid = false;
      }
    },
  },

  computed: {

  filterByTerm1() {
      return this.departments.filter((department) => {
        return department.departmentName.includes(this.departmentNameSelected);
      });
    },
  

  },

  methods: {



    // empty(){


    //   if(this.departmentIdSelected=='')
      
    //   {this.departmentNameSelected=''}
    // },



    GetAllDepartments() {
      this.$http.mailService
        .AllDepartments()
        .then((res) => {
          this.departments = res.data;
        })
        .catch((err) => {
          console.log(err);
        });
    },

    GetAllRoles() {
      this.$http.mailService
        .GetAllRoles()
        .then((res) => {
          this.roles = res.data;
        })
        .catch((err) => {
          console.log(err);
        });
    },

    selectdepartment(id, name) {
      this.departmentNameSelected = name;
      this.departmentIdSelected = id;
    },

    selectrole(id, name,index) {

      this.index=index;
      this.roleNameselected = name;
      this.roleIdselected = id;
      var  role_is_exist=false;


      if(id==100){

        
        for(var d=0;d<this.roles.length;d++){

          if(this.roles[d].roleId!=100){

            for (var c = 0; c < this.pirms.length; c++) {

            if(this.pirms[c].name==this.roles[d].name){

              role_is_exist=true;
              break;

   
               }

           
              }

              if(!role_is_exist){
              this.pirms.push(this.roles[d]);
              
              }
          }

        }
       
      }


    else{
        
          

          for (var i = 0; i < this.pirms.length; i++) {

          if(this.pirms[i].name==name){

            role_is_exist=true;
              break;

               
          }
        }


          if(!role_is_exist){

           
          this.pirms.push({
        roleId: id,
        name: name,

      });

          }
        
      
    

      //this.roles.splice(index, 1);

        }
        this.roleNameselected = "اختر الصلاحيات";
    },

    remove_role(name, id) {
      const index = this.pirms.findIndex((element) => {
        if (element.roleId === id) {
          return true;
        }
      });
      this.pirms.splice(index, 1);

      // this.roles.push({
      //   roleId: id,
      //   name: name,
      // });
    },

    add_user() {
      if (
        this.confir_pass != "" &&
        this.pass_true &&
        !this.national_valid &&
        !this.username_valid &&
        this.pirms.length != 0 &&
        this.departmentIdSelected != "" &&
        !this.mac1_valid &&
        !this.mac2_valid&&
        this.mac1!=""
      ) {
        for (var i = 0; i < this.pirms.length; i++) {
          this.roles1.push(this.pirms[i].roleId);
        }

        var user = {
          Administrator: {
            Username: this.UserName,
            Password: this.pass,
            userNetwork: this.UserNet,
            nationalNumber: this.num,
            DepartmentId: Number(this.departmentIdSelected),

            FirstMACAddress: this.mac1,
            SecandMACAddress: this.mac2,

            state: Boolean(this.state1),
          },

          Listrole: this.roles1,

          currentUser: Number(localStorage.getItem("AY_LW")),
        };

        this.$http.usersService
          .Add_user(user)
          .then((res) => {
            setTimeout(() => {
              this.addsuccess = res.data.message;
              this.isaddsuccess = true;
              this.$router.push("/show");
            }, 201);
          })
          .catch(() => {
            setTimeout(() => {
              this.addsuccess =
                "فشلت عملية الإضافة الرجاء التأكد من البيانات وإعادة المحاولة";
              this.isaddsuccess = true;
            }, 500);
          });
      } else {
        this.addsuccess =
          "فشلت عملية الإضافة الرجاء التأكد من البيانات وإعادة المحاولة";
        this.isaddsuccess = true;
      }
    },

    edit_user() {
      if (
        this.confir_pass != "" &&
        this.pass_true &&
        !this.national_valid &&
        !this.username_valid &&
        this.pirms.length != 0 &&
        this.departmentIdSelected != "" &&
        !this.mac1_valid &&
        !this.mac2_valid&&
        this.mac1!=""
      ) 
      
      
      {
        this.roles1 = [];
        for (var i = 0; i < this.pirms.length; i++) {
          this.roles1.push(this.pirms[i].roleId);
        }

        var user = {
          Administrator: {
            UserId: this.$route.params.id,
            Username: this.UserName,
            Password: this.pass,
            userNetwork: this.UserNet,
            nationalNumber: this.num,
            DepartmentId: Number(this.departmentIdSelected),
            FirstMACAddress: this.mac1,
            SecandMACAddress: this.mac2,

            state: Boolean(this.state1),
          },

          Listrole: this.roles1,

          currentUser: Number(localStorage.getItem("AY_LW")),
        };

        this.$http.usersService
          .Edite_user(user)
          .then((res) => {
            setTimeout(() => {
              this.editesuccess = res.data.message;
              this.iseditesuccess = true;
              this.GetUserById();
            }, 201);
            console.log(res.data.message);
          })
          .catch(() => {
            setTimeout(() => {
              this.editesuccess =
                "فشلت عملية التعديل الرجاء التأكد من البيانات وإعادة المحاولة";
              this.iseditesuccess = true;
            }, 500);
          });
      } else {
        this.editesuccess =
          "فشلت عملية التعديل الرجاء التأكد من البيانات وإعادة المحاولة";
        this.iseditesuccess = true;
      }
    },

    GetUserById() {
      this.$http.usersService
        .GetUserById(this.$route.params.id)
        .then((res) => {
         
          this.UserNet = res.data.administrator.userNetwork;
          this.UserName = res.data.administrator.userName;
          this.num = res.data.administrator.nationalNumber;
          this.pass = res.data.administrator.password;
          this.confir_pass = res.data.administrator.password;
          this.departmentIdSelected = res.data.administrator.departmentId;
          this.departmentNameSelected = this.$route.params.departmentName11;
          this.mac1=res.data.administrator.firstMACAddress;
          this.mac2=res.data.administrator.secandMACAddress;

          if (res.data.administrator.state) {
            this.state1 = res.data.administrator.state;
          } else {
            this.state1 = "";
          }

          this.pirms = res.data.listrole;

          // for (var i = 0; i < this.pirms.length; i++)
          //   //   console.log(this.roles[i]);
          //   for (var j = 0; j < this.roles.length; j++) {
          //     if (this.roles[j].roleId == this.pirms[i].roleId) {
          //       this.roles.splice(j, 1);
          //     }
          //   }
          //    console.log(indexs);
        })
        .catch((err) => {
          console.log(err);
        });
    },

    switch_field() {
      this.fieldtyp = this.fieldtyp === "password" ? "text" : "password";
    },
  },
};
</script>

<style></style>
