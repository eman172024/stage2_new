<template>
  <div class="">
    <div id="menu_mobile" class="hidden lg:hidden">
      <div class="fixed inset-0 flex z-40">
        <div class="fixed inset-0">
          <div
            class="absolute inset-0 bg-gray-600 opacity-75"
            aria-hidden="true"
          ></div>
        </div>

        <div
          class="relative flex-1 flex flex-col max-w-xs w-full pt-5 pb-4 bg-cyan-700"
        >
          <div class="absolute top-0 left-0 pt-2">
            <button
              @click="toggle_menu()"
              class="ml-1 flex items-center justify-center h-10 w-10 rounded-full focus:outline-none focus:ring-2 focus:ring-inset focus:ring-white"
            >
              <span class="sr-only">Close sidebar</span>
              <!-- Heroicon name: x -->
              <svg
                class="h-6 w-6 text-white"
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
                  d="M6 18L18 6M6 6l12 12"
                />
              </svg>
            </button>
          </div>
          <div class="flex-shrink-0 flex items-center px-4">
            <img
              class="h-8 w-auto rounded-full"
              src="../assets/img/logo-aca.png"
              alt="Easywire logo"
            />
          </div>
          <nav
            class="mt-5 flex-shrink-0 h-full divide-y divide-cyan-800 overflow-y-auto"
            aria-label="Sidebar"
          >
            <div class="px-2 space-y-1">
              <!-- Current: "bg-cyan-800 text-white", Default: "text-cyan-100 hover:text-white hover:bg-cyan-600" -->
              <router-link
                :to="{ name: 'dashboard' }"
                class="bg-cyan-800 text-white group flex items-center px-2 py-2 text-base font-medium rounded-md"
              >
                <!-- Heroicon name: home -->
                <svg
                  class="ml-4 h-6 w-6 text-cyan-200"
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
                    d="M3 12l2-2m0 0l7-7 7 7M5 10v10a1 1 0 001 1h3m10-11l2 2m-2-2v10a1 1 0 01-1 1h-3m-6 0a1 1 0 001-1v-4a1 1 0 011-1h2a1 1 0 011 1v4a1 1 0 001 1m-6 0h6"
                  />
                </svg>
                الرئسية
              </router-link>

              <router-link
                :to="{ name: 'mails' }"
                class="bg-cyan-800 text-white group flex items-center px-2 py-2 text-base font-medium rounded-md"
              >
                <svg
                  class="ml-4 h-6 w-6 text-cyan-200 fill-current"
                  id="Capa_1"
                  enable-background="new 0 0 512 512"
                  height="512"
                  viewBox="0 0 512 512"
                  width="512"
                  xmlns="http://www.w3.org/2000/svg"
                >
                  <g>
                    <path
                      d="m498 308.873c4.143 0 7.5-3.358 7.5-7.5v-33.571c0-15.283-12.481-27.5-27.5-27.5h-95.749v-212.802c0-15.164-12.336-27.5-27.5-27.5h-320.751c-15.164 0-27.5 12.336-27.5 27.5v317.911c0 4.142 3.358 7.5 7.5 7.5s7.5-3.358 7.5-7.5v-317.911c0-6.893 5.607-12.5 12.5-12.5h320.751c6.893 0 12.5 5.607 12.5 12.5v212.801c-9.893 0-209.343 0-219.251 0-15.023 0-27.5 12.222-27.5 27.5v189.199h-86.5c-6.893 0-12.5-5.607-12.5-12.5v-64.089c0-4.142-3.358-7.5-7.5-7.5s-7.5 3.358-7.5 7.5v64.089c0 15.164 12.336 27.5 27.5 27.5h86.5v12.5c0 7.7 3.196 14.762 8.475 19.828.067.065.135.13.203.194 5.14 4.836 11.76 7.478 18.822 7.478h330c7.928 0 15.08-3.378 19.965-8.618 4.665-4.93 7.535-11.575 7.535-18.882v-148.127c0-4.142-3.357-7.5-7.5-7.5s-7.5 3.358-7.5 7.5v148.127c0 .05-.007.099-.008.15l-116.493-132.077 115.758-88.977c.472 1.316.743 2.728.743 4.205v33.571c0 4.143 3.357 7.501 7.5 7.501zm-362.492 175.778c-.001-.051-.008-.1-.008-.151 0-8.177 0-206.097 0-216.699 0-1.477.271-2.888.743-4.205l115.758 88.977zm226.571-122.915 118.962 134.874c-.078.02-.155.042-.233.06-.888.205-1.885.33-2.808.33h-330c-.888 0-1.995-.126-3.041-.39l118.962-134.875 33.539 25.779c9.151 7.035 21.932 7.032 31.08 0zm-42.68 13.886c-3.769 2.896-9.029 2.897-12.799 0l-156.536-120.321h325.871z"
                    />
                    <path
                      d="m70.875 77.5h247c4.143 0 7.5-3.358 7.5-7.5s-3.357-7.5-7.5-7.5h-247c-4.142 0-7.5 3.358-7.5 7.5s3.358 7.5 7.5 7.5z"
                    />
                    <path
                      d="m70.875 138.734h247c4.143 0 7.5-3.358 7.5-7.5s-3.357-7.5-7.5-7.5h-247c-4.142 0-7.5 3.358-7.5 7.5s3.358 7.5 7.5 7.5z"
                    />
                    <path
                      d="m70.875 199.968h247c4.143 0 7.5-3.358 7.5-7.5s-3.357-7.5-7.5-7.5h-247c-4.142 0-7.5 3.358-7.5 7.5s3.358 7.5 7.5 7.5z"
                    />
                  </g>
                </svg>
                البريد
              </router-link>

              <router-link
                :to="{ name: 'reports' }"
                class="bg-cyan-800 text-white group flex items-center px-2 py-2 text-base font-medium rounded-md"
              >
                <svg
                  class="ml-4 h-6 w-6 text-cyan-200 fill-current"
                  id="Capa_1"
                  enable-background="new 0 0 512 512"
                  height="512"
                  viewBox="0 0 512 512"
                  width="512"
                  xmlns="http://www.w3.org/2000/svg"
                >
                  <g>
                    <path
                      d="m276.47 240.648h215.295c5.522 0 10-4.551 10-10.074l.001-.187c0-60.233-23.434-116.861-65.984-159.453-42.553-42.594-99.132-66.052-159.312-66.052-5.522 0-10 4.477-10 10v215.766c0 5.523 4.477 10 10 10zm10-215.525c105.333 5.08 190.094 89.993 195.064 195.525h-195.064z"
                    />
                    <path
                      d="m509.075 268.659c-1.876-1.878-4.421-2.933-7.075-2.933h-215.295c-4.044 0-7.689 2.436-9.238 6.171-1.548 3.735-.694 8.036 2.164 10.896l152.106 152.255c1.874 1.876 4.418 2.932 7.07 2.933h.004c2.65 0 5.193-1.053 7.068-2.926 42.567-42.536 66.049-99.116 66.12-159.317.004-2.655-1.048-5.201-2.924-7.079zm-70.426 145.011-11.126-11.137 17.228-17.229c3.905-3.905 3.905-10.237 0-14.142-3.906-3.905-10.236-3.905-14.143 0l-17.221 17.221-18.785-18.803 45.552-45.553c3.905-3.905 3.905-10.237 0-14.142-3.906-3.905-10.236-3.905-14.143 0l-45.545 45.545-17.254-17.271 15.154-15.155c3.905-3.905 3.905-10.237 0-14.142-3.906-3.905-10.236-3.905-14.143 0l-15.147 15.147-38.249-38.286h180.923c-2.33 47.786-20.92 92.574-53.101 127.947z"
                    />
                    <path
                      d="m235.295 277.734v-211.628c0-5.523-4.477-10-10-10-60.18 0-116.758 23.458-159.312 66.053-42.549 42.592-65.983 99.22-65.983 159.453s23.434 116.861 65.984 159.453c42.553 42.595 99.131 66.053 159.312 66.053 60.107 0 116.637-23.41 159.175-65.917 3.906-3.903 3.909-10.234.006-14.142zm-10 209.384c-113.2 0-205.295-92.19-205.295-205.506 0-109.962 86.719-200.029 195.295-205.265v200.034l-105.447 67.034c-4.661 2.963-6.037 9.143-3.074 13.804 1.905 2.998 5.142 4.637 8.448 4.637 1.835 0 3.692-.505 5.355-1.563l103.312-65.677 139.203 139.337c-37.822 34.36-86.371 53.165-137.797 53.165z"
                    />
                  </g>
                </svg>
                التقرير
              </router-link>
            </div>

            <div v-if="role == 2" class="mt-6 pt-6">
              <div class="px-2 space-y-1">
                <router-link
                  :to="{ name: 'users' }"
                  class="bg-cyan-800 text-white group flex items-center px-2 py-2 text-base font-medium rounded-md"
                >
                  <svg
                    class="ml-4 h-6 w-6 text-cyan-200 group-hover:text-cyan-200 fill-current"
                    id="Capa_1"
                    enable-background="new 0 0 512 512"
                    height="512"
                    viewBox="0 0 512 512"
                    width="512"
                    xmlns="http://www.w3.org/2000/svg"
                  >
                    <g>
                      <path
                        d="m256 207c47.972 0 87-39.028 87-87s-39.028-87-87-87-87 39.028-87 87 39.028 87 87 87zm0-144c31.43 0 57 25.57 57 57s-25.57 57-57 57-57-25.57-57-57 25.57-57 57-57z"
                      />
                      <path
                        d="m432 207c30.327 0 55-24.673 55-55s-24.673-55-55-55-55 24.673-55 55 24.673 55 55 55zm0-80c13.785 0 25 11.215 25 25s-11.215 25-25 25-25-11.215-25-25 11.215-25 25-25z"
                      />
                      <path
                        d="m444.1 241h-23.2c-27.339 0-50.939 16.152-61.693 39.352-22.141-24.17-53.944-39.352-89.228-39.352h-27.957c-35.284 0-67.087 15.182-89.228 39.352-10.755-23.2-34.355-39.352-61.694-39.352h-23.2c-37.44 0-67.9 30.276-67.9 67.49v109.21c0 16.156 13.194 29.3 29.412 29.3h91.727c1.538 17.9 16.59 32 34.883 32h199.957c18.292 0 33.344-14.1 34.883-32h90.679c16.796 0 30.46-13.61 30.46-30.34v-108.17c-.001-37.214-30.461-67.49-67.901-67.49zm-414.1 67.49c0-20.672 17.002-37.49 37.9-37.49h23.2c20.898 0 37.9 16.818 37.9 37.49v10.271c-10.087 26.264-8 42.004-8 98.239h-91zm331 135.489c0 2.769-2.252 5.021-5.021 5.021h-199.958c-2.769 0-5.021-2.253-5.021-5.021v-81.957c0-50.19 40.832-91.022 91.021-91.022h27.957c50.19 0 91.022 40.832 91.022 91.021zm121-27.319c0 .517 5.592.34-91 .34 0-56.651 2.071-72.018-8-98.239v-10.271c0-20.672 17.002-37.49 37.9-37.49h23.2c20.898 0 37.9 16.818 37.9 37.49z"
                      />
                      <path
                        d="m80 207c30.327 0 55-24.673 55-55s-24.673-55-55-55-55 24.673-55 55 24.673 55 55 55zm0-80c13.785 0 25 11.215 25 25s-11.215 25-25 25-25-11.215-25-25 11.215-25 25-25z"
                      />
                    </g>
                  </svg>
                  إضافة مستخدم
                </router-link>

                <router-link
                  :to="{ name: 'processingResponses' }"
                  class="bg-cyan-800 text-white group flex items-center px-2 py-2 text-base font-medium rounded-md"
                >
                  <!-- Heroicon name: question-mark-circle -->
                  <svg
                    class="ml-4 h-6 w-6 text-cyan-300 group-hover:text-cyan-200"
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
                      d="M8.228 9c.549-1.165 2.03-2 3.772-2 2.21 0 4 1.343 4 3 0 1.4-1.278 2.575-3.006 2.907-.542.104-.994.54-.994 1.093m0 3h.01M21 12a9 9 0 11-18 0 9 9 0 0118 0z"
                    />
                  </svg>
                  تجهيز الردود
                </router-link>
              </div>
            </div>
          </nav>
        </div>
        <div class="flex-shrink-0 w-14" aria-hidden="true">
          <!-- Dummy element to force sidebar to shrink to fit close icon -->
        </div>
      </div>
    </div>

    <div class="hidden lg:flex lg:flex-shrink-0 h-screen">
      <div class="flex flex-col w-64">
        <!-- Sidebar component, swap this element with another sidebar if you like -->
        <div
          class="flex flex-col flex-grow bg-cyan-700 pt-5 pb-4 overflow-y-auto"
        >
          <div class="flex items-center flex-shrink-0 px-4">
            <img
              class="h-8 w-auto rounded-full"
              src="../assets/img/logo-aca.png"
              alt="Easywire logo"
            />
          </div>
          <nav
            class="flex-1 flex flex-col divide-y divide-cyan-800 overflow-y-auto mt-8"
            aria-label="Sidebar"
          >
            <div class="px-2 space-y-1">
              <!-- Current: "bg-cyan-800 text-white", Default: "text-cyan-100 hover:text-white hover:bg-cyan-600" -->

              <router-link
                :to="{ name: 'dashboard' }"
                class="group flex items-center px-2 py-2 text-sm leading-6 font-medium rounded-md text-cyan-100 hover:text-white hover:bg-cyan-600"
              >
                <!-- Heroicon name: document-report -->
                <svg
                  class="ml-4 h-6 w-6 text-cyan-200"
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
                    d="M3 12l2-2m0 0l7-7 7 7M5 10v10a1 1 0 001 1h3m10-11l2 2m-2-2v10a1 1 0 01-1 1h-3m-6 0a1 1 0 001-1v-4a1 1 0 011-1h2a1 1 0 011 1v4a1 1 0 001 1m-6 0h6"
                  />
                </svg>
                الرئسية
              </router-link>

              <router-link
                :to="{ name: 'mails' }"
                class="group flex items-center px-2 py-2 text-sm leading-6 font-medium rounded-md text-cyan-100 hover:text-white hover:bg-cyan-600"
              >
                <svg
                  class="ml-4 h-6 w-6 text-cyan-200 fill-current"
                  id="Capa_1"
                  enable-background="new 0 0 512 512"
                  height="512"
                  viewBox="0 0 512 512"
                  width="512"
                  xmlns="http://www.w3.org/2000/svg"
                >
                  <g>
                    <path
                      d="m498 308.873c4.143 0 7.5-3.358 7.5-7.5v-33.571c0-15.283-12.481-27.5-27.5-27.5h-95.749v-212.802c0-15.164-12.336-27.5-27.5-27.5h-320.751c-15.164 0-27.5 12.336-27.5 27.5v317.911c0 4.142 3.358 7.5 7.5 7.5s7.5-3.358 7.5-7.5v-317.911c0-6.893 5.607-12.5 12.5-12.5h320.751c6.893 0 12.5 5.607 12.5 12.5v212.801c-9.893 0-209.343 0-219.251 0-15.023 0-27.5 12.222-27.5 27.5v189.199h-86.5c-6.893 0-12.5-5.607-12.5-12.5v-64.089c0-4.142-3.358-7.5-7.5-7.5s-7.5 3.358-7.5 7.5v64.089c0 15.164 12.336 27.5 27.5 27.5h86.5v12.5c0 7.7 3.196 14.762 8.475 19.828.067.065.135.13.203.194 5.14 4.836 11.76 7.478 18.822 7.478h330c7.928 0 15.08-3.378 19.965-8.618 4.665-4.93 7.535-11.575 7.535-18.882v-148.127c0-4.142-3.357-7.5-7.5-7.5s-7.5 3.358-7.5 7.5v148.127c0 .05-.007.099-.008.15l-116.493-132.077 115.758-88.977c.472 1.316.743 2.728.743 4.205v33.571c0 4.143 3.357 7.501 7.5 7.501zm-362.492 175.778c-.001-.051-.008-.1-.008-.151 0-8.177 0-206.097 0-216.699 0-1.477.271-2.888.743-4.205l115.758 88.977zm226.571-122.915 118.962 134.874c-.078.02-.155.042-.233.06-.888.205-1.885.33-2.808.33h-330c-.888 0-1.995-.126-3.041-.39l118.962-134.875 33.539 25.779c9.151 7.035 21.932 7.032 31.08 0zm-42.68 13.886c-3.769 2.896-9.029 2.897-12.799 0l-156.536-120.321h325.871z"
                    />
                    <path
                      d="m70.875 77.5h247c4.143 0 7.5-3.358 7.5-7.5s-3.357-7.5-7.5-7.5h-247c-4.142 0-7.5 3.358-7.5 7.5s3.358 7.5 7.5 7.5z"
                    />
                    <path
                      d="m70.875 138.734h247c4.143 0 7.5-3.358 7.5-7.5s-3.357-7.5-7.5-7.5h-247c-4.142 0-7.5 3.358-7.5 7.5s3.358 7.5 7.5 7.5z"
                    />
                    <path
                      d="m70.875 199.968h247c4.143 0 7.5-3.358 7.5-7.5s-3.357-7.5-7.5-7.5h-247c-4.142 0-7.5 3.358-7.5 7.5s3.358 7.5 7.5 7.5z"
                    />
                  </g>
                </svg>
                البريد
              </router-link>

              <router-link
                :to="{ name: 'reports' }"
                class="group flex items-center px-2 py-2 text-sm leading-6 font-medium rounded-md text-cyan-100 hover:text-white hover:bg-cyan-600"
              >
                <svg
                  class="ml-4 h-6 w-6 text-cyan-200 fill-current"
                  id="Capa_1"
                  enable-background="new 0 0 512 512"
                  height="512"
                  viewBox="0 0 512 512"
                  width="512"
                  xmlns="http://www.w3.org/2000/svg"
                >
                  <g>
                    <path
                      d="m276.47 240.648h215.295c5.522 0 10-4.551 10-10.074l.001-.187c0-60.233-23.434-116.861-65.984-159.453-42.553-42.594-99.132-66.052-159.312-66.052-5.522 0-10 4.477-10 10v215.766c0 5.523 4.477 10 10 10zm10-215.525c105.333 5.08 190.094 89.993 195.064 195.525h-195.064z"
                    />
                    <path
                      d="m509.075 268.659c-1.876-1.878-4.421-2.933-7.075-2.933h-215.295c-4.044 0-7.689 2.436-9.238 6.171-1.548 3.735-.694 8.036 2.164 10.896l152.106 152.255c1.874 1.876 4.418 2.932 7.07 2.933h.004c2.65 0 5.193-1.053 7.068-2.926 42.567-42.536 66.049-99.116 66.12-159.317.004-2.655-1.048-5.201-2.924-7.079zm-70.426 145.011-11.126-11.137 17.228-17.229c3.905-3.905 3.905-10.237 0-14.142-3.906-3.905-10.236-3.905-14.143 0l-17.221 17.221-18.785-18.803 45.552-45.553c3.905-3.905 3.905-10.237 0-14.142-3.906-3.905-10.236-3.905-14.143 0l-45.545 45.545-17.254-17.271 15.154-15.155c3.905-3.905 3.905-10.237 0-14.142-3.906-3.905-10.236-3.905-14.143 0l-15.147 15.147-38.249-38.286h180.923c-2.33 47.786-20.92 92.574-53.101 127.947z"
                    />
                    <path
                      d="m235.295 277.734v-211.628c0-5.523-4.477-10-10-10-60.18 0-116.758 23.458-159.312 66.053-42.549 42.592-65.983 99.22-65.983 159.453s23.434 116.861 65.984 159.453c42.553 42.595 99.131 66.053 159.312 66.053 60.107 0 116.637-23.41 159.175-65.917 3.906-3.903 3.909-10.234.006-14.142zm-10 209.384c-113.2 0-205.295-92.19-205.295-205.506 0-109.962 86.719-200.029 195.295-205.265v200.034l-105.447 67.034c-4.661 2.963-6.037 9.143-3.074 13.804 1.905 2.998 5.142 4.637 8.448 4.637 1.835 0 3.692-.505 5.355-1.563l103.312-65.677 139.203 139.337c-37.822 34.36-86.371 53.165-137.797 53.165z"
                    />
                  </g>
                </svg>
                التقرير
              </router-link>
            </div>

            <div v-if="role == 2" class="mt-6 pt-6">
              <div class="px-2 space-y-1">
                <router-link
                  :to="{ name: 'users' }"
                  class="group flex items-center px-2 py-2 text-sm leading-6 font-medium rounded-md text-cyan-100 hover:text-white hover:bg-cyan-600"
                >
                  <svg
                    class="ml-4 h-6 w-6 text-cyan-200 group-hover:text-cyan-200 fill-current"
                    id="Capa_1"
                    enable-background="new 0 0 512 512"
                    height="512"
                    viewBox="0 0 512 512"
                    width="512"
                    xmlns="http://www.w3.org/2000/svg"
                  >
                    <g>
                      <path
                        d="m256 207c47.972 0 87-39.028 87-87s-39.028-87-87-87-87 39.028-87 87 39.028 87 87 87zm0-144c31.43 0 57 25.57 57 57s-25.57 57-57 57-57-25.57-57-57 25.57-57 57-57z"
                      />
                      <path
                        d="m432 207c30.327 0 55-24.673 55-55s-24.673-55-55-55-55 24.673-55 55 24.673 55 55 55zm0-80c13.785 0 25 11.215 25 25s-11.215 25-25 25-25-11.215-25-25 11.215-25 25-25z"
                      />
                      <path
                        d="m444.1 241h-23.2c-27.339 0-50.939 16.152-61.693 39.352-22.141-24.17-53.944-39.352-89.228-39.352h-27.957c-35.284 0-67.087 15.182-89.228 39.352-10.755-23.2-34.355-39.352-61.694-39.352h-23.2c-37.44 0-67.9 30.276-67.9 67.49v109.21c0 16.156 13.194 29.3 29.412 29.3h91.727c1.538 17.9 16.59 32 34.883 32h199.957c18.292 0 33.344-14.1 34.883-32h90.679c16.796 0 30.46-13.61 30.46-30.34v-108.17c-.001-37.214-30.461-67.49-67.901-67.49zm-414.1 67.49c0-20.672 17.002-37.49 37.9-37.49h23.2c20.898 0 37.9 16.818 37.9 37.49v10.271c-10.087 26.264-8 42.004-8 98.239h-91zm331 135.489c0 2.769-2.252 5.021-5.021 5.021h-199.958c-2.769 0-5.021-2.253-5.021-5.021v-81.957c0-50.19 40.832-91.022 91.021-91.022h27.957c50.19 0 91.022 40.832 91.022 91.021zm121-27.319c0 .517 5.592.34-91 .34 0-56.651 2.071-72.018-8-98.239v-10.271c0-20.672 17.002-37.49 37.9-37.49h23.2c20.898 0 37.9 16.818 37.9 37.49z"
                      />
                      <path
                        d="m80 207c30.327 0 55-24.673 55-55s-24.673-55-55-55-55 24.673-55 55 24.673 55 55 55zm0-80c13.785 0 25 11.215 25 25s-11.215 25-25 25-25-11.215-25-25 11.215-25 25-25z"
                      />
                    </g>
                  </svg>
                  إضافة مستخدم
                </router-link>
                <router-link
                  :to="{ name: 'processingResponses' }"
                  class="group flex items-center px-2 py-2 text-sm leading-6 font-medium rounded-md text-cyan-100 hover:text-white hover:bg-cyan-600"
                >
                  <!-- Heroicon name: question-mark-circle -->
                  <svg
                    class="ml-4 h-6 w-6 text-cyan-200"
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
                      d="M8.228 9c.549-1.165 2.03-2 3.772-2 2.21 0 4 1.343 4 3 0 1.4-1.278 2.575-3.006 2.907-.542.104-.994.54-.994 1.093m0 3h.01M21 12a9 9 0 11-18 0 9 9 0 0118 0z"
                    />
                  </svg>
                  تجهيز الردود
                </router-link>
              </div>
            </div>
          </nav>
        </div>
      </div>
    </div>

    <div
      v-if="loading"
      id="testtest"
      class="absolute inset-0 z-50 flex justify-center items-center bg-black bg-opacity-60"
    >
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
  </div>
