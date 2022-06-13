<template>
  <div
    class="relative z-10 flex-shrink-0 flex items-center h-16 bg-white border-b border-gray-200 lg:border-none"
  >
    <button
      onclick="toggle_menu()"
      class="px-4 border-r border-gray-200 text-gray-400 focus:outline-none focus:ring-2 focus:ring-inset focus:ring-cyan-500 lg:hidden"
    >
      <span class="sr-only">Open sidebar</span>
      <!-- Heroicon name: menu-alt-1 -->
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
          d="M4 6h16M4 12h8m-8 6h16"
        />
      </svg>
    </button>
    <!-- Search bar -->
    <div
      class="flex-1 px-4 flex justify-between sm:px-6 lg:max-w-6xl lg:mx-auto lg:px-8"
    >
      <div class="flex-1 flex">
        <div class="w-full flex justify-center lg:justify-end relative">
          <div class="w-full px-2 lg:px-6">
            <label for="search" class="sr-only">بحث</label>
            <div class="relative">
              <div
                class="absolute inset-y-0 left-0 pl-3 flex items-center pointer-events-none"
              >
                <svg
                  class="h-5 w-5"
                  width="24"
                  height="24"
                  viewBox="0 0 24 24"
                  fill="none"
                  xmlns="http://www.w3.org/2000/svg"
                >
                  <path
                    fill-rule="evenodd"
                    clip-rule="evenodd"
                    d="M11.5 5C7.91015 5 5 7.91015 5 11.5C5 15.0899 7.91015 18 11.5 18C13.115 18 14.5924 17.411 15.7291 16.4362L19.1465 19.8535L19.8536 19.1464L16.4362 15.7291C17.4111 14.5923 18 13.1149 18 11.5C18 7.91015 15.0899 5 11.5 5ZM6 11.5C6 8.46243 8.46243 6 11.5 6C14.5376 6 17 8.46243 17 11.5C17 14.5376 14.5376 17 11.5 17C8.46243 17 6 14.5376 6 11.5Z"
                    fill="#9E9E9E"
                  />
                </svg>
              </div>

              <div
                v-if="closeSearchMenu"
                class="absolute inset-y-0 right-0 pr-3 flex justify-center items-center"
              >
                <button
                  @click="canselSearch"
                  class="cursor-pointer rounded-full focus:outline-none"
                >
                  <svg
                    class="h-5 w-5"
                    width="24"
                    height="24"
                    viewBox="0 0 24 24"
                    fill="none"
                    xmlns="http://www.w3.org/2000/svg"
                  >
                    <path
                      d="M12 22C17.5228 22 22 17.5228 22 12C22 6.47715 17.5228 2 12 2C6.47715 2 2 6.47715 2 12C2 17.5228 6.47715 22 12 22Z"
                      stroke="black"
                      stroke-width="2"
                      stroke-linecap="round"
                      stroke-linejoin="round"
                    />
                    <path
                      d="M15 9L9 15"
                      stroke="black"
                      stroke-width="2"
                      stroke-linecap="round"
                      stroke-linejoin="round"
                    />
                    <path
                      d="M9 9L15 15"
                      stroke="black"
                      stroke-width="2"
                      stroke-linecap="round"
                      stroke-linejoin="round"
                    />
                  </svg>
                </button>
              </div>

              <input
                v-model="searchFor"
                @keyup="search()"
                id="search"
                name="search"
                autocomplete="off"
                class="block w-full px-10 py-2 leading-5 bg-gray-100 focus:outline-none focus:bg-white sm:text-sm"
                placeholder="بحث عن الجهة المرسلة, الملخص, تاريخ الارسال"
                type="text"
              />
            </div>
          </div>
          <div
            id="searchMenu"
            v-if="searchMenu"
            class="w-full absolute mt-12 px-2 lg:px-12 z-40"
          >
            <div class="shadow bg-gray-200">
              <div
                v-if="errorsearc"
                class="h-16 flex justify-center items-center"
              >
                لقد حدث خطا في عملية البحث, الرجاء المحاولة لاحقا.
              </div>

              <div v-else class="">
                <div
                  v-if="noResult"
                  class="h-16 flex justify-center items-center"
                >
                  لا توجد نتائج لعرضها.
                </div>

                <div v-else class="">
                  <div v-if="senders != 0" class="">
                    <p class="bg-grey-100 py-2 px-2">الجهات المرسلة</p>

                    <div class="px-3 py-2 bg-gray-50">
                      <router-link
                        class="py-1 block"
                        :key="index"
                        v-for="(sender, index) in senders"
                        :to="{
                          name: nameOfRouter,
                          params: { mail: sender.id },
                        }"
                      >
                        {{ sender.name }}
                      </router-link>
                    </div>
                  </div>

                  <div v-if="sentMessages != 0" class="">
                    <p class="bg-grey-100 py-2 px-2">الملخص</p>

                    <div class="px-3 py-2 bg-gray-50">
                      <router-link
                        class="py-1 block"
                        :key="index"
                        v-for="(sentMessage, index) in sentMessages"
                        :to="{
                          name: nameOfRouter,
                          params: { mail: sentMessage.id },
                        }"
                      >
                        {{ sentMessage.name }}
                      </router-link>
                    </div>
                  </div>

                  <div v-if="releaseDates != 0" class="">
                    <p class="bg-grey-100 py-2 px-2">البريد</p>

                    <div class="px-3 py-2 bg-gray-50">
                      <router-link
                        class="py-1 block"
                        :key="index"
                        v-for="(releaseDate, index) in releaseDates"
                        :to="{
                          name: nameOfRouter,
                          params: { mail: releaseDate.id },
                        }"
                      >
                        {{ releaseDate.name }}
                      </router-link>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>

      <div class="flex items-center md:mr-5">
        <!-- notifications -->
        <div
          class="relative p-1 rounded-full focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-cyan-500"
        >
          <button name="btn_not_readed">
            <span class="sr-only">View notifications</span>
            <!-- Heroicon name: bell -->

            <div class="absolute -mt-1 text-white text-xs text-center">
              1
              <div class="bg-red-500 w-4 h-4 rounded-full">2</div>
            </div>
            <svg
              class="h-6 w-6"
              xmlns="http://www.w3.org/2000/svg"
              fill="none"
              viewBox="0 0 24 24"
              stroke="black"
              aria-hidden="true"
            >
              <path
                stroke-linecap="round"
                stroke-linejoin="round"
                stroke-width="2"
                d="M15 17h5l-1.405-1.405A2.032 2.032 0 0118 14.158V11a6.002 6.002 0 00-4-5.659V5a2 2 0 10-4 0v.341C7.67 6.165 6 8.388 6 11v3.159c0 .538-.214 1.055-.595 1.436L4 17h5m6 0v1a3 3 0 11-6 0v-1m6 0H9"
              />
            </svg>
          </button>
        </div>

        <!-- logout -->
        <div class="mr-3 relative">
          <button
            @click="Logout"
            class="max-w-xs bg-white rounded-full flex items-center text-sm focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-cyan-500 lg:p-2 lg:rounded-md lg:hover:bg-gray-50"
            name="logingOut"
            id="user-menu"
            aria-haspopup="true"
          >
            <svg
              class="hidden flex-shrink-0 ml-1 h-5 w-5 text-gray-400 lg:block"
              height="512pt"
              viewBox="0 0 512.016 512"
              width="512pt"
              xmlns="http://www.w3.org/2000/svg"
            >
              <path
                d="m496 240.007812h-202.667969c-8.832031 0-16-7.167968-16-16 0-8.832031 7.167969-16 16-16h202.667969c8.832031 0 16 7.167969 16 16 0 8.832032-7.167969 16-16 16zm0 0"
              />
              <path
                d="m416 320.007812c-4.097656 0-8.191406-1.558593-11.308594-4.691406-6.25-6.253906-6.25-16.386718 0-22.636718l68.695313-68.691407-68.695313-68.695312c-6.25-6.25-6.25-16.382813 0-22.632813 6.253906-6.253906 16.386719-6.253906 22.636719 0l80 80c6.25 6.25 6.25 16.382813 0 22.632813l-80 80c-3.136719 3.15625-7.230469 4.714843-11.328125 4.714843zm0 0"
              />
              <path
                d="m170.667969 512.007812c-4.566407 0-8.898438-.640624-13.226563-1.984374l-128.386718-42.773438c-17.46875-6.101562-29.054688-22.378906-29.054688-40.574219v-384c0-23.53125 19.136719-42.6679685 42.667969-42.6679685 4.5625 0 8.894531.6406255 13.226562 1.9843755l128.382813 42.773437c17.472656 6.101563 29.054687 22.378906 29.054687 40.574219v384c0 23.53125-19.132812 42.667968-42.664062 42.667968zm-128-480c-5.867188 0-10.667969 4.800782-10.667969 10.667969v384c0 4.542969 3.050781 8.765625 7.402344 10.28125l127.785156 42.582031c.917969.296876 2.113281.46875 3.480469.46875 5.867187 0 10.664062-4.800781 10.664062-10.667968v-384c0-4.542969-3.050781-8.765625-7.402343-10.28125l-127.785157-42.582032c-.917969-.296874-2.113281-.46875-3.476562-.46875zm0 0"
              />
              <path
                d="m325.332031 170.675781c-8.832031 0-16-7.167969-16-16v-96c0-14.699219-11.964843-26.667969-26.664062-26.667969h-240c-8.832031 0-16-7.167968-16-16 0-8.832031 7.167969-15.9999995 16-15.9999995h240c32.363281 0 58.664062 26.3046875 58.664062 58.6679685v96c0 8.832031-7.167969 16-16 16zm0 0"
              />
              <path
                d="m282.667969 448.007812h-85.335938c-8.832031 0-16-7.167968-16-16 0-8.832031 7.167969-16 16-16h85.335938c14.699219 0 26.664062-11.96875 26.664062-26.667968v-96c0-8.832032 7.167969-16 16-16s16 7.167968 16 16v96c0 32.363281-26.300781 58.667968-58.664062 58.667968zm0 0"
              />
            </svg>
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  components: {},
  data() {
    return {
      state: 0,

      admin: false,
      isSideMenuOpen: false,

      searchMenu: false,
      closeSearchMenu: false,

      errorsearc: false,
      noResult: false,

      searchFor: "",

      resultOfSearch: "",

      senders: {},

      sentMessages: {},

      releaseDates: {},

      nameOfRouter: "",

      role: "",
      fullName: "",
      userId: "",
      email: "",
    };
  },
  mounted() {
    setTimeout(() => {
      this.fullName = this.$authenticatedUser.fullName;
      this.role = this.$authenticatedUser.role;
      this.email = this.$authenticatedUser.email;
      this.userId = this.$authenticatedUser.userId;

      if (this.role == 1) {
        this.nameOfRouter = "mailCC";
      } else {
        this.nameOfRouter = "mailOM-edit";
      }
    }, 500);
  },
  methods: {
    search() {
      this.closeSearchMenu = true;

      if (this.searchFor == "") {
        this.searchMenu = false;
        this.closeSearchMenu = false;
        return;
      }

      this.searchMenu = true;
      this.$http.mailService
        .GetSearchList(this.searchFor)
        .then((res) => {
          this.resultOfSearch = res.data.result;
          this.noResult = false;

          this.senders = this.resultOfSearch.senders;
          this.sentMessages = this.resultOfSearch.sentMessages;
          this.releaseDates = this.resultOfSearch.releaseDates;

          if (
            this.senders == 0 &&
            this.sentMessages == 0 &&
            this.releaseDates == 0
          ) {
            this.noResult = true;
            setTimeout(() => {
              this.searchMenu = false;
            }, 1000);
          }
        })
        .catch((err) => {
          this.noResult = false;
          this.errorsearc = true;
          setTimeout(() => {
            this.searchMenu = false;
          }, 1000);
          console.log(err);
        });
    },

    canselSearch() {
      this.searchFor = "";
      this.searchMenu = false;
      this.closeSearchMenu = false;
    },

    toggle_menu() {
      document.getElementById("menu_mobile").classList.toggle("hidden");
    },
    Logout() {
      //   this.profile = false;
      //  this.loding = true;
      this.$http.securityService
        .Logout()
        .then((res) => {
          let data = res.data;

          this.$authenticatedUser.userId = 0;
          this.$authenticatedUser.fullName = "";
          this.$authenticatedUser.userName = "";
          this.$authenticatedUser.role = "";
          this.$router.replace("/login");
        })
        .catch(() => {});
    },
  },
};
</script>

<style></style>
