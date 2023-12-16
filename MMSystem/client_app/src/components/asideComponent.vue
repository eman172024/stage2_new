<template>
  <div class="hidden md:flex md:flex-shrink-0 bg-gray-50">
    <div :class="toggle_nav ? 'w-64' : 'w-20'" class=" flex flex-col">
      <!-- Sidebar component, swap this element with another sidebar if you like -->
      <div
        class="border-l border-gray-200 z-10 pt-5 pb-4 flex flex-col flex-grow overflow-y-auto"
      >
        <div
          :class="toggle_nav ? 'px-4' : ''"
          class="flex-shrink-0  flex items-center"
        >
          <img
            class="h-10 w-auto"
            src="../assets/img/logo-aca.png"
            alt="logo"
          />
        </div>
        <div class="flex-grow mt-5 flex flex-col">
          <nav class="flex-1 bg-gray-50 flex flex-col justify-between">
            <div class="px-2 space-y-1">
              <!-- Current: "bg-gray-100 text-gray-900", Default: "text-gray-600 hover:bg-gray-50 hover:text-gray-900" -->
              <router-link
                title="لوحة التحكم"
                :to="{ name: 'dashboard' }"
                class="text-gray-600 hover:bg-gray-50 hover:text-gray-900 group rounded-md py-2 px-2 flex items-center justify-center text-sm font-medium"
              >
                <svg
                  class="text-green-400 group-hover:text-green-500 h-6 w-6  "
                  fill="none"
                  stroke="currentColor"
                  viewBox="0 0 24 24"
                  xmlns="http://www.w3.org/2000/svg"
                >
                  <path
                    stroke-linecap="round"
                    stroke-linejoin="round"
                    stroke-width="2"
                    d="M4 5a1 1 0 011-1h14a1 1 0 011 1v2a1 1 0 01-1 1H5a1 1 0 01-1-1V5zM4 13a1 1 0 011-1h6a1 1 0 011 1v6a1 1 0 01-1 1H5a1 1 0 01-1-1v-6zM16 13a1 1 0 011-1h2a1 1 0 011 1v6a1 1 0 01-1 1h-2a1 1 0 01-1-1v-6z"
                  ></path>
                </svg>
                <span v-if="toggle_nav">
                  لوحة التحكم
                </span>
              </router-link>

              <router-link
                v-if="roles.includes('n')"
                title="البريد الوارد"
                :to="{ name: 'inbox' }"
                class="text-gray-600 hover:bg-gray-50 hover:text-gray-900 group rounded-md py-2 px-2 flex items-center justify-center text-sm font-medium"
              >
                <svg
                  class="text-red-500 group-hover:text-red-600 h-6 w-6 "
                  fill="none"
                  stroke="currentColor"
                  viewBox="0 0 24 24"
                  xmlns="http://www.w3.org/2000/svg"
                >
                  <path
                    stroke-linecap="round"
                    stroke-linejoin="round"
                    stroke-width="2"
                    d="M20 13V6a2 2 0 00-2-2H6a2 2 0 00-2 2v7m16 0v5a2 2 0 01-2 2H6a2 2 0 01-2-2v-5m16 0h-2.586a1 1 0 00-.707.293l-2.414 2.414a1 1 0 01-.707.293h-3.172a1 1 0 01-.707-.293l-2.414-2.414A1 1 0 006.586 13H4"
                  ></path>
                </svg>
                <span v-if="toggle_nav">
                  البريد الوارد
                </span>
              </router-link>

              <router-link
                v-if="roles.includes('a')"
                title="البريد الصادر"
                :to="{ name: 'sent' }"
                class="text-gray-600 hover:bg-gray-50 hover:text-gray-900 group rounded-md py-2 px-2 flex items-center justify-center text-sm font-medium"
              >
                <svg
                  class="text-blue-400 group-hover:text-blue-500  h-6 w-6 fill-current stroke-current "
                  fill="none"
                  stroke="currentColor"
                  version="1.1"
                  width="256"
                  height="256"
                  viewBox="0 0 256 256"
                  xml:space="preserve"
                >
                  <g transform="translate(128 128) scale(0.72 0.72)" style="">
                    <g
                      style="stroke: none; stroke-width: 0; stroke-dasharray: none; stroke-linecap: butt; stroke-linejoin: miter; stroke-miterlimit: 10; fill-rule: nonzero; opacity: 1;"
                      transform="translate(-175.05 -175.05000000000004) scale(3.89 3.89)"
                    >
                      <path
                        d="M 89.999 3.075 C 90 3.02 90 2.967 89.999 2.912 c -0.004 -0.134 -0.017 -0.266 -0.038 -0.398 c -0.007 -0.041 -0.009 -0.081 -0.018 -0.122 c -0.034 -0.165 -0.082 -0.327 -0.144 -0.484 c -0.018 -0.046 -0.041 -0.089 -0.061 -0.134 c -0.053 -0.119 -0.113 -0.234 -0.182 -0.346 C 89.528 1.382 89.5 1.336 89.469 1.29 c -0.102 -0.147 -0.212 -0.288 -0.341 -0.417 c -0.13 -0.13 -0.273 -0.241 -0.421 -0.344 c -0.042 -0.029 -0.085 -0.056 -0.129 -0.082 c -0.118 -0.073 -0.239 -0.136 -0.364 -0.191 c -0.039 -0.017 -0.076 -0.037 -0.116 -0.053 c -0.161 -0.063 -0.327 -0.113 -0.497 -0.147 c -0.031 -0.006 -0.063 -0.008 -0.094 -0.014 c -0.142 -0.024 -0.285 -0.038 -0.429 -0.041 C 87.03 0 86.983 0 86.936 0.001 c -0.141 0.003 -0.282 0.017 -0.423 0.041 c -0.035 0.006 -0.069 0.008 -0.104 0.015 c -0.154 0.031 -0.306 0.073 -0.456 0.129 L 1.946 31.709 c -1.124 0.422 -1.888 1.473 -1.943 2.673 c -0.054 1.199 0.612 2.316 1.693 2.838 l 34.455 16.628 l 16.627 34.455 C 53.281 89.344 54.334 90 55.481 90 c 0.046 0 0.091 -0.001 0.137 -0.003 c 1.199 -0.055 2.251 -0.819 2.673 -1.943 L 89.815 4.048 c 0.056 -0.149 0.097 -0.3 0.128 -0.453 c 0.008 -0.041 0.011 -0.081 0.017 -0.122 C 89.982 3.341 89.995 3.208 89.999 3.075 z M 75.086 10.672 L 37.785 47.973 L 10.619 34.864 L 75.086 10.672 z M 55.136 79.381 L 42.027 52.216 l 37.302 -37.302 L 55.136 79.381 z"
                        style=""
                        transform=" matrix(1 0 0 1 0 0) "
                        stroke-linecap="round"
                      />
                    </g>
                  </g>
                </svg>
                <span v-if="toggle_nav">
                  البريد الصادر
                </span>
              </router-link>

              <router-link
                v-if="user_department == 17 && my_user_id == 29"
                title=" المستخدمين"
                :to="{ name: 'Show' }"
                class="
                  text-gray-600
                  hover:bg-gray-50 hover:text-gray-900
                  group
                  rounded-md
                  py-2
                  px-2
                  flex
                  items-center
                  justify-center
                  text-sm
                  font-medium
                "
              >
                <svg
                  class="text-gray-400 group-hover:text-gray-500 h-6 w-6"
                  fill="none"
                  stroke="currentColor"
                  viewBox="0 0 24 24"
                  xmlns="http://www.w3.org/2000/svg"
                >
                  <path
                    stroke-linecap="round"
                    stroke-linejoin="round"
                    stroke-width="2"
                    d="M12 4.354a4 4 0 110 5.292M15 21H3v-1a6 6 0 0112 0v1zm0 0h6v-1a6 6 0 00-9-5.197M13 7a4 4 0 11-8 0 4 4 0 018 0z"
                  ></path>
                </svg>
                <span v-if="toggle_nav"> المستخدمين </span>
              </router-link>


              <router-link
                v-if="user_department == 17 && my_user_id == 29"
                title=" القطاعات والجهات"
                :to="{ name: 'show_sections' }"
                class="
                  text-gray-600
                  hover:bg-gray-50 hover:text-gray-900
                  group
                  rounded-md
                  py-2
                  px-2
                  flex
                  items-center
                  justify-center
                  text-sm
                  font-medium
                "
              >
                <svg
                  class="text-gray-400 group-hover:text-gray-500 h-6 w-6"
                  fill="none"
                  stroke="currentColor"
                  viewBox="0 0 24 24"
                  xmlns="http://www.w3.org/2000/svg"
                >
                
  <path stroke-linecap="round" stroke-linejoin="round" d="M9 12h3.75M9 15h3.75M9 18h3.75m3 .75H18a2.25 2.25 0 002.25-2.25V6.108c0-1.135-.845-2.098-1.976-2.192a48.424 48.424 0 00-1.123-.08m-5.801 0c-.065.21-.1.433-.1.664 0 .414.336.75.75.75h4.5a.75.75 0 00.75-.75 2.25 2.25 0 00-.1-.664m-5.8 0A2.251 2.251 0 0113.5 2.25H15c1.012 0 1.867.668 2.15 1.586m-5.8 0c-.376.023-.75.05-1.124.08C9.095 4.01 8.25 4.973 8.25 6.108V8.25m0 0H4.875c-.621 0-1.125.504-1.125 1.125v11.25c0 .621.504 1.125 1.125 1.125h9.75c.621 0 1.125-.504 1.125-1.125V9.375c0-.621-.504-1.125-1.125-1.125H8.25zM6.75 12h.008v.008H6.75V12zm0 3h.008v.008H6.75V15zm0 3h.008v.008H6.75V18z" />
