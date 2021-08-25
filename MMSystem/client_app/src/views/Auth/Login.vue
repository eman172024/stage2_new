<template>
  <div>
      <div class="min-h-screen flex items-center justify-center bg-gray-50 py-12 px-4 sm:px-6 lg:px-8">
        <div class="max-w-md w-full space-y-8">
          <div>
            <img class="mx-auto h-12 w-auto" src="../../assets/img/logo-aca.png" alt="logo" />
            <h2 class="mt-6 text-center text-3xl font-extrabold text-gray-900">
              تسجيل الدخول إلى حسابك
            </h2>
          </div>
          <div class="mt-8 space-y-6">
            <input type="hidden" name="remember" value="true" />
            <div class="rounded-md shadow-sm -space-y-px">
              <div>
                <label for="email-address" class="sr-only">البريد الإلكتروني</label>
                <input id="email-address" name="email" type="email" autocomplete="email" required v-model="UserName" class="appearance-none rounded-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-t-md focus:outline-none focus:ring-green-500 focus:border-green-500 focus:z-10 sm:text-sm" placeholder=" البريد الإلكتروني" />
              </div>
              <div>
                <label for="password" class="sr-only">كلمه المرور</label>
                <input id="password" name="password" type="password" autocomplete="password" required v-model="Password" class="appearance-none rounded-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-b-md focus:outline-none focus:ring-green-500 focus:border-green-500 focus:z-10 sm:text-sm" placeholder="كلمه المرور" />
              </div>
            </div>
            <div>
              <button @click="totest()" type="submit" class="group relative w-full flex justify-center py-2 px-4 border border-transparent shadow-sm text-sm font-medium rounded-md border-green-600 text-white bg-green-600 hover:shadow-lg focus:shadow-none duration-300 focus:outline-none">
                <span class="absolute left-0 inset-y-0 flex items-center pl-3">
                    <svg class="h-5 w-5 text-white fill-current" id="_x31__x2C_5" enable-background="new 0 0 24 24" height="512" viewBox="0 0 24 24" width="512">
                        <path d="m18.75 24h-13.5c-1.24 0-2.25-1.009-2.25-2.25v-10.5c0-1.241 1.01-2.25 2.25-2.25h13.5c1.24 0 2.25 1.009 2.25 2.25v10.5c0 1.241-1.01 2.25-2.25 2.25zm-13.5-13.5c-.413 0-.75.336-.75.75v10.5c0 .414.337.75.75.75h13.5c.413 0 .75-.336.75-.75v-10.5c0-.414-.337-.75-.75-.75z"/>
                        <path d="m17.25 10.5c-.414 0-.75-.336-.75-.75v-3.75c0-2.481-2.019-4.5-4.5-4.5s-4.5 2.019-4.5 4.5v3.75c0 .414-.336.75-.75.75s-.75-.336-.75-.75v-3.75c0-3.309 2.691-6 6-6s6 2.691 6 6v3.75c0 .414-.336.75-.75.75z"/>
                        <path d="m12 17c-1.103 0-2-.897-2-2s.897-2 2-2 2 .897 2 2-.897 2-2 2zm0-2.5c-.275 0-.5.224-.5.5s.225.5.5.5.5-.224.5-.5-.225-.5-.5-.5z"/>
                        <path d="m12 20c-.414 0-.75-.336-.75-.75v-2.75c0-.414.336-.75.75-.75s.75.336.75.75v2.75c0 .414-.336.75-.75.75z"/>
                    </svg>
                </span>
                تسجيل الدخول
              </button>
            </div>
          </div>
        </div>
      </div>

      <div v-if="screenFreeze" class="w-screen h-screen bg-black bg-opacity-30 absolute inset-0 z-50 flex justify-center items-center">
            <div v-if="loading" class="">
                <svgLoadingComponent></svgLoadingComponent>
            </div>
            <div v-else>
                <div v-if="loginSuccess" class="shadow-2xl">
                    <div class="w-96 h-60 bg-white rounded-lg p-4 flex flex-col justify-between items-center">
                        <div class="flex justify-center items-center h-full">
                            <span class="font-bold">
                               {{ user.name }} &nbsp;
                            </span>
                             مرحبا بك مجدداَ في منظومة الجوازات. 
                        </div>

                        <div class="">
                            <router-link :to="{ name: 'dashboard' }" class="py-2 px-8 border border-transparent shadow-sm text-sm font-medium rounded-md text-green-600 border-green-600 hover:bg-green-600 hover:text-white duration-300 focus:outline-none">
                                دخول
                            </router-link>
                        </div>
                    </div>
                </div>

                <div v-else class="shadow-2xl">
                    <div class="w-96 h-60 bg-white rounded-lg p-4 flex flex-col justify-between items-center">
                        <div class="flex justify-between items-center w-full">
                            <p class="text-lg font-medium text-green-600">
                                فشل في عملية الدخول
                            </p>
                            <button @click="screenFreeze = false; loading = false" class="focus:outline-none">
                                <svg class="w-6 h-6 stroke-current text-base hover:text-red-500 duration-300" width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                                    <path d="M7.86 2H16.14L22 7.86V16.14L16.14 22H7.86L2 16.14V7.86L7.86 2Z"  stroke-width="2" stroke-linecap="round" stroke-linejoin="round"/>
                                    <path d="M15 9L9 15"  stroke-width="2" stroke-linecap="round" stroke-linejoin="round"/>
                                    <path d="M9 9L15 15"  stroke-width="2" stroke-linecap="round" stroke-linejoin="round"/>
                                </svg>
                            </button>
                        </div>

                        <div class="flex justify-center items-center h-full text-center leading-8">
                            يبدو أنك أخطأت في إدخال أحد الحقول.
                            <br>
                            يرجى التحقق من البيانات والمحاولة مرة أخرى.
                        </div>

                        <div class="">
                            <button @click="screenFreeze = false; loading = false" class="py-2 px-8 border border-transparent shadow-sm text-sm font-medium rounded-md text-green-600 border-green-600 hover:bg-green-600 hover:text-white duration-300 focus:outline-none">
                                المحاولة مرة اخرى
                            </button>
                        </div>
                    </div>
                </div>
            </div>
      </div>
  </div>
</template>

<script>
import svgLoadingComponent from '@/components/svgLoadingComponent.vue';

export default {
  components: {
      svgLoadingComponent
  },
  data() {
    return {
        loading: false,
        screenFreeze: false,
        loginSuccess: false,

        UserName:'',
        Password:'',

        user:{}
    };
  },
  methods: {

    totest(){
      console.log("IN")
      this.$router.push({ name: 'dashboard' });
    },
    
    submit() {
        this.screenFreeze = true;
        this.loading = true;
        var Login = {
            UserName: this.UserName,
            Password: this.Password,
        }


        this.$http.securityService
            .LoginFun(Login)
            .then((res) => {
                setTimeout(() => {
                    this.loading = false;
                    // this.screenFreeze = false;

                    this.loginSuccess = true;

                    this.user = res.data

                    this.$authenticatedUser.userId = this.user.id

                    localStorage.setItem("userId", this.user.id);

                    this.$authenticatedUser.name = this.user.name
                    this.$authenticatedUser.userName = this.user.username
                    this.$authenticatedUser.validity = this.user.validity

                }, 100);
                
            })
            .catch((err) => {
                setTimeout(() => {
                    this.loading = false;
                    // this.screenFreeze = false;

                    this.loginSuccess = false;

                  console.log(err)

                }, 100);
            });
    },
    
  },
}
</script>