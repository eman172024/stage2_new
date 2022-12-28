<template>

<div class="bg-gray-100 h-full">
  
  <div class=" bg-gray-100 ">
    
      <div
        id="print"
        class="w-full  text-center  py-1 px-4"
        style="
          width: 100%;
          height: 100%;
          text-align: center;
          direction: rtl;
          --tw-bg-opacity: 1;
          background-color: rgba(243, 244, 246, var(--tw-bg-opacity));
          padding-top: 4px;
          padding-bottom: 4px;
          padding-left: 16px;
          padding-right: 16px;
        "
      >
        <div
          class="w-full h-full text-center"
          style="width: 100%; height: 100%; text-align: center; direction: rtl"
        >
          <div class="text-center" style="text-align: center">
            <div
              class="text-2xl text-center font-semibold"
              style="
                font-size: 24px;
                line-height: 32px;
                text-align: center;
                font-weight: 600;
                padding-top: 4px;
                padding-bottom: 4px;
                padding-left: 12px;
                padding-right: 12px;
              "
            >
              هيئة الرقابة الإدارية
              <div class="my-4" style="margin-top: 16px; margin-bottom: 16px">
                مكتب المحفوظات
              </div>

              <div
                class="ml-4 mt-4"
                style="margin-left: 16px; margin-top: 16px"
              >
                <span class="ml-2" style="margin-left: 8px">
                  تقرير بالرسائل الصادرة من الجهاز خلال الفترة من تاريخ
                </span>

                <span
                  class="mr-2 ml-2"
                  style="margin-right: 8px; margin-left: 8px"
                >
                  {{ this.$route.params.dateFrom }}
                </span>

                <span
                  class="mr-2 ml-2"
                  style="margin-right: 8px; margin-left: 8px"
                >
                  إلى
                </span>

                <span
                  class="mr-2 ml-2"
                  style="margin-right: 8px; margin-left: 8px"
                >
                  {{ this.$route.params.dateTo }}
                </span>
              </div>

              <div
                class="w-full flex border-black border-2 mt-10"
                style="
                  width: 100%;
                  display: flex;
                  --tw-border-opacity: 1;
                  border-color: rgba(0, 0, 0, var(--tw-border-opacity));
                  border-width: 2px;
                  border-style: solid;
                  margin-top: 40px;
                "
              >
                <div
                  class="w-1/12 text-center border-black border-l-2 p-1"
                  style="
                    width: 8.333333%;
                    text-align: center;
                    border-left: 2px solid black;
                    padding: 4px;
                  "
                >
                  ر.م
                </div>

                <div
                  class="w-2/12 text-center border-black border-l-2 p-1"
                  style="
                    width: 16.666667%;
                    text-align: center;
                    border-left: 2px solid black;
                    padding: 4px;
                  "
                >
                  رقم الصادر
                </div>

                <div
                  class="w-5/12 text-center border-black border-l-2 p-1"
                  style="
                    width: 41.666667%;
                    text-align: center;
                    border-left: 2px solid black;
                    padding: 4px;
                  "
                >
                  الجهة الصادر إليها
                </div>

                <div
                  class="w-4/12 text-center p-1"
                  style="width: 33.333333%; text-align: center; padding: 4px"
                >
                  ملاحظات
                </div>
              </div>

              <div
                v-for="(mail, index) in mails"
                :key="index"
                :num1="12"
                class="
                  w-full
                  flex
                  border-b-2 border-r-2 border-l-2 border-black
                  text-lg
                  font-medium
                "
                style="
                  width: 100%;
                  display: flex;
                 border-bottom: 2px solid black;
                  border-right: 2px solid black;
                  border-left: 2px solid black;
                  font-size: 18px;
                  line-height: 28px;
                  font-weight: 500;
                "
              >
                <div
                  class="w-1/12 text-center border-black border-l-2 p-1"
                  style="
                    width: 8.333333%;
                    text-align: center;
                    border-left: 2px solid black;

                    padding: 4px;
                  "
                >
                  {{ index + 1 }}
                </div>

                <div
                  class="w-2/12 text-center border-black border-l-2 p-1"
                  style="
                    width: 16.666667%;
                    text-align: center;
                    padding: 4px;
                    border-left: 2px solid black;
                  "
                >
                  {{ mail.mail_Number }}
                </div>

                <div
                  class="w-5/12 text-right border-black border-l-2 p-1"
                  style="
                    width: 41.666667%;
                    text-align: right;
                    border-left: 2px solid black;
                  "
                >
                  {{ mail.side_Name }}
                </div>

                <div
                  class="w-4/12 text-right p-1"
                  style="width: 33.333333%; text-align: right; padding: 4px"
                >
                  {{ mail.note }}
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>





    <div class="flex justify-end ml-6 mb-8">
      
  
      <div class=" ">
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
          "
          @click="printpage(), printHistory()"
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

        <div class=" ">
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
  </div>
</template>

<script>
export default {
  components: {},

  mounted() {
    this.mails = this.$route.params.mails;
  },

  data() {
    return {
      mails: [],
    };
  },

  methods: {
    printpage() {
      this.$htmlToPaper("print");
    },

    printHistory() {
      var model = {
        Current: Number(localStorage.getItem("AY_LW")),
      };

      this.$http.mailService
        .printHistory(model)
        .then((res) => {
          console.log(res);
          setTimeout(() => {}, 300);
        })
        .catch((err) => {
          setTimeout(() => {
            this.screenFreeze = false;
            this.loading = false;
            console.log(err);
          }, 100);
        });
    },

       back() {
      this.$router.push("/Archives");
    },
  },
};
</script>
