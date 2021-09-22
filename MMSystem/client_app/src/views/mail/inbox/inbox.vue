<template >
    <div class="">
        <div class="h-screen bg-white overflow-hidden flex">
            <asideComponent></asideComponent>
            <div class="flex-1 bg-gray-100 w-0 overflow-y-auto">
                <div class="max-w-screen-2xl  mx-auto flex flex-col md:px-8">
                    <navComponent></navComponent>
                    <main class="flex-1 relative focus:outline-none py-6">
                        <div class="flex justify-between items-center">
                            <div class="">
                                <h1 class="text-xl font-semibold text-gray-900">البريد الوارد</h1>
                            </div>

                            <div class=" flex items-center">
                                <span class=" text-base font-medium text-gray-800">
                                    التاريخ :
                                </span>
                                

                                <span class="flex items-center mr-4">
                                    من 
                                    <input type="date" id="date_from" v-model="date_from" class="block mr-2 w-full rounded-md h-10 border border-gray-200 hover:shadow-sm focus:outline-none focus:border-gray-300 px-2">
                                </span>

                                <span class="flex items-center mr-4">
                                    إلي
                                    <input type="date" id="date_to" v-model="date_to" class="block mr-2 w-full rounded-md h-10 border border-gray-200 hover:shadow-sm focus:outline-none focus:border-gray-300 px-2">
                                </span>
                            </div>

                            <fieldset class="">
                                <div class=" flex items-center">
                                    <legend class=" text-base font-medium text-gray-800 w-16">
                                    نوع البريد
                                    </legend>

                                    <div class="flex items-center mr-6">
                                        <input
                                            v-model="mailType"
                                            id="internal"
                                            type="radio"
                                            name="type"
                                            class="h-4 w-4"
                                            value="0"
                                        />
                                        <label
                                            for="internal"
                                            class="mr-2 block  text-gray-800"
                                        >
                                            الكل
                                        </label>
                                    </div>

                                    <div class="flex items-center mr-6">
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

                                    <div class="flex items-center mr-6">
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

                                    <div class="flex items-center mr-6">
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

                        </div>

                        <div class="relative mt-4">
                            <button @click="filter = !filter" :class="filter ? 'shadow-md':''" class="rounded-t-md border border-b-0 hover:text-blue-600 hover:font-bold group w-full p-2 bg-white flex items-center justify-between focus:outline-none">
                                <span class="flex items-center">
                                    <svg class="w-6 h-6 ml-2 stroke-current group-hover:stroke-2" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round"  d="M3 4a1 1 0 011-1h16a1 1 0 011 1v2.586a1 1 0 01-.293.707l-6.414 6.414a1 1 0 00-.293.707V17l-4 4v-6.586a1 1 0 00-.293-.707L3.293 7.293A1 1 0 013 6.586V4z"></path></svg>
                                    فرز
                                </span>

                                <span class="">
                                    <svg class="w-6 h-6 stroke-current group-hover:stroke-2 " fill="none" stroke="currentColor" viewBox="0 0 24 24"><path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M19 9l-7 7-7-7" /></svg>
                                </span>
                            </button>

                            <div v-if="filter" class="rounded-b-md shadow-md absolute border border-t-0 z-40 w-full bg-white px-4 py-8">
                                <div class="grid grid-cols-1 gap-y-6 gap-x-4 sm:grid-cols-6 max-w-4xl mx-auto">
                                    <div class="sm:col-span-2">
                                        <label
                                            for="mail_id"
                                            class="block text-base font-semibold text-gray-800"
                                        >
                                            رقم البريد
                                        </label>
                                        <input
                                            v-model="mail_id"
                                            type="number"
                                            id="mail_id"
                                            class="block mt-2 h-10 w-full rounded-md border border-gray-300 hover:shadow-sm focus:outline-none focus:border-gray-300 px-2"
                                            
                                        />
                                    </div>

                                    <div class="sm:col-span-2">
                                        <label
                                        for="department"
                                        class="block text-base font-semibold text-gray-800"
                                        >
                                        الإدارات المرسلة
                                        </label>

                                        <div class="relative">
                                            <button @click="departmentselect = !departmentselect" id="department" class="text-right block mt-2 w-full rounded-md h-10 border text-sm bg-white border-gray-300 hover:shadow-sm focus:outline-none focus:border-gray-300 p-2">
                                                {{ departmentNameSelected }}
                                            </button>

                                            <div v-if="departmentselect" class="border text-sm bg-white border-gray-300 p-2 absolute w-full z-20 shadow h-24 overflow-y-scroll rounded-b-md">
                                                <button class="block focus:outline-none w-full my-1 text-right" @click="selectdepartment('', 'الكل'); departmentselect = !departmentselect">
                                                    الكل    
                                                </button>
                                                
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
                                            <button @click="measureselect = !measureselect" id="measure" class="text-right block mt-2 w-full rounded-md h-10 border text-sm bg-white border-gray-300 hover:shadow-sm focus:outline-none focus:border-gray-300 p-2">
                                                {{ measureNameSelected }}
                                            </button>

                                            <div v-if="measureselect" class="border text-sm bg-white border-gray-300 p-2 absolute w-full z-20 shadow h-24 overflow-y-scroll rounded-b-md">
                                                <button class="block focus:outline-none w-full my-1 text-right" @click="selectmeasure('', 'الكل'); measureselect = !measureselect">
                                                    الكل    
                                                </button>
                                                
                                                <button class="block focus:outline-none w-full my-1 text-right" @click="selectmeasure(measure.measuresId, measure.measuresName); measureselect = !measureselect" v-for="measure in measures" :key="measure.measuresId">
                                                    {{ measure.measuresName }}    
                                                </button>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="sm:col-span-2">
                                        <label
                                            for="measure"
                                            class="block text-base font-semibold text-gray-800"
                                        >
                                        حالة البريد
                                        </label>

                                        <div class="relative">
                                            <button @click="mail_caseselect = !mail_caseselect" id="measure" class="text-right block mt-2 w-full rounded-md h-10 border text-sm bg-white border-gray-300 hover:shadow-sm focus:outline-none focus:border-gray-300 p-2">
                                                {{ mail_caseNameSelected }}
                                            </button>

                                            <div v-if="mail_caseselect" class="border text-sm bg-white border-gray-300 p-2 absolute w-full z-20 shadow h-24 overflow-y-scroll rounded-b-md">
                                                <button class="block focus:outline-none w-full my-1 text-right" @click="select_mail_case('', 'الكل'); mail_caseselect = !mail_caseselect">
                                                    الكل    
                                                </button>
                                                
                                                <button class="block focus:outline-none w-full my-1 text-right" @click="select_mail_case(mail_case.id, mail_case.name); mail_caseselect = !mail_caseselect" v-for="mail_case in mail_cases" :key="mail_case.id">
                                                    {{ mail_case.name }}    
                                                </button>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="sm:col-span-2">
                                        <label
                                            for="classification"
                                            class="block text-base font-semibold text-gray-800"
                                        >
                                        التصنيف
                                        </label>

                                        <div class="relative">
                                            <button @click="classificationselect = !classificationselect" id="classification" class="text-right block mt-2 w-full rounded-md h-10 border text-sm bg-white border-gray-300 hover:shadow-sm focus:outline-none focus:border-gray-300 p-2">
                                                {{ classificationNameSelected }}
                                            </button>

                                            <div v-if="classificationselect" class="border text-sm bg-white border-gray-300 p-2 absolute w-full z-20 shadow h-24 overflow-y-scroll rounded-b-md">
                                                <button class="block focus:outline-none w-full my-1 text-right" @click="selectClassification('', 'الكل'); classificationselect = !classificationselect">
                                                    الكل    
                                                </button>
                                                
                                                <button class="block focus:outline-none w-full my-1 text-right" @click="selectClassification(classification.id, classification.name); classificationselect = !classificationselect" v-for="classification in classifications" :key="classification.id">
                                                    {{ classification.name }}    
                                                </button>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="sm:col-span-2">
                                        <label
                                        for="summary"
                                        class="block text-base font-semibold text-gray-800"
                                        >
                                            جزاء من الملخص
                                        </label>
                                        <input
                                            type="text"
                                            v-model="summary"
                                            id="summary"
                                            class="block mt-2 w-full rounded-md h-10 text-sm border border-gray-300 hover:shadow-sm focus:outline-none focus:border-gray-300 p-2"
                                        />
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="w-full mt-4 rounded-md divide-y-2 divide-gray-200">

                            <div class="flex items-center bg-white w-full text-sm">
                                <div class="w-1/9 py-4 pr-6">
                                    رقم الرسالة
                                </div>
                                <div class="w-1/9">
                                    الحالة
                                </div>
                                <div class="w-1/9">
                                    النوع
                                </div>
                                <div class="w-2/9">
                                    الإدارة المرسلة
                                </div>
                                <div class="w-1/9">
                                    نوع الإجراء
                                </div>
                                <div class="w-1/9">
                                    تاريخ الارسال
                                </div>
                                <div class="w-1/9">
                                    وقت الارسال
                                </div>
                                <div class="w-1/9">
                                    الإجراءات
                                </div>
                            </div>

                            <div class="min-h-72">
                                <div v-for="mail in inboxMails" :key="mail.mail_id" :class="mail.flag | mail_state_inbox"  class="group relative border-r-8 border-red-500 flex items-center bg-white">
                                    <div class="w-1/9 pr-4 py-3">
                                        {{ mail.mail_Number }}
                                    </div>
                                    <div class="w-1/9">
                                        {{ mail.state }}
                                    </div>

                                    <div class="w-1/9">
                                        {{ mail.type_of_mail | mail_type }}
                                    </div>

                                    <div class="w-2/9">
                                        {{ mail.mangment_sender }}
                                    </div>

                                    <div class="w-1/9">
                                        {{ mail.masure_type }}
                                    </div>

                                    <div class="w-1/9">
                                        {{ mail.send_time }}
                                    </div>

                                    <div class="w-1/9">
                                        {{ mail.time }}
                                    </div>

                                    <div class="w-1/9 flex justify-between items-center">
                                        <div class="w-1/3 flex justify-center items-center">
                                            <router-link title="عرض التفصيل" :to="{ name: 'inbox-show', params: { mail: mail.mail_id, type:mail.type_of_mail },}"  class="">
                                                <svg class="w-5 h-5 fill-current hover:text-green-500" version="1.1" id="Capa_1" x="0px" y="0px" viewBox="0 0 18.453 18.453"  xml:space="preserve">
                                                    <rect x="2.711" y="4.058" width="8.23" height="1.334"/>
                                                    <path d="M14.972,14.088c0.638-1.127,0.453-2.563-0.475-3.49c-0.549-0.549-1.279-0.852-2.058-0.852
                                                        c-0.779,0-1.51,0.303-2.059,0.852s-0.852,1.279-0.852,2.059c0,0.777,0.303,1.508,0.852,2.059c0.549,0.547,1.279,0.85,2.057,0.85
                                                        c0.507,0,0.998-0.129,1.434-0.375l3.262,3.262l1.101-1.102L14.972,14.088z M13.664,13.881c-0.652,0.652-1.796,0.652-2.448,0
                                                        c-0.675-0.676-0.675-1.773,0-2.449c0.326-0.326,0.762-0.506,1.225-0.506s0.897,0.18,1.224,0.506s0.507,0.762,0.507,1.225
                                                        S13.991,13.554,13.664,13.881z"/>
                                                    <path d="M13.332,16.3H1.857c-0.182,0-0.329-0.148-0.329-0.328V1.638c0-0.182,0.147-0.329,0.329-0.329
                                                        h11.475c0.182,0,0.328,0.147,0.328,0.329V8.95c0.475,0.104,0.918,0.307,1.31,0.597V1.638C14.97,0.735,14.236,0,13.332,0H1.857
                                                        C0.954,0,0.219,0.735,0.219,1.638v14.334c0,0.902,0.735,1.637,1.638,1.637h11.475c0.685,0,1.009-0.162,1.253-0.76l-0.594-0.594
                                                        C13.772,16.347,13.426,16.3,13.332,16.3z"/>
                                                    <rect x="2.711" y="7.818" width="8.23" height="1.334"/>
                                                </svg>
                                            </router-link>
                                        </div>

                                        <div class="w-1/3 flex justify-center items-center">
                                            <button title="طباعة المستندات" class="focus:outline-none">
                                                <svg class="w-5 h-5 fill-current hover:text-blue-500" id="Capa_1" enable-background="new 0 0 512 512" height="512" viewBox="0 0 512 512" width="512" xmlns="http://www.w3.org/2000/svg"><g><path d="m437 129h-14v-54c0-41.355-33.645-75-75-75h-184c-41.355 0-75 33.645-75 75v54h-14c-41.355 0-75 33.645-75 75v120c0 41.355 33.645 75 75 75h14v68c0 24.813 20.187 45 45 45h244c24.813 0 45-20.187 45-45v-68h14c41.355 0 75-33.645 75-75v-120c0-41.355-33.645-75-75-75zm-318-54c0-24.813 20.187-45 45-45h184c24.813 0 45 20.187 45 45v54h-274zm274 392c0 8.271-6.729 15-15 15h-244c-8.271 0-15-6.729-15-15v-148h274zm89-143c0 24.813-20.187 45-45 45h-14v-50h9c8.284 0 15-6.716 15-15s-6.716-15-15-15h-352c-8.284 0-15 6.716-15 15s6.716 15 15 15h9v50h-14c-24.813 0-45-20.187-45-45v-120c0-24.813 20.187-45 45-45h362c24.813 0 45 20.187 45 45z"/><path d="m296 353h-80c-8.284 0-15 6.716-15 15s6.716 15 15 15h80c8.284 0 15-6.716 15-15s-6.716-15-15-15z"/><path d="m296 417h-80c-8.284 0-15 6.716-15 15s6.716 15 15 15h80c8.284 0 15-6.716 15-15s-6.716-15-15-15z"/><path d="m128 193h-48c-8.284 0-15 6.716-15 15s6.716 15 15 15h48c8.284 0 15-6.716 15-15s-6.716-15-15-15z"/></g></svg>
                                            </button>
                                        </div>

                                        <div class="w-1/3 flex justify-center items-center">
                                            <button :class="mail.flag != 1 ? 'hidden' : ''" @click="read_it_mail(mail.mail_id)" title="تأكيد قراءة البريد" class="focus:outline-none">
                                                <svg class="w-5 h-5 fill-current text-gray-400 hover:text-green-500" id="Capa_1" enable-background="new 0 0 512 512" height="512" viewBox="0 0 512 512" width="512" xmlns="http://www.w3.org/2000/svg"><g><path d="m153 157.328c-4.142 0-7.5 3.357-7.5 7.5s3.358 7.5 7.5 7.5h206c4.142 0 7.5-3.357 7.5-7.5s-3.358-7.5-7.5-7.5z"/><path d="m359 235.578c4.142 0 7.5-3.357 7.5-7.5s-3.358-7.5-7.5-7.5h-60.809c-12.709-7.789-27.642-12.288-43.608-12.288-16.628 0-32.126 4.894-45.166 13.288h-56.417c-4.142 0-7.5 3.357-7.5 7.5s3.358 7.5 7.5 7.5h38.926c-11.593 13.094-19.148 29.827-20.718 48.25h-18.208c-4.142 0-7.5 3.357-7.5 7.5s3.358 7.5 7.5 7.5h18.259c1.746 18.709 9.668 35.647 21.711 48.75h-39.97c-4.142 0-7.5 3.357-7.5 7.5s3.358 7.5 7.5 7.5h58.244c12.649 7.687 27.486 12.117 43.339 12.117 15.738 0 30.688-4.321 43.518-12.117h60.899c4.142 0 7.5-3.357 7.5-7.5s-3.358-7.5-7.5-7.5h-42.671c5.17-5.667 9.62-12.112 13.175-19.229 1.851-3.706.348-8.21-3.358-10.062-3.705-1.85-8.21-.347-10.061 3.358-11.723 23.47-35.29 38.049-61.503 38.049-37.882 0-68.702-30.819-68.702-68.702s30.82-68.703 68.702-68.703c37.883 0 68.703 30.82 68.703 68.703v.21c0 .024.003.047.003.071 0 .018-.003.036-.003.054 0 4.143 3.358 7.5 7.5 7.5h28.215c4.142 0 7.5-3.357 7.5-7.5s-3.358-7.5-7.5-7.5h-21.042c-1.61-18.891-9.503-36.015-21.599-49.25h42.641z"/><path d="m359 412.328h-206c-4.142 0-7.5 3.357-7.5 7.5s3.358 7.5 7.5 7.5h206c4.142 0 7.5-3.357 7.5-7.5s-3.358-7.5-7.5-7.5z"/><path d="m418.594 43.254h-57.432c-1.703-7.296-8.247-12.754-16.055-12.754h-36.607v-1.652c0-15.907-12.941-28.848-28.847-28.848h-47.306c-15.906 0-28.847 12.941-28.847 28.848v1.652h-36.607c-7.808 0-14.351 5.458-16.055 12.754h-57.432c-15.164 0-27.5 12.337-27.5 27.5v413.746c0 15.163 12.336 27.5 27.5 27.5h91.423c4.142 0 7.5-3.357 7.5-7.5s-3.358-7.5-7.5-7.5h-91.423c-6.893 0-12.5-5.607-12.5-12.5v-413.746c0-6.893 5.607-12.5 12.5-12.5h56.986v15h-41.986c-6.893 0-12.5 5.607-12.5 12.5v383.746c0 6.893 5.607 12.5 12.5 12.5h295.188c6.893 0 12.5-5.607 12.5-12.5v-383.746c0-6.893-5.607-12.5-12.5-12.5h-41.986v-15h56.986c6.893 0 12.5 5.607 12.5 12.5v413.746c0 6.893-5.607 12.5-12.5 12.5h-198.765c-4.142 0-7.5 3.357-7.5 7.5s3.358 7.5 7.5 7.5h198.765c15.164 0 27.5-12.337 27.5-27.5v-413.746c0-15.163-12.337-27.5-27.5-27.5zm-253.201 3.746c0-.827.673-1.5 1.5-1.5h44.107c4.142 0 7.5-3.357 7.5-7.5v-9.152c0-7.636 6.212-13.848 13.847-13.848h47.306c7.635 0 13.847 6.212 13.847 13.848v9.152c0 4.143 3.358 7.5 7.5 7.5h44.107c.827 0 1.5.673 1.5 1.5 0 47.697.075 57.448-.045 59.588-.054.963-.705 1.417-1.455 1.417h-178.214c-.827 0-1.5-.673-1.5-1.5 0-24.736 0-29.663 0-59.505zm235.701 420h-290.188v-378.746h39.486v18.251c0 9.101 7.405 16.5 16.5 16.5h178.215c9.046 0 16.5-7.377 16.5-16.5v-18.251h39.486v378.746z"/><path d="m283.604 261.149-46.186 44.447-10.337-20.891c-1.837-3.713-6.338-5.234-10.048-3.396-3.712 1.837-5.233 6.335-3.396 10.048l14.879 30.07c2.242 4.529 8.258 5.603 11.923 2.078l53.566-51.549c2.984-2.872 3.076-7.62.204-10.604s-7.62-3.074-10.605-.203z"/></g></svg>
                                            </button>
                                        </div>
                                    </div>

                                    <div class="group-hover:flex items-end hidden absolute z-50 w-8/12  my-2 bottom-1 left-0 right-0 mx-auto min-h-64 h-full  ">
                                        <svg class="w-6 h-6 font-bold stroke-2 stroke-current text-red-500 animate-arrow" className="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path strokeLinecap="round" strokeLinejoin="round" strokeWidth={4} d="M14 5l7 7m0 0l-7 7m7-7H3" /></svg>

                                        
                                        <div class="bg-white p-2 border-4 rounded-md w-full h-full">
                                            <p class="font-bold">
                                                ملخص الرسالة
                                            </p>

                                            <p class="mt-2">
                                                {{ mail.summary }}
                                            </p>
                                        </div>
                                    </div>

                                </div>
                            </div>

                            <div class="flex justify-end mt-4  mx-auto px-4 sm:px-6 lg:px-8 bg-white">

                                <pagination dir="rtl" v-model="page_num" :per-page="page_size" :records="total_of_transaction" @paginate="GetInboxs"/>
                              <!-- <el-pagination
                                background
                                :small="false"
                                :pager-count="5"
                                :page-size="filter.pageSize"
                                layout="prev, pager, next"
                                prev-text="<"
                                next-text=">"
                                :hide-on-single-page="true"
                                :total="total"
                                :current-page.sync="filter.pageNo"
                                @current-change="PageChanged"
                                class="pagination justify-content-center pagination-sm "
                              >
                              </el-pagination> -->
                            </div>

                        </div>
                    </main>
                </div>
            </div>
        </div>
        <div v-if="screenFreeze" class="w-screen h-screen bg-black bg-opacity-30 absolute inset-0 z-50 flex justify-center items-center">
            <div v-if="loading" class="">
                <svgLoadingComponent></svgLoadingComponent>
            </div>
        </div>
    </div>
