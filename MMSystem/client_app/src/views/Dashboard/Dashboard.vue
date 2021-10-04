<template >
    <div class="">
        <div class="h-screen bg-white overflow-hidden flex">
            <asideComponent></asideComponent>
            <div class="flex-1 bg-gray-100 w-0 overflow-y-auto">
                <div class="max-w-screen-2xl  mx-auto flex flex-col md:px-8">
                    <navComponent></navComponent>
                    <main class="flex-1 relative focus:outline-none ">

                        <div class="py-6">
                            <div class="px-4 sm:px-6 md:px-0">
                                <h1 class="text-xl font-semibold text-gray-900">لوحة التحكم</h1>
                            </div>
                            <div class="px-4 sm:px-6 md:px-0">
                                <!-- Replace with your content -->
                                <div class="py-4">
                                    <div class="grid grid-cols-3 gap-8">

                                        <button class="bg-white p-4 hover:shadow focus:outline-none group">
                                            <div class="flex justify-between items-start">
                                                <div class="">
                                                    <p class="text-gray-900">إجمالي البريد</p>
                                                    <p class="font-bold text-gray-100 text-3xl mt-2 text-right">
                                                        {{ Reports.count_Of_all_transaction }}
                                                    </p>
                                                </div>
                                                <div class="w-16 h-16 -mt-8 bg-green-500 flex justify-center items-center">
                                                    <svg class="h-6 w-6 fill-current  text-gray-100 group-hover:text-red-600" fill="none" stroke="currentColor" viewBox="0 0 32 32"><path d="M28,3H4A1,1,0,0,0,3,4V28a1,1,0,0,0,1,1H28a1,1,0,0,0,1-1V4A1,1,0,0,0,28,3ZM27,15H17V5H27ZM15,5V15H5V5ZM5,17H15V27H5ZM17,27V17H27V27Z" data-name="select all"/></svg>
                                                </div>
                                            </div>
                                        </button>

                                        <button class="bg-white p-4 hover:shadow focus:outline-none group">
                                            <div class="flex justify-between items-start">
                                                <div class="">
                                                    <p class="text-gray-900">بريد صادر</p>
                                                    <p class="font-bold text-gray-100 text-3xl mt-2 text-right">
                                                        {{ Reports.count_Of_received }}
                                                    </p>
                                                </div>

                                                <div class="w-16 h-16 -mt-8 bg-green-500 flex justify-center items-center">
                                                    <svg class="text-gray-100 group-hover:text-red-600 h-6 w-6 fill-current stroke-current "  fill="none" stroke="currentColor" version="1.1" width="256" height="256" viewBox="0 0 256 256" xml:space="preserve">
                                                        <g transform="translate(128 128) scale(0.72 0.72)" style="">
                                                            <g style="stroke: none; stroke-width: 0; stroke-dasharray: none; stroke-linecap: butt; stroke-linejoin: miter; stroke-miterlimit: 10; fill-rule: nonzero; opacity: 1;" transform="translate(-175.05 -175.05000000000004) scale(3.89 3.89)" >
                                                                <path d="M 89.999 3.075 C 90 3.02 90 2.967 89.999 2.912 c -0.004 -0.134 -0.017 -0.266 -0.038 -0.398 c -0.007 -0.041 -0.009 -0.081 -0.018 -0.122 c -0.034 -0.165 -0.082 -0.327 -0.144 -0.484 c -0.018 -0.046 -0.041 -0.089 -0.061 -0.134 c -0.053 -0.119 -0.113 -0.234 -0.182 -0.346 C 89.528 1.382 89.5 1.336 89.469 1.29 c -0.102 -0.147 -0.212 -0.288 -0.341 -0.417 c -0.13 -0.13 -0.273 -0.241 -0.421 -0.344 c -0.042 -0.029 -0.085 -0.056 -0.129 -0.082 c -0.118 -0.073 -0.239 -0.136 -0.364 -0.191 c -0.039 -0.017 -0.076 -0.037 -0.116 -0.053 c -0.161 -0.063 -0.327 -0.113 -0.497 -0.147 c -0.031 -0.006 -0.063 -0.008 -0.094 -0.014 c -0.142 -0.024 -0.285 -0.038 -0.429 -0.041 C 87.03 0 86.983 0 86.936 0.001 c -0.141 0.003 -0.282 0.017 -0.423 0.041 c -0.035 0.006 -0.069 0.008 -0.104 0.015 c -0.154 0.031 -0.306 0.073 -0.456 0.129 L 1.946 31.709 c -1.124 0.422 -1.888 1.473 -1.943 2.673 c -0.054 1.199 0.612 2.316 1.693 2.838 l 34.455 16.628 l 16.627 34.455 C 53.281 89.344 54.334 90 55.481 90 c 0.046 0 0.091 -0.001 0.137 -0.003 c 1.199 -0.055 2.251 -0.819 2.673 -1.943 L 89.815 4.048 c 0.056 -0.149 0.097 -0.3 0.128 -0.453 c 0.008 -0.041 0.011 -0.081 0.017 -0.122 C 89.982 3.341 89.995 3.208 89.999 3.075 z M 75.086 10.672 L 37.785 47.973 L 10.619 34.864 L 75.086 10.672 z M 55.136 79.381 L 42.027 52.216 l 37.302 -37.302 L 55.136 79.381 z" style=""  transform=" matrix(1 0 0 1 0 0) " stroke-linecap="round" />
                                                            </g>
                                                        </g>
                                                    </svg>
                                                </div>
                                            </div>
                                        </button>

                                        <button class="bg-white p-4 hover:shadow focus:outline-none group">
                                            <div class="flex justify-between items-start">
                                                <div class="">
                                                    <p class="text-gray-900">بريد وارد</p>
                                                    <p class="font-bold text-gray-100 text-3xl mt-2 text-right">
                                                        {{ Reports.count_Of_booking }}
                                                    </p>
                                                </div>
                                                <div class="w-16 h-16 -mt-8 bg-green-500 flex justify-center items-center">
                                                    <svg class="text-gray-100 group-hover:text-red-600 h-6 w-6 " fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M20 13V6a2 2 0 00-2-2H6a2 2 0 00-2 2v7m16 0v5a2 2 0 01-2 2H6a2 2 0 01-2-2v-5m16 0h-2.586a1 1 0 00-.707.293l-2.414 2.414a1 1 0 01-.707.293h-3.172a1 1 0 01-.707-.293l-2.414-2.414A1 1 0 006.586 13H4"></path></svg>
                                                </div>
                                            </div>
                                        </button>
                                    
                                    </div>
                                </div>
                                <!-- /End replace -->
                            </div>
                        </div>

                        <section>
                            <div class="px-4 sm:px-6 md:px-0 flex justify-between items-center">
                                <h1 class="text-xl font-semibold text-gray-900">أحدث البريد</h1>
                                <router-link :to="{ name: 'mail' }" class="border border-g100text-gray-100 hover:text-g5bg-green-500 hover:border-g5bg-green-500 duration-300 bg-white px-4 py-2 rounded-md text-gray-900 font-medium focus:outline-none">
                                    إضافة +
                                </router-link>
                            </div>

                            <div class="w-full mt-4 rounded-md overflow-hidden divide-y-2 divide-gray-200">
                                
                                
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


                                <div class="min-h-72 ">
                                    <div v-for="mail in LastMails" :key="mail.mailID" :class="mail.flag | mail_state_inbox"  class="group relative border-r-8 border-red-500 flex items-center bg-white">
                                        <div class="w-1/9 pr-4 py-3">
                                            {{ mail.mail_Number }}
                                        </div>
                                        <div class="w-1/9">
                                            {{ mail.state }}
                                        </div>

                                        <div class="w-1/9">
                                            {{ mail.mail_Type | mail_type }}
                                        </div>

                                        <div class="w-2/9">
                                            {{ mail.mangment_sender }}
                                        </div>

                                        <div class="w-1/9">
                                            {{ mail.masure_type }}
                                        </div>

                                        <div class="w-1/9">
                                            {{ mail.date_Of_Mail }}
                                        </div>

                                        <div class="w-1/9">
                                            {{ mail.time }}
                                        </div>

                                        <div class="w-1/9 flex justify-between items-center">
                                            <div class="w-1/3 flex justify-center items-center">
                                                <router-link title="عرض التفصيل" :to="{ name: 'sent-show', params: { mail: mail.mail_id, type:mail.type_of_mail, sends_id:mail.sends_id},}"  class="">
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


                                                <router-link title="عرض التفصيل" :to="{ name: 'inbox-show', params: { mail: mail.mail_id, department:my_department_id, type:mail.type_of_mail, sends_id:mail.sends_id },}"  class="">
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
                                                <button @click="GetAllDocuments(mail.mail_id)" title="طباعة المستندات" class="focus:outline-none">
                                                    <svg class="w-5 h-5 fill-current hover:text-blue-500" id="Capa_1" enable-background="new 0 0 512 512" height="512" viewBox="0 0 512 512" width="512" xmlns="http://www.w3.org/2000/svg"><g><path d="m437 129h-14v-54c0-41.355-33.645-75-75-75h-184c-41.355 0-75 33.645-75 75v54h-14c-41.355 0-75 33.645-75 75v120c0 41.355 33.645 75 75 75h14v68c0 24.813 20.187 45 45 45h244c24.813 0 45-20.187 45-45v-68h14c41.355 0 75-33.645 75-75v-120c0-41.355-33.645-75-75-75zm-318-54c0-24.813 20.187-45 45-45h184c24.813 0 45 20.187 45 45v54h-274zm274 392c0 8.271-6.729 15-15 15h-244c-8.271 0-15-6.729-15-15v-148h274zm89-143c0 24.813-20.187 45-45 45h-14v-50h9c8.284 0 15-6.716 15-15s-6.716-15-15-15h-352c-8.284 0-15 6.716-15 15s6.716 15 15 15h9v50h-14c-24.813 0-45-20.187-45-45v-120c0-24.813 20.187-45 45-45h362c24.813 0 45 20.187 45 45z"/><path d="m296 353h-80c-8.284 0-15 6.716-15 15s6.716 15 15 15h80c8.284 0 15-6.716 15-15s-6.716-15-15-15z"/><path d="m296 417h-80c-8.284 0-15 6.716-15 15s6.716 15 15 15h80c8.284 0 15-6.716 15-15s-6.716-15-15-15z"/><path d="m128 193h-48c-8.284 0-15 6.716-15 15s6.716 15 15 15h48c8.284 0 15-6.716 15-15s-6.716-15-15-15z"/></g></svg>
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
                                                    {{ mail.mail_Summary }}
                                                </p>
                                            </div>
                                        </div>

                                    </div>
                                </div>


                                <!-- <div class="divide-y divide-gray-200 min-h-72">

                                    <router-link :to="{ name: 'mail-show', params: { mail: mail.mailID, type:mail.mail_Type },}" v-for="mail in LastMails" :key="mail.mailID" class="w-full bg-white hover:shadow flex items-center">
                                        
                                        <div class="w-2/12 pr-2 py-4 flex items-center">
                                            <div class="w-8">
                                                <svg  v-if="mail.is_send" class="stroke-current w-5 h-5"  version="1.1" id="Capa_1" x="0px" y="0px" viewBox="0 0 345.834 345.834"  xml:space="preserve">
                                                    <g>
                                                        <path d="M339.798,260.429c0.13-0.026,0.257-0.061,0.385-0.094c0.109-0.028,0.219-0.051,0.326-0.084
                                                            c0.125-0.038,0.247-0.085,0.369-0.129c0.108-0.039,0.217-0.074,0.324-0.119c0.115-0.048,0.226-0.104,0.338-0.157
                                                            c0.109-0.052,0.22-0.1,0.327-0.158c0.107-0.057,0.208-0.122,0.312-0.184c0.107-0.064,0.215-0.124,0.319-0.194
                                                            c0.111-0.074,0.214-0.156,0.321-0.236c0.09-0.067,0.182-0.13,0.27-0.202c0.162-0.133,0.316-0.275,0.466-0.421
                                                            c0.027-0.026,0.056-0.048,0.083-0.075c0.028-0.028,0.052-0.059,0.079-0.088c0.144-0.148,0.284-0.3,0.416-0.46
                                                            c0.077-0.094,0.144-0.192,0.216-0.289c0.074-0.1,0.152-0.197,0.221-0.301c0.074-0.111,0.139-0.226,0.207-0.34
                                                            c0.057-0.096,0.118-0.19,0.171-0.289c0.062-0.115,0.114-0.234,0.169-0.351c0.049-0.104,0.101-0.207,0.146-0.314
                                                            c0.048-0.115,0.086-0.232,0.128-0.349c0.041-0.114,0.085-0.227,0.12-0.343c0.036-0.118,0.062-0.238,0.092-0.358
                                                            c0.029-0.118,0.063-0.234,0.086-0.353c0.028-0.141,0.045-0.283,0.065-0.425c0.014-0.1,0.033-0.199,0.043-0.3
                                                            c0.025-0.249,0.038-0.498,0.038-0.748V92.76c0-4.143-3.357-7.5-7.5-7.5h-236.25c-0.066,0-0.13,0.008-0.196,0.01
                                                            c-0.143,0.004-0.285,0.01-0.427,0.022c-0.113,0.009-0.225,0.022-0.337,0.037c-0.128,0.016-0.255,0.035-0.382,0.058
                                                            c-0.119,0.021-0.237,0.046-0.354,0.073c-0.119,0.028-0.238,0.058-0.356,0.092c-0.117,0.033-0.232,0.069-0.346,0.107
                                                            c-0.117,0.04-0.234,0.082-0.349,0.128c-0.109,0.043-0.216,0.087-0.322,0.135c-0.118,0.053-0.235,0.11-0.351,0.169
                                                            c-0.099,0.051-0.196,0.103-0.292,0.158c-0.116,0.066-0.23,0.136-0.343,0.208c-0.093,0.06-0.184,0.122-0.274,0.185
                                                            c-0.106,0.075-0.211,0.153-0.314,0.235c-0.094,0.075-0.186,0.152-0.277,0.231c-0.09,0.079-0.179,0.158-0.266,0.242
                                                            c-0.099,0.095-0.194,0.194-0.288,0.294c-0.047,0.05-0.097,0.094-0.142,0.145c-0.027,0.03-0.048,0.063-0.074,0.093
                                                            c-0.094,0.109-0.182,0.223-0.27,0.338c-0.064,0.084-0.13,0.168-0.19,0.254c-0.078,0.112-0.15,0.227-0.222,0.343
                                                            c-0.059,0.095-0.12,0.189-0.174,0.286c-0.063,0.112-0.118,0.227-0.175,0.342c-0.052,0.105-0.106,0.21-0.153,0.317
                                                            c-0.049,0.113-0.092,0.23-0.135,0.345c-0.043,0.113-0.087,0.225-0.124,0.339c-0.037,0.115-0.067,0.232-0.099,0.349
                                                            c-0.032,0.12-0.066,0.239-0.093,0.36c-0.025,0.113-0.042,0.228-0.062,0.342c-0.022,0.13-0.044,0.26-0.06,0.39
                                                            c-0.013,0.108-0.019,0.218-0.027,0.328c-0.01,0.14-0.019,0.28-0.021,0.421c-0.001,0.041-0.006,0.081-0.006,0.122v46.252
                                                            c0,4.143,3.357,7.5,7.5,7.5s7.5-3.357,7.5-7.5v-29.595l66.681,59.037c-0.348,0.245-0.683,0.516-0.995,0.827l-65.687,65.687v-49.288
                                                            c0-4.143-3.357-7.5-7.5-7.5s-7.5,3.357-7.5,7.5v9.164h-38.75c-4.143,0-7.5,3.357-7.5,7.5s3.357,7.5,7.5,7.5h38.75v43.231
                                                            c0,4.143,3.357,7.5,7.5,7.5h236.25c0.247,0,0.494-0.013,0.74-0.037c0.115-0.011,0.226-0.033,0.339-0.049
                                                            C339.542,260.469,339.67,260.454,339.798,260.429z M330.834,234.967l-65.688-65.687c-0.042-0.042-0.087-0.077-0.13-0.117
                                                            l49.383-41.897c3.158-2.68,3.546-7.412,0.866-10.571c-2.678-3.157-7.41-3.547-10.571-0.866l-84.381,71.59l-98.444-87.158h208.965
                                                            V234.967z M185.878,179.888c0.535-0.535,0.969-1.131,1.308-1.765l28.051,24.835c1.418,1.255,3.194,1.885,4.972,1.885
                                                            c1.726,0,3.451-0.593,4.853-1.781l28.587-24.254c0.26,0.38,0.553,0.743,0.89,1.08l65.687,65.687H120.191L185.878,179.888z"/>
                                                        <path d="M7.5,170.676h126.667c4.143,0,7.5-3.357,7.5-7.5s-3.357-7.5-7.5-7.5H7.5c-4.143,0-7.5,3.357-7.5,7.5
                                                            S3.357,170.676,7.5,170.676z"/>
                                                        <path d="M20.625,129.345H77.5c4.143,0,7.5-3.357,7.5-7.5s-3.357-7.5-7.5-7.5H20.625c-4.143,0-7.5,3.357-7.5,7.5
                                                            S16.482,129.345,20.625,129.345z"/>
                                                        <path d="M62.5,226.51h-55c-4.143,0-7.5,3.357-7.5,7.5s3.357,7.5,7.5,7.5h55c4.143,0,7.5-3.357,7.5-7.5S66.643,226.51,62.5,226.51z"
                                                            />
                                                    </g>
                                                </svg>
                                                
                                                <svg v-else class="stroke-current w-5 h-5" fill="none"  viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round"  d="M3 8l7.89 5.26a2 2 0 002.22 0L21 8M5 19h14a2 2 0 002-2V7a2 2 0 00-2-2H5a2 2 0 00-2 2v10a2 2 0 002 2z"></path></svg>
                                            </div>
                                            {{ mail.mail_Type }}
                                        </div>

                                        <div class="w-4/12 font-semibold text-black">
                                            {{ mail.mail_Summary }}
                                        </div>
                                        
                                        <div class="w-4/12">
                                            {{ mail.action_Required }}
                                        </div>

                                        <div class="w-2/12">
                                            {{ mail.date_Of_Mail }}
                                        </div>

                                    </router-link>
                                   
                                </div> -->
                            </div>
                        </section>
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
      this.GetLastMails();

    //   this.test();

    //this.GetNumbersOfReports();
    
  },

  components: {
      asideComponent,
      navComponent,
      svgLoadingComponent
  },

  data() {
    return {
       // userId: this.$authenticatedUser.userId,
        //name: this.$authenticatedUser.name,
       // userName: this.$authenticatedUser.userName,
       // validity: this.$authenticatedUser.validity,

        LastMails:{},
        Reports:{
            count_Of_all_transaction:0,
            count_Of_received:0,
            count_Of_booking:0
        },
        loading: false,
        screenFreeze: false,
    };
  },
  methods: {
    //   Numbers_Of_Reports
      GetAllDocuments(id){
          this.screenFreeze = true;
            this.loading = true;
            this.$http.mailService
                .GetAllDocuments(id)
                .then((res) => {
                    console.log(res)

                    this.show_images = res.data

                    this.testimage = this.show_images[0].path;
                  
                    setTimeout(() => {
                        this.show_images_model = true
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


    GetLastMails() {
        this.screenFreeze = true;
        this.loading = true;
        this.$http.DashboardService
            .LastMails()
            .then((res) => {
                setTimeout(() => {

                    console.log(res)
                    this.LastMails = res.data;
                    
                    setTimeout(() => {
                        this.screenFreeze = false;
                    this.loading = false;
                    }, 300);

                    // this.LastTransactions = res.data;
                    // this.Reports.count_Of_all_transaction = res.data.count_Of_all_transaction;
                    // this.Reports.count_Of_booking = res.data.count_Of_booking;
                    // this.Reports.count_Of_received = res.data.count_Of_received;


                }, 100);
                
            })
            .catch((err) => {
                setTimeout(() => {
                    this.screenFreeze = false;
                    this.loading = false;
                    console.log(err);
                }, 100);
                
                
            });
    },

    test() {

        console.log("SSSSSSSSSSSSSSSSS")
        this.$http.DashboardService
            .NumbersOfReports()
            .then((res) => {
                console.log(res)
            })
            .catch((err) => {
                console.log(err)
            });
    },

    // GetNumbersOfReports() {
    //     this.screenFreeze = true;
    //     this.loading = true;
    //     this.$http.DashboardService
    //         .NumbersOfReports()
    //         .then((res) => {
    //             setTimeout(() => {
    //                 this.screenFreeze = false;
    //                 this.loading = false;

    //                 this.Reports.count_Of_all_transaction = res.data.count_Of_all_transaction;
    //                 this.Reports.count_Of_booking = res.data.count_Of_booking;
    //                 this.Reports.count_Of_received = res.data.count_Of_received;

    //             }, 100);
                
    //         })
    //         .catch((err) => {
    //             setTimeout(() => {
    //                 this.screenFreeze = false;
    //                 this.loading = false;
    //                 console.log(err);
    //             }, 100);
                
                
    //         });
    // },

    
  },

}
</script>