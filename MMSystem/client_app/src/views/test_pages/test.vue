<template>
  <div class="">
    <button @click="GetData()" class="bg-blue-500 px-8 py-2 rounded-xl">
      GetData
    </button>

    <div class="flex justify-center items-center">
      <div id="className" class="bg-red-200 h-64 w-64 overflow-y-scroll mt-12 ">
        <div
          v-for="mail in inboxMails"
          :key="mail.mail_id"
          class="bg-gray-100 p-8 mt-4 w-full"
        >
          {{ mail.summary }}
        </div>
      </div>
    </div>

    <div class="h-96 bg-red-500 w-full"></div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      my_user_id: "",
      my_department_id: "",

      inboxMails: {},
      total_of_transaction: "",

      page_num: 1,
    };
  },

  mounted() {
    this.GetData();

    document
      .querySelector("#className")
      .addEventListener("scroll", this.handleScroll);
  },

  methods: {
    handleScroll() {
        const obj = document.querySelector("#className");
        if (obj.scrollTop === obj.scrollHeight - obj.offsetHeight) {
            if(this.inboxMails.length  < this.total_of_transaction){
                this.GetNewData()
            }
        }
    },


    GetNewData() { 
        this.page_num = this.page_num + 1
      this.$http.mailService
        .testsss(this.page_num)
        .then((res) => {
            
            for (let index = 0; index < res.data.mail.length; index++) {
                const element = res.data.mail[index];
                this.inboxMails.push(element)
            }
        })
        .catch((err) => {
          console.log(err);
        });
    },


    GetData() {
      this.$http.mailService
        .testsss(this.page_num)
        .then((res) => {
          this.inboxMails = res.data.mail;
          this.total_of_transaction = res.data.total;

          
        })
        .catch((err) => {
          console.log(err);
        });
    },
  },
};
</script>

<style></style>
