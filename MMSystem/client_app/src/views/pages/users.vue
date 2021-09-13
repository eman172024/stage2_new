<template>
  <div class="antialiased h-screen flex overflow-hidden bg-gray-100">
    <aside class="h-screen">
      <asidebar></asidebar>
    </aside>
    <div class="flex-1 overflow-auto focus:outline-none" tabindex="0">
      <navaca></navaca>

      <main class="max-w-4xl mx-auto mt-8 pb-8 px-4 space-y-8 divide-y divide-gray-200">
        <div class="pt-8 max-w-2xl mx-auto">
          <h3 class="text-lg leading-6 font-medium text-gray-900">
            إضافة مستخدم جديد
          </h3>
          <div class="mt-6 grid grid-cols-1 gap-y-6 gap-x-4 sm:grid-cols-6">
            <div class="sm:col-span-6">
              <label
                for="fullName"
                class="block text-sm font-medium text-gray-700"
              >
                الإسم
              </label>
              <div class="mt-1">
                <input
                  v-model="fullName"
                  type="text"
                  id="fullName"
                  autocomplete="given-name"
                  class="h-10 shadow-sm focus:ring-cyan-700 focus:border-cyan-700 block w-full sm:text-sm border-gray-300 rounded-md"
                  required=""
                />
              </div>
              <span id="errorname"></span>
            </div>
            <div class="sm:col-span-6">
              <label
                for="email"
                class="block text-sm font-medium text-gray-700"
              >
                البريد الإلكتروني
              </label>
              <div class="mt-1">
                <input
                  v-model="email"
                  type="email"
                  id="email"
                  class="h-10 shadow-sm focus:ring-cyan-700 focus:border-cyan-700 block w-full sm:text-sm border-gray-300 rounded-md"
                  required=""
                />
              </div>
            </div>
            <div class="sm:col-span-3">
              <label
                for="password"
                class="block text-sm font-medium text-gray-700"
              >
                كلمة المرور
              </label>
              <div class="mt-1">
                <input
                  v-model="password"
                  type="password"
                  id="password"
                  class="h-10 shadow-sm focus:ring-cyan-700 focus:border-cyan-700 block w-full sm:text-sm border-gray-300 rounded-md"
                  required=""
                />
              </div>
            </div>
            <div class="sm:col-span-3">
              <label
                for="repeatPassword"
                class="block text-sm font-medium text-gray-700"
              >
                تأكيد كلمة المرور
              </label>
              <div class="mt-1">
                <input
                  v-model="repeatPassword"
                  type="password"
                  id="repeatPassword"
                  class="h-10 shadow-sm focus:ring-cyan-700 focus:border-cyan-700 block w-full sm:text-sm border-gray-300 rounded-md"
                  required=""
                />
                <span id="errorpass"></span>
              </div>
            </div>
            <div class="sm:col-span-6">
              <label
                for="phone"
                class="block text-sm font-medium text-gray-700"
              >
                رقم الهاتف
              </label>
              <div class="mt-1">
                <input  
                  v-model="PhoneNumber"
                  type="tel"
                  id="phone"
                  class="h-10 shadow-sm focus:ring-cyan-700 focus:border-cyan-700 block w-full sm:text-sm border-gray-300 rounded-md"
                  required=""
                />
              </div>
            </div>
            <div class="sm:col-span-6">
              <label
                for="type"
                class="shadow-sm focus:ring-cyan-700 focus:border-cyan-700 block w-full sm:text-sm border-gray-300 rounded-md"
              >
                الصلاحية
              </label>
              <div class="mt-1">
                <select v-model="role" class="h-10 shadow-sm focus:ring-cyan-700 focus:border-cyan-700 block w-full sm:text-sm border-gray-300 rounded-md">
                  <option value="1">
                    رئيس الهيئة
                  </option>

                  <option value="2">
                    مكتب الرئيس
                  </option>

                  <option value="2">
                    الأمين الإداري
                  </option>
                
                </select>
              </div>
            </div>
          </div>


          <div class="pt-5 flex justify-between items-center">
          <button class="bg-white py-2 px-4 border border-gray-300 rounded-md shadow-sm text-sm font-medium text-gray-700 hover:bg-gray-50 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-cyan-700">
            جديد
          </button>

          <div class="">
            <button
              v-if="saveButton"
              @click="submit()"
              class="mr-3 inline-flex justify-center py-2 px-4 border border-transparent shadow-sm text-sm font-medium rounded-md text-white bg-cyan-600 hover:bg-cyan-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-cyan-700"
              id="senddata"
            >
              إضافة
            </button>

            <button
            v-if="updataButton"
              @click="updateUserInfo()"
              name="Edit"
              class="mr-3 inline-flex justify-center py-2 px-4 border border-transparent shadow-sm text-sm font-medium rounded-md text-white bg-cyan-600 hover:bg-cyan-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-cyan-700"
            >
              تعديل
            </button>
          </div>
        </div>
        
        </div>





        




        <div class="flex flex-col ">
            <div class="shadow overflow-hidden border-b border-gray-200 sm:rounded-lg mt-16">
              <div class="bg-gray-50 flex items-center">
                <div
                  scope="col"
                  class="w-3/12 px-6 py-3 text-right text-xs font-medium text-gray-500 uppercase tracking-wider"
                >
                  الاسم
                </div>
                <div
                  scope="col"
                  class="w-3/12 px-6 py-3 text-right text-xs font-medium text-gray-500 uppercase tracking-wider"
                >
                  البريد الإلكتروني
                </div>
                <div
                  scope="col"
                  class="w-3/12 px-6 py-3 text-right text-xs font-medium text-gray-500 uppercase tracking-wider"
                >
                  رقم الهاتف
                </div>
                <div
                  scope="col"
                  class="w-2/12 px-6 py-3 text-right text-xs font-medium text-gray-500 uppercase tracking-wider"
                >
                  الصفة
                </div>

                <div scope="col" class="w-1/12 relative px-6 py-3 flex justify-between items-center">
                  <span class="sr-only">تعديل</span>
                  <span class="sr-only">حذف</span>
                </div>
              </div>



              <div v-for="(user, index) in users" :key="index" class="flex items-center border-b border-gray-300">
                <div class="w-3/12 px-6 py-4 whitespace-nowrap text-sm font-medium text-gray-900">
                  {{ user.fullName }}
                </div>
                <div class="w-3/12 px-6 py-4 whitespace-nowrap text-sm text-gray-500 truncate">
                  {{ user.email }}
                </div>
                <div class="w-3/12 px-6 py-4 whitespace-nowrap text-sm text-gray-500 truncate">
                  {{ user.phoneNumber }}
                </div>
                <div class="w-2/12 px-6 py-4 whitespace-nowrap text-sm text-gray-500 truncate">
                  {{ user.role }}
                </div>

                <div class="w-1/12 pl-4 py-4 flex justify-between items-center">
                  <button class="" @click="GetUserForEdit(user.userId)" type="button">
                    <svg class="w-4 h-4" height="401pt" viewBox="0 -1 401.52289 401" width="401pt" xmlns="http://www.w3.org/2000/svg"><path d="m370.589844 250.972656c-5.523438 0-10 4.476563-10 10v88.789063c-.019532 16.5625-13.4375 29.984375-30 30h-280.589844c-16.5625-.015625-29.980469-13.4375-30-30v-260.589844c.019531-16.558594 13.4375-29.980469 30-30h88.789062c5.523438 0 10-4.476563 10-10 0-5.519531-4.476562-10-10-10h-88.789062c-27.601562.03125-49.96875 22.398437-50 50v260.59375c.03125 27.601563 22.398438 49.96875 50 50h280.589844c27.601562-.03125 49.96875-22.398437 50-50v-88.792969c0-5.523437-4.476563-10-10-10zm0 0"/><path d="m376.628906 13.441406c-17.574218-17.574218-46.066406-17.574218-63.640625 0l-178.40625 178.40625c-1.222656 1.222656-2.105469 2.738282-2.566406 4.402344l-23.460937 84.699219c-.964844 3.472656.015624 7.191406 2.5625 9.742187 2.550781 2.546875 6.269531 3.527344 9.742187 2.566406l84.699219-23.464843c1.664062-.460938 3.179687-1.34375 4.402344-2.566407l178.402343-178.410156c17.546875-17.585937 17.546875-46.054687 0-63.640625zm-220.257812 184.90625 146.011718-146.015625 47.089844 47.089844-146.015625 146.015625zm-9.40625 18.875 37.621094 37.625-52.039063 14.417969zm227.257812-142.546875-10.605468 10.605469-47.09375-47.09375 10.609374-10.605469c9.761719-9.761719 25.589844-9.761719 35.351563 0l11.738281 11.734375c9.746094 9.773438 9.746094 25.589844 0 35.359375zm0 0"/></svg>
                  </button>

                  <button class="" @click="DeleteUser(user.userId, index)" type="button">
                    <svg
                      class="w-4 h-4"
                      height="427pt"
                      viewBox="-40 0 427 427.00131"
                      width="427pt"
                      xmlns="http://www.w3.org/2000/svg"
                    >
                      <path
                        d="m232.398438 154.703125c-5.523438 0-10 4.476563-10 10v189c0 5.519531 4.476562 10 10 10 5.523437 0 10-4.480469 10-10v-189c0-5.523437-4.476563-10-10-10zm0 0"
                      ></path>
                      <path
                        d="m114.398438 154.703125c-5.523438 0-10 4.476563-10 10v189c0 5.519531 4.476562 10 10 10 5.523437 0 10-4.480469 10-10v-189c0-5.523437-4.476563-10-10-10zm0 0"
                      ></path>
                      <path
                        d="m28.398438 127.121094v246.378906c0 14.5625 5.339843 28.238281 14.667968 38.050781 9.285156 9.839844 22.207032 15.425781 35.730469 15.449219h189.203125c13.527344-.023438 26.449219-5.609375 35.730469-15.449219 9.328125-9.8125 14.667969-23.488281 14.667969-38.050781v-246.378906c18.542968-4.921875 30.558593-22.835938 28.078124-41.863282-2.484374-19.023437-18.691406-33.253906-37.878906-33.257812h-51.199218v-12.5c.058593-10.511719-4.097657-20.605469-11.539063-28.03125-7.441406-7.421875-17.550781-11.5546875-28.0625-11.46875h-88.796875c-10.511719-.0859375-20.621094 4.046875-28.0625 11.46875-7.441406 7.425781-11.597656 17.519531-11.539062 28.03125v12.5h-51.199219c-19.1875.003906-35.394531 14.234375-37.878907 33.257812-2.480468 19.027344 9.535157 36.941407 28.078126 41.863282zm239.601562 279.878906h-189.203125c-17.097656 0-30.398437-14.6875-30.398437-33.5v-245.5h250v245.5c0 18.8125-13.300782 33.5-30.398438 33.5zm-158.601562-367.5c-.066407-5.207031 1.980468-10.21875 5.675781-13.894531 3.691406-3.675781 8.714843-5.695313 13.925781-5.605469h88.796875c5.210937-.089844 10.234375 1.929688 13.925781 5.605469 3.695313 3.671875 5.742188 8.6875 5.675782 13.894531v12.5h-128zm-71.199219 32.5h270.398437c9.941406 0 18 8.058594 18 18s-8.058594 18-18 18h-270.398437c-9.941407 0-18-8.058594-18-18s8.058593-18 18-18zm0 0"
                      ></path>
                      <path
                        d="m173.398438 154.703125c-5.523438 0-10 4.476563-10 10v189c0 5.519531 4.476562 10 10 10 5.523437 0 10-4.480469 10-10v-189c0-5.523437-4.476563-10-10-10zm0 0"
                      ></path>
                    </svg>
                  </button>
                </div>
              </div>
              
            </div>
          </div>

      </main>
    </div>

    <div
      v-if="showAlert"
      class="absolute inset-0 h-full w-full bg-gray-700 bg-opacity-75 flex justify-center items-center"
    >
      <div v-if="loading" class="h-64 flex justify-center items-center">
        <svg class="w-10 h-w-10 rounded-full" viewBox="0 0 38 38" stroke="#fff">
          <g fill="none">
            <g transform="translate(1 1)" stroke-width="2">
              <circle
                stroke="#E1E7EC"
                stroke-opacity=".5"
                cx="18"
                cy="18"
                r="18"
              />
              <path stroke="black" d="M36 18c0-9.94-8.06-18-18-18">
                <animateTransform
                  attributeName="transform"
                  type="rotate"
                  from="0 18 18"
                  to="360 18 18"
                  dur="1s"
                  repeatCount="indefinite"
                />
              </path>
            </g>
          </g>
        </svg>
      </div>

      <div v-else class="w-1/3 bg-cool-gray-100 rounded">
        <div
          v-if="Successed"
          class="bg-white p-7 w-full max-w-lg rounded-xl cursor-auto z-50"
        >
          <div class="flex justify-end">
            <button @click="showAlert = false" class="focus:outline-none">
              <svg
                width="24"
                height="24"
                viewBox="0 0 24 24"
                fill="none"
                xmlns="http://www.w3.org/2000/svg"
              >
                <path
                  fill-rule="evenodd"
                  clip-rule="evenodd"
                  d="M17.3941 19.5531L11.999 14.158L6.60398 19.5531C6.00806 20.149 5.04188 20.149 4.44596 19.5531C3.85004 18.9571 3.85004 17.991 4.44596 17.395L9.84101 12L4.44596 6.60496C3.85004 6.00904 3.85004 5.04286 4.44596 4.44694C5.04188 3.85102 6.00806 3.85102 6.60398 4.44694L11.999 9.84198L17.3941 4.44694C17.99 3.85102 18.9562 3.85102 19.5521 4.44694C20.148 5.04286 20.148 6.00904 19.5521 6.60496L14.157 12L19.5521 17.395C20.148 17.991 20.148 18.9571 19.5521 19.5531C18.9562 20.149 17.99 20.149 17.3941 19.5531Z"
                  fill="#676767"
                />
              </svg>
            </button>
          </div>

          <div class="flex justify-center mt-4">
            <svg
              width="60"
              height="60"
              viewBox="0 0 80 80"
              fill="none"
              xmlns="http://www.w3.org/2000/svg"
            >
              <circle cx="40" cy="40" r="38" stroke="black" stroke-width="4" />
              <path
                fill-rule="evenodd"
                clip-rule="evenodd"
                d="M56.3149 28.7293C57.2486 29.6808 57.225 31.2002 56.2621 32.123L36.2264 51.323C35.2843 52.2257 33.7871 52.2257 32.8451 51.323L23.7379 42.5957C22.775 41.673 22.7514 40.1535 23.6851 39.202C24.6188 38.2504 26.1563 38.227 27.1192 39.1498L34.5357 46.2569L52.8808 28.677C53.8437 27.7543 55.3812 27.7777 56.3149 28.7293Z"
                fill="black"
              />
            </svg>
          </div>

          <div class="text-center mt-8">
            <p class="text-2xl font-bold">{{ addSuccessed }}</p>
            <!-- <p class="text-sm mt-2">Permanently deleted</p> -->
          </div>

          <div @click="showAlert = false" class="mt-10 flex justify-center">
            <button
              class="bg-black text-center text-xs md:text-sm font-normal tracking-widest w-32 py-3 text-white rounded focus:outline-none hover:bg-white hover:text-black border hover:border-black transform duration-700"
            >
              موافق
            </button>
          </div>
        </div>

        <div
          v-else
          class="bg-white p-7 w-full max-w-lg rounded-xl cursor-auto z-50"
        >
          <div class="flex justify-end">
            <button @click="showAlert = false" class="focus:outline-none">
              <svg
                width="24"
                height="24"
                viewBox="0 0 24 24"
                fill="none"
                xmlns="http://www.w3.org/2000/svg"
              >
                <path
                  fill-rule="evenodd"
                  clip-rule="evenodd"
                  d="M17.3941 19.5531L11.999 14.158L6.60398 19.5531C6.00806 20.149 5.04188 20.149 4.44596 19.5531C3.85004 18.9571 3.85004 17.991 4.44596 17.395L9.84101 12L4.44596 6.60496C3.85004 6.00904 3.85004 5.04286 4.44596 4.44694C5.04188 3.85102 6.00806 3.85102 6.60398 4.44694L11.999 9.84198L17.3941 4.44694C17.99 3.85102 18.9562 3.85102 19.5521 4.44694C20.148 5.04286 20.148 6.00904 19.5521 6.60496L14.157 12L19.5521 17.395C20.148 17.991 20.148 18.9571 19.5521 19.5531C18.9562 20.149 17.99 20.149 17.3941 19.5531Z"
                  fill="#676767"
                />
              </svg>
            </button>
          </div>

          <div class="flex justify-center mt-4">
            <svg
              width="60"
              height="60"
              viewBox="0 0 60 60"
              fill="none"
              xmlns="http://www.w3.org/2000/svg"
            >
              <path
                d="M30 58.5C45.7401 58.5 58.5 45.7401 58.5 30C58.5 14.2599 45.7401 1.5 30 1.5C14.2599 1.5 1.5 14.2599 1.5 30C1.5 45.7401 14.2599 58.5 30 58.5Z"
                stroke="black"
                stroke-width="3"
              />
              <path
                d="M38 22L22 38"
                stroke="black"
                stroke-width="3"
                stroke-linecap="round"
                stroke-linejoin="round"
              />
              <path
                d="M22 22L38 38"
                stroke="black"
                stroke-width="3"
                stroke-linecap="round"
                stroke-linejoin="round"
              />
            </svg>
          </div>

          <div class="text-center mt-8">
            <p class="text-2xl font-bold">{{ addErorr }}</p>
            <!-- <p class="text-sm mt-2">Permanently deleted</p> -->
          </div>

          <div class="mt-10 flex justify-center">
            <button
              @click="showAlert = false"
              class="border border-black text-center text-xs md:text-sm font-normal tracking-widest w-32 py-3 text-black rounded focus:outline-none hover:bg-black hover:text-white hover:border-black transform duration-700"
            >
              إعادة المحاولة
            </button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import asidebar from "@/components/asidebar.vue";
