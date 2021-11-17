<template>
  <div
    class="
      relative
      z-10
      flex-shrink-0
      h-16
      w-full
      border-b border-gray-200
      flex
    "
  >
    <button
      @click="toggleMenu = !toggleMenu"
      class="
        border-r border-gray-200
        px-4
        text-gray-500
        focus:outline-none
        focus:ring-2 focus:ring-inset focus:ring-indigo-500
        md:hidden
      "
    >
      <span class="sr-only">Open sidebar</span>
      <!-- Heroicon name: outline/menu-alt-2 -->
      <svg
        class="h-6 w-6"
        xmlns="http://www.w3.org/2000/svg"
        fill="none"
        viewBox="0 0 24 24"
        stroke="currentColor"
        aria-hidden="true"
      >
        <path
          stroke-linecap="round"
          stroke-linejoin="round"
          stroke-width="2"
          d="M4 6h16M4 12h16M4 18h7"
        />
      </svg>
    </button>
    <div class="flex-1 flex justify-between items-center px-4 md:px-0">

      <!-- <a :href="$router.resolve({ name: 'sent-add' }).href"  class="border border-black duration-300 bg-white px-4 py-2 rounded-md text-gray-900 font-bold hover:bg-green-600 hover:text-white focus:outline-none">
        إضافة بريد جديد +
      </a> -->


      <router-link :to="{ name: 'sent-add' }" class="border border-black duration-300 bg-white px-4 py-2 rounded-md text-gray-900 font-bold hover:bg-green-600 hover:text-white focus:outline-none">
        إضافة بريد جديد +
      </router-link>

      <!-- search -->

      <!-- <div class="w-full flex items-center ">
        <fieldset class="w-2/5 ml-6">
          <div class="flex items-center">
            <legend class="text-base font-semibold text-gray-800 ml-6">
              نوع البريد
            </legend>
            <div class="flex justify-between items-center">
              <div class="flex items-center">
                <input
                  v-model="mailType"
                  id="internal"
                  type="radio"
                  name="type"
                  class="h-4 w-4"
                  value="1"
                />
                <label for="internal" class="mr-2 block text-gray-800">
                  داخلي
                </label>
              </div>

              <div class="flex items-center mx-4">
                <input
                  v-model="mailType"
                  id="internal_export"
                  type="radio"
                  name="type"
                  class="h-4 w-4"
                  value="2"
                />
                <label for="internal_export" class="mr-2 block text-gray-800">
                  صادر خارجي
                </label>
              </div>

              <div class="flex items-center">
                <input
                  v-model="mailType"
                  id="external_incoming"
                  type="radio"
                  name="type"
                  class="h-4 w-4"
                  value="3"
                />
                <label for="external_incoming" class="mr-2 block text-gray-800">
                  وارد خارجي
                </label>
              </div>
            </div>
          </div>
        </fieldset>

        <input type="number" class="w-16 px-1 rounded-md focus:outline-none ">

        <input type="number" class="w-16 px-1 rounded-md focus:outline-none mx-4" v-model="my_department_id">

        <input type="number" class="w-16 px-1 rounded-md focus:outline-none " v-model="year">

      </div> -->

      <!-- Profile dropdown -->
      <div class="relative md:mr-6 ml-4">
        <div>
          <!--  @click="userProcedure = !userProcedure" -->
          <button
            type="button"
            class="
              max-w-xs
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
              class="w-6 h-6"
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

            <!-- <img class="h-8 w-8 rounded-full" src="https://images.unsplash.com/photo-1472099645785-5658abf4ff4e?ixlib=rb-1.2.1&ixqx=9iaFDkXMqu&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=facearea&facepad=2&w=256&h=256&q=80" alt=""> -->
          </button>
        </div>

        <!--
                            Dropdown menu, show/hide based on menu state.

                            Entering: "transition ease-out duration-100"
                                From: "transform opacity-0 scale-95"
                                To: "transform opacity-100 scale-100"
                            Leaving: "transition ease-in duration-75"
                                From: "transform opacity-100 scale-100"
                                To: "transform opacity-0 scale-95"
                            -->
        <div
          v-if="userProcedure"
          class="
            origin-top-left
            absolute
            left-0
            mt-2
            w-48
            rounded-md
            shadow-lg
            bg-white
            ring-1 ring-black ring-opacity-5
            py-1
            focus:outline-none
          "
          role="menu"
          aria-orientation="vertical"
          aria-labelledby="user-menu-button"
          tabindex="-1"
        >
          <!-- Active: "bg-gray-100", Not Active: "" -->
          <a
            href="#"
            class="block py-2 px-4 text-sm text-gray-700"
            role="menuitem"
            tabindex="-1"
            id="user-menu-item-0"
            >الملف الشخصي</a
          >

          <a
            href="#"
            class="block py-2 px-4 text-sm text-gray-700"
            role="menuitem"
            tabindex="-1"
            id="user-menu-item-1"
            >الإعدادات</a
          >

          <a
            href="#"
            class="block py-2 px-4 text-sm text-gray-700"
            role="menuitem"
            tabindex="-1"
            id="user-menu-item-2"
            >خروج</a
          >
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {

    mounted() {

    var date = new Date();

    // var month = date.getMonth() +1;

    // if (month < 10) month = "0" + month;

    // this.date_from = date.getFullYear()+ "-" +month+ "-" +date.getDate()
    // this.date_to = date.getFullYear()+ "-" +month+ "-" +date.getDate()

    this.year = date.getFullYear()
    this.my_user_id = localStorage.getItem('userId')
    this.my_department_id = localStorage.getItem('departmentId')

 

  },

  data() {
    return {
        my_user_id:'',
        my_department_id:'',
        year:'',
      userProcedure: false,
      toggleMenu: false,

      searchMenu: false,
      closeSearchMenu: false,

      searchFor: "",

      resultOfSearch: "",

      finacial_recipt_number: {},

      transaction_number: {},

      mailType: 1,
    };
  },

  methods: {
    Logout(){
      localStorage.removeItem('userId');
      localStorage.removeItem('departmentId');
      this.$router.push('/')
    },
    search() {
      this.closeSearchMenu = true;

      if (this.searchFor == "") {
        this.searchMenu = false;
        this.closeSearchMenu = false;
        return;
      }

      this.searchMenu = true;
      var text = this.searchFor;

      this.$http.TransactionsService.ayoub(text)
        .then((res) => {
          this.resultOfSearch = res.data;

          this.finacial_recipt_number = this.resultOfSearch.finacial_recipt_number;
          this.transaction_number = this.resultOfSearch.transaction_number;

          if (
            this.finacial_recipt_number == 0 &&
            this.transaction_number == 0
          ) {
            this.searchMenu = false;
          }
        })
        .catch((err) => {
          console.log(err);
        });
    },

    canselSearch() {
      this.searchFor = "";
      this.searchMenu = false;
      this.closeSearchMenu = false;
    },

    toggle_menu() {
      document.querySelector("#overlay").classList.toggle("hidden");
      document.body.classList.toggle("overflow-y-hidden");
      document.getElementById("menu").classList.toggle("hidden");
    },

    toggle_search() {
      document.querySelector("#overlaySearch").classList.toggle("hidden");
      document.body.classList.toggle("overflow-y-hidden");
      document.getElementById("searchMobile").classList.toggle("hidden");
    },
  },
};
</script>

<style></style>
