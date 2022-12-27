<template>
  <div dir="rtl" id="app">
    <router-view />

    <div class="w-full fixed bottom-0">
      
      <div class="truncate -mr-4 bg-gray-50 border-t z-0 border-gray-200 flex items-center py-1 max-w-screen-2xl  mx-auto  md:px-8">
        <div class="w-20"></div>
        
        <div class="w-3/12  text-black flex items-center">
          <div >{{hours}}:{{minutes}}:{{seconds}}</div>
          <div class="mr-6">{{date_from}}</div>
        </div>

        <div class="bg-red-400 w-9/12 px-2">
          دولة ليبيا          هيئة الرقابة الإدارية       منظومة البريد الداخلي       حقوق النسخ محفوظة لمكتب التوثيق و تقنية المعلومات        الاصدار رقم 1 - 2023
        </div>
      </div>

    </div>
    
  </div>
</template>

<script>
export default {
  data () {
    return {
      hours: 0,
      minutes: 0,
      seconds: 0,

      date_from: 0,
    }
  },
  methods: {
    setTime () {
      setInterval(() => {
        const date = new Date()
        this.hours = date.getHours()
        this.minutes = this.checkSingleDigit(date.getMinutes())
        this.seconds = this.checkSingleDigit(date.getSeconds())

        var month = date.getMonth() +1;
        if (month < 10) month = "0" + month;
        this.date_from = date.getFullYear()+ "-" +month+ "-" +date.getDate()
      }, 1000)
    },
    checkSingleDigit (digit) {
      return ('0' + digit).slice(-2)
    }
  },
  mounted () {
    this.setTime()
  }
 
};
</script>

<style>
</style>
