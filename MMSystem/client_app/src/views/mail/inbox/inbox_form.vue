<template>
    <div class="">
        <div class="h-screen bg-white overflow-hidden flex">
            <asideComponent></asideComponent>
            <div class="flex-1 bg-gray-100 w-0 overflow-y-auto pb-20">
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
                            <div class="float-left text-base font-semibold text-gray-800 ">
                                رقم الرسالة 

                                <span class="mr-4 underline font-bold text-2xl">
                                    14
                                </span>
                            </div>
                        </div>
                        
                        <div class="mt-6 space-y-6">
                            <div class="grid grid-cols-7 gap-6">
                                <section class="col-span-5 flex justify-between items-stretch">
                                    <section class="w-6/12 ml-3 grid grid-cols-1 gap-y-6 gap-x-4 sm:grid-cols-6 bg-gray-50 rounded-md p-6">
                                        
                                        <div class="sm:col-span-3">
                                            <label
                                                for=""
                                                class="block text-base font-semibold text-gray-800"
                                                >
                                                نوع البريد
                                            </label>

                                            <div class="block mt-2 w-full rounded-md h-10 text-sm border border-gray-300 p-2">
                                                داخلي
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
                                            <div class="block mt-2 w-full rounded-md h-10 text-sm border border-gray-300 p-2">
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

                                            <div class="block mt-2 w-full rounded-md h-10 text-sm border border-gray-300 p-2">
                                                 2021-09-09 
                                            </div>
                                        </div>

                                        <div class="sm:col-span-3">
                                            <label
                                            for="general_incoming_number"
                                            class="block text-base font-semibold text-gray-800"
                                            >
                                            رقم الوارد العام
                                            </label>

                                            <div class="block mt-2 w-full rounded-md h-10 text-sm border border-gray-300 p-2">
                                                 212 
                                            </div>
                                        </div>

                                        <div class="sm:col-span-3">
                                            <label
                                            for="year"
                                            class="block text-base font-semibold text-gray-800"
                                            >
                                            السنة
                                            </label>
                                            <div class="block mt-2 w-full rounded-md h-10 text-sm border border-gray-300 p-2">
                                                 2021
                                            </div>
                                        </div>
                                    </section>

                                    <section class="w-6/12 mr-3 grid grid-cols-1 gap-y-6 gap-x-4 sm:grid-cols-6 bg-gray-50 rounded-md p-6">
                                        <div class="sm:col-span-6">
                                            <label
                                            for="summary"
                                            class="block text-base font-semibold text-gray-800"
                                            >
                                            الملخص
                                            </label>

                                            <div class="block mt-2 w-full rounded-md h-24 text-sm border border-gray-300 p-2">
                                                 2021
                                            </div>
                                        </div>
                                        
                                        <div class="sm:col-span-6">
                                            <label
                                            for="action_required"
                                            class="block text-base font-semibold text-gray-800"
                                            >
                                            الإجراء المطلوب
                                            </label>
                                            <div class="block mt-2 w-full rounded-md h-24 text-sm border border-gray-300 p-2">
                                                 2021
                                            </div>
                                        </div>
                                    </section>
                                </section>
                    
                                <section class="col-span-2 bg-gray-50 rounded-md p-6">
                                    <div class="flex justify-between items-center">
                                        <h3 class="block text-base font-semibold text-gray-800">المستندات</h3>
                                    </div>

                                    <div class="h-72 w-full bg-gray-100 rounded-md mt-4">
                                        <div v-if=" imagesToShow != '' " class="mt-4 px-4 pt-4 pb-4 rounded-md">

                                            <div v-for="image in imagesToShow" :key="image.id" class="relative h-64 w-full">
                                                <img :src="image.path" class="w-full h-full rounded" />
                                            </div>

                                            <div class="flex justify-between items-center mt-4">
                                                <button @click="previousImage()" class="w-12 h-8 bg-gray-300 rounded flex justify-center items-center">
                                                    <svg class="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5l7 7-7 7"></path></svg>
                                                </button>

                                                {{ imagesToShow.length }}

                                                <button @click="nextImage()" class="w-12 h-8 bg-gray-300 rounded flex justify-center items-center">
                                                    <svg class="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M15 19l-7-7 7-7"></path></svg>
                                                </button>
                                            </div>
                                            
                                        </div>
                                    </div>
                                </section>
                            </div>

                            <section v-if="mailType == 'صادر خارجي' || mailType == 'وارد خارجي'"  class="grid grid-cols-1 gap-y-6 gap-x-4 sm:grid-cols-8 bg-gray-50 rounded-md p-6">
                                
                                <div class="sm:col-span-2">
                                    <label class="block text-base font-semibold text-gray-800 w-24">
                                        <div v-if="mailType == 'صادر خارجي'">
                                            توجيه البريد
                                        </div>

                                        <div v-if="mailType == 'وارد خارجي'">
                                            وارد من
                                        </div>
                                    </label>
                                
                                        <div class="block mt-2 w-full rounded-md h-10 text-sm border border-gray-300 p-2">
                                        مقال صحفي
                                    </div>
                                
                                </div>


                                <div class="sm:col-span-2">
                                    <label
                                        for="send_to_sector"
                                        class="block text-base font-semibold text-gray-800"
                                    >
                                        القطاع
                                    </label>
                                    

                                    <div class="block mt-2 w-full rounded-md h-10 text-sm border border-gray-300 p-2">
                                            داخلي
                                        </div>
                                    
                                </div>

                                <div class="sm:col-span-2">
                                    <label
                                        for="sideIdSelected"
                                        class="block text-base font-semibold text-gray-800"
                                    >
                                        الجهة
                                    </label>

                                    <div class="block mt-2 w-full rounded-md h-10 text-sm border border-gray-300 p-2">
                                        داخلي
                                    </div>

                                </div>

                                <div v-if="mailType == 'وارد خارجي' " class="sm:col-span-2">

                                    <label class="block text-base font-semibold text-gray-800 w-24">
                                        وارد إلي
                                    </label>
                                    
                                        <div class="block mt-2 w-full rounded-md h-10 text-sm border border-gray-300 p-2">
                                        مقال صحفي
                                    </div>
                                </div>

                                <div v-if="mailType == 'وارد خارجي' " class="sm:col-span-2">

                                    <label class="block text-base font-semibold text-gray-800 w-24">
                                        نوعها
                                    </label>

                                    <div class="block mt-2 w-full rounded-md h-10 text-sm border border-gray-300 p-2">
                                    مقال صحفي
                                </div>
                                    
                                </div>

                                <div v-if="mailType == 'وارد خارجي' " class="sm:col-span-2">
                                    <label
                                        for="entity_mail_date"
                                        class="block text-base font-semibold text-gray-800"
                                    >
                                        تاريخ رسالة الجهة
                                    </label>
                                    <div class="block mt-2 w-full rounded-md h-10 text-sm border border-gray-300 p-2">
                                        مقال صحفي
                                    </div>
                                </div>

                                <div v-if="mailType == 'وارد خارجي' " class="sm:col-span-2">
                                    <label
                                        for="entity_reference_number"
                                        class="block text-base font-semibold text-gray-800"
                                    >
                                        رقم إشارة الجهة
                                    </label>
                                    <div class="block mt-2 w-full rounded-md h-10 text-sm border border-gray-300 p-2">
                                        مقال صحفي
                                    </div>
                                </div>

                                <div v-if="mailType == 'وارد خارجي' " class="sm:col-span-2">
                                    <label
                                        for="procedure_type"
                                        class="block text-base font-semibold text-gray-800"
                                    >
                                        نوع الإجراء
                                    </label>
                                    <div class="block mt-2 w-full rounded-md h-10 text-sm border border-gray-300 p-2">
                                            مقال صحفي
                                        </div>
                                </div>

                                    <div v-if="mailType == 'صادر خارجي'" class="sm:col-span-6">
                                    <label
                                    for="action_required"
                                    class="block text-base font-semibold text-gray-800"
                                    >
                                    الإجراء المطلوب من الجهة
                                    </label>
                                    <div class="block mt-2 w-full rounded-md h-24 text-sm border border-gray-300 p-2">
                                            2021
                                    </div>
                                </div>
                            </section>


                            <section class="bg-gray-50 rounded-md p-6">   
                                <p class="block text-base font-semibold text-gray-800">
                                    الردود
                                </p>

                                <div class="h-72 overflow-y-scroll mt-4 rounded-lg py-2 border border-gray-300">
                                    <div class="w-full my-2 flex justify-end px-4">
                                        <div class="bg-gray-700 text-white max-w-10/12 py-4 leading-9 px-4 rounded-2xl">
                                            العرب فرع من الشعوب السامية تتركز أساسًا في الوطن العربي بشقيه الآسيوي والإفريقي إضافة إلى الساحل الشرقي لإفريقيا وأقليات في إيران وتركيا وأقليات صغيرة من أحفاد الفاتحين والدعاة في بلدان مثل كازاخستان والهند والباكستان وإندونيسيا وغيرها ودول المهجر، واحدهم عربي ويتحدد هذا المعنى على خلفيات إما إثنية أو لغوية أو ثقافية. سياسيًا العربي هو كل شخص لغته الأم العربية. وتوجد أقليات عربية بأعداد معتبرة في الأمريكيتين وفي أوروبا وإيران وتركيا.
                                        </div>
                                    </div>


                                    <div class="w-full my-2 flex justify-start px-4">
                                        <div class="bg-blue-700 text-white max-w-10/12 py-4 leading-9 px-4 rounded-2xl">
                                            درج المؤرخون العرب حتى الأيام الراهنة بقسمة تاريخ العرب إلى قسمين، قبل الإسلام والمدعو جاهلية، وبعد الإسلام الذي تمكن فيه العرب من سيادة إمبراطورية واسعة ومزدهرة حضاريًا، خصوصًا في العهد الأموي - سواءً في دمشق أم الأندلس - والعهد العباسي - خصوصًا العهد العباسي الأول وحاضرته بغداد - هذه السيادة أفرزت أنماطًا حضارية غنية، وتمازجت مع الشعوب الأخرى المعتنقة للإسلام، وانتشر الاستعراب في عدة أقاليم أهمها الهلال الخصيب، وشمال ووسط وادي النيل، والمغرب العربي، والأهواز، وبشكل أقل سواحل القرن الأفريقي، وتعرف هذه الأقاليم باسم الوطن العربي، ويعود لمرحلة النهضة العربية في القرن التاسع عشر، بروز ملامح الهوية العربية المعاصرة.
                                        </div>
                                    </div>

                                    <div class="w-full my-2 flex justify-start px-4">
                                        <div class="bg-blue-700 text-white max-w-10/12 py-4 leading-9 px-4 rounded-2xl">
                                            درج المؤرخون العرب حتى الأيام الراهنة بقسمة تاريخ العرب إلى قسمين، قبل الإسلام والمدعو جاهلية، وبعد الإسلام الذي تمكن فيه العرب من سيادة إمبراطورية واسعة ومزدهرة حضاريًا، خصوصًا في العهد الأموي - سواءً في دمشق أم الأندلس - والعهد العباسي - خصوصًا العهد العباسي الأول وحاضرته بغداد - هذه السيادة أفرزت أنماطًا حضارية غنية، وتمازجت مع الشعوب الأخرى المعتنقة للإسلام، وانتشر الاستعراب في عدة أقاليم أهمها الهلال الخصيب، وشمال ووسط وادي النيل، والمغرب العربي، والأهواز، وبشكل أقل سواحل القرن الأفريقي، وتعرف هذه الأقاليم باسم الوطن العربي، ويعود لمرحلة النهضة العربية في القرن التاسع عشر، بروز ملامح الهوية العربية المعاصرة.
                                        </div>
                                    </div>

                                    <div class="w-full my-2 flex justify-end px-4">
                                        <div class="bg-gray-700 text-white max-w-10/12 py-4 leading-9 px-4 rounded-2xl">
                                            العرب فرع من الشعوب السامية تتركز أساسًا في الوطن العربي بشقيه الآسيوي والإفريقي إضافة إلى الساحل الشرقي لإفريقيا وأقليات في إيران وتركيا وأقليات صغيرة من أحفاد الفاتحين والدعاة في بلدان مثل كازاخستان والهند والباكستان وإندونيسيا وغيرها ودول المهجر، واحدهم عربي ويتحدد هذا المعنى على خلفيات إما إثنية أو لغوية أو ثقافية. سياسيًا العربي هو كل شخص لغته الأم العربية. وتوجد أقليات عربية بأعداد معتبرة في الأمريكيتين وفي أوروبا وإيران وتركيا.
                                        </div>
                                    </div>

                                </div>

                                <div class="flex justify-between items-center mt-4">
                                    <div class="w-8/12">
                                        <textarea
                                            id=""
                                            class="block w-full h-20 text-sm rounded-md border border-gray-200 hover:shadow-sm focus:outline-none focus:border-gray-300 p-2"
                                        >
                                        </textarea>
                                    </div>
                                    <div class="w-2/12 mr-4">
                                         <label class="w-full flex items-center justify-center h-20  py-2 bg-white rounded-lg tracking-wide text-green-600 border border-green-600 cursor-pointer hover:text-white hover:bg-green-600 focus:outline-none duration-300">
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
                                    </div>
                                    <div class="w-2/12 mr-4">
                                        <button class="w-full flex items-center justify-center h-20 py-2 bg-white rounded-lg text-blue-600 tracking-wide border border-blue-600 cursor-pointer hover:text-white hover:bg-blue-600 focus:outline-none duration-300">    
                                            <span class="leading-normal">إرسال</span>
                                            <svg class="w-6 h-6 mr-2" viewBox="0 0 441 441" fill="currentColor" xmlns="http://www.w3.org/2000/svg">
                                                <g clip-path="url(#clip0)">
                                                <path d="M26.2637 181.168L382.073 33.5286C397.063 27.3081 413.997 30.0445 426.267 40.6664C438.538 51.29 443.669 67.6578 439.659 83.384L404.694 220.501L439.659 357.617C443.669 373.343 438.538 389.711 426.268 400.335C413.974 410.979 397.036 413.681 382.073 407.472L26.2637 259.833C10.0639 253.111 0.000120282 238.04 0.000120282 220.501C0.000120282 202.961 10.0639 187.89 26.2637 181.168ZM36.1681 235.966L391.977 383.605C397.96 386.087 404.456 385.039 409.354 380.798C414.252 376.558 416.22 370.279 414.619 364.001L381.321 233.42H252.927C245.791 233.42 240.007 227.636 240.007 220.5C240.007 213.364 245.791 207.579 252.927 207.579H381.32L414.619 76.9998C416.22 70.7224 414.252 64.4434 409.354 60.203C404.457 55.9627 397.963 54.9136 391.978 57.396L36.1681 205.035C26.5859 209.011 25.8408 217.878 25.8408 220.501C25.8408 223.123 26.5859 231.99 36.1681 235.966Z" fill="currentColor"/>
                                                </g>
                                                <defs>
                                                <clipPath id="clip0">
                                                <rect width="441" height="441" fill="white" transform="matrix(-1 0 0 1 441 0)"/>
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

    },

    components: {
        asideComponent,
        navComponent,
        svgLoadingComponent,
    },

    data() {
        return {
            my_user_id : '',
            my_department_id : '',
            
            imagesToShow : {},
            // mailType : '',
            mailType : 'وارد خارجي',
            // mailType : 'صادر خارجي',

            
            
            loading: false,
            screenFreeze: false,
        };
    },
    methods: {
        previousImage(){

        },

        nextImage(){

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

    },
};
</script>
