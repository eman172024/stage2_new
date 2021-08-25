<template>
  <div class="antialiased h-screen flex overflow-hidden bg-gray-100">
    <aside class="h-screen">
      <asidebar></asidebar>
    </aside>
    <div class="flex-1 overflow-auto focus:outline-none" tabindex="0">
      <navaca></navaca>

      <main class="flex-1 relative pb-8 z-0 overflow-y-auto">
          <div class="max-w-6xl mx-auto px-4 sm:px-6 lg:px-8 mt-10">
            <h2 class="text-lg leading-6 font-medium text-gray-900">
              أحدث التقرير
            </h2>

            <div class="mt-6 grid grid-cols-1 gap-5 sm:grid-cols-2">
             
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
                          بريد محفوض
                        </dt>
                        <dd>
                          <div class="text-lg font-bold text-gray-900">{{ reports.flagZero }}</div>
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
                          بريد تم إرسالة
                        </dt>
                        <dd>
                          <div class="text-lg font-bold text-gray-900">{{ reports.flagFirst }}</div>
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
                          بريد تم عرضة من قبل الرئيس
                        </dt>
                        <dd>
                          <div class="text-lg font-bold text-gray-900">{{ reports.flagSecond }}</div>
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
                          بريد تم الرد عليه من قبل الرئيس
                        </dt>
                        <dd>
                          <div class="text-lg font-bold text-gray-900">{{ reports.flagThird }}</div>
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
                          بريد عرض  رد الرئيس
                        </dt>
                        <dd>
                          <div class="text-lg font-bold text-gray-900">{{ reports.flagFourth}}</div>
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
      reports: [],

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

   
        this.GetReports();

    }, 500);

    
  },
  methods: {
    GetReports() {
      this.$http.mailService.GetReports()
        .then((res) => {
          this.reports = res.data.result;

          console.log(this.reports)
          // this.lastMails = res.data.result.mails;

          // this.documents = res.data.result.documents;
        })
        .catch((err) => {
          console.log(err);
        });
    },
  },

};
</script>

<style>
</style>