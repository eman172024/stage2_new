<template>
  <div class="">
    <div class="h-screen bg-gray-100 overflow-hidden flex">
      <asideComponent></asideComponent>
      <div class="flex-1 bg-gray-200 w-0 overflow-y-auto">
        <div class="max-w-screen-2xl mx-auto flex flex-col md:px-8">
          <navComponent></navComponent>

          <div v-if="roles.includes('b')" class="-mt-14 py-0.5 z-20 w-44">
            <button
              @click="clear_page()"
              class="border border-black duration-300 bg-white px-4 py-2 rounded-md text-gray-900 font-bold hover:bg-green-600 hover:text-white focus:outline-none"
            >
              إضافة بريد جديد +
            </button>
          </div>
          <main class="flex-1 relative focus:outline-none py-6">
            <div class="grid grid-cols-7 gap-6">
              <section class="col-span-5 flex justify-between items-stretch">
                <div class="w-2/12 ml-3">
                  <h3 class="text-xl font-semibold text-gray-900">
                    معلومات البريد
                  </h3>
                </div>

                <fieldset class="w-6/12 mr-3 mt-2">
                  <div class="flex items-center">
                    <legend class="text-sm font-semibold text-gray-800 ml-4">
                      نوع البريد
                    </legend>

                    <div class="flex justify-between items-center">
                      <div v-if="roles.includes('c')" class="flex items-center">
                        <input
                          v-model="mailType"
                          id="internal"
                          type="radio"
                          name="type"
                          class="h-4 w-4"
                          value="1"
                        />
                        <label for="internal" class="mr-2 block text-gray-800">
                          داخلي
                        </label>
                      </div>

                      <div
                        v-if="roles.includes('e')"
                        class="flex items-center mx-4"
                      >
                        <input
                          v-model="mailType"
                          id="internal_export"
                          type="radio"
                          name="type"
                          class="h-4 w-4"
                          value="2"
                        />
                        <label
                          for="internal_export"
                          class="mr-2 block text-gray-800"
                        >
                          صادر خارجي
                        </label>
                      </div>

                      <div v-if="roles.includes('d')" class="flex items-center">
                        <input
                          v-model="mailType"
                          id="external_incoming"
                          type="radio"
                          name="type"
                          class="h-4 w-4"
                          value="3"
                        />
                        <label
                          for="external_incoming"
                          class="mr-2 block text-gray-800"
                        >
                          وارد خارجي
                        </label>
                      </div>
                    </div>
                  </div>
                </fieldset>

                <div
                  v-if="my_department_id == 21 || my_department_id == 22"
                  class="grid grid-cols-7 gap-3 border-black border-2 rounded-xl w-4/12 mb-2 pr-3 py-2"
                >
                  <section class="col-span-5 flex justify-between items-center">
                    <div
                      v-if="mailType == ''"
                      class="bg-gray-200 bg-opacity-80 rounded-lg absolute z-50 w-full h-full"
                    ></div>
                    <fieldset class="">
                      <div class="flex items-center">
                        <div
                          v-if="my_department_id == 21"
                          class="w-full flex items-center"
                        >
                          <div class="flex items-center w-32">
                            <input
                              v-model="office_type"
                              id="chief"
                              type="radio"
                              name="office_type"
                              class="h-4 w-4"
                              value="1"
                            />
                            <label for="chief" class="mr-3 block text-gray-800">
                              رئيس الهيئة
                            </label>
                          </div>

                          <div class="flex items-center w-32">
                            <input
                              v-model="office_type"
                              id="proxy"
                              type="radio"
                              name="office_type"
                              class="h-4 w-4"
                              value="2"
                            />
                            <label for="proxy" class="mr-3 block text-gray-800">
                              مدير المكتب
                            </label>
                          </div>
                        </div>

                        <div
                          v-if="my_department_id == 22"
                          class="w-full flex items-center"
                        >
                          <div class="flex items-center w-32">
                            <input
                              v-model="office_type"
                              id="chief"
                              type="radio"
                              name="office_type"
                              class="h-4 w-4"
                              value="3"
                            />
                            <label for="chief" class="mr-3 block text-gray-800">
                              وكيل الهيئة
                            </label>
                          </div>

                          <div class="flex items-center w-32">
                            <input
                              v-model="office_type"
                              id="proxy"
                              type="radio"
                              name="office_type"
                              class="h-4 w-4"
                              value="4"
                            />
                            <label for="proxy" class="mr-3 block text-gray-800">
                              مدير المكتب
                            </label>
                          </div>
                        </div>
                      </div>
                    </fieldset>
                  </section>
                </div>
              </section>

              <section class="col-span-2">
                <div
                  class="float-left text-sm font-semibold text-gray-800 flex items-center"
                >
                  رقم الرسالة

                  <span
                    class="mr-4 underline font-bold text-2xl flex items-center"
                  >
                    <input
                      type="number"
                      min="1"
                      max="5000"
                      @keypress.enter="mail_search()"
                      class="w-24 px-1 rounded-md focus:outline-none"
                      v-model="mail_Number"
                    />
                    <div
                      class="w-16 px-1 rounded-md font-normal focus:outline-none mx-4 bg-white"
                    >
                      {{ my_department_id }}
                    </div>
                    <input
                      type="number"
                      @keypress.enter="mail_search()"
                      class="w-20 px-1 rounded-md focus:outline-none"
                      v-model="mail_year"
                    />
                  </span>
                </div>
              </section>
            </div>

            <div class="mt-6 space-y-6 relative">
              <div
                v-if="mailType == ''"
                class="bg-gray-200 bg-opacity-80 rounded-lg absolute z-50 inset-0"
              ></div>

              <div class="grid grid-cols-7 gap-6">
                <section class="col-span-5 flex justify-between items-stretch">
                  <section
                    class="w-6/12 ml-3 grid grid-cols-1 gap-y-6 gap-x-4 sm:grid-cols-6 bg-gray-100 rounded-md p-6"
                  >
                    <div class="sm:col-span-6">
                      <label
                        for="summary"
                        class="block text-sm font-semibold text-gray-800"
                      >
                        الملخص
                      </label>
                      <!-- v-if="mail_flag <= 2 || roles.includes('7')" -->
                      <textarea
                      tabindex="1"
                        v-model="summary"
                        id="summary"
                        rows="3"
                        class="block mt-2 w-full text-sm rounded-md border border-green-400 hover:shadow-sm focus:outline-none focus:border-green-500 p-2"
                      >
                      </textarea>

                      <!-- <div
                        v-else
                        class="
                          block
                          mt-2
                          w-full
                          rounded-md
                          h-24
                          text-sm
                          border border-green-400
                          p-2
                        "
                      >
                        {{ summary }}
                      </div> -->
                    </div>

                    <div class="sm:col-span-3">
                      <label
                        for="classification"
                        class="block text-sm font-semibold text-gray-800"
                      >
                        التصنيف
                      </label>
                      <!-- v-if="mail_flag <= 2 || roles.includes('7')" -->
                      <select
                      tabindex="2"
                        v-model="classification"
                        id="classification"
                        class="block mt-2 w-full h-10 text-sm rounded-md border border-green-400 hover:shadow-sm focus:outline-none focus:border-green-400 p-2"
                      >
                        <option disabled selected value="0">
                          إختر التصنيف
                        </option>
                        <option
                          v-for="classification in classifications"
                          :key="classification.id"
                          :value="classification.id"
                        >
                          {{ classification.name }}
                        </option>
                      </select>
                      <!-- 
                      <div
                        v-else
                        class="
                          block
                          mt-2
                          w-full
                          rounded-md
                          h-10
                          text-sm
                          border border-green-400
                          p-2
                          overflow-hidden
                        "
                      >
                        <div class="h-8">
                          {{ new_class }}
                        </div>

                         {{ classification }} 
                      </div> -->
                    </div>

                    <div class="sm:col-span-3">
                      <label
                        for="date"
                        class="block text-sm font-semibold text-gray-800"
                      >
                        التاريخ
                      </label>
                      <!-- v-if="mail_flag <= 2 || roles.includes('7')" -->
                      <input
                        v-model="releaseDate"
                        min="2000-01-01"
                        max="2040-12-30"
                        type="date"
                        id="date"
                        class="block mt-2 w-full rounded-md h-10 text-sm border border-green-400 hover:shadow-sm focus:outline-none focus:border-green-400 p-2"
                      />

                      <!-- <div
                        v-else
                        class="
                          block
                          mt-2
                          w-full
                          rounded-md
                          h-10
                          text-sm
                          border border-green-400
                          p-2
                        "
                      >
                        {{ releaseDate }}
                      </div> -->
                    </div>

                    <div class="sm:col-span-2">
                      <label
                        for="general_incoming_number"
                        class="block text-sm font-semibold text-gray-800"
                      >
                        رقم الوارد العام
                      </label>
                      <!-- v-if="mail_flag <= 2 || roles.includes('7')" -->
                      <input
                      tabindex="3"
                        v-model="general_incoming_number"
                        type="text"
                        min="1"
                        max="50000"
                        id="general_incoming_number"
                        :class="
                          is_exisite_genaral_inbox_number
                            ? 'border-green-400'
                            : 'border-red-500'
                        "
                        class="block mt-2 h-10 text-sm w-full rounded-md border hover:shadow-sm focus:outline-none focus:border-green-400 px-2"
                        required
                      />

                      <!-- <div
                        v-else
                        class="
                          block
                          mt-2
                          w-full
                          rounded-md
                          h-10
                          text-sm
                          border border-green-400
                          p-2
                        "
                      >
                        {{ general_incoming_number }}
                      </div> -->
                    </div>

                    <div class="sm:col-span-2">
                      <label
                        for="year"
                        class="block text-sm font-semibold text-gray-800"
                      >
                        السنة
                      </label>
                      <!-- v-if="mail_flag <= 2 || roles.includes('7')" -->
                      <input
                        type="number"
                        placeholder="YYYY"
                        min="2011"
                        max="2100"
                        v-model="genaral_inbox_year"
                        id="year"
                        class="block mt-2 w-full rounded-md h-10 text-sm border border-green-400 hover:shadow-sm focus:outline-none focus:border-green-400 p-2"
                      />

                      <!-- <div
                        v-else
                        class="
                          block
                          mt-2
                          w-full
                          rounded-md
                          h-10
                          text-sm
                          border border-green-400
                          p-2
                        "
                      >
                        {{ genaral_inbox_year }}
                      </div> -->
                    </div>

                    <div class="sm:col-span-2">
                      <label
                        for="year"
                        class="block text-sm font-semibold text-gray-800"
                      >
                        رقم البريد القديم
                      </label>
                      <!-- v-if="mail_flag <= 2 || roles.includes('7')" -->
                      <input
                        type="text"
                        v-model="old_mail_number"
                        id="old_mail_number"
                        class="block mt-2 w-full rounded-md h-10 text-sm border border-green-400 hover:shadow-sm focus:outline-none focus:border-green-400 p-2"
                      />

                      <!-- <div
                        v-else
                        class="
                          block
                          mt-2
                          w-full
                          rounded-md
                          h-10
                          text-sm
                          border border-green-400
                          p-2
                        "
                      >
                        {{ old_mail_number }}
                      </div> -->
                    </div>
                  </section>

                  <section
                    class="w-6/12 mr-3 grid grid-cols-1 gap-y-6 gap-x-4 sm:grid-cols-6 bg-gray-100 rounded-md p-6"
                  >
                    <div class="sm:col-span-6">
                      <label
                        for="action_required"
                        class="block text-sm font-semibold text-gray-800"
                      >
                        الإجراء المطلوب
                      </label>
                      <!-- v-if="mail_flag <= 2 || roles.includes('7')" -->
                      <textarea 
                      tabindex="4"
                        v-model="required_action"
                        id="required_action"
                        rows="3"
                        class="block mt-2 w-full text-sm rounded-md border border-green-400 hover:shadow-sm focus:outline-none focus:border-green-500 p-2"
                      >
                      </textarea>

                      <!-- <div
                        v-else
                        class="
                          block
                          mt-2
                          w-full
                          rounded-md
                          h-24
                          text-sm
                          border border-green-400
                          p-2
                        "
                      >
                        {{ required_action }}
                      </div> -->
                    </div>

                    <div
                      class="sm:col-span-6 grid grid-cols-1 gap-y-6 gap-x-2 sm:grid-cols-7"
                    >
                      <div class="sm:col-span-4">
                        <label
                        tabindex="5"
                        
                          for="department"
                          class="block text-sm font-semibold text-gray-800"
                        >
                        
                          الإدارات
                        </label>

                        <div class="relative">
                          <button
                            @click="departmentselect = !departmentselect"
                            @keyup.space.prevent
                            id="department"
                            class="overflow-hidden text-right block mt-2 w-full rounded-md h-10 border text-xs bg-white border-green-400 hover:shadow-sm focus:outline-none focus:border-green-400 p-2"
                          >
                            <input
                              @click="
                                (departmentNameSelected = ''),
                                  (departmentIdSelected = '')
                              "
                              v-model="departmentNameSelected"
                              type="text"
                              class="h-6 w-full"
                            />

                            <!-- {{ departmentNameSelected }} -->
                          </button>

                          <div
                            v-if="departmentselect"
                            class="border text-sm bg-white border-green-400 p-2 absolute w-full z-20 shadow h-40 overflow-y-scroll rounded-b-md"
                          >
                            <button
                              v-if="allDepartmentButton"
                              class="block focus:outline-none w-full my-1 text-right"
                              @click="
                                selectAllDepartment(departments, 'الكل');
                                departmentselect = !departmentselect;
                              "
                            >
                              <!--    -->
                              الكل
                            </button>

                            <button
                            
                              class="block focus:outline-none w-full my-1 text-right"
                              @click="
                                selectdepartment(
                                  department.id,
                                  department.departmentName,
                                  index
                                );
                                departmentselect = !departmentselect;
                              "
                              v-for="(department, index) in filterByTerm1"
                              :key="department.id"
                            >
                              {{ department.departmentName }}
                            </button>
                          </div>
                        </div>
                      </div>

                      <div class="sm:col-span-2">
                        <label
                          for="measure"
                          class="block text-sm font-semibold text-gray-800"
                        >
                          الإجراء
                        </label>

                        <div class="relative">
                          <button
                            @click="measureselect = !measureselect"
                            id="measure"
                            class="text-right block mt-2 w-full rounded-md h-10 border text-xs bg-white border-green-400 hover:shadow-sm focus:outline-none focus:border-green-400 p-2"
                          >
                            {{ measureNameSelected }}
                          </button>

                          <div
                            v-if="measureselect"
                            class="border text-sm bg-white border-green-400 p-2 absolute w-full z-20 shadow h-40 overflow-y-scroll rounded-b-md"
                          >
                            <button
                              class="block focus:outline-none w-full my-1 text-right"
                              @click="
                                selectmeasure(
                                  measure.measuresId,
                                  measure.measuresName
                                );
                                measureselect = !measureselect;
                              "
                              v-for="measure in measures"
                              :key="measure.measuresId"
                            >
                              {{ measure.measuresName }}
                            </button>
                          </div>
                        </div>
                      </div>

                      <div
                        class="sm:col-span-1 flex justify-end"
                        v-if="measureNameSelected && departmentNameSelected"
                      >
                        <button
                          v-if="add_button_consignees"
                          @click="add_to_array_of_side_measure()"
                          class="mt-8 rounded-md text-green-400 duration-200 hover:text-green-500 text-base font-semibold w-8 h-8"
                        >
                          <svg
                            class="fill-current w-full h-full"
                            version="1.1"
                            id="Capa_1"
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
                                />
                              </g>
                            </g>
                            <g>
                              <g>
                                <path
                                  d="M355.148,234.386H275.83v-79.318c0-10.946-8.864-19.83-19.83-19.83s-19.83,8.884-19.83,19.83v79.318h-79.318
                                                            c-10.966,0-19.83,8.884-19.83,19.83s8.864,19.83,19.83,19.83h79.318v79.318c0,10.946,8.864,19.83,19.83,19.83
                                                            s19.83-8.884,19.83-19.83v-79.318h79.318c10.966,0,19.83-8.884,19.83-19.83S366.114,234.386,355.148,234.386z"
                                />
                              </g>
                            </g>
                          </svg>
                        </button>
                      </div>
                    </div>

                    <div class="sm:col-span-6">
                      <label
                        for="consignees"
                        class="block text-sm font-semibold text-gray-800"
                      >
                        المرسل اليها
                      </label>
                      <div
                        class="mt-2 w-full rounded-md border border-green-400 p-2 h-24 overflow-y-scroll flex flex-wrap items-center"
                      >
                        <div
                          v-for="consignee in consignees"
                          :key="consignee.side"
                          class="border-2 border-green-400 rounded-md text-sm flex items-center p-2 m-0.5"
                        >
                          {{ consignee.departmentName }} ,
                          {{ consignee.measureName }}
                          <button
                            v-if="
                              (mail_flag <= 2 && consignees.length > 1) ||
                              (mail_flag <= 2 &&
                                consignees.length > 0 &&
                                mailType == '3')
                            "
                            @click="
                              delete_side_measure(
                                consignee.departmentId,
                                consignee.departmentName
                              )
                            "
                            class="mr-1 rounded-full"
                          >
                            <svg
                              aria-hidden="true"
                              focusable="false"
                              data-prefix="far"
                              data-icon="times-circle"
                              class="w-5 h-5 stroke-current text-red-400 hover:text-red-500 duration-200"
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

                        <div
                          v-for="consignee in newactionSenders"
                          :key="consignee.side"
                          class="border border-gary-200 rounded-md text-sm flex items-center p-2 m-0.5"
                        >
                          {{ consignee.departmentName }} ,
                          {{ consignee.measureName }}
                          <!--  -->
                          <button
                            @click="
                              remove_to_array_of_side_measure(
                                consignee.departmentId,
                                consignee.departmentName
                              )
                            "
                            class="mr-1 rounded-full"
                          >
                            <svg
                              aria-hidden="true"
                              focusable="false"
                              data-prefix="far"
                              data-icon="times-circle"
                              class="w-5 h-5 stroke-current text-red-400 hover:text-red-500 duration-200"
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
                  </section>
                </section>

                <section
                  v-if="documentSection"
                  class="col-span-2 bg-gray-100 rounded-md p-6"
                >
                  <div class="flex justify-between items-center">
                    <h3 class="block text-sm font-semibold text-gray-800">
                      المستندات
                      <!-- <div class="">
                        doc_number : {{ doc_number }} //
                        total_of_doc : {{ total_of_doc }}
                      </div> -->
                    </h3>

                    <!-- <input
                        class="hidden"
                        type="button"
                        @click="scanToJpg(), (show_images = true)"
                      /> -->
                    <a
                      v-if="roles.includes('t') && mailType == '1'"
                      id="a1"
                      @click="func()"
                    >
                      <label
                        v-if="mailId"
                        class="w-48 flex justify-center items-center py-2 bg-white rounded-lg tracking-wide border border-green-600 cursor-pointer hover:text-white hover:bg-green-600 focus:outline-none duration-300"
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
                        <span class="text-sm leading-normal">تصوير</span>
                      </label>
                    </a>

                    <a
                      v-if="roles.includes('u') && mailType == '2'"
                      id="a1"
                      @click="func()"
                    >
                      <label
                        v-if="mailId"
                        class="w-48 flex justify-center items-center py-2 bg-white rounded-lg tracking-wide border border-green-600 cursor-pointer hover:text-white hover:bg-green-600 focus:outline-none duration-300"
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
                        <span class="text-sm leading-normal">تصوير</span>
                      </label>
                    </a>

                    <a
                      v-if="roles.includes('v') && mailType == '3'"
                      id="a1"
                      @click="func()"
                    >
                      <label
                        v-if="mailId"
                        class="w-48 flex justify-center items-center py-2 bg-white rounded-lg tracking-wide border border-green-600 cursor-pointer hover:text-white hover:bg-green-600 focus:outline-none duration-300"
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
                        <span class="text-sm leading-normal">تصوير</span>
                      </label>
                    </a>
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

                    <div class="w-1/2 flex justify-end">
                      <button
                        v-if="roles.includes('6') && image_of_doc"
                        @click="prepare_delete_all_documents()"
                        class="bg-red-500 hover:bg-red-400 px-4 py-2 rounded-lg text-white"
                      >
                        حذف كل الصور
                      </button>
                    </div>
                  </div>

                  <div
                    v-if="image_of_doc"
                    class="h-72 w-full rounded-md mt-2 mb-10"
                  >
                    <!--  v-if="imagesToSend != '' || imagesToShow != ''" -->
                    <div class="mt-2 pt-2 pb-4 rounded-md relative">
                      <div
                        v-if="!roles.includes('g')"
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
                                @click="open_model_to_order_image()"
                                type="button"
                                class="bg-green-600 hover:bg-green-500 duration-500 p-0 rounded-full focus:outline-none ml-2"
                              >
                                <div class="w-8 h-8">
                                  <svg
                                    class="w-full h-full text-white mx-auto"
                                    enable-background="new 0 0 100 100"
                                    id="Layer_1"
                                    version="1.1"
                                    viewBox="0 0 100 100"
                                    xml:space="preserve"
                                    xmlns="http://www.w3.org/2000/svg"
                                    xmlns:xlink="http://www.w3.org/1999/xlink"
                                  >
                                    <g>
                                      <rect
                                        fill="none"
                                        height="5.9"
                                        width="28.7"
                                        x="32.4"
                                        y="42.7"
                                      />
                                      <rect
                                        fill="none"
                                        height="5.9"
                                        width="28.7"
                                        x="32.4"
                                        y="51.2"
                                      />
                                      <rect
                                        fill="#010101"
                                        height="2.5"
                                        width="28.7"
                                        x="32.4"
                                        y="48.6"
                                      />
                                      <rect
                                        fill="#010101"
                                        height="2.5"
                                        width="28.7"
                                        x="32.4"
                                        y="40.2"
                                      />
                                      <rect
                                        fill="#010101"
                                        height="2.5"
                                        width="28.7"
                                        x="32.4"
                                        y="57.1"
                                      />
                                      <g>
                                        <polygon
                                          points="24.4,26 24.2,26.2 15.1,35.3 16.1,36.3 16.2,36.4 16.4,36.6 16.6,36.8 23.5,29.8 23.5,60.9 24.9,60.9 25.1,60.9     25.3,60.9 25.6,60.9 25.6,29.8 32.5,36.8 33,36.3 33.5,35.8 33.6,35.7 33.8,35.5 34,35.3 24.6,25.9   "
                                        />
                                        <polygon
                                          points="75.4,64.6 75.3,64.5 74.8,64.1 74.5,63.7 74.4,63.6 67.4,70.5 67.4,39.4 66.9,39.4 66.7,39.4 65.6,39.4     65.3,39.4 65.3,70.5 58.4,63.6 58,63.9 57.9,64.1 56.9,65 66,74.1 66.2,74.3 66.4,74.5 66.6,74.3 75.8,65   "
                                        />
                                      </g>
                                    </g>
                                  </svg>
                                </div>

                                <!-- <svg
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
                                </svg> -->
                              </button>

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

                              <button
                                v-if="roles.includes('6')"
                                type="button"
                                class="bg-red-600 hover:bg-red-500 duration-500 p-2 rounded-full focus:outline-none ml-2"
                                @click="prepare_delete_document()"
                              >
                                <svg
                                  class="w-4 h-4 stroke-current text-white mx-auto"
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
                class="col-span-2 grid grid-cols-1 gap-y-6 gap-x-4 sm:grid-cols-6 bg-gray-50 rounded-md p-6"
              >
                <div
                  class="sm:col-span-6 grid grid-cols-1 gap-y-6 gap-x-4 sm:grid-cols-6"
                >
                  <fieldset class="sm:col-span-3">
                    <div class="flex items-center">
                      <legend
                        class="block text-sm font-semibold text-gray-800 w-24"
                      >
                        <div v-if="mailType == '2'">توجيه البريد</div>

                        <div v-if="mailType == '3'">وارد من</div>
                      </legend>

                      <div class="flex items-center w-32">
                        <input
                          v-model="mail_forwarding"
                          id="Branches"
                          type="radio"
                          name="forwarding"
                          class="h-4 w-4"
                          value="1"
                          @click="get_sectors(1)"
                        />
                        <label for="Branches" class="mr-3 block text-gray-800">
                          فروع الرقابة
                        </label>
                      </div>

                      <div class="flex items-center w-32">
                        <input
                          v-model="mail_forwarding"
                          id="public_parties"
                          type="radio"
                          name="forwarding"
                          class="h-4 w-4"
                          value="2"
                          @click="get_sectors(2)"
                        />
                        <label
                          for="public_parties"
                          class="mr-3 block text-gray-800"
                        >
                          جهات عامة
                        </label>
                      </div>

                      <div class="flex items-center w-32">
                        <input
                          v-model="mail_forwarding"
                          id="private_parties"
                          type="radio"
                          name="forwarding"
                          class="h-4 w-4"
                          value="3"
                          @click="get_sectors(3)"
                        />
                        <label
                          for="private_parties"
                          class="mr-3 block text-gray-800"
                        >
                          جهات خاصة
                        </label>
                      </div>
                    </div>
                  </fieldset>

                  <!-- <div
                    v-if="mailType == '2'"
                    class="sm:col-span-3 border-2 border-red-500 rounded p-2"
                  >
                    لإضافة جهة يجب اختيار القطاع والجهة والضغط على زر الاضافة
                    (+) حتي يتم إضافة الجهة في مربع الجهات المرسل اليها
                  </div> -->

                  <!-- <div
                    v-if="mailType == '3'"
                    class="sm:col-span-3 border-2 border-red-500 rounded p-2"
                  >
                    لإضافة جهة يجب اختيار القطاع والجهة والضغط على زر الاضافة
                    (+) حتي يتم إضافة الجهة في مربع الجهة الوارد منها
                  </div> -->

                  <!-- <br /> -->

                  <div
                    class="sm:col-span-6 grid grid-cols-1 gap-y-6 gap-x-2 sm:grid-cols-7"
                  >
                    <div class="sm:col-span-4">
                      <label
                        for="department"
                        class="block text-sm font-semibold text-gray-800"
                      >
                        القطاع
                      </label>

                      <div class="relative">
                        <button
                          @click="sectorselect = !sectorselect"
                          id="department"
                          class="overflow-hidden text-right block mt-2 w-full rounded-md h-10 border text-xs bg-white border-green-400 hover:shadow-sm focus:outline-none focus:border-green-400 p-2"
                        >
                          {{ sectorNameSelected }}
                        </button>

                        <div
                          v-if="sectorselect"
                          class="border text-sm bg-white border-green-400 p-2 absolute w-full z-20 shadow h-40 overflow-y-scroll rounded-b-md"
                        >
                          <!-- <button
                              v-if="allDepartmentButton"
                              class="
                                block
                                focus:outline-none
                                w-full
                                my-1
                                text-right
                              "
                              @click="
                                selectAllDepartment(departments, 'الكل');
                                departmentselect = !departmentselect;
                              "
                            >
                          
                              الكل
                            </button> -->

                          <button
                            class="block focus:outline-none w-full my-1 text-right"
                            @click="
                              get_sides(sector.id, sector.section_Name, index);
                              sectorselect = !sectorselect;
                            "
                            v-for="(sector, index) in sectors"
                            :key="sector.id"
                          >
                            {{ sector.section_Name }}
                          </button>
                        </div>
                      </div>
                    </div>

                    <div class="sm:col-span-2">
                      <label
                        for="measure"
                        class="block text-sm font-semibold text-gray-800"
                      >
                        الجهة
                      </label>

                      <div class="relative">
                        <button
                          @click="sideselect = !sideselect"
                          @keyup.space.prevent
                          id="measure"
                          class="text-right block mt-2 w-full rounded-md h-10 border text-xs bg-white border-green-400 hover:shadow-sm focus:outline-none focus:border-green-400 p-2"
                        >
                          <!-- {{ sideNameSelected }} -->

                          <input
                            v-model="sideNameSelected"
                            type="text"
                            class="h-6 w-full"
                          />
                        </button>

                        <div
                          v-if="sideselect"
                          class="border text-sm bg-white border-green-400 p-2 absolute w-full z-20 shadow h-40 overflow-y-scroll rounded-b-md"
                        >
                          <button
                            class="block focus:outline-none w-full my-1 text-right"
                            @click="
                              pass_side(side.id, side.section_Name);
                              sideselect = !sideselect;
                            "
                            v-for="side in filterByTerm"
                            :key="side.id"
                          >
                            {{ side.section_Name }}
                          </button>
                        </div>
                      </div>
                    </div>

                    <div
                      class="sm:col-span-1 flex justify-end"
                      v-if="sectorNameSelected && sideNameSelected"
                    >
                      <button
                        v-if="add_button_consignees"
                        @click="add_sector_side_to_array()"
                        class="mt-8 rounded-md text-green-400 duration-200 hover:text-green-500 text-base font-semibold w-8 h-8"
                      >
                        <svg
                          class="fill-current w-full h-full"
                          version="1.1"
                          id="Capa_1"
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
                              />
                            </g>
                          </g>
                          <g>
                            <g>
                              <path
                                d="M355.148,234.386H275.83v-79.318c0-10.946-8.864-19.83-19.83-19.83s-19.83,8.884-19.83,19.83v79.318h-79.318
                                                            c-10.966,0-19.83,8.884-19.83,19.83s8.864,19.83,19.83,19.83h79.318v79.318c0,10.946,8.864,19.83,19.83,19.83
                                                            s19.83-8.884,19.83-19.83v-79.318h79.318c10.966,0,19.83-8.884,19.83-19.83S366.114,234.386,355.148,234.386z"
                              />
                            </g>
                          </g>
                        </svg>
                      </button>
                    </div>
                  </div>

                  <div class="sm:col-span-6">
                    <label
                      for="consignees"
                      class="block text-sm font-semibold text-gray-800"
                    >
                      <div v-if="mailType == '2'">الجهات المرسل اليها</div>

                      <div v-if="mailType == '3'">الجهة الوارد منها</div>
                    </label>
                    <div
                      class="mt-2 w-full rounded-md border border-green-400 p-2 h-24 overflow-y-scroll flex flex-wrap items-center"
                    >
                      <div
                        v-for="sector_side in sector_side_old_array"
                        :key="sector_side.side"
                        class="border-2 border-green-500 rounded-md text-sm flex items-center p-2 m-0.5"
                      >
                        {{ sector_side.sector_name }} ,
                        {{ sector_side.side_name }}
                        <!--  -->
                        <button
                          @click="delete_sector_side_from_array(sector_side.id)"
                          class="mr-1 rounded-full"
                        >
                          <svg
                            aria-hidden="true"
                            focusable="false"
                            data-prefix="far"
                            data-icon="times-circle"
                            class="w-5 h-5 stroke-current text-red-400 hover:text-red-500 duration-200"
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

                      <div
                        v-for="sector_side in sector_side_new_array"
                        :key="sector_side.side"
                        class="border border-gary-200 rounded-md text-sm flex items-center p-2 m-0.5"
                      >
                        {{ sector_side.sector_name }} ,
                        {{ sector_side.side_name }}
                        <!--  -->
                        <button
                          @click="
                            remove_sector_side_from_array(
                              sector_side.side_number,
                              sector_side.side_name,
                              sector_side.sector_number,
                              sector_side.sector_name
                            )
                          "
                          class="mr-1 rounded-full"
                        >
                          <svg
                            aria-hidden="true"
                            focusable="false"
                            data-prefix="far"
                            data-icon="times-circle"
                            class="w-5 h-5 stroke-current text-red-400 hover:text-red-500 duration-200"
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

                <div v-if="mailType == '2'" class="sm:col-span-6">
                  <label
                    for="action_required"
                    class="block text-sm font-semibold text-gray-800"
                  >
                    الإجراء المطلوب من الجهة
                  </label>
                  <textarea
                    v-model="action_required_by_the_entity"
                    id="action_required"
                    rows="3"
                    class="block mt-2 w-full text-sm rounded-md border border-green-400 hover:shadow-sm focus:outline-none focus:border-green-400 p-2"
                  >
                  </textarea>
                </div>

                <div
                  v-if="mailType == '3'"
                  class="sm:col-span-6 grid grid-cols-1 mt-6 gap-y-6 gap-x-4 sm:grid-cols-6 rounded-md"
                >
                  <fieldset class="sm:col-span-3">
                    <div class="flex items-center">
                      <legend
                        class="block text-sm font-semibold text-gray-800 w-24"
                      >
                        وارد إلي
                      </legend>
                      <div class="flex items-center w-32">
                        <input
                          v-model="ward_to"
                          id="chief"
                          type="radio"
                          name="ward_to"
                          class="h-4 w-4"
                          value="1"
                        />
                        <label for="chief" class="mr-3 block text-gray-800">
                          رئيس الهيئة
                        </label>
                      </div>

                      <div class="flex items-center w-32">
                        <input
                          v-model="ward_to"
                          id="proxy"
                          type="radio"
                          name="ward_to"
                          class="h-4 w-4"
                          value="2"
                        />
                        <label for="proxy" class="mr-3 block text-gray-800">
                          وكيل الهيئة
                        </label>
                      </div>

                      <div class="flex items-center w-48">
                        <input
                          v-model="ward_to"
                          id="proxy"
                          type="radio"
                          name="ward_to"
                          class="h-4 w-4"
                          value="3"
                        />
                        <label for="proxy" class="mr-3 block text-gray-800">
                          مدير إدارة أو مكتب
                        </label>
                      </div>
                    </div>
                  </fieldset>

                  <fieldset class="sm:col-span-3">
                    <div class="flex items-center">
                      <legend
                        class="block text-sm font-semibold text-gray-800 w-24"
                      >
                        نوعها
                      </legend>
                      <div class="flex items-center w-32">
                        <input
                          v-model="mail_ward_type"
                          id="directly"
                          type="radio"
                          name="mail_ward_type"
                          class="h-4 w-4"
                          value="1"
                        />
                        <label for="directly" class="mr-3 block text-gray-800">
                          مباشرة
                        </label>
                      </div>

                      <div class="flex items-center w-32">
                        <input
                          v-model="mail_ward_type"
                          id="copy"
                          type="radio"
                          name="mail_ward_type"
                          class="h-4 w-4"
                          value="2"
                        />
                        <label for="copy" class="mr-3 block text-gray-800">
                          صورة
                        </label>
                      </div>
                    </div>
                  </fieldset>

                  <div class="sm:col-span-2">
                    <label
                      for="entity_mail_date"
                      class="block text-sm font-semibold text-gray-800"
                    >
                      تاريخ رسالة الجهة
                    </label>
                    <input
                      v-model="entity_mail_date"
                      type="date"
                      min="2000-01-01"
                      max="2040-12-30"
                      id="entity_mail_date"
                      class="block mt-2 w-full rounded-md h-10 border border-green-400 hover:shadow-sm focus:outline-none focus:border-green-400 px-2"
                      required
                    />
                  </div>

                  <div class="sm:col-span-2">
                    <label
                      for="entity_reference_number"
                      class="block text-sm font-semibold text-gray-800"
                    >
                      رقم إشارة الجهة
                    </label>
                    <input
                      v-model="entity_reference_number"
                      type="number"
                      id="entity_reference_number"
                      class="block mt-2 h-10 w-full rounded-md border border-green-400 hover:shadow-sm focus:outline-none focus:border-green-400 px-2"
                      required
                    />
                  </div>

                  <div class="sm:col-span-2">
                    <label
                      for="procedure_type"
                      class="block text-sm font-semibold text-gray-800"
                    >
                      نوع الإجراء
                    </label>
                    <select
                      v-model="procedure_type"
                      id="procedure_type"
                      class="block mt-2 w-full rounded-md h-10 border border-green-400 hover:shadow-sm focus:outline-none focus:border-green-400 p-2"
                    >
                      <option value="1">لم تعرض</option>
                      <option value="2">عرضت</option>
                    </select>
                  </div>
                </div>
              </section>

              <section>
                <div class="sm:col-span-6 flex items-center justify-end mt-10">
                  <div class="flex justify-end ml-6">
                    <!--  :href="$router.resolve({ name: 'sent-add' }).href" -->
                    <button
                      v-if="summary && classification"
                      @click="clear_page()"
                      class="flex justify-center items-center py-2 px-8 border border-transparent shadow-sm text-sm font-medium rounded-md border-green-600 text-green-600 hover:shadow-lg focus:shadow-none duration-300 focus:outline-none"
                    >
                      <svg
                        class="w-5 h-5 stroke-current ml-2 fill-current"
                        enable-background="new 0 0 512 512"
                        height="512"
                        viewBox="0 0 512 512"
                        width="512"
                        xmlns="http://www.w3.org/2000/svg"
                      >
                        <g>
                          <path d="m115.817 138.734h195.166v30h-195.166z" />
                          <path d="m115.817 198.734h195.166v30h-195.166z" />
                          <path d="m115.817 258.734h195.166v30h-195.166z" />
                          <path
                            d="m438.304 330.762c-15.36-15.361-34.297-25.016-54.154-28.976v-301.786h-272.714l-68.786 68.787v372.418h220.429c5.203 14.767 13.686 28.302 25.084 39.7 20.052 20.052 46.713 31.095 75.071 31.095 28.357 0 55.019-11.043 75.07-31.096 41.395-41.394 41.395-108.747 0-150.142zm-316.92-298.283v46.255h-46.255zm-48.734 378.726v-302.47h78.734v-78.735h202.766v270.11c-24.084 2.05-47.598 12.262-65.987 30.652-20.053 20.052-31.096 46.713-31.096 75.071 0 1.798.045 3.588.133 5.371h-184.55zm344.442 48.486c-14.386 14.386-33.513 22.309-53.858 22.309-20.346 0-39.473-7.923-53.858-22.309-14.386-14.386-22.309-33.513-22.309-53.857s7.923-39.472 22.309-53.858c14.851-14.85 34.351-22.273 53.858-22.273 19.502 0 39.011 7.426 53.857 22.273 29.698 29.697 29.698 78.018.001 107.715z"
                          />
                          <path
                            d="m378.233 365.807h-30v25.026h-25.026v30h25.026v25.027h30v-25.027h25.027v-30h-25.027z"
                          />
                        </g>
                      </svg>
                      جديد
                    </button>
                  </div>

                  <div v-if="updataButton" class="flex justify-end ml-6">
                    <div v-if="roles.includes('w') && mailType == '1'" class="">
                      <button
                        v-if="
                          summary &&
                          is_exisite_genaral_inbox_number == true &&
                          classification &&
                          (consignees.length != 0 ||
                            newactionSenders.length != 0)
                        "
                        @click="updateMail"
                        type="button"
                        id="edit"
                        class="w-full sm:w-auto sm:mr-3 flex justify-center items-center py-2 px-4 border border-transparent shadow-sm text-sm font-medium rounded-md border-green-600 text-white bg-green-600 hover:shadow-lg focus:shadow-none duration-300 focus:outline-none"
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

                    <div v-if="roles.includes('y') && mailType == '2'" class="">
                      <button
                        v-if="
                          summary &&
                          is_exisite_genaral_inbox_number == true &&
                          classification &&
                          (sector_side_new_array.length != 0 ||
                            sector_side_old_array.length != 0) &&
                          (consignees.length != 0 ||
                            newactionSenders.length != 0)
                        "
                        @click="updateMail"
                        type="button"
                        id="edit"
                        class="w-full sm:w-auto sm:mr-3 flex justify-center items-center py-2 px-4 border border-transparent shadow-sm text-sm font-medium rounded-md border-green-600 text-white bg-green-600 hover:shadow-lg focus:shadow-none duration-300 focus:outline-none"
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

                    <div v-if="roles.includes('x') && mailType == '3'" class="">
                      <button
                        v-if="
                          summary &&
                          is_exisite_genaral_inbox_number == true &&
                          (sector_side_new_array.length != 0 ||
                            sector_side_old_array.length != 0) &&
                          classification
                        "
                        @click="updateMail"
                        type="button"
                        id="edit"
                        class="w-full sm:w-auto sm:mr-3 flex justify-center items-center py-2 px-4 border border-transparent shadow-sm text-sm font-medium rounded-md border-green-600 text-white bg-green-600 hover:shadow-lg focus:shadow-none duration-300 focus:outline-none"
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

                  <div v-if="deleteButton" class="flex justify-end ml-6">
                    <div v-if="roles.includes('3') && mailType == '1'" class="">
                      <button
                        v-if="
                          summary &&
                          classification &&
                          (consignees.length != 0 ||
                            newactionSenders.length != 0)
                        "
                        @click="prepare_delete_mail()"
                        type="button"
                        id="edit"
                        class="w-full sm:w-auto sm:mr-3 flex justify-center items-center py-2 px-4 border border-transparent shadow-sm text-sm font-medium rounded-md border-green-600 text-white bg-green-600 hover:shadow-lg focus:shadow-none duration-300 focus:outline-none"
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
                        حذف
                      </button>
                    </div>

                    <div v-if="roles.includes('5') && mailType == '2'" class="">
                      <button
                        v-if="
                          summary &&
                          classification &&
                          (consignees.length != 0 ||
                            newactionSenders.length != 0)
                        "
                        @click="prepare_delete_mail()"
                        type="button"
                        id="edit"
                        class="w-full sm:w-auto sm:mr-3 flex justify-center items-center py-2 px-4 border border-transparent shadow-sm text-sm font-medium rounded-md border-green-600 text-white bg-green-600 hover:shadow-lg focus:shadow-none duration-300 focus:outline-none"
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
                        حذف
                      </button>
                    </div>

                    <div v-if="roles.includes('4') && mailType == '3'" class="">
                      <button
                        v-if="summary && classification"
                        @click="prepare_delete_mail()"
                        type="button"
                        id="edit"
                        class="w-full sm:w-auto sm:mr-3 flex justify-center items-center py-2 px-4 border border-transparent shadow-sm text-sm font-medium rounded-md border-green-600 text-white bg-green-600 hover:shadow-lg focus:shadow-none duration-300 focus:outline-none"
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
                        حذف
                      </button>
                    </div>
                  </div>

                  <div v-if="saveButton" class="flex justify-end">
                    <div v-if="mailType == '1'" class="">
                      <button
                        v-if="
                          summary &&
                          is_exisite_genaral_inbox_number == true &&
                          classification &&
                          (consignees.length != 0 ||
                            newactionSenders.length != 0)
                        "
                        class="flex justify-center items-center py-2 px-8 border border-transparent shadow-sm text-sm font-medium rounded-md border-green-600 text-white bg-green-600 hover:shadow-lg focus:shadow-none duration-300 focus:outline-none"
                        @click="saveMail()"
                      >
                        <svg
                          class="w-4 h-4 stroke-current ml-2 fill-current"
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
                                  d="M166,332h180c8.284,0,15-6.716,15-15s-6.716-15-15-15H166c-8.284,0-15,6.716-15,15S157.716,332,166,332z"
                                ></path>
                                <path
                                  d="M166,392h180c8.284,0,15-6.716,15-15s-6.716-15-15-15H166c-8.284,0-15,6.716-15,15S157.716,392,166,392z"
                                ></path>
                                <path
                                  d="M507.606,84.394l-80-80C424.793,1.58,420.978,0,417,0H15C6.716,0,0,6.716,0,15v482c0,8.284,6.716,15,15,15
                                                  c6.912,0,477.495,0,482,0c8.284,0,15-6.716,15-15V95C512,91.021,510.419,87.206,507.606,84.394z M121,30h210v100H121V30z
                                                  M391,482H121V272h270V482z M482,482h-61V257c0-8.284-6.716-15-15-15H106c-8.284,0-15,6.716-15,15v225H30V30h61v115
                                                  c0,8.284,6.716,15,15,15h240c8.284,0,15-6.716,15-15V30h49.787L482,101.213V482z"
                                ></path>
                                <path
                                  d="M166,452h180c8.284,0,15-6.716,15-15s-6.716-15-15-15H166c-8.284,0-15,6.716-15,15S157.716,452,166,452z"
                                ></path>
                              </g>
                            </g>
                          </g>
                        </svg>
                        حفظ
                      </button>
                    </div>

                    <div v-if="mailType == '2'" class="">
                      <button
                        v-if="
                          summary &&
                          classification &&
                          is_exisite_genaral_inbox_number == true &&
                          (consignees.length != 0 ||
                            newactionSenders.length != 0) &&
                          mail_forwarding &&
                          (sector_side_new_array.length != 0 ||
                            sector_side_old_array.length != 0) &&
                          action_required_by_the_entity
                        "
                        class="flex justify-center items-center py-2 px-8 border border-transparent shadow-sm text-sm font-medium rounded-md border-green-600 text-white bg-green-600 hover:shadow-lg focus:shadow-none duration-300 focus:outline-none"
                        @click="saveMail()"
                      >
                        <svg
                          class="w-4 h-4 stroke-current ml-2 fill-current"
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
                                  d="M166,332h180c8.284,0,15-6.716,15-15s-6.716-15-15-15H166c-8.284,0-15,6.716-15,15S157.716,332,166,332z"
                                ></path>
                                <path
                                  d="M166,392h180c8.284,0,15-6.716,15-15s-6.716-15-15-15H166c-8.284,0-15,6.716-15,15S157.716,392,166,392z"
                                ></path>
                                <path
                                  d="M507.606,84.394l-80-80C424.793,1.58,420.978,0,417,0H15C6.716,0,0,6.716,0,15v482c0,8.284,6.716,15,15,15
                                                  c6.912,0,477.495,0,482,0c8.284,0,15-6.716,15-15V95C512,91.021,510.419,87.206,507.606,84.394z M121,30h210v100H121V30z
                                                  M391,482H121V272h270V482z M482,482h-61V257c0-8.284-6.716-15-15-15H106c-8.284,0-15,6.716-15,15v225H30V30h61v115
                                                  c0,8.284,6.716,15,15,15h240c8.284,0,15-6.716,15-15V30h49.787L482,101.213V482z"
                                ></path>
                                <path
                                  d="M166,452h180c8.284,0,15-6.716,15-15s-6.716-15-15-15H166c-8.284,0-15,6.716-15,15S157.716,452,166,452z"
                                ></path>
                              </g>
                            </g>
                          </g>
                        </svg>
                        حفظ
                      </button>
                    </div>

                    <div v-if="mailType == '3'" class="">
                      <button
                        v-if="
                          summary &&
                          classification &&
                          is_exisite_genaral_inbox_number == true &&
                          (sector_side_new_array.length != 0 ||
                            sector_side_old_array.length != 0) &&
                          ward_to &&
                          mail_ward_type &&
                          entity_mail_date &&
                          entity_reference_number &&
                          procedure_type
                        "
                        class="flex justify-center items-center py-2 px-8 border border-transparent shadow-sm text-sm font-medium rounded-md border-green-600 text-white bg-green-600 hover:shadow-lg focus:shadow-none duration-300 focus:outline-none"
                        @click="saveMail()"
                      >
                        <svg
                          class="w-4 h-4 stroke-current ml-2 fill-current"
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
                                  d="M166,332h180c8.284,0,15-6.716,15-15s-6.716-15-15-15H166c-8.284,0-15,6.716-15,15S157.716,332,166,332z"
                                ></path>
                                <path
                                  d="M166,392h180c8.284,0,15-6.716,15-15s-6.716-15-15-15H166c-8.284,0-15,6.716-15,15S157.716,392,166,392z"
                                ></path>
                                <path
                                  d="M507.606,84.394l-80-80C424.793,1.58,420.978,0,417,0H15C6.716,0,0,6.716,0,15v482c0,8.284,6.716,15,15,15
                                                  c6.912,0,477.495,0,482,0c8.284,0,15-6.716,15-15V95C512,91.021,510.419,87.206,507.606,84.394z M121,30h210v100H121V30z
                                                  M391,482H121V272h270V482z M482,482h-61V257c0-8.284-6.716-15-15-15H106c-8.284,0-15,6.716-15,15v225H30V30h61v115
                                                  c0,8.284,6.716,15,15,15h240c8.284,0,15-6.716,15-15V30h49.787L482,101.213V482z"
                                ></path>
                                <path
                                  d="M166,452h180c8.284,0,15-6.716,15-15s-6.716-15-15-15H166c-8.284,0-15,6.716-15,15S157.716,452,166,452z"
                                ></path>
                              </g>
                            </g>
                          </g>
                        </svg>
                        حفظ
                      </button>
                    </div>
                  </div>

                  <div v-if="sendButton" class="flex justify-end">
                    <div v-if="roles.includes('z') && mailType == '1'" class="">
                      <button
                        v-if="
                          summary &&
                          classification &&
                          (consignees.length != 0 ||
                            newactionSenders.length != 0)
                        "
                        class="flex justify-center items-center py-2 px-8 border border-transparent shadow-sm text-sm font-medium rounded-md border-green-600 text-white bg-green-600 hover:shadow-lg focus:shadow-none duration-300 focus:outline-none"
                        @click="sendMail()"
                      >
                        <svg
                          class="w-4 h-4 stroke-current ml-2 fill-current"
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
                                  d="M166,332h180c8.284,0,15-6.716,15-15s-6.716-15-15-15H166c-8.284,0-15,6.716-15,15S157.716,332,166,332z"
                                ></path>
                                <path
                                  d="M166,392h180c8.284,0,15-6.716,15-15s-6.716-15-15-15H166c-8.284,0-15,6.716-15,15S157.716,392,166,392z"
                                ></path>
                                <path
                                  d="M507.606,84.394l-80-80C424.793,1.58,420.978,0,417,0H15C6.716,0,0,6.716,0,15v482c0,8.284,6.716,15,15,15
                                                  c6.912,0,477.495,0,482,0c8.284,0,15-6.716,15-15V95C512,91.021,510.419,87.206,507.606,84.394z M121,30h210v100H121V30z
                                                  M391,482H121V272h270V482z M482,482h-61V257c0-8.284-6.716-15-15-15H106c-8.284,0-15,6.716-15,15v225H30V30h61v115
                                                  c0,8.284,6.716,15,15,15h240c8.284,0,15-6.716,15-15V30h49.787L482,101.213V482z"
                                ></path>
                                <path
                                  d="M166,452h180c8.284,0,15-6.716,15-15s-6.716-15-15-15H166c-8.284,0-15,6.716-15,15S157.716,452,166,452z"
                                ></path>
                              </g>
                            </g>
                          </g>
                        </svg>
                        إرسال
                      </button>
                    </div>

                    <div v-if="roles.includes('2') && mailType == '2'" class="">
                      <button
                        v-if="
                          summary &&
                          classification &&
                          (consignees.length != 0 ||
                            newactionSenders.length != 0)
                        "
                        class="flex justify-center items-center py-2 px-8 border border-transparent shadow-sm text-sm font-medium rounded-md border-green-600 text-white bg-green-600 hover:shadow-lg focus:shadow-none duration-300 focus:outline-none"
                        @click="sendMail()"
                      >
                        <svg
                          class="w-4 h-4 stroke-current ml-2 fill-current"
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
                                  d="M166,332h180c8.284,0,15-6.716,15-15s-6.716-15-15-15H166c-8.284,0-15,6.716-15,15S157.716,332,166,332z"
                                ></path>
                                <path
                                  d="M166,392h180c8.284,0,15-6.716,15-15s-6.716-15-15-15H166c-8.284,0-15,6.716-15,15S157.716,392,166,392z"
                                ></path>
                                <path
                                  d="M507.606,84.394l-80-80C424.793,1.58,420.978,0,417,0H15C6.716,0,0,6.716,0,15v482c0,8.284,6.716,15,15,15
                                                  c6.912,0,477.495,0,482,0c8.284,0,15-6.716,15-15V95C512,91.021,510.419,87.206,507.606,84.394z M121,30h210v100H121V30z
                                                  M391,482H121V272h270V482z M482,482h-61V257c0-8.284-6.716-15-15-15H106c-8.284,0-15,6.716-15,15v225H30V30h61v115
                                                  c0,8.284,6.716,15,15,15h240c8.284,0,15-6.716,15-15V30h49.787L482,101.213V482z"
                                ></path>
                                <path
                                  d="M166,452h180c8.284,0,15-6.716,15-15s-6.716-15-15-15H166c-8.284,0-15,6.716-15,15S157.716,452,166,452z"
                                ></path>
                              </g>
                            </g>
                          </g>
                        </svg>
                        إرسال
                      </button>
                    </div>

                    <div v-if="roles.includes('1') && mailType == '3'" class="">
                      <button
                        v-if="
                          summary && classification && consignees.length != 0
                        "
                        class="flex justify-center items-center py-2 px-8 border border-transparent shadow-sm text-sm font-medium rounded-md border-green-600 text-white bg-green-600 hover:shadow-lg focus:shadow-none duration-300 focus:outline-none"
                        @click="sendMail()"
                      >
                        <svg
                          class="w-4 h-4 stroke-current ml-2 fill-current"
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
                                  d="M166,332h180c8.284,0,15-6.716,15-15s-6.716-15-15-15H166c-8.284,0-15,6.716-15,15S157.716,332,166,332z"
                                ></path>
                                <path
                                  d="M166,392h180c8.284,0,15-6.716,15-15s-6.716-15-15-15H166c-8.284,0-15,6.716-15,15S157.716,392,166,392z"
                                ></path>
                                <path
                                  d="M507.606,84.394l-80-80C424.793,1.58,420.978,0,417,0H15C6.716,0,0,6.716,0,15v482c0,8.284,6.716,15,15,15
                                                  c6.912,0,477.495,0,482,0c8.284,0,15-6.716,15-15V95C512,91.021,510.419,87.206,507.606,84.394z M121,30h210v100H121V30z
                                                  M391,482H121V272h270V482z M482,482h-61V257c0-8.284-6.716-15-15-15H106c-8.284,0-15,6.716-15,15v225H30V30h61v115
                                                  c0,8.284,6.716,15,15,15h240c8.284,0,15-6.716,15-15V30h49.787L482,101.213V482z"
                                ></path>
                                <path
                                  d="M166,452h180c8.284,0,15-6.716,15-15s-6.716-15-15-15H166c-8.284,0-15,6.716-15,15S157.716,452,166,452z"
                                ></path>
                              </g>
                            </g>
                          </g>
                        </svg>
                        إرسال
                      </button>
                    </div>
                  </div>
                </div>
              </section>



              <div>.</div>
              <!-- <section
                class="bg-gray-100 rounded-md p-6 flex flex-wrap items-center"
              >
                <button
                  v-for="consignee in consignees"
                  :key="consignee.side"
                  @click="
                    GetReplyByDepartment(
                      consignee.departmentId,
                      consignee.send_ToId,
                      consignee.departmentName,
                      consignee.flag
                    )
                  "
                  class="border border-blue-400 hover:bg-blue-400 hover:text-white duration-300 focus:outline-none rounded-md text-sm p-2 m-0.5"
                >
                  {{ consignee.departmentName }} ,
                  {{ consignee.measureName }}
                </button>
              </section> -->

              <!-- <section
                v-if="departmentflag > 2 && roles.includes('f')"
                class="bg-gray-100 rounded-md p-6"
              >
                <p class="block text-sm font-semibold text-gray-800">
                  ردود - {{ departmentName }}
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
                        ? ' flex-row-reverse justify-start'
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
                          v-if="reply.reply.to != my_department_id"
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

                        <div v-if="reply.resources == true" class="mx-2">
                          <button
                            v-if="roles.includes('g')"
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
                </div> -->
                <!-- 
                <div class="flex justify-between items-center mt-2">
                  <div class="w-9/12 flex justify-between">
                    <div class="w-10/12">
                      <textarea
                        id=""
                        class="
                          block
                          w-full
                          h-20
                          text-sm
                          rounded-md
                          border border-green-400
                          hover:shadow-sm
                          focus:outline-none focus:border-green-400
                          p-2
                        "
                        v-model="reply_to_add"
                      >
                      </textarea>
                    </div>

                    <div class="w-2/12 mr-4">
                      <label
                        v-if="reply_to_add != ''"
                        class="
                          w-48
                          h-full
                          flex
                          justify-center
                          items-center
                          py-2
                          bg-white
                          rounded-lg
                          tracking-wide
                          border border-green-600
                          cursor-pointer
                          hover:text-white hover:bg-green-600
                          focus:outline-none
                          duration-300
                        "
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
                        <span class="text-sm leading-normal"> </span>
                        <input
                          class="hidden"
                          type="button"
                          @click="scanToReply"
                        />
                        <a id="a2" @click="reply1()"> الماسح الضوئي </a>
                      </label>
                    </div>
                  </div>

                  <div class="w-2/12 mr-4">
                    <button
                      v-if="reply_to_add != ''"
                      @click="AddReply()"
                      class="
                        w-full
                        flex
                        items-center
                        justify-center
                        h-20
                        py-2
                        bg-white
                        rounded-lg
                        text-blue-600
                        tracking-wide
                        border border-blue-600
                        cursor-pointer
                        hover:text-white hover:bg-blue-600
                        focus:outline-none
                        duration-300
                      "
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
                </div> -->
              <!-- </section> -->


            </div>
          </main>
        </div>
      </div>
    </div>

    <div
      v-if="alert_prepare_delete_document"
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
        <p class="text-xl font-bold mt-4">هل انت متأكد من عملية الحذف؟</p>
        <p class="text-gray-600">لن تتمكن من استرداد المستند بعد حذفه.</p>

        <div class="mt-6">
          <button
            v-if="delete_all_documents"
            @click="deleteAllDocuments()"
            class="bg-red-600 hover:bg-red-700 hover:shadow-lg duration-200 rounded text-white w-32 py-1 ml-2"
          >
            نعم ، احذفها
          </button>

          <button
            v-else
            @click="deleteDocument()"
            class="bg-red-600 hover:bg-red-700 hover:shadow-lg duration-200 rounded text-white w-32 py-1 ml-2"
          >
            نعم ، احذفها
          </button>
          <button
            @click="alert_prepare_delete_document = false"
            class="bg-gray-400 hover:bg-gray-700 hover:shadow-lg duration-200 rounded text-white w-32 py-1 mr-2"
          >
            إلغاء
          </button>
        </div>
      </div>
    </div>

    <div
      v-if="alert_prepare_delete_mail"
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
        <p class="text-xl font-bold mt-4">هل انت متأكد من عملية الحذف؟</p>
        <p class="text-gray-600">لن تتمكن من استرداد البريد بعد حذفه.</p>

        <div class="mt-6">
          <button
            @click="deleteMail"
            class="bg-red-600 hover:bg-red-700 hover:shadow-lg duration-200 rounded text-white w-32 py-1 ml-2"
          >
            نعم ، احذفها
          </button>
          <button
            @click="alert_prepare_delete_mail = false"
            class="bg-gray-400 hover:bg-gray-700 hover:shadow-lg duration-200 rounded text-white w-32 py-1 mr-2"
          >
            إلغاء
          </button>
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
          <button
            type="button"
            @click="image_rotate = !image_rotate"
            class="absolute text-white font-bold px-8 z-50 bg-yellow-500 py-2 right-12"
          >
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
      v-if="show_current_reply_image_to_for_bigger_screen_model"
      class="w-screen h-full absolute inset-0 z-50 overflow-hidden"
    >
      <div class="relative">
        <div
          v-if="reply_image_to_print_n_model"
          id="print_reply_doc_n"
          class="bg-black bg-opacity-50 h-screen-100"
        >
          <!--  v-for="image in reply_image_to_print_n"
            :key="image.id" -->
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
                @click="print_reply_image()"
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

    <div
      v-if="alert_state"
      class="w-screen h-full flex justify-center items-center absolute inset-0 z-50 overflow-hidden bg-black bg-opacity-70"
    >
      <div
        class="bg-yellow-100 rounded-md w-1/3 py-10 flex flex-col justify-center items-center"
      >
        <div
          v-if="alert_state_true_false"
          class="flex flex-col justify-center items-center"
        >
          <div class="">
            <svg
              class="w-14 h-14 stroke-current stroke-2 text-green-600"
              fill="none"
              stroke="currentColor"
              viewBox="0 0 24 24"
              xmlns="http://www.w3.org/2000/svg"
            >
              <path
                strokeLinecap="round"
                strokeLinejoin="round"
                strokeWidth="{2}"
                d="M9 12l2 2 4-4m6 2a9 9 0 11-18 0 9 9 0 0118 0z"
              />
            </svg>
          </div>
          <p class="text-xl font-bold mt-4">تمت العملية بنجاح..</p>
        </div>

        <div v-else class="flex flex-col justify-center items-center">
          <div class="">
            <svg
              class="w-14 h-14 stroke-current stroke-2 text-red-600"
              fill="none"
              stroke="currentColor"
              viewBox="0 0 24 24"
              xmlns="http://www.w3.org/2000/svg"
            >
              <path
                strokeLinecap="round"
                strokeLinejoin="round"
                strokeWidth="{2}"
                d="M10 14l2-2m0 0l2-2m-2 2l-2-2m2 2l2 2m7-2a9 9 0 11-18 0 9 9 0 0118 0z"
              />
            </svg>
          </div>
          <p class="text-xl font-bold mt-4">فشلت العملية..</p>
        </div>

        <div class="mt-6">
          <button
            @click="alert_state = false"
            class="bg-blue-500 hover:bg-blue-700 hover:shadow-lg duration-200 rounded text-white w-32 py-1 mr-2"
          >
            حسناً
          </button>
        </div>
      </div>
    </div>

    <div
      v-if="show_model_to_order_image"
      class="w-screen h-full absolute inset-0 z-50 overflow-hidden"
    >
      <div class="relative">
        <div class="h-screen bg-black bg-opacity-90 absolute top-0 inset-0 z-50 w-full">

          <div class="w-full text-white">
            <div class="">
              <div
                class="flex justify-between items-center w-full p-4 text-white text-xl"
              >
                <div class="">
                  <span>ترتيب مرفقات للبريد </span> 
                  <span class="underline">
                    {{ mail_Number }} {{ my_department_id }} {{mail_year}}
                  </span>
                </div>
                <div
                  @click="show_model_to_order_image = false"
                  class="bg-red-600 w-8 h-8 rounded-full flex items-center justify-center"
                >
                  X
                </div>
              </div>
            </div>

            <div class="flex items-start justify-between p-4">
              <div class="w-3/12 h-screen-75">
                <p>الترتيب الحالي</p>
                <div class="bg-white p-1 overflow-y-scroll mt-4 h-screen-75">
                    <button 
                      @click="select_image_to_ordering(n)" 
                      class="my-1 py-1  w-full" v-for="(n, index) in ordering_image_list" :key="n.id"
                      :class="index_of_image_selected == n.order? 'bg-blue-700 hover:bg-blue-600' : 'bg-gray-700 hover:bg-gray-600'"
                      >
                      الصورة رقم 
                      {{ index+1 }}
                    </button>
              
                </div>
              </div>

              <div class="w-2/12 h-screen-75 flex flex-col items-center justify-center">
                <button @click="show_image_to_ordering()" class="bg-gray-600 hover:bg-gray-500 my-5 py-1 w-44">عرض المرفق</button>

                <button @click="transfer_image_to_order()" class="bg-gray-600 hover:bg-gray-500 my-5 py-1 w-44">نقل المرفق</button>

                <button @click="transfer_back_image_to_order()" class="bg-gray-600 hover:bg-gray-500 my-5 py-1 w-44">إرجاع المرفق</button>

                <button @click="transfer_all_images_to_order()" class="bg-gray-600 hover:bg-gray-500 my-5 py-1 w-44">نقل كل المرفقات</button>

                <button @click="transfer_back_images_to_order()" class="bg-gray-600 hover:bg-gray-500 my-5 py-1 w-44">إرجاع كل المرفقات</button>

                <button @click="save_new_order()" class="bg-green-600 hover:bg-green-500 mt-10 py-1 w-48 text-lg font-bold"> حفظ الترتيب الجديد </button>
              </div>



              <div class="w-3/12 h-screen-75">
                <p>الترتيب الجديد</p>
                <div class="bg-white p-1 overflow-y-scroll mt-4 h-screen-75">
                    <button 
                      @click="select_image_to_ordering(n)" 
                      class="my-1 py-1  w-full" v-for="(n, index) in new_ordering_image_list" :key="n.id"
                      :class="index_of_image_selected == n.order? 'bg-blue-700 hover:bg-blue-600' : 'bg-gray-700 hover:bg-gray-600'"
                      >
                      الصورة رقم 
                      {{ index+1 }}
                    </button>
              
                </div>
              </div>

      

           

              <div class="w-4/12 h-screen-75 pr-6">
                <p>المرفق</p>
                <div class="w-full h-screen-75 bg-gray-400 mt-4">
                  <img
                    :src="image_ordering"
                    alt="image"
                    :class="image_rotate ? 'rotate-0' : 'rotate-180'"
                    class="h-full w-full object-contain transform"
                  />
                </div>
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