</template>

<script>
export default {
  methods: {
    toggle_menu() {
      document.getElementById("menu_mobile").classList.toggle("hidden");
    },
  },
  data() {
    return {
      role: "",
      fullName: "",
      userId: "",
      email: "",

      loading: false,
    };
  },

  created() {
    this.loading = true;
    this.$http.securityService
      .CheckLogin()
      .then((res) => {
        setTimeout(() => {
          this.loading = false;
          let data = res.data;
          if (data.userauth) {
            this.$authenticatedUser.userId = data.userauth.userId;
            this.$authenticatedUser.fullName = data.userauth.fullName;
            this.$authenticatedUser.email = data.userauth.email;
            this.$authenticatedUser.role = data.userauth.role;
          } else {
            this.$authenticatedUser.userId = 0;
            this.$authenticatedUser.fullName = "";
            this.$authenticatedUser.email = "";
            this.$authenticatedUser.role = "";
            if (this.$route.path != "/login") {
              this.$router.replace("/login");
            }
          }
        }, 200);
      })
      .catch(() => {
        this.loading = false;
        this.$authenticatedUser.userId = 0;
        this.$authenticatedUser.fullName = "";
        this.$authenticatedUser.email = "";
        this.$authenticatedUser.role = "";

        this.$router.replace("/login");
      });
  },

  mounted() {
    setTimeout(() => {
      this.fullName = this.$authenticatedUser.fullName;
      this.role = this.$authenticatedUser.role;
      this.email = this.$authenticatedUser.email;
      this.userId = this.$authenticatedUser.userId;
    }, 500);
  },
};
</script>

<style></style>
