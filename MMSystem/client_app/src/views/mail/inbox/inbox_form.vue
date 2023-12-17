<template>
  <div class="">
    <div class="h-screen bg-gray-100 overflow-hidden flex">
      <asideComponent></asideComponent>
      <div class="flex-1 bg-gray-200 w-0 overflow-y-auto pb-20">
        <div class="max-w-screen-2xl mx-auto flex flex-col md:px-8">
          <navComponent></navComponent>
          <main class="flex-1 relative focus:outline-none pt-2 pb-6">
            <div class="flex justify-between items-center">
              <h3 class="text-xl font-semibold text-gray-900">
                معلومات البريد
              </h3>
              <!-- 
                                animate-bounce
                            -->
              <div class="float-left text-base font-semibold text-gray-800">
                رقم الرسالة
                <span class="mr-4 underline font-bold text-2xl">
                  {{ mail_Number }} - {{ department_Id }} - {{ mail_year }}
                </span>
              </div>
            </div>

            <div class="mt-6 space-y-6">
              <div class="grid grid-cols-7 gap-6">
                <section class="col-span-5 flex justify-between items-stretch">
                  <section
                    class="w-6/12 ml-3 grid grid-cols-1 gap-y-6 gap-x-4 sm:grid-cols-6 bg-gray-100 rounded-md p-6"
                  >
                    <div class="sm:col-span-3">
                      <label
                        for=""
                        class="block text-base font-semibold text-gray-800"
                      >
                        نوع البريد
                      </label>

                      <div
                        class="block mt-2 w-full rounded-md h-10 text-sm border border-green-400 p-2"
                      >
                        {{ to_test_passing_mail_type | mail_type }}
                      </div>
                    </div>

                    <div class="sm:col-span-3"></div>

                    <div class="sm:col-span-3">
                      <label
                        for="classification"
                        class="block text-base font-semibold text-gray-800"
                      >
                        التصنيف
                      </label>
                      <div
                        class="block mt-2 w-full rounded-md h-10 text-sm border border-green-400 p-2"
                      >
                        {{ classification }}
                      </div>
                    </div>

                    <div class="sm:col-span-3">
                      <label
                        for="date"
                        class="block text-base font-semibold text-gray-800"
                      >
                        التاريخ
                      </label>

                      <div
                        class="block mt-2 w-full rounded-md h-10 text-sm border border-green-400 p-2"
                      >
                        {{ releaseDate }}
                      </div>
                    </div>

                    <div class="sm:col-span-3">
                      <label
                        for="general_incoming_number"
                        class="block text-base font-semibold text-gray-800"
                      >
                        رقم الوارد العام
                      </label>

                      <div
                        class="block mt-2 w-full rounded-md h-10 text-sm border border-green-400 p-2"
                      >
                        {{ general_incoming_number }}
                      </div>
                    </div>

                    <div class="sm:col-span-3">
                      <label
                        for="year"
                        class="block text-base font-semibold text-gray-800"
                      >
                        السنة
                      </label>
                      <div
                        class="block mt-2 w-full rounded-md h-10 text-sm border border-green-400 p-2"
                      >
                        {{ genaral_inbox_year }}
                      </div>
                    </div>
                  </section>

                  <section
                    class="w-6/12 mr-3 grid grid-cols-1 gap-y-6 gap-x-4 sm:grid-cols-6 bg-gray-100 rounded-md p-6"
                  >
                    <div class="sm:col-span-6">
                      <label
                        for="summary"
                        class="block text-base font-semibold text-gray-800"
                      >
                        الملخص
                      </label>

                      <div
                        class="block mt-2 w-full rounded-md h-24 text-sm border border-green-400 p-2 overflow-y-scroll"
                      >
                        {{ summary }}
                      </div>
                    </div>

                    <div class="sm:col-span-6">
                      <label
                        for="action_required"
                        class="block text-base font-semibold text-gray-800"
                      >
                        الإجراء المطلوب
                      </label>
                      <div
                        class="block mt-2 w-full rounded-md h-24 text-sm border border-green-400 p-2 overflow-y-scroll"
                      >
                        {{ required_action }}
                      </div>
                    </div>
                  </section>
                </section>

                <section class="col-span-2 bg-gray-100 rounded-md p-6">
                  <div class="flex justify-between items-center">
                    <h3 class="block text-base font-semibold text-gray-800">
                      المستندات
                    </h3>
                  </div>

                  <div class="flex justify-between items-center mt-2">
                    <div v-if="image_of_doc" class="w-1/2 flex items-center">
                      <input
                        type="text"
                        v-model="doc_number_to_search"
                        id="doc_number"
                        class="ml-2 block w-16 rounded-md h-10 text-sm border border---200 hover:shadow-sm focus:outline-none focus:border-blue-300 p-2"
                      />

                      <button
                        @click="search_the_doc()"
                        class="py-2 px-4 bg-white rounded-lg tracking-wide border border-blue-600 cursor-pointer hover:text-white hover:bg-blue-600 focus:outline-none duration-300 text-sm leading-normal"
                      >
                        بحث
                      </button>
                    </div>
                  </div>

                  <div
                    v-if="image_of_doc"
                    class="h-72 w-full bg-gray-100 rounded-md mt-4 mb-10"
                  >
                    <!--  v-if="imagesToSend != '' || imagesToShow != ''" -->
                    <div class="mt-4 pt-4 pb-4 rounded-md relative">
                      <div
                        v-if="!roles.includes('s')"
                        class="cursor-not-allowed w-full h-full bg-gray-900 bg-opacity-90 absolute z-20 inset-0"
                      ></div>
                      <div class="">
                        <div class="relative h-64 w-full">
                          <img
                            :src="image_of_doc"
                            alt="image"
                            class="w-full h-full rounded object-contain"
                          />

                          <div
                            class="absolute inset-0 flex justify-between items-center"
                          >
                            <div class="">
                              <button
                                @click="farst_documents()"
                                class="bg-gray-500 hover:bg-gray-400 px-2 py-2 rounded-lg text-xs text-white"
                              >
                                &#x276E; &#x276E;
                              </button>
                            </div>

                            <div class="">
                              <button
                                @click="show_current_image_for_bigger_screen()"
                                type="button"
                                class="bg-green-600 hover:bg-green-500 duration-500 p-2 rounded-full focus:outline-none ml-2"
                              >
                                <svg
                                  class="w-4 h-4 text-white mx-auto"
                                  fill="none"
                                  stroke="currentColor"
                                  viewBox="0 0 24 24"
                                  xmlns="http://www.w3.org/2000/svg"
                                >
                                  <path
                                    stroke-linecap="round"
                                    stroke-linejoin="round"
                                    stroke-width="2"
                                    d="M21 21l-6-6m2-5a7 7 0 11-14 0 7 7 0 0114 0zM10 7v3m0 0v3m0-3h3m-3 0H7"
                                  ></path>
                                </svg>
                              </button>
                            </div>

                            <div class="">
                              <button
                                @click="last_documents()"
                                class="bg-gray-500 hover:bg-gray-400 px-2 py-2 rounded-lg text-xs text-white"
                              >
                                &#x276F; &#x276F;
                              </button>
                            </div>
                          </div>
                        </div>

                        <div
                          class="flex justify-between items-center pt-2 MB-2"
                        >
                          <div
                            class="ml-2 flex justify-between items-center w-full"
                          >
                            <div class="w-8 h-8">
                              <button
                                title="prev"
                                v-if="doc_number > 1"
                                @click="GetAllDocN('prev')"
                                class="w-8 h-8 bg-gray-300 rounded flex justify-center items-center"
                              >
                                <svg
                                  class="w-4 h-4"
                                  fill="none"
                                  stroke="currentColor"
                                  viewBox="0 0 24 24"
                                  xmlns="http://www.w3.org/2000/svg"
                                >
                                  <path
                                    stroke-linecap="round"
                                    stroke-linejoin="round"
                                    stroke-width="2"
                                    d="M9 5l7 7-7 7"
                                  ></path>
                                </svg>
                              </button>
                            </div>

                            <div class="">
                              {{ doc_number }} / {{ total_of_doc }}
                            </div>

                            <div class="w-8 h-8">
                              <button
                                v-if="doc_number < total_of_doc"
                                title="next"
                                @click="GetAllDocN('next')"
                                class="w-8 h-8 bg-gray-300 rounded flex justify-center items-center"
                              >
                                <svg
                                  class="w-4 h-4"
                                  fill="none"
                                  stroke="currentColor"
                                  viewBox="0 0 24 24"
                                  xmlns="http://www.w3.org/2000/svg"
                                >
                                  <path
                                    stroke-linecap="round"
                                    stroke-linejoin="round"
                                    stroke-width="2"
                                    d="M15 19l-7-7 7-7"
                                  ></path>
                                </svg>
                              </button>
                            </div>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                </section>
              </div>

              <section
                v-if="mailType == '2' || mailType == '3'"
                class="grid grid-cols-1 gap-y-6 gap-x-4 sm:grid-cols-8 bg-gray-100 rounded-md p-6"
              >
                <div class="sm:col-span-2">
                  <label
                    class="block text-base font-semibold text-gray-800 w-24"
                  >
                    <div v-if="mailType == '2'">توجيه البريد</div>

                    <div v-if="mailType == '3'">وارد من</div>
                  </label>
                </div>

                <div
                  class="sm:col-span-8 mt-2 w-full rounded-md text-sm border border-gray-400 p-2 flex flex-wrap"
                >
                  <div
                    v-for="(sectoin, index) in external_sectoin"
                    :key="index"
                    class="rounded-md border border-green-400 p-2 ml-4 mb-4"
                  >
                    {{ sectoin.mail_forwarding | mail_forwarding_filter }}
                    /
                    {{ sectoin.sector_name }}
                    /
                    {{ sectoin.side_name }}
                  </div>
                </div>

                <div v-if="mailType == '3'" class="sm:col-span-2">
                  <label
                    class="block text-base font-semibold text-gray-800 w-24"
                  >
                    وارد إلى
                  </label>

                  <div
                    class="block mt-2 w-full rounded-md h-10 text-sm border border-green-400 p-2"
                  >
                    {{ ward_to | ward_to_filter }}
                  </div>
                </div>

                <div v-if="mailType == '3'" class="sm:col-span-2">
                  <label
                    class="block text-base font-semibold text-gray-800 w-24"
                  >
                    نوعها
                  </label>

                  <div
                    class="block mt-2 w-full rounded-md h-10 text-sm border border-green-400 p-2"
                  >
                    {{ mail_ward_type | mail_ward_type_filter }}
                  </div>
                </div>

                <div v-if="mailType == '3'" class="sm:col-span-2">
                  <label
                    for="entity_mail_date"
                    class="block text-base font-semibold text-gray-800"
                  >
                    تاريخ رسالة الجهة
                  </label>
                  <div
                    class="block mt-2 w-full rounded-md h-10 text-sm border border-green-400 p-2"
                  >
                    {{ entity_mail_date }}
                  </div>
                </div>

                <div v-if="mailType == '3'" class="sm:col-span-2">
                  <label
                    for="entity_reference_number"
                    class="block text-base font-semibold text-gray-800"
                  >
                    رقم إشارة الجهة
                  </label>
                  <div
                    class="block mt-2 w-full rounded-md h-10 text-sm border border-green-400 p-2"
                  >
                    {{ entity_reference_number }}
                  </div>
                </div>

                <div v-if="mailType == '3'" class="sm:col-span-2">
                  <label
                    for="procedure_type"
                    class="block text-base font-semibold text-gray-800"
                  >
                    نوع الإجراء
                  </label>
                  <div
                    class="block mt-2 w-full rounded-md h-10 text-sm border border-green-400 p-2"
                  >
                    {{ procedure_type | procedure_type_filter }}
                  </div>
                </div>

                <div v-if="mailType == '2'" class="sm:col-span-6">
                  <label
                    for="action_required"
                    class="block text-base font-semibold text-gray-800"
                  >
                    الإجراء المطلوب من الجهة
                  </label>
                  <div
                    class="block mt-2 w-full rounded-md h-24 text-sm border border-green-400 p-2 overflow-y-scroll"
                  >
                    {{ action_required_by_the_entity }}
                  </div>
                </div>
              </section>

              <section
                v-if="roles.includes('r')"
                class="bg-gray-100 rounded-md p-6"
              >
                <p class="block text-base font-semibold text-gray-800">
                  الردود
                </p>

                <div
                  id="scroll"
                  class="h-72 overflow-y-scroll mt-4 rounded-lg py-2 border border-green-400"
                >
                  <div
                    v-for="(reply, index) in replies"
                    :key="index"
                    :class="
                      reply.reply.to == my_department_id
                        ? ' flex-row-reverse justify-start '
                        : 'justify-start'
                    "
                    class="w-full my-0.5 flex px-2"
                  >
                    <div class="">
                      <div
                        class="flex"
                        :class="
                          reply.reply.to == my_department_id
                            ? '  justify-end'
                            : 'justify-end flex-row-reverse'
                        "
                      >
                        <button
                          v-if="
                            reply.reply.to != my_department_id &&
                            reply.reply.userId == my_user_id
                          "
                          @click="
                            (alert_delete_document = true),
                              (reply_id_to_delete = reply.reply.replyId)
                          "
                          type="button"
                          class="hover:bg-red-500 duration-500 p-1 rounded-full focus:outline-none ml-2"
                        >
                          <svg
                            class="w-4 h-4 stroke-current text-red mx-auto"
                            width="24"
                            height="25"
                            viewBox="0 0 24 25"
                            fill="none"
                            xmlns="http://www.w3.org/2000/svg"
                          >
                            <path
                              d="M3 6.5H5H21"
                              stroke-width="2"
                              stroke-linecap="round"
                              stroke-linejoin="round"
                            />
                            <path
                              d="M8 6.5V4.5C8 3.96957 8.21071 3.46086 8.58579 3.08579C8.96086 2.71071 9.46957 2.5 10 2.5H14C14.5304 2.5 15.0391 2.71071 15.4142 3.08579C15.7893 3.46086 16 3.96957 16 4.5V6.5M19 6.5V20.5C19 21.0304 18.7893 21.5391 18.4142 21.9142C18.0391 22.2893 17.5304 22.5 17 22.5H7C6.46957 22.5 5.96086 22.2893 5.58579 21.9142C5.21071 21.5391 5 21.0304 5 20.5V6.5H19Z"
                              stroke-width="2"
                              stroke-linecap="round"
                              stroke-linejoin="round"
                            />
                          </svg>
                        </button>

                        <div
                          v-if="alert_delete_document"
                          class="w-screen h-full flex justify-center items-center absolute inset-0 z-50 overflow-hidden bg-black bg-opacity-70"
                        >
                          <div
                            class="bg-yellow-100 rounded-md w-1/3 py-10 flex flex-col justify-center items-center"
                          >
                            <div class="">
                              <svg
                                class="w-20 h-20 stroke-current text-red-600"
                                fill="none"
                                stroke="currentColor"
                                viewBox="0 0 24 24"
                                xmlns="http://www.w3.org/2000/svg"
                              >
                                <path
                                  stroke-linecap="round"
                                  stroke-linejoin="round"
                                  stroke-width="2"
                                  d="M12 9v2m0 4h.01m-6.938 4h13.856c1.54 0 2.502-1.667 1.732-3L13.732 4c-.77-1.333-2.694-1.333-3.464 0L3.34 16c-.77 1.333.192 3 1.732 3z"
                                ></path>
                              </svg>
                            </div>
                            <p class="text-xl font-bold mt-4">
                              هل انت متأكد من عملية الحذف؟
                            </p>
                            <p class="text-gray-600">
                              لن تتمكن من استرداد الرد بعد حذفه.
                            </p>

                            <div class="mt-6">
                              <button
                                @click="deletereply()"
                                class="bg-red-600 hover:bg-red-700 hover:shadow-lg duration-200 rounded text-white w-32 py-1 ml-2"
                              >
                                نعم متأكد
                              </button>
                              <button
                                @click="alert_delete_document = false"
                                class="bg-gray-400 hover:bg-gray-700 hover:shadow-lg duration-200 rounded text-white w-32 py-1 mr-2"
                              >
                                إلغاء
                              </button>
                            </div>
                          </div>
                        </div>

                        <div v-if="reply.resources != 0" class="mx-2">
                          <button
                            v-if="roles.includes('r')"
                            @click="GetResources_ById(reply.reply.replyId)"
                            class="px-2 text-xs rounded leading-9 text-white bg-red-400 flex items-center"
                          >
                            عرض الصور
                            <svg
                              class="stroke-current mr-2 w-6 h-6"
                              width="24"
                              height="24"
                              viewBox="0 0 24 24"
                              fill="none"
                              xmlns="http://www.w3.org/2000/svg"
                            >
                              <path
                                d="M19 3H5C3.89543 3 3 3.89543 3 5V19C3 20.1046 3.89543 21 5 21H19C20.1046 21 21 20.1046 21 19V5C21 3.89543 20.1046 3 19 3Z"
                                stroke-width="1"
                                stroke-linecap="round"
                                stroke-linejoin="round"
                              />
                              <path
                                d="M8.5 10C9.32843 10 10 9.32843 10 8.5C10 7.67157 9.32843 7 8.5 7C7.67157 7 7 7.67157 7 8.5C7 9.32843 7.67157 10 8.5 10Z"
                                stroke-width="1"
                                stroke-linecap="round"
                                stroke-linejoin="round"
                              />
                              <path
                                d="M21 15L16 10L5 21"
                                stroke-width="1"
                                stroke-linecap="round"
                                stroke-linejoin="round"
                              />
                            </svg>
                          </button>
                        </div>

                        <div
                          :class="
                            reply.reply.to == my_department_id
                              ? 'bg-gray-700'
                              : 'bg-blue-700'
                          "
                          class="text-white max-w-10/12 py-0 leading-9 px-2 rounded"
                        >
                          {{ reply.reply.mail_detail }}
                        </div>
                      </div>

                      <div
                        class="mt-1 text-sm"
                        :class="
                          reply.reply.to == my_department_id
                            ? 'text-left'
                            : 'text-right'
                        "
                      >
                        {{ reply.reply.date }}
                      </div>
                    </div>
                  </div>
                </div>

                <div class="flex justify-between items-center mt-4">
                  <div class="w-9/12 flex justify-between">
                    <div class="w-10/12">
                      <textarea
                        id=""
                        class="block w-full h-20 text-sm rounded-md border hover:shadow-sm focus:outline-none border-green-400 p-2"
                        v-model="reply_to_add"
                      >
                      </textarea>
                    </div>

                    <div class="w-2/12 mr-4">
                      <!-- <input class="hidden" type="button" @click="scanToReply" />-->
                      <a id="a5" @click="reply1()">
                        <label
                          v-if="reply_to_add != ''"
                          class="w-48 h-full flex justify-center items-center py-2 bg-white rounded-lg tracking-wide border border-green-600 cursor-pointer hover:text-white hover:bg-green-600 focus:outline-none duration-300"
                        >
                          <svg
                            class="w-5 h-5 ml-2"
                            fill="currentColor"
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
                                <g>
                                  <path
                                    d="M509.501,116.968c1.6-1.6,2.499-3.771,2.499-6.035V76.8c-0.019-1.015-0.222-2.019-0.598-2.962
                                              c-0.076-0.203-0.14-0.399-0.23-0.595c-0.391-0.864-0.925-1.655-1.579-2.342c-0.123-0.128-0.265-0.221-0.396-0.341
                                              c-0.309-0.312-0.643-0.6-0.997-0.86l-102.4-68.267C404.399,0.499,402.752,0,401.067,0H110.933
                                              c-1.685,0.001-3.331,0.499-4.733,1.434L3.8,69.7c-0.354,0.26-0.688,0.548-0.997,0.86c-0.131,0.12-0.273,0.214-0.396,0.341
                                              c-0.654,0.687-1.188,1.478-1.579,2.342c-0.091,0.195-0.154,0.392-0.23,0.595C0.222,74.781,0.019,75.785,0,76.8v34.133
                                              c-0.001,2.263,0.898,4.434,2.499,6.035c1.6,1.6,3.771,2.499,6.035,2.499h73.225L0.496,347c-0.114,0.476-0.184,0.961-0.21,1.449
                                              c-0.138,0.463-0.233,0.937-0.286,1.417V435.2c0.028,23.553,19.114,42.639,42.667,42.667h17.067v17.067
                                              c0.011,9.421,7.645,17.056,17.067,17.067h358.4c9.421-0.011,17.056-7.645,17.067-17.067v-17.067h17.067
                                              c23.553-0.028,42.639-19.114,42.667-42.667v-85.333c-0.218-0.946-0.383-1.903-0.496-2.867l-81.262-227.533h73.225
                                              C505.73,119.467,507.901,118.568,509.501,116.968z M113.517,17.067h284.967l76.8,51.2H36.717L113.517,17.067z M76.8,494.933
                                              v-17.067h358.404l0.008,17.067H76.8z M494.933,435.2c-0.015,14.132-11.468,25.585-25.6,25.6H42.667
                                              c-14.132-0.015-25.585-11.468-25.6-25.6v-76.8H128v42.667c0.015,14.132,11.468,25.585,25.6,25.6h204.8
                                              c14.132-0.015,25.585-11.468,25.6-25.6V358.4h110.933V435.2z M164.632,390.035c1.6,1.6,3.771,2.499,6.035,2.499h170.667
                                              c2.263,0.001,4.434-0.898,6.035-2.499c1.6-1.6,2.499-3.771,2.499-6.035v-25.6h17.067v42.667
                                              c-0.005,4.711-3.822,8.529-8.533,8.533H153.6c-4.711-0.005-8.529-3.822-8.533-8.533V358.4h17.067V384
                                              C162.133,386.263,163.032,388.434,164.632,390.035z M179.2,375.467V358.4h17.067v17.067H179.2z M213.333,375.467V358.4H230.4
                                              v17.067H213.333z M247.467,375.467V358.4h17.067v17.067H247.467z M281.6,375.467V358.4h17.067v17.067H281.6z M315.733,375.467
                                              V358.4H332.8v17.067H315.733z M491.358,341.333H20.642L99.88,119.467h312.24L491.358,341.333z M494.933,102.4H17.067V85.333
                                              h477.867V102.4z"
                                  />
                                  <path
                                    d="M68.267,375.467H51.2c-9.421,0.011-17.056,7.646-17.067,17.067V409.6c0.011,9.421,7.645,17.056,17.067,17.067h17.067
                                              c9.421-0.011,17.056-7.645,17.067-17.067v-17.067C85.323,383.112,77.688,375.477,68.267,375.467z M51.2,409.6v-17.067h17.067
                                              l0.012,17.067H51.2z"
                                  />
                                  <path
                                    d="M388.067,136.533H123.933c-7.21,0.012-13.639,4.545-16.071,11.333L53,301.458c-1.863,5.227-1.07,11.034,2.127,15.57
                                              s8.399,7.236,13.948,7.238h373.85c5.548-0.003,10.748-2.701,13.945-7.235c3.197-4.534,3.991-10.339,2.13-15.565l-54.862-153.6
                                              C401.705,141.079,395.277,136.546,388.067,136.533z M69.067,307.225l0.009-0.017V307.2l54.858-153.6h264.129l54.862,153.6
                                              L69.067,307.225z"
                                  />
                                  <path
                                    d="M128.009,221.867c1.682-0.001,3.326-0.5,4.725-1.434l25.6-17.067c3.872-2.633,4.899-7.894,2.302-11.79
                                              s-7.849-4.971-11.768-2.409l-25.6,17.067c-3.13,2.087-4.524,5.977-3.432,9.577C120.927,219.41,124.247,221.87,128.009,221.867z"
                                  />
                                  <path
                                    d="M179.2,187.733c2.855,0.03,5.532-1.385,7.115-3.761c1.584-2.376,1.86-5.39,0.735-8.014
                                              c-1.031-2.685-3.362-4.656-6.181-5.227c-2.819-0.571-5.733,0.338-7.728,2.41c-0.755,0.829-1.363,1.782-1.796,2.817
                                              c-1.122,2.625-0.844,5.639,0.74,8.013C173.67,186.346,176.346,187.761,179.2,187.733z"
                                  />
                                  <path
                                    d="M225.542,172.183l-110.933,76.8c-3.071,2.125-4.403,6.001-3.287,9.565c1.116,3.564,4.419,5.989,8.154,5.984
                                              c1.733,0.001,3.426-0.529,4.85-1.517l110.933-76.8c3.864-2.687,4.824-7.996,2.144-11.865
                                              C234.723,170.482,229.417,169.512,225.542,172.183z"
                                  />
                                  <path
                                    d="M463.275,407.125c0.829,0.753,1.78,1.359,2.813,1.792c2.066,0.911,4.421,0.911,6.487,0
                                              c1.034-0.433,1.987-1.039,2.817-1.792c0.751-0.832,1.357-1.784,1.792-2.817c0.438-1.026,0.67-2.127,0.683-3.242
                                              c-0.016-0.545-0.073-1.088-0.171-1.625c-0.082-0.563-0.255-1.109-0.513-1.617c-0.187-0.546-0.447-1.064-0.771-1.542
                                              c-0.313-0.446-0.654-0.872-1.021-1.275c-0.816-0.771-1.772-1.379-2.817-1.792c-3.177-1.341-6.849-0.634-9.3,1.792l-1.025,1.275
                                              c-0.324,0.477-0.583,0.996-0.771,1.542c-0.258,0.507-0.43,1.053-0.508,1.617c-0.1,0.536-0.157,1.08-0.171,1.625
                                              c0.012,1.115,0.243,2.216,0.679,3.242C461.914,405.342,462.521,406.295,463.275,407.125z"
                                  />
                                  <path
                                    d="M431.954,408.916c2.067,0.911,4.421,0.911,6.487,0c1.034-0.433,1.987-1.039,2.817-1.792
                                              c0.751-0.832,1.357-1.784,1.792-2.817c0.437-1.025,0.669-2.126,0.683-3.241c-0.016-0.545-0.073-1.088-0.171-1.625
                                              c-0.082-0.563-0.255-1.109-0.513-1.617c-0.187-0.546-0.447-1.064-0.771-1.542c-0.338-0.425-0.679-0.85-1.021-1.275
                                              c-0.83-0.753-1.783-1.359-2.817-1.792c-3.178-1.333-6.845-0.626-9.3,1.792l-1.025,1.275c-0.324,0.477-0.583,0.996-0.771,1.542
                                              c-0.258,0.507-0.43,1.053-0.508,1.617c-0.1,0.536-0.157,1.08-0.171,1.625c-0.029,1.119,0.204,2.229,0.679,3.242
                                              C428.126,406.449,429.813,408.136,431.954,408.916z"
                                  />
                                </g>
                              </g>
                            </g>
                          </svg>

                          <span class="text-sm leading-normal"> تصوير </span>
                        </label>
                      </a>
                    </div>
                  </div>

                  <div class="w-2/12 mr-4">
                    <button
                      v-if="reply_to_add != ''"
                      @click="AddReply()"
                      class="w-full flex items-center justify-center h-20 py-2 bg-white rounded-lg text-blue-600 tracking-wide border border-blue-600 cursor-pointer hover:text-white hover:bg-blue-600 focus:outline-none duration-300"
                    >
                      <span class="leading-normal">إرسال</span>
                      <svg
                        class="w-6 h-6 mr-2"
                        viewBox="0 0 441 441"
                        fill="currentColor"
                        xmlns="http://www.w3.org/2000/svg"
                      >
                        <g clip-path="url(#clip0)">
                          <path
                            d="M26.2637 181.168L382.073 33.5286C397.063 27.3081 413.997 30.0445 426.267 40.6664C438.538 51.29 443.669 67.6578 439.659 83.384L404.694 220.501L439.659 357.617C443.669 373.343 438.538 389.711 426.268 400.335C413.974 410.979 397.036 413.681 382.073 407.472L26.2637 259.833C10.0639 253.111 0.000120282 238.04 0.000120282 220.501C0.000120282 202.961 10.0639 187.89 26.2637 181.168ZM36.1681 235.966L391.977 383.605C397.96 386.087 404.456 385.039 409.354 380.798C414.252 376.558 416.22 370.279 414.619 364.001L381.321 233.42H252.927C245.791 233.42 240.007 227.636 240.007 220.5C240.007 213.364 245.791 207.579 252.927 207.579H381.32L414.619 76.9998C416.22 70.7224 414.252 64.4434 409.354 60.203C404.457 55.9627 397.963 54.9136 391.978 57.396L36.1681 205.035C26.5859 209.011 25.8408 217.878 25.8408 220.501C25.8408 223.123 26.5859 231.99 36.1681 235.966Z"
                            fill="currentColor"
                          />
                        </g>
                        <defs>
                          <clipPath id="clip0">
                            <rect
                              width="441"
                              height="441"
                              fill="white"
                              transform="matrix(-1 0 0 1 441 0)"
                            />
                          </clipPath>
                        </defs>
                      </svg>
                    </button>
                  </div>
                </div>
              </section>
            </div>
          </main>
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
    </div>

    <div
      v-if="show_current_image_for_bigger_screen_model"
      class="w-screen h-full absolute inset-0 z-50 overflow-hidden"
    >
      <div class="relative">
        <div
          v-if="image_to_print_n_model"
          id="printMe"
          class="bg-black bg-opacity-50 h-screen-100"
        >
          <div
            v-for="image in image_to_print_n"
            :key="image.id"
            class="h-screen-100"
          >
            <img
              :src="image.path"
              alt=""
              class="h-full w-full object-contain"
            />
          </div>
        </div>

        <div
          v-if="image_to_print_n_model"
          id="print_one_dec"
          class="bg-black bg-opacity-50 h-screen-100"
        >
          <div class="h-screen-100">
            <img
              :src="image_of_doc"
              alt=""
              class="h-full w-full object-contain"
            />
          </div>
        </div>

        <div
          class="h-screen flex flex-col justify-center items-center bg-black bg-opacity-90 absolute top-0 inset-0 z-50 w-full"
        >
        <button type="button" @click="image_rotate = !image_rotate"  class="absolute text-white font-bold px-8 z-50 bg-yellow-500 py-2 right-12">
              تدوير الصفحة
            </button>


          <div class="max-w-3xl mx-auto relative">
            <div
              class="absolute top-6 z-50 flex justify-between items-center w-full"
            >
              <button
                @click="show_current_image_for_bigger_screen_model = false"
              >
                <svg
                  class="w-8 h-8 stroke-current text-red-500 hover:text-red-400"
                  fill="none"
                  stroke="currentColor"
                  viewBox="0 0 24 24"
                  xmlns="http://www.w3.org/2000/svg"
                >
                  <path
                    stroke-linecap="round"
                    stroke-linejoin="round"
                    stroke-width="2"
                    d="M10 14l2-2m0 0l2-2m-2 2l-2-2m2 2l2 2m7-2a9 9 0 11-18 0 9 9 0 0118 0z"
                  ></path>
                </svg>
              </button>

              <button
                v-if="roles.includes('k')"
                @click="print_image()"
                v-print="'#print_one_dec'"
                class="bg-blue-500 hover:bg-blue-400 px-4 py-2 rounded-lg text-white"
              >
                طباعة المستند الحالي
              </button>

              <button
                v-if="roles.includes('k')"
                @click="print_image()"
                v-print="'#printMe'"
                class="bg-blue-500 hover:bg-blue-400 px-4 py-2 rounded-lg text-white"
              >
                طباعة كافة المستندات
              </button>

              <div
                v-if="image_of_doc"
                class="flex items-center border border-blue-400 rounded-md"
              >
                <input
                  type="text"
                  v-model="doc_number_to_search"
                  id="doc_number"
                  class="ml-2 block w-16 rounded-md h-10 text-sm border border---200 hover:shadow-sm focus:outline-none focus:border-blue-300 p-2"
                />

                <button
                  @click="search_the_doc()"
                  class="py-2 px-4 bg-white rounded-lg tracking-wide border border-blue-600 cursor-pointer hover:text-white hover:bg-blue-600 focus:outline-none duration-300 text-sm leading-normal"
                >
                  بحث
                </button>
              </div>
            </div>

            <div class="h-screen-93 mt-4">
              <img
                :src="image_of_doc"
                alt="image"
                :class="image_rotate ? 'rotate-0' : 'rotate-180'"
                class="h-full w-full object-contain transform"
              />
            </div>

            <div
              class="absolute bottom-3 z-50 bg-gray-100 flex justify-between items-center w-full mx-auto mt-4"
            >
              <div class="">
                <button
                  @click="farst_documents()"
                  class="bg-gray-500 hover:bg-gray-400 px-2 py-2 rounded-lg text-xs text-white"
                >
                  &#x276E; &#x276E;
                </button>
              </div>

              <div class="w-12 h-8">
                <button
                  title="prev"
                  v-if="doc_number > 1"
                  @click="GetAllDocN('prev')"
                  class="focus:outline-none w-12 h-8 bg-gray-300 rounded flex justify-center items-center"
                >
                  <svg
                    class="w-4 h-4"
                    fill="none"
                    stroke="currentColor"
                    viewBox="0 0 24 24"
                    xmlns="http://www.w3.org/2000/svg"
                  >
                    <path
                      stroke-linecap="round"
                      stroke-linejoin="round"
                      stroke-width="2"
                      d="M9 5l7 7-7 7"
                    ></path>
                  </svg>
                </button>
              </div>

              <div class="text-black">
                {{ doc_number }} / {{ total_of_doc }}
              </div>

              <div class="w-12 h-8">
                <button
                  v-if="doc_number < total_of_doc"
                  title="next"
                  @click="GetAllDocN('next')"
                  class="focus:outline-none w-12 h-8 bg-gray-300 rounded flex justify-center items-center"
                >
                  <svg
                    class="w-4 h-4"
                    fill="none"
                    stroke="currentColor"
                    viewBox="0 0 24 24"
                    xmlns="http://www.w3.org/2000/svg"
                  >
                    <path
                      stroke-linecap="round"
                      stroke-linejoin="round"
                      stroke-width="2"
                      d="M15 19l-7-7 7-7"
                    ></path>
                  </svg>
                </button>
              </div>

              <div class="">
                <button
                  @click="last_documents()"
                  class="bg-gray-500 hover:bg-gray-400 px-2 py-2 rounded-lg text-xs text-white"
                >
                  &#x276F; &#x276F;
                </button>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>

    <div
      v-if="show_images_model"
      class="w-screen h-full absolute inset-0 z-50 overflow-hidden"
    >
      <div class="relative">
        <div
          v-if="to_test_print_images_model"
          id="printMe"
          class="bg-black bg-opacity-50 h-screen-85"
        >
          <div
            v-for="image in show_images_images_model"
            :key="image.id"
            class="h-screen-85"
          >
            <img
              :src="image.path"
              alt=""
              class="h-full w-full object-contain"
            />
          </div>
        </div>

        <div
          class="h-screen flex flex-col justify-center items-center bg-black bg-opacity-90 absolute top-0 inset-0 z-50 w-full"
        >
          <div class="max-w-3xl mx-auto">
            <div class="flex justify-between items-center w-full">
              <button @click="show_images_model = false">
                <svg
                  class="w-8 h-8 stroke-current text-red-500 hover:text-red-400"
                  fill="none"
                  stroke="currentColor"
                  viewBox="0 0 24 24"
                  xmlns="http://www.w3.org/2000/svg"
                >
                  <path
                    stroke-linecap="round"
                    stroke-linejoin="round"
                    stroke-width="2"
                    d="M10 14l2-2m0 0l2-2m-2 2l-2-2m2 2l2 2m7-2a9 9 0 11-18 0 9 9 0 0118 0z"
                  ></path>
                </svg>
              </button>

              <button
                v-if="roles.includes('k')"
                @click="print_image()"
                v-print="'#printMe'"
                class="bg-blue-500 hover:bg-blue-400 px-4 py-2 rounded-lg"
              >
                طباعة كافة المستندات
              </button>
            </div>

            <div class="h-screen-85 mt-4">
              <img
                :src="testimage_images_model"
                alt="image"
                class="h-full w-full object-contain"
              />
            </div>

            <div
              v-if="testimage_images_model"
              class="flex justify-between items-center max-w-xs mx-auto w-full mt-4 text-white"
            >
              <button
                @click="previousImage_images_model()"
                class="focus:outline-none w-12 h-8 bg-gray-300 rounded flex justify-center items-center"
              >
                <svg
                  class="w-4 h-4"
                  fill="none"
                  stroke="currentColor"
                  viewBox="0 0 24 24"
                  xmlns="http://www.w3.org/2000/svg"
                >
                  <path
                    stroke-linecap="round"
                    stroke-linejoin="round"
                    stroke-width="2"
                    d="M9 5l7 7-7 7"
                  ></path>
                </svg>
              </button>

              <div class="text-white">
                {{ indextotest_images_model + 1 }} /
                {{ show_images_images_model.length }}
              </div>

              <button
                title="next"
                @click="nextImage_images_model()"
                class="focus:outline-none w-12 h-8 bg-gray-300 rounded flex justify-center items-center"
              >
                <svg
                  class="w-4 h-4"
                  fill="none"
                  stroke="currentColor"
                  viewBox="0 0 24 24"
                  xmlns="http://www.w3.org/2000/svg"
                >
                  <path
                    stroke-linecap="round"
                    stroke-linejoin="round"
                    stroke-width="2"
                    d="M15 19l-7-7 7-7"
                  ></path>
                </svg>
              </button>
            </div>
          </div>
        </div>
      </div>

      <!-- w-full h-full rounded object-contain -->
    </div>

    <div
      v-if="show_current_reply_image_to_for_bigger_screen_model"
      class="w-screen h-full absolute inset-0 z-50 overflow-hidden"
    >
      <div class="relative">
        <div id="print_reply_doc_n" class="bg-black bg-opacity-50 h-screen-100">
          <div class="h-screen-100">
            <img
              :src="reply_image_of_doc"
              alt=""
              class="h-full w-full object-contain"
            />
          </div>
        </div>

        <div
          class="h-screen flex flex-col justify-center items-center bg-black bg-opacity-90 absolute top-0 inset-0 z-50 w-full"
        >
          <div class="max-w-3xl mx-auto relative">
            <div
              class="absolute top-6 z-50 flex justify-between items-center w-full"
            >
              <button
                @click="
                  show_current_reply_image_to_for_bigger_screen_model = false
                "
              >
                <svg
                  class="w-8 h-8 stroke-current text-red-500 hover:text-red-400"
                  fill="none"
                  stroke="currentColor"
                  viewBox="0 0 24 24"
                  xmlns="http://www.w3.org/2000/svg"
                >
                  <path
                    stroke-linecap="round"
                    stroke-linejoin="round"
                    stroke-width="2"
                    d="M10 14l2-2m0 0l2-2m-2 2l-2-2m2 2l2 2m7-2a9 9 0 11-18 0 9 9 0 0118 0z"
                  ></path>
                </svg>
              </button>

              <button
                v-if="roles.includes('k')"
                v-print="'#print_reply_doc_n'"
                class="bg-blue-500 hover:bg-blue-400 px-4 py-2 rounded-lg text-white"
              >
                طباعة المستند الحالي
              </button>
            </div>

            <div class="h-screen-93 mt-4">
              <img
                :src="reply_image_of_doc"
                alt="image"
                class="h-full w-full object-contain"
              />
            </div>

            <div
              class="absolute bottom-3 z-50 bg-gray-100 flex justify-between items-center w-full mx-auto mt-4"
            >
              <div class="w-12 h-8">
                <button
                  title="prev"
                  v-if="reply_doc_number > 1"
                  @click="Next_prevent_GetResources_ById('prev')"
                  class="focus:outline-none w-12 h-8 bg-gray-300 rounded flex justify-center items-center"
                >
                  <svg
                    class="w-4 h-4"
                    fill="none"
                    stroke="currentColor"
                    viewBox="0 0 24 24"
                    xmlns="http://www.w3.org/2000/svg"
                  >
                    <path
                      stroke-linecap="round"
                      stroke-linejoin="round"
                      stroke-width="2"
                      d="M9 5l7 7-7 7"
                    ></path>
                  </svg>
                </button>
              </div>

              <div class="text-black">
                {{ reply_doc_number }} / {{ reply_total_of_doc }}
              </div>

              <div class="w-12 h-8">
                <button
                  v-if="reply_doc_number < reply_total_of_doc"
                  title="next"
                  @click="Next_prevent_GetResources_ById('next')"
                  class="focus:outline-none w-12 h-8 bg-gray-300 rounded flex justify-center items-center"
                >
                  <svg
                    class="w-4 h-4"
                    fill="none"
                    stroke="currentColor"
                    viewBox="0 0 24 24"
                    xmlns="http://www.w3.org/2000/svg"
                  >
                    <path
                      stroke-linecap="round"
                      stroke-linejoin="round"
                      stroke-width="2"
                      d="M15 19l-7-7 7-7"
                    ></path>
                  </svg>
                </button>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script
  type="text/javascript"
  src="http://cdn.asprise.com/scannerjs/scanner.js"
