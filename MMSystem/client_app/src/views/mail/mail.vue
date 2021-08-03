<template>
  <div class="">
    <div class="h-screen bg-white overflow-hidden flex">
      <asideComponent></asideComponent>
      <div class="flex-1 bg-gray-50 w-0 overflow-y-auto">
        <div class="max-w-4xl  mx-auto  flex flex-col md:px-8 xl:px-0">
          <navComponent></navComponent>
          <main class="flex-1 relative focus:outline-none py-6">
            <h3 class="text-xl font-medium text-gray-900">
              معلومات البريد
            </h3>
            <div class="mt-6 space-y-6 ">
                <!--
                <div class="grid grid-cols-1 gap-y-6 gap-x-4 sm:grid-cols-6 bg-white rounded-md p-8">
                    <div class="sm:col-span-6">
                        <label
                        for="title"
                        class="block text-base font-medium text-gray-800"
                        >
                        العنوان
                        </label>
                        <input
                            v-model="title"
                            type="text"
                            id="title"
                            class="block mt-2 h-12 w-full rounded-md border border-gray-200 hover:shadow-sm focus:outline-none focus:border-gray-300 px-2"
                            required
                        />
                    </div>

                    <div class="sm:col-span-6">
                        <label
                        for="summary"
                        class="block text-base font-medium text-gray-800"
                        >
                        الملخص
                        </label>
                        <textarea
                            v-model="summary"
                            id="summary"
                            rows="3"
                            class="block mt-2 w-full rounded-md border border-gray-200 hover:shadow-sm focus:outline-none focus:border-gray-300 p-2"
                        >
                        </textarea>
                    </div>

                    <div class="sm:col-span-3">
                        <label
                        for="category"
                        class="block text-base font-medium text-gray-800"
                        >
                        التصنيف
                        </label>
                        <select name="" id="category" class="block mt-2 w-full rounded-md border border-gray-200 hover:shadow-sm focus:outline-none focus:border-gray-300 p-2">
                            <option value="مقال صحفي">
                                مقال صحفي
                            </option>
                            <option value="مقال صحفي">
                                مقال صحفي
                            </option>
                        </select>
                    </div>

                    <div class="sm:col-span-3">
                        <label
                        for="date"
                        class="block text-base font-medium text-gray-800"
                        >
                        التاريخ
                        </label>
                        <input
                            v-model="releaseDate"
                            type="date"
                            id="date"
                            class="block mt-2 w-full rounded-md border border-gray-200 hover:shadow-sm focus:outline-none focus:border-gray-300 p-2"
                        />
                    </div>

                    <div class="sm:col-span-3">
                        <label
                        for="general_incoming_number"
                        class="block text-base font-medium text-gray-800"
                        >
                        رقم الوارد العام
                        </label>
                        <input
                            v-model="general_incoming_number"
                            type="number"
                            id="general_incoming_number"
                            class="block mt-2 h-12 w-full rounded-md border border-gray-200 hover:shadow-sm focus:outline-none focus:border-gray-300 px-2"
                            required
                        />
                    </div>

                    <div class="sm:col-span-3">
                        <label
                        for="year"
                        class="block text-base font-medium text-gray-800"
                        >
                        السنة
                        </label>
                        <input
                            type="number"
                            placeholder="YYYY"
                            min="2011"
                            max="2100"
                            v-model="releaseDate"
                            id="year"
                            class="block mt-2 w-full rounded-md border border-gray-200 hover:shadow-sm focus:outline-none focus:border-gray-300 p-2"
                        />
                    </div>
                </div>

                <div class="grid grid-cols-1 gap-y-6 gap-x-4 sm:grid-cols-6 bg-white rounded-md p-8">
                    <div class="sm:col-span-6">
                        <label
                        for="required_action"
                        class="block text-base font-medium text-gray-800"
                        >
                        الإجراء المطلوب
                        </label>
                        <textarea
                            v-model="required_action"
                            id="required_action"
                            rows="3"
                            class="block mt-2 w-full rounded-md border border-gray-200 hover:shadow-sm focus:outline-none focus:border-gray-300 p-2"
                        >
                        </textarea>
                    </div>

                    <div class="sm:col-span-6 grid grid-cols-1 gap-y-6 gap-x-4 sm:grid-cols-6">
                        <div class="sm:col-span-3">
                            <label
                                for="side"
                                class="block text-base font-medium text-gray-800"
                            >
                                الجهة
                            </label>
                            <select name="" id="side" class="block mt-2 w-full rounded-md border border-gray-200 hover:shadow-sm focus:outline-none focus:border-gray-300 p-2">
                                <option value="مقال صحفي">
                                    مقال صحفي
                                </option>
                                <option value="مقال صحفي">
                                    مقال صحفي
                                </option>
                            </select>
                        </div>

                        <div class="sm:col-span-2">
                            <label
                                for="action"
                                class="block text-base font-medium text-gray-800"
                            >
                            الإجراء
                            </label>
                            <select name="" id="action" class="block mt-2 w-full rounded-md border border-gray-200 hover:shadow-sm focus:outline-none focus:border-gray-300 p-2">
                                <option value="مقال صحفي">
                                    مقال صحفي
                                </option>
                                <option value="مقال صحفي">
                                    مقال صحفي
                                </option>
                            </select>
                        </div>

                        <div class="sm:col-span-1 ">
                           
                            <button class="w-full mt-8 rounded-md border text-green-400 duration-200 border-green-400 hover:text-green-500 hover:border-green-500 px-4 py-2 text-base font-medium">
                                إضافة +
                            </button>
                        </div>
                    </div>

                    <div class="sm:col-span-6">
                        <label
                            for="required_action"
                            class="block text-base font-medium text-gray-800"
                        >
                            المرسل إليهم    
                        </label>
                        <div class="mt-2 w-full rounded-md border border-gray-200 p-2 min-h-24 flex items-center">


                            <div class="border border-gray-400 rounded-md flex items-center px-4 py-2 mx-2">
                                مكتب التوثيق, للإجراء
                                <button class="mr-2 rounded-full">
                                    <svg aria-hidden="true" focusable="false" data-prefix="far" data-icon="times-circle" class="w-5 h-5 stroke-current text-red-400 hover:text-red-500 duration-200" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512">
                                        <path fill="currentColor" d="M256 8C119 8 8 119 8 256s111 248 248 248 248-111 248-248S393 8 256 8zm0 448c-110.5 0-200-89.5-200-200S145.5 56 256 56s200 89.5 200 200-89.5 200-200 200zm101.8-262.2L295.6 256l62.2 62.2c4.7 4.7 4.7 12.3 0 17l-22.6 22.6c-4.7 4.7-12.3 4.7-17 0L256 295.6l-62.2 62.2c-4.7 4.7-12.3 4.7-17 0l-22.6-22.6c-4.7-4.7-4.7-12.3 0-17l62.2-62.2-62.2-62.2c-4.7-4.7-4.7-12.3 0-17l22.6-22.6c4.7-4.7 12.3-4.7 17 0l62.2 62.2 62.2-62.2c4.7-4.7 12.3-4.7 17 0l22.6 22.6c4.7 4.7 4.7 12.3 0 17z"></path>
                                    </svg>
                                </button>
                            </div>

                            <div class="border border-gray-400 rounded-md flex items-center px-4 py-2 mx-2">
                                مكتب التوثيق, للإجراء
                                <button class="mr-2 rounded-full">
                                    <svg aria-hidden="true" focusable="false" data-prefix="far" data-icon="times-circle" class="w-5 h-5 stroke-current text-red-400 hover:text-red-500 duration-200" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512">
                                        <path fill="currentColor" d="M256 8C119 8 8 119 8 256s111 248 248 248 248-111 248-248S393 8 256 8zm0 448c-110.5 0-200-89.5-200-200S145.5 56 256 56s200 89.5 200 200-89.5 200-200 200zm101.8-262.2L295.6 256l62.2 62.2c4.7 4.7 4.7 12.3 0 17l-22.6 22.6c-4.7 4.7-12.3 4.7-17 0L256 295.6l-62.2 62.2c-4.7 4.7-12.3 4.7-17 0l-22.6-22.6c-4.7-4.7-4.7-12.3 0-17l62.2-62.2-62.2-62.2c-4.7-4.7-4.7-12.3 0-17l22.6-22.6c4.7-4.7 12.3-4.7 17 0l62.2 62.2 62.2-62.2c4.7-4.7 12.3-4.7 17 0l22.6 22.6c4.7 4.7 4.7 12.3 0 17z"></path>
                                    </svg>
                                </button>
                            </div>

                            
                        </div>
                    </div>
                </div>
                -->

                <div class="grid grid-cols-1 gap-y-6 gap-x-4 sm:grid-cols-6 bg-white rounded-md p-8">
                    <fieldset class="sm:col-span-3">
                        <div>
                            <legend class="block text-base font-medium text-gray-800">
                            نوع البريد
                            </legend>
                        </div>
                        <div class="mt-3 flex justify-between items-center">
                            <div class="flex items-center">
                                <input
                                    v-model="mailType"
                                    id="internal"
                                    type="radio"
                                    name="type"

                                    class="h-4 w-4"
                                    value="1"
                                />
                                <label
                                    for="internal"
                                    class="mr-3 block font-medium text-gray-800"
                                >
                                    داخلي
                                </label>
                            </div>

                            <div class="flex items-center">
                                <input
                                    v-model="mailType"
                                    id="internal_export"
                                    type="radio"
                                    name="type"
                                    class="h-4 w-4"
                                    value="3"
                                />
                                <label
                                    for="internal_export"
                                    class="mr-3 block font-medium text-gray-800"
                                >
                                    صادر داخلي
                                </label>
                            </div>

                            <div class="flex items-center">
                                <input
                                    v-model="mailType"
                                    id="external_incoming"
                                    type="radio"
                                    name="type"

                                    class="h-4 w-4"
                                    value="2"
                                />
                                <label
                                    for="external_incoming"
                                    class="mr-3 block font-medium text-gray-800"
                                >
                                    وارد خارجي 
                                </label>
                            </div>
                        </div>
                    </fieldset>

                    <div class="sm:col-span-6 grid grid-cols-1 gap-y-6 gap-x-4 sm:grid-cols-6 border border-gray-200 rounded-md p-4">
                        <fieldset class="sm:col-span-3">
                            <legend class="block text-base font-medium text-gray-800">
                                توجيه البريد
                            </legend>
                            <div class="mt-3 flex justify-between items-center">
                                <div class="flex items-center">
                                    <input
                                        v-model="mail_forwarding"
                                        id="Branches"
                                        type="radio"
                                        name="forwarding"
                                        class="h-4 w-4"
                                        value="1"
                                    />
                                    <label
                                        for="Branches"
                                        class="mr-3 block font-medium text-gray-800"
                                    >
                                        فروع الرقابة
                                    </label>
                                </div>

                                <div class="flex items-center">
                                    <input
                                        v-model="mail_forwarding"
                                        id="public_parties"
                                        type="radio"
                                        name="forwarding"
                                        class="h-4 w-4"
                                        value="3"
                                    />
                                    <label
                                        for="public_parties"
                                        class="mr-3 block font-medium text-gray-800"
                                    >
                                        جهات عامة
                                    </label>
                                </div>

                                <div class="flex items-center">
                                    <input
                                        v-model="mail_forwarding"
                                        id="private_parties"
                                        type="radio"
                                        name="forwarding"

                                        class="h-4 w-4"
                                        value="2"
                                    />
                                    <label
                                        for="private_parties"
                                        class="mr-3 block font-medium text-gray-800"
                                    >
                                        جهات خاصة 
                                    </label>
                                </div>
                            </div>
                        </fieldset>
                        <br>
                        <div class="sm:col-span-3">
                            <label
                                for="send_to_sector"
                                class="block text-base font-medium text-gray-800"
                            >
                                القطاع
                            </label>
                            <select name="" id="send_to_sector" class="block mt-2 w-full rounded-md border border-gray-200 hover:shadow-sm focus:outline-none focus:border-gray-300 p-2">
                                <option value="مقال صحفي">
                                    مقال صحفي
                                </option>
                                <option value="مقال صحفي">
                                    مقال صحفي
                                </option>
                            </select>
                        </div>

                        <div class="sm:col-span-3">
                            <label
                                for="send_to_side"
                                class="block text-base font-medium text-gray-800"
                            >
                                الجهة
                            </label>
                            <select name="" id="send_to_side" class="block mt-2 w-full rounded-md border border-gray-200 hover:shadow-sm focus:outline-none focus:border-gray-300 p-2">
                                <option value="مقال صحفي">
                                    مقال صحفي
                                </option>
                                <option value="مقال صحفي">
                                    مقال صحفي
                                </option>
                            </select>
                        </div>
                    </div>


                    <div class="sm:col-span-6 grid grid-cols-1 gap-y-6 gap-x-4 sm:grid-cols-6 border border-gray-200 rounded-md p-4">
                        <fieldset class="sm:col-span-3">
                            <legend class="block text-base font-medium text-gray-800">
                                وارد إلي
                            </legend>
                            <div class="mt-3 flex justify-between items-center">
                                <div class="flex items-center">
                                    <input
                                        v-model="mail_forwarding"
                                        id="Branches"
                                        type="radio"
                                        name="forwarding"
                                        class="h-4 w-4"
                                        value="1"
                                    />
                                    <label
                                        for="Branches"
                                        class="mr-3 block font-medium text-gray-800"
                                    >
                                        فروع الرقابة
                                    </label>
                                </div>

                                <div class="flex items-center">
                                    <input
                                        v-model="mail_forwarding"
                                        id="public_parties"
                                        type="radio"
                                        name="forwarding"
                                        class="h-4 w-4"
                                        value="3"
                                    />
                                    <label
                                        for="public_parties"
                                        class="mr-3 block font-medium text-gray-800"
                                    >
                                        جهات عامة
                                    </label>
                                </div>

                                <div class="flex items-center">
                                    <input
                                        v-model="mail_forwarding"
                                        id="private_parties"
                                        type="radio"
                                        name="forwarding"

                                        class="h-4 w-4"
                                        value="2"
                                    />
                                    <label
                                        for="private_parties"
                                        class="mr-3 block font-medium text-gray-800"
                                    >
                                        جهات خاصة 
                                    </label>
                                </div>
                            </div>
                        </fieldset>
                        <br>
                        <div class="sm:col-span-3">
                            <label
                                for="send_to_sector"
                                class="block text-base font-medium text-gray-800"
                            >
                                القطاع
                            </label>
                            <select name="" id="send_to_sector" class="block mt-2 w-full rounded-md border border-gray-200 hover:shadow-sm focus:outline-none focus:border-gray-300 p-2">
                                <option value="مقال صحفي">
                                    مقال صحفي
                                </option>
                                <option value="مقال صحفي">
                                    مقال صحفي
                                </option>
                            </select>
                        </div>

                        <div class="sm:col-span-3">
                            <label
                                for="send_to_side"
                                class="block text-base font-medium text-gray-800"
                            >
                                الجهة
                            </label>
                            <select name="" id="send_to_side" class="block mt-2 w-full rounded-md border border-gray-200 hover:shadow-sm focus:outline-none focus:border-gray-300 p-2">
                                <option value="مقال صحفي">
                                    مقال صحفي
                                </option>
                                <option value="مقال صحفي">
                                    مقال صحفي
                                </option>
                            </select>
                        </div>
                    </div>
                </div>


              



              
            </div>
          </main>
        </div>
      </div>
    </div>
    <div
      v-if="screenFreeze"
      class="w-screen h-screen bg-black bg-opacity-30 absolute inset-0 z-50 flex justify-center items-center"
    >
      <div v-if="loading" class="">
        <svgLoadingComponent></svgLoadingComponent>
      </div>
    </div>
  </div>
