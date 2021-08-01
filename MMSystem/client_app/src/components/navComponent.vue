<template>
    <div class="relative z-10 flex-shrink-0 h-16 w-full border-b border-gray-200 flex">
                    <button @click="toggleMenu =! toggleMenu" class="border-r border-gray-200 px-4 text-gray-500 focus:outline-none focus:ring-2 focus:ring-inset focus:ring-indigo-500 md:hidden">
                        <span class="sr-only">Open sidebar</span>
                        <!-- Heroicon name: outline/menu-alt-2 -->
                        <svg class="h-6 w-6" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor" aria-hidden="true">
                        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M4 6h16M4 12h16M4 18h7" />
                        </svg>
                    </button>
                    <div class="flex-1 flex justify-between items-center px-4 md:px-0">
                        <!-- search -->








                        <div class="w-full">

                            <div class="hidden w-full md:flex items-center">
                                <div class="w-full flex justify-end relative">
                                    <div class="w-full px-2 lg:px-6">
                                        <label for="search" class="sr-only">Search</label>
                                        <div class="relative">
                                        <div class="absolute inset-y-0 left-0 pl-3 flex items-center pointer-events-none">
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

                                        <div v-if="closeSearchMenu" class="absolute inset-y-0 right-0 pr-3 flex justify-center items-center">
                                            <button @click="canselSearch" class="cursor-pointer rounded-full focus:outline-none">
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
                                            class="block w-full px-10 py-2 rounded-full leading-5 bg-surface-grey focus:outline-none focus:bg-white sm:text-sm"
                                            placeholder="بحث عام عن (رقم المعاملة، رقم الايصال المالي، رقم الجواز، الاسم)"
                                            type="text"
                                        />
                                        </div>
                                    </div>

                                    <div id="searchMenu" v-if="searchMenu" class="w-full absolute mt-12 px-2 lg:px-12 z-40" >
                                        <div class="shadow-lg bg-white">
                                            <div v-if="finacial_recipt_number != 0" class="">
                                                <p class="bg-gray-100 py-2 px-2">النتائج المشابة لرقم الإيصال المالي</p>

                                                <div class="px-3 py-2">
                                                    <a
                                                        :href="
                                                        $router.resolve({
                                                            name: 'TransactionsFormEdit',
                                                            query: { transaction: resultonumber.id },
                                                        }).href
                                                        "
                                                        class="block py-1 hover:bg-gray-50"
                                                        :key="index"
                                                        v-for="(resultonumber, index) in finacial_recipt_number"
                                                    >
                                                        {{ resultonumber.finacial_recipt_number }}
                                                    </a>
                                                </div>
                                            </div>

                                            <div v-if="transaction_number != 0" class="">
                                                <p class="bg-gray-100 py-2 px-2">  النتائج المشابة لرقم المعاملة </p>

                                                <div class="px-3 py-2">
                                                <a
                                                    :href="
                                                    $router.resolve({
                                                        name: 'TransactionsFormEdit',
                                                        params: { transaction: transaction.id },
                                                    }).href
                                                    "
                                                    class="block py-1 hover:bg-gray-50"
                                                    :key="index"
                                                    v-for="(transaction, index) in transaction_number"
                                                >
                                                    {{ transaction.transaction_number }}
                                                </a>
                                                </div>
                                            </div>

                                            <div v-if="full_name != 0" class="">
                                                <p class="bg-gray-100 py-2 px-2">النتائج المشابة لاسم صاحب الجواز</p>

                                                <div class="px-3 py-2">
                                                <a
                                                    :href="
                                                    $router.resolve({
                                                        name: 'TransactionsFormEdit',
                                                        params: { transaction: name.id },
                                                    }).href
                                                    "
                                                    class="block py-1 hover:bg-gray-50"
                                                    :key="index"
                                                    v-for="(name, index) in full_name"
                                                >
                                                    {{ name.full_name }}
                                                </a>
                                                </div>
                                            </div>

                                            <div v-if="passport_number != 0" class="">
                                                <p class="bg-gray-100 py-2 px-2">النتائج المشابة لرقم الجواز</p>

                                                <div class="px-3 py-2">
                                                    <a
                                                        :href="
                                                        $router.resolve({
                                                            name: 'TransactionsFormEdit',
                                                            params: { transaction: passport.id },
                                                        }).href
                                                        "
                                                        class="block py-1 hover:bg-gray-50"
                                                        :key="index"
                                                        v-for="(passport, index) in passport_number"
                                                    >
                                                        {{ passport.passport_number }}
                                                    </a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>







                        <!-- Profile dropdown -->
                        <div class="relative md:mr-6 ml-4">
                            <div>
                                <button @click="userProcedure = !userProcedure" type="button" class="max-w-xs flex items-center text-sm rounded-full focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500" id="user-menu-button" aria-expanded="false" aria-haspopup="true">
                                    <span class="sr-only">Open user menu</span>
                                    <img class="h-8 w-8 rounded-full" src="https://images.unsplash.com/photo-1472099645785-5658abf4ff4e?ixlib=rb-1.2.1&ixqx=9iaFDkXMqu&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=facearea&facepad=2&w=256&h=256&q=80" alt="">
                                </button>
                            </div>

                            <!--
                            Dropdown menu, show/hide based on menu state.

                            Entering: "transition ease-out duration-100"
                                From: "transform opacity-0 scale-95"
                                To: "transform opacity-100 scale-100"
                            Leaving: "transition ease-in duration-75"
                                From: "transform opacity-100 scale-100"
                                To: "transform opacity-0 scale-95"
                            -->
                            <div v-if="userProcedure" class="origin-top-left absolute left-0 mt-2 w-48 rounded-md shadow-lg bg-white ring-1 ring-black ring-opacity-5 py-1 focus:outline-none" role="menu" aria-orientation="vertical" aria-labelledby="user-menu-button" tabindex="-1">
                                <!-- Active: "bg-gray-100", Not Active: "" -->
                                <a href="#" class="block py-2 px-4 text-sm text-gray-700" role="menuitem" tabindex="-1" id="user-menu-item-0">الملف الشخصي</a>

                                <a href="#" class="block py-2 px-4 text-sm text-gray-700" role="menuitem" tabindex="-1" id="user-menu-item-1">الإعدادات</a>

                                <a href="#" class="block py-2 px-4 text-sm text-gray-700" role="menuitem" tabindex="-1" id="user-menu-item-2">خروج</a>
                            </div>
                        </div>
                    </div>
                </div>
