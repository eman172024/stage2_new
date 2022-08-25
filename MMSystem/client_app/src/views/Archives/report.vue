<template>
  <div class="bg-gray-100 h-screen">
    <div class=" overflow-hidden flex">
      <div
        id="print"
        class="w-full h-full text-center bg-gray-100 "
        style="width: 100%; height: 100%; text-align: center; direction: rtl; --tw-bg-opacity: 1;
    background-color: rgba(243, 244, 246, var(--tw-bg-opacity));"
      >
        <div
          class="w-full h-full text-center"
          style="width: 100%; height: 100%; text-align: center;direction: rtl;"
        >
          <div
            class="text-center mt-10"
            style="text-align: center; margin-top: 40px"
          >
            <div
              class="text-2xl text-center font-semibold"
              style="font-size: 24px; line-height: 32px;"
            >
              هيئة الرقابة الإدارية
              <div class="my-2" style="margin-top: 8px; margin-bottom: 8px;">
                منظومة الصادر الخارجي
              </div>
              تقرير المراسلات الصادرة
            </div>
          </div>

          <div
            class="
              text-2xl text-center
              font-semibold
              mt-10
              grid
              grid-cols-2
              justify-center
              w-full
            "
            style="font-size: 24px; line-height: 32px; text-align: center;font-weight: 600;margin-top: 60px; display: grid; grid-template-columns: repeat(2, minmax(0, 1fr)); justify-content: center; width: 100%;"
          >
            <div class="ml-4" style="margin-left: 16px;">
              من :

              {{ this.$route.params.dateFrom }}
            </div>

            <div class="mr-4" style="margin-right: 16px;">
              إلى :

              {{ this.$route.params.dateTo }}
            </div>
          </div>

          <div
            class="mt-12 border-2"
            style="border-width: 2px ;border-style: solid;margin-top: 48px;"
          >
            <span
              class="text-xl font-semibold"
              style="font-size:20px;
    line-height:28px;"
              >عدد مراسلات الصادر الخارجي</span
            >

            <div
              class="flex mt-12 mb-4 justify-center ml-4"
              style="
                display: flex;
                justify-content: center;
                margin-top: 48px;
                margin-bottom: 16px;
                margin-left: 16px;
                
              "
            >
              <div></div>
              <span
                class="ml-6 font-medium text-xl"
                style="margin-left: 24px; font-weight: 500;font-size: 20px ; line-height: 28px ;"
                >{{ this.mail_type }}</span
              >

              <div
                class="mr-6 font-medium text-xl border-black border-2 px-1"
                style="margin-right: 24px; font-weight: 500; border-width: 2px; border-style: solid;  padding-left: 4px; padding-right: 4px;    --tw-border-opacity: 1; border-color: rgba(0, 0, 0, var(--tw-border-opacity));font-size:  20px ; line-height: 28px;"
              >
                {{ this.$route.params.total_of_transaction }}
              </div>
              <div></div>
            </div>
          </div>
        </div>
      </div>

      <!-- <button @click="printpage()">طباعة</button> -->
    </div>

    <div class="flex justify-end ml-6">

    <div class="  mt-8 ml-2">
      <button
        class="
                    mx-auto 
                    w-72
                    bg-green-700
                    text-green-50
                    rounded-md
                    py-3
                    border border-green-300
                    hover:bg-green-800
                    focus:outline-none
                    flex
                    items-center
                    justify-center
                    col-span-2
                  "
        @click="printpage()"
      >
        <span class="text-sm font-bold block ml-1">طباعة</span>

        <svg
          class="
                      h-5
                      w-5
                      mr-1
                      text-white
                      block
                      fill-current
                      hover:text-blue-500
                    "
          id="Capa_1"
          enable-background="new 0 0 512 512"
          height="512"
          viewBox="0 0 512 512"
          width="512"
          xmlns="http://www.w3.org/2000/svg"
        >
          <g>
            <path
              d="m437 129h-14v-54c0-41.355-33.645-75-75-75h-184c-41.355 0-75 33.645-75 75v54h-14c-41.355 0-75 33.645-75 75v120c0 41.355 33.645 75 75 75h14v68c0 24.813 20.187 45 45 45h244c24.813 0 45-20.187 45-45v-68h14c41.355 0 75-33.645 75-75v-120c0-41.355-33.645-75-75-75zm-318-54c0-24.813 20.187-45 45-45h184c24.813 0 45 20.187 45 45v54h-274zm274 392c0 8.271-6.729 15-15 15h-244c-8.271 0-15-6.729-15-15v-148h274zm89-143c0 24.813-20.187 45-45 45h-14v-50h9c8.284 0 15-6.716 15-15s-6.716-15-15-15h-352c-8.284 0-15 6.716-15 15s6.716 15 15 15h9v50h-14c-24.813 0-45-20.187-45-45v-120c0-24.813 20.187-45 45-45h362c24.813 0 45 20.187 45 45z"
            />
            <path
              d="m296 353h-80c-8.284 0-15 6.716-15 15s6.716 15 15 15h80c8.284 0 15-6.716 15-15s-6.716-15-15-15z"
            />
            <path
              d="m296 417h-80c-8.284 0-15 6.716-15 15s6.716 15 15 15h80c8.284 0 15-6.716 15-15s-6.716-15-15-15z"
            />
            <path
              d="m128 193h-48c-8.284 0-15 6.716-15 15s6.716 15 15 15h48c8.284 0 15-6.716 15-15s-6.716-15-15-15z"
            />
          </g>
        </svg>
      </button>
    </div>


        <div class="mt-8 ">
          <button
            class="
            mr-4
            w-40
            bg-green-700
            text-green-50
            rounded-md
            py-3
            border border-green-300
            hover:bg-green-800
            focus:outline-none
         
          "
            @click="back()"
          >
            <span class="text-sm font-bold block ml-1">رجوع</span>
          </button>
        </div>

    </div>


  </div>
</template>

<script>
export default {
  components: {},

  mounted() {
    switch (this.$route.params.mailType) {
      case "1": {
        this.mail_type = "فروع الرقابة";
        break;
      }

      case "2": {
        this.mail_type = "جهات عامة";
        break;
      }

      case "3": {
        this.mail_type = "جهات خاصة";
        break;
      }

      default: {
        this.mail_type = "الكل";
        break;
      }
    }
  },

  data() {
    return {
      mail_type: "",
    };
  },

  methods: {
    printpage() {
      this.$htmlToPaper("print");
    },

        back() {
      this.$router.push("/Archives");
    },
  },
};
</script>
