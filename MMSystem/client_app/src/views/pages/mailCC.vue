<template>
  <div class="h-screen flex overflow-hidden bg-gray-100 relative">
    <aside class="h-screen">
      <asidebar></asidebar>
    </aside>
    <div class="flex-1 overflow-auto focus:outline-none" tabindex="0">
      <navaca></navaca>

      <main
        class="flex-1 z-0 overflow-y-auto max-w-2xl mx-auto mt-8 pb-8 px-4"
      >
        <div class="space-y-8 divide-y divide-gray-200">
          <div class="pt-8">
            <div>
              <h3 class="text-lg leading-6 font-medium text-gray-900">
                معلومات البريد
              </h3>
            </div>
            <div class="mt-6 grid grid-cols-1 gap-y-6 gap-x-4 sm:grid-cols-6">
              <div class="sm:col-span-6">
                <label
                  for="first_name"
                  class="block text-sm font-medium text-gray-700"
                >
                  الجهة المرسلة
                </label>
                <div
                  class="mt-1 h-16 w-full bg-white border-gray-300 rounded-md p-2 overflow-y-auto leading-7"
                >
                  {{ sender }}
                </div>
              </div>

              <div class="sm:col-span-3">
                <label
                  for="date"
                  class="block text-sm font-medium text-gray-700"
                >
                  تاريخ الارسال
                </label>
                <div
                  class="mt-1 h-12 w-full bg-white border-gray-300 rounded-md p-2 overflow-y-auto leading-8"
                >
                  {{ releaseDate }}
                </div>
              </div>

              <div class="sm:col-span-3">
                <label
                  for="date"
                  class="block text-sm font-medium text-gray-700"
                >
                  نوع البريد
                </label>
                <div
                  class="mt-1 h-12 w-full bg-white border-gray-300 rounded-md p-2 overflow-y-auto leading-8"
                >
                  <span v-if="mailType == 1">داخلي</span>
                  <span v-if="mailType == 2">خارجي</span>
                </div>
              </div>

              <div class="sm:col-span-6">
                <label
                  for="about"
                  class="block text-sm font-medium text-gray-700"
                >
                  الملخص
                </label>

                <div
                  class="mt-1 h-48 w-full bg-white border-gray-300 rounded-md p-2 overflow-y-auto leading-8"
                >
                  {{ sentMessage }}
                </div>
              </div>
            </div>
            <div class="sm:col-span-6 mt-6">
              <label
                for="cover_photo"
                class="block text-sm font-medium text-gray-700"
              >
                المستندات
              </label>


              <div class="min-h-64 border-2 border-gray-300 border-dashed rounded-md mt-2 p-4 ">
                <div v-if="documentsLoading" class="h-64 flex justify-center items-center bg-gray-200">
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

                <div v-else class="grid grid-cols-2 gap-4 sm:gap-8">
                  <div v-if="originalDocuments == 0" class="col-span-2 flex justify-center items-center h-64">
                    لا يوجد مستندات
                  </div>
                  <button v-else
                    v-for="(img, index) in originalDocuments" :key="index"
                    @click="toggleShowModal(img.documentFile)"
                    class="w-full h-52 sm:h-96 object-cover group relative"
                    type="button"
                    onclick=""
                  >
                    <img class="w-full h-full" :src="img.documentFile" alt="" />
                  </button>

                </div>

              </div>
              
            </div>

            <!-- The Modal -->
            <div
              v-if="showModal"
              id="myModal"
              class="modal h-full w-full mt-0 inset-0 z-50 absolute bg-gray-400 overflow-y-auto"
            >
              <div class="modal-content w-full">
                <editocomponent
                  @passMarginalizedDocumentsToparent="
                    marginalizedDocumentsFromChild
                  "
                  @clicked-show-detail="toggleShowModal('')"
                  :imageToCanvas="imagePassToModal"
                />
              </div>
            </div>
          </div>
        </div>

        <div class="mt-6 grid grid-cols-1 gap-y-6 gap-x-4 sm:grid-cols-6">
          <div class="sm:col-span-6">
            <label
              for="country"
              class="block text-sm font-medium text-gray-700 sm:mt-px sm:pt-2"
            >
              الردود الجاهزة
            </label>

            <div class="mt-1 border-2 border-gray-300 border-dashed p-2 flex flex-wrap">
              <button
                v-for="responses  in ProcessingResponses" :key="responses.replyId"
                :id="responses.replyId"
                type="button"
                class="bg-cyan-500 text-white flex items-center px-2 py-1 rounded-md m-1 focus:outline-none hover:bg-cyan-400"
                @click="
                  setTextToResponses( responses.replyContent )
                "
              >
               {{ responses.title }}
                <svg
                  class="w-4 h-4 mr-2 fill-current text-white"
                  xmlns="http://www.w3.org/2000/svg"
                  xmlns:xlink="http://www.w3.org/1999/xlink"
                  x="0px"
                  y="0px"
                  viewBox="0 0 512 512"
                  style="enable-background: new 0 0 512 512"
                  xml:space="preserve"
                >
                  <g>
                    <g>
                      <path
                        d="M256,0C114.833,0,0,114.833,0,256s114.833,256,256,256s256-114.853,256-256S397.167,0,256,0z M256,472.341
                                    c-119.275,0-216.341-97.046-216.341-216.341S136.725,39.659,256,39.659S472.341,136.705,472.341,256S375.295,472.341,256,472.341z
                                    "
                      ></path>
                    </g>
                  </g>
                  <g>
                    <g>
                      <path
                        d="M355.148,234.386H275.83v-79.318c0-10.946-8.864-19.83-19.83-19.83s-19.83,8.884-19.83,19.83v79.318h-79.318
                                    c-10.966,0-19.83,8.884-19.83,19.83s8.864,19.83,19.83,19.83h79.318v79.318c0,10.946,8.864,19.83,19.83,19.83
                                    s19.83-8.884,19.83-19.83v-79.318h79.318c10.966,0,19.83-8.884,19.83-19.83S366.114,234.386,355.148,234.386z"
                      ></path>
                    </g>
                  </g>
                  <g></g>
                </svg>
              </button>

              
            </div>
          </div>

          <div class="sm:col-span-6">
            <label
              for="responses"
              class="block text-sm font-medium text-gray-700"
            >
              الرد
            </label>
            <div class="mt-1">
              <textarea
                id="responses"
                v-model="reply"
                rows="6"
                class="shadow-sm focus:ring-cyan-700 focus:border-cyan-700 block w-full p-2 sm:text-sm border-gray-300 rounded-md"
              ></textarea>
            </div>
          </div>

          <div
            v-if="
              marginalizedDocumentsToShow != '' ||
              marginalizedDocumentsToSend != ''
            "
            class="sm:col-span-6"
          >
            <label
              for="cover_photo"
              class="block text-sm font-medium text-gray-700"
            >
              المستندات المهمش عليها
            </label>
            <br />


            <div class="border-2 border-gray-300 border-dashed rounded-md mt-2 p-4 ">


              <div v-if="marginalizedDocumentsLoading" class="h-64 flex justify-center items-center bg-gray-200">
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

             

              <div v-else class="">
                <div v-if="marginalizedDocumentsToShow == 0 && marginalizedDocumentsToSend == 0" class="w-full flex justify-center items-center h-64">
                     لا يوجد مستندات مهمشة
                  </div>



                <div v-else class="grid grid-cols-2 gap-4 sm:gap-8">
                  <div
                    v-for="(image, index) in marginalizedDocumentsToShow"
                    :key="image.documentId"
                    class="relative h-64 sm:h-96 w-full"
                  >
                    <img :src="image.documentFile" class="w-full h-full rounded" />
                    <button
                      type="button"
                      class="absolute bg-red-600 hover:bg-red-500 duration-500 p-2 rounded-full bottom-0 inset-x-0 mx-auto mb-2 focus:outline-none"
                      @click="deleteDocument(image.documentId, index)"
                    >
                      <svg
                        class="w-4 h-4 text-white fill-current"
                        height="427pt"
                        viewBox="-40 0 427 427.00131"
                        width="427pt"
                        xmlns="http://www.w3.org/2000/svg"
                      >
                        <path
                          d="m232.398438 154.703125c-5.523438 0-10 4.476563-10 10v189c0 5.519531 4.476562 10 10 10 5.523437 0 10-4.480469 10-10v-189c0-5.523437-4.476563-10-10-10zm0 0"
                        />
                        <path
                          d="m114.398438 154.703125c-5.523438 0-10 4.476563-10 10v189c0 5.519531 4.476562 10 10 10 5.523437 0 10-4.480469 10-10v-189c0-5.523437-4.476563-10-10-10zm0 0"
                        />
                        <path
                          d="m28.398438 127.121094v246.378906c0 14.5625 5.339843 28.238281 14.667968 38.050781 9.285156 9.839844 22.207032 15.425781 35.730469 15.449219h189.203125c13.527344-.023438 26.449219-5.609375 35.730469-15.449219 9.328125-9.8125 14.667969-23.488281 14.667969-38.050781v-246.378906c18.542968-4.921875 30.558593-22.835938 28.078124-41.863282-2.484374-19.023437-18.691406-33.253906-37.878906-33.257812h-51.199218v-12.5c.058593-10.511719-4.097657-20.605469-11.539063-28.03125-7.441406-7.421875-17.550781-11.5546875-28.0625-11.46875h-88.796875c-10.511719-.0859375-20.621094 4.046875-28.0625 11.46875-7.441406 7.425781-11.597656 17.519531-11.539062 28.03125v12.5h-51.199219c-19.1875.003906-35.394531 14.234375-37.878907 33.257812-2.480468 19.027344 9.535157 36.941407 28.078126 41.863282zm239.601562 279.878906h-189.203125c-17.097656 0-30.398437-14.6875-30.398437-33.5v-245.5h250v245.5c0 18.8125-13.300782 33.5-30.398438 33.5zm-158.601562-367.5c-.066407-5.207031 1.980468-10.21875 5.675781-13.894531 3.691406-3.675781 8.714843-5.695313 13.925781-5.605469h88.796875c5.210937-.089844 10.234375 1.929688 13.925781 5.605469 3.695313 3.671875 5.742188 8.6875 5.675782 13.894531v12.5h-128zm-71.199219 32.5h270.398437c9.941406 0 18 8.058594 18 18s-8.058594 18-18 18h-270.398437c-9.941407 0-18-8.058594-18-18s8.058593-18 18-18zm0 0"
                        />
                        <path
                          d="m173.398438 154.703125c-5.523438 0-10 4.476563-10 10v189c0 5.519531 4.476562 10 10 10 5.523437 0 10-4.480469 10-10v-189c0-5.523437-4.476563-10-10-10zm0 0"
                        />
                      </svg>
                    </button>
                  </div>

                  <div
                    v-for="(image, index) in marginalizedDocumentsToSend"
                    :key="index"
                    class="relative h-64 sm:h-96 w-full"
                  >
                    <img :src="image.documentFile" class="w-full h-full rounded" />
                    <button
                      type="button"
                      class="absolute bg-red-600 hover:bg-red-500 duration-500 p-2 rounded-full bottom-0 inset-x-0 mx-auto mb-2 focus:outline-none"
                      @click="removeImageFromArrayToSend(index)"
                    >
                      <svg
                        class="w-4 h-4 text-white fill-current"
                        height="427pt"
                        viewBox="-40 0 427 427.00131"
                        width="427pt"
                        xmlns="http://www.w3.org/2000/svg"
                      >
                        <path
                          d="m232.398438 154.703125c-5.523438 0-10 4.476563-10 10v189c0 5.519531 4.476562 10 10 10 5.523437 0 10-4.480469 10-10v-189c0-5.523437-4.476563-10-10-10zm0 0"
                        />
                        <path
                          d="m114.398438 154.703125c-5.523438 0-10 4.476563-10 10v189c0 5.519531 4.476562 10 10 10 5.523437 0 10-4.480469 10-10v-189c0-5.523437-4.476563-10-10-10zm0 0"
                        />
                        <path
                          d="m28.398438 127.121094v246.378906c0 14.5625 5.339843 28.238281 14.667968 38.050781 9.285156 9.839844 22.207032 15.425781 35.730469 15.449219h189.203125c13.527344-.023438 26.449219-5.609375 35.730469-15.449219 9.328125-9.8125 14.667969-23.488281 14.667969-38.050781v-246.378906c18.542968-4.921875 30.558593-22.835938 28.078124-41.863282-2.484374-19.023437-18.691406-33.253906-37.878906-33.257812h-51.199218v-12.5c.058593-10.511719-4.097657-20.605469-11.539063-28.03125-7.441406-7.421875-17.550781-11.5546875-28.0625-11.46875h-88.796875c-10.511719-.0859375-20.621094 4.046875-28.0625 11.46875-7.441406 7.425781-11.597656 17.519531-11.539062 28.03125v12.5h-51.199219c-19.1875.003906-35.394531 14.234375-37.878907 33.257812-2.480468 19.027344 9.535157 36.941407 28.078126 41.863282zm239.601562 279.878906h-189.203125c-17.097656 0-30.398437-14.6875-30.398437-33.5v-245.5h250v245.5c0 18.8125-13.300782 33.5-30.398438 33.5zm-158.601562-367.5c-.066407-5.207031 1.980468-10.21875 5.675781-13.894531 3.691406-3.675781 8.714843-5.695313 13.925781-5.605469h88.796875c5.210937-.089844 10.234375 1.929688 13.925781 5.605469 3.695313 3.671875 5.742188 8.6875 5.675782 13.894531v12.5h-128zm-71.199219 32.5h270.398437c9.941406 0 18 8.058594 18 18s-8.058594 18-18 18h-270.398437c-9.941407 0-18-8.058594-18-18s8.058593-18 18-18zm0 0"
                        />
                        <path
                          d="m173.398438 154.703125c-5.523438 0-10 4.476563-10 10v189c0 5.519531 4.476562 10 10 10 5.523437 0 10-4.480469 10-10v-189c0-5.523437-4.476563-10-10-10zm0 0"
                        />
                      </svg>
                    </button>
                  </div>
                </div>
                
              </div>

            </div>
            
          </div>
        </div>

        <div class="pt-5">
          <div class="flex justify-end">
            <router-link
              :to="{ name: 'dashboard' }"
              class="flex items-center bg-white py-2 px-4 border border-gray-300 rounded-md shadow-sm text-sm font-medium text-gray-700 hover:bg-gray-50 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-cyan-700"
            >
              <svg
                class="w-3 h-3 ml-2 fill-current text-gray-600"
                height="329pt"
                viewBox="0 0 329.26933 329"
                width="329pt"
                xmlns="http://www.w3.org/2000/svg"
              >
                <path
                  d="m194.800781 164.769531 128.210938-128.214843c8.34375-8.339844 8.34375-21.824219 0-30.164063-8.339844-8.339844-21.824219-8.339844-30.164063 0l-128.214844 128.214844-128.210937-128.214844c-8.34375-8.339844-21.824219-8.339844-30.164063 0-8.34375 8.339844-8.34375 21.824219 0 30.164063l128.210938 128.214843-128.210938 128.214844c-8.34375 8.339844-8.34375 21.824219 0 30.164063 4.15625 4.160156 9.621094 6.25 15.082032 6.25 5.460937 0 10.921875-2.089844 15.082031-6.25l128.210937-128.214844 128.214844 128.214844c4.160156 4.160156 9.621094 6.25 15.082032 6.25 5.460937 0 10.921874-2.089844 15.082031-6.25 8.34375-8.339844 8.34375-21.824219 0-30.164063zm0 0"
                ></path>
              </svg>
              إلغاء
            </router-link>

            <button
              type="submit"
              id="send_reply"
              @click="submit()"
              class="mr-3 flex items-center justify-center py-2 px-4 border border-transparent shadow-sm text-sm font-medium rounded-md text-white bg-cyan-600 hover:bg-cyan-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-cyan-700"
            >
              <svg
                class="w-4 h-4 ml-2 fill-current text-white"
                version="1.1"
                id="Capa_1"
                xmlns="http://www.w3.org/2000/svg"
                xmlns:xlink="http://www.w3.org/1999/xlink"
                x="0px"
                y="0px"
                viewBox="0 0 512 512"
                style="enable-background: new 0 0 512 512"
                xml:space="preserve"
              >
                <g>
                  <g>
                    <path
                      d="M506.955,1.314c-3.119-1.78-6.955-1.75-10.045,0.078L313.656,109.756c-4.754,2.811-6.329,8.943-3.518,13.697
                                                    c2.81,4.753,8.942,6.328,13.697,3.518l131.482-77.749L210.411,303.335L88.603,266.069l158.965-94
                                                    c4.754-2.812,6.329-8.944,3.518-13.698c-2.81-4.753-8.943-6.33-13.697-3.518L58.91,260.392c-3.41,2.017-5.309,5.856-4.84,9.791
                                                    s3.216,7.221,7.004,8.38l145.469,44.504L270.72,439.88c0.067,0.121,0.136,0.223,0.207,0.314c1.071,1.786,2.676,3.245,4.678,4.087
                                                    c1.253,0.527,2.57,0.784,3.878,0.784c2.563,0,5.086-0.986,6.991-2.849l73.794-72.12l138.806,42.466
                                                    c0.96,0.293,1.945,0.438,2.925,0.438c2.116,0,4.206-0.672,5.948-1.961C510.496,409.153,512,406.17,512,403V10
                                                    C512,6.409,510.074,3.093,506.955,1.314z M271.265,329.23c-1.158,1.673-1.779,3.659-1.779,5.694v61.171l-43.823-79.765
                                                    l193.921-201.21L271.265,329.23z M289.486,411.309v-62.867l48.99,14.988L289.486,411.309z M492,389.483l-196.499-60.116
                                                    L492,45.704V389.483z"
                    ></path>
                  </g>
                </g>
                <g>
                  <g>
                    <path
                      d="M164.423,347.577c-3.906-3.905-10.236-3.905-14.143,0l-93.352,93.352c-3.905,3.905-3.905,10.237,0,14.143
                                                    C58.882,457.024,61.441,458,64,458s5.118-0.976,7.071-2.929l93.352-93.352C168.328,357.815,168.328,351.483,164.423,347.577z"
                    ></path>
                  </g>
                </g>
                <g>
                  <g>
                    <path
                      d="M40.071,471.928c-3.906-3.903-10.236-3.903-14.142,0.001l-23,23c-3.905,3.905-3.905,10.237,0,14.143
                                                    C4.882,511.024,7.441,512,10,512s5.118-0.977,7.071-2.929l23-23C43.976,482.166,43.976,475.834,40.071,471.928z"
                    ></path>
                  </g>
                </g>
                <g>
                  <g>
                    <path
                      d="M142.649,494.34c-1.859-1.86-4.439-2.93-7.069-2.93c-2.641,0-5.21,1.07-7.07,2.93c-1.86,1.86-2.93,4.43-2.93,7.07
                                                    c0,2.63,1.069,5.21,2.93,7.07c1.86,1.86,4.44,2.93,7.07,2.93s5.21-1.07,7.069-2.93c1.86-1.86,2.931-4.44,2.931-7.07
                                                    C145.58,498.77,144.51,496.2,142.649,494.34z"
                    ></path>
                  </g>
                </g>
                <g>
                  <g>
                    <path
                      d="M217.051,419.935c-3.903-3.905-10.233-3.905-14.142,0l-49.446,49.445c-3.905,3.905-3.905,10.237,0,14.142
                                                    c1.953,1.953,4.512,2.929,7.071,2.929s5.118-0.977,7.071-2.929l49.446-49.445C220.956,430.172,220.956,423.84,217.051,419.935z"
                    ></path>
                  </g>
                </g>
                <g>
                  <g>
                    <path
                      d="M387.704,416.139c-3.906-3.904-10.236-3.904-14.142,0l-49.58,49.58c-3.905,3.905-3.905,10.237,0,14.143
                                                    c1.953,1.952,4.512,2.929,7.071,2.929s5.118-0.977,7.071-2.929l49.58-49.58C391.609,426.377,391.609,420.045,387.704,416.139z"
                    ></path>
                  </g>
                </g>
                <g>
                  <g>
                    <path
                      d="M283.5,136.31c-1.86-1.86-4.44-2.93-7.07-2.93s-5.21,1.07-7.07,2.93c-1.859,1.86-2.93,4.44-2.93,7.08
                                                    c0,2.63,1.07,5.2,2.93,7.06c1.86,1.87,4.44,2.93,7.07,2.93s5.21-1.06,7.07-2.93c1.859-1.86,2.93-4.43,2.93-7.06
                                                    C286.43,140.75,285.36,138.17,283.5,136.31z"
                    ></path>
                  </g>
                </g>
              </svg>

              إرسال
            </button>
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

          <div class="mt-10 flex justify-center">
            <router-link
              :to="{ name: 'dashboard' }"
              class="bg-black text-center text-xs md:text-sm font-normal tracking-widest w-32 py-3 text-white rounded focus:outline-none hover:bg-white hover:text-black border hover:border-black transform duration-700"
              >رجوع</router-link
            >
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
import editocomponent from "@/components/editor-component.vue";

