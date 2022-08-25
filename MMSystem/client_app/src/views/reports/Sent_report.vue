<template>
  <div class="h-full bg-gray-50">
    <div class="overflow-hidden">
      <div id="content">
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

        
            <div id="pageFooter">Page </div>


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
                  font-weight: 900;
                  padding-top: 44px;
                  padding-bottom: 4px;
                  padding-left: 12px;
                  padding-right: 12px;
                "
              >
                هيئة الرقابة الإدارية
                <div class="my-4" style="margin-top: 16px; margin-bottom: 16px">
                  تقرير بصادر مكتب رئيس الهيئة {{ this.mail_type }}
                </div>

                <div
                  class="ml-4 mt-4"
                  style="margin-left: 16px; margin-top: 16px"
                >
                  <span class="ml-2" style="margin-left: 8px">
                    خلال الفترة من
                    22-12-2022
                    <!-- {{ this.$route.params.dateFrom }} -->
                    الي 
                    22-12-2022
                    <!-- {{ this.$route.params.dateTo }} -->
                  </span>
                </div>


                

                <div style="margin-top:48px">
                  <div style="text-align: right; font-size: 24px">
                    الادارة العامة للتحقيق
                  </div>
                
                  <table style="border:1px solid black; margin-top: 8px; font-size: 24px; width: 100%;">
                    <tr style="border:1px solid black;">
                      <th style="border:1px solid black; width: 10%; text-align: center;">
                        رقم الوارد
                      </th>
                      <th style="border:1px solid black; width: 60%; text-align: center;">
                        ملخص الرسالة
                      </th>
                      <th style="border:1px solid black; width: 10%; text-align: center;">
                        تاريخ الارسال
                      </th>
                      <th style="border:1px solid black; width: 10%; text-align: center;">
                        وقت الارسال
                      </th>
                      <th style="border:1px solid black; width: 10%; text-align: center;">
                        حالة الرسالة
                      </th>
                    </tr>

                    <tr style="border:1px solid black;font-weight: 600;">
                      <td style="border:1px solid black; width: 10%; text-align: center;">
                        19958
                      </td>
                      <td style="border:1px solid black; width: 60%; text-align: center;">
                        م يستىن هت نتص ره سنىر صهت نصث رهتاسي رهتسي هت سريهخعلا
                        م يستىن هت نتص ره سنىر صهت نصث رهتاسي رهتسي هت سريهخعلا
                        م يستىن هت نتص ره سنىر صهت نصث رهتاسي رهتسي هت سريهخعلا 
                      </td>
                      <td style="border:1px solid black; width: 10%; text-align: center;">
                        03:26:43م
                      </td>
                      <td style="border:1px solid black; width: 10%; text-align: center;">
                        03:26:43م
                      </td>
                      <td style="border:1px solid black; width: 10%; text-align: center;">
                        لم تقرا
                      </td>
                    </tr>

                    <tr style="border:1px solid black;font-weight: 600;">
                      <td style="border:1px solid black; width: 10%; text-align: center;">
                        19958
                      </td>
                      <td style="border:1px solid black; width: 60%; text-align: center;">
                        م يستىن هت نتص ره سنىر صهت نصث رهتاسي رهتسي هت سريهخعلا
                        م يستىن هت نتص ره سنىر صهت نصث رهتاسي رهتسي هت سريهخعلا
                        م يستىن هت نتص ره سنىر صهت نصث رهتاسي رهتسي هت سريهخعلا 
                      </td>
                      <td style="border:1px solid black; width: 10%; text-align: center;">
                        03:26:43م
                      </td>
                      <td style="border:1px solid black; width: 10%; text-align: center;">
                        03:26:43م
                      </td>
                      <td style="border:1px solid black; width: 10%; text-align: center;">
                        لم تقرا
                      </td>
                    </tr>

                    <tr style="border:1px solid black;font-weight: 600;">
                      <td style="border:1px solid black; width: 10%; text-align: center;">
                        19958
                      </td>
                      <td style="border:1px solid black; width: 60%; text-align: center;">
                        م يستىن هت نتص ره سنىر صهت نصث رهتاسي رهتسي هت سريهخعلا
                        م يستىن هت نتص ره سنىر صهت نصث رهتاسي رهتسي هت سريهخعلا
                        م يستىن هت نتص ره سنىر صهت نصث رهتاسي رهتسي هت سريهخعلا 
                      </td>
                      <td style="border:1px solid black; width: 10%; text-align: center;">
                        03:26:43م
                      </td>
                      <td style="border:1px solid black; width: 10%; text-align: center;">
                        03:26:43م
                      </td>
                      <td style="border:1px solid black; width: 10%; text-align: center;">
                        لم تقرا
                      </td>
                    </tr>
                  </table>

                  <div style="text-align: right; margin-top: 12px; font-size: 24px">
                    اجمالي عدد المراسلات لهذه الادارة او المكتب  <span style="margin-right: 16px;">30</span>
                  </div>
                </div>

                <div style="margin-top:48px">
                  <div style="text-align: right; font-size: 24px">
                    الادارة العامة للتحقيق
                  </div>
                
                  <table style="border:1px solid black; margin-top: 8px; font-size: 24px; width: 100%;">
                    <tr style="border:1px solid black;">
                      <th style="border:1px solid black; width: 10%; text-align: center;">
                        رقم الوارد
                      </th>
                      <th style="border:1px solid black; width: 60%; text-align: center;">
                        ملخص الرسالة
                      </th>
                      <th style="border:1px solid black; width: 10%; text-align: center;">
                        تاريخ الارسال
                      </th>
                      <th style="border:1px solid black; width: 10%; text-align: center;">
                        وقت الارسال
                      </th>
                      <th style="border:1px solid black; width: 10%; text-align: center;">
                        حالة الرسالة
                      </th>
                    </tr>

                    <tr style="border:1px solid black;font-weight: 600;">
                      <td style="border:1px solid black; width: 10%; text-align: center;">
                        19958
                      </td>
                      <td style="border:1px solid black; width: 60%; text-align: center;">
                        م يستىن هت نتص ره سنىر صهت نصث رهتاسي رهتسي هت سريهخعلا
                        م يستىن هت نتص ره سنىر صهت نصث رهتاسي رهتسي هت سريهخعلا
                        م يستىن هت نتص ره سنىر صهت نصث رهتاسي رهتسي هت سريهخعلا 
                      </td>
                      <td style="border:1px solid black; width: 10%; text-align: center;">
                        03:26:43م
                      </td>
                      <td style="border:1px solid black; width: 10%; text-align: center;">
                        03:26:43م
                      </td>
                      <td style="border:1px solid black; width: 10%; text-align: center;">
                        لم تقرا
                      </td>
                    </tr>

                    <tr style="border:1px solid black;font-weight: 600;">
                      <td style="border:1px solid black; width: 10%; text-align: center;">
                        19958
                      </td>
                      <td style="border:1px solid black; width: 60%; text-align: center;">
                        م يستىن هت نتص ره سنىر صهت نصث رهتاسي رهتسي هت سريهخعلا
                        م يستىن هت نتص ره سنىر صهت نصث رهتاسي رهتسي هت سريهخعلا
                        م يستىن هت نتص ره سنىر صهت نصث رهتاسي رهتسي هت سريهخعلا 
                      </td>
                      <td style="border:1px solid black; width: 10%; text-align: center;">
                        03:26:43م
                      </td>
                      <td style="border:1px solid black; width: 10%; text-align: center;">
                        03:26:43م
                      </td>
                      <td style="border:1px solid black; width: 10%; text-align: center;">
                        لم تقرا
                      </td>
                    </tr>

                    <tr style="border:1px solid black;font-weight: 600;">
                      <td style="border:1px solid black; width: 10%; text-align: center;">
                        19958
                      </td>
                      <td style="border:1px solid black; width: 60%; text-align: center;">
                        م يستىن هت نتص ره سنىر صهت نصث رهتاسي رهتسي هت سريهخعلا
                        م يستىن هت نتص ره سنىر صهت نصث رهتاسي رهتسي هت سريهخعلا
                        م يستىن هت نتص ره سنىر صهت نصث رهتاسي رهتسي هت سريهخعلا 
                      </td>
                      <td style="border:1px solid black; width: 10%; text-align: center;">
                        03:26:43م
                      </td>
                      <td style="border:1px solid black; width: 10%; text-align: center;">
                        03:26:43م
                      </td>
                      <td style="border:1px solid black; width: 10%; text-align: center;">
                        لم تقرا
                      </td>
                    </tr>
                  </table>

                  <div style="text-align: right; margin-top: 12px; font-size: 24px">
                    اجمالي عدد المراسلات لهذه الادارة او المكتب  <span style="margin-right: 16px;">30</span>
                  </div>
                </div>

                <div style="margin-top:48px">
                  <div style="text-align: right; font-size: 24px">
                    الادارة العامة للتحقيق
                  </div>
                
                  <table style="border:1px solid black; margin-top: 8px; font-size: 24px; width: 100%;">
                    <tr style="border:1px solid black;">
                      <th style="border:1px solid black; width: 10%; text-align: center;">
                        رقم الوارد
                      </th>
                      <th style="border:1px solid black; width: 60%; text-align: center;">
                        ملخص الرسالة
                      </th>
                      <th style="border:1px solid black; width: 10%; text-align: center;">
                        تاريخ الارسال
                      </th>
                      <th style="border:1px solid black; width: 10%; text-align: center;">
                        وقت الارسال
                      </th>
                      <th style="border:1px solid black; width: 10%; text-align: center;">
                        حالة الرسالة
                      </th>
                    </tr>

                    <tr style="border:1px solid black;font-weight: 600;">
                      <td style="border:1px solid black; width: 10%; text-align: center;">
                        19958
                      </td>
                      <td style="border:1px solid black; width: 60%; text-align: center;">
                        م يستىن هت نتص ره سنىر صهت نصث رهتاسي رهتسي هت سريهخعلا
                        م يستىن هت نتص ره سنىر صهت نصث رهتاسي رهتسي هت سريهخعلا
                        م يستىن هت نتص ره سنىر صهت نصث رهتاسي رهتسي هت سريهخعلا 
                      </td>
                      <td style="border:1px solid black; width: 10%; text-align: center;">
                        03:26:43م
                      </td>
                      <td style="border:1px solid black; width: 10%; text-align: center;">
                        03:26:43م
                      </td>
                      <td style="border:1px solid black; width: 10%; text-align: center;">
                        لم تقرا
                      </td>
                    </tr>

                    <tr style="border:1px solid black;font-weight: 600;">
                      <td style="border:1px solid black; width: 10%; text-align: center;">
                        19958
                      </td>
                      <td style="border:1px solid black; width: 60%; text-align: center;">
                        م يستىن هت نتص ره سنىر صهت نصث رهتاسي رهتسي هت سريهخعلا
                        م يستىن هت نتص ره سنىر صهت نصث رهتاسي رهتسي هت سريهخعلا
                        م يستىن هت نتص ره سنىر صهت نصث رهتاسي رهتسي هت سريهخعلا 
                      </td>
                      <td style="border:1px solid black; width: 10%; text-align: center;">
                        03:26:43م
                      </td>
                      <td style="border:1px solid black; width: 10%; text-align: center;">
                        03:26:43م
                      </td>
                      <td style="border:1px solid black; width: 10%; text-align: center;">
                        لم تقرا
                      </td>
                    </tr>

                    <tr style="border:1px solid black;font-weight: 600;">
                      <td style="border:1px solid black; width: 10%; text-align: center;">
                        19958
                      </td>
                      <td style="border:1px solid black; width: 60%; text-align: center;">
                        م يستىن هت نتص ره سنىر صهت نصث رهتاسي رهتسي هت سريهخعلا
                        م يستىن هت نتص ره سنىر صهت نصث رهتاسي رهتسي هت سريهخعلا
                        م يستىن هت نتص ره سنىر صهت نصث رهتاسي رهتسي هت سريهخعلا 
                      </td>
                      <td style="border:1px solid black; width: 10%; text-align: center;">
                        03:26:43م
                      </td>
                      <td style="border:1px solid black; width: 10%; text-align: center;">
                        03:26:43م
                      </td>
                      <td style="border:1px solid black; width: 10%; text-align: center;">
                        لم تقرا
                      </td>
                    </tr>
                  </table>

                  <div style="text-align: right; margin-top: 12px; font-size: 24px">
                    اجمالي عدد المراسلات لهذه الادارة او المكتب  <span style="margin-right: 16px;">30</span>
                  </div>
                </div>

                <div style="margin-top:48px">
                  <div style="text-align: right; font-size: 24px">
                    الادارة العامة للتحقيق
                  </div>
                
                  <table style="border:1px solid black; margin-top: 8px; font-size: 24px; width: 100%;">
                    <tr style="border:1px solid black;">
                      <th style="border:1px solid black; width: 10%; text-align: center;">
                        رقم الوارد
                      </th>
                      <th style="border:1px solid black; width: 60%; text-align: center;">
                        ملخص الرسالة
                      </th>
                      <th style="border:1px solid black; width: 10%; text-align: center;">
                        تاريخ الارسال
                      </th>
                      <th style="border:1px solid black; width: 10%; text-align: center;">
                        وقت الارسال
                      </th>
                      <th style="border:1px solid black; width: 10%; text-align: center;">
                        حالة الرسالة
                      </th>
                    </tr>

                    <tr style="border:1px solid black;font-weight: 600;">
                      <td style="border:1px solid black; width: 10%; text-align: center;">
                        19958
                      </td>
                      <td style="border:1px solid black; width: 60%; text-align: center;">
                        م يستىن هت نتص ره سنىر صهت نصث رهتاسي رهتسي هت سريهخعلا
                        م يستىن هت نتص ره سنىر صهت نصث رهتاسي رهتسي هت سريهخعلا
                        م يستىن هت نتص ره سنىر صهت نصث رهتاسي رهتسي هت سريهخعلا 
                      </td>
                      <td style="border:1px solid black; width: 10%; text-align: center;">
                        03:26:43م
                      </td>
                      <td style="border:1px solid black; width: 10%; text-align: center;">
                        03:26:43م
                      </td>
                      <td style="border:1px solid black; width: 10%; text-align: center;">
                        لم تقرا
                      </td>
                    </tr>

                    <tr style="border:1px solid black;font-weight: 600;">
                      <td style="border:1px solid black; width: 10%; text-align: center;">
                        19958
                      </td>
                      <td style="border:1px solid black; width: 60%; text-align: center;">
                        م يستىن هت نتص ره سنىر صهت نصث رهتاسي رهتسي هت سريهخعلا
                        م يستىن هت نتص ره سنىر صهت نصث رهتاسي رهتسي هت سريهخعلا
                        م يستىن هت نتص ره سنىر صهت نصث رهتاسي رهتسي هت سريهخعلا 
                      </td>
                      <td style="border:1px solid black; width: 10%; text-align: center;">
                        03:26:43م
                      </td>
                      <td style="border:1px solid black; width: 10%; text-align: center;">
                        03:26:43م
                      </td>
                      <td style="border:1px solid black; width: 10%; text-align: center;">
                        لم تقرا
                      </td>
                    </tr>

                    <tr style="border:1px solid black;font-weight: 600;">
                      <td style="border:1px solid black; width: 10%; text-align: center;">
                        19958
                      </td>
                      <td style="border:1px solid black; width: 60%; text-align: center;">
                        م يستىن هت نتص ره سنىر صهت نصث رهتاسي رهتسي هت سريهخعلا
                        م يستىن هت نتص ره سنىر صهت نصث رهتاسي رهتسي هت سريهخعلا
                        م يستىن هت نتص ره سنىر صهت نصث رهتاسي رهتسي هت سريهخعلا 
                      </td>
                      <td style="border:1px solid black; width: 10%; text-align: center;">
                        03:26:43م
                      </td>
                      <td style="border:1px solid black; width: 10%; text-align: center;">
                        03:26:43م
                      </td>
                      <td style="border:1px solid black; width: 10%; text-align: center;">
                        لم تقرا
                      </td>
                    </tr>
                  </table>

                  <div style="text-align: right; margin-top: 12px; font-size: 24px">
                    اجمالي عدد المراسلات لهذه الادارة او المكتب  <span style="margin-right: 16px;">30</span>
                  </div>
                </div>


              
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

    console.log(this.$route.params)


    var date = new Date();

    var month = date.getMonth() + 1;
    var day = date.getDate();

    if (month < 10) month = "0" + month;
    if (day < 10) day = "0" + day;

    this.date = date.getFullYear() + "-" + month + "-" + day;

    switch (this.$route.params.mailtype) {
      case "0":
        this.mail_type_num = 0;
        this.mail_type = "";
        break;

      case "1":
        this.mail_type_num = 1;
        this.mail_type = "للداخلي";
        break;

      case "2":
        this.mail_type_num = 2;
        this.mail_type = "للصادر خارجي";
        break;

      case "3":
        this.mail_type_num = 3;
        this.mail_type = "للوارد خارجي";
        break;
    }

    // this.GetMysectionReport();
  },

  data() {
    return {
      mails: [],
      total: [],

      mail_type: "",
      mail_type_num: 1,

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

<style>
#content {
    display: table;
}

#pageFooter {
    display: table-footer-group;
}

#pageFooter:after {
    counter-increment: page;
    content: counter(page);
}

</style>