</svg>

                <span v-if="toggle_nav"> القطاعات والجهات </span>
              </router-link>




              <router-link
              
                title=" دليل الالوان "
                :to="{ name: 'guidecolor' }"
                class="
                  text-gray-600
                  hover:bg-gray-50 hover:text-gray-900
                  group
                  rounded-md
                  py-2
                  px-2
                  flex
                  items-center
                  justify-center
                  text-sm
                  font-medium
                "
              >
                <svg class="text-gray-400 group-hover:text-gray-500 h-6 w-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
                  <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M18.364 5.636l-3.536 3.536m0 5.656l3.536 3.536M9.172 9.172L5.636 5.636m3.536 9.192l-3.536 3.536M21 12a9 9 0 11-18 0 9 9 0 0118 0zm-5 0a4 4 0 11-8 0 4 4 0 018 0z" />
                </svg>

               
                <span v-if="toggle_nav"> دليل الالوان </span>
              </router-link>




                
              <a title=" الذهاب إلى منظومة البريد القديمة" class="self-start" id="aa1" @click="func1()">

                      <label
                        
                        class="
                        text-gray-600
                  hover:bg-gray-50 hover:text-gray-900
                  group
                  rounded-md
                  py-2
                  px-2
                  flex
                  items-center
                  justify-center
                  text-sm
                  font-medium
                        "

                        
                      >
                       

                      <svg   class="text-gray-500 group-hover:text-red-400 h-6 w-6"  xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" >
  <path stroke-linecap="round" stroke-linejoin="round" d="M9 15L3 9m0 0l6-6M3 9h12a6 6 0 010 12h-3" />
