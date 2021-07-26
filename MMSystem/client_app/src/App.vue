<template>
  <div dir="rtl" id="app">
    <router-view/>
  </div>
</template>

<script>
export default {
    created() {
      // this.CheckLogin();
    },
    
    data() {
      return {
        state: 0,

        admin: false,
        isSideMenuOpen: false,
      }
    },

    methods: {
      CheckLogin() {
        if(localStorage.getItem("userId") == undefined || localStorage.getItem("userId") == 0 ){
          this.$router.replace("/");
        }else{
          this.$authenticatedUser.userId = localStorage.getItem("userId");
          // this.$router.replace("/dashboard");
        }
      },
        
    },
}
</script>