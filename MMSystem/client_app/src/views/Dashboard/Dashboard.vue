<template>
  <div class="">
    <div class="h-screen bg-white overflow-hidden flex">
      <asideComponent></asideComponent>
      <div class="flex-1 bg-gray-100 w-0 overflow-y-auto">
        <div class="max-w-screen-2xl mx-auto flex flex-col md:px-8">
          <navComponent></navComponent>
          <main class="flex-1 relative focus:outline-none pt-2 pb-6">
            <h1 class="text-xl font-semibold text-black">البريد في أرقام</h1>

            <section class="grid grid-cols-2 gap-8">
              <div class="border border-gray-400 rounded mt-8 p-4">
                <p class="text-center text-lg font-bold">الصادر</p>
                <section class="grid grid-cols-2 gap-8 mt-8">
                  <div
                    class="
                      bg-white
                      p-4
                      hover:shadow
                      focus:outline-none
                      group
                      border-t-4 border-green-500
                    "
                  >
                    <div class="flex justify-between items-start">
                      <div class="">
                        <p class="text-gray-900">مجموع الداخلي</p>
                        <p
                          class="
                            font-bold
                            text-gray-600 text-3xl
                            mt-2
                            text-right
                          "
                        >
                          {{ Reports.totale_internell_externl }}
                        </p>
                      </div>

                      <!-- <div
                          class="w-16 h-16 -mt-8 bg-red-500 flex justify-center items-center"
                        >
                          <svg
                            class="text-gray-100 group-hover:text-red-600 h-6 w-6 fill-current stroke-current "
                            fill="none"
                            stroke="currentColor"
                            version="1.1"
                            width="256"
                            height="256"
                            viewBox="0 0 256 256"
                            xml:space="preserve"
                          >
                            <g
                              transform="translate(128 128) scale(0.72 0.72)"
                              style=""
                            >
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
                        </div> -->
                    </div>
                  </div>

                  <div
                    class="
                      bg-white
                      p-4
                      hover:shadow
                      focus:outline-none
                      group
                      border-t-4 border-red-700
                    "
                  >
                    <div class="flex justify-between items-start">
                      <div class="">
                        <p class="text-gray-900">داخلي لم يقرأ</p>
                        <p
                          class="
                            font-bold
                            text-gray-600 text-3xl
                            mt-2
                            text-right
                          "
                        >
                          {{ Reports.notreaded_internell_externl }}
                        </p>
                      </div>
                      <!-- <div
                          class="w-16 h-16 -mt-8 bg-green-500 flex justify-center items-center"
                        >
                          <svg
                            class="text-gray-100 group-hover:text-red-600 h-6 w-6 stroke-current"
                            width="24"
                            height="24"
                            viewBox="0 0 24 24"
                            fill="none"
                            xmlns="http://www.w3.org/2000/svg"
                          >
                            <path
                              d="M18 13.875H15.7372C15.5052 13.875 15.2827 13.9673 15.1186 14.1314L13.0064 16.2436C12.8423 16.4077 12.6198 16.5 12.3878 16.5H9.61225C9.3802 16.5 9.15768 16.4077 8.99362 16.2436L6.88138 14.1314C6.71732 13.9673 6.4948 13.875 6.26275 13.875H4M18 13.875V7.75C18 7.28587 17.8156 6.84075 17.4874 6.51256C17.1592 6.18437 16.7141 6 16.25 6H5.75C5.28587 6 4.84075 6.18437 4.51256 6.51256C4.18437 6.84075 4 7.28587 4 7.75V13.875H18ZM18 13.875V18.25C18 18.7141 17.8156 19.1592 17.4874 19.4874C17.1592 19.8156 16.7141 20 16.25 20H5.75C5.28587 20 4.84075 19.8156 4.51256 19.4874C4.18437 19.1592 4 18.7141 4 18.25V13.875H18Z"
                              stroke-width="2"
                              stroke-linecap="round"
                              stroke-linejoin="round"
                            />
                            <path
                              d="M22 1L16 7"
                              stroke-width="2"
                              stroke-linecap="round"
                              stroke-linejoin="round"
                            />
                            <path
                              d="M16 1L22 7"
                              stroke-width="2"
                              stroke-linecap="round"
                              stroke-linejoin="round"
                            />
                          </svg>
                        </div> -->
                    </div>
                  </div>

                  <div
                    class="
                      bg-white
                      p-4
                      hover:shadow
                      focus:outline-none
                      group
                      border-t-4 border-green-500
                    "
                  >
                    <div class="flex justify-between items-start">
                      <div class="">
                        <p class="text-gray-900">مجموع الصادر الخارجي</p>
                        <p
                          class="
                            font-bold
                            text-gray-600 text-3xl
                            mt-2
                            text-right
                          "
                        >
                          {{ Reports.totale_externl }}
                        </p>
                      </div>

                      <!-- <div
                          class="w-16 h-16 -mt-8 bg-green-500 flex justify-center items-center"
                        >
                          <svg
                            class="text-gray-100 group-hover:text-red-600 h-6 w-6 fill-current stroke-current "
                            fill="none"
                            stroke="currentColor"
                            version="1.1"
                            width="256"
                            height="256"
                            viewBox="0 0 256 256"
                            xml:space="preserve"
                          >
                            <g
                              transform="translate(128 128) scale(0.72 0.72)"
                              style=""
                            >
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
                        </div> -->
                    </div>
                  </div>

                  <div
                    class="
                      bg-white
                      p-4
                      hover:shadow
                      focus:outline-none
                      group
                      border-t-4 border-red-700
                    "
                  >
                    <div class="flex justify-between items-start">
                      <div class="">
                        <p class="text-gray-900">صادر خارجي لم يقرأ</p>
                        <p
                          class="
                            font-bold
                            text-gray-600 text-3xl
                            mt-2
                            text-right
                          "
                        >
                          {{ Reports.notreaded_Totale_externl }}
                        </p>
                      </div>
                      <!-- <div
                          class="w-16 h-16 -mt-8 bg-green-500 flex justify-center items-center"
                        >
                          <svg
                            class="text-gray-100 group-hover:text-red-600 h-6 w-6 stroke-current"
                            width="24"
                            height="24"
                            viewBox="0 0 24 24"
                            fill="none"
                            xmlns="http://www.w3.org/2000/svg"
                          >
                            <path
                              d="M18 13.875H15.7372C15.5052 13.875 15.2827 13.9673 15.1186 14.1314L13.0064 16.2436C12.8423 16.4077 12.6198 16.5 12.3878 16.5H9.61225C9.3802 16.5 9.15768 16.4077 8.99362 16.2436L6.88138 14.1314C6.71732 13.9673 6.4948 13.875 6.26275 13.875H4M18 13.875V7.75C18 7.28587 17.8156 6.84075 17.4874 6.51256C17.1592 6.18437 16.7141 6 16.25 6H5.75C5.28587 6 4.84075 6.18437 4.51256 6.51256C4.18437 6.84075 4 7.28587 4 7.75V13.875H18ZM18 13.875V18.25C18 18.7141 17.8156 19.1592 17.4874 19.4874C17.1592 19.8156 16.7141 20 16.25 20H5.75C5.28587 20 4.84075 19.8156 4.51256 19.4874C4.18437 19.1592 4 18.7141 4 18.25V13.875H18Z"
                              stroke-width="2"
                              stroke-linecap="round"
                              stroke-linejoin="round"
                            />
                            <path
                              d="M22 1L16 7"
                              stroke-width="2"
                              stroke-linecap="round"
                              stroke-linejoin="round"
                            />
                            <path
                              d="M16 1L22 7"
                              stroke-width="2"
                              stroke-linecap="round"
                              stroke-linejoin="round"
                            />
                          </svg>
                        </div> -->
                    </div>
                  </div>

                  <div
                    class="
                      bg-white
                      p-4
                      hover:shadow
                      focus:outline-none
                      group
                      border-t-4 border-green-500
                    "
                  >
                    <div class="flex justify-between items-start">
                      <div class="">
                        <p class="text-gray-900">مجموع الوارد الخارجي</p>
                        <p
                          class="
                            font-bold
                            text-gray-600 text-3xl
                            mt-2
                            text-right
                          "
                        >
                          {{ Reports.totale_inbox }}
                        </p>
                      </div>

                      <!-- <div
                          class="w-16 h-16 -mt-8 bg-green-500 flex justify-center items-center"
                        >
                          <svg
                            class="text-gray-100 group-hover:text-red-600 h-6 w-6 fill-current stroke-current "
                            fill="none"
                            stroke="currentColor"
                            version="1.1"
                            width="256"
                            height="256"
                            viewBox="0 0 256 256"
                            xml:space="preserve"
                          >
                            <g
                              transform="translate(128 128) scale(0.72 0.72)"
                              style=""
                            >
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
                        </div> -->
                    </div>
                  </div>

                  <div
                    class="
                      bg-white
                      p-4
                      hover:shadow
                      focus:outline-none
                      group
                      border-t-4 border-red-700
                    "
                  >
                    <div class="flex justify-between items-start">
                      <div class="">
                        <p class="text-gray-900">وارد لم يقرأ</p>
                        <p
                          class="
                            font-bold
                            text-gray-600 text-3xl
                            mt-2
                            text-right
                          "
                        >
                          {{ Reports.notreaded_Totale_inbox }}
                        </p>
                      </div>
                      <!-- <div
                          class="w-16 h-16 -mt-8 bg-green-500 flex justify-center items-center"
                        >
                          <svg
                            class="text-gray-100 group-hover:text-red-600 h-6 w-6 stroke-current"
                            width="24"
                            height="24"
                            viewBox="0 0 24 24"
                            fill="none"
                            xmlns="http://www.w3.org/2000/svg"
                          >
                            <path
                              d="M18 13.875H15.7372C15.5052 13.875 15.2827 13.9673 15.1186 14.1314L13.0064 16.2436C12.8423 16.4077 12.6198 16.5 12.3878 16.5H9.61225C9.3802 16.5 9.15768 16.4077 8.99362 16.2436L6.88138 14.1314C6.71732 13.9673 6.4948 13.875 6.26275 13.875H4M18 13.875V7.75C18 7.28587 17.8156 6.84075 17.4874 6.51256C17.1592 6.18437 16.7141 6 16.25 6H5.75C5.28587 6 4.84075 6.18437 4.51256 6.51256C4.18437 6.84075 4 7.28587 4 7.75V13.875H18ZM18 13.875V18.25C18 18.7141 17.8156 19.1592 17.4874 19.4874C17.1592 19.8156 16.7141 20 16.25 20H5.75C5.28587 20 4.84075 19.8156 4.51256 19.4874C4.18437 19.1592 4 18.7141 4 18.25V13.875H18Z"
                              stroke-width="2"
                              stroke-linecap="round"
                              stroke-linejoin="round"
                            />
                            <path
                              d="M22 1L16 7"
                              stroke-width="2"
                              stroke-linecap="round"
                              stroke-linejoin="round"
                            />
                            <path
                              d="M16 1L22 7"
                              stroke-width="2"
                              stroke-linecap="round"
                              stroke-linejoin="round"
                            />
                          </svg>
                        </div> -->
                    </div>
                  </div>
                </section>
              </div>

              <div class="border border-gray-400 rounded mt-8 p-4">
                <p class="text-center text-lg font-bold">الوارد</p>
                <section class="grid grid-cols-2 gap-8 mt-8">
                  <div
                    class="
                      bg-white
                      p-4
                      hover:shadow
                      focus:outline-none
                      group
                      border-t-4 border-green-500
                    "
                  >
                    <div class="flex justify-between items-start">
                      <div class="">
                        <p class="text-gray-900">مجموع الداخلي</p>
                        <p
                          class="
                            font-bold
                            text-gray-600 text-3xl
                            mt-2
                            text-right
                          "
                        >
                          {{ Reports.totale_Internal_inbox }}
                        </p>
                      </div>
                    </div>
                  </div>

                  <div
                    class="
                      bg-white
                      p-4
                      hover:shadow
                      focus:outline-none
                      group
                      border-t-4 border-red-700
                    "
                  >
                    <div class="flex justify-between items-start">
                      <div class="">
                        <p class="text-gray-900">داخلي لم يقرأ</p>
                        <p
                          class="
                            font-bold
                            text-gray-600 text-3xl
                            mt-2
                            text-right
                          "
                        >
                          {{ Reports.notreaded_Totale_Internal_inbox }}
                        </p>
                      </div>
                      <!-- <div
                          class="w-16 h-16 -mt-8 bg-green-500 flex justify-center items-center"
                        >
                          <svg
                            class="text-gray-100 group-hover:text-red-600 h-6 w-6 stroke-current"
                            width="24"
                            height="24"
                            viewBox="0 0 24 24"
                            fill="none"
                            xmlns="http://www.w3.org/2000/svg"
                          >
                            <path
                              d="M18 13.875H15.7372C15.5052 13.875 15.2827 13.9673 15.1186 14.1314L13.0064 16.2436C12.8423 16.4077 12.6198 16.5 12.3878 16.5H9.61225C9.3802 16.5 9.15768 16.4077 8.99362 16.2436L6.88138 14.1314C6.71732 13.9673 6.4948 13.875 6.26275 13.875H4M18 13.875V7.75C18 7.28587 17.8156 6.84075 17.4874 6.51256C17.1592 6.18437 16.7141 6 16.25 6H5.75C5.28587 6 4.84075 6.18437 4.51256 6.51256C4.18437 6.84075 4 7.28587 4 7.75V13.875H18ZM18 13.875V18.25C18 18.7141 17.8156 19.1592 17.4874 19.4874C17.1592 19.8156 16.7141 20 16.25 20H5.75C5.28587 20 4.84075 19.8156 4.51256 19.4874C4.18437 19.1592 4 18.7141 4 18.25V13.875H18Z"
                              stroke-width="2"
                              stroke-linecap="round"
                              stroke-linejoin="round"
                            />
                            <path
                              d="M22 1L16 7"
                              stroke-width="2"
                              stroke-linecap="round"
                              stroke-linejoin="round"
                            />
                            <path
                              d="M16 1L22 7"
                              stroke-width="2"
                              stroke-linecap="round"
                              stroke-linejoin="round"
                            />
                          </svg>
                        </div> -->
                    </div>
                  </div>

                  <div
                    class="
                      bg-white
                      p-4
                      hover:shadow
                      focus:outline-none
                      group
                      border-t-4 border-green-500
                    "
                  >
                    <div class="flex justify-between items-start">
                      <div class="">
                        <p class="text-gray-900">مجموع الصادر الخارجي</p>
                        <p
                          class="
                            font-bold
                            text-gray-600 text-3xl
                            mt-2
                            text-right
                          "
                        >
                          {{ Reports.total_externl2 }}
                        </p>
                      </div>

                      <!-- <div
                          class="w-16 h-16 -mt-8 bg-green-500 flex justify-center items-center"
                        >
                          <svg
                            class="text-gray-100 group-hover:text-red-600 h-6 w-6 fill-current stroke-current "
                            fill="none"
                            stroke="currentColor"
                            version="1.1"
                            width="256"
                            height="256"
                            viewBox="0 0 256 256"
                            xml:space="preserve"
                          >
                            <g
                              transform="translate(128 128) scale(0.72 0.72)"
                              style=""
                            >
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
                        </div> -->
                    </div>
                  </div>

                  <div
                    class="
                      bg-white
                      p-4
                      hover:shadow
                      focus:outline-none
                      group
                      border-t-4 border-red-700
                    "
                  >
                    <div class="flex justify-between items-start">
                      <div class="">
                        <p class="text-gray-900">صادر خارجي لم يقرأ</p>
                        <p
                          class="
                            font-bold
                            text-gray-600 text-3xl
                            mt-2
                            text-right
                          "
                        >
                          {{ Reports.notreaded_Total_externl2 }}
                        </p>
                      </div>
                      <!-- <div
                          class="w-16 h-16 -mt-8 bg-green-500 flex justify-center items-center"
                        >
                          <svg
                            class="text-gray-100 group-hover:text-red-600 h-6 w-6 stroke-current"
                            width="24"
                            height="24"
                            viewBox="0 0 24 24"
                            fill="none"
                            xmlns="http://www.w3.org/2000/svg"
                          >
                            <path
                              d="M18 13.875H15.7372C15.5052 13.875 15.2827 13.9673 15.1186 14.1314L13.0064 16.2436C12.8423 16.4077 12.6198 16.5 12.3878 16.5H9.61225C9.3802 16.5 9.15768 16.4077 8.99362 16.2436L6.88138 14.1314C6.71732 13.9673 6.4948 13.875 6.26275 13.875H4M18 13.875V7.75C18 7.28587 17.8156 6.84075 17.4874 6.51256C17.1592 6.18437 16.7141 6 16.25 6H5.75C5.28587 6 4.84075 6.18437 4.51256 6.51256C4.18437 6.84075 4 7.28587 4 7.75V13.875H18ZM18 13.875V18.25C18 18.7141 17.8156 19.1592 17.4874 19.4874C17.1592 19.8156 16.7141 20 16.25 20H5.75C5.28587 20 4.84075 19.8156 4.51256 19.4874C4.18437 19.1592 4 18.7141 4 18.25V13.875H18Z"
                              stroke-width="2"
                              stroke-linecap="round"
                              stroke-linejoin="round"
                            />
                            <path
                              d="M22 1L16 7"
                              stroke-width="2"
                              stroke-linecap="round"
                              stroke-linejoin="round"
                            />
                            <path
                              d="M16 1L22 7"
                              stroke-width="2"
                              stroke-linecap="round"
                              stroke-linejoin="round"
                            />
                          </svg>
                        </div> -->
                    </div>
                  </div>

                  <div
                    class="
                      bg-white
                      p-4
                      hover:shadow
                      focus:outline-none
                      group
                      border-t-4 border-green-500
                    "
                  >
                    <div class="flex justify-between items-start">
                      <div class="">
                        <p class="text-gray-900">مجموع الوارد الخارجي</p>
                        <p
                          class="
                            font-bold
                            text-gray-600 text-3xl
                            mt-2
                            text-right
                          "
                        >
                          {{ Reports.totale_inbox2 }}
                        </p>
                      </div>

                      <!-- <div
                          class="w-16 h-16 -mt-8 bg-green-500 flex justify-center items-center"
                        >
                          <svg
                            class="text-gray-100 group-hover:text-red-600 h-6 w-6 fill-current stroke-current "
                            fill="none"
                            stroke="currentColor"
                            version="1.1"
                            width="256"
                            height="256"
                            viewBox="0 0 256 256"
                            xml:space="preserve"
                          >
                            <g
                              transform="translate(128 128) scale(0.72 0.72)"
                              style=""
                            >
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
                        </div> -->
                    </div>
                  </div>

                  <div
                    class="
                      bg-white
                      p-4
                      hover:shadow
                      focus:outline-none
                      group
                      border-t-4 border-red-700
                    "
                  >
                    <div class="flex justify-between items-start">
                      <div class="">
                        <p class="text-gray-900">وارد خارجي لم يقرأ</p>
                        <p
                          class="
                            font-bold
                            text-gray-600 text-3xl
                            mt-2
                            text-right
                          "
                        >
                          {{ Reports.notreaded_Totale_inbox2 }}
                        </p>
                      </div>
                      <!-- <div
                          class="w-16 h-16 -mt-8 bg-green-500 flex justify-center items-center"
                        >
                          <svg
                            class="text-gray-100 group-hover:text-red-600 h-6 w-6 stroke-current"
                            width="24"
                            height="24"
                            viewBox="0 0 24 24"
                            fill="none"
                            xmlns="http://www.w3.org/2000/svg"
                          >
                            <path
                              d="M18 13.875H15.7372C15.5052 13.875 15.2827 13.9673 15.1186 14.1314L13.0064 16.2436C12.8423 16.4077 12.6198 16.5 12.3878 16.5H9.61225C9.3802 16.5 9.15768 16.4077 8.99362 16.2436L6.88138 14.1314C6.71732 13.9673 6.4948 13.875 6.26275 13.875H4M18 13.875V7.75C18 7.28587 17.8156 6.84075 17.4874 6.51256C17.1592 6.18437 16.7141 6 16.25 6H5.75C5.28587 6 4.84075 6.18437 4.51256 6.51256C4.18437 6.84075 4 7.28587 4 7.75V13.875H18ZM18 13.875V18.25C18 18.7141 17.8156 19.1592 17.4874 19.4874C17.1592 19.8156 16.7141 20 16.25 20H5.75C5.28587 20 4.84075 19.8156 4.51256 19.4874C4.18437 19.1592 4 18.7141 4 18.25V13.875H18Z"
                              stroke-width="2"
                              stroke-linecap="round"
                              stroke-linejoin="round"
                            />
                            <path
                              d="M22 1L16 7"
                              stroke-width="2"
                              stroke-linecap="round"
                              stroke-linejoin="round"
                            />
                            <path
                              d="M16 1L22 7"
                              stroke-width="2"
                              stroke-linecap="round"
                              stroke-linejoin="round"
                            />
                          </svg>
                        </div> -->
                    </div>
                  </div>
                </section>
              </div>
            </section>
          </main>
        </div>
      </div>
    </div>
    <div
      v-if="screenFreeze"
      class="
        w-screen
        h-screen
        bg-black bg-opacity-30
        absolute
        inset-0
        z-50
        flex
        justify-center
        items-center
      "
    >
      <div v-if="loading" class="">
        <svgLoadingComponent></svgLoadingComponent>
      </div>
    </div>
  </div>
</template>

<script>
import asideComponent from "@/components/asideComponent.vue";
import navComponent from "@/components/navComponent.vue";
import svgLoadingComponent from "@/components/svgLoadingComponent.vue";

export default {
  mounted() {
    this.my_user_id = localStorage.getItem("AY_LW");
    this.my_department_id = localStorage.getItem("chrome");
    this.roles = localStorage.getItem("Az07");
    this.GetNumbersOfReports();
  },

  components: {
    asideComponent,
    navComponent,
    svgLoadingComponent,
  },

  data() {
    return {
      // userId: this.$authenticatedUser.userId,
      //name: this.$authenticatedUser.name,
      // userName: this.$authenticatedUser.userName,
      // validity: this.$authenticatedUser.validity,
      roles: [],
      my_user_id: "",
      my_department_id: "",
      LastMails: {},
      Reports: {},
      loading: false,
      screenFreeze: false,
    };
  },

  methods: {
    GetNumbersOfReports() {
      this.$http.DashboardService.NumbersOfReports(this.my_department_id)
        .then((res) => {
          console.log(res.data);
          this.Reports = res.data;
        })
        .catch((err) => {
          console.log(err);
        });
    },
  },
};
</script>
