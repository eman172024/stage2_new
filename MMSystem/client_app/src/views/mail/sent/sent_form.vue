<template>
  <div class="">
    <div class="h-screen bg-gray-100 overflow-hidden flex">
      <asideComponent></asideComponent>
      <div class="flex-1 bg-gray-200 w-0 overflow-y-auto">
        <div class="max-w-screen-2xl mx-auto flex flex-col md:px-8">
          <navComponent></navComponent>

          <div v-if="roles.includes('d')" class="-mt-14 py-0.5 z-20 w-44">
            <button
              @click="clear_page()"
              class="
                border border-black
                duration-300
                bg-white
                px-4
                py-2
                rounded-md
                text-gray-900
                font-bold
                hover:bg-green-600 hover:text-white
                focus:outline-none
              "
            >
              إضافة بريد جديد +
            </button>
          </div>
          <main class="flex-1 relative focus:outline-none py-6">
            <div class="flex justify-between items-center">
              <h3 class="text-xl font-semibold text-gray-900">
                معلومات البريد
              </h3>
              <!-- 
                    animate-bounce
                    v-if="mailId"
                 -->

              <fieldset class="">
                <div class="flex items-center">
                  <legend class="text-sm font-semibold text-gray-800 ml-6">
                    نوع البريد
                  </legend>

                  <div class="flex justify-between items-center">
                    <div v-if="roles.includes('o')" class="flex items-center">
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

                    <div v-if="roles.includes('j')" class="flex items-center mx-4">
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

                    <div v-if="roles.includes('a')" class="flex items-center">
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
                class="
                  float-left
                  text-sm
                  font-semibold
                  text-gray-800
                  flex
                  items-center
                "
              >
                رقم الرسالة

                <span
                  class="mr-4 underline font-bold text-2xl flex items-center"
                >
                  <input
                    type="number"
                    @keypress.enter="mail_search()"
                    class="w-16 px-1 rounded-md focus:outline-none"
                    v-model="mail_Number"
                  />
                  <div
                    class="
                      w-16
                      px-1
                      rounded-md
                      font-normal
                      focus:outline-none
                      mx-4
                      bg-white
                    "
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
            </div>

            <div class="mt-6 space-y-6">
              <div class="grid grid-cols-7 gap-6">
                <section class="col-span-5 flex justify-between items-stretch">
                  <section
                    class="
                      w-6/12
                      ml-3
                      grid grid-cols-1
                      gap-y-6 gap-x-4
                      sm:grid-cols-6
                      bg-gray-100
                      rounded-md
                      p-6
                    "
                  >
                    <div class="sm:col-span-6">
                      <label
                        for="summary"
                        class="block text-sm font-semibold text-gray-800"
                      >
                        الملخص
                      </label>
                      <textarea
                        v-model="summary"
                        id="summary"
                        rows="3"
                        class="
                          block
                          mt-2
                          w-full
                          text-sm
                          rounded-md
                          border border-gray-200
                          hover:shadow-sm
                          focus:outline-none focus:border-gray-300
                          p-2
                        "
                      >
                      </textarea>
                    </div>

                    <div class="sm:col-span-3">
                      <label
                        for="classification"
                        class="block text-sm font-semibold text-gray-800"
                      >
                        التصنيف
                      </label>
                      <select
                        v-model="classification"
                        id="classification"
                        class="
                          block
                          mt-2
                          w-full
                          h-10
                          text-sm
                          rounded-md
                          border border-gray-200
                          hover:shadow-sm
                          focus:outline-none focus:border-gray-300
                          p-2
                        "
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
                    </div>

                    <div class="sm:col-span-3">
                      <label
                        for="date"
                        class="block text-sm font-semibold text-gray-800"
                      >
                        التاريخ
                      </label>
                      <input
                        v-model="releaseDate"
                        min="2000-01-01"
                        max="2040-12-30"
                        type="date"
                        id="date"
                        class="
                          block
                          mt-2
                          w-full
                          rounded-md
                          h-10
                          text-sm
                          border border-gray-200
                          hover:shadow-sm
                          focus:outline-none focus:border-gray-300
                          p-2
                        "
                      />
                    </div>

                    <div class="sm:col-span-3">
                      <label
                        for="general_incoming_number"
                        class="block text-sm font-semibold text-gray-800"
                      >
                        رقم الوارد العام
                      </label>
                      <input
                        v-model="general_incoming_number"
                        type="number"
                        id="general_incoming_number"
                        class="
                          block
                          mt-2
                          h-10
                          text-sm
                          w-full
                          rounded-md
                          border border-gray-200
                          hover:shadow-sm
                          focus:outline-none focus:border-gray-300
                          px-2
                        "
                        required
                      />
                    </div>

                    <div class="sm:col-span-3">
                      <label
                        for="year"
                        class="block text-sm font-semibold text-gray-800"
                      >
                        السنة
                      </label>
                      <input
                        type="number"
                        placeholder="YYYY"
                        min="2011"
                        max="2100"
                        v-model="genaral_inbox_year"
                        id="year"
                        class="
                          block
                          mt-2
                          w-full
                          rounded-md
                          h-10
                          text-sm
                          border border-gray-200
                          hover:shadow-sm
                          focus:outline-none focus:border-gray-300
                          p-2
                        "
                      />
                    </div>
                  </section>

                  <section
                    class="
                      w-6/12
                      mr-3
                      grid grid-cols-1
                      gap-y-6 gap-x-4
                      sm:grid-cols-6
                      bg-gray-100
                      rounded-md
                      p-6
                    "
                  >
                    <div class="sm:col-span-6">
                      <label
                        for="action_required"
                        class="block text-sm font-semibold text-gray-800"
                      >
                        الإجراء المطلوب
                      </label>
                      <textarea
                        v-model="required_action"
                        id="action_required"
                        rows="3"
                        class="
                          block
                          mt-2
                          w-full
                          text-sm
                          rounded-md
                          border border-gray-200
                          hover:shadow-sm
                          focus:outline-none focus:border-gray-300
                          p-2
                        "
                      >
                      </textarea>
                    </div>

                    <div
                      class="
                        sm:col-span-6
                        grid grid-cols-1
                        gap-y-6 gap-x-2
                        sm:grid-cols-7
                      "
                    >
                      <div class="sm:col-span-4">
                        <label
                          for="department"
                          class="block text-sm font-semibold text-gray-800"
                        >
                          الإدارات
                        </label>

                        <div class="relative">
                          <button
                            @click="departmentselect = !departmentselect"
                            id="department"
                            class="
                              overflow-hidden
                              text-right
                              block
                              mt-2
                              w-full
                              rounded-md
                              h-10
                              border
                              text-xs
                              bg-white
                              border-gray-200
                              hover:shadow-sm
                              focus:outline-none focus:border-gray-300
                              p-2
                            "
                          >
                            {{ departmentNameSelected }}
                          </button>

                          <div
                            v-if="departmentselect"
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
                              h-40
                              overflow-y-scroll
                              rounded-b-md
                            "
                          >
                            <button
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
                              <!--    -->
                              الكل
                            </button>

                            <button
                              class="
                                block
                                focus:outline-none
                                w-full
                                my-1
                                text-right
                              "
                              @click="
                                selectdepartment(
                                  department.id,
                                  department.departmentName,
                                  index
                                );
                                departmentselect = !departmentselect;
                              "
                              v-for="(department, index) in departments"
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
                            class="
                              text-right
                              block
                              mt-2
                              w-full
                              rounded-md
                              h-10
                              border
                              text-xs
                              bg-white
                              border-gray-200
                              hover:shadow-sm
                              focus:outline-none focus:border-gray-300
                              p-2
                            "
                          >
                            {{ measureNameSelected }}
                          </button>

                          <div
                            v-if="measureselect"
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
                              h-40
                              overflow-y-scroll
                              rounded-b-md
                            "
                          >
                            <button
                              class="
                                block
                                focus:outline-none
                                w-full
                                my-1
                                text-right
                              "
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

                      <div class="sm:col-span-1 flex justify-end"
                        v-if="measureNameSelected && departmentNameSelected"
                      >
                        <button
                          v-if="add_button_consignees"
                          @click="add_to_array_of_side_measure()"
                          class="
                            mt-8
                            rounded-md
                            text-green-400
                            duration-200
                            hover:text-green-500
                            text-base
                            font-semibold
                            w-8
                            h-8
                          "
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
                        المرسل إليهم
                      </label>
                      <div
                        class="
                          mt-2
                          w-full
                          rounded-md
                          border border-gray-200
                          p-2
                          h-24
                          overflow-y-scroll
                          flex flex-wrap
                          items-center
                        "
                      >
                        <div
                          v-for="consignee in consignees"
                          :key="consignee.side"
                          class="
                            border border-gary-200
                            rounded-md
                            text-sm
                            flex
                            items-center
                            p-2
                            m-0.5
                          "
                        >
                          {{ consignee.departmentName }} ,
                          {{ consignee.measureName }}
                          <button
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

                        <div
                          v-for="consignee in newactionSenders"
                          :key="consignee.side"
                          class="
                            border border-gary-200
                            rounded-md
                            text-sm
                            flex
                            items-center
                            p-2
                            m-0.5
                          "
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
                  </section>
                </section>

                <section
                  v-if="documentSection"
                  class="col-span-2 bg-gray-100 rounded-md p-6"
                >
                  <div class="flex justify-between items-center">
                    <h3 class="block text-sm font-semibold text-gray-800">
                      المستندات
                    </h3>

                    <label
                      v-if="mailId"
                      class="
                        w-48
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
                     <!-- <input
                        class="hidden"
                        type="button"
                        @click="scanToJpg(), (show_images = true)"
                      /> -->
                      <a id="a1" @click="func();">تجربة  الماسح الضوئي</a>
                    </label>
                  </div>
                    
                  <div class="h-72 w-full bg-gray-100 rounded-md mt-4 mb-10">
                    <div
                      v-if="imagesToSend != '' || imagesToShow != ''"
                      class="mt-4 pt-4 pb-4 rounded-md"
                    >
                      <div v-if="testimage" class="">
                        <div class="relative h-64 w-full">
                          <img
                            :src="testimage"
                            alt="image"
                            class="w-full h-full rounded object-contain"
                          />

                          <div
                            class="
                              absolute
                              inset-0
                              flex
                              justify-center
                              items-center
                            "
                          >
                            <button
                              @click="GetAllDocuments(mailId, 1)"
                              type="button"
                              class="
                                bg-green-600
                                hover:bg-green-500
                                duration-500
                                p-2
                                rounded-full
                                focus:outline-none
                                ml-2
                              "
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
                              type="button"
                              class="
                                bg-red-600
                                hover:bg-red-500
                                duration-500
                                p-2
                                rounded-full
                                focus:outline-none
                                ml-2
                              "
                              @click="deleteDocument()"
                            >
                              <svg
                                class="
                                  w-4
                                  h-4
                                  stroke-current
                                  text-white
                                  mx-auto
                                "
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
                        </div>

                        <div
                          class="flex justify-between items-center pt-2 MB-2"
                        >
                          <div
                            class="
                              ml-2
                              flex
                              justify-between
                              items-center
                              w-full
                            "
                          >
                            <button
                              title="prev"
                              @click="previousImage()"
                              class="
                                w-8
                                h-8
                                bg-gray-300
                                rounded
                                flex
                                justify-center
                                items-center
                              "
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

                            <div class="">
                              {{ indextotest + 1 }} / {{ imagesToShow.length }}
                            </div>

                            <button
                              title="next"
                              @click="nextImage()"
                              class="
                                w-8
                                h-8
                                bg-gray-300
                                rounded
                                flex
                                justify-center
                                items-center
                              "
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

                  <div class="w-full flex justify-center ">
                    <button
                      @click="GetAllDocumentsToSend()"
                      type="button"
                      class="
                        w-full
                        sm:w-auto sm:mr-3
                        flex
                        justify-center
                        items-center
                        py-2
                        px-4
                        border border-transparent
                        shadow-sm
                        text-sm
                        font-medium
                        rounded-md
                        border-green-600
                        text-white
                        bg-green-600
                        hover:shadow-lg
                        focus:shadow-none
                        duration-300
                        focus:outline-none
                     
                    
                       
                      
                    "
                      v-if="show_images && roles.includes('h')"
                    >
                      عرض الصور
                    </button>
                  </div>
                </section>
              </div>

              <section
                v-if="mailType == '2' || mailType == '3'"
                class="
                  col-span-2
                  grid grid-cols-1
                  gap-y-6 gap-x-4
                  sm:grid-cols-6
                  bg-gray-50
                  rounded-md
                  p-6
                "
              >
                <div
                  class="
                    sm:col-span-6
                    grid grid-cols-1
                    gap-y-6 gap-x-4
                    sm:grid-cols-6
                  "
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

                  <br />

                  <div class="sm:col-span-3">
                    <label
                      for="send_to_sector"
                      class="block text-sm font-semibold text-gray-800"
                    >
                      القطاع
                    </label>

                    <div class="relative">
                      <button
                        @click="sectorselect = !sectorselect"
                        id="department"
                        class="
                          text-right
                          block
                          mt-2
                          w-full
                          rounded-md
                          h-10
                          border
                          text-sm
                          bg-white
                          border-gray-200
                          hover:shadow-sm
                          focus:outline-none focus:border-gray-300
                          p-2
                        "
                      >
                        {{ sectorNameSelected }}
                      </button>

                      <div
                        v-if="sectorselect"
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
                          h-40
                          overflow-y-scroll
                          rounded-b-md
                        "
                      >
                        <button
                          class="
                            block
                            focus:outline-none
                            w-full
                            my-1
                            text-right
                          "
                          @click="
                            get_sides(sector.id, sector.section_Name);
                            sectorselect = !sectorselect;
                          "
                          v-for="sector in sectors"
                          :key="sector.id"
                        >
                          {{ sector.section_Name }}
                        </button>
                      </div>
                    </div>
                  </div>

                  <div class="sm:col-span-3">
                    <label
                      for="sideIdSelected"
                      class="block text-sm font-semibold text-gray-800"
                    >
                      الجهة
                    </label>

                    <div class="relative">
                      <button
                        @click="sideselect = !sideselect"
                        id="department"
                        class="
                          text-right
                          block
                          mt-2
                          w-full
                          rounded-md
                          h-10
                          border
                          text-sm
                          bg-white
                          border-gray-200
                          hover:shadow-sm
                          focus:outline-none focus:border-gray-300
                          p-2
                        "
                      >
                        {{ sideNameSelected }}
                      </button>

                      <div
                        v-if="sideselect"
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
                          h-40
                          overflow-y-scroll
                          rounded-b-md
                        "
                      >
                        <button
                          class="
                            block
                            focus:outline-none
                            w-full
                            my-1
                            text-right
                          "
                          @click="
                            pass_side(side.id, side.section_Name);
                            sideselect = !sideselect;
                          "
                          v-for="side in sides"
                          :key="side.id"
                        >
                          {{ side.section_Name }}
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
                    class="
                      block
                      mt-2
                      w-full
                      text-sm
                      rounded-md
                      border border-gray-200
                      hover:shadow-sm
                      focus:outline-none focus:border-gray-300
                      p-2
                    "
                  >
                  </textarea>
                </div>

                <div
                  v-if="mailType == '3'"
                  class="
                    sm:col-span-6
                    grid grid-cols-1
                    mt-6
                    gap-y-6 gap-x-4
                    sm:grid-cols-6
                    rounded-md
                  "
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
                      class="
                        block
                        mt-2
                        w-full
                        rounded-md
                        h-10
                        border border-gray-200
                        hover:shadow-sm
                        focus:outline-none focus:border-gray-300
                        px-2
                      "
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
                      class="
                        block
                        mt-2
                        h-10
                        w-full
                        rounded-md
                        border border-gray-200
                        hover:shadow-sm
                        focus:outline-none focus:border-gray-300
                        px-2
                      "
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
                      class="
                        block
                        mt-2
                        w-full
                        rounded-md
                        h-10
                        border border-gray-200
                        hover:shadow-sm
                        focus:outline-none focus:border-gray-300
                        p-2
                      "
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
                      v-if="
                        summary &&
                          classification &&
                          (consignees.length != 0 ||
                            newactionSenders.length != 0)
                      "
                      @click="clear_page()"
                      class="
                        flex
                        justify-center
                        items-center
                        py-2
                        px-8
                        border border-transparent
                        shadow-sm
                        text-sm
                        font-medium
                        rounded-md
                        border-green-600
                        text-green-600
                        hover:shadow-lg
                        focus:shadow-none
                        duration-300
                        focus:outline-none
                      "
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
                    <button
                      v-if="
                        summary &&
                          classification &&
                          (consignees.length != 0 ||
                            newactionSenders.length != 0)
                      "
                      @click="updateMail"
                      type="button"
                      id="edit"
                      class="
                        w-full
                        sm:w-auto sm:mr-3
                        flex
                        justify-center
                        items-center
                        py-2
                        px-4
                        border border-transparent
                        shadow-sm
                        text-sm
                        font-medium
                        rounded-md
                        border-green-600
                        text-white
                        bg-green-600
                        hover:shadow-lg
                        focus:shadow-none
                        duration-300
                        focus:outline-none
                      "
                    >
                      <!-- onclick="change();" -->
                      <svg
                        class="
                          w-4
                          h-4
                          stroke-current
                          text-white
                          ml-2
                          fill-current
                        "
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

                  <div v-if="deleteButton" class="flex justify-end ml-6">
                    <button
                      v-if="
                        summary &&
                          classification &&
                          (consignees.length != 0 ||
                            newactionSenders.length != 0)
                            && roles.includes('s')
                      "
                      @click="deleteMail"
                      type="button"
                      id="edit"
                      class="
                        w-full
                        sm:w-auto sm:mr-3
                        flex
                        justify-center
                        items-center
                        py-2
                        px-4
                        border border-transparent
                        shadow-sm
                        text-sm
                        font-medium
                        rounded-md
                        border-green-600
                        text-white
                        bg-green-600
                        hover:shadow-lg
                        focus:shadow-none
                        duration-300
                        focus:outline-none
                      "
                    >
                      <!-- onclick="change();" -->
                      <svg
                        class="
                          w-4
                          h-4
                          stroke-current
                          text-white
                          ml-2
                          fill-current
                        "
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

                  <div v-if="saveButton" class="flex justify-end">
                    <div v-if="mailType == '1'" class="">
                      <button
                        v-if="
                          summary &&
                            classification &&
                            (consignees.length != 0 ||
                              newactionSenders.length != 0)
                        "
                        class="
                          flex
                          justify-center
                          items-center
                          py-2
                          px-8
                          border border-transparent
                          shadow-sm
                          text-sm
                          font-medium
                          rounded-md
                          border-green-600
                          text-white
                          bg-green-600
                          hover:shadow-lg
                          focus:shadow-none
                          duration-300
                          focus:outline-none
                        "
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
                            (consignees.length != 0 ||
                              newactionSenders.length != 0) &&
                            mail_forwarding &&
                            sectorNameSelected &&
                            sideNameSelected &&
                            action_required_by_the_entity
                        "
                        class="
                          flex
                          justify-center
                          items-center
                          py-2
                          px-8
                          border border-transparent
                          shadow-sm
                          text-sm
                          font-medium
                          rounded-md
                          border-green-600
                          text-white
                          bg-green-600
                          hover:shadow-lg
                          focus:shadow-none
                          duration-300
                          focus:outline-none
                        "
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
                            (consignees.length != 0 ||
                              newactionSenders.length != 0) &&
                            sectorNameSelected &&
                            sideNameSelected &&
                            ward_to &&
                            mail_ward_type &&
                            entity_mail_date &&
                            entity_reference_number &&
                            procedure_type
                        "
                        class="
                          flex
                          justify-center
                          items-center
                          py-2
                          px-8
                          border border-transparent
                          shadow-sm
                          text-sm
                          font-medium
                          rounded-md
                          border-green-600
                          text-white
                          bg-green-600
                          hover:shadow-lg
                          focus:shadow-none
                          duration-300
                          focus:outline-none
                        "
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

                  <div v-if="sendButton && roles.includes('b')" class="flex justify-end">
                    <button
                      v-if="
                        summary &&
                          classification &&
                          (consignees.length != 0 ||
                            newactionSenders.length != 0)
                      "
                      class="
                        flex
                        justify-center
                        items-center
                        py-2
                        px-8
                        border border-transparent
                        shadow-sm
                        text-sm
                        font-medium
                        rounded-md
                        border-green-600
                        text-white
                        bg-green-600
                        hover:shadow-lg
                        focus:shadow-none
                        duration-300
                        focus:outline-none
                      "
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
              </section>

              <section
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
                  class="
                    border border-blue-400
                    hover:bg-blue-400 hover:text-white
                    duration-300
                    focus:outline-none
                    rounded-md
                    text-sm
                    p-2
                    m-0.5
                  "
                >
                  {{ consignee.departmentName }} ,
                  {{ consignee.measureName }}
                </button>
              </section>

              <section
                v-if="departmentflag > 2"
                class="bg-gray-100 rounded-md p-6"
              >
                <p class="block text-sm font-semibold text-gray-800">
                  ردود - {{ departmentName }}
                </p>

                <div
                  id="scroll"
                  class="
                    h-72
                    overflow-y-scroll
                    mt-4
                    rounded-lg
                    py-2
                    border border-gray-300
                  "
                >
                  <div
                    v-for="(reply, index) in replies" :key="index"
                    :class="
                      reply.reply.to == my_department_id
                        ? ' flex-row-reverse justify-start'
                        : 'justify-start'
                    "
                    class="w-full my-0.5 flex px-2"
                  > 
                    <div class="">
                      <div class="flex " :class="reply.reply.to == my_department_id
                        ? '  justify-end'
                        : 'justify-end flex-row-reverse'
                    ">
                        

                        <!--<div v-if="reply.resources != 0" class="mx-2">
                          <button
                            v-if="roles.includes('h')"
                            @click="show_reply_images(index, 3)"
                            class="
                              px-2
                              text-xs
                              rounded
                              leading-9
                              text-white
                              bg-red-400
                              flex
                              items-center
                            "
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
                        </div>-->

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

                      <div class="mt-1 text-sm" :class="reply.reply.to == my_department_id ? 'text-left' : 'text-right'">
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
                        class="
                          block
                          w-full
                          h-20
                          text-sm
                          rounded-md
                          border border-gray-200
                          hover:shadow-sm
                          focus:outline-none focus:border-gray-300
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
                        <span class="text-sm leading-normal"
                          >   </span
                        >
                       <!-- <input
                          class="hidden"
                          type="button"
                          @click="scanToReply"
                        />-->
                         <a id="a1" @click="reply1();">  الماسح الضوئي الرد</a>
                 
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
                </div>
              </section>
            </div>
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
          class="
            h-screen
            flex flex-col
            justify-center
            items-center
            bg-black bg-opacity-90
            absolute
            top-0
            inset-0
            z-50
            w-full
          "
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
                v-if="roles.includes('g')"
                @click="print_image()"
                v-print="'#printMe'"
                class="
                  bg-blue-500
                  hover:bg-blue-400
                  px-4
                  py-2
                  rounded-lg
                  text-white
                "
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
              class="
                flex
                justify-between
                items-center
                max-w-xs
                mx-auto
                w-full
                mt-4
              "
            >
              <button
                @click="previousImage_images_model()"
                class="
                  focus:outline-none
                  w-12
                  h-8
                  bg-gray-300
                  rounded
                  flex
                  justify-center
                  items-center
                "
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
                class="
                  focus:outline-none
                  w-12
                  h-8
                  bg-gray-300
                  rounded
                  flex
                  justify-center
                  items-center
                "
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
</template>

