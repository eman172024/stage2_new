<template>
  <div class="">
    <div class="h-screen bg-gray-50 overflow-hidden flex">
      <asideComponent></asideComponent>
      <div class="flex-1 bg-gray-100 w-0 overflow-y-auto">
        <div class="max-w-screen-2xl  mx-auto flex flex-col md:px-8">
          <navComponent></navComponent>
          <main class="flex-1 relative focus:outline-none py-6">
            <div class="flex justify-between items-center">
                <h3 class="text-xl font-semibold text-gray-900">
                معلومات البريد
                </h3>
                <!-- 
                    animate-bounce
                 -->
                <div v-if="mailId" class="float-left text-base font-semibold text-gray-800 ">
                    رقم الرسالة 

                    <span class="mr-4 underline font-bold text-2xl">
                         {{mailId}} - {{department_Id}} - {{mail_year}}
                    </span>
                </div>
            </div>

            <div class="mt-6 space-y-6 ">

                <div class="grid grid-cols-7 gap-6">
                    <section class="col-span-5 flex justify-between items-stretch">
                        <section class="w-6/12 ml-3 grid grid-cols-1 gap-y-6 gap-x-4 sm:grid-cols-6 bg-gray-50 rounded-md p-6">
                            <fieldset class="sm:col-span-6">
                                <div class=" flex items-center">
                                    <legend class=" text-base font-semibold text-gray-800 w-24">
                                    نوع البريد
                                    </legend>
                                    <div class="flex items-center w-28">
                                        <input
                                            v-model="mailType"
                                            id="internal"
                                            type="radio"
                                            name="type"
                                            class="h-4 w-4"
                                            value="1"
                                        />
                                        <label
                                            for="internal"
                                            class="mr-2 block  text-gray-800"
                                        >
                                            داخلي
                                        </label>
                                    </div>

                                    <div class="flex items-center w-28">
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
                                            class="mr-2 block  text-gray-800"
                                        >
                                            صادر خارجي
                                        </label>
                                    </div>

                                    <div class="flex items-center w-28">
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
                                            class="mr-2 block  text-gray-800"
                                        >
                                            وارد خارجي 
                                        </label>
                                    </div>
                                </div>
                            </fieldset>

                            <div class="sm:col-span-6">
                                <label
                                for="summary"
                                class="block text-base font-semibold text-gray-800"
                                >
                                الملخص
                                </label>
                                <textarea
                                    v-model="summary"
                                    id="summary"
                                    rows="3"
                                    class="block mt-2 w-full text-sm rounded-md border border-gray-200 hover:shadow-sm focus:outline-none focus:border-gray-300 p-2"
                                >
                                </textarea>
                            </div>

                            <div class="sm:col-span-3">
                                <label
                                for="classification"
                                class="block text-base font-semibold text-gray-800"
                                >
                                التصنيف
                                </label>
                                <select v-model="classification" id="classification" class="block mt-2 w-full h-10 text-sm rounded-md border border-gray-200 hover:shadow-sm focus:outline-none focus:border-gray-300 p-2">
                                    <option disabled selected value="0">
                                       إختر التصنيف
                                    </option>
                                    <option v-for="classification in classifications" :key="classification.id" :value="classification.id">
                                        {{ classification.name }}
                                    </option>
                                   
                                </select>
                            </div>

                            <div class="sm:col-span-3">
                                <label
                                for="date"
                                class="block text-base font-semibold text-gray-800"
                                >
                                التاريخ
                                </label>
                                <input
                                    v-model="releaseDate"
                                    type="date"
                                    id="date"
                                    class="block mt-2 w-full rounded-md h-10 text-sm border border-gray-200 hover:shadow-sm focus:outline-none focus:border-gray-300 p-2"
                                />
                            </div>

                            <div class="sm:col-span-3">
                                <label
                                for="general_incoming_number"
                                class="block text-base font-semibold text-gray-800"
                                >
                                رقم الوارد العام
                                </label>
                                <input
                                    v-model="general_incoming_number"
                                    type="number"
                                    id="general_incoming_number"
                                    class="block mt-2 h-10 text-sm w-full rounded-md border border-gray-200 hover:shadow-sm focus:outline-none focus:border-gray-300 px-2"
                                    required
                                />
                            </div>

                            <div class="sm:col-span-3">
                                <label
                                for="year"
                                class="block text-base font-semibold text-gray-800"
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
                                    class="block mt-2 w-full rounded-md h-10 text-sm border border-gray-200 hover:shadow-sm focus:outline-none focus:border-gray-300 p-2"
                                />
                            </div>
                        </section>

                        <section class="w-6/12 mr-3 grid grid-cols-1 gap-y-6 gap-x-4 sm:grid-cols-6 bg-gray-50 rounded-md p-6">
                            <div class="sm:col-span-6">
                                <label
                                for="action_required"
                                class="block text-base font-semibold text-gray-800"
                                >
                                الإجراء المطلوب
                                </label>
                                <textarea
                                    v-model="required_action"
                                    id="action_required"
                                    rows="3"
                                    class="block mt-2 w-full text-sm rounded-md border border-gray-200 hover:shadow-sm focus:outline-none focus:border-gray-300 p-2"
                                >
                                </textarea>
                            </div>

                            <div class="sm:col-span-6 grid grid-cols-1 gap-y-6 gap-x-4 sm:grid-cols-6">


                                <div class="sm:col-span-3">
                                    <label
                                    for="department"
                                    class="block text-base font-semibold text-gray-800"
                                    >
                                    الإدارات
                                    </label>

                                    <div class="relative">
                                        <button @click="departmentselect = !departmentselect" id="department" class="text-right block mt-2 w-full rounded-md h-10 border text-sm bg-white border-gray-200 hover:shadow-sm focus:outline-none focus:border-gray-300 p-2">
                                            {{ departmentNameSelected }}
                                        </button>

                                        <div v-if="departmentselect" class="border text-sm bg-white border-gray-200 p-2 absolute w-full z-20 shadow h-40 overflow-y-scroll rounded-b-md">
                                            <button class="block focus:outline-none w-full my-1 text-right" @click="selectdepartment(department.id, department.departmentName); departmentselect = !departmentselect" v-for="department in departments" :key="department.id">
                                                {{ department.departmentName }}    
                                            </button>
                                        </div>
                                    </div>

                                    
                                </div>

                                <div class="sm:col-span-2">
                                    <label
                                        for="measure"
                                        class="block text-base font-semibold text-gray-800"
                                    >
                                    الإجراء
                                    </label>

                                    <div class="relative">
                                        <button @click="measureselect = !measureselect" id="measure" class="text-right block mt-2 w-full rounded-md h-10 border text-sm bg-white border-gray-200 hover:shadow-sm focus:outline-none focus:border-gray-300 p-2">
                                            {{ measureNameSelected }}
                                        </button>

                                        <div v-if="measureselect" class="border text-sm bg-white border-gray-200 p-2 absolute w-full z-20 shadow h-40 overflow-y-scroll rounded-b-md">
                                            <button class="block focus:outline-none w-full my-1 text-right" @click="selectmeasure(measure.measuresId, measure.measuresName); measureselect = !measureselect" v-for="measure in measures" :key="measure.measuresId">
                                                {{ measure.measuresName }}    
                                            </button>
                                        </div>
                                    </div>

                                </div>

                                <div class="sm:col-span-1 flex justify-end">
                                    <button v-if="add_button_consignees" @click="add_to_array_of_side_measure()" class="mt-10 rounded-md text-green-400 duration-200 hover:text-green-500 text-base font-semibold w-8 h-8">
                                        <svg class="fill-current w-full h-full" version="1.1" id="Capa_1" x="0px" y="0px" viewBox="0 0 512 512" style="enable-background:new 0 0 512 512;" xml:space="preserve">
                                            <g>
                                                <g>
                                                    <path d="M256,0C114.833,0,0,114.833,0,256s114.833,256,256,256s256-114.853,256-256S397.167,0,256,0z M256,472.341
                                                        c-119.275,0-216.341-97.046-216.341-216.341S136.725,39.659,256,39.659S472.341,136.705,472.341,256S375.295,472.341,256,472.341z
                                                        "/>
                                                </g>
                                            </g>
                                            <g>
                                                <g>
                                                    <path d="M355.148,234.386H275.83v-79.318c0-10.946-8.864-19.83-19.83-19.83s-19.83,8.884-19.83,19.83v79.318h-79.318
                                                        c-10.966,0-19.83,8.884-19.83,19.83s8.864,19.83,19.83,19.83h79.318v79.318c0,10.946,8.864,19.83,19.83,19.83
                                                        s19.83-8.884,19.83-19.83v-79.318h79.318c10.966,0,19.83-8.884,19.83-19.83S366.114,234.386,355.148,234.386z"/>
                                                </g>
                                            </g>
                                        </svg>
                                    </button>
                                </div>
                            </div>

                            <div class="sm:col-span-6">
                                <label
                                    for="consignees"
                                    class="block text-base font-semibold text-gray-800"
                                >
                                    المرسل إليهم    
                                </label>
                                <div class="mt-2 w-full rounded-md border border-gray-200 p-2 h-24 overflow-y-scroll flex flex-wrap items-center">

                                    <div v-for="consignee in consignees" :key="consignee.side" class="border border-gary-200 rounded-md text-sm flex items-center p-2 m-0.5">
                                        {{ consignee.departmentName }} , {{ consignee.measureName }}
                                        <!--  -->
                                        <button v-if="remove_button_consignees" @click="remove_to_array_of_side_measure(consignee.departmentId)" class="mr-1 rounded-full">
                                            <svg aria-hidden="true" focusable="false" data-prefix="far" data-icon="times-circle" class="w-5 h-5 stroke-current text-red-400 hover:text-red-500 duration-200" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512">
                                                <path fill="currentColor" d="M256 8C119 8 8 119 8 256s111 248 248 248 248-111 248-248S393 8 256 8zm0 448c-110.5 0-200-89.5-200-200S145.5 56 256 56s200 89.5 200 200-89.5 200-200 200zm101.8-262.2L295.6 256l62.2 62.2c4.7 4.7 4.7 12.3 0 17l-22.6 22.6c-4.7 4.7-12.3 4.7-17 0L256 295.6l-62.2 62.2c-4.7 4.7-12.3 4.7-17 0l-22.6-22.6c-4.7-4.7-4.7-12.3 0-17l62.2-62.2-62.2-62.2c-4.7-4.7-4.7-12.3 0-17l22.6-22.6c4.7-4.7 12.3-4.7 17 0l62.2 62.2 62.2-62.2c4.7-4.7 12.3-4.7 17 0l22.6 22.6c4.7 4.7 4.7 12.3 0 17z"></path>
                                            </svg>
                                        </button>
                                    </div>
                                    
                                </div>
                            </div>
                        </section>
                    </section>
                    
                    <section v-if="documentSection" class="col-span-2 bg-gray-50 rounded-md p-6">
                        <div class="flex justify-between items-center">
                            <h3 class="block text-base font-semibold text-gray-800">المستندات</h3>

                            <label v-if="mailId" class="w-48 flex justify-center items-center py-2 bg-white rounded-lg tracking-wide border border-green-600 cursor-pointer hover:text-white hover:bg-green-600 focus:outline-none duration-300">
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
                                <span class="text-sm leading-normal">الماسح الضوئي</span>
                                <input class="hidden" type="button" @click="scanToJpg" />
                            </label>
                        </div>

                        <div class="h-72 w-full bg-gray-100 rounded-md mt-4">
                            <div v-if=" imagesToSend != '' || imagesToShow != '' " class="mt-4 px-4 pt-4 pb-4 rounded-md">

                                


                                <div v-for="(image, index) in imagesToSend" :key="image.indexOfimagesToShow" class="relative h-60 overflow-x-scroll w-full">
                                    <div class="absolute inset-x-0 bottom-2 flex justify-center items-center">
                                        <button
                                            type="button"
                                            class="bg-red-600 hover:bg-red-500 duration-500 p-2 flex justify-center items-center rounded-full focus:outline-none ml-2"
                                            @click="removeImage(index)"
                                            >
                                            <svg class="w-5 h-5 stroke-current text-white" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M19 7l-.867 12.142A2 2 0 0116.138 21H7.862a2 2 0 01-1.995-1.858L5 7m5 4v6m4-6v6m1-10V4a1 1 0 00-1-1h-4a1 1 0 00-1 1v3M4 7h16"></path></svg>
                                        </button>

                                        <button class="bg-green-600 hover:bg-green-500 duration-500 p-2 flex justify-center items-center rounded-full focus:outline-none mr-2">
                                            <svg class="w-5 h-5 stroke-current text-white" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M21 21l-6-6m2-5a7 7 0 11-14 0 7 7 0 0114 0zM10 7v3m0 0v3m0-3h3m-3 0H7"></path></svg>
                                        </button>
                                   </div>
                                    <img :src="image.baseAs64" class="w-full h-full rounded" />
                                    
                                </div>

                                 <div class="relative h-64 w-full " >

                                    <img :src="testimage" alt="image" class="w-full h-full rounded object-contain">

                                    <div class="absolute inset-0 flex justify-center items-center">

                                        <button type="button" class="bg-green-600 hover:bg-green-500 duration-500 p-2 rounded-full focus:outline-none">
                                            <svg class="w-4 h-4 text-white  mx-auto" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M21 21l-6-6m2-5a7 7 0 11-14 0 7 7 0 0114 0zM10 7v3m0 0v3m0-3h3m-3 0H7"></path></svg>
                                        </button>

                                        <button type="button" class="bg-blue-600 hover:bg-blue-500 duration-500 p-2 rounded-full focus:outline-none mx-4">
                                            <svg class="w-4 h-4 text-white  mx-auto" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M17 17h2a2 2 0 002-2v-4a2 2 0 00-2-2H5a2 2 0 00-2 2v4a2 2 0 002 2h2m2 4h6a2 2 0 002-2v-4a2 2 0 00-2-2H9a2 2 0 00-2 2v4a2 2 0 002 2zm8-12V5a2 2 0 00-2-2H9a2 2 0 00-2 2v4h10z"></path></svg>
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
                                

                                 <div class="flex justify-between items-center mt-4">
                                    <button @click="previousImage()" class="w-12 h-8 bg-gray-300 rounded flex justify-center items-center">
                                        <svg class="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5l7 7-7 7"></path></svg>
                                    </button>
                                        {{indextotest +1}} / {{ imagesToShow.length }}

                                        <button title="next" @click="nextImage()" class="w-12 h-8 bg-gray-300 rounded flex justify-center items-center">
                                        <svg class="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M15 19l-7-7 7-7"></path></svg>
                                    </button>
                                </div>

                                <div class="flex justify-center mt-10">
                                    <button
                                        @click="UploadImagesMail"
                                        type="button"
                                        class="mr-3 flex justify-center items-center py-2 px-4 border border-transparent shadow-sm text-sm font-semibold rounded-md text-white bg-cyan-600 hover:bg-cyan-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-cyan-700"
                                    >
                                        <svg
                                        class="w-4 h-4 stroke-current text-white ml-2 fill-current"
                                        height="512"
                                        viewBox="0 0 55 60"
                                        width="512"
                                        xmlns="http://www.w3.org/2000/svg"
                                        >
                                        <g id="Page-1" fill-rule="evenodd">
                                            <g id="040---Save-File" fill-rule="nonzero">
                                            <path
                                                id="Shape"
                                                d="m53 5v39h-7c-2.7600532.0033061-4.9966939 2.2399468-5 5v7h-3c-.5522847 0-1 .4477153-1 1s.4477153 1 1 1h4c.2651948-.0000566.5195073-.1054506.707-.293l12-12c.1875494-.1874927.2929434-.4418052.293-.707v-40c-.0033061-2.76005315-2.2399468-4.99669388-5-5h-40c-2.76005315.00330612-4.99669388 2.23994685-5 5v17c0 .5522847.44771525 1 1 1s1-.4477153 1-1v-17c0-1.65685425 1.34314575-3 3-3h40c1.6568542 0 3 1.34314575 3 3zm-7 41h5.586l-8.586 8.586v-5.586c0-1.6568542 1.3431458-3 3-3z"
                                            ></path>
                                            <path
                                                id="Shape"
                                                d="m14 6h-2c-.5522847 0-1 .44771525-1 1s.4477153 1 1 1h2c.5522847 0 1-.44771525 1-1s-.4477153-1-1-1z"
                                            ></path>
                                            <path
                                                id="Shape"
                                                d="m48 6h-30c-.5522847 0-1 .44771525-1 1s.4477153 1 1 1h30c.5522847 0 1-.44771525 1-1s-.4477153-1-1-1z"
                                            ></path>
                                            <path
                                                id="Shape"
                                                d="m14 12h-2c-.5522847 0-1 .4477153-1 1s.4477153 1 1 1h2c.5522847 0 1-.4477153 1-1s-.4477153-1-1-1z"
                                            ></path>
                                            <path
                                                id="Shape"
                                                d="m18 14h23c.5522847 0 1-.4477153 1-1s-.4477153-1-1-1h-23c-.5522847 0-1 .4477153-1 1s.4477153 1 1 1z"
                                            ></path>
                                            <path
                                                id="Shape"
                                                d="m14 18h-2c-.5522847 0-1 .4477153-1 1s.4477153 1 1 1h2c.5522847 0 1-.4477153 1-1s-.4477153-1-1-1z"
                                            ></path>
                                            <path
                                                id="Shape"
                                                d="m18 20h16c.5522847 0 1-.4477153 1-1s-.4477153-1-1-1h-16c-.5522847 0-1 .4477153-1 1s.4477153 1 1 1z"
                                            ></path>
                                            <path
                                                id="Shape"
                                                d="m51 21c0-.5522847-.4477153-1-1-1s-1 .4477153-1 1v14c0 .5522847.4477153 1 1 1s1-.4477153 1-1z"
                                            ></path>
                                            <path
                                                id="Shape"
                                                d="m50 38c-.5522847 0-1 .4477153-1 1v2c0 .5522847.4477153 1 1 1s1-.4477153 1-1v-2c0-.5522847-.4477153-1-1-1z"
                                            ></path>
                                            <path
                                                id="Shape"
                                                d="m3 60h28c1.6568542 0 3-1.3431458 3-3v-28c0-1.6568542-1.3431458-3-3-3h-28c-1.65685425 0-3 1.3431458-3 3v28c0 1.6568542 1.34314575 3 3 3zm4-2v-2h20v2zm6-23v-7h14v7c0 .5522847-.4477153 1-1 1h-12c-.5522847 0-1-.4477153-1-1zm-2-7v7c.0033144.3414397.0655622.679743.184 1h-3.184c-.55228475 0-1-.4477153-1-1v-7zm-9 1c0-.5522847.44771525-1 1-1h2v7c0 1.6568542 1.34314575 3 3 3h18c1.6568542 0 3-1.3431458 3-3v-7h2c.5522847 0 1 .4477153 1 1v28c0 .5522847-.4477153 1-1 1h-2v-2c0-1.1045695-.8954305-2-2-2h-20c-1.1045695 0-2 .8954305-2 2v2h-2c-.55228475 0-1-.4477153-1-1z"
                                            ></path>
                                            <path
                                                id="Shape"
                                                d="m17 52c3.3137085 0 6-2.6862915 6-6s-2.6862915-6-6-6-6 2.6862915-6 6c.0033074 3.3123376 2.6876624 5.9966926 6 6zm0-10c2.209139 0 4 1.790861 4 4s-1.790861 4-4 4-4-1.790861-4-4 1.790861-4 4-4z"
                                            ></path>
                                            <circle id="Oval" cx="16" cy="45" r="1"></circle>
                                            </g>
                                        </g>
                                        </svg>

                                        حفظ المستندات
                                    </button>
                                </div>
                            </div>
                        </div>
                    </section>
                </div> 

                <section v-if="mailType == '2' || mailType == '3'" class="col-span-2 grid grid-cols-1 gap-y-6 gap-x-4 sm:grid-cols-6 bg-gray-50 rounded-md p-6">

                    <div class="sm:col-span-6 grid grid-cols-1 gap-y-6 gap-x-4 sm:grid-cols-6">
                        
                        <fieldset class="sm:col-span-3">
                            <div class="flex items-center">
                                <legend class="block text-base font-semibold text-gray-800 w-24">
                                    <div v-if="mailType == '2'">
                                        توجيه البريد
                                    </div>

                                    <div v-if="mailType == '3'">
                                        وارد من
                                    </div>
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
                                    <label
                                        for="Branches"
                                        class="mr-3 block text-gray-800"
                                    >
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

                        <br>

                        <div class="sm:col-span-3">
                            <label
                                for="send_to_sector"
                                class="block text-base font-semibold text-gray-800"
                            >
                                القطاع
                            </label>
                            

                            <div class="relative">
                                <button @click="sectorselect = !sectorselect" id="department" class="text-right block mt-2 w-full rounded-md h-10 border text-sm bg-white border-gray-200 hover:shadow-sm focus:outline-none focus:border-gray-300 p-2">
                                    {{ sectorNameSelected }}
                                </button>

                                <div v-if="sectorselect" class="border text-sm bg-white border-gray-200 p-2 absolute w-full z-20 shadow h-40 overflow-y-scroll rounded-b-md">
                                    <button class="block focus:outline-none w-full my-1 text-right" @click="get_sides(sector.id, sector.section_Name ); sectorselect = !sectorselect" v-for="sector in sectors" :key="sector.id">
                                        {{ sector.section_Name }}    
                                    </button>
                                </div>
                            </div>
                            
                        </div>

                        <div class="sm:col-span-3">
                            <label
                                for="sideIdSelected"
                                class="block text-base font-semibold text-gray-800"
                            >
                                الجهة
                            </label>

                            <div class="relative">
                                <button @click="sideselect = !sideselect" id="department" class="text-right block mt-2 w-full rounded-md h-10 border text-sm bg-white border-gray-200 hover:shadow-sm focus:outline-none focus:border-gray-300 p-2">
                                    {{ sideNameSelected }}
                                </button>

                                <div v-if="sideselect" class="border text-sm bg-white border-gray-200 p-2 absolute w-full z-20 shadow h-40 overflow-y-scroll rounded-b-md">
                                    <button class="block focus:outline-none w-full my-1 text-right" @click="pass_side(side.id, side.section_Name ); sideselect = !sideselect" v-for="side in sides" :key="side.id">
                                        {{ side.section_Name }}    
                                    </button>
                                </div>
                            </div>

                        </div>

                    </div>

                    <div v-if="mailType == '2'" class="sm:col-span-6">
                        <label
                        for="action_required"
                        class="block text-base font-semibold text-gray-800"
                        >
                         الإجراء المطلوب من الجهة
                        </label>
                        <textarea
                            v-model="action_required_by_the_entity"
                            id="action_required"
                            rows="3"
                            class="block mt-2 w-full text-sm rounded-md border border-gray-200 hover:shadow-sm focus:outline-none focus:border-gray-300 p-2"
                        >
                        </textarea>
                    </div>

                    <div v-if="mailType == '3' " class="sm:col-span-6 grid grid-cols-1 mt-6 gap-y-6 gap-x-4 sm:grid-cols-6 rounded-md">
                        <fieldset class="sm:col-span-3">
                            <div class="flex items-center">

                                <legend class="block text-base font-semibold text-gray-800 w-24">
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
                                    <label
                                        for="chief"
                                        class="mr-3 block text-gray-800"
                                    >
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
                                        value="3"
                                    />
                                    <label
                                        for="proxy"
                                        class="mr-3 block text-gray-800"
                                    >
                                        وكيل الهيئة
                                    </label>
                                </div>
                            </div>
                        </fieldset>

                        <fieldset class="sm:col-span-3">
                            <div class="flex items-center">

                                <legend class="block text-base font-semibold text-gray-800 w-24">
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
                                    <label
                                        for="directly"
                                        class="mr-3 block text-gray-800"
                                    >
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
                                    <label
                                        for="copy"
                                        class="mr-3 block text-gray-800"
                                    >
                                        صورة
                                    </label>
                                </div>
                            </div>
                        </fieldset>

                        <div class="sm:col-span-2">
                            <label
                                for="entity_mail_date"
                                class="block text-base font-semibold text-gray-800"
                            >
                                تاريخ رسالة الجهة
                            </label>
                            <input
                                v-model="entity_mail_date"
                                type="date"
                                id="entity_mail_date"
                                class="block mt-2 w-full rounded-md h-10 border border-gray-200 hover:shadow-sm focus:outline-none focus:border-gray-300 px-2"
                                required
                            />
                        </div>

                        <div class="sm:col-span-2">
                            <label
                                for="entity_reference_number"
                                class="block text-base font-semibold text-gray-800"
                            >
                                رقم إشارة الجهة
                            </label>
                            <input
                                v-model="entity_reference_number"
                                type="number"
                                id="entity_reference_number"
                                class="block mt-2 h-10 w-full rounded-md border border-gray-200 hover:shadow-sm focus:outline-none focus:border-gray-300 px-2"
                                required
                            />
                        </div>

                        <div class="sm:col-span-2">
                            <label
                                for="procedure_type"
                                class="block text-base font-semibold text-gray-800"
                            >
                                نوع الإجراء
                            </label>
                            <select v-model="procedure_type" id="procedure_type" class="block mt-2 w-full rounded-md h-10 border border-gray-200 hover:shadow-sm focus:outline-none focus:border-gray-300 p-2">
                                <option value="1">
                                    لم تعرض
                                </option>
                                <option value="2">
                                    عرضت
                                </option>
                            </select>
                        </div>
                    </div>

                </section> 

                <section>
                    <div class="sm:col-span-6 flex items-center justify-end mt-10">
                        <div class="flex justify-end ml-6">
                            <!-- @click="saveMail()" -->
                           <button
                                class="flex justify-center items-center py-2 px-8 border border-transparent shadow-sm text-sm font-medium rounded-md border-green-600 text-green-600 hover:shadow-lg focus:shadow-none duration-300 focus:outline-none"
                                
                            >
                                <svg class="w-5 h-5 stroke-current ml-2 fill-current" enable-background="new 0 0 512 512" height="512" viewBox="0 0 512 512" width="512" xmlns="http://www.w3.org/2000/svg"><g><path d="m115.817 138.734h195.166v30h-195.166z"/><path d="m115.817 198.734h195.166v30h-195.166z"/><path d="m115.817 258.734h195.166v30h-195.166z"/><path d="m438.304 330.762c-15.36-15.361-34.297-25.016-54.154-28.976v-301.786h-272.714l-68.786 68.787v372.418h220.429c5.203 14.767 13.686 28.302 25.084 39.7 20.052 20.052 46.713 31.095 75.071 31.095 28.357 0 55.019-11.043 75.07-31.096 41.395-41.394 41.395-108.747 0-150.142zm-316.92-298.283v46.255h-46.255zm-48.734 378.726v-302.47h78.734v-78.735h202.766v270.11c-24.084 2.05-47.598 12.262-65.987 30.652-20.053 20.052-31.096 46.713-31.096 75.071 0 1.798.045 3.588.133 5.371h-184.55zm344.442 48.486c-14.386 14.386-33.513 22.309-53.858 22.309-20.346 0-39.473-7.923-53.858-22.309-14.386-14.386-22.309-33.513-22.309-53.857s7.923-39.472 22.309-53.858c14.851-14.85 34.351-22.273 53.858-22.273 19.502 0 39.011 7.426 53.857 22.273 29.698 29.697 29.698 78.018.001 107.715z"/><path d="m378.233 365.807h-30v25.026h-25.026v30h25.026v25.027h30v-25.027h25.027v-30h-25.027z"/></g></svg>
                                جديد
                            </button> 
                        </div>

                        <div v-if="updataButton" class="flex justify-end ml-6">
                            <button
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

                        <div v-if="deleteButton" class="flex justify-end ml-6">
                            <button
                                @click="deleteMail"
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

                        <div v-if="saveButton" class="flex justify-end">
                            <button
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

                        <div v-if="sendButton" class="flex justify-end">
                            <button
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

    this.my_user_id = localStorage.getItem('userId')
    this.my_department_id = localStorage.getItem('departmentId')
  

    if (this.$route.params.mail) {

     

        if(this.$route.params.type == '1'){
            this.to_test_passing_mail_type = 1            
        }
        if(this.$route.params.type == '2'){
            this.to_test_passing_mail_type = 2

        }
        if(this.$route.params.type == '3'){
            this.to_test_passing_mail_type = 3
        }

        


        this.mailId = this.$route.params.mail;

        this.sendButton = true;
        this.updataButton = true;
        this.deleteButton = true;
        this.saveButton = false;

        this.getMailById();

    }else{

    }
      this.GetAllClassifications();
      this.GetAllMeasures();
      this.GetAllDepartments();


   

  },

  components: {
    asideComponent,
    navComponent,
    svgLoadingComponent,
  },

  data() {
    return {
        testimage:'',
        indextotest: 0,



















        classifications:[],

        measures:[],
        measureselect : false,
        measureNameSelected: '',
        measureIdSelected: '',

        departments:[],
        departmentselect : false,
        departmentNameSelected: '',
        departmentIdSelected: '',

        consignees:[],


        releaseDate:'',
        summary:'',
        classification: '',
        mailType:'',
        general_incoming_number:'',
        genaral_inbox_year:'',
        required_action: '',

        mailId: '',
        external_mailId: '',

        saveButton: true,
        sendButton: false,
        updataButton: false,
        deleteButton: false,

        mail_Number: '',
        department_Id: '',

        imagesToSend: [],
        indexOfimagesToShow: 0,

        my_user_id: '',
        my_department_id : '',

        action_required_by_the_entity:'',
        mail_forwarding:'',

        send_to_sector:'',

        sectors:[],
        sectorselect : false,
        sectorNameSelected: '',
        sectorIdSelected: '',

        sides:[],

        sideselect : false,
        sideNameSelected: '',
        sideIdSelected: '',

        send_to_side:'',

        entity_reference_number:'',
        procedure_type:'',
        entity_mail_date:'',
        mail_ward_type:'',
        ward_to:'',


        to_test_passing_mail_type : '',
        remove_button_consignees: true,
        add_button_consignees: true,











        isThisMobile: false,

        
        
        mail_num:'1955 - 12 -2021',
        
        
        
        
        
        send_to_sector_ward:'',
        
        
        
        
        
        side: 0,
        action:0,
        
        mail_year : '',
       
        imagesToShow: [],



        

        showAlert: false,
     
        addErorr: null,

        documentSection : true,
        proceduresSection : false,

        marginalizedDocuments: [],
      
      // 
      //name: this.$authenticatedUser.name,
      // userName: this.$authenticatedUser.userName,
      // validity: this.$authenticatedUser.validity,

      
      loading: false,
      screenFreeze: false,
    };
  },
  methods: {

        previousImage(){
            if ( this.indextotest > 0 ) {
                this.indextotest--
                this.testimage = this.imagesToShow[this.indextotest].path
            }  
        },

        nextImage(){
            if ( this.indextotest < this.imagesToShow.length-1 ) {
                this.indextotest++
                this.testimage = this.imagesToShow[this.indextotest].path
            }
        },

        getMailById(){
            this.$http.mailService
            .GetMailById(this.mailId, this.to_test_passing_mail_type)
            .then((res) => {

                if(res.data.mail.is_send == true){
                    this.sendButton = false
                    this.deleteButton = false
                    this.remove_button_consignees = false
                    this.add_button_consignees = false
                }

                this.mail_Number = res.data.mail.mail_Number
                this.department_Id = res.data.mail.department_Id
                this.releaseDate = res.data.mail.date_Of_Mail
                this.summary = res.data.mail.mail_Summary
                this.classification = res.data.mail.clasification
                this.mailType = res.data.mail.mail_Type
                this.general_incoming_number = res.data.mail.genaral_inbox_Number
                this.genaral_inbox_year = res.data.mail.genaral_inbox_year
                this.required_action = res.data.mail.action_Required

                this.consignees = res.data.actionSenders

                this.imagesToShow = res.data.resourcescs


                this.testimage = this.imagesToShow[0].path

                if(this.to_test_passing_mail_type == '2'){

                    this.external_mailId = res.data.external.id

                    this.action_required_by_the_entity = res.data.external.action_required_by_the_entity

                    this.mail_forwarding = res.data.external.action

                    this.get_sectors(this.mail_forwarding)

                    this.sectorNameSelected = res.data.sector[0].section_Name
                    this.sectorIdSelected = res.data.sector[0].id

                    this.get_sides(this.sectorIdSelected, this.sectorNameSelected)
                    this.sideNameSelected = res.data.side[0].section_Name
                    this.sideIdSelected = res.data.side[0].id
                }
                if(this.to_test_passing_mail_type == '3'){

                    this.external_mailId = res.data.external.id
                   
                    this.mail_forwarding = res.data.external.action
                  
                    this.get_sectors(this.mail_forwarding)

                    this.sectorNameSelected = res.data.sector[0].section_Name
                    this.sectorIdSelected = res.data.sector[0].id

                    this.get_sides(this.sectorIdSelected, this.sectorNameSelected)
                    this.sideNameSelected = res.data.side[0].section_Name
                    this.sideIdSelected = res.data.side[0].id

                    this.ward_to = res.data.external.to

                    this.mail_ward_type = res.data.external.type

                    this.entity_mail_date = res.data.external.send_time

                    this.entity_reference_number = res.data.external.entity_reference_number

                    this.procedure_type = res.data.external.procedure_type
                }

                

               

                



            //   this.GetDocmentForMail();
            //   this.GetDocmentForMailToShow();


            //   this.GetProcessingResponses()

            })
            .catch((err) => {
                console.log(err)
            });
        },

        pass_side(id, name){
            this.sideNameSelected = name
            this.sideIdSelected = id
        },

        get_sides(sector, sector_name){
            this.sideNameSelected = ''
                this.sideIdSelected = ''
            this.sides = []
            this.sectorNameSelected = sector_name
            this.$http.sectorsService
                .GetSides(sector)
                .then((res) => {
                    console.log(res)
                    this.sides = res.data 
                })
                .catch((err) => {
                    console.log(err)
                });
        },

        get_sectors(type){
            
                this.sideNameSelected = ''
                this.sideIdSelected = ''
                this.sectorIdSelected = ''
                this.sectorNameSelected = ''
                this.sectors = []
                this.sides = []

            this.$http.sectorsService
                .GetSectors(type)
                .then((res) => {
                    this.sectors = res.data 
                })
                .catch((err) => {
                    console.log(err)
                });
        },

        

        selectmeasure(id, name){
            this.measureNameSelected = name;
            this.measureIdSelected = id;
        },

        selectdepartment(id, name){
            this.departmentNameSelected = name;
            this.departmentIdSelected = id;
        },

        add_to_array_of_side_measure(){
            this.consignees.push({
                departmentId : this.departmentIdSelected,
                departmentName : this.departmentNameSelected,
                measureId : this.measureIdSelected,
                measureName : this.measureNameSelected,
            }) 
        },

        remove_to_array_of_side_measure(consignee){
            const index = this.consignees.findIndex((element, index) => {
                if (element.departmentId === consignee) {
                    return true
                }
            })
            this.consignees.splice(index, 1);
        },

        GetAllClassifications() {

            this.$http.mailService
                .AllClassifications()
                .then((res) => {
                    this.classifications = res.data 
                })
                .catch((err) => {
                    console.log(err)
                });
        },

        GetAllMeasures() {

            this.$http.mailService
                .AllMeasures()
                .then((res) => {
                    this.measures = res.data 
                })
                .catch((err) => {
                    console.log(err)
                });
        },

        GetAllDepartments() {

            this.$http.mailService
                .AllDepartments()
                .then((res) => {
                    this.departments = res.data 
                })
                .catch((err) => {
                    console.log(err)
                });
        },

        saveMail() {
            
            this.screenFreeze = true;
            this.loading = true;

            if (this.mailType == '1'){
                var info = {
                    "mail":{
                        "Mail_Type": Number(this.mailType),
                        "userId": Number(this.my_user_id),
                        "department_Id": Number(this.my_department_id),
                        "Date_Of_Mail": this.releaseDate,
                        "Mail_Summary": this.summary,
                        "clasification": Number(this.classification),
                        "Genaral_inbox_Number": Number(this.general_incoming_number),
                        "Genaral_inbox_year": Number(this.genaral_inbox_year),
                        "ActionRequired": this.required_action,
                    },

                    "actionSenders":this.consignees,
                }
            }

            if (this.mailType == '2'){
                var info = {
                    "mail":{
                        "Mail_Type": Number(this.mailType),
                        "userId": Number(this.my_user_id),
                        "department_Id": Number(this.my_department_id),
                        "Date_Of_Mail": this.releaseDate,
                        "Mail_Summary": this.summary,
                        "clasification": Number(this.classification),
                        "Genaral_inbox_Number": Number(this.general_incoming_number),
                        "Genaral_inbox_year": Number(this.genaral_inbox_year),
                        "ActionRequired": this.required_action,
                    },

                    "actionSenders":this.consignees,

                    "external_Mail":{
                        "action": Number(this.mail_forwarding),
                        "Sectionid": this.sideIdSelected,
                        "sectionName":'',
                        "action_required_by_the_entity": this.action_required_by_the_entity
                    },
                }
            }

            if (this.mailType == '3'){
                var info = {
                    "mail":{
                        "Mail_Type": Number(this.mailType),
                        "userId": Number(this.my_user_id),
                        "department_Id": Number(this.my_department_id),
                        "Date_Of_Mail": this.releaseDate,
                        "Mail_Summary": this.summary,
                        "clasification": Number(this.classification),
                        "Genaral_inbox_Number": Number(this.general_incoming_number),
                        "Genaral_inbox_year": Number(this.genaral_inbox_year),
                        "ActionRequired": this.required_action,
                    },

                    "actionSenders":this.consignees,

                    "extrenal_Inbox":{
                        "action": Number(this.mail_forwarding),
                        "Sectionid": this.sideIdSelected,
                        "section_Name":'',
                        "to": Number(this.ward_to),
                        "type": Number(this.mail_ward_type),
                        "Send_time": this.entity_mail_date,
                        "entity_reference_number": Number(this.entity_reference_number),
                        "procedure_type": Number(this.procedure_type),
                    },
                }
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

                        this.mailId = res.data.mailId
                        this.department_Id = res.data.department_Id
                        this.mail_year = res.data.mail_year

                    }, 500);
                })
                .catch((err) => {
                    setTimeout(() => {
                        this.loading = false;
                        this.screenFreeze = false;
                        
                    }, 500);
                });
        },

        sendMail(){
        this.screenFreeze = true;
        this.loading = true;

        this.$http.mailService
            .SendMail(Number(this.mailId))
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
    
        deleteMail(){
        this.screenFreeze = true;
        this.loading = true;

        this.$http.mailService
            .DeleteMail(this.mailId)
            .then((res) => {
            setTimeout(() => {
                this.loading = false;
                        this.screenFreeze = false;
               

                setTimeout(() => {
                this.$router.replace("/dashboard");
                }, 500);
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
            this.indexOfimagesToShow++
            this.imagesToSend.push({baseAs64:scannedImage.src, index:this.indexOfimagesToShow});
        }
        },

        UploadImagesMail() {
            this.screenFreeze = true;
            this.loading = true;
            console.log(this.imagesToSend)
            this.$http.mailService
                .UploadImagesMail(   this.mailId ,this.imagesToSend)
                .then((res) => {
                setTimeout(() => {
                    this.loading = false;
                        this.screenFreeze = false;
                        console.log(res)

                }, 500);
                })
                .catch((err) => {
                setTimeout(() => {
                    this.loading = false;
                        this.screenFreeze = false;
                    
                }, 500);
                });
        },

        deleteDocument(documentId, index){
            this.$http.mailService
                .DeleteDocument(Number(documentId))
                .then((res) => {
                    this.imagesToShow.splice(index, 1);
                    console.log(res)
                    // this.imagesToShow = res.data.result.documents
                })
                .catch((err) => {
                    this.addErorr = err.message; 
                });
        },

        updateMail(){
            this.screenFreeze = true;
            this.loading = true;

            if (this.mailType == '1'){
                var dataUpdate = {
                    "mail":{
                        "MailID": Number(this.mailId),
                        "Mail_Type": Number(this.mailType),
                        "userId": Number(this.my_user_id),
                        "department_Id": Number(this.my_department_id),
                        "Date_Of_Mail": this.releaseDate,
                        "Mail_Summary": this.summary,
                        "clasification": Number(this.classification),
                        "Genaral_inbox_Number": Number(this.general_incoming_number),
                        "Genaral_inbox_year": Number(this.genaral_inbox_year),
                        "ActionRequired": this.required_action,
                        "state": true
                    },

                    "actionSenders":this.consignees,
                }
            }

            if (this.mailType == '2'){
                var dataUpdate = {
                    "mail":{
                        "MailID": Number(this.mailId),
                        "Mail_Type": Number(this.mailType),
                        "userId": Number(this.my_user_id),
                        "department_Id": Number(this.my_department_id),
                        "Date_Of_Mail": this.releaseDate,
                        "Mail_Summary": this.summary,
                        "clasification": Number(this.classification),
                        "Genaral_inbox_Number": Number(this.general_incoming_number),
                        "Genaral_inbox_year": Number(this.genaral_inbox_year),
                        "ActionRequired": this.required_action,
                        "state": true
                    },

                    "actionSenders":this.consignees,

                    "external_Mail":{
                        "id" : Number(this.external_mailId),
                        "action": Number(this.mail_forwarding),
                        "Sectionid": this.sideIdSelected,
                        "sectionName":'',
                        "action_required_by_the_entity": this.action_required_by_the_entity
                    },
                }
            }

            if (this.mailType == '3'){
                var dataUpdate = {
                    "mail":{
                        "MailID": Number(this.mailId),
                        "Mail_Type": Number(this.mailType),
                        "userId": Number(this.my_user_id),
                        "department_Id": Number(this.my_department_id),
                        "Date_Of_Mail": this.releaseDate,
                        "Mail_Summary": this.summary,
                        "clasification": Number(this.classification),
                        "Genaral_inbox_Number": Number(this.general_incoming_number),
                        "Genaral_inbox_year": Number(this.genaral_inbox_year),
                        "ActionRequired": this.required_action,
                        "state": true
                    },

                    "actionSenders":this.consignees,

                    "extrenal_Inbox":{
                        "Id" : Number(this.external_mailId),
                        "action": Number(this.mail_forwarding),
                        "Sectionid": this.sideIdSelected,
                        "section_Name":'',
                        "to": Number(this.ward_to),
                        "type": Number(this.mail_ward_type),
                        "Send_time": this.entity_mail_date,
                        "entity_reference_number": Number(this.entity_reference_number),
                        "procedure_type": Number(this.procedure_type),
                    },
                }
            }

            this.$http.mailService
                .UpdateMail(dataUpdate)
                .then((res) => {
                    setTimeout(() => {
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






































    

  

   

    removeImage(index) {
      this.imagesToSend.splice(index, 1);
    },

    

    GetDocmentForMailToShow(){
      this.$http.documentService
        .GetDocmentForMail(Number(this.mailId), 1)
        .then((res) => {
          this.imagesToShow = res.data.result.documents
        })
        .catch((err) => {
          this.addErorr = err.message; 
        });
    },

    GetDocmentForMailMarginalized(){
      this.$http.documentService
        .GetDocmentForMail(Number(this.mailId), 2)
        .then((res) => {
          this.marginalizedDocuments = res.data.result.documents
        })
        .catch((err) => {
          this.addErorr = err.message; 
        });
    },

    

    

    

    printImage(img) {
        var Pagelink = "هيئة الرقابة الادارية ليبيا";
        var pwa = window.open(Pagelink, "_new", 'status=1,scrollbars=1,height=533,width=800');

        pwa.document.open();
        pwa.document.write(this.ImagetoPrint(img));
        pwa.document.close();
    },

    ImagetoPrint(img) {
      return "<html><head><scri" + "pt>function step1(){\n" +
        "setTimeout('step2()', 10);}\n" +
        "function step2(){window.print();window.close()}\n" +
        "</scri" + "pt></head><body onload='step1()'>\n" +
        "<img  style='padding:0; width: 100%; size:A4; margin:0;' src='" + img + "' /></body></html>";
    },





















    //  onFileChange(e) {
    //   var files = e.target.files || e.dataTransfer.files;
    //   if (!files.length) return;
    //   this.createImage(files);
    // },

    // createImage(files) {
    //   var vm = this;
    //   for (var index = 0; index < files.length; index++) {
    //     var reader = new FileReader();
    //     reader.onload = function (event) {
    //       const imageUrl = event.target.result;
    //       vm.imagesToSend.push({baseAs64:imageUrl});
    //     };
    //     reader.readAsDataURL(files[index]);
    //   }
    // },

    // addDocuments() {
    //   this.screenFreeze = true;
    //   this.loading = true;

    //    var documenInfo = {
    //     mailId: Number(this.mailId),
    //     images: this.imagesToSend,
    //   };

    //   this.$http.documentService
    //     .AddDocument(documenInfo)
    //     .then((res) => {
    //       setTimeout(() => {
    //         this.loading = false;
    //         

    //         this.imagesToSend = [];
    //         this.GetDocmentForMailToShow()
    //       }, 500);
    //     })
    //     .catch((err) => {
    //       setTimeout(() => {
    //         this.loading = false;
    //     
    //       }, 500);
    //     });
    // },


   
  },
};
</script>