export default {
  created() {},

  destroyed() {
    console.log("destroyed_send_form");
    if (this.conn != null) {
      if (this.conn.readystate != 3) {
        console.log("readystate destory_sent_form=" + this.conn.readyState);
        this.conn.close();
        console.log("close_sent_form");
        this.conn = null;
      }
    }
  },
  components: {
    asideComponent,
    navComponent,
    svgLoadingComponent,
  },

  mounted() {
    //*********************websocket 18/8/2022
    //  this.conn = new WebSocket("ws://localhost:58316/ws");
    // this.conn = new WebSocket("ws://mail:82/ws");
    // //*********************websocket 8/1/2023

    /*this.connect1();
this.massage_on();

this.conn.onerror =(error) =>{
  console.error(error.message);
this.conn.close();
};

this.conn.onopen =(event) =>{
console.log("open")
};

//**************onmassage



//this.conn.onclose =(event) =>{

//console.log("WebSocket close");
//this.conn.close();

//setTimeout(()=>{
  //this.conn=null;
  //this.massage1();

//},1000);


//};

setInterval(()=>{
  if(this.conn.readyState===3){
    this.conn=null;
   this.massage1();
   console.log("setinterval");
  
  }
},10000)*/

    //21/1/2023
    /*this.conn.onerror =(error) =>{
console.log("WebSocket Error " + error);
};

this.conn.onclose =(event) =>{
console.log("readystate"+this.conn.readyState);
console.log("code="+event.code);
console.log("WebSocket close");*/
    //*********23/1/2023

    /*setTimeout(()=>{
 // this.conn=null;
  this.conn = new WebSocket("ws://localhost:58316/ws");
 this.conn.onmessage = (event) => {
      console.log("settime onmessage");
      let scannedImage = event.data;
      let mgs = JSON.parse(scannedImage);
      this.imagesscantest = mgs;
      var ind = this.imagesscantest.index;
console.log("index="+ind);
      if (ind == 1) {
        this.keyid = this.imagesscantest.keyid;
        console.log("settime keyid="+this.keyid);
      } else {
        var flag1 = this.imagesscantest.flag1;
        if (flag1 == 1){
          console.log("settime flag="+flag1);
           this.imagesToSend = [];
        }
        for (var i = 0; i < mgs["image"].length; i++) {
          this.indexOfimagesToShow++;
          this.imagesToSend.push({
            baseAs64: mgs["image"][i],
            index: this.indexOfimagesToShow,
          });
        }

        if (flag1 == 1){
           this.UploadImagesMail();
           console.log("settime uploadimagemail function");
        }
      }
    };

},1000);*/
    //};

    /* this.conn.onclose = (event) => {
      console.log("readystate" + this.conn.readyState);
      console.log("WebSocket close");
      console.log("code="+event.code);
    };*/

    // setTimeout(()=>{
    //   this.conn=null;
    //   this.conn = new WebSocket("ws://localhost:58316/ws");
    //  this.conn.onmessage = (event) => {
    //       console.log("settime onmessage");
    //       let scannedImage = event.data;
    //       let mgs = JSON.parse(scannedImage);
    //       this.imagesscantest = mgs;
    //       var ind = this.imagesscantest.index;
    // console.log("index="+ind);
    //       if (ind == 1) {
    //         this.keyid = this.imagesscantest.keyid;
    //         console.log("settime keyid="+this.keyid);
    //       } else {
    //         var flag1 = this.imagesscantest.flag1;
    //         if (flag1 == 1){
    //           console.log("settime flag="+flag1);
    //            this.imagesToSend = [];
    //         }
    //         for (var i = 0; i < mgs["image"].length; i++) {
    //           this.indexOfimagesToShow++;
    //           this.imagesToSend.push({
    //             baseAs64: mgs["image"][i],
    //             index: this.indexOfimagesToShow,
    //           });
    //         }

    //         if (flag1 == 1){
    //            this.UploadImagesMail();
    //            console.log("settime uploadimagemail function");
    //         }
    //       }
    //     };

    // },1000);
    // };

    //21/1/2023
    /* this.conn.onopen = (event) => {
      console.log("open");
    };

    this.conn.onmessage = (event) => {
      console.log("onmessage");
      let scannedImage = event.data;
      let mgs = JSON.parse(scannedImage);
      this.imagesscantest = mgs;
      var ind = this.imagesscantest.index;
      console.log("index=" + ind);
      if (ind == 1) {
        this.keyid = this.imagesscantest.keyid;
        console.log("keyid=" + this.keyid);
      } else {
        var flag1 = this.imagesscantest.flag1;
        if (flag1 == 1) {
          console.log("flag=" + flag1);
          this.imagesToSend = [];
        }
        for (var i = 0; i < mgs["image"].length; i++) {
          this.indexOfimagesToShow++;
          this.imagesToSend.push({
            baseAs64: mgs["image"][i],
            index: this.indexOfimagesToShow,
          });
        }

        if (flag1 == 1) {
          this.UploadImagesMail();
          console.log("uploadimagemail function");
        }
      }
    };end 21/1/2023*/
    //var   conn= null;
    var date = new Date();

    var month = date.getMonth() + 1;
    var day = date.getDate();

    if (month < 10) month = "0" + month;
    if (day < 10) day = "0" + day;

    this.releaseDate = date.getFullYear() + "-" + month + "-" + day;

    this.genaral_inbox_year = date.getFullYear();
    this.mail_year = date.getFullYear();
    this.my_user_id = localStorage.getItem("AY_LW");
    this.my_department_id = localStorage.getItem("chrome");
    this.roles = localStorage.getItem("Az07");

    if (this.$route.params.mail) {
      this.screenFreeze = true;
      this.loading = true;

      if (this.$route.params.type == "1") {
        this.to_test_passing_mail_type = 1;
        this.mailType = 1;
      }
      if (this.$route.params.type == "2") {
        this.to_test_passing_mail_type = 2;
        this.mailType = 2;
      }
      if (this.$route.params.type == "3") {
        this.to_test_passing_mail_type = 3;
        this.mailType = 3;
      }

      setTimeout(() => {
        this.mailId = this.$route.params.mail;
        this.GetSentMailById();
        this.GetAllDocN("next");

        this.sendButton = true;
        this.updataButton = true;
        this.deleteButton = true;
        this.saveButton = false;

        setTimeout(() => {
          this.screenFreeze = false;
          this.loading = false;
        }, 100);
      }, 500);
    } else {
      this.GetAllDepartments();
    }
    this.GetAllClassifications();
    this.GetAllMeasures();

    if (this.my_department_id == 21) {
      this.office_type = "1";
    }
    if (this.my_department_id == 22) {
      this.office_type = "3";
    }
  },

  data() {
    return {

      id_of_image_selected : '',
      selected_image:'',
      ordering_image_list: [],
      new_ordering_image_list: [],
      
      index_of_image_selected:'',
      image_ordering:'',
      id_image_ordering:'',


      image_rotate: true,
      doc_number_to_search: "",
      delete_all_documents: false,

      reply_id_to_delete: "",
      alert_delete_document: false,

      alert_state: false,
      alert_state_true_false: false,
      alert_prepare_delete_document: false,
      alert_prepare_delete_mail: false,
      //*************

      filter_text: "",
      mail_flag: "",
      keyid: "",
      conn: null,

      imagesscantest: [],
      indexOfimagesToShow1: 0,
      arimage: [],
      user11: [],

      //******************
      roles: [],
      show_images: false,

      from_reply_or_general: "",
      indexOfDepartment: "",
      allDepartment: false,
      allDepartmentButton: true,
      blblbl: [],
      to_test_print_images_model: false,
      show_images_model: false,

      testimage_images_model: "",
      indextotest_images_model: 0,

      show_images_images_model: [],

      replies: [],
      reply_to_add: "",
      sends_id: this.$route.params.sends_id,
      replyByDepartmenId: "",

      testimageToSend: "",
      indextotestToSend: 0,

      testimage: "",
      test_image_id: "",
      indextotest: 0,

      classifications: [],

      measures: [],
      measureselect: false,
      measureNameSelected: "",
      measureIdSelected: "",

      departments: [],
      departmentselect: false,
      departmentNameSelected: "",
      departmentIdSelected: "",
      departmentName: "",
      departmentflag: 0,

      consignees: [],
      consignees1: [],
      consigneesIncludesId: [],
      newactionSenders: [],
      newactionSendersIncludesId: [],

      releaseDate: "",
      summary: "",
      classification: "",
      mailType: "",
      general_incoming_number: "",
      genaral_inbox_year: "",
      required_action: "",

      mailId: "",
      external_mailId: "",

      saveButton: true,
      sendButton: false,
      updataButton: false,
      deleteButton: false,
      ButtonUploadImagesMail: false,

      mail_Number: "",
      department_Id: "",

      imagesToSend: [],
      indexOfimagesToShow: 0,

      my_user_id: "",
      my_department_id: "",

      action_required_by_the_entity: "",
      mail_forwarding: "",

      send_to_sector: "",

      sectors: [],
      sectorselect: false,
      sectorNameSelected: "",
      sectorIdSelected: "",

      sides: [],

      sideselect: false,
      sideNameSelected: "",
      sideIdSelected: "",

      send_to_side: "",

      entity_reference_number: "",
      procedure_type: 1,
      entity_mail_date: "",
      mail_ward_type: 1,
      ward_to: "",

      to_test_passing_mail_type: 1,
      remove_button_consignees: true,
      add_button_consignees: true,

      isThisMobile: false,

      send_to_sector_ward: "",

      side: 0,
      action: 0,

      mail_year: "",

      imagesToShow: [],

      showAlert: false,

      addErorr: null,

      documentSection: true,
      proceduresSection: false,

      marginalizedDocuments: [],

      this_value_to_solve_repetition_department: true,

      //
      //name: this.$authenticatedUser.name,
      // userName: this.$authenticatedUser.userName,
      // validity: this.$authenticatedUser.validity,

      loading: false,
      screenFreeze: false,

      doc_number: 0,
      total_of_doc: 0,

      image_of_doc: "",
      id_of_doc: "",
      image_to_print_n: [],

      image_to_print_n_model: false,
      show_current_image_for_bigger_screen_model: false,
      show_model_to_order_image: false,

      reply_doc_number: 0,
      reply_total_of_doc: 0,

      reply_image_of_doc: "",
      reply_id_of_doc: "",
      reply_image_to_print_n: [],

      reply_image_to_print_n_model: false,
      show_current_reply_image_to_for_bigger_screen_model: false,

      id_reply_image: "",

      is_exisite_genaral_inbox_number: true,
      old_mail_number: "",
      conclusion: "",

      office_type: "",

      sector_side_new_array_id: [],
      sector_side_new_array: [],
      sector_side_old_array: [],
      sector_side_old_array_id: [],

      sector_side_from_delet_fun: false,
    };
  },

  computed: {
    filterByTerm() {
      return this.sides.filter((side) => {
        return side.section_Name.toLowerCase().includes(this.sideNameSelected);
      });
    },

    filterByTerm1() {
      return this.departments.filter((department) => {
        return department.departmentName.includes(this.departmentNameSelected);
      });
    },
  },

  watch: {
    // filter_text: function() {

    //   this.action_required_by_the_entity=this.filter_text;

    //   this.sides.filter(function (n) {
    //             return n.section_Name.indexOf(this.filter_text) !== -1;
    //         });

    // },

    mailType: function () {
      var date = new Date();

      var month = date.getMonth() + 1;
      var day = date.getDate();

      if (month < 10) month = "0" + month;
      if (day < 10) day = "0" + day;

      this.releaseDate = date.getFullYear() + "-" + month + "-" + day;

      this.genaral_inbox_year = date.getFullYear();

      this.mail_flag = "";
      this.image_of_doc = "";
      this.image_to_print_n = [];
      this.indextotest_images_model = 0;
      this.show_images_images_model = [];
      this.mail_Number = "";
      this.summary = "";
      this.classification = "";
      this.general_incoming_number = "";
      this.required_action = "";
      this.mailId = "";
      this.mail_forwarding = "";

      this.old_mail_number = "";

      this.sideNameSelected = "";
      this.sideIdSelected = "";
      this.sectorNameSelected = "";
      this.sectorIdSelected = "";

      this.action_required_by_the_entity = "";
      this.mail_ward_type = 1;
      if (this.my_department_id == 21) {
        this.ward_to = 1;
      } else if (this.my_department_id == 22) {
        this.ward_to = 2;
      } else {
        this.ward_to = "";
      }

      this.entity_mail_date = "";
      this.entity_reference_number = "";
      this.procedure_type = 1;

      this.this_value_to_solve_repetition_department = true;

      this.consignees = [];
      this.consignees1 = [];
      this.consigneesIncludesId = [];
      this.newactionSenders = [];
      this.newactionSendersIncludesId = [];

      this.replies = [];
      this.imagesToShow = [];

      this.saveButton = true;
      this.sendButton = false;
      this.updataButton = false;
      this.deleteButton = false;
      this.ButtonUploadImagesMail = false;
      this.add_button_consignees = true;
      this.office_type = "";
      this.GetAllDepartments();

      if (this.my_department_id == 21) {
        this.office_type = "1";
      }
      if (this.my_department_id == 22) {
        this.office_type = "3";
      }

      this.sector_side_new_array = [];
      this.sector_side_new_array_id = [];

      this.sector_side_old_array = [];
      this.sector_side_old_array_id = [];

      setTimeout(() => {
        if (this.mailType == 2) {
          this.newactionSendersIncludesId = [];

          if (this.this_value_to_solve_repetition_department) {
            this.newactionSendersIncludesId = [];
            this.newactionSenders = [];
            for (let index = 0; index < this.departments.length; index++) {
              if (
                this.departments[index].departmentName.includes(
                  "مكتب رئيس الهيئة"
                )
              ) {
                this.newactionSenders.push({
                  departmentId: this.departments[index].id,
                  departmentName: this.departments[index].departmentName,
                  measureId: this.measures[0].measuresId,
                  measureName: this.measures[0].measuresName,
                });
                this.newactionSendersIncludesId.push(
                  this.departments[index].id
                );
                // this.departments.splice(index, 1);
              }

              if (
                this.departments[index].departmentName.includes("المحفوظات")
              ) {
                this.newactionSenders.push({
                  departmentId: this.departments[index].id,
                  departmentName: this.departments[index].departmentName,
                  measureId: this.measures[0].measuresId,
                  measureName: this.measures[0].measuresName,
                });
                this.newactionSendersIncludesId.push(
                  this.departments[index].id
                );
                // this.departments.splice(index, 1);
              }
            }
          }
        }
      }, 500);
    },
  },

  methods: {

    transfer_back_images_to_order(){

      if( this.selected_image != ''){

      for (let index = 0; index < this.new_ordering_image_list.length; index++) {
        const element = this.new_ordering_image_list[index];
        this.ordering_image_list.push(element)
        
      }
      this.new_ordering_image_list = []
      }
    },

    transfer_all_images_to_order(){

      if( this.selected_image != ''){

      for (let index = 0; index < this.ordering_image_list.length; index++) {
        const element = this.ordering_image_list[index];
        this.new_ordering_image_list.push(element)
        
      }
      this.ordering_image_list = []

      }
    },

    save_new_order(){

      this.transfer_all_images_to_order()

      this.screenFreeze = true;
        this.loading = true;


      this.$http.documentService
          .save_new_order(this.new_ordering_image_list)
          .then((res) => {
            // this.ordering_image_list = res.data
            console.log(res)
            this.show_model_to_order_image = false;

            this.new_ordering_image_list = []
            this.doc_number = 0;
            this.GetAllDocN("next");
            setTimeout(() => {
              this.screenFreeze = false;
        this.loading = false;
            }, 100);
   
          })
          .catch((err) => {
            this.screenFreeze = false;
        this.loading = false;
            console.log(err);
          });
    },

    transfer_image_to_order(){


      if( this.selected_image != ''){


      this.new_ordering_image_list.push(this.selected_image)

      const index = this.ordering_image_list.findIndex((element, index) => {
        if (
          element.id === this.selected_image.id &&
          element.order === this.selected_image.order
        ) {
          return true;
        }
      });
      this.ordering_image_list.splice(index, 1);

      }
    },


    transfer_back_image_to_order(){

 

      if( this.selected_image != ''){
        this.ordering_image_list.push(this.selected_image)

      const index = this.new_ordering_image_list.findIndex((element, index) => {
        if (
          element.id === this.selected_image.id &&
          element.order === this.selected_image.order
        ) {
          return true;
        }
      });
      this.new_ordering_image_list.splice(index, 1);
      }
      
    },

    open_model_to_order_image() {
     
     this.show_model_to_order_image = true;
     this.get_ordering_image();
    
    },




    select_image_to_ordering(n){

      
      this.selected_image = n
      this.index_of_image_selected = n.order
      this.id_of_image_selected = n.id

    },


    


    get_ordering_image() {
        this.$http.documentService
          .get_ordering_image(this.mailId)
          .then((res) => {
            this.ordering_image_list = res.data
   
          })
          .catch((err) => {
       
            console.log(err);
          });
    },



    
    show_image_to_ordering() {


      if( this.selected_image != ''){

    
    
        this.$http.documentService
          .show_doc_for_order(this.id_of_image_selected)
          .then((res) => {

            console.log(res)
            this.total_of_doc = res.data.total;

            this.image_ordering = res.data.data.path;
           this.id_image_ordering = res.data.data.id;

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





    add_sector_side_to_array() {
      // // sector_side

      //     // this.sector_side_new_array_id;
      //     this.sector_side_new_array.push(
      //       {
      //         side_number: this.sideIdSelected,
      //         side_name: this.sideNameSelected,
      //         sector_number: this.sectorIdSelected,
      //         sector_name: this.sectorNameSelected,
      //       }
      //     );

      //     this.sector_side_new_array_id.push(this.sideIdSelected)

      //     console.log(this.sector_side_new_array)
      //     // this.sector_side_new_array_id.push(this.departmentIdSelected);

      //     this.sideIdSelected = "";
      //     this.sideNameSelected = "";

      //     this.sectorIdSelected = "";
      //     this.sectorNameSelected = "";

      if (
        this.sector_side_new_array_id.includes(this.sideIdSelected) ||
        this.sector_side_old_array_id.includes(this.sideIdSelected)
      ) {
        alert("تم اضافة الجهة من قبل");
        this.sideIdSelected = "";
        this.sideNameSelected = "";
      } else {
        this.sector_side_new_array.push({
          mail_forwarding: Number(this.mail_forwarding),
          side_number: this.sideIdSelected,
          side_name: this.sideNameSelected,
          sector_number: this.sectorIdSelected,
          sector_name: this.sectorNameSelected,
        });
        this.sector_side_new_array_id.push(this.sideIdSelected);

        this.sideIdSelected = "";
        this.sideNameSelected = "";
      }

      // this.departments.splice(this.indexOfDepartment, 1);
    },

    delete_sector_side_from_array(id) {
      if (this.sector_side_old_array_id.length > 1) {
        this.screenFreeze = true;
        this.loading = true;

        this.sector_side_from_delet_fun = true;
        console.log(id);
        this.$http.mailService
          .cancel_sending_to_sector_side(
            id,
            Number(localStorage.getItem("AY_LW"))
          )
          .then((res) => {
            setTimeout(() => {
              this.loading = false;
              this.screenFreeze = false;

              this.GetSentMailById();
            }, 500);
          })
          .catch((err) => {
            setTimeout(() => {
              this.loading = false;
              this.screenFreeze = false;
            }, 500);
            alert("لا يمكن إلغاء الإدارة بعد القراءة");
          });
      } else {
        alert("لا يمكن حذف جميع الجهات");
      }
    },

    remove_sector_side_from_array(sideId, sideName, sectorId, sectorName) {
      console.log(this.sector_side_new_array_id.length);
      console.log(this.sector_side_old_array_id.length);

      console.log(
        this.sector_side_new_array_id.length +
          this.sector_side_old_array_id.length
      );
      console.log(
        this.sector_side_new_array_id.length +
          this.sector_side_old_array_id.length <
          1
      );

      // if (
      //   this.sector_side_new_array_id.length +
      //     this.sector_side_old_array_id.length >
      //   1
      // ) {
      const index = this.sector_side_new_array.findIndex((element, index) => {
        if (
          element.side_number === sideId &&
          element.sector_number === sectorId
        ) {
          return true;
        }
      });
      this.sector_side_new_array.splice(index, 1);

      const index_id = this.sector_side_new_array_id.findIndex(
        (element, index_id) => {
          if (element === sideId) {
            return true;
          }
        }
      );
      this.sector_side_new_array_id.splice(index_id, 1);
      // } else {
      //   alert("لا يمكن حذف جميع الجهات");
      // }

      // this.newactionSendersIncludesId.splice(index, 1);
    },

    pass_side(id, name) {
      // this.filter_text=name;
      this.sideNameSelected = name;
      this.sideIdSelected = id;
    },

    get_sides(sector, sector_name, id) {
      this.sideNameSelected = "";
      this.sideIdSelected = "";
      this.sides = [];
      this.sectorNameSelected = sector_name;
      this.sectorIdSelected = sector;
      this.$http.sectorsService
        .GetSides(sector)
        .then((res) => {
          this.sides = res.data;
        })
        .catch((err) => {
          console.log(err);
        });
    },

    farst_documents() {
      this.image_rotate = true;

      this.doc_number_to_search = 1;
      this.search_the_doc();
    },

    last_documents() {
      this.image_rotate = true;

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

    //************8/1/2023
    /*connect1(){
this.conn = new WebSocket("ws://localhost:58316/ws");
console.log("connect_fun_connect1");
},
async massage_on(){

  try
  {
  
  console.log("in massage_on");

  this.conn.onmessage = (event) => {
      console.log("WebSocket onmassage fun");
      let scannedImage = event.data;
      let mgs = JSON.parse(scannedImage);
      this.imagesscantest = mgs;
      var ind = this.imagesscantest.index;
       console.log("keyid_testttttt fun="+this.imagesscantest.keyid);
//console.log("WebSocket onmassage11111 fun");
      if (ind == 1) {
        this.keyid = this.imagesscantest.keyid;
        console.log("WebSocket ind =1 keyid fun="+this.keyid);
      } else {
        console.log("WebSocket onmassage else fun");
        var flag1 = this.imagesscantest.flag1;
        if (flag1 == 1) this.imagesToSend = [];
        for (var i = 0; i < mgs["image"].length; i++) {
          this.indexOfimagesToShow++;
          this.imagesToSend.push({
            baseAs64: mgs["image"][i],
            index: this.indexOfimagesToShow,
          });
        }

        if (flag1 == 1) {
          console.log("WebSocket uploadimage function fun");
          this.UploadImagesMail()};
      }

  
    };
}
catch (error)
{
  console.log("catch error");
}
},

  async  massage1(){

console.log("fun1");

    await this.connect1();
    await this.massage_on();
  
   console.log("fun2");



    },*/

    //**************end 8/1/2023

    // isExisiteGenaralInboxNumberFun() {
    //   this.screenFreeze = true;
    //   this.loading = true;

    //   this.$http.mailService
    //     .isExisiteGenaralInboxNumberFun(Number(this.general_incoming_number))
    //     .then((res) => {
    //       this.is_exisite_genaral_inbox_number = true;
    //       this.screenFreeze = false;
    //       this.loading = false;
    //     })
    //     .catch((err) => {
    //       this.is_exisite_genaral_inbox_number = false;
    //       this.screenFreeze = false;
    //       this.loading = false;
    //       alert("رقم الوارد العام موجود مسبقا.");
    //       this.addErorr = err.message;
    //     });
    // },

    deletereply() {
      this.alert_delete_document = false;

      this.$http.mailService
        .delete_reply(
          Number(this.reply_id_to_delete),
          Number(localStorage.getItem("AY_LW"))
        )
        .then((res) => {
          this.GetReplyByDepartment(
            this.replyByDepartmenId,
            this.sends_id,
            this.departmentName
          );
        })
        .catch((err) => {});
    },

    prepare_delete_all_documents() {
      this.delete_all_documents = true;

      this.alert_prepare_delete_document = true;
    },

    prepare_delete_document() {
      this.delete_all_documents = false;
      this.alert_prepare_delete_document = true;
    },

    prepare_delete_mail() {
      this.alert_prepare_delete_mail = true;
    },

    deleteAllDocuments() {
      this.alert_prepare_delete_document = false;

      this.$http.mailService
        .DeleteAllDocuments(
          Number(this.mailId),
          Number(localStorage.getItem("AY_LW"))
        )
        .then((res) => {
          this.doc_number = 0;
          this.total_of_doc = 0;

          this.image_of_doc = "";
          this.id_of_doc = "";

          this.alert_state = true;
          this.alert_state_true_false = true;

          // this.GetAllDocN("next");

          // this.imagesToShow.splice(index, 1);
          // this.mail_search();

          // this.imagesToShow = res.data.result.documents
        })
        .catch((err) => {
          this.alert_state = true;
          this.alert_state_true_false = false;
          this.addErorr = err.message;
        });
    },

    deleteDocument() {
      this.alert_prepare_delete_document = false;

      this.$http.mailService
        .DeleteDocument(
          Number(this.id_of_doc),
          Number(localStorage.getItem("AY_LW"))
        )
        .then((res) => {
          this.doc_number = 0;
          this.total_of_doc = 0;

          this.image_of_doc = "";
          this.id_of_doc = "";

          this.alert_state = true;
          this.alert_state_true_false = true;

          this.GetAllDocN("next");

          // this.imagesToShow.splice(index, 1);
          this.mail_search();

          // this.imagesToShow = res.data.result.documents
        })
        .catch((err) => {
          this.alert_state = true;
          this.alert_state_true_false = false;
          this.addErorr = err.message;
        });
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

    //*****************29/3/2022

    
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
      this.image_rotate = true;

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

    //*****************29/3/2022
    //  func() {
    // var link = document.getElementById("a1");

    //   var replyByDepartmenId = this.replyByDepartmenId;
    //   var sends_id = this.sends_id;
    //   var mailid = this.mailId;
    //   var keyid = this.keyid;

    //   var timeout;
    //   window.addEventListener("blur", function(e) {
    //     window.clearTimeout(timeout);
    //   });

    //   timeout = window.setTimeout(function() {
    //     window.location = "http://mail/scanner_app/Setup1.msi";
    //   }, 1000);

    //   link.href = "SScaner:flag=1" + "mId=" + mailid + "keyid=" + keyid;
    // },

    func() {
      if (this.conn == null) {
        console.log("conn=" + this.conn);
        this.conn = new WebSocket("ws://localhost:58316/ws");
        //  this.conn = new WebSocket("ws://mail:82/ws");

        this.conn.onclose = (event) => {
          console.log("close code_sent_form=" + event.code);
        };

        this.conn.onmessage = (event) => {
          console.log("onmessage");
          let scannedImage = event.data;
          let mgs = JSON.parse(scannedImage);
          this.imagesscantest = mgs;
          var ind = this.imagesscantest.index;
          console.log("index=" + ind);
          if (ind == 1) {
            this.keyid = this.imagesscantest.keyid;
            //   localStorage.setItem("keyid",this.keyid);
            console.log("keyid=" + this.keyid);
            console.log(
              "count websocket_ sent_form=" + this.imagesscantest.count1
            );
          } else {
            var flag1 = this.imagesscantest.flag1;
            if (flag1 == 1) {
              console.log("flag=" + flag1);
              this.imagesToSend = [];
            }
            for (var i = 0; i < mgs["image"].length; i++) {
              this.indexOfimagesToShow++;
              this.imagesToSend.push({
                baseAs64: mgs["image"][i],
                index: this.indexOfimagesToShow,
              });
            }

            if (flag1 == 1) {
              this.UploadImagesMail();
              console.log("uploadimagemail function");
            }
          }
        };
      } else if (this.conn.readyState === 3 || this.conn.readyState === 2) {
        console.log("readystate=" + this.conn.readyState);
        this.conn.close();
        this.conn = null;
        this.func();
      } else {
        console.log("func");
        var mailid = this.mailId;
        var keyid = this.keyid;

        var timeout;
        window.addEventListener("blur", function (e) {
          window.clearTimeout(timeout);
        });

        timeout = window.setTimeout(function () {
          window.location = "http://mail/scanner_app/Setup1.msi";
        }, 1000);

        document.location =
          "SScaner:flag=1" + "mId=" + mailid + "keyid=" + keyid;
      }

      //21/1/2023
      /* var link = document.getElementById("a1");

      var replyByDepartmenId = this.replyByDepartmenId;
      var sends_id = this.sends_id;
      var mailid = this.mailId;
      var keyid = this.keyid;

      var timeout;
      window.addEventListener("blur", function (e) {
        window.clearTimeout(timeout);
      });

      timeout = window.setTimeout(function () {
        window.location = "http://mail/scanner_app/Setup1.msi";
      }, 1000);

      link.href = "SScaner:flag=1" + "mId=" + mailid + "keyid=" + keyid;*/
      //end 21/1/2023
    },

    ////////////////////////////////////////////////////////////////////////////////////////////

    reply1() {
      /*     if(this.conn==null){
 console.log("conn="+this.conn);
      this.conn = new WebSocket("ws://localhost:58316/ws");
     //  this.conn = new WebSocket("ws://mail:94/ws");
    // localStorage.setItem("connect",this.conn);

this.conn.onclose=(event)=>{
console.log("close code="+event.code);
//this.conn.close();
}

//********
  this.conn.onmessage = (event) => {
      console.log("onmessage replay1");
      let scannedImage = event.data;

      let mgs = JSON.parse(scannedImage);
      this.imagesscantest = mgs;
      var ind = this.imagesscantest.index;
      console.log(" replay1 index="+ind);
      if (ind == 1) {
        this.keyid = this.imagesscantest.keyid;
        console.log("replay1 keyid=" + this.keyid);
      } else {
       
        console.log("replay1 else");
        for (var i = 0; i < mgs["image"].length; i++) {
          this.indexOfimagesToShow++;
          this.imagesToSend.push({
            baseAs64: mgs["image"][i],
            index: this.indexOfimagesToShow,
          });
        }
      }
    };
//*********

       }
  else if(this.conn.readyState===3||this.conn.readyState===2){
     console.log("readystate="+this.conn.readyState)
     this.conn.close();
     this.conn=null;
     this.reply1();
     }
      else {

      var replyByDepartmenId = this.replyByDepartmenId;
      var sends_id = this.sends_id;
      var mailId = this.mailId;
      var keyid = this.keyid;

      var timeout;
      window.addEventListener("blur", function (e) {
        window.clearTimeout(timeout);
      });

      timeout = window.setTimeout(function () {
        window.location = "http://mail/scanner_app/Setup1.msi";
      }, 1000);

      document.location=
        "SScaner:flag=0" +
        "userId=" +
        localStorage.getItem("AY_LW") +
        "mId=" +
        mailId +
        "send_ToId=" +
        sends_id +
        "to=" +
        replyByDepartmenId +
        "keyid=" +
        keyid;

            }*/
      //********21/1/2023
      /* var link = document.getElementById("a2");

      var replyByDepartmenId = this.replyByDepartmenId;
      var sends_id = this.sends_id;
      var mailId = this.mailId;
      var keyid = this.keyid;

      var timeout;
      window.addEventListener("blur", function (e) {
        window.clearTimeout(timeout);
      });

      timeout = window.setTimeout(function () {
        window.location = "http://mail/scanner_app/Setup1.msi";
      }, 1000);

      link.href =
        "SScaner:flag=0" +
        "userId=" +
        localStorage.getItem("AY_LW") +
        "mId=" +
        mailId +
        "send_ToId=" +
        sends_id +
        "to=" +
        replyByDepartmenId +
        "keyid=" +
        keyid;*/
      //********21/1/2023
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

    print_reply_image() {
      this.reply_image_to_print_n_model = true;

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

    clear_page() {
      this.screenFreeze = true;
      this.loading = true;

      this.sideNameSelected = "";
      this.sideIdSelected = "";
      this.sectorIdSelected = "";
      this.sectorNameSelected = "";
      this.sectors = [];
      this.sides = [];

      this.consignees = [];
      this.consignees1 = [];
      this.consigneesIncludesId = [];
      this.newactionSendersIncludesId = [];

      this.newactionSenders = [];

      this.show_images = false;
      this.departmentNameSelected = "";
      this.measureNameSelected = "";
      this.old_mail_number = "";
      this.conclusion = "";
      this.doc_number = 0;
      this.total_of_doc = 0;

      this.image_of_doc = "";
      this.id_of_doc = "";

      this.office_type = "";

      var date = new Date();

      var month = date.getMonth() + 1;
      var day = date.getDate();

      if (month < 10) month = "0" + month;
      if (day < 10) day = "0" + day;

      this.releaseDate = date.getFullYear() + "-" + month + "-" + day;

      this.mail_year = date.getFullYear();

      if (this.mailType == 1) {
        this.mailType = "";
        setTimeout(() => {
          this.mailType = 1;
        }, 100);
      }
      if (this.mailType == 2) {
        this.mailType = "";

        setTimeout(() => {
          this.mailType = 2;
        }, 100);
      }
      if (this.mailType == 3) {
        this.mailType = "";

        setTimeout(() => {
          this.mailType = 3;
        }, 100);
      }
      this.saveButton = true;
      this.sendButton = false;
      this.updataButton = false;
      this.deleteButton = false;
      this.ButtonUploadImagesMail = false;
      this.mail_flag = 0;

      setTimeout(() => {
        this.screenFreeze = false;
        this.loading = false;
      }, 300);
    },

    selectAllDepartment(x, name) {
      this.departmentNameSelected = name;

      this.allDepartment = true;
      this.blblbl = x;
    },

    add_to_array_of_side_measure() {
      // consigneesIncludesId

      if (this.allDepartment) {
        for (let index = 0; index < this.blblbl.length; index++) {
          if (
            this.newactionSendersIncludesId.includes(this.blblbl[index].id) ||
            this.consigneesIncludesId.includes(this.blblbl[index].id)
          ) {
          } else {
            this.newactionSenders.push({
              departmentId: this.blblbl[index].id,
              departmentName: this.blblbl[index].departmentName,
              measureId: this.measureIdSelected,
              measureName: this.measureNameSelected,
            });
            this.newactionSendersIncludesId.push(this.blblbl[index].id);
          }
        }

        this.departmentNameSelected = "";
        this.departmentIdSelected = "";

        this.measureIdSelected = "";
        this.measureNameSelected = "";

        // this.departments = [];
        this.allDepartmentButton = false;
      } else {
        // array.includes('🍰');

        if (
          this.newactionSendersIncludesId.includes(this.departmentIdSelected) ||
          this.consigneesIncludesId.includes(this.departmentIdSelected)
        ) {
          alert("تم اضافة الادارة من قبل");
          this.departmentNameSelected = "";
          this.departmentIdSelected = "";

          this.measureIdSelected = "";
          this.measureNameSelected = "";
        } else {
          this.newactionSendersIncludesId;
          this.newactionSenders.push({
            departmentId: this.departmentIdSelected,
            departmentName: this.departmentNameSelected,
            measureId: this.measureIdSelected,
            measureName: this.measureNameSelected,
          });
          this.newactionSendersIncludesId.push(this.departmentIdSelected);

          this.departmentNameSelected = "";
          this.departmentIdSelected = "";

          this.measureIdSelected = "";
          this.measureNameSelected = "";
        }

        // this.departments.splice(this.indexOfDepartment, 1);
      }
    },

    remove_to_array_of_side_measure(consignee, name) {
      if (this.mail_Number) {
        const index = this.newactionSenders.findIndex((element, index) => {
          if (element.departmentId === consignee) {
            return true;
          }
        });
        this.newactionSenders.splice(index, 1);
        this.newactionSendersIncludesId.splice(index, 1);
      } else {
        const index = this.newactionSenders.findIndex((element, index) => {
          if (element.departmentId === consignee) {
            return true;
          }
        });
        this.newactionSenders.splice(index, 1);
        this.newactionSendersIncludesId.splice(index, 1);
      }

      // this.departments.push({
      //   id: consignee,
      //   departmentName: name,
      // });

      this.allDepartmentButton = true;
    },

    delete_side_measure(department_id, name) {
      this.screenFreeze = true;
      this.loading = true;

      this.$http.mailService
        .cancel_sending_to_department(
          this.mailId,
          department_id,
          Number(localStorage.getItem("AY_LW"))
        )
        .then((res) => {
          setTimeout(() => {
            this.loading = false;
            this.screenFreeze = false;
            // this.consignees = res.data.actionSenders
            this.GetSentMailById();
            // const index = this.consignees.findIndex((element, index) => {
            //   if (element.departmentId === department_id) {
            //     return true;
            //   }
            // });
            // this.consignees.splice(index, 1);
          }, 500);
        })
        .catch((err) => {
          setTimeout(() => {
            this.loading = false;
            this.screenFreeze = false;
          }, 500);
          alert("لا يمكن إلغاء الإدارة بعد القراءة");
        });
    },

    mail_search() {
      this.screenFreeze = true;
      this.loading = true;

      this.consignees = [];
      this.consignees1 = [];
      this.consigneesIncludesId = [];
      this.newactionSenders = [];
      this.newactionSendersIncludesId = [];

      this.sector_side_new_array = [];
      this.sector_side_new_array_id = [];

      this.doc_number = 0;
      this.total_of_doc = 0;

      this.image_of_doc = "";
      this.id_of_doc = "";

      this.mail_flag = 0;

      this.office_type = "";

      this.old_mail_number = "";

      var date = new Date();

      var month = date.getMonth() + 1;
      var day = date.getDate();

      if (month < 10) month = "0" + month;
      if (day < 10) day = "0" + day;

      this.releaseDate = date.getFullYear() + "-" + month + "-" + day;

      this.GetAllDepartments;
      this.$http.mailService
        .search(
          this.mail_Number,
          this.mailType,
          this.my_department_id,
          this.mail_year
        )
        .then((res) => {
          if (res.data.mail.is_send == true) {
            this.saveButton = false;
            this.updataButton = true;
            this.deleteButton = false;
            this.sendButton = false;
            this.add_button_consignees = true;

            this.remove_button_consignees = false;
          } else {
            this.deleteButton = true;
            this.updataButton = true;
            this.saveButton = false;
            this.sendButton = true;
          }

          this.mailId = res.data.mail.mailID;
          // this.to_get_all_doc_of_mail();
          this.mail_Number = res.data.mail.mail_Number;
          this.department_Id = res.data.mail.department_Id;
          this.mail_year = res.data.mail.mail_year;

          this.releaseDate = res.data.mail.date_Of_Mail;
          this.summary = res.data.mail.mail_Summary;
          this.classification = res.data.mail.clasification;

          this.new_class =
            this.classifications[Number(this.classification) - 1].name;
          this.office_type = res.data.mail.office_type;
          // this.mailType = res.data.mail.mail_Type;
          if (res.data.mail.genaral_inbox_Number == 0) {
            this.general_incoming_number = "";
          } else {
            this.general_incoming_number = res.data.mail.genaral_inbox_Number;
          }

          this.genaral_inbox_year = res.data.mail.genaral_inbox_year;
          this.required_action = res.data.mail.action_Required;

          this.mail_flag = res.data.mail.flag;

          this.consignees = res.data.actionSenders;
          this.consignees1 = res.data.actionSenders;
          this.old_mail_number = res.data.mail.old_mail_number;

          // for (let index = 0; index < res.data.actionSenders.length; index++) {
          //   this.newactionSendersIncludesId.push(
          //     res.data.actionSenders[index].departmentId
          //   );
          // }

          for (let index = 0; index < res.data.actionSenders.length; index++) {
            this.consigneesIncludesId.push(
              res.data.actionSenders[index].departmentId
            );
          }

          if (this.mailType == "2") {
            this.external_mailId = res.data.external.id;

            this.action_required_by_the_entity =
              res.data.external.action_required_by_the_entity;

            this.sector_side_old_array = res.data.external_sectoin;

            for (
              let index = 0;
              index < res.data.external_sectoin.length;
              index++
            ) {
              this.sector_side_old_array_id.push(
                res.data.external_sectoin[index].side_number
              );
            }

            // this.external_mailId = res.data.external.id;

            // this.action_required_by_the_entity =
            //   res.data.external.action_required_by_the_entity;

            // this.sector_side_old_array = res.data.external_sectoin;

            // for (
            //   let index = 0;
            //   index < res.data.sector_side_old_array.length;
            //   index++
            // ) {
            //   this.sector_side_old_array_id.push(
            //     res.data.sector_side_old_array[index].side_number
            //   );
            // }

            // this.get_sectors(this.mail_forwarding);

            // this.sectorNameSelected = res.data.sector[0].section_Name;
            // this.sectorIdSelected = res.data.sector[0].id;

            // this.get_sides(this.sectorIdSelected, this.sectorNameSelected);
            // this.sideNameSelected = res.data.side[0].section_Name;
            // this.sideIdSelected = res.data.side[0].id;
          }
          if (this.mailType == "3") {
            this.external_mailId = res.data.external.id;

            this.sector_side_old_array = res.data.external_sectoin;

            for (
              let index = 0;
              index < res.data.external_sectoin.length;
              index++
            ) {
              this.sector_side_old_array_id.push(
                res.data.external_sectoin[index].side_number
              );
            }

            // this.get_sectors(this.mail_forwarding);

            // this.sectorNameSelected = res.data.sector[0].section_Name;
            // this.sectorIdSelected = res.data.sector[0].id;

            // this.get_sides(this.sectorIdSelected, this.sectorNameSelected);
            // this.sideNameSelected = res.data.side[0].section_Name;
            // this.sideIdSelected = res.data.side[0].id;

            this.ward_to = res.data.external.to;

            this.mail_ward_type = res.data.external.type;

            this.entity_mail_date = res.data.external.send_time;

            this.entity_reference_number =
              res.data.external.entity_reference_number;

            this.procedure_type = res.data.external.procedure_type;

            // this.external_mailId = res.data.external.id;

            // this.sector_side_old_array = res.data.external_sectoin;

            // for (
            //   let index = 0;
            //   index < res.data.sector_side_old_array.length;
            //   index++
            // ) {
            //   this.sector_side_old_array_id.push(
            //     res.data.sector_side_old_array[index].side_number
            //   );
            // }

            // // this.get_sectors(this.mail_forwarding);

            // // this.sectorNameSelected = res.data.sector[0].section_Name;
            // // this.sectorIdSelected = res.data.sector[0].id;

            // // this.get_sides(this.sectorIdSelected, this.sectorNameSelected);
            // // this.sideNameSelected = res.data.side[0].section_Name;
            // // this.sideIdSelected = res.data.side[0].id;

            // this.ward_to = res.data.external.to;

            // this.mail_ward_type = res.data.external.type;

            // this.entity_mail_date = res.data.external.send_time;

            // this.entity_reference_number =
            //   res.data.external.entity_reference_number;

            // this.procedure_type = res.data.external.procedure_type;
          }

          setTimeout(() => {
            this.GetAllDocN("next");
            this.screenFreeze = false;
            this.loading = false;
          }, 300);
        })
        .catch((err) => {
          setTimeout(() => {
            this.screenFreeze = false;
            this.loading = false;
            this.clear_page();

            alert("لا يوحد بريد بهذا الرقم.");
            console.log(err);
          }, 100);
        });
    },

    AddReply() {
      this.screenFreeze = true;
      this.loading = true;

      var ReplyViewModel = {
        userId: Number(localStorage.getItem("AY_LW")),
        mailId: Number(this.mailId),
        send_ToId: Number(this.sends_id),
        from: Number(1),
        reply: {
          mail_detail: this.reply_to_add,
          To: Number(this.replyByDepartmenId),
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
            this.GetReplyByDepartment(
              this.replyByDepartmenId,
              this.sends_id,
              this.departmentName
            );
          }, 500);
        })
        .catch((err) => {
          setTimeout(() => {
            this.loading = false;
            this.screenFreeze = false;
          }, 500);
        });
    },

    GetReplyByDepartment(id, send_ToId, name, flag) {
      this.reply_to_add = "";
      this.imagesToSend = [];

      this.departmentflag = 0;
      this.replyByDepartmenId = id;
      this.sends_id = send_ToId;
      this.departmentName = name;
      this.departmentflag = flag;

      this.$http.mailService
        .GetReplyByDepartment(this.replyByDepartmenId, this.mailId)
        .then((res) => {
          this.replies = res.data.list;
        })
        .catch((err) => {
          console.log(err);
        });
    },

    previousImage() {
      if (this.indextotest > 0) {
        this.indextotest--;
        this.testimage = this.imagesToShow[this.indextotest].path;
        this.test_image_id = this.imagesToShow[this.indextotest].id;
      }
    },

    nextImage() {
      if (this.indextotest < this.imagesToShow.length - 1) {
        this.indextotest++;
        this.testimage = this.imagesToShow[this.indextotest].path;
        this.test_image_id = this.imagesToShow[this.indextotest].id;
      }
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

          this.test_image_id = this.show_images_images_model[0].id;

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

    get_sectors(type) {
      this.sideNameSelected = "";
      this.sideIdSelected = "";
      this.sectorIdSelected = "";
      this.sectorNameSelected = "";
      this.sectors = [];
      this.sides = [];

      this.$http.sectorsService
        .GetSectors(type)
        .then((res) => {
          this.sectors = res.data;
        })
        .catch((err) => {
          console.log(err);
        });
    },

    selectmeasure(id, name) {
      this.measureNameSelected = name;
      this.measureIdSelected = id;
    },

    selectdepartment(id, name, index) {
      this.allDepartment = false;
      this.departmentNameSelected = name;
      this.departmentIdSelected = id;

      this.indexOfDepartment = index;
    },

    GetAllClassifications() {
      this.$http.mailService
        .AllClassifications()
        .then((res) => {
          this.classifications = res.data;
        })
        .catch((err) => {
          console.log(err);
        });
    },

    GetAllMeasures() {
      this.$http.mailService
        .AllMeasures()
        .then((res) => {
          this.measures = res.data;
        })
        .catch((err) => {
          console.log(err);
        });
    },

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

    updateMail() {
      this.screenFreeze = true;
      this.loading = true;

      this.doc_number = 0;

      if (this.mailType == "1") {
        var dataUpdate = {
          userId: Number(localStorage.getItem("AY_LW")),
          mail: {
            MailID: Number(this.mailId),
            Mail_Type: Number(this.mailType),
            userId: Number(this.my_user_id),
            department_Id: Number(this.my_department_id),
            Date_Of_Mail: this.releaseDate,
            Mail_Summary: this.summary,
            clasification: Number(this.classification),
            Genaral_inbox_Number: Number(this.general_incoming_number),
            Genaral_inbox_year: Number(this.genaral_inbox_year),
            ActionRequired: this.required_action,
            old_mail_number: this.old_mail_number,
            state: true,
            office_type: this.office_type,
          },

          // actionSenders: this.consignees,
          newactionSenders: this.newactionSenders,
        };
      }

      if (this.mailType == "2") {
        var dataUpdate = {
          userId: Number(localStorage.getItem("AY_LW")),
          mail: {
            MailID: Number(this.mailId),
            Mail_Type: Number(this.mailType),
            userId: Number(this.my_user_id),
            department_Id: Number(this.my_department_id),
            Date_Of_Mail: this.releaseDate,
            Mail_Summary: this.summary,
            clasification: Number(this.classification),
            Genaral_inbox_Number: Number(this.general_incoming_number),
            Genaral_inbox_year: Number(this.genaral_inbox_year),
            ActionRequired: this.required_action,
            old_mail_number: this.old_mail_number,
            state: true,
            office_type: this.office_type,
          },

          // actionSenders: this.consignees,
          newactionSenders: this.newactionSenders,

          external_Mail: {
            id: Number(this.external_mailId),
            action: Number(this.mail_forwarding),

            action_required_by_the_entity: this.action_required_by_the_entity,
          },

          external_sectoin: this.sector_side_new_array,
        };
      }

      if (this.mailType == "3") {
        var dataUpdate = {
          userId: Number(localStorage.getItem("AY_LW")),
          mail: {
            MailID: Number(this.mailId),
            Mail_Type: Number(this.mailType),
            userId: Number(this.my_user_id),
            department_Id: Number(this.my_department_id),
            Date_Of_Mail: this.releaseDate,
            Mail_Summary: this.summary,
            clasification: Number(this.classification),
            Genaral_inbox_Number: Number(this.general_incoming_number),
            Genaral_inbox_year: Number(this.genaral_inbox_year),
            ActionRequired: this.required_action,
            old_mail_number: this.old_mail_number,
            state: true,
            office_type: this.office_type,
          },

          // actionSenders: this.consignees,
          newactionSenders: this.newactionSenders,

          extrenal_Inbox: {
            Id: Number(this.external_mailId),
            action: Number(this.mail_forwarding),

            to: Number(this.ward_to),
            type: Number(this.mail_ward_type),
            Send_time: this.entity_mail_date,
            entity_reference_number: Number(this.entity_reference_number),
            procedure_type: Number(this.procedure_type),
          },

          external_sectoin: this.sector_side_new_array,
        };
      }

      this.$http.mailService
        .UpdateMail(dataUpdate)
        .then((res) => {
          this.newactionSenders = [];
          this.sector_side_new_array = [];
          this.sector_side_new_array_id = "";
          this.newactionSendersIncludesId = [];

          if (this.mailType == 1) {
            this.to_test_passing_mail_type = 1;
          }
          if (this.mailType == 2) {
            this.to_test_passing_mail_type = 2;
          }
          if (this.mailType == 3) {
            this.to_test_passing_mail_type = 3;
          }

          setTimeout(() => {
            this.loading = false;
            this.screenFreeze = false;

            this.GetSentMailById();
            this.GetAllDocN("next");
          }, 500);
        })
        .catch((err) => {
          setTimeout(() => {
            this.loading = false;
            this.screenFreeze = false;
          }, 500);
        });
    },

    saveMail() {
      this.screenFreeze = true;
      this.loading = true;

      if (this.mailType == "1") {
        var info = {
          mail: {
            Mail_Type: Number(this.mailType),
            userId: Number(this.my_user_id),
            department_Id: Number(this.my_department_id),
            Date_Of_Mail: this.releaseDate,
            Mail_Summary: this.summary,
            clasification: Number(this.classification),
            Genaral_inbox_Number: Number(this.general_incoming_number),
            Genaral_inbox_year: Number(this.genaral_inbox_year),
            old_mail_number: this.old_mail_number,
            ActionRequired: this.required_action,
            office_type: this.office_type,
          },

          actionSenders: this.newactionSenders,
        };
      }

      if (this.mailType == "2") {
        var info = {
          mail: {
            Mail_Type: Number(this.mailType),
            userId: Number(this.my_user_id),
            department_Id: Number(this.my_department_id),
            Date_Of_Mail: this.releaseDate,
            Mail_Summary: this.summary,
            clasification: Number(this.classification),
            Genaral_inbox_Number: Number(this.general_incoming_number),
            Genaral_inbox_year: Number(this.genaral_inbox_year),
            old_mail_number: this.old_mail_number,
            ActionRequired: this.required_action,
            office_type: this.office_type,
          },

          actionSenders: this.newactionSenders,

          external_Mail: {
            action: Number(this.mail_forwarding),

            action_required_by_the_entity: this.action_required_by_the_entity,
          },

          external_sectoin: this.sector_side_new_array,
        };
      }

      if (this.mailType == "3") {
        var info = {
          mail: {
            Mail_Type: Number(this.mailType),
            userId: Number(this.my_user_id),
            department_Id: Number(this.my_department_id),
            Date_Of_Mail: this.releaseDate,
            Mail_Summary: this.summary,
            clasification: Number(this.classification),
            Genaral_inbox_Number: Number(this.general_incoming_number),
            Genaral_inbox_year: Number(this.genaral_inbox_year),
            old_mail_number: this.old_mail_number,
            ActionRequired: this.required_action,
            office_type: this.office_type,
          },

          actionSenders: this.newactionSenders,

          extrenal_Inbox: {
            action: Number(this.mail_forwarding),

            to: Number(this.ward_to),
            type: Number(this.mail_ward_type),
            Send_time: this.entity_mail_date,
            entity_reference_number: Number(this.entity_reference_number),
            procedure_type: Number(this.procedure_type),
          },

          external_sectoin: this.sector_side_new_array,
        };
      }

      this.$http.mailService
        .SaveMail(info)
        .then((res) => {
          setTimeout(() => {
            // this.loading = false;

            // this.documentSection = true;
            // this.proceduresSection = true;

            this.loading = false;
            this.screenFreeze = false;

            this.saveButton = false;
            this.sendButton = true;
            this.updataButton = true;
            this.deleteButton = true;

            this.mail_Number = res.data.mail_Number;

            this.mailId = res.data.mailId;
            this.department_Id = res.data.department_Id;
            this.mail_year = res.data.mail_year;
            this.to_test_passing_mail_type = this.mailType;

            this.GetSentMailById();
          }, 500);
        })
        .catch((err) => {
          setTimeout(() => {
            this.loading = false;
            this.screenFreeze = false;
          }, 500);
        });
    },

    GetSentMailById() {
      this.this_value_to_solve_repetition_department = false;

      this.newactionSenders = [];
      this.newactionSendersIncludesId = [];
      this.doc_number = 0;

      if (!this.sector_side_from_delet_fun) {
        this.sector_side_new_array = [];
        this.sector_side_new_array_id = [];
      }

      this.sector_side_old_array = [];
      this.sector_side_old_array_id = [];

      this.screenFreeze = true;
      this.loading = true;

      this.$http.mailService
        .GetSentMailById(this.mailId, this.mailType)
        .then((res) => {
          // this.mailType = res.data.mail.mail_Type;
          if (res.data.mail.is_send == true) {
            this.sendButton = false;
            this.deleteButton = false;
            // this.add_button_consignees = false;
          }

          // this.sector_side_old_array = res.data.external_sectoin

          this.summary = res.data.mail.mail_Summary;

          this.remove_button_consignees = false;

          this.mail_Number = res.data.mail.mail_Number;
          this.department_Id = res.data.mail.department_Id;
          this.mail_year = res.data.mail.mail_year;
          this.mail_flag = res.data.mail.flag;

          this.releaseDate = res.data.mail.date_Of_Mail;
          this.classification = res.data.mail.clasification;
          this.new_class =
            this.classifications[Number(this.classification) - 1].name;
          this.office_type = res.data.mail.office_type;

          if (res.data.mail.genaral_inbox_Number == 0) {
            this.general_incoming_number = "";
          } else {
            this.general_incoming_number = res.data.mail.genaral_inbox_Number;
          }

          this.genaral_inbox_year = res.data.mail.genaral_inbox_year;
          this.required_action = res.data.mail.action_Required;
          this.consignees = res.data.actionSenders;
          this.consignees1 = res.data.actionSenders;
          this.old_mail_number = res.data.mail.old_mail_number;

          // this.newactionSendersIncludesId = [];

          // for (let index = 0; index < res.data.actionSenders.length; index++) {
          //   this.newactionSendersIncludesId.push(
          //     res.data.actionSenders[index].departmentId
          //   );
          // }

          this.consigneesIncludesId = [];

          for (let index = 0; index < res.data.actionSenders.length; index++) {
            this.consigneesIncludesId.push(
              res.data.actionSenders[index].departmentId
            );
          }

          // this.departments = res.data.departments;

          if (res.data.mail.mail_Type == 1) {
            this.GetAllDepartments();
          }

          if (this.to_test_passing_mail_type == "2") {
            this.external_mailId = res.data.external.id;

            this.action_required_by_the_entity =
              res.data.external.action_required_by_the_entity;

            this.sector_side_old_array = res.data.external_sectoin;

            for (
              let index = 0;
              index < res.data.external_sectoin.length;
              index++
            ) {
              this.sector_side_old_array_id.push(
                res.data.external_sectoin[index].side_number
              );
            }

            // this.get_sectors(this.mail_forwarding);

            // this.sectorNameSelected = res.data.sector[0].section_Name;
            // this.sectorIdSelected = res.data.sector[0].id;

            // this.get_sides(this.sectorIdSelected, this.sectorNameSelected);
            // this.sideNameSelected = res.data.side[0].section_Name;
            // this.sideIdSelected = res.data.side[0].id;
          }
          if (this.to_test_passing_mail_type == "3") {
            this.external_mailId = res.data.external.id;

            this.sector_side_old_array = res.data.external_sectoin;

            for (
              let index = 0;
              index < res.data.external_sectoin.length;
              index++
            ) {
              this.sector_side_old_array_id.push(
                res.data.external_sectoin[index].side_number
              );
            }

            // this.get_sectors(this.mail_forwarding);

            // this.sectorNameSelected = res.data.sector[0].section_Name;
            // this.sectorIdSelected = res.data.sector[0].id;

            // this.get_sides(this.sectorIdSelected, this.sectorNameSelected);
            // this.sideNameSelected = res.data.side[0].section_Name;
            // this.sideIdSelected = res.data.side[0].id;

            this.ward_to = res.data.external.to;

            this.mail_ward_type = res.data.external.type;

            this.entity_mail_date = res.data.external.send_time;

            this.entity_reference_number =
              res.data.external.entity_reference_number;

            this.procedure_type = res.data.external.procedure_type;
          }

          // this.to_get_all_doc_of_mail();

          // this.GetDocmentForMail();
          // this.GetDocmentForMailToShow();

          // this.GetProcessingResponses();

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

    updateBeforSendMail() {
      this.screenFreeze = true;
      this.loading = true;

      this.doc_number = 0;

      if (this.mailType == "1") {
        var dataUpdate = {
          userId: Number(localStorage.getItem("AY_LW")),
          mail: {
            MailID: Number(this.mailId),
            Mail_Type: Number(this.mailType),
            userId: Number(this.my_user_id),
            department_Id: Number(this.my_department_id),
            Date_Of_Mail: this.releaseDate,
            Mail_Summary: this.summary,
            clasification: Number(this.classification),
            Genaral_inbox_Number: Number(this.general_incoming_number),
            Genaral_inbox_year: Number(this.genaral_inbox_year),
            ActionRequired: this.required_action,
            old_mail_number: this.old_mail_number,
            state: true,
            office_type: this.office_type,
          },

          // actionSenders: this.consignees,
          newactionSenders: this.newactionSenders,
        };
      }

      if (this.mailType == "2") {
        var dataUpdate = {
          userId: Number(localStorage.getItem("AY_LW")),
          mail: {
            MailID: Number(this.mailId),
            Mail_Type: Number(this.mailType),
            userId: Number(this.my_user_id),
            department_Id: Number(this.my_department_id),
            Date_Of_Mail: this.releaseDate,
            Mail_Summary: this.summary,
            clasification: Number(this.classification),
            Genaral_inbox_Number: Number(this.general_incoming_number),
            Genaral_inbox_year: Number(this.genaral_inbox_year),
            ActionRequired: this.required_action,
            old_mail_number: this.old_mail_number,
            state: true,
            office_type: this.office_type,
          },

          // actionSenders: this.consignees,
          newactionSenders: this.newactionSenders,

          external_Mail: {
            id: Number(this.external_mailId),
            action: Number(this.mail_forwarding),

            action_required_by_the_entity: this.action_required_by_the_entity,
          },

          external_sectoin: this.sector_side_new_array,
        };
      }

      if (this.mailType == "3") {
        var dataUpdate = {
          userId: Number(localStorage.getItem("AY_LW")),
          mail: {
            MailID: Number(this.mailId),
            Mail_Type: Number(this.mailType),
            userId: Number(this.my_user_id),
            department_Id: Number(this.my_department_id),
            Date_Of_Mail: this.releaseDate,
            Mail_Summary: this.summary,
            clasification: Number(this.classification),
            Genaral_inbox_Number: Number(this.general_incoming_number),
            Genaral_inbox_year: Number(this.genaral_inbox_year),
            ActionRequired: this.required_action,
            old_mail_number: this.old_mail_number,
            state: true,
            office_type: this.office_type,
          },

          // actionSenders: this.consignees,
          newactionSenders: this.newactionSenders,

          extrenal_Inbox: {
            Id: Number(this.external_mailId),
            action: Number(this.mail_forwarding),

            to: Number(this.ward_to),
            type: Number(this.mail_ward_type),
            Send_time: this.entity_mail_date,
            entity_reference_number: Number(this.entity_reference_number),
            procedure_type: Number(this.procedure_type),
          },

          external_sectoin: this.sector_side_new_array,
        };
      }

      this.$http.mailService
        .UpdateMail(dataUpdate)
        .then((res) => {
          this.newactionSenders = [];
          this.newactionSendersIncludesId = [];

          if (this.mailType == 1) {
            this.to_test_passing_mail_type = 1;
          }
          if (this.mailType == 2) {
            this.to_test_passing_mail_type = 2;
          }
          if (this.mailType == 3) {
            this.to_test_passing_mail_type = 3;
          }

          this.sendMail();

          setTimeout(() => {
            this.loading = false;
            this.screenFreeze = false;

            this.GetSentMailById();
            this.GetAllDocN("next");
          }, 500);
        })
        .catch((err) => {
          setTimeout(() => {
            this.loading = false;
            this.screenFreeze = false;
          }, 500);
        });
    },

    scanToJpg() {
      scanner.scan(this.displayImagesOnPage, {
        output_settings: [
          {
            type: "return-base64",
            format: "jpg",
          },
        ],
      });
    },

    sendMail() {
      this.screenFreeze = true;
      this.loading = true;

      // this.updateMail();

      this.$http.mailService
        .SendMail(Number(this.mailId), Number(localStorage.getItem("AY_LW")))
        .then((res) => {
          setTimeout(() => {
            this.deleteButton = false;
            this.sendButton = false;

            this.loading = false;
            this.screenFreeze = false;
          }, 500);
        })
        .catch((err) => {
          setTimeout(() => {
            this.loading = false;
            this.screenFreeze = false;
          }, 500);
        });
    },

    deleteMail() {
      this.screenFreeze = true;
      this.loading = true;
      this.alert_prepare_delete_mail = false;

      this.$http.mailService
        .DeleteMail(this.my_department_id, this.my_user_id, this.mailId)
        .then((res) => {
          setTimeout(() => {
            this.loading = false;
            this.screenFreeze = false;

            this.clear_page();
            // this.$router.replace("/sent");
          }, 500);
        })
        .catch((err) => {
          setTimeout(() => {
            this.loading = false;
            this.screenFreeze = false;
          }, 500);
        });
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
        return;
      }

      if (
        successful &&
        mesg != null &&
        mesg.toLowerCase().indexOf("user cancel") >= 0
      ) {
        // User cancelled.
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

    displayImagesOnPage(successful, mesg, response) {
      if (!successful) {
        // On error
        return;
      }

      if (
        successful &&
        mesg != null &&
        mesg.toLowerCase().indexOf("user cancel") >= 0
      ) {
        // User cancelled.
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

      this.UploadImagesMail();

      if (this.mailType == 1) {
        this.to_test_passing_mail_type = 1;
      }
      if (this.mailType == 2) {
        this.to_test_passing_mail_type = 2;
      }
      if (this.mailType == 3) {
        this.to_test_passing_mail_type = 3;
      }

      setTimeout(() => {
        this.GetSentMailById();
        this.GetAllDocN("next");
      }, 1000);
    },

    ImagetoPrint(img) {
      return (
        "<html><head><scri" +
        "pt>function step1(){\n" +
        "setTimeout('step2()', 10);}\n" +
        "function step2(){window.print();window.close()}\n" +
        "</scri" +
        "pt></head><body onload='step1()'>\n" +
        "<img  style='padding:0; width: 100%; size:A4; margin:0;' src='" +
        img +
        "' /></body></html>"
      );
    },

    UploadImagesMail() {
      this.screenFreeze = true;
      this.loading = true;
      this.$http.mailService
        //************20/11/2022
        /*  .UploadImagesMail(this.mailId, this.imagesToSend, Number(9))*/
        .UploadImagesMail(
          this.mailId,
          this.imagesToSend,
          Number(localStorage.getItem("AY_LW"))
        )
        //*************end 20/11/2022
        .then((res) => {
          setTimeout(() => {
            this.ButtonUploadImagesMail = false;
            this.loading = false;
            this.screenFreeze = false;

            this.imagesToSend = [];
            console.log(res);

            this.GetSentMailById();
            this.GetAllDocN("next");
          }, 500);
        })
        .catch((err) => {
          setTimeout(() => {
            this.loading = false;
            this.screenFreeze = false;
          }, 500);
        });
    },

    GetDocmentForMailToShow() {
      this.$http.documentService
        .GetDocmentForMail(Number(this.mailId), 1)
        .then((res) => {
          this.imagesToShow = res.data.result.documents;
        })
        .catch((err) => {
          this.addErorr = err.message;
        });
    },

    printImage(img) {
      var Pagelink = "هيئة الرقابة الادارية ليبيا";
      var pwa = window.open(
        Pagelink,
        "_new",
        "status=1,scrollbars=1,height=533,width=800"
      );

      pwa.document.open();
      pwa.document.write(this.ImagetoPrint(img));
      pwa.document.close();
    },
  },
};
</script>