</template>

<script>
import asideComponent from "@/components/asideComponent.vue";
import navComponent from "@/components/navComponent.vue";
import svgLoadingComponent from "@/components/svgLoadingComponent.vue";

export default {
  created() {},

  mounted() {
    console.log("in dashbord");
    //this.GetNumbersOfReports();
    //this.GetLastFiveTransactions();
  },

  components: {
    asideComponent,
    navComponent,
    svgLoadingComponent,
  },

  data() {
    return {
      // userId: this.$authenticatedUser.userId,
      //name: this.$authenticatedUser.name,
      // userName: this.$authenticatedUser.userName,
      // validity: this.$authenticatedUser.validity,

      LastTransactions: {},
      Reports: {
        count_Of_all_transaction: 0,
        count_Of_received: 0,
        count_Of_booking: 0,
      },
      loading: false,
      screenFreeze: false,
    };
  },
  methods: {
    //   Numbers_Of_Reports

    GetLastFiveTransactions() {
      this.screenFreeze = true;
      this.loading = true;
      this.$http.DashboardService.LastFiveTransactions()
        .then((res) => {
          setTimeout(() => {
            this.screenFreeze = false;
            this.loading = false;

            this.LastTransactions = res.data;
            // this.Reports.count_Of_all_transaction = res.data.count_Of_all_transaction;
            // this.Reports.count_Of_booking = res.data.count_Of_booking;
            // this.Reports.count_Of_received = res.data.count_Of_received;
          }, 100);
        })
        .catch((err) => {
          setTimeout(() => {
            this.screenFreeze = false;
            this.loading = false;
            console.log(err);
          }, 100);
        });
    },

    GetNumbersOfReports() {
      this.screenFreeze = true;
      this.loading = true;
      this.$http.DashboardService.NumbersOfReports()
        .then((res) => {
          setTimeout(() => {
            this.screenFreeze = false;
            this.loading = false;

            this.Reports.count_Of_all_transaction =
              res.data.count_Of_all_transaction;
            this.Reports.count_Of_booking = res.data.count_Of_booking;
            this.Reports.count_Of_received = res.data.count_Of_received;
          }, 100);
        })
        .catch((err) => {
          setTimeout(() => {
            this.screenFreeze = false;
            this.loading = false;
            console.log(err);
          }, 100);
        });
    },
  },
};
</script>