</template>

<script>
import asideComponent from '@/components/asideComponent.vue';
import navComponent from '@/components/navComponent.vue';
import svgLoadingComponent from '@/components/svgLoadingComponent.vue';

export default {
  created() {},

  mounted() {

    var date = new Date();

    var month = date.getMonth() +1;

    if (month < 10) month = "0" + month;

    this.date_from = date.getFullYear()+ "-" +month+ "-" +date.getDate()
    this.date_to = date.getFullYear()+ "-" +month+ "-" +date.getDate()



    console.log(this.date_from)

      this.my_user_id = localStorage.getItem('userId')
      this.my_department_id = localStorage.getItem('departmentId')

        this.GetInboxs();

        this.GetAllmail_cases()
        this.GetAllClassifications();
        this.GetAllDepartments();
        this.GetAllMeasures();

  },

    watch: {
         
            mailType: function () {
                this.GetInboxs()
            },
            date_from: function () {
                this.GetInboxs()
            },
            date_to: function () {
                this.GetInboxs()
            },
            mail_id: function () {
                this.GetInboxs()
            },
            summary: function () {
                this.GetInboxs()
            },
            departmentIdSelected: function () {
                this.GetInboxs()
            },
            measureIdSelected: function () {
                this.GetInboxs()
            },
            classificationIdSelected: function () {
                this.GetInboxs()
            },

            mail_caseIdSelected: function () {
                this.GetInboxs()
            },
    },

  components: {
      asideComponent,
      navComponent,
      svgLoadingComponent
  },

  data() {
    return {

        total_of_transaction : 0,
        my_user_id: '',
        my_department_id: '',

        inboxMails:[],

        mail_id:'',


        classifications:[],
        classificationselect : false,
        classificationNameSelected: '',
        classificationIdSelected: '',
        
        departments:[],
        departmentselect : false,
        departmentNameSelected: '',
        departmentIdSelected: '',

        measures:[],
        measureselect : false,
        measureNameSelected: '',
        measureIdSelected: '',

        mail_cases:[],
        mail_caseselect : false,
        mail_caseNameSelected: '',
        mail_caseIdSelected: '',

        mailType:0,

        summary:'',

        filter: false,
        loading: false,
        screenFreeze: false,

        date_from:'',
        date_to:'',

        page_size: 4,
        page_num: 1
    };
  },

  methods: {

        GetInboxs() {
            this.screenFreeze = true;
            this.loading = true;
            this.inboxMails = []
            this.$http.mailService
                .inboxs(this.my_user_id, this.mailType, this.my_department_id, this.date_from, this.date_to, this.mail_id, this.summary, this.departmentIdSelected, this.measureIdSelected, this.classificationIdSelected, this.mail_caseIdSelected, this.page_num, this.page_size)
                .then((res) => {
                    console.log(res)
                    this.inboxMails = res.data.mail;
                    this.total_of_transaction = res.data.total
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



        read_it_mail(id) {
            // this.screenFreeze = true;
            // this.loading = true;
            this.$http.mailService
                .read_it_mail(id, this.my_department_id)
                .then((res) => {
                    console.log(res)
                    // this.inboxMails = res.data.mail;
                    // this.total_of_transaction = res.data.total
                    // setTimeout(() => {
                    //     this.screenFreeze = false;
                    //     this.loading = false;

                        this.GetInboxs()
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
                    this.departments = res.data 
                })
                .catch((err) => {
                    console.log(err)
                });
        },

        selectdepartment(id, name){
            this.departmentNameSelected = name;
            this.departmentIdSelected = id;
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

        selectmeasure(id, name){
            this.measureNameSelected = name;
            this.measureIdSelected = id;
        },

        GetAllmail_cases() {
            this.mail_cases = [
                {
                    id : 1,
                    name : 'read it'
                },
                {
                    id : 2,
                    name : 'not read it'
                },
                {
                    id : 3,
                    name : 'aaaa'
                }
            ] 
        },

        select_mail_case(id, name){
            this.mail_caseNameSelected = name;
            this.mail_caseIdSelected = id;
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

        selectClassification(id, name){
            this.classificationNameSelected = name;
            this.classificationIdSelected = id;
        },
        

        // add_to_array_of_side_measure(){
        //     this.consignees.push({
        //         departmentId : this.departmentIdSelected,
        //         departmentName : this.departmentNameSelected,
                
        //     }) 
        // },


    
    
  },

}
</script>

<style >
    .VuePagination{
        width: 100%;
    }

    .VuePagination nav {
        display:flex;
        justify-content: space-between;
        align-items: center;
    }

    .pagination{
        display:flex;
    }

    .page-link{
        background-color:red;
    }

    .page-item{
        /* margin-left: .5rem;
        margin-right: .5rem;*/
    }

    .page-link {
        padding-left: 1rem;
        padding-right: 1rem;
        padding-top: 0.5rem;
        padding-bottom: 0.5rem;

        font-size: 0.875rem;
        line-height: 1.25rem;

        font-weight: 500;
        border-width: 1px;

        --tw-border-opacity: 1;
        border-color: rgba(209, 213, 219, var(--tw-border-opacity));

        --tw-bg-opacity: 1;
        background-color: rgba(255, 255, 255, var(--tw-bg-opacity));

        --tw-text-opacity: 1;
        color: rgba(107, 114, 128, var(--tw-text-opacity));
    }

    .page-link:hover{
        --tw-bg-opacity: 1;
        background-color: rgba(249, 250, 251, var(--tw-bg-opacity));
    }

    .active{
        background-color: #152b67;
        color: #fff;
    }

    .VuePagination nav ul{
        padding-top: 0.5rem;
        padding-bottom: 0.5rem;
        border-radius: 0.375rem;
        overflow: hidden;
    }
  
</style>