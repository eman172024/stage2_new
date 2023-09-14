<template>
  <div
    class="
      relative
      z-10
      
      
      border-b border-gray-200
      
      flex
      justify-end
    "
  >
    <button
      type="button"
      class="
              max-w-s
              flex
              items-center
              text-sm
              rounded-full
              focus:outline-none
              focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500
             
            "
      @click="Logout"
      id="user-menu-button"
      aria-expanded="false"
      aria-haspopup="true"
    >
      <span class="sr-only">Logout</span>
      <svg
        class="w-7 h-7"
        fill="none"
        stroke="currentColor"
        viewBox="0 0 24 24"
        xmlns="http://www.w3.org/2000/svg"
      >
        <path
          strokeLinecap="round"
          strokeLinejoin="round"
          strokeWidth="{2}"
          d="M17 16l4-4m0 0l-4-4m4 4H7m6 4v1a3 3 0 01-3 3H6a3 3 0 01-3-3V7a3 3 0 013-3h4a3 3 0 013 3v1"
        />
      </svg>
    </button>
  </div>
</template>

<script>
export default {
  mounted() {

    if (localStorage.getItem("AY_LW") == null || sessionStorage.getItem("id") == null) {
      this.$router.push("/");
    }

    
    this.my_user_id = localStorage.getItem("AY_LW");
    this.my_department_id = localStorage.getItem("chrome");
  },

  data() {
    return {
      my_user_id: "",
      my_department_id: "",
    };
  },

  methods: {
    Logout() {
      localStorage.removeItem("AY_LW");
      localStorage.removeItem("chrome");
      localStorage.removeItem("Az07");
      this.$router.push("/");
    },
  },
};
</script>

<style></style>
