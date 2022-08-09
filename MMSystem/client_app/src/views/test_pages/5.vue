<template>
  <div class="bg-gray-200" dir="rtl">
    <form class="max-w-3xl mx-auto bg-gray-200 pt-12">
      <div
        class="flex px-8 py-6 border-b rounded-t-md items-center bg-gray-100"
      >
        <label class="flex items-center">
          <input
            class="form-radio bg-white border border-green-700 checked:bg-green-700"
            type="radio"
            name="propertyType"
            value="عامة"
          />
          <span class="text-black font-bold mr-2">الإدارة العامة</span>
        </label>
        <label class="flex items-center mx-32">
          <input
            class="form-radio bg-white border border-green-700"
            type="radio"
            name="propertyType"
            value="فرعية"
          />
          <span class="text-black font-bold mr-2">الإدارة الفرعية</span>
        </label>
        <label class=" flex items-center">
          <input
            class="form-radio bg-white border border-green-700 checked:bg-blue-600 checked:border-transparent"
            type="radio"
            name="propertyType"
            value="قسم"
          />
          <span class="text-black font-bold mr-2">القسم</span>
        </label>
      </div>
      <div class="items-center bg-gray-100 w-full rounded-b-md">
        <div class="h-60 hidden">
          <div class="flex px-8 py-16 items-center w-2/3">
            <lable class="font-medium">الإدارة العامة</lable>
            <input
              class="w-72 py-1 border border-green-700 rounded-md focus:shadow-md shadow-sm focus:outline-none mr-3"
              type="text"
            />
          </div>
        </div>
        <div class="h-60 hidden">
          <div class=" flex px-8 py-8 items-center">
            <label class="font-medium">الإدارة العامة</label>
            <select
              class="w-72 py-1 items-center bg-white text-black border border-green-700 rounded-md shadow-sm focus:outline-none mr-5"
            >
              <option></option>
              <option>test</option>
              <option>test</option>
              <option>test</option>
            </select>
          </div>
          <div class="px-8 py-8 flex items-center w-2/3">
            <label class="font-medium">الإدارة الفرعية</label>
            <input
              class="w-72 py-1 border border-green-700 rounded-md focus:shadow-md shadow-sm focus:outline-none mr-4"
              type="text"
            />
          </div>
        </div>
        <div class="">
          <div class=" flex px-8 py-6 items-center">
            <label class="font-medium">الإدارة العامة</label>
            <select
              class="w-72 py-1 items-center bg-white text-black border border-green-700 rounded-md shadow-sm focus:outline-none mr-3"
            >
              <option></option>
              <option>test</option>
              <option>test</option>
              <option>test</option>
              <option>test</option>
            </select>
          </div>
          <div class=" flex px-8 py-6 items-center">
            <label class="font-medium">الإدارة الفرعية</label>
            <select
              class="w-72 py-1 items-center bg-white text-black border border-green-700 rounded-md shadow-sm focus:outline-none mr-2"
            >
              <option></option>
              <option>test</option>
              <option>test</option>
              <option>test</option>
              <option>test</option>
            </select>
          </div>
          <div class="flex px-8 py-6 items-center">
            <span class="font-medium">القسم</span>
            <input
              class="w-72 py-1 border border-green-700 rounded-md focus:shadow-md shadow-sm focus:outline-none mr-14"
              type="text"
            />
          </div>
        </div>
        <div class="flex py-5 justify-center border-b rounded-b-md">
          <button
            class="px-40 py-1 font-medium itemes-center text-white shadow-sm bg-green-700 hover:bg-green-800 hover:shadow-md rounded-md focus:outline-none"
          >
            حفظ
          </button>
        </div>
      </div>
    </form>

    <form class="max-w-3xl mx-auto bg-gray-200 pt-12">
      <div
        class="flex px-8 py-6 border-b rounded-t-md items-center bg-gray-100"
      >
        <label class="flex items-center">
          <input
            class="form-radio bg-white border border-green-700 checked:bg-green-700"
            type="radio"
            name="propertyType"
            value="عامة"
          />
          <span class="text-black font-bold mr-2">القطاع</span>
        </label>
        <label class="flex items-center mr-32">
          <input
            class="form-radio bg-white border border-green-700"
            type="radio"
            name="propertyType"
            value="فرعية"
          />
          <span class="text-black font-bold mr-2">الجهة</span>
        </label>
      </div>
      <div class="items-center bg-gray-100 w-full rounded-b-md">
        <div class="h-60 hidden">
          <div class="px-8 py-16 flex items-center">
            <label class="font-medium">القطاع</label>
            <input
              class="w-72 py-1 border border-green-700 rounded-md focus:shadow-md shadow-sm focus:outline-none mr-3"
              type="text"
            />
          </div>
        </div>
        <div class="h-60">
          <div class="flex px-8 py-8 items-center">
            <label class="font-medium">القطاع</label>
            <select
              class="w-72 py-1 items-center bg-white text-black border border-green-700 rounded-md shadow-sm focus:outline-none mr-12"
            >
              <option></option>
              <option>test</option>
              <option>test</option>
              <option>test</option>
            </select>
          </div>
          <div class="px-8 py-8 flex items-center">
            <label class="font-medium">الجهة</label>
            <input
              class="w-72 py-1 border border-green-700 rounded-md focus:shadow-md shadow-sm focus:outline-none mr-14"
              type="text"
            />
          </div>
        </div>
        <div class="flex py-5 justify-center border-b rounded-b-md">
          <button
            class="px-40 py-1 font-medium itemes-center text-white shadow-sm bg-green-700 hover:bg-green-800 hover:shadow-md rounded-md focus:outline-none"
          >
            حفظ
          </button>
        </div>
      </div>
    </form>
  </div>
</template>

<script>
export default {};
</script>

<style></style>