<script
  type="text/javascript"
  src="http://cdn.asprise.com/scannerjs/scanner.js"
></script>
<script>
import asideComponent from "@/components/asideComponent.vue";
import navComponent from "@/components/navComponent.vue";
import svgLoadingComponent from "@/components/svgLoadingComponent.vue";

//***************
import {HubConnectionBuilder} from "@microsoft/signalr";

     const connection = new HubConnectionBuilder()
    // .withUrl('http://172.16.0.12:82/api/Testhub')
      .withUrl('http://localhost:58316/api/Testhub')
     .withAutomaticReconnect([0, 1000, 5000, null])
     .build();   
connection.start();
//***************

export default {
  created() {},

  components: {
    asideComponent,
    navComponent,
    svgLoadingComponent,
  },

  mounted() {
//**************

 connection.on("resivemassage",(state1,massage)=>{
  
   // if(state1==true){
       if(state1==true && massage=="a"){
         console.log("massage="+massage)

         this.GetAllDocumentsToSend()
    }else
    //**********2/6/2022
   /*  if(state1==true && massage=="r"){
         console.log("massage="+massage)

          this.GetReplyByDepartment(
              this.replyByDepartmenId,
              this.sends_id,
              this.departmentName
            );
     }
     else*/
    //**********end 2/6/2022
    {
      console.log("state1=false") 
    }
     })
  
//*****************

    var date = new Date();

    var month = date.getMonth() + 1;
    var day = date.getDate();

    if (month < 10) month = "0" + month;
    if (day < 10) day = "0" + day;

    this.releaseDate = date.getFullYear() + "-" + month + "-" + day;

    this.mail_year = date.getFullYear();
    this.my_user_id = localStorage.getItem("userId");
    this.my_department_id = localStorage.getItem("departmentId");
    this.roles = localStorage.getItem("roles");

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
  },

  data() {
    return {
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
      newactionSenders: [],
      newactionSendersIncludesId: [],

      releaseDate: "",
      summary: "",
      classification: "",
      mailType: 1,
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
      mail_ward_type: "",
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
    };
  },

  watch: {
    mailType: function() {
      this.indextotest_images_model = 0;
      this.show_images_images_model = [];
      this.mail_Number = "";
      this.summary = "";
      this.classification = "";
      this.general_incoming_number = "";
      this.genaral_inbox_year = "";
      this.required_action = "";
      this.mailId = "";
      this.mail_forwarding = "";

      this.sideNameSelected = "";
      this.sideIdSelected = "";
      this.sectorNameSelected = "";

      

      this.action_required_by_the_entity = "";
      this.mail_ward_type = "";
      this.ward_to = "";
      this.entity_mail_date = "";
      this.entity_reference_number = "";
      this.procedure_type = 1;

      this.this_value_to_solve_repetition_department = true;

      this.consignees = [];
      this.newactionSendersIncludesId = [];

      this.replies = [];
      this.imagesToShow = [];
      this.newactionSenders = [];

      this.saveButton = true;
      this.sendButton = false;
      this.updataButton = false;
      this.deleteButton = false;
      this.ButtonUploadImagesMail = false;
      this.add_button_consignees = true;

      this.GetAllDepartments();

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
                this.newactionSendersIncludesId.push(this.departments[index].id)
                // this.departments.splice(index, 1);

                
              }

              if ( this.departments[index].departmentName.includes("المحفوظات") )
              {
                this.newactionSenders.push({
                  departmentId: this.departments[index].id,
                  departmentName: this.departments[index].departmentName,
                  measureId: this.measures[0].measuresId,
                  measureName: this.measures[0].measuresName,
                });
                this.newactionSendersIncludesId.push(this.departments[index].id)
                // this.departments.splice(index, 1);
              }
            }
          }
        }
      }, 500);
    },
  },

  methods: {

//*****************29/3/2022
func(){
   /* var link = document.getElementById('a1');
        var timeout;
        window.addEventListener('blur',function(e){
            window.clearTimeout(timeout);
        })
        
        link.addEventListener('click', function(e) { 
        
            timeout = window.setTimeout(function() {
              console.log('timeout');
              console.log("//"+"file://mail/aca-mail/scan-setup.exe")
                window.location="//"+"file://mail/aca-mail/scan-setup.exe";
            }, 1000);
        
            window.location = "scanapp://";
            e.preventDefault();
        });*/

//***********
 console.log("bbbbbbbhhhhhhh"+"  id= "+this.mailId)
  //document.getElementById("a1").href="SScaner:id=" + this.mailId;
  document.getElementById("a1").href="SScaner:flag=1" + "mId="+this.mailId
  console.log("test "+"  id= "+this.mailId)
//************
},
 
 reply1(){
 console.log("replay"+"  id= "+this.mailId)
   document.getElementById("a1").href="SScaner:flag=0"+"userid="+localStorage.getItem("userId") + "mId="+this.mailId +"send_ToId="+this.sends_id+"to="+this.replyByDepartmenId
  console.log("testreplay "+"  id= "+this.mailId+"userid="+localStorage.getItem("userId")  +"send_ToId="+this.sends_id+"to="+this.replyByDepartmenId)
//************
},
//*************end 29/3/2022

    print_image() {
      this.to_test_print_images_model = true;
      this.$http.mailService
        .PrintOrShowDocument(
          Number(this.mailId),
          Number(localStorage.getItem("userId")),
          Number(this.from_reply_or_general)
        )
        .then((res) => {
          setTimeout(() => {
            console.log(res);
            this.loading = false;
            this.screenFreeze = false;
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

    show_reply_images(index, plase) {
      this.from_reply_or_general = plase;
      this.screenFreeze = true;
      this.loading = true;

      this.$http.mailService
        .PrintOrShowDocument(
          Number(this.mailId),
          Number(localStorage.getItem("userId")),
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


      this.consignees = [];
      this.newactionSendersIncludesId = [];
      
      this.newactionSenders = []; 

      this.show_images = false;
      this.departmentNameSelected = "";
      this.measureNameSelected = "";

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
      if (this.allDepartment) {
        for (let index = 0; index < this.blblbl.length; index++) {

          if(this.newactionSendersIncludesId.includes(this.blblbl[index].id)){

          }else{
            this.newactionSenders.push({
              departmentId: this.blblbl[index].id,
              departmentName: this.blblbl[index].departmentName,
              measureId: this.measureIdSelected,
              measureName: this.measureNameSelected,
            });
            this.newactionSendersIncludesId.push(this.blblbl[index].id)
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

        if(this.newactionSendersIncludesId.includes(this.departmentIdSelected)){
          console.log("found")
          alert("تم اضافة الادارة من قبل")
          this.departmentNameSelected = "";
          this.departmentIdSelected = "";

          this.measureIdSelected = "";
          this.measureNameSelected = "";
        }else{
          console.log("not found")

          this.newactionSendersIncludesId
          this.newactionSenders.push({
            departmentId: this.departmentIdSelected,
            departmentName: this.departmentNameSelected,
            measureId: this.measureIdSelected,
            measureName: this.measureNameSelected,
          });
          this.newactionSendersIncludesId.push(this.departmentIdSelected)

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
          Number(localStorage.getItem("userId"))
        )
        .then((res) => {
          setTimeout(() => {
            this.loading = false;
            this.screenFreeze = false;

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
      this.newactionSenders = [];
      this.newactionSendersIncludesId = [];

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
          this.mail_Number = res.data.mail.mail_Number;
          this.department_Id = res.data.mail.department_Id;
          this.mail_year = res.data.mail.mail_year;

          this.releaseDate = res.data.mail.date_Of_Mail;
          this.summary = res.data.mail.mail_Summary;
          this.classification = res.data.mail.clasification;
          // this.mailType = res.data.mail.mail_Type;
          this.general_incoming_number = res.data.mail.genaral_inbox_Number;
          this.genaral_inbox_year = res.data.mail.genaral_inbox_year;
          this.required_action = res.data.mail.action_Required;

          this.consignees = res.data.actionSenders;



          for (let index = 0; index < res.data.actionSenders.length; index++) {
           
            this.newactionSendersIncludesId.push(res.data.actionSenders[index].departmentId)
          }

          this.imagesToShow = res.data.resourcescs;

          if (this.imagesToShow.length > 0) {
            this.testimage = this.imagesToShow[0].path;
            this.test_image_id = this.imagesToShow[0].id;
          }

          if (this.mailType == "2") {
            this.external_mailId = res.data.external.id;

            this.action_required_by_the_entity =
              res.data.external.action_required_by_the_entity;

            this.mail_forwarding = res.data.external.action;

            this.get_sectors(this.mail_forwarding);

            this.sectorNameSelected = res.data.sector[0].section_Name;
            this.sectorIdSelected = res.data.sector[0].id;

            this.get_sides(this.sectorIdSelected, this.sectorNameSelected);
            this.sideNameSelected = res.data.side[0].section_Name;
            this.sideIdSelected = res.data.side[0].id;
          }
          if (this.mailType == "3") {
            this.external_mailId = res.data.external.id;

            this.mail_forwarding = res.data.external.action;

            this.get_sectors(this.mail_forwarding);

            this.sectorNameSelected = res.data.sector[0].section_Name;
            this.sectorIdSelected = res.data.sector[0].id;

            this.get_sides(this.sectorIdSelected, this.sectorNameSelected);
            this.sideNameSelected = res.data.side[0].section_Name;
            this.sideIdSelected = res.data.side[0].id;

            this.ward_to = res.data.external.to;

            this.mail_ward_type = res.data.external.type;

            this.entity_mail_date = res.data.external.send_time;

            this.entity_reference_number =
              res.data.external.entity_reference_number;

            this.procedure_type = res.data.external.procedure_type;
          }

          setTimeout(() => {
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
        userId: Number(localStorage.getItem("userId")),
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
      this.departmentflag = 0;
      this.replyByDepartmenId = id;
      this.sends_id = send_ToId;
      this.departmentName = name;
      this.departmentflag = flag;

      this.$http.mailService
        .GetReplyByDepartment(this.replyByDepartmenId, this.mailId)
        .then((res) => {
          this.replies = res.data.list;

          console.log(this.replies);
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
        this.testimage_images_model = this.show_images_images_model[
          this.indextotest_images_model
        ].path;
      }
    },

    nextImage_images_model() {
      if (
        this.indextotest_images_model <
        this.show_images_images_model.length - 1
      ) {
        this.indextotest_images_model++;
        this.testimage_images_model = this.show_images_images_model[
          this.indextotest_images_model
        ].path;
      }
    },

    GetAllDocuments(id, plase) {
      this.from_reply_or_general = plase;
      this.screenFreeze = true;
      this.loading = true;
      this.$http.mailService
        .GetAllDocuments(id, Number(localStorage.getItem("userId")))
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

    pass_side(id, name) {
      this.sideNameSelected = name;
      this.sideIdSelected = id;
    },

    get_sides(sector, sector_name) {
      this.sideNameSelected = "";
      this.sideIdSelected = "";
      this.sides = [];
      this.sectorNameSelected = sector_name;
      this.$http.sectorsService
        .GetSides(sector)
        .then((res) => {
          this.sides = res.data;
        })
        .catch((err) => {
          console.log(err);
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

      if (this.mailType == "1") {
        var dataUpdate = {
          userId: Number(localStorage.getItem("userId")),
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
            state: true,
          },

          // actionSenders: this.consignees,
          newactionSenders: this.newactionSenders,
        };
      }

      if (this.mailType == "2") {
        var dataUpdate = {
          userId: Number(localStorage.getItem("userId")),
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
            state: true,
          },

          // actionSenders: this.consignees,
          newactionSenders: this.newactionSenders,

          external_Mail: {
            id: Number(this.external_mailId),
            action: Number(this.mail_forwarding),
            Sectionid: this.sideIdSelected,
            sectionName: "",
            action_required_by_the_entity: this.action_required_by_the_entity,
          },
        };
      }

      if (this.mailType == "3") {
        var dataUpdate = {
          userId: Number(localStorage.getItem("userId")),
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
            state: true,
          },

          // actionSenders: this.consignees,
          newactionSenders: this.newactionSenders,

          extrenal_Inbox: {
            Id: Number(this.external_mailId),
            action: Number(this.mail_forwarding),
            Sectionid: this.sideIdSelected,
            section_Name: "",
            to: Number(this.ward_to),
            type: Number(this.mail_ward_type),
            Send_time: this.entity_mail_date,
            entity_reference_number: Number(this.entity_reference_number),
            procedure_type: Number(this.procedure_type),
          },
        };
      }

      this.$http.mailService
        .UpdateMail(dataUpdate)
        .then((res) => {
          setTimeout(() => {
            this.loading = false;
            this.screenFreeze = false;

            this.newactionSenders = [];

            if (this.mailType == 1) {
              this.to_test_passing_mail_type = 1;
            }
            if (this.mailType == 2) {
              this.to_test_passing_mail_type = 2;
            }
            if (this.mailType == 3) {
              this.to_test_passing_mail_type = 3;
            }

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
            ActionRequired: this.required_action,
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
            ActionRequired: this.required_action,
          },

          actionSenders: this.newactionSenders,

          external_Mail: {
            action: Number(this.mail_forwarding),
            Sectionid: this.sideIdSelected,
            sectionName: "",
            action_required_by_the_entity: this.action_required_by_the_entity,
          },
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
            ActionRequired: this.required_action,
          },

          actionSenders: this.newactionSenders,

          extrenal_Inbox: {
            action: Number(this.mail_forwarding),
            Sectionid: this.sideIdSelected,
            section_Name: "",
            to: Number(this.ward_to),
            type: Number(this.mail_ward_type),
            Send_time: this.entity_mail_date,
            entity_reference_number: Number(this.entity_reference_number),
            procedure_type: Number(this.procedure_type),
          },
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

            console.log("this.to_test_passing_mail_type");
            console.log(this.to_test_passing_mail_type);
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

      this.screenFreeze = true;
      this.loading = true;

      
      this.$http.mailService
        .GetSentMailById(this.mailId, this.to_test_passing_mail_type)
        .then((res) => {
          // this.mailType = res.data.mail.mail_Type;
          if (res.data.mail.is_send == true) {
            this.sendButton = false;
            this.deleteButton = false;
            // this.add_button_consignees = false;
          }

          this.summary = res.data.mail.mail_Summary;


          this.remove_button_consignees = false;

          this.mail_Number = res.data.mail.mail_Number;
          this.department_Id = res.data.mail.department_Id;
          this.mail_year = res.data.mail.mail_year;

          this.releaseDate = res.data.mail.date_Of_Mail;
          this.classification = res.data.mail.clasification;

          this.general_incoming_number = res.data.mail.genaral_inbox_Number;
          this.genaral_inbox_year = res.data.mail.genaral_inbox_year;
          this.required_action = res.data.mail.action_Required;

          
          this.consignees = res.data.actionSenders;

          console.log(res.data.actionSenders)

          for (let index = 0; index < res.data.actionSenders.length; index++) {
           
            this.newactionSendersIncludesId.push(res.data.actionSenders[index].departmentId)
          }

          // this.departments = res.data.departments;

          this.imagesToShow = res.data.resourcescs;

          if (this.imagesToShow.length > 0) {
            this.testimage = this.imagesToShow[0].path;
            this.test_image_id = this.imagesToShow[0].id;
          }

          if (res.data.mail.mail_Type == 1) {
            this.GetAllDepartments()
          }

          if (this.to_test_passing_mail_type == "2") {
            this.external_mailId = res.data.external.id;

            this.action_required_by_the_entity =
              res.data.external.action_required_by_the_entity;

            this.mail_forwarding = res.data.external.action;

            this.get_sectors(this.mail_forwarding);

            this.sectorNameSelected = res.data.sector[0].section_Name;
            this.sectorIdSelected = res.data.sector[0].id;

            this.get_sides(this.sectorIdSelected, this.sectorNameSelected);
            this.sideNameSelected = res.data.side[0].section_Name;
            this.sideIdSelected = res.data.side[0].id;
          }
          if (this.to_test_passing_mail_type == "3") {
            this.external_mailId = res.data.external.id;

            this.mail_forwarding = res.data.external.action;

            this.get_sectors(this.mail_forwarding);

            this.sectorNameSelected = res.data.sector[0].section_Name;
            this.sectorIdSelected = res.data.sector[0].id;

            this.get_sides(this.sectorIdSelected, this.sectorNameSelected);
            this.sideNameSelected = res.data.side[0].section_Name;
            this.sideIdSelected = res.data.side[0].id;

            this.ward_to = res.data.external.to;

            this.mail_ward_type = res.data.external.type;

            this.entity_mail_date = res.data.external.send_time;

            this.entity_reference_number =
              res.data.external.entity_reference_number;

            this.procedure_type = res.data.external.procedure_type;
          }

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

    sendMail() {
      console.log(this.mailId);
      console.log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
      console.log(this.mailId);
      console.log(this.mail_Number);

      this.screenFreeze = true;
      this.loading = true;

      this.$http.mailService
        .SendMail(Number(this.mailId), Number(localStorage.getItem("userId")))
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

    GetAllDocumentsToSend() {
      this.screenFreeze = true;
      this.loading = true;
      this.$http.mailService
      //  .GetAllDocuments(29, Number(localStorage.getItem("userId")))
       .GetAllDocuments(this.mailId, Number(localStorage.getItem("userId")))
        .then((res) => {
          console.log(res);

          this.imagesToShow = res.data;

          this.testimage = this.imagesToShow[0].path;

          setTimeout(() => {
            // this.show_images_model = true;
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

    displayImagesOnPage(successful, mesg, response) {
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
      }, 1000);
    },

    UploadImagesMail() {
      this.screenFreeze = true;
      this.loading = true;
      this.$http.mailService
        .UploadImagesMail(
          this.mailId,
          this.imagesToSend,
          Number(localStorage.getItem("userId"))
        )
        .then((res) => {
          setTimeout(() => {
            this.ButtonUploadImagesMail = false;
            this.loading = false;
            this.screenFreeze = false;

            this.imagesToSend = [];
            console.log(res);

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

    deleteDocument() {
      this.$http.mailService
        .DeleteDocument(
          Number(this.test_image_id),
          Number(localStorage.getItem("userId"))
        )
        .then((res) => {
          console.log("SSSSSSSSSSSSSSSSSSSSSS");
          // this.imagesToShow.splice(index, 1);
          this.mail_search();
          console.log(res);
          // this.imagesToShow = res.data.result.documents
        })
        .catch((err) => {
          this.addErorr = err.message;
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
  },
};
</script>
