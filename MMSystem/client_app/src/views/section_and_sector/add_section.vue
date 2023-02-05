<template>
    <div class="h-screen bg-gray-100  flex overflow-scroll">
      <asideComponent></asideComponent>
  
      <div class="bg-gray-200 h-screen w-full " dir="rtl">
        <logout class="pt-2 ml-12"></logout>
        <div
          class="
          min-h-full
          mx-auto
          max-w-4xl
          p-2
          flex flex-col
          
          
          relative
        "
        >
          <div
            v-if="isaddsuccess"
            class="w-96  z-50 p-4 bg-white rounded-lg absolute top-48 flex flex-col text-center items-center"
          >
            <span>{{ addsuccess }}</span>
            <button
              class="bg-green-800 text-white h-10 w-32 mt-6 rounded-md"
              @click="isaddsuccess = false"
            >
              موافق
            </button>
          </div>
  
          <div
            v-if="iseditesuccess"
            class="w-96  z-50 p-4 bg-white rounded-lg absolute top-48 flex flex-col text-center items-center"
          >
            <span>{{ editesuccess }}</span>
            <button
              class="bg-green-800 text-white h-10 w-32 mt-6 rounded-md"
              @click="iseditesuccess = false"
            >
              موافق
            </button>
          </div>
  
          <div class="w-full h-full">
            <h1 class="font-extrabold text-xl text-center">القطاعات والجهات</h1>


            
            <fieldset class=" flex  mt-6">
                    
                     

                  
                    <div v-if="!isedit" class="flex items-center ml-4">
                      <input
                        v-model="mail_forwarding"
                        id="sector_radio"
                        type="radio"
                        name="sector1"
                        class="h-4 w-4"
                        value="1"
                        
                      />
                      <label
                        for="sector_radio"
                        class="mr-3 block text-black"
                      >
                        إضافة قطاع
                      </label>
                    </div>

                    <div v-if="!isedit" class="flex items-center mr-4 ">
                      <input
                        v-model="mail_forwarding"
                        id="side_radio"
                        type="radio"
                        name="side1"
                        class="h-4 w-4"
                        value="2"
                        
                      />
                      <label for="side_radio" class="mr-3 block text-black">
                        إضافة جهة
                      </label>
                    </div>

                  
                </fieldset>
  
            <div class="bg-gray-100 grid grid-cols-1 p-4 gap-10 text-sm mt-4">



                
              <div >
              <label for="network_user_name" class=" font-bold text-black">
                  تصنيف القطاع
                </label>
              
              <fieldset class=" flex w-10/12 justify-between mt-6">
                    
                     

                    <div class="flex items-center ">
                      <input
                        v-model="mail_type"
                        id="sub"
                        type="radio"
                        name="sub"
                        class="h-4 w-4"
                        value="1"
                        @click="get_sectors(1)"
                      />
                      <label for="sub" class="mr-3 block text-black">
                        فروع الرقابة
                      </label>
                    </div>

                    <div class="flex items-center">
                      <input
                        v-model="mail_type"
                        id="public_parties"
                        type="radio"
                        name="forwarding"
                        class="h-4 w-4"
                        value="2"
                        @click="get_sectors(2)"
                      />
                      <label
                        for="public_parties"
                        class="mr-3 block text-black"
                      >
                        جهات عامة
                      </label>
                    </div>

                    <div class="flex items-center w-32">
                      <input
                        v-model="mail_type"
                        id="private_parties"
                        type="radio"
                        name="forwarding"
                        class="h-4 w-4"
                        value="3"
                        @click="get_sectors(3)"
                      />
                      <label
                        for="private_parties"
                        class="mr-3 block text-black"
                      >
                        جهات خاصة
                      </label>
                    </div>
                  
                </fieldset>
            </div>


              <div>
                <label for="name" class="font-bold text-black">
                    الاسم
                    </label>
  
                <input
                
                  id="name"
                  type="text"
                  v-model="name"
                  class="
                  w-full
                  h-10
                  mt-1
                  focus:outline-none focus:border-green-300
                  border
                  rounded-md
                  px-2
                  py-1
                "
                  placeholder="الاسم"
                />

                <label
                v-if="show"
                  id="name"
                  type="text"
                  
                  class="
                  w-full
                  h-10
                  text-red-600
                 
                "
                  
                >{{ filterByTerm[0].section_Name }}</label>
                
              </div>
  

              <div v-if="mail_forwarding==2">


                
                <label for="management" class="font-bold text-black">
                  القطاع
                </label>
  
                <div class="relative">
                  <button
                    @click="sectorselect = !sectorselect"
                    id="sctor"
                    class="
                    text-right
                    block
                    mt-2
                    w-full
                    rounded-md
                    h-8
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
                        sectorIdSelected=sector.id;
                        sectorNameSelected=sector.section_Name
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
  
              <div>
                <span class="font-bold text-black">حالة الحساب</span>
  
                <div class="flex items-center mt-2 justify-around">
                  <div class="flex items-center">
                    <input
                      id="active"
                      type="radio"
                      class="h-4 w-4 border-gray-300"
                      value="true"
                      v-model="state1"
                    />
  
                    <label
                      for="active"
                      class="mr-3 text-sm font-medium text-black"
                    >
                      مفعل
                    </label>
                  </div>
  
                  <div class="flex items-center">
                    <input
                      id="deactive"
                      type="radio"
                      class="h-4 w-4"
                      value=""
                      v-model="state1"
                    />
  
                    <label
                      for="deactive"
                      class="mr-3 text-sm font-medium text-black"
                    >
                      غير مفعل
                    </label>
                  </div>
                </div>
              </div>
  
              
            </div>
  
            <button
              v-if="!isedit"
              class="
              mx-auto
              w-96
              bg-green-700
              text-green-50
              rounded-md
              py-2
              border border-green-300
              hover:bg-green-800
              focus:outline-none
              flex
              items-center
              justify-center
              col-span-2
              mt-4
            "
              @click="add_sector()"
            >
              <svg
                class="h-5 w-5 ml-1 text-white block"
                fill="none"
                stroke="currentColor"
                viewBox="0 0 24 24"
                xmlns="http://www.w3.org/2000/svg"
              >
                <path
                  stroke-linecap="round"
                  stroke-linejoin="round"
                  stroke-width="2"
                  d="M9 13h6m-3-3v6m-9 1V7a2 2 0 012-2h6l2 2h6a2 2 0 012 2v8a2 2 0 01-2 2H5a2 2 0 01-2-2z"
                ></path>
              </svg>
  
              <span class="text-sm font-bold block">حفظ</span>
            </button>
  
            <div v-if="isedit" class="flex justify-end ml-6">
              <button
                type="button"
                id="edit"
                @click="edit_sector()"
                class="
                mx-auto
                w-96
                bg-green-700
                text-green-50
                rounded-md
                py-2
                border border-green-300
                hover:bg-green-800
                focus:outline-none
                flex
                items-center
                justify-center
                col-span-2
                mt-4
              "
              >
                <!-- onclick="change();" -->
                <svg
                  class="w-4 h-4 stroke-current text-white ml-2 fill-current"
                  version="1.1"
                  id="Capa_1"
                  xmlns="http://www.w3.org/2000/svg"
                  xmlns:xlink="http://www.w3.org/1999/xlink"
                  x="0px"
                  y="0px"
                  viewBox="0 0 477.873 477.873"
                  style="enable-background: new 0 0 477.873 477.873"
                  xml:space="preserve"
                >
                  <g>
                    <g>
                      <path
                        d="M392.533,238.937c-9.426,0-17.067,7.641-17.067,17.067V426.67c0,9.426-7.641,17.067-17.067,17.067H51.2
                                          c-9.426,0-17.067-7.641-17.067-17.067V85.337c0-9.426,7.641-17.067,17.067-17.067H256c9.426,0,17.067-7.641,17.067-17.067
                                          S265.426,34.137,256,34.137H51.2C22.923,34.137,0,57.06,0,85.337V426.67c0,28.277,22.923,51.2,51.2,51.2h307.2
                                          c28.277,0,51.2-22.923,51.2-51.2V256.003C409.6,246.578,401.959,238.937,392.533,238.937z"
                      ></path>
                    </g>
                  </g>
                  <g>
                    <g>
                      <path
                        d="M458.742,19.142c-12.254-12.256-28.875-19.14-46.206-19.138c-17.341-0.05-33.979,6.846-46.199,19.149L141.534,243.937
                                          c-1.865,1.879-3.272,4.163-4.113,6.673l-34.133,102.4c-2.979,8.943,1.856,18.607,10.799,21.585
                                          c1.735,0.578,3.552,0.873,5.38,0.875c1.832-0.003,3.653-0.297,5.393-0.87l102.4-34.133c2.515-0.84,4.8-2.254,6.673-4.13
                                          l224.802-224.802C484.25,86.023,484.253,44.657,458.742,19.142z M434.603,87.419L212.736,309.286l-66.287,22.135l22.067-66.202
                                          L390.468,43.353c12.202-12.178,31.967-12.158,44.145,0.044c5.817,5.829,9.095,13.72,9.12,21.955
                                          C443.754,73.631,440.467,81.575,434.603,87.419z"
                      ></path>
                    </g>
                  </g>
                </svg>
                تعديل
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  </template>
  
  <script>
  import asideComponent from "@/components/asideComponent.vue";
  import logout from "@/components/logout.vue";
  export default {
    name: "Add",
  
    mounted() {

      if (localStorage.getItem("AY_LW") == null || localStorage.getItem("AY_LW") !=29 || localStorage.getItem("chrome")!=17) {
      this.$router.push("/");
    }

      this.get_sides(0);
      
      if (this.$route.params.id) {
      this.isedit = true;
      this.get_one_sector(this.$route.params.id);
      
    }
      
      
    },
  
    components: {
      asideComponent,
      logout,
    },
  
    data() {
      return {



        sides:[],

        sectorIdSelected : "",
      sectorNameSelected : "",
      sectors:[],
      sectorselect:false,

        mail_forwarding:2,
        mail_type:0,

     
        isedit: false,
  
        
  
       item:[],
        name: "",
       
        state1: "true",
       
    
        addsuccess: "",
        editesuccess: "",
        isaddsuccess: false,
        iseditesuccess: false,
       
        show:false,
      };
    },
  
    watch: {


      name:function(){


        if(this.mail_forwarding==1){

           
        if(this.filterByTerm.length==this.sectors.length||this.filterByTerm.length==0){
          this.show=false;
        }
        else{
         this.show=true;
        }

        }
        
        
        else{
          

          if(this.filterByTerm.length==this.sides.length||this.filterByTerm.length==0){
          this.show=false;
        }
        else{
         this.show=true;
        }

        }

       
      }

//       name: function(){
      
//       if(this.mail_forwarding==1){


// return this.sectors.filter((sector) => {
//  return sector.section_Name.toLowerCase().includes(this.name);


// });




// }else{


// return this.sides.filter((side) => {
// return side.section_Name.toLowerCase().includes(this.name);
// });

// }

 
  
// }
  
 
    },

    computed: {
    filterByTerm() {

      
           if(this.mail_forwarding==1){


            return this.sectors.filter((sector) => {
        return sector.section_Name.includes(this.name);
        

      });

      
            

        }else{

       
            return this.sides.filter((side) => {
        return side.section_Name.includes(this.name);
      });

           }
      
    },
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
     
     this.sectorIdSelected = "";
     this.sectorNameSelected = "";
     this.sectors = [];

     this.$http.sectorsService
       .GetSectors(type)
       .then((res) => {
         this.sectors = res.data;
       })
       .catch((err) => {
         console.log(err);
       });
   },


   get_one_sector(id){

   
    this.$http.sectorsService
       .GetSide(id)
       .then((res) => {
         this.name = res.data.section_Name;
         this.mail_type=res.data.type;
         this.sectorIdSelected=res.data.perent;

         this.get_sectors(res.data.type);
         

          this.sectorNameSelected=this.sectors.find((item) => item.id == res.data.perent).section_Name;
            
   

         if (res.data.state) {
            this.state1 = res.data.state;
          } else {
            this.state1 = "";
          }

         
       })
       .catch((err) => {
         console.log(err);
       });


   },


   
   edit_sector() {



    var isvalid=1;
        if(this.mail_forwarding==2&&this.sectorIdSelected=="")
        {
            isvalid=0;
        }


       if(this.name!=""&&this.mail_type!=0&&isvalid==1){
      
      
      
        var perent1;
        if(this.mail_forwarding==1){
          perent1=0;
        }
        else{
          perent1=Number(this.sectorIdSelected);
        }


        var sector = {
              id:this.$route.params.id,
              Section_Name: this.name,
              type: Number(this.mail_type),
              perent: perent1,
              state: Boolean(this.state1),
         

  
        };

        this.$http.sectorsService
            .edit_sector(sector)
            .then((res) => {
              setTimeout(() => {
                this.editesuccess = res.data.message;
                this.iseditesuccess = true;
                this.get_one_sector(this.$route.params.id)
              }, 201);
            })
            .catch(() => {
              setTimeout(() => {
                this.editesuccess =
                  "فشلت عملية التعديل الرجاء التأكد من البيانات وإعادة المحاولة";
                this.iseditesuccess = true;
              }, 500);
            });}

            else {
        this.editesuccess =
          "فشلت عملية التعديل الرجاء التأكد من البيانات وإعادة المحاولة";
        this.iseditesuccess = true;
      }

    },




      add_sector(){

          var isvalid=1;
        if(this.mail_forwarding==2&&this.sectorIdSelected=="")
        {
            isvalid=0;
        }


        if(this.name!=""&&this.mail_type!=0&&isvalid==1){

        var perent1;
        if(this.mail_forwarding==1){
          perent1=0;
        }
        else{
          perent1=Number(this.sectorIdSelected);
        }
        
  
          var sector = {
             

              Section_Name: this.name,
              type: Number(this.mail_type),
              perent: perent1,
              state: Boolean(this.state1),
          };
  
          this.$http.sectorsService
            .add_sector(sector)
            .then((res) => {
              setTimeout(() => {
                this.addsuccess = res.data.message;
                this.isaddsuccess = true;
                this.$router.push("/sectionForm");
                
              }, 201);
            })
            .catch(() => {
              setTimeout(() => {
                this.addsuccess =
                  "فشلت عملية الإضافة الرجاء التأكد من البيانات وإعادة المحاولة";
                this.isaddsuccess = true;
              }, 500);
            });}

            else{

              this.addsuccess =
          "فشلت عملية الإضافة الرجاء التأكد من البيانات وإعادة المحاولة";
             this.isaddsuccess = true;
            }
   

      }
    },
  };
  </script>
  
  <style></style>
  