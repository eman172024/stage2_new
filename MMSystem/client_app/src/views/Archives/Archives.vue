<template>
  <div class="">
    <div class="h-screen bg-gray-100 overflow-hidden flex">
      <div class="flex-1 bg-gray-200 w-0 overflow-y-auto">
        <div class="max-w-screen-2xl mx-auto flex flex-col md:px-8">
          <logout class="mt-4 ml-4"></logout>
          <main class="flex-1 relative focus:outline-none pt-2 pb-6">
            <div class="flex justify-between items-center mt-6">
              <div class="">
                <h1 class="text-xl font-semibold text-gray-900">المحفوظات</h1>
              </div>

              <div class="flex items-center">
                <span class="text-base font-medium text-gray-800">
                  التاريخ :
                </span>

                <span class="flex items-center mr-4">
                  من
                  <input
                    type="date"
                    min="2000-01-01"
                    max="2040-12-30"
                    id="date_from"
                    v-model="date_from"
                    class="
                      block
                      mr-2
                      w-full
                      rounded-md
                      h-10
                      border border-gray-200
                      hover:shadow-sm
                      focus:outline-none focus:border-gray-300
                      px-2
                    "
                  />
                </span>

                <span class="flex items-center mr-4">
                  إلي
                  <input
                    type="date"
                    min="2000-01-01"
                    max="2040-12-30"
                    id="date_to"
                    v-model="date_to"
                    class="
                      block
                      mr-2
                      w-full
                      rounded-md
                      h-10
                      border border-gray-200
                      hover:shadow-sm
                      focus:outline-none focus:border-gray-300
                      px-2
                    "
                  />
                </span>
              </div>

              <fieldset class="ml-6">
                <div class="flex items-center">
                  <div class="flex items-center">
                    <input
                      v-model="mailType"
                      id="all"
                      type="radio"
                      name="type"
                      class="h-4 w-4"
                      value=""
                      @click="get_sectors(0)"
                    />
                    <label for="all" class="mr-2 block text-gray-800">
                      الكل
                    </label>
                  </div>

                  <div class="flex items-center mr-6">
                    <input
                      v-model="mailType"
                      id="public"
                      type="radio"
                      name="type"
                      class="h-4 w-4"
                      value="2"
                      @click="get_sectors(2)"
                    />
                    <label for="public" class="mr-2 block text-gray-800">
                      جهات عامة
                    </label>
                  </div>

                  <div class="flex items-center mr-6">
                    <input
                      v-model="mailType"
                      id="branch"
                      type="radio"
                      name="type"
                      class="h-4 w-4"
                      value="1"
                      @click="get_sectors(1)"
                    />
                    <label for="branch" class="mr-2 block text-gray-800">
                      فروع الرقابة
                    </label>
                  </div>

                  <div class="flex items-center mr-6">
                    <input
                      v-model="mailType"
                      id="private"
                      type="radio"
                      name="type"
                      class="h-4 w-4"
                      value="3"
                      @click="get_sectors(3)"
                    />
                    <label for="private" class="mr-2 block text-gray-800">
                      جهات خاصة
                    </label>
                  </div>
                </div>
              </fieldset>
            </div>

            <div class="mt-4 flex justify-between w-full">
              <div class="relative w-full">
                <button
                  @click="filter = !filter"
                  :class="filter ? 'shadow-md' : ''"
                  class="
                    rounded-t-md
                    border border-b-0
                    hover:text-blue-600 hover:font-bold
                    group
                    w-11/12
                    p-2
                    bg-white
                    flex
                    items-center
                    justify-between
                    focus:outline-none
                  "
                >
                  <span class="flex items-center">
                    <svg
                      class="w-6 h-6 ml-2 stroke-current group-hover:stroke-2"
                      fill="none"
                      stroke="currentColor"
                      viewBox="0 0 24 24"
                      xmlns="http://www.w3.org/2000/svg"
                    >
                      <path
                        stroke-linecap="round"
                        stroke-linejoin="round"
                        d="M3 4a1 1 0 011-1h16a1 1 0 011 1v2.586a1 1 0 01-.293.707l-6.414 6.414a1 1 0 00-.293.707V17l-4 4v-6.586a1 1 0 00-.293-.707L3.293 7.293A1 1 0 013 6.586V4z"
                      ></path>
                    </svg>
                    فرز
                  </span>

                  <span class="">
                    <svg
                      class="w-6 h-6 stroke-current group-hover:stroke-2"
                      fill="none"
                      stroke="currentColor"
                      viewBox="0 0 24 24"
                    >
                      <path
                        strokeLinecap="round"
                        strokeLinejoin="round"
                        strokeWidth="{2}"
                        d="M19 9l-7 7-7-7"
                      />
                    </svg>
                  </span>
                </button>

                <div
                  v-if="filter"
                  class="
                    rounded-b-md
                    shadow-md
                    absolute
                    border border-t-0
                    z-40
                    w-full
                    bg-white
                    px-4
                    py-8
                  "
                >
                  <div
                    class="
                      grid grid-cols-1
                      gap-y-6 gap-x-4
                      sm:grid-cols-6
                      max-w-4xl
                      mx-auto
                    "
                  >
                    <div class="sm:col-span-2">
                      <label
                        for="mail_id"
                        class="block text-base font-semibold text-gray-800"
                      >
                        رقم الصادر
                      </label>
                      <input
                        v-model="mail_id"
                        type="number"
                         min="1"
                        max="50000"
                        id="mail_id"
                        class="
                          block
                          mt-2
                          h-10
                          w-full
                          rounded-md
                          border border-gray-300
                          hover:shadow-sm
                          focus:outline-none focus:border-gray-300
                          px-2
                        "
                      />
                    </div>

                    <div class="sm:col-span-2">
                      <label
                        for="department"
                        class="block text-base font-semibold text-gray-800"
                      >
                        الإدارة المرسلة
                      </label>

                      <div class="relative">
                        <button
                          @click="departmentselect = !departmentselect"
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
                          {{ departmentNameSelected }}
                        </button>

                        <div
                          v-if="departmentselect"
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
                              selectdepartment('', 'الكل');
                              departmentselect = !departmentselect;
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
                              selectdepartment(
                                department.id,
                                department.departmentName
                              );
                              departmentselect = !departmentselect;
                            "
                            v-for="department in departments"
                            :key="department.id"
                          >
                            {{ department.departmentName }}
                          </button>
                        </div>
                      </div>
                    </div>

                    <div class="sm:col-span-2">
                      <label
                        for="summary"
                        class="block text-base font-semibold text-gray-800"
                      >
                        جزء من الملخص
                      </label>
                      <input
                        type="text"
                        v-model="summary"
                        id="summary"
                        class="
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
                        "
                      />
                    </div>

                    <div class="sm:col-span-2">
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
                            @click="sectorIdSelected = 0,sectorNameSelected='الكل';get_sides(0,'الكل');"
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
                              get_sides(sector.id, sector.section_Name);
                              sectorselect = !sectorselect;
                              sectorIdSelected = sector.id;
                            "
                            v-for="sector in sectors"
                            :key="sector.id"
                          >
                            {{ sector.section_Name }}
                          </button>
                        </div>
                      </div>
                    </div>

                    <div class="sm:col-span-2">
                      <label
                        for="sideIdSelected"
                        class="block text-sm font-semibold text-gray-800"
                      >
                        الجهة الموجه إليها
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
                              

                              pass_side(0, 'الكل')
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
                              pass_side(side.id, side.section_Name);
                              sideselect = !sideselect;
                            "
                            v-for="side in sides"
                            :key="side.id"
                          >
                            {{ side.section_Name }}
                          </button>
                        </div>


                        <div class="flex justify-between">


                      <div class="mt-6">
                    
                    <button 
                    @click="   page_num=1; GetMailsForArchives();filter = !filter"
                    
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
                
                
                      </div>
                    </div>
                  </div>
                </div>
              </div>

              <div class="w-5/12 flex py-1 px-4">
                <button
                  class="
                    mx-auto
                    w-full
                    ml-2
                    bg-green-700
                    text-green-50
                    rounded-md
                    py-3
                    border border-green-300
                    hover:bg-green-800
                    focus:outline-none
                    flex
                    items-center
                    justify-center
                    col-span-2
                  "
                  @click="GetMailsToPrint()"
                >
                  <span class="text-sm font-bold block ml-1"
                    >طباعة الحافظة</span
                  >

                  <svg
                    class="
                      h-5
                      w-5
                      mr-1
                      text-white
                      block
                      fill-current
                      hover:text-blue-500
                    "
                    id="Capa_1"
                    enable-background="new 0 0 512 512"
                    height="512"
                    viewBox="0 0 512 512"
                    width="512"
                    xmlns="http://www.w3.org/2000/svg"
                  >
                    <g>
                      <path
                        d="m437 129h-14v-54c0-41.355-33.645-75-75-75h-184c-41.355 0-75 33.645-75 75v54h-14c-41.355 0-75 33.645-75 75v120c0 41.355 33.645 75 75 75h14v68c0 24.813 20.187 45 45 45h244c24.813 0 45-20.187 45-45v-68h14c41.355 0 75-33.645 75-75v-120c0-41.355-33.645-75-75-75zm-318-54c0-24.813 20.187-45 45-45h184c24.813 0 45 20.187 45 45v54h-274zm274 392c0 8.271-6.729 15-15 15h-244c-8.271 0-15-6.729-15-15v-148h274zm89-143c0 24.813-20.187 45-45 45h-14v-50h9c8.284 0 15-6.716 15-15s-6.716-15-15-15h-352c-8.284 0-15 6.716-15 15s6.716 15 15 15h9v50h-14c-24.813 0-45-20.187-45-45v-120c0-24.813 20.187-45 45-45h362c24.813 0 45 20.187 45 45z"
                      />
                      <path
                        d="m296 353h-80c-8.284 0-15 6.716-15 15s6.716 15 15 15h80c8.284 0 15-6.716 15-15s-6.716-15-15-15z"
                      />
                      <path
                        d="m296 417h-80c-8.284 0-15 6.716-15 15s6.716 15 15 15h80c8.284 0 15-6.716 15-15s-6.716-15-15-15z"
                      />
                      <path
                        d="m128 193h-48c-8.284 0-15 6.716-15 15s6.716 15 15 15h48c8.284 0 15-6.716 15-15s-6.716-15-15-15z"
                      />
                    </g>
                  </svg>
                </button>

                <router-link
                  class="
                    mx-auto
                    w-full
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
                    mr-2
                  "
                  :to="{
                    name: 'report',
                    params: {
                      dateFrom: date_from,
                      dateTo: date_to,
                      mailType: mailType,
                      total_of_transaction: total_of_transaction,
                    },
                  }"
                >
                  <span class="text-sm font-bold block ml-1">تقرير</span>

                  <svg
                    class="h-5 w-5 text-white block mr-1"
                    fill="none"
                    stroke="currentColor"
                    viewBox="0 0 24 24"
                    xmlns="http://www.w3.org/2000/svg"
                  >
                    <path
                      stroke-linecap="round"
                      stroke-linejoin="round"
                      stroke-width="2"
                      d="M9 5H7a2 2 0 00-2 2v12a2 2 0 002 2h10a2 2 0 002-2V7a2 2 0 00-2-2h-2M9 5a2 2 0 002 2h2a2 2 0 002-2M9 5a2 2 0 012-2h2a2 2 0 012 2m-3 7h3m-3 4h3m-6-4h.01M9 16h.01"
                    ></path>
                  </svg>
                </router-link>
              </div>
            </div>
            <div class="w-full mt-2 rounded-md divide-y-2 divide-gray-200">
              <div class="flex justify-between">
                <div class="w-full ml-2">
                  البريد
                  <div
                    class="
                      flex
                      items-center
                      bg-gray-100
                      w-full
                      text-sm
                      pl-2
                      mt-2
                    "
                  >
                    <div class="w-10/12 flex items-center">
                      <div class="w-1/12 pr-4 text-right py-1">رقم الصادر</div>

                      <div class="w-1/12 text-center py-1">الحالة</div>

                      <div class="w-2/12 text-center py-1">تاريخ الصادر</div>

                      <div class="w-3/12 text-center py-1">الإدارة المرسلة</div>

                      <div class="w-3/12 text-center py-1">
                        الجهة الموجه إليها
                      </div>

                      <div class="w-2/12 text-center py-1">
                        القطاع التابعة له
                      </div>
                    </div>

                    <div class="w-2/12 text-center py-1">الإجراءات</div>
                  </div>

                  <div class="min-h-64 text-sm bg-gray-100">
                    <div
                      v-for="mail in inboxMails"
                      :key="mail.id"
                      :class="mail.flag | mail_state_inbox"
                      class="
                        group
                        relative
                        border-r-8 border-red-500
                        flex
                        items-center
                        bg-white
                        hover:bg-gray-100
                        pl-2
                      "
                    >
                      <button class="w-10/12 flex items-center">
                        <div class="w-1/12 pr-4 py-1 text-right">
                          {{ mail.mail_Number }}
                        </div>

                        <div class="w-1/12 py-1 text-center">
                          {{ mail.flagn }}
                        </div>

                        <div class="w-2/12 py-1 text-center">
                          {{ mail.date_Of_Mail }}
                        </div>

                        <div class="w-3/12 py-1 text-center">
                          {{ mail.department }}
                        </div>

                        <div class="w-3/12 py-1 text-center">
                          {{ mail.side_Name }}
                        </div>

                        <div class="w-2/12 py-1text-center">
                          {{ mail.perentName }}
                        </div>
                      </button>

                      <div
                        class="
                          w-2/12
                          flex
                          justify-between
                          items-center
                          px-4
                          py-1
                        "
                      >
                        <div class="w-1/3 flex justify-center items-center">
                          <button
                            @click="GetAllDocuments(mail.id)"
                            title="عرض الصور"
                            class="focus:outline-none"
                          >
                            <svg
                              class="w-7 h-7 hover:text-blue-500"
                              fill="none"
                              stroke="currentColor"
                              viewBox="0 0 24 24"
                              xmlns="http://www.w3.org/2000/svg"
                            >
                              <path
                                stroke-linecap="round"
                                stroke-linejoin="round"
                                stroke-width="2"
                                d="M4 16l4.586-4.586a2 2 0 012.828 0L16 16m-2-2l1.586-1.586a2 2 0 012.828 0L20 14m-6-6h.01M6 20h12a2 2 0 002-2V6a2 2 0 00-2-2H6a2 2 0 00-2 2v12a2 2 0 002 2z"
                              ></path>
                            </svg>
                          </button>
                        </div>

                        <div
                          class="w-1/3 flex justify-center items-center"
                          v-if="mail.flag < 3"
                        >
                          <button
                            @click="UpdateArciveState(mail.id), (isread = true)"
                            title="تم الاستلام والارسال"
                            class="focus:outline-none"
                          >
                            <svg
                              class="
                                w-6
                                h-6
                                hover:text-blue-500
                                border-2
                                rounded-md
                                border-black
                              "
                              fill="none"
                              stroke="currentColor"
                              viewBox="0 0 24 24"
                              xmlns="http://www.w3.org/2000/svg"
                            >
                              <path
                                stroke-linecap="round"
                                stroke-linejoin="round"
                                stroke-width="2"
                                d="M5 13l4 4L19 7"
                              ></path>
                            </svg>
                          </button>
                        </div>

                        <div
                          class="w-1/3 flex justify-center items-center"
                          v-if="mail.flag > 2"
                        >
                          <button
                            @click="
                              (isDelivered = true),
                                (mail_id_copy = mail.id),
                                (delivaryName = mail.delivery),
                                isDelivered1(mail.delivery),
                                (NoOfcopies = mail.number_Of_Copies),
                                (notes = mail.note),
                                attached11(mail.attachments)
                            "
                            title="تم التسليم للجهة"
                            class="focus:outline-none"
                          >
                            <svg
                              class="w-6 h-6 hover:text-blue-500"
                              fill="none"
                              stroke="currentColor"
                              viewBox="0 0 24 24"
                              xmlns="http://www.w3.org/2000/svg"
                            >
                              <path
                                stroke-linecap="round"
                                stroke-linejoin="round"
                                stroke-width="2"
                                d="M14 10h4.764a2 2 0 011.789 2.894l-3.5 7A2 2 0 0115.263 21h-4.017c-.163 0-.326-.02-.485-.06L7 20m7-10V5a2 2 0 00-2-2h-.095c-.5 0-.905.405-.905.905 0 .714-.211 1.412-.608 2.006L7 11v9m7-10h-2M7 20H5a2 2 0 01-2-2v-6a2 2 0 012-2h2.5"
                              ></path>
                            </svg>
                          </button>
                        </div>

                        <div
                          class="w-1/3 flex justify-center items-center"
                          v-if="mail.flag > 2"
                        >
                          <button
                            title="عدد النسخ"
                            class="focus:outline-none"
                            @click="
                              (copies = true),
                                (mail_id_copy = mail.id),
                                (NoOfcopies = mail.number_Of_Copies),
                                (notes = mail.note),
                                attached11(mail.attachments),
                                (delivaryName = mail.delivery),
                                isDelivered1(mail.delivery)
                            "
                          >
                            <svg
                              class="w-7 h-7 hover:text-blue-500"
                              fill="none"
                              stroke="currentColor"
                              viewBox="0 0 24 24"
                              xmlns="http://www.w3.org/2000/svg"
                            >
                              <path
                                stroke-linecap="round"
                                stroke-linejoin="round"
                                stroke-width="2"
                                d="M8 7v8a2 2 0 002 2h6M8 7V5a2 2 0 012-2h4.586a1 1 0 01.707.293l4.414 4.414a1 1 0 01.293.707V15a2 2 0 01-2 2h-2M8 7H6a2 2 0 00-2 2v10a2 2 0 002 2h8a2 2 0 002-2v-2"
                              ></path>
                            </svg>
                          </button>
                        </div>
                      </div>

                      <div
                        class="
                          group-hover:block
                          items-end
                          hidden
                          absolute
                          z-20
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
                        "
                      >
                        <div class="flex items-center justify-between">
                          <div class="">
                            تاريخ استلام الرسالة بالمحفوظات :
                            <span class="mr-4 text-red-400 underline">{{
                              mail.dateTime_of_read
                            }}</span>
                          </div>

                          <div class="">
                            وقت استلام الرسالة بالمحفوظات :
                            <span class="mr-4 text-red-400 underline">{{
                              mail.time_of_read
                            }}</span>
                          </div>
                        </div>

                        <div class="flex mt-10">
                          <p class="font-bold">ملخص الرسالة :</p>

                          <p class="mr-1">
                            {{ mail.summary }}
                          </p>
                        </div>

                        <div class="flex items-center justify-between mt-8 p-2">
                          <div class="">
                            التسليم للجهة - {{ mail.delivery }}
                          </div>

                          <div class="">
                            عدد النسخ - {{ mail.number_Of_Copies }}
                          </div>

                          <div class="" v-if="mail.attachments">
                            يوجد مرفقات
                          </div>
                          <div class="" v-else>لا يوجد مرفقات</div>
                        </div>
                      </div>
                    </div>
                  </div>

                  <div
                    class="
                      flex
                      justify-end
                      mt-2
                      mx-auto
                      px-4
                      sm:px-6
                      lg:px-8
                      w-full
                      bg-white
                      relative
                    "
                  >
                    <pagination
                      dir="rtl"
                      v-model="page_num"
                      :per-page="page_size"
                      :records="total_of_transaction"
                      @paginate="GetMailsForArchives"
                      class="z-10"
                    />
                    <div class="">
                      <div
                        class="
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
                        "
                      >
                        <span class="text-xs ml-1"> عدد الرسائل </span>
                        {{ total_of_transaction }}
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </main>
        </div>
      </div>
    </div>
    <div
      v-if="isDelivered"
      class="
        bg-gray-300
        w-96
        h-80
        mx-auto
        flex flex-col
        justify-between
        absolute
        inset-32
        z-50
        py-4
        px-2
        rounded-lg
        border-black border-2
      "
    >
      <button @click="isDelivered = false">
        <svg
          class="w-8 h-8 stroke-current hover:text-red-500"
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

      <fieldset class="ml-6 font-semibold">
        <div class="flex justify-between">
          <div class="flex items-center mr-6">
            <input
              id="dtoff"
              @click="hand = false"
              type="radio"
              name="delivaryType"
              class="h-4 w-4"
              value="1"
              v-model="delivaryType"
            />
            <label for="dtoff" class="mr-2 block text-gray-800">
              سلمت للجهة
            </label>
          </div>

          <div class="flex items-center mr-6">
            <input
              id="hand"
              type="radio"
              name="delivaryType"
              class="h-4 w-4"
              value="2"
              @click="hand = true"
              v-model="delivaryType"
            />
            <label for="hand" class="mr-2 block text-gray-800">
              سلمت باليد
            </label>
          </div>
        </div>
      </fieldset>

      <div v-if="hand" class="sm:col-span-2 mt-1">
        <label
          for="DelivaryName"
          class="block text-base font-semibold text-gray-800"
        >
          اسم المستلم
        </label>
        <input
          type="text"
          v-model="delivaryName"
          id="DelivaryName"
          class="
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
          "
          placeholder="ادخل اسم المستلم"
        />
      </div>

      <button
        class="
          mx-auto
          bg-green-700
          text-green-50 text-lg
          rounded-md
          py-3
          w-56
          border border-green-300
          hover:bg-green-800
          focus:outline-none
          flex
          items-center
          justify-center
        "
        @click="UpdateArciveDelivary(), (isDelivered = false)"
      >
        <span class="text-sm font-bold block ml-1">موافق</span>
      </button>
    </div>

    <div
      v-if="copies"
      class="
        bg-gray-300
        w-96
        h-96
        mx-auto
        flex flex-col
        justify-between
        absolute
        inset-32
        z-50
        py-4
        px-2
        rounded-lg
        border-black border-2
      "
    >
      <button @click="copies = false">
        <svg
          class="w-8 h-8 stroke-current hover:text-red-500"
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

      <div class="sm:col-span-2 mt-1">
        <label
          for="NoOfcopies"
          class="block text-base font-semibold text-gray-800"
        >
          عدد النسخ
        </label>
        <input
          type="number"
           min="0"
          max="50000"
          v-model="NoOfcopies"
          id="NoOfcopies"
          class="
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
          "
        />
      </div>

      <fieldset class="ml-6 font-semibold">
        <div class="flex justify-between">
          <div class="flex items-center mr-6">
            <input
              id="ThereIs"
              type="radio"
              name="attached"
              class="h-4 w-4"
              value="true"
              v-model="attached"
            />
            <label for="ThereIs" class="mr-2 block text-gray-800">
              يوجد مرفقات
            </label>
          </div>

          <div class="flex items-center mr-6">
            <input
              id="ThereIsNo"
              type="radio"
              name="attached"
              class="h-4 w-4"
              value=""
              v-model="attached"
            />
            <label for="ThereIsNo" class="mr-2 block text-gray-800">
              لايوجد مرفقات
            </label>
          </div>
        </div>
      </fieldset>

      <div class="sm:col-span-2 mt-1">
        <label for="notes" class="block text-base font-semibold text-gray-800">
          ملاحظات
        </label>
        <input
          type="text"
          v-model="notes"
          maxlength="30"
          id="notes"
          class="
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
          "
          placeholder="ادخل الملاحظة"
        />
      </div>

      <button
        class="
          mx-auto
          bg-green-700
          text-green-50 text-lg
          rounded-md
          py-3
          w-56
          border border-green-300
          hover:bg-green-800
          focus:outline-none
          flex
          items-center
          justify-center
        "
        @click="UpdateArciveCopies(), (copies = false)"
      >
        <span class="text-sm font-bold block ml-1">موافق</span>
      </button>
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

      <div
        v-if="there_are_no_documents"
        class="bg-white w-96 h-32 flex justify-center items-center"
      >
        لا توجد مستندات لهذا البريد.
      </div>
    </div>

    <div
      v-if="show_images_model"
      class="w-screen h-full absolute inset-0 z-50 overflow-hidden"
    >
      <div class="relative">
        <div
          v-if="to_test_print"
          id="printMe"
          class="bg-black bg-opacity-50 h-screen-85"
        >
          <div v-for="image in show_images" :key="image.id" class="h-screen-85">
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
            bg-black bg-opacity-50
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
                  class="w-8 h-8 stroke-current hover:text-red-500"
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
                @click="to_test_print = true"
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
                :src="testimage"
                alt="image"
                class="h-full w-full object-contain"
              />
            </div>

            <div
              v-if="testimage"
              class="
                flex
                justify-between
                items-center
                max-w-xs
                mx-auto
                w-full
                bg-white
              "
            >
              <button
                @click="previousImage()"
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

              {{ indextotest + 1 }} / {{ show_images.length }}

              <button
                title="next"
                @click="nextImage()"
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

      <!-- w-full h-full rounded object-contain -->
    </div>
  </div>
