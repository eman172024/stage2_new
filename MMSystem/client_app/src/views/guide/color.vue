<template>
    <div class="">
        
        <div class="h-screen bg-gray-100 overflow-hidden flex">
        <asideComponent></asideComponent>
        <div class="flex-1 bg-gray-200 w-0 overflow-y-auto">
            <div class="max-w-screen-2xl mx-auto flex flex-col md:px-8">
            <navComponent></navComponent>
                <main class="flex-1 relative focus:outline-none py-6">
                    <h3 class="text-xl font-semibold text-gray-900">
                        دليل الالوان
                    </h3>

                    <section class="grid grid-cols-2 gap-8">

                        <div class="border border-gray-400 rounded mt-8 p-4">
                            <h4 class="text-lg font-semibold text-gray-900 underline">
                                دليل الالوان في البريد الصادر
                            </h4>
                            
                            <div class="flex items-center mt-4">
                                <div class="w-8 h-8 border-2 border-black bg-yellow-300"></div>
                                <p class="mr-2">
                                    لم يتم إرسال البريد بعد.
                                </p>
                            </div>

                            <div class="flex items-center mt-4">
                                <div class="w-8 h-8 border-2 border-black bg-red-700"></div>
                                <p class="mr-2">
                                    تم ارسال البريد وفي انتظار رد احد الادارات.
                                </p>
                            </div>

                            <div class="flex items-center mt-4">
                                <div class="w-8 h-8 border-2 border-black bg-pink-300"></div>
                                <p class="mr-2">
                                    تم تأكيد القراءة من الادارة.
                                </p>
                            </div>

                            <div class="flex items-center mt-4">
                                <div class="w-8 h-8 border-2 border-black bg-blue-800"></div>
                                <p class="mr-2">
                                    يوجد رد جديد من الادارة.
                                </p>
                            </div>

                            <div class="flex items-center mt-4">
                                <div class="w-8 h-8 border-2 border-black bg-yellow-800"></div>
                                <p class="mr-2">
                                    قمت بارسال رد جديد.
                                </p>
                            </div>

                            <div class="flex items-center mt-4">
                                <div class="w-8 h-8 border-2 border-black bg-green-800"></div>
                                <p class="mr-2">
                                    تم طباعة مستندات البريد.
                                </p>
                            </div>
                        </div>

                        <div class="border border-gray-400 rounded mt-8 p-4">
                            <h4 class="text-lg font-semibold text-gray-900 underline">
                                دليل الالوان في البريد الوارد
                            </h4>

                            <div class="flex items-center mt-4">
                                <div class="w-8 h-8 border-2 border-black bg-red-700"></div>
                                <p class="mr-2">
                                    لم يتم تأكيد قراءة هذا البريد بعد.
                                </p>
                            </div>

                            <div class="flex items-center mt-4">
                                <div class="w-8 h-8 border-2 border-black bg-pink-300"></div>
                                <p class="mr-2">
                                    تم تأكيد قراءة البريد.
                                </p>
                            </div>

                            <div class="flex items-center mt-4">
                                <div class="w-8 h-8 border-2 border-black bg-blue-800"></div>
                                <p class="mr-2">
                                    تم إراسال رد من قبلك.
                                </p>
                            </div>

                            <div class="flex items-center mt-4">
                                <div class="w-8 h-8 border-2 border-black bg-yellow-800"></div>
                                <p class="mr-2">
                                    يوجد رد جديد من الادارة.
                                </p>
                            </div>

                            <div class="flex items-center mt-4">
                                <div class="w-8 h-8 border-2 border-black bg-green-800"></div>
                                <p class="mr-2">
                                    تم طباعة مستندات البريد.
                                </p>
                            </div>
                        </div>
                        
                    </section>
                
                </main>
            </div>
        </div>
        </div>

    </div>
</template>

<script>
import asideComponent from "@/components/asideComponent.vue";
import navComponent from "@/components/navComponent.vue";

export default {
  created() {},

  components: {
    asideComponent,
    navComponent,
  },

    data() {
        return {

        }
    }
}
</script>

<style>

</style>