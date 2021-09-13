<template>
  <div class="antialiased h-screen flex overflow-hidden bg-gray-100">
    <aside class="h-screen">
      <asidebar></asidebar>
    </aside>
    <div class="flex-1 overflow-auto focus:outline-none" tabindex="0">
      <navaca></navaca>

      <main class="flex-1 relative pb-8 z-0 overflow-y-auto">
        <!-- Page header -->
        <div class="bg-white shadow">
          <div class="px-4 sm:px-6 lg:max-w-6xl lg:mx-auto lg:px-8">
            <div
              class="py-6 md:flex md:items-center md:justify-between lg:border-t lg:border-gray-200"
            >
              <div class="flex-1 min-w-0">
                <!-- Profile -->
                <div class="flex items-center">
                  <img
                    class="hidden h-16 w-16 rounded-full sm:block"
                    src="../../assets/img/user_icon.jpg"
                    alt=""
                  />
                  <div>
                    <div class="flex items-center">
                      <img
                        class="h-16 w-16 rounded-full sm:hidden"
                        src="../../assets/img/user_icon.jpg"
                        alt=""
                      />
                      <h1
                        class="mr-3 text-2xl font-bold leading-7 text-gray-900 sm:leading-9 sm:truncate"
                      >
                        {{ fullName }}
                      </h1>
                    </div>
                    <dl
                      class="mt-6 flex flex-col sm:ml-3 sm:mt-1 sm:flex-row sm:flex-wrap"
                    >
                      <dt class="sr-only">Account status</dt>
                      <dd
                        class="mt-3 flex items-center text-sm text-gray-500 font-medium sm:mr-2 sm:mt-0 capitalize"
                      >
                        <!-- Heroicon name: check-circle -->
                        <svg
                          class="flex-shrink-0 ml-1.5 h-5 w-5 text-green-400"
                          xmlns="http://www.w3.org/2000/svg"
                          viewBox="0 0 20 20"
                          fill="currentColor"
                          aria-hidden="true"
                        >
                          <path
                            fill-rule="evenodd"
                            d="M10 18a8 8 0 100-16 8 8 0 000 16zm3.707-9.293a1 1 0 00-1.414-1.414L9 10.586 7.707 9.293a1 1 0 00-1.414 1.414l2 2a1 1 0 001.414 0l4-4z"
                            clip-rule="evenodd"
                          />
                        </svg>
                        حساب تم التحقق منه
                      </dd>
                    </dl>
                  </div>
                </div>
              </div>

              <div v-if="role == 2" class="mt-6 flex space-x-3 md:mt-0 md:ml-4">
                <router-link
                  :to="{ name: 'mailOM-create' }"
                  class="inline-flex items-center px-4 py-2 border border-transparent shadow-sm text-sm font-medium rounded-md text-white bg-cyan-600 hover:bg-cyan-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-cyan-500"
                >
                  أضف
                </router-link>
              </div>
            </div>
          </div>
        </div>

        <div class="mt-8">
          <div class="max-w-6xl mx-auto px-4 sm:px-6 lg:px-8">
            <h2 class="text-lg leading-6 font-medium text-gray-900">
              نظرة عامة
            </h2>
            <div class="mt-2 grid grid-cols-1 gap-5 sm:grid-cols-2">
              <!-- Card -->
              <div class="bg-white overflow-hidden shadow rounded-lg">
                <div class="p-5">
                  <div class="flex items-center">
                    <div class="flex-shrink-0">
                      <!-- Heroicon name: scale -->
                      <svg
                        class="h-6 w-6 text-gray-400"
                        xmlns="http://www.w3.org/2000/svg"
                        fill="none"
                        viewBox="0 0 24 24"
                        stroke="currentColor"
                        aria-hidden="true"
                      >
                        <path
                          stroke-linecap="round"
                          stroke-linejoin="round"
                          stroke-width="2"
                          d="M3 6l3 1m0 0l-3 9a5.002 5.002 0 006.001 0M6 7l3 9M6 7l6-2m6 2l3-1m-3 1l-3 9a5.002 5.002 0 006.001 0M18 7l3 9m-3-9l-6-2m0-2v2m0 16V5m0 16H9m3 0h3"
                        />
                      </svg>
                    </div>
                    <div class="mr-5 w-0 flex-1">
                      <dl>
                        <dt class="text-sm font-medium text-gray-500 truncate">
                          بريد لم يرسل
                        </dt>
                        <dd>
                          <div class="text-lg font-bold text-gray-900">1</div>
                        </dd>
                      </dl>
                    </div>
                  </div>
                </div>
                <div class="bg-gray-50 px-5 py-3">
                  <div class="text-sm">
                    <button
                      type="submit"
                      name="btn_replied"
                      class="border-none font-medium text-cyan-700 hover:text-cyan-900"
                    >
                      مشاهدة الكل
                    </button>
                  </div>
                </div>
              </div>

              <div class="bg-white overflow-hidden shadow rounded-lg">
                <div class="p-5">
                  <div class="flex items-center">
                    <div class="flex-shrink-0">
                      <!-- Heroicon name: scale -->
                      <svg
                        class="h-6 w-6 text-gray-400"
                        xmlns="http://www.w3.org/2000/svg"
                        fill="none"
                        viewBox="0 0 24 24"
                        stroke="currentColor"
                        aria-hidden="true"
                      >
                        <path
                          stroke-linecap="round"
                          stroke-linejoin="round"
                          stroke-width="2"
                          d="M3 6l3 1m0 0l-3 9a5.002 5.002 0 006.001 0M6 7l3 9M6 7l6-2m6 2l3-1m-3 1l-3 9a5.002 5.002 0 006.001 0M18 7l3 9m-3-9l-6-2m0-2v2m0 16V5m0 16H9m3 0h3"
                        />
                      </svg>
                    </div>
                    <div class="mr-5 w-0 flex-1">
                      <dl>
                        <dt class="text-sm font-medium text-gray-500 truncate">
                          بريد لم يرسل
                        </dt>
                        <dd>
                          <div class="text-lg font-bold text-gray-900">1</div>
                        </dd>
                      </dl>
                    </div>
                  </div>
                </div>
                <div class="bg-gray-50 px-5 py-3">
                  <div class="text-sm">
                    <button
                      type="submit"
                      name="btn_replied"
                      class="border-none font-medium text-cyan-700 hover:text-cyan-900"
                    >
                      مشاهدة الكل
                    </button>
                  </div>
                </div>
              </div>
            </div>
          </div>

          <h2
            class="max-w-6xl mx-auto mt-8 px-4 text-lg leading-6 font-medium text-gray-900 sm:px-6 lg:px-8"
          >
            أخر الواردات
          </h2>

          <!-- Activity list (smallest breakopoint only) -->
          <div class="shadow sm:hidden">
            <ul
              class="mt-2 divide-y divide-gray-200 overflow-hidden shadow sm:hidden"
            >
              <li>
                <a
                  href="#"
                  id=""
                  class="block px-4 py-4 bg-white hover:bg-gray-50"
                >
                  <span class="flex items-center space-x-4">
                    <span class="flex-1 flex space-x-2 truncate">
                      <span
                        class="flex flex-col text-gray-500 text-sm truncate"
                      >
                        <span class="text-gray-900 font-medium mt-2 pl-4">
                          'mail_id'
                        </span>

                        <span class="truncate"> ['sender_place']; </span>

                        <span class="text-gray-900 font-medium mt-2 pl-4">
                          conclusion']
                        </span>

                        <span
                          class="text-gray-900 font-medium mt-2 bg-green-100"
                        >
                          لم تقرأ من قبل الرئيس
                        </span>

                        <span class="text-gray-900 font-medium mt-2"
                          >create_at</span
                        >
                      </span>
                    </span>

                    <!-- Heroicon name: chevron-right  -->
                    <svg
                      class="flex-shrink-0 h-5 w-5 text-gray-400"
                      width="22"
                      height="22"
                      viewBox="0 0 22 22"
                      fill="none"
                      xmlns="http://www.w3.org/2000/svg"
                    >
                      <path
                        fill-rule="evenodd"
                        clip-rule="evenodd"
                        d="M13.6123 6.24009C13.8035 6.42383 13.9139 6.67598 13.9192 6.94109C13.9245 7.2062 13.8243 7.46257 13.6406 7.65381L10.4141 11.012L13.7724 14.2385C13.9583 14.4234 14.0641 14.6739 14.0671 14.9361C14.07 15.1983 13.9699 15.4512 13.7882 15.6403C13.6066 15.8294 13.3579 15.9395 13.0958 15.947C12.8337 15.9546 12.5791 15.8588 12.3869 15.6805L8.3077 11.7613C8.11651 11.5776 8.00613 11.3255 8.00082 11.0603C7.99552 10.7952 8.09572 10.5389 8.27941 10.3476L12.1986 6.26838C12.3823 6.0772 12.6345 5.96682 12.8996 5.96151C13.1647 5.9562 13.421 6.05641 13.6123 6.24009Z"
                        fill="black"
                      />
                    </svg>
                  </span>
                </a>
              </li>

              <!-- More items... -->
            </ul>
          </div>

          <!-- Activity table (small breakopoint and up) -->
          <div class="hidden sm:block mt-2">
            <div class="max-w-6xl mx-auto px-4 sm:px-6 lg:px-8">
              <div class="flex flex-col mt-2">
                <div
                  class="align-middle min-w-full shadow overflow-hidden sm:rounded-lg"
                >
                  <div class=" ">
                    <ul class="flex">
                      <li
                        class="w-1/12 px-6 py-3 bg-gray-50 text-right text-sm font-medium text-gray-500 uppercase tracking-wider"
                      >
                        رقم الرسالة
                      </li>
                      <li
                        class="w-2/12 px-6 py-3 bg-gray-50 text-right text-sm font-medium text-gray-500 uppercase tracking-wider"
                      >
                        الجهة المرسلة
                      </li>
                      <li
                        class="w-2/12 px-6 py-3 bg-gray-50 text-right text-sm font-medium text-gray-500 uppercase tracking-wider"
                      >
                        ملخص
                      </li>
                      <li
                        class="w-3/12 px-6 py-3 bg-gray-50 text-right text-sm font-medium text-gray-500 uppercase tracking-wider"
                      >
                        الحالة
                      </li>
                      <li
                        class="w-2/12 px-6 py-3 bg-gray-50 text-right text-sm font-medium text-gray-500 uppercase tracking-wider"
                      >
                        تاريخ الارسال
                      </li>
                      <li
                        class="w-2/12 px-6 py-3 bg-gray-50 text-right text-sm font-medium text-gray-500 uppercase tracking-wider"
                      >
                        تاريخ الرد
                      </li>
                    </ul>
                  </div>

                  <div class="bg-white w-full divide-y divide-gray-200">
                    <div v-if="lastMails.length == 0" class="h-52 flex justify-center items-center">
                      لا يوجد بريد 
                    </div>
                    <router-link
                      v-for="(mail, index) in lastMails"
                      :key="index"
                      :to="{
                        name: nameOfRouter,
                        params: { mail: mail.mailId },
                      }"
                      class="flex hover:shadow"
                    >
                      <div
                        class="w-1/12 truncate px-2 md:px-6 py-4 whitespace-nowrap text-gray-900"
                      >
                        {{ mail.mailId }}
                      </div>
                      <div
                        class="w-2/12 truncate px-2 md:px-6 py-4 whitespace-nowrap text-gray-900"
                      >
                        <div class="space-x-2 truncate text-gray-500">
                          {{ mail.sender }}
                        </div>
                      </div>
                      <div
                        :title="mail.sentMessage"
                        class="w-2/12 truncate px-2 md:px-6 py-4 text-right whitespace-nowrap text-gray-900 font-medium"
                      >
                        {{ mail.sentMessage }}
                      </div>
                      <div
                        class="w-3/12 truncate px-2 md:px-6 py-4 whitespace-nowrap text-gray-500"
                      >
                        <span
                          v-if="role == 1"
                          class="inline-flex items-center text- px-2.5 py-0.5 rounded-full text-sm font-medium capitalize"
                          :class="mail.flag | flagColorCC"
                        >
                          {{ mail.flag | flagMassageCC }}
                        </span>
                        <span
                          v-if="role == 2"
                          class="inline-flex items-center text- px-2.5 py-0.5 rounded-full text-sm font-medium capitalize"
                          :class="mail.flag | flagColorOM"
                        >
                          {{ mail.flag | flagMassageOM }}
                        </span>
                      </div>
                      <div
                        class="w-2/12 truncate px-2 md:px-6 py-4 whitespace-nowrap text-gray-500"
                      >
                        {{ mail.createdOn }}
                      </div>
                      <div
                        class="w-2/12 truncate px-2 md:px-6 py-4 whitespace-nowrap text-gray-500"
                      >
                        {{ mail.modifiedOn }}
                      </div>
                    </router-link>
                  </div>
                </div>
              </div>
            </div>
          </div>

         
        </div>
      </main>
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
      filter: {
        pageSize: 4,
        pageNo: 1,
      },
      lastMails: [],

      nameOfRouter: "",

      role: '',
      fullName: '',
      userId: '',
      email: '',
    };
  },
  
  created(){
  },
  mounted() {
    
    setTimeout(() => {
        this.fullName = this.$authenticatedUser.fullName;
        this.role = this.$authenticatedUser.role;
        this.email = this.$authenticatedUser.email;
        this.userId = this.$authenticatedUser.userId;

        if (this.role == 1) {
          this.nameOfRouter = "mailCC";
        } else {
          this.nameOfRouter = "mailOM-edit";
        }
        this.GetLastFiveMail();

    }, 500);

    
  },
  methods: {
    GetLastFiveMail() {
      this.$http.mailService
        .GetMails(this.filter , this.role)
        .then((res) => {
          
          this.lastMails = res.data.result.mails;

            console.log(this.lastMails)
          // this.documents = res.data.result.documents;
        })
        .catch((err) => {
          console.log(err);
        });
    },
  },
};
</script>
