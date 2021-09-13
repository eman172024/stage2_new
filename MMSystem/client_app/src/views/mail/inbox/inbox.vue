<template >
    <div class="">
        <div class="h-screen bg-white overflow-hidden flex">
            <asideComponent></asideComponent>
            <div class="flex-1 bg-gray-100 w-0 overflow-y-auto">
                <div class="max-w-screen-2xl  mx-auto flex flex-col md:px-8">
                    <navComponent></navComponent>
                    <main class="flex-1 relative focus:outline-none py-6">
                        <h1 class="text-xl font-semibold text-gray-900">البريد الوارد</h1>

                        <div class="relative mt-4 bg-white">
                            <button @click="filter = !filter" class="w-full p-2 bg-white flex items-center rounded-md focus:outline-none">
                                

                                <svg class="w-6 h-6 ml-2" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round"  d="M3 4a1 1 0 011-1h16a1 1 0 011 1v2.586a1 1 0 01-.293.707l-6.414 6.414a1 1 0 00-.293.707V17l-4 4v-6.586a1 1 0 00-.293-.707L3.293 7.293A1 1 0 013 6.586V4z"></path></svg>
                                فرز
                            </button>

                            <div v-if="filter" class="absolute z-40 w-full bg-white shadow-2xl py-2 px-2">
                                asf
                            </div>
                        </div>

                        <div class="w-full mt-4 rounded-md  divide-y-2 divide-gray-200">

                            <div class="flex items-center bg-white w-full text-sm">
                                <div class="w-1/12 py-4 pr-6">
                                    رقم الرسالة
                                </div>

                                <div class="w-1/12">
                                    النوع
                                </div>

                                <div class="w-4/12">
                                    الإدارة
                                </div>

                                <div class="w-5/12">
                                    ملخص الرسالة
                                </div>
                                
                                <div class="w-1/12">
                                    تاريخ الارسال
                                </div>
                            </div>

                            <div class="min-h-72">
                                <router-link :to="{ name: 'inbox-show', params: { mail: mail.mailID, type:mail.mail_Type },}" v-for="mail in LastMails" :key="mail.mailID" class="w-full">
                                  <div class="group relative border-r-8 border-red-500 flex items-center bg-white transform hover:bg-gray-50 duration-300">
                                    <div class="w-1/12 pr-4 py-4">
                                        14
                                    </div>

                                    <div class="w-1/12 ">
                                      {{ mail.mail_Type }}
                                        <!-- {{ mail.mail_Summary }} -->
                                    </div>
                                    
                                    <div class="w-4/12">
                                        {{ mail.action_Required }}
                                    </div>

                                    <div class="w-5/12">
                                        {{ mail.action_Required }}
                                    </div>

                                    <div class="w-1/12">
                                        {{ mail.date_Of_Mail }}
                                    </div>

                                    <div class="group-hover:flex items-end hidden absolute z-50 w-8/12  my-2 bottom-1 left-0 right-0 mx-auto min-h-64 h-full  ">
                                        <svg class="w-6 h-6 font-bold stroke-2 stroke-current text-red-500 animate-arrow" className="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path strokeLinecap="round" strokeLinejoin="round" strokeWidth={4} d="M14 5l7 7m0 0l-7 7m7-7H3" /></svg>

                                        
                                        <div class="bg-white p-2 border-4 rounded-md w-full h-full">
                                            <p class="font-bold">
                                                ملخص الرسالة
                                            </p>

                                            <p class="mt-2">
                                                {{ mail.action_Required }}
                                            </p>
                                        </div>
                                    </div>
                                  </div>
                                </router-link>
                            </div>

                            <div class=" flex justify-end mt-4  mx-auto px-4 sm:px-6 lg:px-8" >
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
      this.GetLastMails();

  },

  components: {
      asideComponent,
      navComponent,
      svgLoadingComponent
  },

  data() {
    return {
        LastMails:{},

        filter: false,
        loading: false,
        screenFreeze: false,
    };
  },
  methods: {

    GetLastMails() {
        this.screenFreeze = true;
        this.loading = true;
        this.$http.DashboardService
            .LastMails()
            .then((res) => {
                console.log(res)
                this.LastMails = res.data;
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
    
  },

}
</script>

<style >
  
  .el-pagination.is-background .el-pager li:not(.disabled).active{
    background: RGB(15, 116, 144);
  }
  
</style>