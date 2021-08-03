<template >
    <div class="">
        <div class="h-screen bg-white overflow-hidden flex">
            <asideComponent></asideComponent>
            <div class="flex-1 bg-gray-50 w-0 overflow-y-auto">
                <div class="max-w-4xl  mx-auto  flex flex-col md:px-8 xl:px-0">
                    <navComponent></navComponent>
                    <main class="flex-1 relative focus:outline-none">
                        <div class="py-6">
                            <div class="px-4 sm:px-6 md:px-0">
                                <h1 class="text-xl font-semibold text-black">لوحة التحكم</h1>
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