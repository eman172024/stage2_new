<template>
  <div class="">
    <div class="h-screen bg-gray-100 overflow-hidden flex">
      <asideComponent></asideComponent>
      <div class="flex-1 bg-gray-200 w-0 overflow-y-auto">
        <div class="max-w-screen-2xl mx-auto flex flex-col md:px-8">
          <navComponent></navComponent>
          <main class="flex-1 relative focus:outline-none pt-2 pb-24">
            <div class="flex justify-between items-center">
              <div class="">
                <h1 class="text-xl font-semibold text-gray-900">
                  البريد الوارد
                </h1>
              </div>

              <div class="flex items-center">
                <span class="text-base font-medium text-gray-800">
                  التاريخ :
                </span>

                <span class="flex items-center mr-4">
                  من
                  <input type="date" min="2000-01-01" max="2040-12-30" id="date_from" v-model="date_from" class="
                        block
                        mr-2
                        w-full
                        rounded-md
                        h-10
                        border border-gray-200
                        hover:shadow-sm
                        focus:outline-none focus:border-gray-300
                        px-2
                      " />
                </span>

                <span class="flex items-center mr-4">
                  إلي
                  <input type="date" min="2000-01-01" max="2040-12-30" id="date_to" v-model="date_to" class="
                        block
                        mr-2
                        w-full
                        rounded-md
                        h-10
                        border border-gray-200
                        hover:shadow-sm
                        focus:outline-none focus:border-gray-300
                        px-2
                      " />
                </span>
              </div>

              <fieldset class="">
                <div class="flex items-center">
                  <legend class="text-base font-medium text-gray-800 w-16">
                    نوع البريد
                  </legend>

                  <div class="flex items-center mr-6">
                    <input v-model="mailType" id="all" type="radio" name="type" class="h-4 w-4" value="0" />
                    <label for="all" class="mr-2 block text-gray-800">
                      الكل
                    </label>
                  </div>

                  <div class="flex items-center mr-6">
                    <input v-model="mailType" id="internal" type="radio" name="type" class="h-4 w-4" value="1" />
                    <label for="internal" class="mr-2 block text-gray-800">
                      داخلي
                    </label>
                  </div>

                  <div class="flex items-center mr-6">
                    <input v-model="mailType" id="internal_export" type="radio" name="type" class="h-4 w-4" value="2" />
                    <label for="internal_export" class="mr-2 block text-gray-800">
                      صادر خارجي
                    </label>
                  </div>

                  <div class="flex items-center mr-6">
                    <input v-model="mailType" id="external_incoming" type="radio" name="type" class="h-4 w-4" value="3" />
                    <label for="external_incoming" class="mr-2 block text-gray-800">
                      وارد خارجي
                    </label>
                  </div>
                </div>
              </fieldset>
            </div>

            <div class="mt-4 flex">
              <div class="relative w-full">
                <button @click="filter = !filter" :class="filter ? 'shadow-md' : ''" class="
                      rounded-t-md
                      border border-b-0
                      hover:text-blue-600 hover:font-bold
                      group
                      w-full
                      p-2
                      bg-white
                      flex
                      items-center
                      justify-between
                      focus:outline-none
                    ">
                  <span class="flex items-center">
                    <svg class="w-6 h-6 ml-2 stroke-current group-hover:stroke-2" fill="none" stroke="currentColor"
                      viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
                      <path stroke-linecap="round" stroke-linejoin="round"
                        d="M3 4a1 1 0 011-1h16a1 1 0 011 1v2.586a1 1 0 01-.293.707l-6.414 6.414a1 1 0 00-.293.707V17l-4 4v-6.586a1 1 0 00-.293-.707L3.293 7.293A1 1 0 013 6.586V4z">
                      </path>
                    </svg>
                    فرز
                  </span>

                  <span class="">
                    <svg class="w-6 h-6 stroke-current group-hover:stroke-2" fill="none" stroke="currentColor"
                      viewBox="0 0 24 24">
                      <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="{2}" d="M19 9l-7 7-7-7" />
                    </svg>
                  </span>
                </button>

                <div v-if="filter" class="
                      rounded-b-md
                      shadow-md
                      absolute
                      top-10
                      w-full
                      border border-t-0
                      z-40
                      bg-white
                      px-4
                      py-8
                    ">
                  <div class="
                        grid grid-cols-1
                        gap-y-6 gap-x-4
                        sm:grid-cols-6
                        max-w-4xl
                        mx-auto
                      ">
                    <div class="sm:col-span-2">
                      <label for="mail_id" class="block text-base font-semibold text-gray-800">
                        رقم البريد
                      </label>
                      <input v-model="mail_id" type="number" min="1" max="5000" id="mail_id" class="
                            block
                            mt-2
                            h-10
                            w-full
                            rounded-md
                            border border-gray-300
                            hover:shadow-sm
                            focus:outline-none focus:border-gray-300
                            px-2
                          " />
                    </div>

                    <div class="sm:col-span-2">
                      <label for="department" class="block text-base font-semibold text-gray-800">
                        الإدارات المرسلة
                      </label>

                      <div class="relative">
                        <button
                          @click="departmentselect = !departmentselect"
                          @keyup.space.prevent
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
                            border-gray-300
                            hover:shadow-sm
                            focus:outline-none focus:border-gray-300
                            p-2
                          "
                        >
                        <input
                        @click="departmentNameSelected='',departmentIdSelected=''"
                          v-model="departmentNameSelected"
                          type="text"
                          class="h-6 w-full"
                        />

                          <!-- {{ departmentNameSelected }} -->
                        </button>

                        <div v-if="departmentselect" class="
                              border
                              text-sm
                              bg-white
                              border-gray-300
                              p-2
                              absolute
                              w-full
                              z-20
                              shadow
                              h-24
                              overflow-y-scroll
                              rounded-b-md
                            ">
                          <button class="
                                block
                                focus:outline-none
                                w-full
                                my-1
                                text-right
                              " @click="
                                selectdepartment('', 'الكل');
                              departmentselect = !departmentselect;
                                                            ">
                            الكل
                          </button>

                          <button class="
                                block
                                focus:outline-none
                                w-full
                                my-1
                                text-right
                              " @click="
                                selectdepartment(
                                  department.id,
                                  department.departmentName
                                );
                              departmentselect = !departmentselect;
                                                            " v-for="department in filterByTerm" :key="department.id">
                            {{ department.departmentName }}
                          </button>
                        </div>
                      </div>
                    </div>

                    <div class="sm:col-span-2">
                      <label for="measure" class="block text-base font-semibold text-gray-800">
                        الإجراء
                      </label>

                      <div class="relative">
                        <button @click="measureselect = !measureselect" id="measure" class="
                              text-right
                              block
                              mt-2
                              w-full
                              rounded-md
                              h-10
                              border
                              text-sm
                              bg-white
                              border-gray-300
                              hover:shadow-sm
                              focus:outline-none focus:border-gray-300
                              p-2
                            ">
                          {{ measureNameSelected }}
                        </button>

                        <div v-if="measureselect" class="
                              border
                              text-sm
                              bg-white
                              border-gray-300
                              p-2
                              absolute
                              w-full
                              z-20
                              shadow
                              h-24
                              overflow-y-scroll
                              rounded-b-md
                            ">
                          <button class="
                                block
                                focus:outline-none
                                w-full
                                my-1
                                text-right
                              " @click="
                                selectmeasure('', 'الكل');
                              measureselect = !measureselect;
                                                            ">
                            الكل
                          </button>

                          <button class="
                                block
                                focus:outline-none
                                w-full
                                my-1
                                text-right
                              " @click="
                                selectmeasure(
                                  measure.measuresId,
                                  measure.measuresName
                                );
                              measureselect = !measureselect;
                                                            " v-for="measure in measures" :key="measure.measuresId">
                            {{ measure.measuresName }}
                          </button>
                        </div>
                      </div>
                    </div>

                    <div class="sm:col-span-2">
                      <label for="measure" class="block text-base font-semibold text-gray-800">
                        حالة البريد
                      </label>

                      <div class="relative">
                        <button @click="mail_caseselect = !mail_caseselect" id="measure" class="
                              text-right
                              block
                              mt-2
                              w-full
                              rounded-md
                              h-10
                              border
                              text-sm
                              bg-white
                              border-gray-300
                              hover:shadow-sm
                              focus:outline-none focus:border-gray-300
                              p-2
                            ">
                          {{ mail_caseNameSelected }}
                        </button>

                        <div v-if="mail_caseselect" class="
                              border
                              text-sm
                              bg-white
                              border-gray-300
                              p-2
                              absolute
                              w-full
                              z-20
                              shadow
                              h-24
                              overflow-y-scroll
                              rounded-b-md
                            ">
                          <button class="
                                block
                                focus:outline-none
                                w-full
                                my-1
                                text-right
                              " @click="
                                select_mail_case('', 'الكل');
                              mail_caseselect = !mail_caseselect;
                                                            ">
                            الكل
                          </button>

                          <button class="
                                block
                                focus:outline-none
                                w-full
                                my-1
                                text-right
                              " @click="
                                select_mail_case(
                                  mail_case.flag,
                                  mail_case.statename
                                );
                              mail_caseselect = !mail_caseselect;
                                                            " v-for="mail_case in mail_cases" :key="mail_case.flag">
                            {{ mail_case.statename }}
                          </button>
                        </div>
                      </div>
                    </div>

                    <div class="sm:col-span-2">
                      <label for="classification" class="block text-base font-semibold text-gray-800">
                        التصنيف
                      </label>

                      <div class="relative">
                        <button @click="classificationselect = !classificationselect" id="classification" class="
                              text-right
                              block
                              mt-2
                              w-full
                              rounded-md
                              h-10
                              border
                              text-sm
                              bg-white
                              border-gray-300
                              hover:shadow-sm
                              focus:outline-none focus:border-gray-300
                              p-2
                            ">
                          {{ classificationNameSelected }}
                        </button>

                        <div v-if="classificationselect" class="
                              border
                              text-sm
                              bg-white
                              border-gray-300
                              p-2
                              absolute
                              w-full
                              z-20
                              shadow
                              h-24
                              overflow-y-scroll
                              rounded-b-md
                            ">
                          <button class="
                                block
                                focus:outline-none
                                w-full
                                my-1
                                text-right
                              " @click="
                                selectClassification('', 'الكل');
                              classificationselect = !classificationselect;
                                                            ">
                            الكل
                          </button>

                          <button class="
                                block
                                focus:outline-none
                                w-full
                                my-1
                                text-right
                              " @click="
                                selectClassification(
                                  classification.id,
                                  classification.name
                                );
                              classificationselect = !classificationselect;
                                                            " v-for="classification in classifications" :key="classification.id">
                            {{ classification.name }}
                          </button>
                        </div>
                      </div>
                    </div>

                    <div class="sm:col-span-2">
                      <label for="summary" class="block text-base font-semibold text-gray-800">
                        جزء من الملخص
                      </label>
                      <input type="text" v-model="summary" id="summary" class="
                            block
                            mt-2
                            w-full
                            rounded-md
                            h-10
                            text-sm
                            border border-gray-300
                            hover:shadow-sm
                            focus:outline-none focus:border-gray-300
                            p-2
                          " />
                    </div>

                    <!-- <div class="sm:col-span-2" v-if="mailType != 1">
                      <label
                        for="side"
                        class="block text-base font-semibold text-gray-800"
                      >
                        الجهات الخارجية
                      </label>

                      <div class="relative">
                        <button
                          @click="sideselect = !sideselect"
                          id="side"
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
                            border-gray-300
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
                            border-gray-300
                            p-2
                            absolute
                            w-full
                            z-20
                            shadow
                            h-24
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
                              selectsides('', 'الكل');
                              sideselect = !sideselect;
                            "
                          >
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
                              selectsides(side.id, side.section_Name);
                              sideselect = !sideselect;
                            "
                            v-for="side in sides"
                            :key="side.id"
                          >
                            {{ side.section_Name }}
                          </button>
                        </div>
                      </div>
                    </div> -->

                    <div class="sm:col-span-2">
                      <label for="general_incoming_number" class="block text-base font-semibold text-gray-800">
                        رقم الوارد العام
                      </label>
                      <input v-model="general_incoming_number" type="number" min="1" max="5000"
                        id="general_incoming_number" class="
                            block
                            mt-2
                            h-10
                            w-full
                            rounded-md
                            border border-gray-300
                            hover:shadow-sm
                            focus:outline-none focus:border-gray-300
                            px-2
                          " />
                    </div>

                    <div class="sm:col-span-2">
                        <label
                          for="s-number"
                          class="block text-base font-semibold text-gray-800"
                        >
                      رقم إشارة الجهة
                        </label>
                        <input
                          v-model="s_number"
                          type="number"
                          min="1"
                          id="s-number"
                          class="block mt-2 h-10 w-full rounded-md border border-gray-300 hover:shadow-sm focus:outline-none focus:border-gray-300 px-2"
                        />
                    </div>

                    <div class="sm:col-span-2 mt-2 flex justify-between">

                      <div>


                      
                      <label class="block text-base font-semibold text-gray-800">
                        السنة
                      </label>

                      <select id="small"
                        class="block p-2  w-28  text-sm text-gray-900 bg-gray-50 rounded-lg border border-gray-300 focus:ring-blue-500 focus:border-blue-500 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                        v-model="year_filter">

                        <option value="0" selected>اختر السنة</option>
                        <option value="0">إلغاء</option>
                        <option value="2023">2023</option>
                        <option value="2024">2024</option>
                           <!--    <option value="2025">2025</option>
                              <option value="2026">2026</option>
                              <option value="2027">2027</option>
                              <option value="2028">2028</option>
                              <option value="2029">2029</option>
                              <option value="2030">2030</option>
                              <option value="2031">2031</option>
                              <option value="2032">2032</option>
                              <option value="2033">2033</option>
                              <option value="2034">2034</option>
                              <option value="2035">2035</option>
                              <option value="2036">2036</option>
                              <option value="2037">2037</option>
                              <option value="2038">2038</option>
                              <option value="2039">2039</option>
                              <option value="2040">2040</option>
                              <option value="2041">2041</option>
                              <option value="2042">2042</option>
                              <option value="2043">2043</option>
                              <option value="2044">2044</option>
                              <option value="2045">2045</option>
                              <option value="2046">2046</option>
                              <option value="2047">2047</option>
                              <option value="2048">2048</option>
                              <option value="2049">2049</option>
                              <option value="2050">2050</option>
                              <option value="2051">2051</option>
                              <option value="2052">2052</option>
                              <option value="2053">2053</option>
                              <option value="2054">2054</option>
                              <option value="2055">2055</option>
                              <option value="2056">2056</option>
                              <option value="2057">2057</option>
                              <option value="2058">2058</option>
                              <option value="2059">2059</option>
                              <option value="2060">2060</option>
                              <option value="2061">2061</option>
                              <option value="2062">2062</option>
                              <option value="2063">2063</option>
                              <option value="2064">2064</option>
                              <option value="2065">2065</option>
                              <option value="2066">2066</option>
                              <option value="2067">2067</option>
                              <option value="2068">2068</option>
                              <option value="2069">2069</option>
                              <option value="2070">2070</option> -->
                      </select>
                    </div>



                      <div class="mt-6">
                    
                        <button 
                        @click="page_num=1; GetInboxs();filter = !filter"
                        
                        id="search_button" class="
                        px-8
                    mr-2
                    bg-green-700
                    text-green-50
                    rounded-md
                    py-2
                    border border-green-300
                    hover:bg-green-800
                    focus:outline-none
                    flex
                    items-center
                    justify-center
                    col-span-2
                            ">

                            <span class="text-sm font-bold block ml-1"> بحث</span>
                        </button>
                        
                      </div>

                      <div class="mt-6">
                    
                    <button 
                    @click="   
                       search_reset()"
                    
                    id="search_button" class="
                    px-8
                mr-2
                bg-green-700
                text-green-50
                rounded-md
                py-2
                border border-green-300
                hover:bg-green-800
                focus:outline-none
                flex
                items-center
                justify-center
                col-span-2
                        ">

                        <span class="text-sm font-bold block ml-1"> جديد</span>
                    </button>
                    
                  </div>
                    
                    
                    </div>
                      <!-- <div class="sm:col-span-2">
                      <label
                        for="by_date_of_reply"
                        class="block text-base font-semibold text-gray-800"
                      >
                        حسب تاريخ الرد
                      </label>
                      <input
                        v-model="by_date_of_reply"
                        type="checkbox"
                        id="by_date_of_reply"
                        class="
                          block
                          mt-2
                          h-10
                          w-10
                          overflow-hidden
                          rounded-md
                          border border-gray-300
                          hover:shadow-sm
                          focus:outline-none focus:border-gray-300
                          px-2
                        "
                      />
                    </div> -->
                  </div>
                </div>
              </div>

              <button v-if="roles.includes('m')" class="
                    px-8
                    mr-2
                    bg-green-700
                    text-green-50
                    rounded-md
                    py-2
                    border border-green-300
                    hover:bg-green-800
                    focus:outline-none
                    flex
                    items-center
                    justify-center
                    col-span-2
                  " @click="GetMailsToPrint()">
                <span class="text-sm font-bold block ml-1"> طباعة </span>

                <svg class="
                      h-5
                      w-5
                      mr-1
                      text-white
                      block
                      fill-current
                      hover:text-blue-500
                    " id="Capa_1" enable-background="new 0 0 512 512" height="512" viewBox="0 0 512 512" width="512"
                  xmlns="http://www.w3.org/2000/svg">
                  <g>
                    <path
                      d="m437 129h-14v-54c0-41.355-33.645-75-75-75h-184c-41.355 0-75 33.645-75 75v54h-14c-41.355 0-75 33.645-75 75v120c0 41.355 33.645 75 75 75h14v68c0 24.813 20.187 45 45 45h244c24.813 0 45-20.187 45-45v-68h14c41.355 0 75-33.645 75-75v-120c0-41.355-33.645-75-75-75zm-318-54c0-24.813 20.187-45 45-45h184c24.813 0 45 20.187 45 45v54h-274zm274 392c0 8.271-6.729 15-15 15h-244c-8.271 0-15-6.729-15-15v-148h274zm89-143c0 24.813-20.187 45-45 45h-14v-50h9c8.284 0 15-6.716 15-15s-6.716-15-15-15h-352c-8.284 0-15 6.716-15 15s6.716 15 15 15h9v50h-14c-24.813 0-45-20.187-45-45v-120c0-24.813 20.187-45 45-45h362c24.813 0 45 20.187 45 45z" />
                    <path
                      d="m296 353h-80c-8.284 0-15 6.716-15 15s6.716 15 15 15h80c8.284 0 15-6.716 15-15s-6.716-15-15-15z" />
                    <path
                      d="m296 417h-80c-8.284 0-15 6.716-15 15s6.716 15 15 15h80c8.284 0 15-6.716 15-15s-6.716-15-15-15z" />
                    <path
                      d="m128 193h-48c-8.284 0-15 6.716-15 15s6.716 15 15 15h48c8.284 0 15-6.716 15-15s-6.716-15-15-15z" />
                  </g>
                </svg>
              </button>
            </div>

            <div class="
                  w-full
                  mt-4
                  rounded-md
                  flex
                  items-start
                  divide-y-2 divide-gray-200
                ">
              <div class="w-8/12 ml-2">
                البريد

                <div class="
                      flex
                      items-center
                      bg-gray-100
                      w-full
                      text-xs
                      pl-2
                      py-1
                      mt-2
                    ">
                  <div class="w-11/12 flex items-center">
                    <div class="w-16 py-1 pr-2  text-right">رقم الرسالة</div>
                    <div class="w-2/12 mr-2 text-center ">الحالة</div>
                    <div class="w-2/12 text-center">النوع</div>
                    <div class="w-5/12 text-center">الإدارة المرسلة</div>
                    <div class="w-1/12 text-center ">نوع الإجراء</div>
                  </div>

                  <div class="w-1/12 text-center ">الإجراءات</div>
                </div>

                <div class="min-h-64 text-sm bg-gray-100">
                  <div v-for="mail in inboxMails" :key="mail.mail_id" :class="mail.flag | mail_state_inbox" class="
                        group
                        relative
                        border-r-8 border-red-500
                        flex
                        items-center
                        bg-white
                        hover:bg-gray-100
                        pl-2
                      ">
                    <button class="w-11/12 flex items-center  " @click="
                      to_pass_data_to_get_mail_by_id(
                        mail.mail_id,
                        my_department_id,
                        mail.type_of_mail,
                        mail.sends_id,
                        mail.mangment_sender
                      )
                    ">
                      <div class="w-12 pr-2 py-1 text-right">
                        {{ mail.mail_Number }}
                      </div>
                      <div class="w-2/12 mr-4 truncate text-center ">
                        {{ mail.state }}
                      </div>

                      <div class="w-2/12 text-center">
                        {{ mail.type_of_mail | mail_type }}
                      </div>

                      <div class="w-5/12 truncate text-center">
                        {{ mail.mangment_sender }}
                      </div>

                      <div class="w-1/12 text-center ">
                        {{ mail.masure_type }}
                      </div>
                    </button>

                    <div class="w-1/12 flex justify-between items-center">
                      <div class="w-1/3 flex justify-center items-center">
                        <router-link title="عرض التفصيل" :to="{
                          name: 'inbox-show',
                          params: {
                            mail: mail.mail_id,
                            department: my_department_id,
                            type: mail.type_of_mail,
                            sends_id: mail.sends_id,
                          },
                        }" class="">
                          <svg class="w-4 h-4 fill-current hover:text-green-500" version="1.1" id="Capa_1" x="0px" y="0px"
                            viewBox="0 0 18.453 18.453" xml:space="preserve">
                            <rect x="2.711" y="4.058" width="8.23" height="1.334" />
                            <path d="M14.972,14.088c0.638-1.127,0.453-2.563-0.475-3.49c-0.549-0.549-1.279-0.852-2.058-0.852
                                                              c-0.779,0-1.51,0.303-2.059,0.852s-0.852,1.279-0.852,2.059c0,0.777,0.303,1.508,0.852,2.059c0.549,0.547,1.279,0.85,2.057,0.85
                                                              c0.507,0,0.998-0.129,1.434-0.375l3.262,3.262l1.101-1.102L14.972,14.088z M13.664,13.881c-0.652,0.652-1.796,0.652-2.448,0
                                                              c-0.675-0.676-0.675-1.773,0-2.449c0.326-0.326,0.762-0.506,1.225-0.506s0.897,0.18,1.224,0.506s0.507,0.762,0.507,1.225
                                                              S13.991,13.554,13.664,13.881z" />
                            <path d="M13.332,16.3H1.857c-0.182,0-0.329-0.148-0.329-0.328V1.638c0-0.182,0.147-0.329,0.329-0.329
                                                              h11.475c0.182,0,0.328,0.147,0.328,0.329V8.95c0.475,0.104,0.918,0.307,1.31,0.597V1.638C14.97,0.735,14.236,0,13.332,0H1.857
                                                              C0.954,0,0.219,0.735,0.219,1.638v14.334c0,0.902,0.735,1.637,1.638,1.637h11.475c0.685,0,1.009-0.162,1.253-0.76l-0.594-0.594
                                                              C13.772,16.347,13.426,16.3,13.332,16.3z" />
                            <rect x="2.711" y="7.818" width="8.23" height="1.334" />
                          </svg>
                        </router-link>
                      </div>

                      <div class="w-1/3 flex justify-center items-center">
                        <button v-if="roles.includes('s')" @click="GetAllDocuments(mail.mail_id, 1)" title="عرض المستندات"
                          class="focus:outline-none">
                          <svg class="w-4 h-4 fill-current hover:text-blue-500" id="Capa_1"
                            enable-background="new 0 0 512 512" height="512" viewBox="0 0 512 512" width="512"
                            xmlns="http://www.w3.org/2000/svg">
                            <g>
                              <path
                                d="m437 129h-14v-54c0-41.355-33.645-75-75-75h-184c-41.355 0-75 33.645-75 75v54h-14c-41.355 0-75 33.645-75 75v120c0 41.355 33.645 75 75 75h14v68c0 24.813 20.187 45 45 45h244c24.813 0 45-20.187 45-45v-68h14c41.355 0 75-33.645 75-75v-120c0-41.355-33.645-75-75-75zm-318-54c0-24.813 20.187-45 45-45h184c24.813 0 45 20.187 45 45v54h-274zm274 392c0 8.271-6.729 15-15 15h-244c-8.271 0-15-6.729-15-15v-148h274zm89-143c0 24.813-20.187 45-45 45h-14v-50h9c8.284 0 15-6.716 15-15s-6.716-15-15-15h-352c-8.284 0-15 6.716-15 15s6.716 15 15 15h9v50h-14c-24.813 0-45-20.187-45-45v-120c0-24.813 20.187-45 45-45h362c24.813 0 45 20.187 45 45z" />
                              <path
                                d="m296 353h-80c-8.284 0-15 6.716-15 15s6.716 15 15 15h80c8.284 0 15-6.716 15-15s-6.716-15-15-15z" />
                              <path
                                d="m296 417h-80c-8.284 0-15 6.716-15 15s6.716 15 15 15h80c8.284 0 15-6.716 15-15s-6.716-15-15-15z" />
                              <path
                                d="m128 193h-48c-8.284 0-15 6.716-15 15s6.716 15 15 15h48c8.284 0 15-6.716 15-15s-6.716-15-15-15z" />
                            </g>
                          </svg>
                        </button>
                      </div>

                      <div class="w-1/3 flex justify-center items-center">
                        <!-- v-if="roles.includes('g')" -->
                        <button :class="mail.flag != 2 ? 'hidden' : ''" @click="read_it_mail(mail.mail_id)"
                          title="تأكيد قراءة البريد" class="focus:outline-none">
                          <svg class="
                                w-4
                                h-4
                                fill-current
                                text-gray-400
                                hover:text-green-500
                              " id="Capa_1" enable-background="new 0 0 512 512" height="512" viewBox="0 0 512 512"
                            width="512" xmlns="http://www.w3.org/2000/svg">
                            <g>
                              <path
                                d="m153 157.328c-4.142 0-7.5 3.357-7.5 7.5s3.358 7.5 7.5 7.5h206c4.142 0 7.5-3.357 7.5-7.5s-3.358-7.5-7.5-7.5z" />
                              <path
                                d="m359 235.578c4.142 0 7.5-3.357 7.5-7.5s-3.358-7.5-7.5-7.5h-60.809c-12.709-7.789-27.642-12.288-43.608-12.288-16.628 0-32.126 4.894-45.166 13.288h-56.417c-4.142 0-7.5 3.357-7.5 7.5s3.358 7.5 7.5 7.5h38.926c-11.593 13.094-19.148 29.827-20.718 48.25h-18.208c-4.142 0-7.5 3.357-7.5 7.5s3.358 7.5 7.5 7.5h18.259c1.746 18.709 9.668 35.647 21.711 48.75h-39.97c-4.142 0-7.5 3.357-7.5 7.5s3.358 7.5 7.5 7.5h58.244c12.649 7.687 27.486 12.117 43.339 12.117 15.738 0 30.688-4.321 43.518-12.117h60.899c4.142 0 7.5-3.357 7.5-7.5s-3.358-7.5-7.5-7.5h-42.671c5.17-5.667 9.62-12.112 13.175-19.229 1.851-3.706.348-8.21-3.358-10.062-3.705-1.85-8.21-.347-10.061 3.358-11.723 23.47-35.29 38.049-61.503 38.049-37.882 0-68.702-30.819-68.702-68.702s30.82-68.703 68.702-68.703c37.883 0 68.703 30.82 68.703 68.703v.21c0 .024.003.047.003.071 0 .018-.003.036-.003.054 0 4.143 3.358 7.5 7.5 7.5h28.215c4.142 0 7.5-3.357 7.5-7.5s-3.358-7.5-7.5-7.5h-21.042c-1.61-18.891-9.503-36.015-21.599-49.25h42.641z" />
                              <path
                                d="m359 412.328h-206c-4.142 0-7.5 3.357-7.5 7.5s3.358 7.5 7.5 7.5h206c4.142 0 7.5-3.357 7.5-7.5s-3.358-7.5-7.5-7.5z" />
                              <path
                                d="m418.594 43.254h-57.432c-1.703-7.296-8.247-12.754-16.055-12.754h-36.607v-1.652c0-15.907-12.941-28.848-28.847-28.848h-47.306c-15.906 0-28.847 12.941-28.847 28.848v1.652h-36.607c-7.808 0-14.351 5.458-16.055 12.754h-57.432c-15.164 0-27.5 12.337-27.5 27.5v413.746c0 15.163 12.336 27.5 27.5 27.5h91.423c4.142 0 7.5-3.357 7.5-7.5s-3.358-7.5-7.5-7.5h-91.423c-6.893 0-12.5-5.607-12.5-12.5v-413.746c0-6.893 5.607-12.5 12.5-12.5h56.986v15h-41.986c-6.893 0-12.5 5.607-12.5 12.5v383.746c0 6.893 5.607 12.5 12.5 12.5h295.188c6.893 0 12.5-5.607 12.5-12.5v-383.746c0-6.893-5.607-12.5-12.5-12.5h-41.986v-15h56.986c6.893 0 12.5 5.607 12.5 12.5v413.746c0 6.893-5.607 12.5-12.5 12.5h-198.765c-4.142 0-7.5 3.357-7.5 7.5s3.358 7.5 7.5 7.5h198.765c15.164 0 27.5-12.337 27.5-27.5v-413.746c0-15.163-12.337-27.5-27.5-27.5zm-253.201 3.746c0-.827.673-1.5 1.5-1.5h44.107c4.142 0 7.5-3.357 7.5-7.5v-9.152c0-7.636 6.212-13.848 13.847-13.848h47.306c7.635 0 13.847 6.212 13.847 13.848v9.152c0 4.143 3.358 7.5 7.5 7.5h44.107c.827 0 1.5.673 1.5 1.5 0 47.697.075 57.448-.045 59.588-.054.963-.705 1.417-1.455 1.417h-178.214c-.827 0-1.5-.673-1.5-1.5 0-24.736 0-29.663 0-59.505zm235.701 420h-290.188v-378.746h39.486v18.251c0 9.101 7.405 16.5 16.5 16.5h178.215c9.046 0 16.5-7.377 16.5-16.5v-18.251h39.486v378.746z" />
                              <path
                                d="m283.604 261.149-46.186 44.447-10.337-20.891c-1.837-3.713-6.338-5.234-10.048-3.396-3.712 1.837-5.233 6.335-3.396 10.048l14.879 30.07c2.242 4.529 8.258 5.603 11.923 2.078l53.566-51.549c2.984-2.872 3.076-7.62.204-10.604s-7.62-3.074-10.605-.203z" />
                            </g>
                          </svg>
                        </button>
                      </div>
                    </div>

                    <div class="
                          group-hover:block
                          items-end
                          hidden
                          absolute
                          z-50
                          w-10/12
                          bottom-20
                          left-0
                          min-h-32
                          h-full
                          bg-white
                          p-2
                          border-4
                          rounded-md
                          overflow-y-auto
                        ">
                      <div class="flex items-center justify-between">
                        <p class="font-bold">ملخص الرسالة</p>

                        <div class="underline">
                        <!--  تاريخ الارسال - {{ mail.send_time }}-->
                         تاريخ الارسال - {{ mail.send_time.substring(0,10)}}
                        </div>
                        <div class="underline">
                         <!-- وقت الارسال - {{ mail.time }}-->
                            وقت الارسال - {{ mail.send_time.substring(11,16) }}
                        </div>
                      </div>

                      <p class="mt-2">
                        {{ mail.summary }}
                      </p>
                    </div>
                  </div>
                </div>

                <div class="
                      flex
                      justify-end
                      mt-8
                      mx-auto
                      px-4
                      sm:px-6
                      lg:px-8
                      w-full
                      bg-white
                      relative
                    ">
                  <pagination dir="rtl" v-model="page_num" :per-page="page_size" :records="total_of_transaction"
                    @paginate="GetInboxs" class="z-10" />
                  <div class="">
                    <div class="
                          absolute
                          z-0
                          top-0
                          py-2
                          left-0
                          w-full
                          text-left
                          p-1
                          flex
                          bg-white
                          items-center
                          justify-end
                        ">
                      <span class="text-xs ml-1"> عدد الرسائل </span>
                      {{ total_of_transaction }}
                    </div>
                  </div>
                </div>
              </div>

              <div v-if="roles.includes('r')" class="w-4/12 mr-2">
                الردود - {{ mangment_sender_to_get_mail_by_id }}

                <div v-if="mangment_sender_to_get_mail_by_id != ''" class="bg-gray-100 w-full text-sm p-2 mt-2">
                  <div id="scroll" class="
                        h-56
                        overflow-y-scroll
                        mt-3
                        rounded-lg
                        py-
                        border border-gray-300
                      ">
                    <div v-for="(reply, index) in replies" :key="index" :class="
                      reply.reply.to == my_department_id
                        ? ' flex-row-reverse justify-start'
                        : 'justify-start'
                    " class="w-full my-0.5 flex px-2">
                      <div class="">
                        <div class="flex" :class="
                          reply.reply.to == my_department_id
                            ? '  justify-end'
                            : 'justify-end flex-row-reverse'
                        ">


                          <button v-if="reply.reply.to != my_department_id && reply.reply.userId == my_user_id"
                            @click="alert_delete_document = true, reply_id_to_delete = reply.reply.replyId" type="button"
                            class="
                                
                                  hover:bg-red-500
                                  duration-500
                                  p-1
                                  rounded-full
                                  focus:outline-none
                                  ml-2
                                ">
                            <svg class="
                                    w-4
                                    h-4
                                    stroke-current
                                    text-red
                                    mx-auto
                                  " width="24" height="25" viewBox="0 0 24 25" fill="none"
                              xmlns="http://www.w3.org/2000/svg">
                              <path d="M3 6.5H5H21" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" />
                              <path
                                d="M8 6.5V4.5C8 3.96957 8.21071 3.46086 8.58579 3.08579C8.96086 2.71071 9.46957 2.5 10 2.5H14C14.5304 2.5 15.0391 2.71071 15.4142 3.08579C15.7893 3.46086 16 3.96957 16 4.5V6.5M19 6.5V20.5C19 21.0304 18.7893 21.5391 18.4142 21.9142C18.0391 22.2893 17.5304 22.5 17 22.5H7C6.46957 22.5 5.96086 22.2893 5.58579 21.9142C5.21071 21.5391 5 21.0304 5 20.5V6.5H19Z"
                                stroke-width="2" stroke-linecap="round" stroke-linejoin="round" />
                            </svg>
                          </button>




                          <div v-if="alert_delete_document" class="
          w-screen
          h-full
          flex
          justify-center
          items-center
          absolute
          inset-0
          z-50
          overflow-hidden
          bg-black bg-opacity-70
        ">
                            <div class="
            bg-yellow-100
            rounded-md
            w-1/3
            py-10
            flex flex-col
            justify-center
            items-center
          ">
                              <div class="">
                                <svg class="w-20 h-20 stroke-current text-red-600" fill="none" stroke="currentColor"
                                  viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
                                  <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                    d="M12 9v2m0 4h.01m-6.938 4h13.856c1.54 0 2.502-1.667 1.732-3L13.732 4c-.77-1.333-2.694-1.333-3.464 0L3.34 16c-.77 1.333.192 3 1.732 3z">
                                  </path>
                                </svg>
                              </div>
                              <p class="text-xl font-bold mt-4">هل انت متأكد من عملية الحذف؟</p>
                              <p class="text-gray-600">لن تتمكن من استرداد الرد بعد حذفه.</p>

                              <div class="mt-6">
                                <button @click="deletereply()" class="
                bg-red-600
                hover:bg-red-700 hover:shadow-lg
                duration-200
                rounded
                text-white
                w-32
                py-1
                ml-2
              ">
                                  نعم متأكد
                                </button>
                                <button @click="alert_delete_document = false" class="
                bg-gray-400
                hover:bg-gray-700 hover:shadow-lg
                duration-200
                rounded
                text-white
                w-32
                py-1
                mr-2
              ">
                                  إلغاء
                                </button>
                              </div>
                            </div>
                          </div>
                          <div v-if="reply.resources == true" class="mx-2">
                            <button v-if="roles.includes('s')" @click="GetResources_ById(reply.reply.replyId)" class="
                                  px-2
                                  text-xs
                                  rounded
                                  leading-9
                                  text-white
                                  bg-red-400
                                  flex
                                  items-center
                                ">
                              عرض الصور
                              <svg class="stroke-current mr-2 w-6 h-6" width="24" height="24" viewBox="0 0 24 24"
                                fill="none" xmlns="http://www.w3.org/2000/svg">
                                <path
                                  d="M19 3H5C3.89543 3 3 3.89543 3 5V19C3 20.1046 3.89543 21 5 21H19C20.1046 21 21 20.1046 21 19V5C21 3.89543 20.1046 3 19 3Z"
                                  stroke-width="1" stroke-linecap="round" stroke-linejoin="round" />
                                <path
                                  d="M8.5 10C9.32843 10 10 9.32843 10 8.5C10 7.67157 9.32843 7 8.5 7C7.67157 7 7 7.67157 7 8.5C7 9.32843 7.67157 10 8.5 10Z"
                                  stroke-width="1" stroke-linecap="round" stroke-linejoin="round" />
                                <path d="M21 15L16 10L5 21" stroke-width="1" stroke-linecap="round"
                                  stroke-linejoin="round" />
                              </svg>
                            </button>
                          </div>




                          <div :class="
                            reply.reply.to == my_department_id
                              ? 'bg-gray-700'
                              : 'bg-blue-700'
                          " class="
                                text-white
                                max-w-10/12
                                py-0
                                leading-9
                                px-2
                                rounded
                              ">
                            {{ reply.reply.mail_detail }}
                          </div>

                        </div>

                        <div class="mt-1 text-sm" :class="
                          reply.reply.to == my_department_id
                            ? 'text-left'
                            : 'text-right'
                        ">
                          {{ reply.reply.date }}
                        </div>


                      </div>



                    </div>
                  </div>




                  <div class="flex justify-between items-center mt-4">
                    <div class="w-8/12 flex justify-between">
                      <div class="w-full">
                        <textarea id="" class="
                              block
                              w-full
                              h-24
                              text-sm
                              rounded-md
                              border border-green-400
                              hover:shadow-sm
                              focus:outline-none focus:border-gray-300
                              p-2
                            " v-model="reply_to_add">
                          </textarea>
                      </div>
                    </div>

                    <div class="w-3/12">
                      <div class="">
                        <a id="a4" @click="reply1()">
                          <label v-if="reply_to_add != ''" class="
                                w-full
                                h-10
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
                              ">
                            <svg class="w-4 h-4 ml-1" fill="currentColor" version="1.1" id="Capa_1"
                              xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" x="0px"
                              y="0px" viewBox="0 0 512 512" style="enable-background: new 0 0 512 512"
                              xml:space="preserve">
                              <g>
                                <g>
                                  <g>
                                    <path d="M509.501,116.968c1.6-1.6,2.499-3.771,2.499-6.035V76.8c-0.019-1.015-0.222-2.019-0.598-2.962
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
                                                  h477.867V102.4z" />
                                    <path d="M68.267,375.467H51.2c-9.421,0.011-17.056,7.646-17.067,17.067V409.6c0.011,9.421,7.645,17.056,17.067,17.067h17.067
                                                  c9.421-0.011,17.056-7.645,17.067-17.067v-17.067C85.323,383.112,77.688,375.477,68.267,375.467z M51.2,409.6v-17.067h17.067
                                                  l0.012,17.067H51.2z" />
                                    <path d="M388.067,136.533H123.933c-7.21,0.012-13.639,4.545-16.071,11.333L53,301.458c-1.863,5.227-1.07,11.034,2.127,15.57
                                                  s8.399,7.236,13.948,7.238h373.85c5.548-0.003,10.748-2.701,13.945-7.235c3.197-4.534,3.991-10.339,2.13-15.565l-54.862-153.6
                                                  C401.705,141.079,395.277,136.546,388.067,136.533z M69.067,307.225l0.009-0.017V307.2l54.858-153.6h264.129l54.862,153.6
                                                  L69.067,307.225z" />
                                    <path
                                      d="M128.009,221.867c1.682-0.001,3.326-0.5,4.725-1.434l25.6-17.067c3.872-2.633,4.899-7.894,2.302-11.79
                                                  s-7.849-4.971-11.768-2.409l-25.6,17.067c-3.13,2.087-4.524,5.977-3.432,9.577C120.927,219.41,124.247,221.87,128.009,221.867z" />
                                    <path
                                      d="M179.2,187.733c2.855,0.03,5.532-1.385,7.115-3.761c1.584-2.376,1.86-5.39,0.735-8.014
                                                  c-1.031-2.685-3.362-4.656-6.181-5.227c-2.819-0.571-5.733,0.338-7.728,2.41c-0.755,0.829-1.363,1.782-1.796,2.817
                                                  c-1.122,2.625-0.844,5.639,0.74,8.013C173.67,186.346,176.346,187.761,179.2,187.733z" />
                                    <path d="M225.542,172.183l-110.933,76.8c-3.071,2.125-4.403,6.001-3.287,9.565c1.116,3.564,4.419,5.989,8.154,5.984
                                                  c1.733,0.001,3.426-0.529,4.85-1.517l110.933-76.8c3.864-2.687,4.824-7.996,2.144-11.865
                                                  C234.723,170.482,229.417,169.512,225.542,172.183z" />
                                    <path
                                      d="M463.275,407.125c0.829,0.753,1.78,1.359,2.813,1.792c2.066,0.911,4.421,0.911,6.487,0
                                                  c1.034-0.433,1.987-1.039,2.817-1.792c0.751-0.832,1.357-1.784,1.792-2.817c0.438-1.026,0.67-2.127,0.683-3.242
                                                  c-0.016-0.545-0.073-1.088-0.171-1.625c-0.082-0.563-0.255-1.109-0.513-1.617c-0.187-0.546-0.447-1.064-0.771-1.542
                                                  c-0.313-0.446-0.654-0.872-1.021-1.275c-0.816-0.771-1.772-1.379-2.817-1.792c-3.177-1.341-6.849-0.634-9.3,1.792l-1.025,1.275
                                                  c-0.324,0.477-0.583,0.996-0.771,1.542c-0.258,0.507-0.43,1.053-0.508,1.617c-0.1,0.536-0.157,1.08-0.171,1.625
                                                  c0.012,1.115,0.243,2.216,0.679,3.242C461.914,405.342,462.521,406.295,463.275,407.125z" />
                                    <path d="M431.954,408.916c2.067,0.911,4.421,0.911,6.487,0c1.034-0.433,1.987-1.039,2.817-1.792
                                                  c0.751-0.832,1.357-1.784,1.792-2.817c0.437-1.025,0.669-2.126,0.683-3.241c-0.016-0.545-0.073-1.088-0.171-1.625
                                                  c-0.082-0.563-0.255-1.109-0.513-1.617c-0.187-0.546-0.447-1.064-0.771-1.542c-0.338-0.425-0.679-0.85-1.021-1.275
                                                  c-0.83-0.753-1.783-1.359-2.817-1.792c-3.178-1.333-6.845-0.626-9.3,1.792l-1.025,1.275c-0.324,0.477-0.583,0.996-0.771,1.542
                                                  c-0.258,0.507-0.43,1.053-0.508,1.617c-0.1,0.536-0.157,1.08-0.171,1.625c-0.029,1.119,0.204,2.229,0.679,3.242
                                                  C428.126,406.449,429.813,408.136,431.954,408.916z" />
                                  </g>
                                </g>
                              </g>
                            </svg>

                            <span class="text-xs leading-normal"> تصوير </span>
                          </label>
                        </a>

                        <!-- <input
                            class="hidden"
                            type="button"
                            @click="scanToReply"
                          />-->
                      </div>

                      <button v-if="reply_to_add != ''" @click="AddReply()" class="
                            mt-2
                            w-full
                            flex
                            items-center
                            justify-center
                            h-10
                            py-1
                            bg-white
                            rounded-lg
                            text-blue-600
                            tracking-wide
                            border border-blue-600
                            cursor-pointer
                            hover:text-white hover:bg-blue-600
                            focus:outline-none
                            duration-300
                          ">
                        <span class="leading-normal">إرسال</span>
                        <svg class="w-4 h-4 mr-2" viewBox="0 0 441 441" fill="currentColor"
                          xmlns="http://www.w3.org/2000/svg">
                          <g clip-path="url(#clip0)">
                            <path
                              d="M26.2637 181.168L382.073 33.5286C397.063 27.3081 413.997 30.0445 426.267 40.6664C438.538 51.29 443.669 67.6578 439.659 83.384L404.694 220.501L439.659 357.617C443.669 373.343 438.538 389.711 426.268 400.335C413.974 410.979 397.036 413.681 382.073 407.472L26.2637 259.833C10.0639 253.111 0.000120282 238.04 0.000120282 220.501C0.000120282 202.961 10.0639 187.89 26.2637 181.168ZM36.1681 235.966L391.977 383.605C397.96 386.087 404.456 385.039 409.354 380.798C414.252 376.558 416.22 370.279 414.619 364.001L381.321 233.42H252.927C245.791 233.42 240.007 227.636 240.007 220.5C240.007 213.364 245.791 207.579 252.927 207.579H381.32L414.619 76.9998C416.22 70.7224 414.252 64.4434 409.354 60.203C404.457 55.9627 397.963 54.9136 391.978 57.396L36.1681 205.035C26.5859 209.011 25.8408 217.878 25.8408 220.501C25.8408 223.123 26.5859 231.99 36.1681 235.966Z"
                              fill="currentColor" />
                          </g>
                          <defs>
                            <clipPath id="clip0">
                              <rect width="441" height="441" fill="white" transform="matrix(-1 0 0 1 441 0)" />
                            </clipPath>
                          </defs>
                        </svg>
                      </button>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </main>
        </div>
      </div>
    </div>

    <div v-if="screenFreeze" class="
          w-screen
          h-screen
          bg-black bg-opacity-30
          absolute
          inset-0
          z-50
          flex
          justify-center
          items-center
        ">
      <div v-if="loading" class="">
        <svgLoadingComponent></svgLoadingComponent>
      </div>

      <div v-if="there_are_no_documents" class="bg-white w-96 h-32 flex justify-center items-center">
        لا توجد مستندات لهذا البريد.
      </div>
    </div>

    <div v-if="show_images_model" class="w-screen h-full absolute inset-0 z-50 overflow-hidden">
      <div class="relative">
        <div v-if="to_test_print" id="printMe" class="bg-black bg-opacity-50 h-screen-100">
          <div v-for="image in show_images" :key="image.id" class="h-screen-100">
            <img :src="image.path" alt="" class="h-full w-full object-contain" />
          </div>
        </div>

        <div v-if="to_test_print" id="print_one_dec" class="bg-black bg-opacity-50 h-screen-100">
          <div class="h-screen-100">
            <img :src="testimage" alt="" class="h-full w-full object-contain" />
          </div>
        </div>

        <div class="
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
            ">

            <button type="button" @click="image_rotate = !image_rotate"  class="absolute text-white font-bold px-8 z-50 bg-yellow-500 py-2 right-12">
              تدوير الصفحة
            </button>


          <div class="max-w-3xl mx-auto relative">
            <div class="
                  absolute
                  top-6
                  z-50
                  flex
                  justify-between
                  items-center
                  w-full
                ">
              <button @click="show_images_model = false">
                <svg class="w-8 h-8 stroke-current text-red-500 hover:text-red-400" fill="none" stroke="currentColor"
                  viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
                  <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                    d="M10 14l2-2m0 0l2-2m-2 2l-2-2m2 2l2 2m7-2a9 9 0 11-18 0 9 9 0 0118 0z"></path>
                </svg>
              </button>

              <button v-if="roles.includes('k')" @click="print_image()" v-print="'#print_one_dec'" class="
                    bg-blue-500
                    hover:bg-blue-400
                    px-4
                    py-2
                    rounded-lg
                    text-white
                  ">
                طباعة المستند الحالي
              </button>

              <button v-if="roles.includes('k')" @click="print_image()" v-print="'#printMe'" class="
                    bg-blue-500
                    hover:bg-blue-400
                    px-4
                    py-2
                    rounded-lg
                    text-white
                  ">
                طباعة كافة المستندات
              </button>
            </div>

            <div class="h-screen-93 mt-4">


              <div class="h-screen-93 mt-4">
              <img
                :src="testimage"
                alt="image"
                :class="image_rotate ? 'rotate-0' : 'rotate-180'"
                class="h-full w-full object-contain transform"
              />
            </div>


              <!-- <img :src="testimage" alt="image" class="h-full w-full object-contain" /> -->
            </div>

            <div class="
                  absolute
                  bottom-3
                  z-50
                  bg-gray-100
                  flex
                  justify-between
                  items-center
                  w-full
                  mx-auto
                  mt-4
                ">
              <div v-if="testimage" class="w-12 h-8">
                <button title="prev" @click="previousImage()" class="
                      focus:outline-none
                      w-12
                      h-8
                      bg-gray-300
                      rounded
                      flex
                      justify-center
                      items-center
                    ">
                  <svg class="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24"
                    xmlns="http://www.w3.org/2000/svg">
                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5l7 7-7 7"></path>
                  </svg>
                </button>
              </div>

              <div class="text-black">
                {{ indextotest + 1 }} / {{ show_images.length }}
              </div>

              <div class="w-12 h-8">
                <button title="next" @click="nextImage()" class="
                      focus:outline-none
                      w-12
                      h-8
                      bg-gray-300
                      rounded
                      flex
                      justify-center
                      items-center
                    ">
                  <svg class="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24"
                    xmlns="http://www.w3.org/2000/svg">
                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M15 19l-7-7 7-7"></path>
                  </svg>
                </button>
              </div>
            </div>
          </div>
        </div>
      </div>

      <!-- w-full h-full rounded object-contain -->
    </div>

    <div v-if="show_current_reply_image_to_for_bigger_screen_model"
      class="w-screen h-full absolute inset-0 z-50 overflow-hidden">
      <div class="relative">
        <div id="print_reply_doc_n" class="bg-black bg-opacity-50 h-screen-100">
          <div class="h-screen-100">
            <img :src="reply_image_of_doc" alt="" class="h-full w-full object-contain" />
          </div>
        </div>

        <div class="
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
            ">
          <div class="max-w-3xl mx-auto relative">
            <div class="
                  absolute
                  top-6
                  z-50
                  flex
                  justify-between
                  items-center
                  w-full
                ">
              <button @click="
                show_current_reply_image_to_for_bigger_screen_model = false
              ">
                <svg class="w-8 h-8 stroke-current text-red-500 hover:text-red-400" fill="none" stroke="currentColor"
                  viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
                  <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                    d="M10 14l2-2m0 0l2-2m-2 2l-2-2m2 2l2 2m7-2a9 9 0 11-18 0 9 9 0 0118 0z"></path>
                </svg>
              </button>

              <button v-if="roles.includes('k')" v-print="'#print_reply_doc_n'" class="
                    bg-blue-500
                    hover:bg-blue-400
                    px-4
                    py-2
                    rounded-lg
                    text-white
                  ">
                طباعة المستند الحالي
              </button>
            </div>

            <div class="h-screen-93 mt-4">
              <img :src="reply_image_of_doc" alt="image" class="h-full w-full object-contain" />
            </div>

            <div class="
                  absolute
                  bottom-3
                  z-50
                  bg-gray-100
                  flex
                  justify-between
                  items-center
                  w-full
                  mx-auto
                  mt-4
                ">
              <div class="w-12 h-8">
                <button title="prev" v-if="reply_doc_number > 1" @click="Next_prevent_GetResources_ById('prev')" class="
                      focus:outline-none
                      w-12
                      h-8
                      bg-gray-300
                      rounded
                      flex
                      justify-center
                      items-center
                    ">
                  <svg class="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24"
                    xmlns="http://www.w3.org/2000/svg">
                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5l7 7-7 7"></path>
                  </svg>
                </button>
              </div>

              <div class="text-black">
                {{ reply_doc_number }} / {{ reply_total_of_doc }}
              </div>

              <div class="w-12 h-8">
                <button v-if="reply_doc_number < reply_total_of_doc" title="next"
                  @click="Next_prevent_GetResources_ById('next')" class="
                      focus:outline-none
                      w-12
                      h-8
                      bg-gray-300
                      rounded
                      flex
                      justify-center
                      items-center
                    ">
                  <svg class="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24"
                    xmlns="http://www.w3.org/2000/svg">
                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M15 19l-7-7 7-7"></path>
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
  console.log("destroyed_inbox.vue")
  if(this.conn!=null){
 if (this.conn.readystate!=3){
   console.log("readystate destory_inbox.vue="+this.conn.readyState);
           this.conn.close();
           console.log("close_inbox.vue");
         this.conn=null;
 }
}},
  mounted() {
    //21/1/2023*********************websocket
  /*  this.conn = new WebSocket("ws://localhost:58316/ws");
    
this.conn.onerror =(error) =>{
console.log("inbox WebSocket Error " + error);
};

this.conn.onclose =(event) =>{
console.log("inbox.vue readystate"+this.conn.readyState);
console.log(" inbox.vue WebSocket close");
consol.log("code inbox.vue="+event.code);

};
    this.conn.onmessage = (event) => {
      console.log("inbox onmessage");
      let scannedImage = event.data;
      let mgs = JSON.parse(scannedImage);
      this.imagesscantest = mgs;

      var ind = this.imagesscantest.index;
       console.log("inbox index="+ind);
      if (ind == 1) {
        this.keyid = this.imagesscantest.keyid;
        console.log("inbox keyid="+this.keyid);
      } else {
         console.log("inbox.vue else");
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

    //*********************end websocket 21/1/2023

    var date = new Date();

    var month = date.getMonth() + 1;
    var day = date.getDate();


       var month1 = "01";
    var day1 = "01";

    if (month < 10) month = "0" + month;
    if (day < 10) day = "0" + day;

    this.date_from = "2023" + "-" + month1 + "-" + day1;
    this.date_to = date.getFullYear() + "-" + month + "-" + day;

    this.my_user_id = localStorage.getItem("AY_LW");
    this.my_department_id = localStorage.getItem("chrome");
    this.roles = localStorage.getItem("Az07");

    this.GetInboxs();

    this.GetAllmail_cases();
    this.GetAllClassifications();
    this.GetAllDepartments();
    this.GetAllSides();
    this.GetAllMeasures();
  },

  computed: {
    filterByTerm() {
      return this.departments.filter((department) => {
        return department.departmentName.includes(this.departmentNameSelected);
      });
    },
  },


  watch: {


    // year_filter: function() {
    //   this.page_num = 1;
    //   this.GetInboxs();
    // },
     mailType: function () {
      this.page_num = 1;
      this.GetInboxs();
    },
//************code stop 1/2/2024
   // departmentNameSelected: function() {

    //  if(this.departmentNameSelected==""){
     // this.page_num = 1;
    //  this.GetInboxs();
    //  }
   // },

   
   // date_from: function () {
   //   this.page_num = 1;
  //    this.GetInboxs();
   // },
   // date_to: function () {
    //  this.page_num = 1;
   //   this.GetInboxs();
   // },
//******end code stop 1/2/2024

    // mail_id: function () {
    //   this.page_num = 1;
    //   this.GetInboxs();
    // },

    // general_incoming_number: function () {
    //   this.page_num = 1;
    //   this.GetInboxs();
    // },

    // summary: function () {
    //   this.page_num = 1;
    //   this.GetInboxs();
    // },
    // departmentIdSelected: function () {
    //   this.page_num = 1;
    //   this.GetInboxs();
    // },
    // sideIdSelected: function () {
    //   this.page_num = 1;
    //   this.GetInboxs();
    // },
    // measureIdSelected: function () {
    //   this.page_num = 1;
    //   this.GetInboxs();
    // },
    // classificationIdSelected: function () {
    //   this.page_num = 1;
    //   this.GetInboxs();
    // },

    // mail_caseIdSelected: function () {
    //   this.page_num = 1;
    //   this.GetInboxs();
    // },
    // by_date_of_reply: function () {
    //   this.page_num = 1;
    //   this.GetInboxs();
    // },

    // s_number: function () {
    //   this.page_num = 1;
    //   this.GetInboxs();
    // },

  },

  components: {
    asideComponent,
    navComponent,
    svgLoadingComponent,
  },

  data() {
    return {
      image_rotate : true,

      
//*********21/1/2023
    keyid: "",
    conn: null,
//**********end 21/1/2023


      s_number:"",
      reply_id_to_delete:"",
      alert_delete_document:false,
      roles: [],
      from_reply_or_general: "",
      year_filter:0,
      by_date_of_reply: false,
      general_incoming_number: "",
      indexOfimagesToShow: 0,
      imagesToSend: [],
      replies: [],
      to_test_print: false,
      sends_id: "",
      department_Id: "",

      reply_to_add: "",

      testimage: "",
      indextotest: 0,

      show_images: [],
      show_images_model: false,

      total_of_transaction: 0,
      my_user_id: "",
      my_department_id: "",

      inboxMails: [],

      mail_id: "",

      classifications: [],
      classificationselect: false,
      classificationNameSelected: "",
      classificationIdSelected: "",

      departments: [],
      departmentselect: false,
      departmentNameSelected: "",
      departmentIdSelected: "",

      sides: [],
      sideselect: false,
      sideNameSelected: "",
      sideIdSelected: "",

      measures: [],
      measureselect: false,
      measureNameSelected: "",
      measureIdSelected: "",

      mail_cases: [],
      mail_caseselect: false,
      mail_caseNameSelected: "",
      mail_caseIdSelected: "",

      mailType: 0,

      summary: "",

      filter: false,
      loading: false,
      screenFreeze: false,
      there_are_no_documents: false,

      date_from: "",
      date_to: "",

      page_size: 10,
      page_size2: 100000,
      page_num: 1,

      mailId_to_get_mail_by_id: "",
      my_department_id_to_get_mail_by_id: "",
      to_test_passing_mail_type_to_get_mail_by_id: "",
      sends_id_to_get_mail_by_id: "",
      mangment_sender_to_get_mail_by_id: "",

      mails_to_print: [],

      reply_doc_number: 0,
      reply_total_of_doc: 0,

      reply_image_of_doc: "",
      reply_id_of_doc: "",
      reply_image_to_print_n: [],

      reply_image_to_print_n_model: false,
      show_current_reply_image_to_for_bigger_screen_model: false,

      id_reply_image: "",
    };
  },

  methods: {

  

    search_reset(){

this.mail_id = "";
this.summary = "";
this.general_incoming_number ="";
this.selectdepartment('', 'الكل');
this.selectmeasure('', 'الكل');
this.select_mail_case('', 'الكل');
this.selectClassification('', 'الكل');
this.year_filter="2023"

this.s_number = "";




},



    deletereply(){

        
      this.alert_delete_document = false;

      this.$http.mailService
        .delete_reply(
          Number(this.reply_id_to_delete),Number(localStorage.getItem("AY_LW"))
        )
        .then((res) => {

          

          this.getMailById();
          // this.to_pass_data_to_get_mail_by_id(
          //                 this.mail.mail_id,
          //                 this.my_department_id,
          //                 this.mail.type_of_mail,
          //                 this.mail.sends_id,
          //                 this.mail.mangment_sender
          //               )
                      
        })
        .catch((err) => {
     
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

    //************************
    reply1() {

if(this.conn==null){
     console.log("conn="+this.conn);
      this.conn = new WebSocket("ws://localhost:58316/ws");
      // this.conn = new WebSocket("ws://mail:82/ws");
   
  this.conn.onclose=(event)=>{
  console.log("close code_inbox.vue="+event.code);
  }
this.conn.onmessage = (event) => {
      console.log("inbox onmessage");
      let scannedImage = event.data;
      let mgs = JSON.parse(scannedImage);
      this.imagesscantest = mgs;

      var ind = this.imagesscantest.index;
       console.log("inbox index="+ind);
      if (ind == 1) {
        this.keyid = this.imagesscantest.keyid;
        console.log("inbox keyid="+this.keyid);
          console.log("count websocket_inbox="+this.imagesscantest.count1);
    
      } else {
         console.log("inbox.vue else");
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

}
 else if(this.conn.readyState===3||this.conn.readyState===2){
            console.log("readystate="+this.conn.readyState)
            this.conn.close();
                  this.conn=null;
                  this.reply1();
           }
  
           else {
 var mailId_to_get_mail_by_id = this.mailId_to_get_mail_by_id;
      var sends_id_to_get_mail_by_id = this.sends_id_to_get_mail_by_id;
      var department_Id = this.department_Id;
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
        mailId_to_get_mail_by_id +
        "send_ToId=" +
        sends_id_to_get_mail_by_id +
        "to=" +
        department_Id +
        "keyid=" +
        keyid;

           }


      //**********21/1/2023
     /* var link = document.getElementById("a4");
      var mailId_to_get_mail_by_id = this.mailId_to_get_mail_by_id;
      var sends_id_to_get_mail_by_id = this.sends_id_to_get_mail_by_id;
      var department_Id = this.department_Id;
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
        mailId_to_get_mail_by_id +
        "send_ToId=" +
        sends_id_to_get_mail_by_id +
        "to=" +
        department_Id +
        "keyid=" +
        keyid;*/
        //***********21/1/2023
    },
    //***************************

    print_image() {
      this.to_test_print = true;
      this.$http.mailService
        .PrintOrShowDocument(
          Number(this.mailId_to_get_mail_by_id),
          Number(localStorage.getItem("AY_LW")),
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
          Number(this.mailId_to_get_mail_by_id),
          Number(localStorage.getItem("AY_LW")),
          2
        )
        .then((res) => {
          this.show_images = [];
          this.indextotest = 0;

          this.show_images = this.replies[index].resources;

          this.testimage = this.show_images[0].path;

          setTimeout(() => {
            this.show_images_model = true;
            this.screenFreeze = false;
            this.loading = false;
          }, 300);
        })
        .catch((err) => {
          setTimeout(() => {
            this.loading = false;
            this.screenFreeze = false;
          }, 500);
          console.log(err);
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

    AddReply_old() {
      this.screenFreeze = true;
      this.loading = true;

      var ReplyViewModel = {
        userId: Number(localStorage.getItem("AY_LW")),
        mailId: Number(this.mailId_to_get_mail_by_id),
        send_ToId: Number(this.sends_id_to_get_mail_by_id),
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
            this.imagesToSend = [];
            // this.documentSection = true;
            // this.proceduresSection = true;

            for (let index = 0; index < this.inboxMails.length; index++) {
              if (
                this.inboxMails[index].mail_id == this.mailId_to_get_mail_by_id
              ) {
                if (
                  this.inboxMails[index].flag == 2 ||
                  this.inboxMails[index].flag == 3
                ) {
                  this.inboxMails[index].flag = 4;
                  this.inboxMails[index].state = " تم الرد من قيلك ";
                }
              }
            }

            this.loading = false;
            this.screenFreeze = false;

            this.reply_to_add = "";
            this.getMailById();

            // from Ayoub to eman

            
            var index_of_reply_img = 12

            if(index_of_reply_img > 10)
            {
              var id_of_reply_from_beackend = 1
              this.update_reply_to_complet_sent_img(id_of_reply_from_beackend);
            }
            
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
//*************************end addreplay_old
    update_reply_to_complet_sent_img_old(id){
      var new_index_of_reply_img = 10

      if(index_of_reply_img > new_index_of_reply_img)
      {
      this.screenFreeze = true;
      this.loading = true;

      var ReplyViewModel = {
        userId: Number(localStorage.getItem("AY_LW")),
        mailId: Number(this.mailId_to_get_mail_by_id),
        send_ToId: Number(this.sends_id_to_get_mail_by_id),
        from: Number(2),
        reply: {
          mail_detail: this.reply_to_add,
          To: Number(this.department_Id),
        },
        file: {
          list: this.imagesToSend,
        },
        id_of_reply: id
      };
      this.$http.mailService
        .NewAddReply(ReplyViewModel)
        .then((res) => {
          setTimeout(() => {
            console.log(res);
            this.imagesToSend = [];
            // this.documentSection = true;
            // this.proceduresSection = true;

            for (let index = 0; index < this.inboxMails.length; index++) {
              if (
                this.inboxMails[index].mail_id == this.mailId_to_get_mail_by_id
              ) {
                if (
                  this.inboxMails[index].flag == 2 ||
                  this.inboxMails[index].flag == 3
                ) {
                  this.inboxMails[index].flag = 4;
                  this.inboxMails[index].state = " تم الرد من قيلك ";
                }
              }
            }

            this.loading = false;
            this.screenFreeze = false;

            this.reply_to_add = "";
            // this.getMailById();

            // from Ayoub to eman

            
            var index_of_reply_img = 12

            if(index_of_reply_img > 10)
            {
              var id_of_reply_from_beackend = 1
              this.update_reply_to_complet_sent_img_old(id_of_reply_from_beackend);
            }
            
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
//*******************end addreply_old

//*********************************1/3/2023
    AddReply() {

      this.screenFreeze = true;
      this.loading = true;
      console.log("lenght1111="+this.imagesToSend.length);
      var ReplyViewModel = {
        userId: Number(localStorage.getItem("AY_LW")),
        mailId: Number(this.mailId_to_get_mail_by_id),
        send_ToId: Number(this.sends_id_to_get_mail_by_id),
        from: Number(2),
        reply: {
          mail_detail: this.reply_to_add,
          To: Number(this.department_Id),
        },
        file: {
          list: this.imagesToSend.slice(0,50),
        },
      };

     this.$http.mailService
        .NewAddReply(ReplyViewModel)
        .then((res) => {
          setTimeout(() => {
            console.log("res="+res.data.replyid);
           // this.imagesToSend = [];
            // this.documentSection = true;
            // this.proceduresSection = true;

            for (let index = 0; index < this.inboxMails.length; index++) {
              if (
                this.inboxMails[index].mail_id == this.mailId_to_get_mail_by_id
              ) {
                if (
                  this.inboxMails[index].flag == 2 ||
                  this.inboxMails[index].flag == 3
                ) {
                  this.inboxMails[index].flag = 4;
                  this.inboxMails[index].state = " تم الرد من قيلك ";
                }
              }
            }

            this.loading = false;
            this.screenFreeze = false;
            this.reply_to_add = "";
           //28/2/2023 this.getMailById();
            var cou=Math.ceil(this.imagesToSend.length/50);
           if(cou > 1)
            {
              console.log("cou="+cou);
              var id_of_reply_from_beackend = res.data.replyid;//101
             this.update_reply_to_complet_sent_img(1,id_of_reply_from_beackend,cou,50);
            }
            //****28/2/2023
           else{
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

    update_reply_to_complet_sent_img(ii,id,count1,a2){
     // var new_index_of_reply_img = 10

    //  if(index_of_reply_img > new_index_of_reply_img)
    console.log("update_reply ii="+ii);

    
    if(ii < count1)
     {
     var a1=a2;
      a2=a1+50;
      this.screenFreeze = true;
      this.loading = true;

      var ReplyViewModel = {
        userId: Number(localStorage.getItem("AY_LW")),
        mailId: Number(this.mailId_to_get_mail_by_id),
        send_ToId: Number(this.sends_id_to_get_mail_by_id),
        from: Number(2),
        reply: {
          mail_detail: this.reply_to_add,
          To: Number(this.department_Id),
        },
        file: {
          list: this.imagesToSend.slice(a1,a2),
        },
        id_of_reply: id
      };
      this.$http.mailService
        .update_replay(ReplyViewModel)
        .then((res) => {
          setTimeout(() => {
            console.log(res);
          //28/3/2023  this.imagesToSend = [];
            // this.documentSection = true;
            // this.proceduresSection = true;

            for (let index = 0; index < this.inboxMails.length; index++) {
              if (
                this.inboxMails[index].mail_id == this.mailId_to_get_mail_by_id
              ) {
                if (
                  this.inboxMails[index].flag == 2 ||
                  this.inboxMails[index].flag == 3
                ) {
                  this.inboxMails[index].flag = 4;
                  this.inboxMails[index].state = " تم الرد من قيلك ";
                }
              }
            }

            this.loading = false;
            this.screenFreeze = false;

            this.reply_to_add = "";
            // this.getMailById();

            // from Ayoub to eman

            
           // var index_of_reply_img = 12

           // if(index_of_reply_img > 10)
           ii++;
             if(ii < count1)
            {
             // var id_of_reply_from_beackend = 1
           //   this.update_reply_to_complet_sent_img(ii,id_of_reply_from_beackend);
          this.update_reply_to_complet_sent_img(ii,id,count1,a2);
         
            }
           //*********1/3/2023
            else
 this.getMailById();
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
//************************************end 1/3/2023 addreply

    to_pass_data_to_get_mail_by_id(
      mailId_to_get_mail_by_id,
      my_department_id_to_get_mail_by_id,
      to_test_passing_mail_type_to_get_mail_by_id,
      sends_id_to_get_mail_by_id,
      mangment_sender_to_get_mail_by_id
    ) {
      this.mailId_to_get_mail_by_id = mailId_to_get_mail_by_id;
      this.my_department_id_to_get_mail_by_id =
        my_department_id_to_get_mail_by_id;
      this.to_test_passing_mail_type_to_get_mail_by_id =
        to_test_passing_mail_type_to_get_mail_by_id;
      this.sends_id_to_get_mail_by_id = sends_id_to_get_mail_by_id;
      this.mangment_sender_to_get_mail_by_id =
        mangment_sender_to_get_mail_by_id;

      this.getMailById();
    },

    getMailById() {
      this.reply_to_add = "";
      this.imagesToSend = [];
      this.$http.mailService
        .GetInboxMailById(
          this.mailId_to_get_mail_by_id,
          this.my_department_id_to_get_mail_by_id,
          this.to_test_passing_mail_type_to_get_mail_by_id
        )
        .then((res) => {
          this.department_Id = res.data.mail.department_Id;
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
            this.external_mailId = res.data.external.id;

            this.action_required_by_the_entity =
              res.data.external.action_required_by_the_entity;

            this.mail_forwarding = res.data.external.action;

            this.mail_forwarding_sector_side = res.data.sector.type;

            this.sectorNameSelected = res.data.sector.section_Name;

            this.sideNameSelected = res.data.side.section_Name;
          }
          if (this.to_test_passing_mail_type == "3") {
            this.external_mailId = res.data.inbox.id;

            this.mail_forwarding = res.data.inbox.action;

            this.mail_forwarding_sector_side = res.data.sector.type;

            this.sectorNameSelected = res.data.sector.section_Name;

            this.sideNameSelected = res.data.side.section_Name;

            this.ward_to = res.data.inbox.to;

            this.mail_ward_type = res.data.inbox.type;

            this.entity_mail_date = res.data.inbox.send_time;

            this.entity_reference_number =
              res.data.inbox.entity_reference_number;

            this.procedure_type = res.data.inbox.procedure_type;
          }

          //   this.GetDocmentForMail();
          //   this.GetDocmentForMailToShow();

          //   this.GetProcessingResponses()
        })
        .catch((err) => {
          console.log(err);
        });
    },

    previousImage() {
      if (this.indextotest > 0) {
        this.indextotest--;
        this.testimage = this.show_images[this.indextotest].path;
      }
    },

    nextImage() {
      if (this.indextotest < this.show_images.length - 1) {
        this.indextotest++;
        this.testimage = this.show_images[this.indextotest].path;
      }
    },

    GetAllDocuments(id, plase) {
      this.from_reply_or_general = plase;
      this.screenFreeze = true;
      this.loading = true;
      this.$http.mailService
        .GetAllDocuments(id, Number(localStorage.getItem("AY_LW")))
        .then((res) => {
          this.show_images = res.data;

          this.testimage = this.show_images[0].path;

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

    GetInboxs() {


      var date_from2=this.date_from;
      var date_to2=this.date_to;

      if(this.year_filter!=0){
        date_from2= this.year_filter + "-01-01"
        date_to2= this.year_filter + "-12-31"
      }


      if(this.departmentNameSelected==""){

         this.departmentIdSelected=''
    }

      this.screenFreeze = true;
      this.loading = true;
      this.inboxMails = [];
      this.$http.mailService
        .inboxs(
          this.my_user_id,
          this.mailType,
          this.my_department_id,
          date_from2,
          date_to2,
          this.by_date_of_reply,
          this.mail_id,
          this.general_incoming_number,
          this.summary,
          this.departmentIdSelected,
          this.sideIdSelected,
          this.measureIdSelected,
          this.classificationIdSelected,
          this.mail_caseIdSelected,
          this.s_number,
          this.page_num,
          this.page_size

         
          
          
         
          
         
          
          
         
          
         
          
          
          
        )
        .then((res) => {
          this.inboxMails = res.data.mail;
          this.replies = [];
          this.sends_id_to_get_mail_by_id = "";
          this.mangment_sender_to_get_mail_by_id = "";
          this.reply_to_add = "";

          this.total_of_transaction = res.data.total;
          setTimeout(() => {
            this.screenFreeze = false;
            this.loading = false;
          }, 300);
        })
        .catch((err) => {
          setTimeout(() => {
            this.screenFreeze = false;
            this.loading = false;
            console.log(err);
          }, 100);
        });
    },

    GetMailsToPrint() {


      var date_from2=this.date_from;
      var date_to2=this.date_to;


      if(this.year_filter!=0){
        date_from2= this.year_filter + "-01-01"
        date_to2= this.year_filter + "-12-31"
      }



      this.screenFreeze = true;
      this.loading = true;
      this.mails_to_print = [];
      this.$http.mailService
        .inboxs(
          this.my_user_id,
          this.mailType,
          this.my_department_id,
          date_from2,
          date_to2,
          this.by_date_of_reply,
          this.mail_id,
          this.general_incoming_number,
          this.summary,
          this.departmentIdSelected,
          this.sideIdSelected,
          this.measureIdSelected,
          this.classificationIdSelected,
          this.mail_caseIdSelected,
          this.s_number,
          this.page_num,
          this.page_size2
        )
        .then((res) => {
          this.mails_to_print = res.data.mail;
         

          this.total_of_transaction = res.data.total;
          setTimeout(() => {
            this.screenFreeze = false;
            this.loading = false;

            this.$router.push({
              name: "incoming_report",
              params: {
                dateFrom: this.date_from,
                dateTo: this.date_to,
                total_of_transaction: this.total_of_transaction,
                mails: this.mails_to_print,
              },
            });
          }, 300);
        })
        .catch((err) => {
          setTimeout(() => {
            this.screenFreeze = false;
            this.loading = false;
            console.log(err);
          }, 100);
        });
    },

    read_it_mail(id) {
      // this.screenFreeze = true;
      // this.loading = true;
      this.$http.mailService
        .read_it_mail(
          id,
          this.my_department_id,
          Number(localStorage.getItem("AY_LW"))
        )
        .then((res) => {
          console.log(res);
          // this.inboxMails = res.data.mail;
          // this.total_of_transaction = res.data.total
          // setTimeout(() => {
          //     this.screenFreeze = false;
          //     this.loading = false;

          this.GetInboxs();
          // }, 300);
        })
        .catch((err) => {
          setTimeout(() => {
            this.screenFreeze = false;
            this.loading = false;
            console.log(err);
          }, 100);
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

    selectdepartment(id, name) {
      this.departmentNameSelected = name;
      this.departmentIdSelected = id;
    },

    GetAllSides() {
      this.$http.mailService
        .AllSides()
        .then((res) => {
          this.sides = res.data;
        })
        .catch((err) => {
          console.log(err);
        });
    },

    selectsides(id, name) {
      this.sideNameSelected = name;
      this.sideIdSelected = id;
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

    selectmeasure(id, name) {
      this.measureNameSelected = name;
      this.measureIdSelected = id;
    },

    GetAllmail_cases() {
      this.$http.mailService
        .AllStateInbox()
        .then((res) => {
          this.mail_cases = res.data;
        })
        .catch((err) => {
          console.log(err);
        });
    },

    select_mail_case(id, name) {
      this.mail_caseNameSelected = name;
      this.mail_caseIdSelected = id;
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

    selectClassification(id, name) {
      this.classificationNameSelected = name;
      this.classificationIdSelected = id;
    },
  },
  // add_to_array_of_side_measure(){
  //     this.consignees.push({
  //         departmentId : this.departmentIdSelected,
  //         departmentName : this.departmentNameSelected,

  //     })
  // },
};
</script>

<style>
.VuePagination__count {
  display: none;
}

.VuePagination {
  width: 100%;
}

.VuePagination nav {
  display: flex;
  justify-content: space-between;
  align-items: center;
}

.pagination {
  display: flex;
}

.page-link {
  background-color: red;
}

.page-item {
  /* margin-left: .5rem;
        margin-right: .5rem;*/
}

.page-link {
  padding-left: 0.5rem;
  padding-right: 0.5rem;
  padding-top: 0.5rem;
  padding-bottom: 0.5rem;

  font-size: 0.75rem;
  /* line-height: 1.25rem; */

  font-weight: 500;
  border-width: 1px;

  --tw-border-opacity: 0;
  border-color: rgba(209, 213, 219, var(--tw-border-opacity));

  --tw-bg-opacity: 1;
  background-color: rgba(255, 255, 255, var(--tw-bg-opacity));

  --tw-text-opacity: 1;
  color: rgba(0, 0, 0, var(--tw-text-opacity));
}

.page-link:hover {
  --tw-bg-opacity: 1;
  background-color: rgba(52, 211, 153, var(--tw-bg-opacity));
  --tw-text-opacity: 1;
  color: rgba(255, 255, 255, var(--tw-text-opacity));
}

.active {
  background-color: rgba(16, 185, 129);
  color: #fff;
}

.VuePagination nav ul {
  padding-top: 0.3rem;
  padding-bottom: 0.5rem;
  border-radius: 0.375rem;
  overflow: hidden;
}
</style>