</svg>

                        
                      </label>
                    </a>

            </div>

            <!-- <router-link :to="{ name: 'login' }" class="text-gray-600 hover:bg-gray-50 hover:text-gray-900 group rounded-md py-2 px-2 flex items-center text-sm font-medium">
                            <svg class="text-gray-400 group-hover:text-gray-500 ml-3 h-6 w-6" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor" aria-hidden="true">
                                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 19v-6a2 2 0 00-2-2H5a2 2 0 00-2 2v6a2 2 0 002 2h2a2 2 0 002-2zm0 0V9a2 2 0 012-2h2a2 2 0 012 2v10m-6 0a2 2 0 002 2h2a2 2 0 002-2m0 0V5a2 2 0 012-2h2a2 2 0 012 2v14a2 2 0 01-2 2h-2a2 2 0 01-2-2z" />
                            </svg>

                            <span v-if="toggle_nav">
                               التقرير  
                            </span>
                        </router-link> -->
          </nav>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  mounted() {
    // this.my_user_id = localStorage.getItem("userId");
    // this.my_department_id = localStorage.getItem("chrome");
    this.roles = localStorage.getItem("Az07");
  },

  data() {
    return {
      roles: [],
      toggle_nav: false,
      user_department: localStorage.getItem("chrome"),
      my_user_id : localStorage.getItem("AY_LW"),
    };
  },
  methods: {
    add_to_array_of_side_action() {
      this.consignees.push({
        side: this.side,
        action: this.action,
      });

      // this.consignees.push( this.side )
    },


    //*****************29/3/2022
    func1() {
      var link = document.getElementById("aa1");

   
      var timeout;
      window.addEventListener("blur", function() {
        window.clearTimeout(timeout);
      });

      timeout = window.setTimeout(function() {
        window.location = "http://mail/scanner_app/Setup1.msi";
      }, 1000);

      link.href = "EEmploy:flag=1" + "Department_id=" +localStorage.getItem("chrome");
     
    
    },
  },
};
</script>

<style>
nav a.router-link-exact-active {
  --tw-bg-opacity: 1;
  background-color: rgba(243, 244, 246, var(--tw-bg-opacity));

  --tw-text-opacity: 1;
  color: rgba(17, 24, 39, var(--tw-text-opacity));
}
</style>