></script>
<script>
import asideComponent from "@/components/asideComponent.vue";
import navComponent from "@/components/navComponent.vue";
import svgLoadingComponent from "@/components/svgLoadingComponent.vue";

//import { HubConnectionBuilder } from "@microsoft/signalr";

export default {
  created() {},

  destroyed() {
    console.log("destroyed_inbox_form");
    if (this.conn != null) {
      if (this.conn.readystate != 3) {
        console.log("readystate destory_inbox_form=" + this.conn.readyState);
        this.conn.close();
        console.log("close_inbox_form");
        this.conn = null;
      }
    }
  },

  mounted() {
    //21/1/2023*********************websocket
    /***********  this.conn = new WebSocket("ws://localhost:58316/ws");
    //  this.conn = new WebSocket("ws://mail:82/ws");
    console.log("inbox_form websocket connect ok");

 

this.conn.onerror =(error) =>{
console.log("inbox_form.vue  WebSocket Error " + error);
};

this.conn.onclose =(event) =>{
console.log("inbox_form.vue readystate"+this.conn.readyState);
console.log(" inbox_form.vue WebSocket close");
console.log("code inbox_form="+event.code);

};

    this.conn.onmessage = (event) => {
       console.log("inbox_form onmessage");
      let scannedImage = event.data;
      let mgs = JSON.parse(scannedImage);
      this.imagesscantest = mgs;
      var ind = this.imagesscantest.index;
      console.log("inbox_form index="+ind);
      if (ind == 1) {
        this.keyid = this.imagesscantest.keyid;
        console.log("inbox keyid="+this.keyid);
      } else {
         console.log("inbox_form.vue else");
        //this.imagesToSend=[]
        for (var i = 0; i < mgs["image"].length; i++) {
          this.indexOfimagesToShow++;
          this.imagesToSend.push({
            baseAs64: mgs["image"][i],
            index: this.indexOfimagesToShow,
          });
        }
      }
    };*/
    //****************21/1/2023
    this.my_user_id = localStorage.getItem("AY_LW");
    this.my_department_id = localStorage.getItem("chrome");
    this.roles = localStorage.getItem("Az07");

    if (this.$route.params.mail) {
      if (this.$route.params.type == "1") {
        this.to_test_passing_mail_type = 1;
      }
      if (this.$route.params.type == "2") {
        this.to_test_passing_mail_type = 2;
      }
      if (this.$route.params.type == "3") {
        this.to_test_passing_mail_type = 3;
      }

      this.mailId = this.$route.params.mail;

      this.getMailById();
      this.GetAllDocN("next");
    } else {
    }
  },

  components: {
    asideComponent,
    navComponent,
    svgLoadingComponent,
  },

  data() {
    return {

      image_rotate : true,


      doc_number_to_search: "",

      //********21/1/2023
      keyid: "",
      conn: null,
      //**end 21/1/2023
      reply_id_to_delete: "",
      alert_delete_document: false,

      roles: [],
      from_reply_or_general: "",

      to_test_print_images_model: false,
      show_images_model: false,

      testimage_images_model: "",
      indextotest_images_model: 0,

      show_images_images_model: [],

      testimage: "",
      indextotest: 0,

      reply_to_add: "",
      to_test_passing_mail_type: "",

      my_user_id: "",
      my_department_id: "",

      mailType: this.$route.params.type,
      sends_id: this.$route.params.sends_id,

      mail_Number: "",
      mail_year: "",

      releaseDate: "",
      summary: "",
      classification: "",
      general_incoming_number: "",
      genaral_inbox_year: "",
      required_action: "",

      consignees: [],

      mailId: "",
      external_mailId: "",

      department_Id: "",

      imagesToSend: [],
      indexOfimagesToShow: 0,

      action_required_by_the_entity: "",
      mail_forwarding: "",

      send_to_sector: "",

      sectors: [],
      sectorselect: false,
      sectorIdSelected: "",

      sides: [],

      sideselect: false,
      sideIdSelected: "",

      send_to_side: "",

      entity_reference_number: "",
      procedure_type: "",
      entity_mail_date: "",
      mail_ward_type: "",
      ward_to: "",

      to_test_passing_mail_type: "",
      remove_button_consignees: true,
      add_button_consignees: true,

      side: 0,
      action: 0,

      imagesToShow: [],

      loading: false,
      screenFreeze: false,

      replies: [],

      doc_number: 0,
      total_of_doc: 0,

      image_of_doc: "",
      id_of_doc: "",
      image_to_print_n: [],

      image_to_print_n_model: false,
      show_current_image_for_bigger_screen_model: false,

      reply_doc_number: 0,
      reply_total_of_doc: 0,

      reply_image_of_doc: "",
      reply_id_of_doc: "",
      reply_image_to_print_n: [],

      reply_image_to_print_n_model: false,
      show_current_reply_image_to_for_bigger_screen_model: false,

      id_reply_image: "",

      external_sectoin: [],
    };
  },
  methods: {
    farst_documents() {
      this.image_rotate = true

      this.doc_number_to_search = 1;
      this.search_the_doc();
    },

    last_documents() {
      this.image_rotate = true

      this.doc_number_to_search = this.total_of_doc;
      this.search_the_doc();
    },

    search_the_doc() {
      // doc_number_to_search

      if (this.doc_number_to_search > this.total_of_doc) {
        alert("لقد ادخلة رقم خطا الرجاء إعادة المحاولة");
      } else {
        this.doc_number = this.doc_number_to_search;
        this.screenFreeze = true;
        this.loading = true;
        this.$http.documentService
          .GetAllDocN(this.mailId, this.doc_number)
          .then((res) => {
            this.total_of_doc = res.data.total;

            this.image_of_doc = res.data.data.path;
            this.id_of_doc = res.data.data.id;

            setTimeout(() => {
              this.screenFreeze = false;
              this.loading = false;
            }, 200);
          })
          .catch((err) => {
            this.screenFreeze = false;
            this.loading = false;
            console.log(err);
          });
      }
    },

    getMailById() {
      this.$http.mailService
        .GetInboxMailById(
          this.mailId,
          this.my_department_id,
          this.to_test_passing_mail_type
        )
        .then((res) => {
          this.mail_Number = res.data.mail.mail_Number;
          this.department_Id = res.data.mail.department_Id;
          this.mail_year = res.data.mail.mail_year;

          this.releaseDate = res.data.mail.date_Of_Mail;
          this.summary = res.data.mail.mail_Summary;
          this.classification = res.data.mail.classification_name;
          this.mailType = res.data.mail.mail_Type;
          this.general_incoming_number = res.data.mail.genaral_inbox_Number;
          this.genaral_inbox_year = res.data.mail.genaral_inbox_year;
          this.required_action = res.data.mail.action_Required;

          this.replies = res.data.list;

          setTimeout(() => {
            document.getElementById("scroll").scrollTop =
              document.getElementById("scroll").scrollHeight;
          }, 100);

          this.consignees = res.data.actionSenders;

          this.imagesToShow = res.data.mail_Resourcescs;

          if (this.imagesToShow.length > 0) {
            this.testimage = this.imagesToShow[0].path;
          }

          if (this.to_test_passing_mail_type == "2") {
            this.external_sectoin = res.data.external_sectoin;

            this.external_mailId = res.data.external.id;

            this.action_required_by_the_entity =
              res.data.external.action_required_by_the_entity;

            this.mail_forwarding = res.data.external.action;
          }
          if (this.to_test_passing_mail_type == "3") {
            this.external_sectoin = res.data.external_sectoin;

            this.external_mailId = res.data.inbox.id;

            this.mail_forwarding = res.data.inbox.action;

            this.ward_to = res.data.inbox.to;

            this.mail_ward_type = res.data.inbox.type;

            this.entity_mail_date = res.data.inbox.send_time;

            this.entity_reference_number =
              res.data.inbox.entity_reference_number;

            this.procedure_type = res.data.inbox.procedure_type;
          }

        //  this.to_get_all_doc_of_mail();
          //   this.GetDocmentForMail();
          //   this.GetDocmentForMailToShow();

          //   this.GetProcessingResponses()
        })
        .catch((err) => {
          console.log(err);
        });
    },

    deletereply() {
      this.alert_delete_document = false;

      this.$http.mailService
        .delete_reply(
          Number(this.reply_id_to_delete),
          Number(localStorage.getItem("AY_LW"))
        )
        .then((res) => {
          this.getMailById();
          this.GetAllDocN("next");

          // this.to_pass_data_to_get_mail_by_id(
          //                 this.mail.mail_id,
          //                 this.my_department_id,
          //                 this.mail.type_of_mail,
          //                 this.mail.sends_id,
          //                 this.mail.mangment_sender
          //               )
        })
        .catch((err) => {});
    },

    Next_prevent_GetResources_ById(x) {
      if (x == "next") {
        this.reply_doc_number++;
      } else {
        this.reply_doc_number--;
      }

      this.screenFreeze = true;
      this.loading = true;
      this.$http.documentService
        .GetResources_ById(this.id_reply_image, this.reply_doc_number)
        .then((res) => {
          this.show_current_reply_image_to_for_bigger_screen_model = true;
          this.reply_total_of_doc = res.data.total;

          this.reply_image_of_doc = res.data.date[0].path;
          this.reply_id_of_doc = res.data.date[0].id;

          setTimeout(() => {
            this.screenFreeze = false;
            this.loading = false;
          }, 200);
        })
        .catch((err) => {
          this.screenFreeze = false;
          this.loading = false;
          console.log(err);
        });
    },

    GetResources_ById(id) {
      this.id_reply_image = id;

      this.reply_doc_number = 1;
      this.reply_image_of_doc = [];
      this.reply_id_of_doc = "";
      this.reply_total_of_doc = "";

      this.screenFreeze = true;
      this.loading = true;
      this.$http.documentService
        .GetResources_ById(id, this.reply_doc_number)
        .then((res) => {
          this.show_current_reply_image_to_for_bigger_screen_model = true;
          this.reply_total_of_doc = res.data.total;

          this.reply_image_of_doc = res.data.date[0].path;
          this.reply_id_of_doc = res.data.date[0].id;

          setTimeout(() => {
            this.screenFreeze = false;
            this.loading = false;
          }, 200);
        })
        .catch((err) => {
          this.screenFreeze = false;
          this.loading = false;
          console.log(err);
        });
    },

    to_get_all_doc_of_mail() {
      this.screenFreeze = true;
      this.loading = true;
      this.$http.mailService
        .GetAllDocuments(this.mailId, Number(localStorage.getItem("AY_LW")))
        .then((res) => {
          this.image_to_print_n = res.data;
          setTimeout(() => {
            this.screenFreeze = false;
            this.loading = false;
          }, 300);
        })
        .catch((err) => {
          this.loading = false;
          setTimeout(() => {
            this.screenFreeze = false;
            console.log(err);
          }, 700);
        });
    },

    show_current_image_for_bigger_screen() {

      this.to_get_all_doc_of_mail();
      this.screenFreeze = true;
      this.loading = true;
      setTimeout(() => {
        this.show_current_image_for_bigger_screen_model = true;
        this.screenFreeze = false;
        this.loading = false;
      }, 300);
    },

    GetAllDocN(x) {

      this.image_rotate = true



      if (x == "next") {
        this.doc_number++;
      } else {
        this.doc_number--;
      }

      this.screenFreeze = true;
      this.loading = true;
      this.$http.documentService
        .GetAllDocN(this.mailId, this.doc_number)
        .then((res) => {
          this.total_of_doc = res.data.total;

          this.image_of_doc = res.data.data.path;
          this.id_of_doc = res.data.data.id;

          setTimeout(() => {
            this.screenFreeze = false;
            this.loading = false;
          }, 200);
        })
        .catch((err) => {
          this.screenFreeze = false;
          this.loading = false;
          console.log(err);
        });
    },

    //*******************
    reply1() {
      if (this.conn == null) {
        console.log("conn=" + this.conn);
        this.conn = new WebSocket("ws://localhost:58316/ws");
        //  this.conn = new WebSocket("ws://mail:82/ws");

        this.conn.onclose = (event) => {
          console.log("close code_inbox_form=" + event.code);
        };
        this.conn.onmessage = (event) => {
          console.log("inbox_form onmessage");
          let scannedImage = event.data;
          let mgs = JSON.parse(scannedImage);
          this.imagesscantest = mgs;
          var ind = this.imagesscantest.index;
          console.log("inbox_form index=" + ind);
          if (ind == 1) {
            this.keyid = this.imagesscantest.keyid;
            console.log("inbox keyid=" + this.keyid);
            console.log(
              "count websocket_inbox_form=" + this.imagesscantest.count1
            );
          } else {
            console.log("inbox_form.vue else");
            //this.imagesToSend=[]
            for (var i = 0; i < mgs["image"].length; i++) {
              this.indexOfimagesToShow++;
              this.imagesToSend.push({
                baseAs64: mgs["image"][i],
                index: this.indexOfimagesToShow,
              });
            }
          }
        };
      } else if (this.conn.readyState === 3 || this.conn.readyState === 2) {
        console.log("readystate=" + this.conn.readyState);
        this.conn = null;
        this.reply1();
      } else {
        var mailId_to_get_mail_by_id = this.mailId_to_get_mail_by_id;
        var mailId = this.mailId;
        var sends_id = this.sends_id;
        var department_Id = this.department_Id;
        var keyid = this.keyid;

        var timeout;
        window.addEventListener("blur", function (e) {
          window.clearTimeout(timeout);
        });

        timeout = window.setTimeout(function () {
          window.location = "http://mail/scanner_app/Setup1.msi";
        }, 1000);

        console.log("replay" + "  id= " + mailId_to_get_mail_by_id);
        document.location =
          "SScaner:flag=0" +
          "userId=" +
          localStorage.getItem("AY_LW") +
          "mId=" +
          mailId +
          "send_ToId=" +
          sends_id +
          "to=" +
          department_Id +
          "keyid=" +
          keyid;

        console.log(
          "testreplay " +
            "  id= " +
            mailId +
            "userId=" +
            localStorage.getItem("AY_LW") +
            "send_ToId=" +
            sends_id +
            "to=" +
            department_Id +
            "keyid=" +
            keyid
        );
      }

      //***********21/1/2023
      /* var link = document.getElementById("a5");
      var mailId_to_get_mail_by_id = this.mailId_to_get_mail_by_id;
      var mailId = this.mailId;
      var sends_id = this.sends_id;
      var department_Id = this.department_Id;
      var keyid = this.keyid;

      var timeout;
      window.addEventListener("blur", function (e) {
        window.clearTimeout(timeout);
      });

      timeout = window.setTimeout(function () {
        window.location = "http://mail/scanner_app/Setup1.msi";
      }, 1000);

      console.log("replay" + "  id= " + mailId_to_get_mail_by_id);
      link.href =
        "SScaner:flag=0" +
        "userId=" +
        localStorage.getItem("AY_LW") +
        "mId=" +
        mailId +
        "send_ToId=" +
        sends_id +
        "to=" +
        department_Id +
        "keyid=" +
        keyid;

      console.log(
        "testreplay " +
          "  id= " +
          mailId +
          "userId=" +
          localStorage.getItem("AY_LW") +
          "send_ToId=" +
          sends_id +
          "to=" +
          department_Id +
          "keyid=" +
          keyid
      );*/
      //*************21/1/2023
    },
    //**************************************

    print_image() {
      this.image_to_print_n_model = true;

      // this.$http.mailService
      //   .PrintOrShowDocument(
      //     Number(this.mailId),
      //     Number(localStorage.getItem("AY_LW")),
      //     Number(this.from_reply_or_general)
      //   )
      //   .then((res) => {
      //     setTimeout(() => {
      //       console.log(res);
      //       this.loading = false;
      //       this.screenFreeze = false;
      //     }, 500);
      //   })
      //   .catch((err) => {
      //     setTimeout(() => {
      //       this.loading = false;
      //       this.screenFreeze = false;
      //     }, 500);
      //     console.log(err);
      //   });
    },

    show_reply_images(index, plase) {
      this.from_reply_or_general = plase;

      this.screenFreeze = true;
      this.loading = true;

      this.$http.mailService
        .PrintOrShowDocument(
          Number(this.mailId),
          Number(localStorage.getItem("AY_LW")),
          2
        )
        .then((res) => {
          setTimeout(() => {
            console.log(res);

            this.show_images_images_model = [];
            this.indextotest = 0;

            this.show_images_images_model = this.replies[index].resources;

            this.testimage_images_model = this.show_images_images_model[0].path;

            this.show_images_model = true;
            this.screenFreeze = false;
            this.loading = false;
          }, 500);
        })
        .catch((err) => {
          setTimeout(() => {
            this.loading = false;
            this.screenFreeze = false;
          }, 500);
          console.log(err);
        });
    },

    previousImage_images_model() {
      if (this.indextotest_images_model > 0) {
        this.indextotest_images_model--;
        this.testimage_images_model =
          this.show_images_images_model[this.indextotest_images_model].path;
      }
    },

    nextImage_images_model() {
      if (
        this.indextotest_images_model <
        this.show_images_images_model.length - 1
      ) {
        this.indextotest_images_model++;
        this.testimage_images_model =
          this.show_images_images_model[this.indextotest_images_model].path;
      }
    },

    GetAllDocuments(id, plase) {
      this.from_reply_or_general = plase;
      this.screenFreeze = true;
      this.loading = true;
      this.$http.mailService
        .GetAllDocuments(id, Number(localStorage.getItem("AY_LW")))
        .then((res) => {
          this.show_images_images_model = res.data;

          this.testimage_images_model = this.show_images_images_model[0].path;

          setTimeout(() => {
            this.show_images_model = true;
            this.screenFreeze = false;
            this.loading = false;
          }, 300);
        })
        .catch((err) => {
          this.loading = false;
          this.there_are_no_documents = true;
          setTimeout(() => {
            this.screenFreeze = false;
            this.there_are_no_documents = false;
            console.log(err);
          }, 700);
        });
    },

    previousImage() {
      if (this.indextotest > 0) {
        this.indextotest--;
        this.testimage = this.imagesToShow[this.indextotest].path;
      }
    },

    nextImage() {
      if (this.indextotest < this.imagesToShow.length - 1) {
        this.indextotest++;
        this.testimage = this.imagesToShow[this.indextotest].path;
      }
    },

    scanToReply() {
      scanner.scan(this.displayReplyImagesOnPage, {
        output_settings: [
          {
            type: "return-base64",
            format: "jpg",
          },
        ],
      });
    },

    displayReplyImagesOnPage(successful, mesg, response) {
      if (!successful) {
        // On error
        console.error("Failed: " + mesg);
        return;
      }

      if (
        successful &&
        mesg != null &&
        mesg.toLowerCase().indexOf("user cancel") >= 0
      ) {
        // User cancelled.
        console.info("User cancelled");
        return;
      }

      var scannedImages = scanner.getScannedImages(response, true, false); // returns an array of ScannedImage
      for (
        var i = 0;
        scannedImages instanceof Array && i < scannedImages.length;
        i++
      ) {
        var scannedImage = scannedImages[i];
        // this.processScannedImage(scannedImage);
        this.indexOfimagesToShow++;
        this.imagesToSend.push({
          baseAs64: scannedImage.src,
          index: this.indexOfimagesToShow,
        });

        // if (this.imagesToSend.length > 0) {
        // this.testimageToSend = this.imagesToSend[0].baseAs64;
        // this.ButtonUploadImagesMail = true;
        // }
      }

      // this.UploadImagesMail()

      // if (this.mailType == 1) {
      //   this.to_test_passing_mail_type = 1;
      // }
      // if (this.mailType == 2) {
      //   this.to_test_passing_mail_type = 2;
      // }
      // if (this.mailType == 3) {
      //   this.to_test_passing_mail_type = 3;
      // }

      // setTimeout(() => {
      //   this.GetSentMailById();
      // }, 1000);
    },

    AddReply_old() {
      this.screenFreeze = true;
      this.loading = true;

      var ReplyViewModel = {
        userId: Number(localStorage.getItem("AY_LW")),
        mailId: Number(this.mailId),
        send_ToId: Number(this.sends_id),
        from: Number(2),
        reply: {
          mail_detail: this.reply_to_add,
          To: Number(this.department_Id),
        },
        file: {
          list: this.imagesToSend,
        },
      };
      this.$http.mailService
        .NewAddReply(ReplyViewModel)
        .then((res) => {
          setTimeout(() => {
            console.log(res);
            // this.documentSection = true;
            // this.proceduresSection = true;

            this.loading = false;
            this.screenFreeze = false;

            this.reply_to_add = "";
            this.imagesToSend = [];
            this.getMailById();
          }, 500);
        })
        .catch((err) => {
          setTimeout(() => {
            this.loading = false;
            this.screenFreeze = false;
          }, 500);
        });
    },

    //***************8/3/2023
    AddReply() {
      this.screenFreeze = true;
      this.loading = true;
      console.log("lenght1111=" + this.imagesToSend.length);
      var ReplyViewModel = {
        userId: Number(localStorage.getItem("AY_LW")),
        mailId: Number(this.mailId),
        send_ToId: Number(this.sends_id),
        from: Number(2),
        reply: {
          mail_detail: this.reply_to_add,
          To: Number(this.department_Id),
        },
        file: {
          list: this.imagesToSend.slice(0, 50),
        },
      };
      //

      //

      this.$http.mailService
        .NewAddReply(ReplyViewModel)
        .then((res) => {
          setTimeout(() => {
            console.log("res=" + res.data.replyid);
            // this.imagesToSend = [];
            // this.documentSection = true;
            // this.proceduresSection = true;

            this.loading = false;
            this.screenFreeze = false;

            this.reply_to_add = "";
            //28/2/2023 this.getMailById();
            var cou = Math.ceil(this.imagesToSend.length / 50);
            if (cou > 1) {
              console.log("cou=" + cou);
              var id_of_reply_from_beackend = res.data.replyid; //101
              this.update_reply_to_complet_sent_img(
                1,
                id_of_reply_from_beackend,
                cou,
                50
              );
            }
            //****28/2/2023
            else {
              this.getMailById();
            }
            //********end 28/2/2023
          }, 500);
        })
        .catch((err) => {
          setTimeout(() => {
            this.loading = false;
            this.screenFreeze = false;
          }, 500);
          console.log(err);
        });
    },

    update_reply_to_complet_sent_img(ii, id, count1, a2) {
      console.log("update_reply ii=" + ii);

      if (ii < count1) {
        var a1 = a2;
        a2 = a1 + 50;
        this.screenFreeze = true;
        this.loading = true;

        var ReplyViewModel = {
          userId: Number(localStorage.getItem("AY_LW")),
          mailId: Number(this.mailId),
          send_ToId: Number(this.sends_id),
          from: Number(2),
          reply: {
            mail_detail: this.reply_to_add,
            To: Number(this.department_Id),
          },
          file: {
            list: this.imagesToSend.slice(a1, a2),
          },
          id_of_reply: id,
        };
        this.$http.mailService
          .update_replay(ReplyViewModel)
          .then((res) => {
            setTimeout(() => {
              console.log(res);
              //28/3/2023  this.imagesToSend = [];
              // this.documentSection = true;
              // this.proceduresSection = true;

              this.loading = false;
              this.screenFreeze = false;

              this.reply_to_add = "";
              // this.getMailById();

              ii++;
              if (ii < count1) {
                // var id_of_reply_from_beackend = 1
                //   this.update_reply_to_complet_sent_img(ii,id_of_reply_from_beackend);
                this.update_reply_to_complet_sent_img(ii, id, count1, a2);
              }
              //*********1/3/2023
              else this.getMailById();
              //*******end 1/3/2023
            }, 500);
          })
          .catch((err) => {
            setTimeout(() => {
              this.loading = false;
              this.screenFreeze = false;
            }, 500);
            console.log(err);
          });
      }
    },
    //************************************8/3/2023
  },
};
</script>