</template>

<script>
import svgLoadingComponent from "@/components/svgLoadingComponent.vue";
import logout from "@/components/logout.vue";

export default {
  created() {},

  mounted() {
    var date = new Date();

    var month = date.getMonth() + 1;
    var day = date.getDate();

    if (month < 10) month = "0" + month;
    if (day < 10) day = "0" + day;

    this.date_from = date.getFullYear() + "-" + month + "-" + day;
    this.date_to = date.getFullYear() + "-" + month + "-" + day;

    this.my_user_id = localStorage.getItem("AY_LW");
    this.my_department_id = localStorage.getItem("chrome");

    this.GetMailsForArchives();

    this.GetAllDepartments();
    this.GetAllMeasures();
    this.get_sectors(this.mailType);
  },

  watch: {
    mailType: function() {
      this.senders = [];
      this.show_senders_mail = "";
      this.page_num = 1;
      this.GetMailsForArchives();
    },
    date_from: function() {
      this.senders = [];
      this.show_senders_mail = "";
      this.page_num = 1;
      this.GetMailsForArchives();
    },
    date_to: function() {
      this.senders = [];
      this.show_senders_mail = "";
      this.page_num = 1;
      this.GetMailsForArchives();
    },


    // mail_id: function() {
    //   this.senders = [];
    //   this.show_senders_mail = "";
    //   this.page_num = 1;
    //   this.GetMailsForArchives();
    // },
    // summary: function() {
    //   this.senders = [];
    //   this.show_senders_mail = "";
    //   this.page_num = 1;
    //   this.GetMailsForArchives();
    // },
    // departmentIdSelected: function() {
    //   this.senders = [];
    //   this.show_senders_mail = "";
    //   this.page_num = 1;
    //   this.GetMailsForArchives();
    // },

    // sideIdSelected: function() {
    //   this.senders = [];
    //   this.show_senders_mail = "";
    //   this.page_num = 1;
    //   this.GetMailsForArchives();
    // },

    // sectorIdSelected: function() {
    //   this.senders = [];
    //   this.show_senders_mail = "";
    //   this.page_num = 1;
      
    //   this.GetMailsForArchives();
    // },
  },

  components: {
    svgLoadingComponent,
    logout,
  },

  data() {
    return {
      isread: false,
      NoOfcopies: 0,
      notes: "",
      delivaryName: "",
      delivaryType: 0,
      attached: "",
      attached1: "",
      copies: false,
      show_senders_mail: "",
      senders: [],
      to_test_print: false,

      testimage: "",
      indextotest: 0,

      show_images: [],
      show_images_model: false,

      total_of_transaction: 0,
      my_user_id: "",
      my_department_id: "",

      inboxMails: [],

      mail_id: "",

      departments: [],
      departmentselect: false,
      departmentNameSelected: "",
      departmentIdSelected: "",
      departmentName: "",

      measures: [],
      measureselect: false,
      measureNameSelected: "",
      measureIdSelected: "",

      mail_cases: [],
      mail_caseselect: false,
      mail_caseNameSelected: "",
      mail_caseIdSelected: "",

      mailType: "",

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

      sideselect: false,
      sideNameSelected: "الكل",
      sideIdSelected: 0,
      sides: [],

      send_to_sector: "",

      sectors: [],
      sectorselect: false,
      sectorNameSelected: "الكل",
      sectorIdSelected: 0,

      isDelivered: false,
      dtoff: false,
      hand: false,

      mail_id_copy: 0,

      mail_to_print: [],
    };
  },

  methods: {



    search_reset(){

this.mail_id = "";
this.summary = "";
this.sectorIdSelected = 0;



this.selectdepartment('', 'الكل');
this.pass_side(0, 'الكل')
this.get_sides(0,'الكل')





},

    pass_side(id, name) {

     
           
      this.sideNameSelected = name;
      this.sideIdSelected = id;

    },

    get_sides(sector, sector_name) {
      this.sideNameSelected = "الكل";
      this.sideIdSelected = 0;
      this.sides = [];
      this.sectorNameSelected = sector_name;

      if(sector==null){sector = 0}

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
      if (type == "" || type == null) {
        type = 0;
      }
      this.sideNameSelected = "الكل";
      this.sideIdSelected = 0;
      this.sectorIdSelected = 0;
      this.sectorNameSelected = "الكل";
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

    GetAllDocuments(id) {
      this.screenFreeze = true;
      this.loading = true;
      this.$http.mailService
        .GetAllDocuments(id, Number(localStorage.getItem("AY_LW")))
        .then((res) => {
          console.log(res);

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

    GetMailsToPrint() {
      this.screenFreeze = true;
      this.loading = true;
      this.mail_to_print = [];

      this.$http.mailService
        .GetMailForArchives(
          this.page_num,
          this.page_size2,
          this.mail_id,
          this.date_from,
          this.date_to,
          this.departmentIdSelected,
          this.sideIdSelected,
          this.summary,
          this.mailType,
          this.sectorIdSelected
        )
        .then((res) => {
          console.log(res);
          this.mail_to_print = res.data.list;
          setTimeout(() => {
            this.screenFreeze = false;
            this.loading = false;

            this.$router.push({
              name: "report2",
              params: {
                dateFrom: this.date_from,
                dateTo: this.date_to,
                total_of_transaction: this.total_of_transaction,
                mails: this.mail_to_print,
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

    GetMailsForArchives() {
      this.senders = [];
      this.show_senders_mail = "";

      this.screenFreeze = true;
      this.loading = true;
      this.inboxMails = [];

      this.$http.mailService
        .GetMailForArchives(
          this.page_num,
          this.page_size,
          this.mail_id,
          this.date_from,
          this.date_to,
          this.departmentIdSelected,
          this.sideIdSelected,
          this.summary,
          this.mailType,
          this.sectorIdSelected
        )
        .then((res) => {
          console.log(res);
          this.inboxMails = res.data.list;
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

    UpdateArciveState(mail_id1) {
      var model = {
        MailId: mail_id1,
        Current: Number(localStorage.getItem("AY_LW")),
      };

      this.$http.mailService
        .UpdateArchive(model)
        .then((res) => {
          console.log(res);
          setTimeout(() => {
            this.screenFreeze = false;
            this.loading = false;
            this.GetMailsForArchives();
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

    UpdateArciveCopies() {
      var del;
      if (this.delivaryType == 1) {
        del = "سلمت للجهة";
      } else {
        del = this.delivaryName;
      }

      var model = {
        MailId: this.mail_id_copy,

        Attachments: Boolean(this.attached),
        Number_Of_Copies: Number(this.NoOfcopies),
        note: this.notes,
        delevery: del,
        Current: Number(localStorage.getItem("AY_LW")),
      };

      this.$http.mailService
        .UpdateArchive(model)
        .then((res) => {
          console.log(res);
          setTimeout(() => {
            this.screenFreeze = false;
            this.loading = false;
            this.attached = "";
            this.NoOfcopies = 0;
            this.notes = "";
            this.GetMailsForArchives();
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

    UpdateArciveDelivary() {
      var del;
      if (this.delivaryType == 1) {
        del = "سلمت للجهة";
      } else {
        del = this.delivaryName;
      }
      var model = {
        MailId: this.mail_id_copy,
        delevery: del,
        Attachments: Boolean(this.attached),
        Number_Of_Copies: Number(this.NoOfcopies),
        note: this.notes,
        Current: Number(localStorage.getItem("AY_LW")),
      };

      this.$http.mailService
        .UpdateArchive(model)
        .then((res) => {
          console.log(res);
          setTimeout(() => {
            this.screenFreeze = false;
            this.loading = false;
            this.GetMailsForArchives();

            this.delivaryType = 0;
            this.delivaryName = "";
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

    isDelivered1(delivery) {
      if (delivery == "سلمت للجهة") {
        this.delivaryType = 1;
      } else if (delivery == "لم يتم التسليم") {
        this.delivaryType = 0;
      } else {
        this.delivaryType = 2;
        this.hand = true;
      }
    },

    attached11(Attachments) {
      if (Attachments) {
        this.attached = "true";
      } else this.attached = "";
    },
  },
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
