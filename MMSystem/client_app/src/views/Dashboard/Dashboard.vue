<template >
    <div class="">
        <div class="h-screen bg-white overflow-hidden flex">
            <asideComponent></asideComponent>
            <div class="flex-1 bg-gray-50 w-0 overflow-y-auto">
                <div class="max-w-4xl  mx-auto  flex flex-col md:px-8 xl:px-0">
                    <navComponent></navComponent>
                    <main class="flex-1 relative focus:outline-none ">
                        <div class="py-6">
                            <div class="px-4 sm:px-6 md:px-0">
                                <h1 class="text-xl font-semibold text-gray-100">لوحة التحكم</h1>
                            </div>
                            <div class="px-4 sm:px-6 md:px-0">
                                <!-- Replace with your content -->
                                <div class="py-4">
                                    <div class="grid grid-cols-3 gap-8">

                                        <button class="bg-white p-4 hover:shadow focus:outline-none group">
                                            <div class="flex justify-between items-start">
                                                <div class="">
                                                    <p class="text-gray-900">إجمالي المعاملات</p>
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
                                                    <p class="text-gray-900">المعاملات المستلمة</p>
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
                                                    <p class="text-gray-900">المعاملات المحجوزة</p>
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
                                <h1 class="text-xl font-semibold text-gray-100">أحدث المعاملات</h1>
                                <router-link :to="{ name: 'Login' }" class="border border-g100text-gray-100 hover:text-g5bg-green-500 hover:border-g5bg-green-500 duration-300 bg-white px-4 py-2 rounded-md text-gray-100 font-medium focus:outline-none">
                                    إضافة +
                                </router-link>
                            </div>

                            <div class="w-full mt-4 rounded-md overflow-hidden divide-y-2 divide-gray-200">
                                <div class="flex items-center bg-white w-full">
                                    <div class="w-2/12 py-4 pr-2">
                                        رقم الإيصال
                                    </div>
                                    <div class="w-3/12">
                                        الاسم
                                    </div>
                                    <div class="w-3/12">
                                        المستلم
                                    </div>
                                    <div class="w-2/12">
                                        تاريخ الاستلام
                                    </div>
                                    <div class="w-2/12 pl-2">
                                        الحالة
                                    </div>
                                </div>

                                <div class="divide-y divide-gray-200 min-h-72">
                                    <!--<router-link :to="{ name: 'TransactionsFormEdit', params: { transaction: transaction.id },}" v-for="transaction in LastTransactions" :key="transaction.id" class="w-full bg-white hover:shadow flex items-center">
                                        <div class="w-2/12 py-4 pr-2 font-semibold text-black">
                                            {{ transaction.finacial_recipt_number }}
                                        </div>
                                        <div class="w-3/12">
                                            {{ transaction.full_name }}
                                        </div>
                                        <div class="w-3/12">
                                            {{ transaction.recipients_name }}
                                        </div>
                                        <div class="w-2/12">
                                            {{ transaction.delivery_date }}
                                        </div>
                                        <div class="w-2/12 font-semibold text-black pl-2">
                                            {{ transaction.passport_status }}
                                        </div>
                                    </router-link>-->

                                    <div class="w-full bg-white hover:shadow flex items-center">
                                        <div class="w-2/12 py-4 pr-2 font-semibold text-black">
                                             transaction.finacial_recipt_number 
                                        </div>
                                        <div class="w-3/12">
                                             transaction.full_name 
                                        </div>
                                        <div class="w-3/12">
                                             transaction.recipients_name 
                                        </div>
                                        <div class="w-2/12">
                                             transaction.delivery_date 
                                        </div>
                                        <div class="w-2/12 font-semibold text-black pl-2">
                                             transaction.passport_status 
                                        </div>
                                    </div>
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
      console.log("in dashbord")
    //this.GetNumbersOfReports();
    //this.GetLastFiveTransactions();
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

        LastTransactions:{},
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

    GetLastFiveTransactions() {
        this.screenFreeze = true;
        this.loading = true;
        this.$http.DashboardService
            .LastFiveTransactions()
            .then((res) => {
                setTimeout(() => {
                    this.screenFreeze = false;
                    this.loading = false;

                    this.LastTransactions = res.data;
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

    GetNumbersOfReports() {
        this.screenFreeze = true;
        this.loading = true;
        this.$http.DashboardService
            .NumbersOfReports()
            .then((res) => {
                setTimeout(() => {
                    this.screenFreeze = false;
                    this.loading = false;

                    this.Reports.count_Of_all_transaction = res.data.count_Of_all_transaction;
                    this.Reports.count_Of_booking = res.data.count_Of_booking;
                    this.Reports.count_Of_received = res.data.count_Of_received;

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

    
  },

}
</script>