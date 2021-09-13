<template>
     <div class="min-h-full mx-auto max-w-4xl p-2 flex flex-col justify-center items-center">

        <div class="w-full">

            <h1 class="font-extrabold text-xl text-center">المستخدمين</h1>

            <div class="bg-gray-100 grid grid-cols-2 p-4  gap-3  text-sm mt-4">


                <div>

                    <label for="network_user_name" class="font-medium text-gray-700">
                        اسم المستخدم على الشبكة
                    </label>

                    <input id="network_user_name" type="text"
                        class=" w-full mt-1 focus:outline-none focus:border-green-300 border  rounded-md px-2 py-1"
                        placeholder="ادخل اسم المستخدم على الشبكة">

                </div>


                <div>

                    <label for="national_id" class="font-medium text-gray-700">
                        الرقم الوطني
                    </label>

                    <input id="national_id" type="text" class=" w-full mt-1 focus:outline-none focus:border-green-300 border rounded-md px-2 py-1"
                        placeholder="ادخل الرقم الوطني">

                </div>


                <div>
                    <label for="user_name" class="font-medium text-gray-700">
                        اسم المستخدم
                    </label>

                    <input id="user_name" type="text" class=" w-full mt-1 focus:outline-none focus:border-green-300 border rounded-md px-2 py-1"
                        placeholder="ادخل اسم المستخدم">

                </div>


                <div>
                    <label for="password" class="font-medium text-gray-700">
                        كلمة المرور
                    </label>

                    <input id="password" type="text" class=" w-full mt-1 focus:outline-none focus:border-green-300 border rounded-md px-2 py-1"
                        placeholder="ادخل كلمة المرور">

                </div>



                <div>
                    <label for="management" class="font-medium text-gray-700">
                        الإدارة
                    </label>

                    <select class="shadow-sm  w-full h-7 mt-2  focus:outline-none  rounded-md px-2 py-1"
                        name="mangment_type">
                        <option value="0">التوثيق</option>

                    </select>

                </div>


                <div>


                    <span class="font-medium text-gray-700">حالة الحساب</span>

                    <div class=" flex items-center mt-2 justify-around">


                        <div class="flex items-center ">

                            <input id="active" type="radio" name="account_state" class=" h-4 w-4  border-gray-300"
                                value="مفعل">

                            <label for="active" class="mr-3 text-sm font-medium text-gray-700">
                                مفعل
                            </label>

                        </div>

                        <div class="flex items-center ">

                            <input id="deactive" type="radio" name="account_state" class=" h-4 w-4 "
                                value="غير مفعل">

                            <label for="deactive" class="mr-3 text-sm font-medium text-gray-700">
                                غير مفعل
                            </label>

                        </div>

                    </div>

                </div>



                <div>

                    <label for="management" class="font-medium text-gray-700">
                        الصلاحيات
                    </label>

                    <select class="shadow-sm  w-full  mt-2  focus:outline-none rounded-md px-2 py-1"
                        name="mangment_type">
                        <option value="0">طباعة التقارير</option>

                    </select>

                </div>



                <div>
                    <span class="font-medium text-gray-700">الصلاحيات المتاحة</span>

                    <div class="mt-2 bg-white shadow-sm rounded-md p-2 ">


                        <span class="border border-green-300 p-1 rounded-md">طباعة التقارير</span>
                        <span class="border border-green-300 p-1 rounded-md">طباعة التقارير</span>


                    </div>

                </div>

                <button
                    class=" mx-auto w-96 bg-green-700 text-green-50 rounded-md py-2 border border-green-300 hover:bg-green-800  focus:outline-none flex items-center  justify-center col-span-2 mt-4">

                    <svg class=" h-5 w-5  ml-1 text-white block" fill="none" stroke="currentColor" viewBox="0 0 24 24"
                        xmlns="http://www.w3.org/2000/svg">
                        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                            d="M9 13h6m-3-3v6m-9 1V7a2 2 0 012-2h6l2 2h6a2 2 0 012 2v8a2 2 0 01-2 2H5a2 2 0 01-2-2z">
                        </path>
                    </svg>


                    <span class="text-sm font-bold block">حفظ</span>

                </button>

            </div>

        </div>
    </div>
</template>

<script>
export default {

}
</script>

<style>

</style>