<template>
  <div class="">
    <div class="h-screen  overflow-hidden flex">
      <asideComponent></asideComponent>
      <div class="w-full h-full text-center">
        <div class="text-center mt-10">
          <div class="text-2xl text-center font-semibold">
            هيئة الرقابة الإدارية
            <div class="my-2">منظومة الصادر الخارجي</div>
            تقرير المراسلات الصادرة
          </div>
        </div>

        <div class="text-2xl text-center font-semibold mt-10 flex  justify-center w-full">
         <div class="ml-4">
         من  :

          {{ this.$route.params.dateFrom }}
         </div>

         <div class="mr-4">
           إلى  :

          {{ this.$route.params.dateTo }}
         </div>
        </div>


        <div class="mt-12  border-2">
<!-- {{this.$route.params.mailType}} -->
            <span class="text-xl font-semibold ">عدد مراسلات الصادر الخارجي</span>

<div class="flex mt-12 mb-4 justify-center ml-4">
<div></div>
    <span class="ml-6 font-medium text-xl">جهات عامة</span>

    <div class="mr-6 font-medium text-xl border-black border-2 px-1  ">{{this.$route.params.total_of_transaction}}</div>
    <div></div>
</div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import asideComponent from "@/components/asideComponent.vue";

export default {
  components: {
    asideComponent,
  },

  data() {

    return {

            
    }
    
    },
};
</script>
