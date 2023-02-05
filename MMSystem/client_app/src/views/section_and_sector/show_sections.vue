<template>
    <div class="h-screen bg-gray-100 overflow-hidden flex">
      <asideComponent></asideComponent>
  
      <div class="bg-gray-200 h-screen w-full overflow-hidden" dir="rtl">
        <div
          class="min-h-full mx-auto max-w-4xl p-2 flex flex-col mt-4 items-center"
        >
          <div class="flex justify-between w-full">
            <router-link
              :to="{ name: 'sectionForm' }"
              class="
              border border-black
              duration-300
              bg-white
              px-4
              py-2
              rounded-md
              text-gray-900
              font-bold
              hover:bg-green-600 hover:text-white
              focus:outline-none
            "
            >
           +   إضافة قطاع / جهة 
            </router-link>
  
            <logout></logout>
          </div>
          <h1 class="font-extrabold text-xl mt-2">عرض القطاعات والجهات</h1>
  
          <div class="flex mt-6 w-full">

            <div class="ml-2 w-full">
              <label class="font-medium mr-1 text-gray-700"> اسم القطاع </label>
  
              <div class="relative">
                <button
                @click="sectorselect = !sectorselect"
                  id="sector"
                  class="
                  text-right
                  block
                  mt-2
                  w-full
                  rounded-md
                  h-10
                  border
                  text-sm
                  bg-white
                  border-gray-300
                  hover:shadow-sm
                  focus:outline-none focus:border-gray-300
                  p-2
                "
                >
                  {{ sectorNameSelected }}
                </button>
  
                <div
                  v-if="sectorselect"
                  class="
                  border
                  text-sm
                  bg-white
                  border-gray-300
                  p-2
                  absolute
                  w-full
                  z-20
                  shadow
                  h-24
                  overflow-y-scroll
                  rounded-b-md
                "
                >
                  <button
                    class="block focus:outline-none w-full my-1 text-right"
                    @click="
                            get_sides(sector.id, sector.section_Name);
                            sectorselect = !sectorselect;
                          "
                   v-for="sector in sectors"
                          :key="sector.id"
                        >
                          {{ sector.section_Name }}
                  </button>
                </div>
              </div>
  
           
            </div>
  
                 <fieldset class=" flex w-10/12 justify-between mt-6">
                    
                     

                      <div class="flex items-center ">
                        <input
                          v-model="mail_forwarding"
                          id="Branches"
                          type="radio"
                          name="forwarding"
                          class="h-4 w-4"
                          value="1"
                          @click="get_sectors(1)"
                        />
                        <label for="Branches" class="mr-3 block text-gray-800">
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
                          value="2"
                          @click="get_sectors(2)"
                        />
                        <label
                          for="public_parties"
                          class="mr-3 block text-gray-800"
                        >
                          جهات عامة
                        </label>
                      </div>

                      <div class="flex items-center w-32">
                        <input
                          v-model="mail_forwarding"
                          id="private_parties"
                          type="radio"
                          name="forwarding"
                          class="h-4 w-4"
                          value="3"
                          @click="get_sectors(3)"
                        />
                        <label
                          for="private_parties"
                          class="mr-3 block text-gray-800"
                        >
                          جهات خاصة
                        </label>
                      </div>
                    
                  </fieldset>
          </div>
  
          <div
            v-if="sides[0]"
            class="bg-gray-100 mt-3 rounded-md overflow-y-auto max-h-96 w-full"
          >
            <div
              class="
              grid grid-cols-6
              border-b
              items-center
              p-1
              sticky
              top-0
              bg-gray-100
            "
            >
              <span class="col-span-2 mx-auto text-lg font-bold text-center"
                  >  الاسم  </span>
  
              
  
              <span class="col-span-2 mx-auto text-lg font-bold text-center">الحالة</span>
  
              <span class=" mx-auto col-span-2 text-lg font-bold text-center">تفعيل / إلغاء تفعيل</span>
            </div>
  
            
              <div
                v-for="side in sides"
                :key="side.id"
                class="grid grid-cols-6 mt-2 border-b pb-4 items-center"
              >
                <router-link
                  class="grid grid-cols-4 col-span-4 mt-2 border-b pb-4 items-center"
                  :to="{
                    name: 'sectionForm',
                    params: {
                      id: side.id,
                   
                    },
                  }"
                >
                  <span class="col-span-2 mx-auto">{{ side.section_Name }}</span>
  
                 
  
                  <span class="col-span-2 mx-auto" v-if="side.state == true"
                    >مفعل</span
                  >
                  <span class="col-span-2 mx-auto" v-else>غير مفعل</span>
                </router-link>
  
                <button
                  class="
  
                  hover:text-red-500
                  text-black
                  p-2
                  mx-auto
                  rounded-md
                  col-span-2
                "
                  v-if="side.state == true"
                  @click="stop_side(side.id)"
                  title="إيقاف المستخدم"
                >
                  <svg
                    class="w-8 h-8 inline-block text-center"
                    fill="none"
                    stroke="currentColor"
                    viewBox="0 0 24 24"
                    xmlns="http://www.w3.org/2000/svg"
                  >
                    <path
                      stroke-linecap="round"
                      stroke-linejoin="round"
                      stroke-width="2"
                      d="M12 15v2m-6 4h12a2 2 0 002-2v-6a2 2 0 00-2-2H6a2 2 0 00-2 2v6a2 2 0 002 2zm10-10V7a4 4 0 00-8 0v4h8z"
                    ></path>
                  </svg>
                </button>
  
                <button
                  class="
                  hover:text-green-500
                  text-black-500
                  col-span-2
                  p-2
                  mx-auto
                  rounded-md
                "
                  v-else
                  @click="stop_side(side.id)"
                  title="تفعيل المستخدم"
                >
                  <svg
                    class="w-8 h-8 inline-block text-center"
                    fill="none"
                    stroke="currentColor"
                    viewBox="0 0 24 24"
                    xmlns="http://www.w3.org/2000/svg"
                  >
                    <path
                      stroke-linecap="round"
                      stroke-linejoin="round"
                      stroke-width="2"
                      d="M8 11V7a4 4 0 118 0m-4 8v2m-6 4h12a2 2 0 002-2v-6a2 2 0 00-2-2H6a2 2 0 00-2 2v6a2 2 0 002 2z"
                    ></path>
                  </svg>
                </button>
              </div>
            
          </div>
          <div v-else class="text-center text-2xl text-red-500 mt-20">
                            لا توجد جهات في هذا القطاع
          </div>
        </div>
      </div>
    </div>
  </template>
  
  <script>
  import asideComponent from "@/components/asideComponent.vue";
  import logout from "@/components/logout.vue";
  
  export default {
    watch: {
   
  
     
    },
  
    mounted() {


      if (localStorage.getItem("AY_LW") == null || localStorage.getItem("AY_LW") !=29 || localStorage.getItem("chrome")!=17) {
      this.$router.push("/");
    }
    
    
        //this.get_sectors(1);
        this.get_sides(0);
     
    },
  
    name: "Show",
    components: {
      asideComponent,
      logout,
    },
    data() {
      return {

       
        mail_forwarding:"",
      sideNameSelected : "",
      sideIdSelected : "",

      sectorIdSelected : "",
      sectorNameSelected : "",

      sectors : [],
      sides : [],

      sectorselect: false,





        
      };
    },
  
    methods: {

        get_sides(sector, sector_name) {
      this.sideNameSelected = "";
      this.sideIdSelected = "";
      this.sides = [];
      this.sectorNameSelected = sector_name;
      this.sectorIdSelected=sector;
      this.$http.sectorsService
        .GetSides(sector)
        .then((res) => {
          this.sides = res.data;
        })
        .catch((err) => {
          console.log(err);
        });
    },

        get_sectors(type) {
      this.sideNameSelected = "";
      this.sideIdSelected = "";
      this.sectorIdSelected = "";
      this.sectorNameSelected = "";
      this.sectors = [];
      this.sides = [];

      this.$http.sectorsService
        .GetSectors(type)
        .then((res) => {
          this.sectors = res.data;
          this.get_sides(this.sectors[0].id)
        })
        .catch((err) => {
          console.log(err);
        });
    },






  
  
    
  
      stop_side(id) {
      
  
        this.$http.sectorsService
          .stop_sector(id)
          .then((res) => {
            setTimeout(() => {
              console.log(res);
              this.get_sides(this.sectorIdSelected,this.sectorNameSelected);
              // this.documentSection = true;
              
              // this.proceduresSection = true;
            }, 500);
          })
          .catch(() => {
            setTimeout(() => {}, 500);
          });
      },
  
 
    },
  };
  </script>
  
  <style></style>
  