import navaca from "@/components/nav.vue";
export default {
  components: {
    asidebar,
    navaca,
  },

  data() {
    return {
      fullName: "",
      email: "",
      password: "",
      repeatPassword: "",
      PhoneNumber: "",
      role: "",

      userId: "",


      users: [],
      saveButton: true,
      updataButton: false,

      showAlert: false,
      loading: false,
      Successed: false,
      addSuccessed: "",
      addErorr: null,
    };
  },
  mounted() {
    this.GetUsers();
  },
  methods: {
    GetUsers() {
      this.$http.userService
        .GetUsers()
        .then((res) => {
          this.users = res.data.result.users;
        })
        .catch((err) => {
          console.log(err);
        });
    },

    submit() {
      this.showAlert = true;
      this.loading = true;

      var userInfo = {
        fullName: this.fullName,
        email: this.email,
        password: this.password,
        PhoneNumber: this.PhoneNumber,
        role: this.role,
      };
      
      this.$http.userService
        .AddUser(userInfo)
        .then((res) => {
          setTimeout(() => {
            this.loading = false;
            this.Successed = true;
            this.addSuccessed = res.data.result.message;
            this.GetUsers();
          }, 500);
        })
        .catch((err) => {
          setTimeout(() => {
            this.loading = false;
            this.Successed = false;
            this.addErorr = err.message;
          }, 500);
        });
    },

    GetUserForEdit(id){
      this.showAlert = true;
      this.loading = true

      this.userId = id
      this.$http.userService.GetUserForEdit(id)
        .then((res) => {
          setTimeout(() => {
              var user = res.data.result

              this.fullName = user.fullName;
              this.email = user.email;
              this.PhoneNumber = user.phoneNumber;
              this.role = user.role;

              this.loading = false;
              this.showAlert = false;

              this.saveButton= false
              this.updataButton= true

          }, 300);
          
        })
        .catch((err) => {
          this.loading = false;
          this.Successed = false;
          this.addErorr = err;
        });
    },

    updateUserInfo(){
      this.showAlert = true;
      this.loading = true;

      var userInfo = {
        userId : this.userId,
        fullName: this.fullName,
        email: this.email,
        password: this.password,
        PhoneNumber: this.PhoneNumber,
        role: this.role,
      };

      this.$http.userService.EditUser(userInfo)
        .then((res) => {
          setTimeout(() => {
            this.loading = false;
            this.Successed = true;
            this.addSuccessed = res.data.result.message;
            this.GetUsers()
          }, 500);
        })
        .catch((err) => {
          setTimeout(() => {
            this.loading = false;
            this.Successed = false;
            this.addErorr = err.message; 
          }, 500);
        });
    },

    DeleteUser(id, index) {
      this.showAlert = true;
      this.loading = true;
      this.$http.userService
        .DeleteUser(Number(id))
        .then((res) => {
          setTimeout(() => {
            this.loading = false;
            this.Successed = true;
            this.users.splice(index, 1);

            this.addSuccessed = res.data.result.message;
            this.GetUsers();
          }, 500);
        })
        .catch((err) => {
          setTimeout(() => {
            this.loading = false;
            this.Successed = false;
            this.addErorr = err.message;
          }, 500);
        });
    },
  },
};
</script>

<style>
</style>