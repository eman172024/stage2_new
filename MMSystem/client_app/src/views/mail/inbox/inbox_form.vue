<template>
  <div class="">
    <div class="h-screen bg-white overflow-hidden flex">
      <asideComponent></asideComponent>
      <div class="flex-1 bg-gray-100 w-0 overflow-y-auto pb-20">
        <div class="max-w-screen-2xl mx-auto flex flex-col md:px-8">
          <navComponent></navComponent>
          <main class="flex-1 relative focus:outline-none py-6">
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
                  {{ mailId }} - {{ department_Id }} - {{ mail_year }}
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
                      bg-gray-50
                      rounded-md
                      p-6
                    "
                  >
                    <div class="sm:col-span-3">
                      <label
                        for=""
                        class="block text-base font-semibold text-gray-800"
                      >
                        نوع البريد
                      </label>

                      <div
                        class="
                          block
                          mt-2
                          w-full
                          rounded-md
                          h-10
                          text-sm
                          border border-gray-300
                          p-2
                        "
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
                        class="
                          block
                          mt-2
                          w-full
                          rounded-md
                          h-10
                          text-sm
                          border border-gray-300
                          p-2
                        "
                      >
                        مقال صحفي
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
                        class="
                          block
                          mt-2
                          w-full
                          rounded-md
                          h-10
                          text-sm
                          border border-gray-300
                          p-2
                        "
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
                        class="
                          block
                          mt-2
                          w-full
                          rounded-md
                          h-10
                          text-sm
                          border border-gray-300
                          p-2
                        "
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
                        class="
                          block
                          mt-2
                          w-full
                          rounded-md
                          h-10
                          text-sm
                          border border-gray-300
                          p-2
                        "
                      >
                        {{ genaral_inbox_year }}
                      </div>
                    </div>
                  </section>

                  <section
                    class="
                      w-6/12
                      mr-3
                      grid grid-cols-1
                      gap-y-6 gap-x-4
                      sm:grid-cols-6
                      bg-gray-50
                      rounded-md
                      p-6
                    "
                  >
                    <div class="sm:col-span-6">
                      <label
                        for="summary"
                        class="block text-base font-semibold text-gray-800"
                      >
                        الملخص
                      </label>

                      <div
                        class="
                          block
                          mt-2
                          w-full
                          rounded-md
                          h-24
                          text-sm
                          border border-gray-300
                          p-2
                        "
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
                        class="
                          block
                          mt-2
                          w-full
                          rounded-md
                          h-24
                          text-sm
                          border border-gray-300
                          p-2
                        "
                      >
                        {{ required_action }}
                      </div>
                    </div>
                  </section>
                </section>

                <section class="col-span-2 bg-gray-50 rounded-md p-6">
                  <div class="flex justify-between items-center">
                    <h3 class="block text-base font-semibold text-gray-800">
                      المستندات
                    </h3>
                  </div>

                  <div class="relative h-64 w-full " v-if="testimage">
                    <img
                      :src="testimage"
                      alt="image"
                      class="w-full h-full rounded object-contain"
                    />

                    <div
                      class="absolute inset-0 flex justify-center items-center"
                    >
                      <button
                        type="button"
                        class="bg-green-600 hover:bg-green-500 duration-500 p-2 rounded-full focus:outline-none"
                      >
                        <svg
                          class="w-4 h-4 text-white  mx-auto"
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
                        class="bg-blue-600 hover:bg-blue-500 duration-500 p-2 rounded-full focus:outline-none mx-4"
                      >
                        <svg
                          class="w-4 h-4 text-white  mx-auto"
                          fill="none"
                          stroke="currentColor"
                          viewBox="0 0 24 24"
                          xmlns="http://www.w3.org/2000/svg"
                        >
                          <path
                            stroke-linecap="round"
                            stroke-linejoin="round"
                            stroke-width="2"
                            d="M17 17h2a2 2 0 002-2v-4a2 2 0 00-2-2H5a2 2 0 00-2 2v4a2 2 0 002 2h2m2 4h6a2 2 0 002-2v-4a2 2 0 00-2-2H9a2 2 0 00-2 2v4a2 2 0 002 2zm8-12V5a2 2 0 00-2-2H9a2 2 0 00-2 2v4h10z"
                          ></path>
                        </svg>
                      </button>

                      <button
                        type="button"
                        class="bg-red-600 hover:bg-red-500 duration-500 p-2 rounded-full focus:outline-none"
                        @click="deleteDocument(image.id, index)"
                      >
                        <svg
                          class="w-4 h-4 text-white fill-current mx-auto"
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

                  <div
                    v-if="testimage"
                    class="flex justify-between items-center mt-4"
                  >
                    <button
                      @click="previousImage()"
                      class="w-12 h-8 bg-gray-300 rounded flex justify-center items-center"
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
                    {{ indextotest + 1 }} / {{ imagesToShow.length }}
                    <!--  -->

                    <button
                      title="next"
                      @click="nextImage()"
                      class="w-12 h-8 bg-gray-300 rounded flex justify-center items-center"
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

                  <!-- <div class="h-72 w-full bg-gray-100 rounded-md mt-4">
                    <div
                      v-if="imagesToShow != ''"
                      class="mt-4 px-4 pt-4 pb-4 rounded-md"
                    >
                      <div
                        v-for="image in imagesToShow"
                        :key="image.id"
                        class="relative h-64 w-full"
                      >
                        <img :src="image.path" class="w-full h-full rounded" />
                      </div>

                      <div class="flex justify-between items-center mt-4">
                        <button
                          @click="previousImage()"
                          class="
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

                        {{ imagesToShow.length }}

                        <button
                          @click="nextImage()"
                          class="
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
                  </div> -->
                </section>
              </div>

              <section
                v-if="mailType == '2' || mailType == '3'"
                class="
                  grid grid-cols-1
                  gap-y-6 gap-x-4
                  sm:grid-cols-8
                  bg-gray-50
                  rounded-md
                  p-6
                "
              >
                <div class="sm:col-span-2">
                  <label
                    class="block text-base font-semibold text-gray-800 w-24"
                  >
                    <div v-if="mailType == '2'">توجيه البريد</div>

                    <div v-if="mailType == '3'">وارد من</div>
                  </label>

                  <div
                    class="
                      block
                      mt-2
                      w-full
                      rounded-md
                      h-10
                      text-sm
                      border border-gray-300
                      p-2
                    "
                  >
                    {{
                      mail_forwarding_sector_side
                        | mail_forwarding_sector_side_filter
                    }}
                  </div>
                </div>

                <div class="sm:col-span-2">
                  <label
                    for="send_to_sector"
                    class="block text-base font-semibold text-gray-800"
                  >
                    القطاع
                  </label>

                  <div
                    class="
                      block
                      mt-2
                      w-full
                      rounded-md
                      h-10
                      text-sm
                      border border-gray-300
                      p-2
                    "
                  >
                    {{ sectorNameSelected }}
                  </div>
                </div>

                <div class="sm:col-span-2">
                  <label
                    for="sideIdSelected"
                    class="block text-base font-semibold text-gray-800"
                  >
                    الجهة
                  </label>

                  <div
                    class="
                      block
                      mt-2
                      w-full
                      rounded-md
                      h-10
                      text-sm
                      border border-gray-300
                      p-2
                    "
                  >
                    {{ sideNameSelected }}
                  </div>
                </div>

                <div v-if="mailType == '3'" class="sm:col-span-2">
                  <label
                    class="block text-base font-semibold text-gray-800 w-24"
                  >
                    وارد إلي
                  </label>

                  <div
                    class="
                      block
                      mt-2
                      w-full
                      rounded-md
                      h-10
                      text-sm
                      border border-gray-300
                      p-2
                    "
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
                    class="
                      block
                      mt-2
                      w-full
                      rounded-md
                      h-10
                      text-sm
                      border border-gray-300
                      p-2
                    "
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
                    class="
                      block
                      mt-2
                      w-full
                      rounded-md
                      h-10
                      text-sm
                      border border-gray-300
                      p-2
                    "
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
                    class="
                      block
                      mt-2
                      w-full
                      rounded-md
                      h-10
                      text-sm
                      border border-gray-300
                      p-2
                    "
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
                    class="
                      block
                      mt-2
                      w-full
                      rounded-md
                      h-10
                      text-sm
                      border border-gray-300
                      p-2
                    "
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
                    class="
                      block
                      mt-2
                      w-full
                      rounded-md
                      h-24
                      text-sm
                      border border-gray-300
                      p-2
                    "
                  >
                    {{ action_required_by_the_entity }}
                  </div>
                </div>
              </section>

              <section class="bg-gray-50 rounded-md p-6">
                <p class="block text-base font-semibold text-gray-800">
                  الردود
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
                    v-for="reply in replies"
                    :key="reply.replyId"
                    :class="
                      reply.reply.to == my_department_id
                        ? 'justify-start'
                        : 'justify-end'
                    "
                    class="w-full my-2 flex px-4"
                  >
                    <div
                      :class="
                        reply.reply.to == my_department_id
                          ? 'bg-blue-700'
                          : 'bg-gray-700'
                      "
                      class="
                        
                        text-white
                        max-w-10/12
                        py-4
                        leading-9
                        px-4
                        rounded-2xl
                      "
                    >
                      {{ reply.reply.mail_detail }}
                    </div>
                  </div>
                </div>

                <div class="flex justify-between items-center mt-4">
                  <div class="w-8/12">
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
                        focus:outline-none
                        focus:border-gray-300
                        p-2
                      "
                      v-model="reply_to_add"
                    >
                    </textarea>
                  </div>
                  <!-- <div class="w-2/12 mr-4">
                    <label
                      class="
                        w-full
                        flex
                        items-center
                        justify-center
                        h-20
                        py-2
                        bg-white
                        rounded-lg
                        tracking-wide
                        text-green-600
                        border border-green-600
                        cursor-pointer
                        hover:text-white
                        hover:bg-green-600
                        focus:outline-none
                        duration-300
                      "
                    >
                      <svg
                        class="w-6 h-6 ml-2"
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
                      <span class="leading-normal">الماسح الضوئي</span>
                      <input class="hidden" type="button" @click="scanToJpg" />
                    </label>
                  </div> -->
                  <div class="w-2/12 mr-4">
                    <button
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
                        hover:text-white
                        hover:bg-blue-600
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
      class="w-screen h-screen bg-black bg-opacity-30 absolute inset-0 z-50 flex justify-center items-center"
    >
      <div v-if="loading" class="">
        <svgLoadingComponent></svgLoadingComponent>
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

  mounted() {
    this.my_user_id = localStorage.getItem("userId");
    this.my_department_id = localStorage.getItem("departmentId");

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
      sectorNameSelected: "",
      sectorIdSelected: "",

      sides: [],

      sideselect: false,
      sideNameSelected: "",
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

      mail_forwarding_sector_side: "",

      loading: false,
      screenFreeze: false,

      replies: [],
    };
  },
  methods: {
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
          this.classification = res.data.mail.clasification;
          this.mailType = res.data.mail.mail_Type;
          this.general_incoming_number = res.data.mail.genaral_inbox_Number;
          this.genaral_inbox_year = res.data.mail.genaral_inbox_year;
          this.required_action = res.data.mail.action_Required;

          this.replies = res.data.list;

          setTimeout(() => {
            document.getElementById(
              "scroll"
            ).scrollTop = document.getElementById("scroll").scrollHeight;
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
        this.testimage = this.imagesToShow[this.indextotest].path;
      }
    },

    nextImage() {
      if (this.indextotest < this.imagesToShow.length - 1) {
        this.indextotest++;
        this.testimage = this.imagesToShow[this.indextotest].path;
      }
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
      }

      this.AddReplyDocument();
    },

    AddReplyDocument() {
      console.log("Ayoub");
    },

    AddReply() {
      this.screenFreeze = true;
      this.loading = true;

      var ReplyViewModel = {
        send_ToId: Number(this.sends_id),
        from: Number(2),
        reply: {
          mail_detail: this.reply_to_add,
          To: Number(this.department_Id),
          
        },
      };
      this.$http.mailService
        .AddReply(ReplyViewModel)
        .then((res) => {
          setTimeout(() => {
            console.log(res);
            // this.documentSection = true;
            // this.proceduresSection = true;

            this.loading = false;
            this.screenFreeze = false;

            this.reply_to_add = "";
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
  },
};
</script>
