<template >
    <div class="">
        <div class="h-screen bg-white overflow-hidden flex">
            <asideComponent></asideComponent>
            <div class="flex-1 bg-gray-100 w-0 overflow-y-auto">
                <div class="max-w-4xl  mx-auto  flex flex-col md:px-8 xl:px-0">
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
                                                    <svg class="h-6 w-6 stroke-current text-gray-100 group-hover:text-red-600" width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                        <path d="M7.86 2H16.14L22 7.86V16.14L16.14 22H7.86L2 16.14V7.86L7.86 2Z" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"/>
                                                        <path d="M14.7187 8H9.28123C9.17288 8 9.07386 8.05813 9.02737 8.14983C8.98082 8.24116 8.99469 8.34934 9.06294 8.4281L11.7319 11.5L9.0626 14.572C8.99435 14.6507 8.98082 14.7592 9.02737 14.8502C9.07386 14.9419 9.17288 15 9.28123 15H14.7187C14.874 15 15 14.8824 15 14.7375V13.8625C15 13.7176 14.874 13.6 14.7187 13.6C14.5635 13.6 14.4375 13.7176 14.4375 13.8625V14.475H9.87147L12.3124 11.6656C12.396 11.5693 12.396 11.4311 12.3124 11.3348L9.87147 8.525H14.4375V9.13754C14.4375 9.28244 14.5635 9.40004 14.7187 9.40004C14.874 9.40004 15 9.28244 15 9.13754V8.2625C15 8.1176 14.874 8 14.7187 8Z" fill="black" stroke-width="1.1"/>
                                                    </svg>
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
                                                    <svg  class="h-6 w-6 stroke-current text-gray-100 group-hover:text-red-600" width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                        <path d="M7.86 2H16.14L22 7.86V16.14L16.14 22H7.86L2 16.14V7.86L7.86 2Z" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"/>
                                                        <path d="M17 9L10.8125 15L8 12.2727" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"/>
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
                                                    <svg class="h-6 w-6 stroke-current text-gray-100 group-hover:text-red-600" width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                        <path d="M7.86 2H16.14L22 7.86V16.14L16.14 22H7.86L2 16.14V7.86L7.86 2Z"  stroke-width="2" stroke-linecap="round" stroke-linejoin="round"/>
                                                        <path d="M12 8V12"  stroke-width="2" stroke-linecap="round" stroke-linejoin="round"/>
                                                        <path d="M12 16H12.01"  stroke-width="2" stroke-linecap="round" stroke-linejoin="round"/>
                                                    </svg>
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
                                <div class="flex items-center bg-white w-full">
                                    <div class="w-2/12 py-4 pr-2 flex items-center">
                                    <div class="w-8"> </div>
                                        نوع البريد
                                    </div>
                                    <div class="w-4/12">
                                        الملخص
                                    </div>
                                    <div class="w-4/12">
                                        الإجراء المطلوب
                                    </div>
                                    <div class="w-2/12">
                                        تاريخ الاستلام
                                    </div>
                                </div>

                                <div class="divide-y divide-gray-200 min-h-72">

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
                                   
                                </div>
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