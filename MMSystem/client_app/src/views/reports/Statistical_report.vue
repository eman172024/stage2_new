<template>
  <div class="h-full bg-gray-50">
    <div class="overflow-hidden">
      <div
        id="print"
        class="w-full h-full text-center bg-gray-50 py-1 px-4"
        style="
          width: 100%;
          height: 100%;
          text-align: center;
          direction: rtl;
          --tw-bg-opacity: 1;
          background-color: rgba(249, 250, 251, var(--tw-bg-opacity));
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
                منظومة البريد
              </div>

              {{ this.current_department_name}} 
              
              <div
                class="ml-4 mt-4"
                style="margin-left: 16px; margin-top: 16px"
              >
                <span class="ml-2" style="margin-left: 8px">
                  تقرير احصائي لجميع مراسلات {{ this.mail_type }} للفترة من
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
                class="mt-8 text-left w-full"
                style="margin-top: 32px; text-align: left; width: 100%"
              >
                <span class=""> تاريخ الطباعة : {{ date }}</span>
              </div>
              <div
                class="w-full flex border-black border-2 mt-2 text-lg"
                style="
                  width: 100%;
                  display: flex;
                  --tw-border-opacity: 1;
                  border-color: rgba(0, 0, 0, var(--tw-border-opacity));
                  border-width: 2px;
                  border-style: solid;
                  margin-top: 8px;
                  font-size: 18px;
                  line-height: 28px;
                "
              >
                <div
                  class="text-center border-black border-l-2 p-1"
                  style="
                    width: 45%;
                    text-align: center;
                    border-left: 2px solid black;
                    padding: 0.25rem/* 4px */;
                  "
                >
                  اسم المكتب أو الإدارة
                </div>

                <div
                  class="text-center border-black border-l-2 p-1"
                  style="
                    width: 7.5%;
                    text-align: center;
                    border-left: 2px solid black;
                    padding: 4px;
                  "
                >
                  المرسل
                </div>

                <div
                  class="text-center border-black border-l-2 p-1"
                  style="
                    width: 7.5%;
                    text-align: center;
                    border-left: 2px solid black;
                    padding: 4px;
                  "
                >
                  الرد
                </div>

                <div
                  class="text-center p-1 border-black border-l-2"
                  style="
                    width: 7.5%;
                    text-align: center;
                    padding: 4px;
                    border-left: 2px solid black;
                  "
                >
                  لم يتم الرد
                </div>

                <div
                  class="text-center p-1 border-black border-l-2"
                  style="
                    width: 7.5%;
                    text-align: center;
                    border-left: 2px solid black;
                    padding: 4px;
                  "
                >
                  النسبة %
                </div>

                <div
                  class="text-center p-1 "
                  style="
                    width: 25%;
                    text-align: center;
                    
                    padding: 4px;
                  "
                >
                  ملاحظات
                </div>
              </div>

              <div
                v-for="(mail, index) in mails"
                :key="index"
                class="
                  w-full
                  flex
                   border-r-2 border-l-2 border-black 
                  
                "
                style="
                  width: 100%;
                  display: flex;
                  border-right: 2px solid black;
                  border-left: 2px solid black;
                  border-bottom: 1px solid black;
                  font-size: 15px;
                  line-height: 25px;
                  font-weight: 900;
                "
              >
                <div
                  class="text-center border-black border-l-2 px-1 pt-1  flex justify-center items-center"
                  style="
                    width: 45%;
                    text-align: center;
                    border-left: 2px solid black;
                    padding-left: 0.25rem/* 4px */;
                    padding-right: 0.25rem/* 4px */;
                    padding-top: 0.25rem/* 4px */;
 
                display: flex; justify-content: center; align-items: center;
                  "
                >
                  <span class="flex justify-center items-center">{{
                    mail.departmentName
                  }}</span>
                </div>

                <div
                  class="text-center border-black border-l-2 px-1   flex justify-center items-center"
                  style="
                    width: 7.5%;
                    text-align: center;
                    padding-left: 0.25rem/* 4px */;
                    padding-right: 0.25rem/* 4px */;
                    border-left: 2px solid black;
                    display: flex; justify-content: center; align-items: center;
                  "
                >
                  {{ mail.totalOfReceived.totalOfMassage }}
                </div>

                <div
                  class="border-black border-l-2 text-center px-1 pt-1 pb-0.5 flex justify-center items-center"
                  style="
                    width: 7.5%;
                    text-align: center;
                    border-left: 2px solid black;
                    padding-left: 0.25rem/* 4px */;
                    padding-right: 0.25rem/* 4px */;
                    padding-top: 0.25rem/* 4px */;
                    padding-bottom: 0.125rem/* 2px */;
                    display: flex; justify-content: center; align-items: center;
                    
                  "
                >
                  {{ mail.totalOfReceived.totalOfReplay }}
                </div>

                <div
                  class="border-black border-l-2 px-1 pt-1 pb-0.5 flex justify-center items-center"
                  style="
                    width: 7.5%;
                    padding-left: 0.25rem/* 4px */;
                    padding-right: 0.25rem/* 4px */;
                    padding-top: 0.25rem/* 4px */;
                    padding-bottom: 0.125rem/* 2px */;
                    border-left: 2px solid black;
                    
                    display: flex; justify-content: center; align-items: center;
                    
                  "
                >
                  <span class="">
                    {{ mail.totalOfReceived.totalOfNotReplay }}</span
                  >
                </div>

                <div
                  class="text-center border-black border-l-2 px-1 pt-1 pb-0.5 flex justify-center items-center"
                  style="
                    width: 7.5%;
                    text-align: center;
                    border-left: 2px solid black;
                    padding-left: 0.25rem/* 4px */;
                    padding-right: 0.25rem/* 4px */;
                    padding-top: 0.25rem/* 4px */;
                    padding-bottom: 0.125rem/* 2px */;
                    display: flex; justify-content: center; align-items: center;
                    
                  "
                >
                  {{ mail.totalOfReceived.average }} %
                </div>

                <div
                  class="text-right   px-1 pt-1 pb-0.5 flex justify-center items-center"
                  style="
                    width: 25%;
                    text-align: right;
                    display: flex; justify-content: center; align-items: center;
                    padding-left: 0.25rem/* 4px */;
                    padding-right: 0.25rem/* 4px */;
                    padding-top: 0.25rem/* 4px */;
                    padding-bottom: 0.125rem/* 2px */;
                  "
                ></div>
              </div>

              <div
                class="
                  w-full
                  flex
                   border-r-2 border-l-2 border-black 
                  
                "
                style="
                  width: 100%;
                  display: flex;
                  border-right: 2px solid black;
                  border-left: 2px solid black;
                 
                  border-bottom: 1px solid black;
                  font-size: 15px;
                  line-height: 25px;
                  font-weight: 900;
                "
              >
                <div
                  class="text-center border-black border-l-2 px-1 pt-1  flex justify-center items-center"
                  style="
                    width: 45%;
                    text-align: center;
                    border-left: 2px solid black;
                    padding-left: 0.25rem/* 4px */;
                    padding-right: 0.25rem/* 4px */;
                    padding-top: 0.25rem/* 4px */;
                    
                display: flex; justify-content: center; align-items: center;
                  "
                >
                  <span class="flex justify-center items-center">المجاميع</span>
                </div>

                <div
                  class="text-center border-black border-l-2 px-1   flex justify-center items-center"
                  style="
                    width: 7.5%;
                    text-align: center;
                  
                    border-left: 2px solid black;
                    display: flex; justify-content: center; align-items: center;
                  "
                >
                  {{ this.total.totalOfMassage }}
                </div>

                <div
                  class="border-black border-l-2 text-center px-1 pt-1 pb-0.5 flex justify-center items-center"
                  style="
                    width: 7.5%;
                    text-align: center;
                    border-left: 2px solid black;
                    
                    display: flex; justify-content: center; align-items: center;
                    
                  "
                >
                  {{ this.total.totalOfReplay }}
                </div>

                <div
                  class="border-black border-l-2 px-1 pt-1 pb-0.5 flex justify-center items-center"
                  style="
                    width: 7.5%;
                    
                    border-left: 2px solid black;
                    
                    display: flex; justify-content: center; align-items: center;
                    
                  "
                >
                  <span class=""> {{ this.total.totalOfNotReplay }}</span>
                </div>

                <div
                  class="text-center border-black border-l-2 px-1 pt-1 pb-0.5 flex justify-center items-center"
                  style="
                    width: 7.5%;
                    text-align: center;
                    border-left: 2px solid black;
                    
                    display: flex; justify-content: center; align-items: center;
                    
                  "
                >
                  {{ this.total.average }} %
                </div>

                <div
                  class="text-right  px-1 pt-1 pb-0.5 flex justify-center items-center"
                  style="
                    width: 25%;
                    text-align: right;
                    display: flex; justify-content: center; align-items: center;
                    
                  "
                ></div>
              </div>
            </div>
          </div>
        </div>
      </div>

      <div class="flex justify-end mb-10 mt-6 pl-7">
        <div class="">
          <button
            class="
            ml-2
            w-64
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

        <div class="">
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
    var date = new Date();

    var month = date.getMonth() + 1;
    var day = date.getDate();

    if (month < 10) month = "0" + month;
    if (day < 10) day = "0" + day;

    this.date = date.getFullYear() + "-" + month + "-" + day;

    switch (this.$route.params.mailtype) {
      case "3":
        this.mail_type_num = 3;
        this.mail_type = "الوارد الخارجي";
        break;

      default:
        this.mail_type_num = 1;
        this.mail_type = "البريد الداخلي";
        break;
    }

    this.GetMysectionReport();
  },

  data() {
    return {
      mails: [],
      total: [],

      mail_type: "",
      mail_type_num: 1,

    

      current_department_name:localStorage.getItem("current_department_name"),
      date: "",
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

    GetMysectionReport() {
      this.$http.mailService
        .GetMysectionReport(
          localStorage.getItem("chrome"),
          this.$route.params.dateFrom,
          this.$route.params.dateTo,
          this.mail_type_num,
          "sended"
        )
        .then((res) => {
          console.log(res);
          this.mails = res.data.sectionReport;
          this.total = res.data.totalOfTotal;
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
      this.$router.push("/sent");
    },
  },
};
</script>