</template>

<script>
export default {
    data() {
        return {
            userProcedure: false,
            toggleMenu: false,

            searchMenu: false,
            closeSearchMenu: false,

            searchFor: "",

            resultOfSearch: "",

            finacial_recipt_number: {},

            transaction_number: {},

            full_name: {},
            passport_number: {},
        
        
        };
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
            var text = this.searchFor;

            this.$http.TransactionsService
            .ayoub(text)
                .then((res) => {
                    this.resultOfSearch = res.data;


                    this.finacial_recipt_number = this.resultOfSearch.finacial_recipt_number;
                    this.transaction_number = this.resultOfSearch.transaction_number;
                    this.full_name = this.resultOfSearch.full_name;
                    this.passport_number = this.resultOfSearch.passport_number;

                    if (
                        this.finacial_recipt_number == 0 &&
                        this.transaction_number == 0 &&
                        this.full_name == 0 &&
                        this.passport_number == 0
                        ) {
                            this.searchMenu = false;
                        }
                })
                .catch((err) => {
                    console.log(err);
                });
        },

        canselSearch() {
            this.searchFor = "";
            this.searchMenu = false;
            this.closeSearchMenu = false;
        },

        toggle_menu() {
            document.querySelector("#overlay").classList.toggle("hidden");
            document.body.classList.toggle("overflow-y-hidden");
            document.getElementById("menu").classList.toggle("hidden");
        },

        toggle_search() {
            document.querySelector("#overlaySearch").classList.toggle("hidden");
            document.body.classList.toggle("overflow-y-hidden");
            document.getElementById("searchMobile").classList.toggle("hidden");
        },
    },
}
</script>

<style>

</style>