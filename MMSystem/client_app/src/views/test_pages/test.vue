<template>
  <div class="">
      <button @click="GetData()" class="bg-blue-500 px-8 py-2 rounded-xl">
          GetData
      </button>


      <div class="bg-gray-100 p-8 mt-16 w-full">
          {{ data }}
      </div>
  </div>
</template>

<script>
export default {
    
  data() {
    return {
        my_user_id: '',
        my_department_id: '',

        data:{},

       
    };
  },

     methods: {

        GetData() {
           
            this.$http.testService
                .test()
                .then((res) => {
                    console.log(res)
                    this.data = res
                   
                })
                .catch((err) => {
                   
                        console.log(err);
                    
                    
                    
                });
        },
     }
}
</script>

<style>

</style>