export default {
  components: {
    asidebar,
    navaca,
    editocomponent,
  },
  created() {
    // this.getmailbyId();
  },
  data() {
    return {
      reply: "",
      showModal: false,
      imagePassToModal: null,

      originalDocuments: [],
      marginalizedDocumentsToShow: [],
      marginalizedDocumentsToSend: [],
      sender: "",
      mailType: 1,
      releaseDate: "releaseDate",
      sentMessage: "sentMessage",
      mailId: '',
      showAlert: false,
      loading: false,
      Successed: false,
      addSuccessed: "",
      addErorr: null,

      marginalizedDocumentsLoading : true,
      documentsLoading : true,


      ProcessingResponses: []
    };
  },

  mounted() {

    this.mailId = this.$route.params.mail;
    if (this.$route.params.mail) {


        



      this.$http.mailService
        .GetMailById(this.mailId)
        .then((res) => {
          console.log(res.data.result)
          var mail = res.data.result

          this.sender = mail.sender
          this.flag = mail.flag
          this.mailType = mail.mailType
          this.sentMessage = mail.sentMessage
          this.releaseDate = mail.releaseDate
          this.reply = mail.reply


          this.GetDocmentForMail();
          this.GetDocmentForMailToShow();


          this.GetProcessingResponses()

if(this.flag == 1){ 
          this.$http.mailService
        .BossSee(this.mailId)
        .then((res) => {
          console.log("res")
          console.log(res)

          console.log("res")
        })
        .catch((err) => {
          console.log(err)
        });
          
}


          // this.loading = false;
          // this.Successed = true;
          // this.addSuccessed = res.data.response;
          
        })
        .catch((err) => {
          // this.loading = false;
          // this.Successed = false;
          this.addErorr = err;
        });

      // this.title_page = "Edit Product";
      // this.submit_text = "Edit";
      // this.showDelete = true;
    } else {
      // this.title_page = "Add Product";
      // this.submit_text = "Add";
    }

    
  },


  methods: {

    GetProcessingResponses() {
      this.$http.processingResponsesService
        .GetProcessingResponses()
        .then((res) => {
          this.ProcessingResponses = res.data.result.processingResponses;
        })
        .catch((err) => {
          console.log(err);
        });
    },

    GetDocmentForMail(){
      this.$http.documentService
        .GetDocmentForMail(Number(this.mailId), 1)
        .then((res) => {
          setTimeout(() => {
            this.originalDocuments = res.data.result.documents
            this.documentsLoading =false
          }, 500);
          
        })
        .catch((err) => {
          this.addErorr = err.message; 
        });
    },

    GetDocmentForMailToShow(){
      this.$http.documentService
        .GetDocmentForMail(Number(this.mailId), 2)
        .then((res) => {

          setTimeout(() => {
          this.marginalizedDocumentsToShow = res.data.result.documents
            this.marginalizedDocumentsLoading =false
          }, 500);

        })
        .catch((err) => {
          this.addErorr = err.message; 
        });
    },

    

    setTextToResponses(responses) {
      document.getElementById("responses").value =
        document.getElementById("responses").value + "   " + responses + "\n";

      this.reply = this.reply + "  " + responses + "\n";
    },

    toggleShowModal(img) {
      this.imagePassToModal = img;
      this.showModal = !this.showModal;
    },

    marginalizedDocumentsFromChild(value) {
      this.marginalizedDocumentsToSend.push({documentFile: value});
    },

    removeImageFromArrayToSend(index) {
      this.marginalizedDocumentsToSend.splice(index, 1);
    },

   

    deleteDocument(documentId, index){
      this.$http.documentService
        .DeleteDocument(Number(documentId))
        .then((res) => {
          this.marginalizedDocumentsToShow.splice(index, 1);
          console.log(res)
        })
        .catch((err) => {
          this.addErorr = err.message; 
        });

    },


    submit() {
      this.showAlert = true;
      this.loading = true;
      var senderreply = {
        mailId: Number(this.mailId),

        reply: this.reply,
        Documents: this.marginalizedDocumentsToSend,
      };
      this.$http.mailService
        .ReplyMail(senderreply)
        .then((res) => {
          this.loading = false;
          this.Successed = true;
          this.addSuccessed = res.data.result.message;

          this.GetDocmentForMailToShow();
        })
        .catch((err) => {
          this.loading = false;
          this.Successed = false;
          this.addErorr = err.message;
        });
    },
  },
};
</script>
