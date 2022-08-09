<template>
  <div class="  mx-auto  max-w-6xl mt-6 rounded-md bg-gray-100 p-2 ">
    <h1 class="font-extrabold text-4xl text-center">
      وارد جديد من الإدارات والمكاتب
    </h1>

    <div
      class="flex justify-between items-center  border-green-300 border rounded-md px-4 mt-4"
    >
      <div class="">
        <label for="year" class="font-medium ">السنة</label>

        <input
          type="number"
          id="year"
          value="2021"
          class="focus:outline-none  w-20 focus:border-green-300 border rounded-md px-2 py-1"
        />
      </div>

      <div class=" p-2 border-b">
        <span class="font-bold ">نوع البريد</span>

        <div class=" flex items-center mt-4 justify-between">
          <div class="flex items-center ml-4">
            <input
              id="internal"
              type="radio"
              name="mail_type"
              class=" h-4 w-4  border-gray-300"
              value="مفعل"
            />

            <label for="internal" class="mr-2 text-sm font-medium ">
              داخلي
            </label>
          </div>

          <div class="flex items-center ml-4">
            <input
              id="external_export"
              type="radio"
              name="mail_type"
              class=" h-4 w-4 "
            />

            <label for="external_export" class="mr-2 text-sm font-medium ">
              صادر خارجي
            </label>
          </div>

          <div class="flex items-center ">
            <input
              id="external_incoming"
              type="radio"
              name="mail_type"
              class=" h-4 w-4 "
            />

            <label for="external_incoming" class="mr-2 text-sm font-medium ">
              وارد خارجي
            </label>
          </div>
        </div>
      </div>
    </div>

    <div
      class="mt-2 p-2 border-green-300 border rounded-md grid grid-cols-2  gap-6"
    >
      <div class="flex items-center ">
        <input id="to_day" type="checkbox" class=" h-4 w-4 " />

        <label for="to_day" class="mr-2 text-sm font-medium ">
          اليوم
        </label>
      </div>

      <div class="flex items-center mt-2">
        <div class="ml-2 w-32 flex items-center ">
          <input id="depends_on_mangment" type="checkbox" class=" h-4 w-4 " />

          <label
            for="depends_on_mangment"
            class="mr-2  w-20 text-sm font-medium "
          >
            حسب الإدارة
          </label>
        </div>

        <select
          class="shadow-sm  w-full mr-2    focus:outline-none  rounded-md px-2 py-1"
          name="mangment_type"
        >
          <option value="0">التوثيق</option>
        </select>
      </div>

      <div class="flex items-center w-full ">
        <div class="flex items-center ">
          <input id="word-from-subject" type="checkbox" class=" h-4 w-4 " />

          <label for="word-from-subject" class="mr-2 w-40 text-sm font-medium ">
            كلمة من ملخص الموضوع
          </label>
        </div>

        <input
          type="text"
          class="shadow-sm  w-full mr-2    focus:outline-none  rounded-md px-2 py-1"
        />
      </div>

      <div class="flex items-center ">
        <div class="ml-2 flex items-center ">
          <input id="depends_on_number" type="checkbox" class=" h-4 w-4 " />

          <label for="depends_on_number" class="mr-2 w-20 text-sm font-medium ">
            حسب الرقم
          </label>
        </div>

        <input
          type="number"
          class="shadow-sm  w-full mr-2    focus:outline-none  rounded-md px-2 py-1"
        />
      </div>

      <div class="flex items-center w-full">
        <div class="flex items-center ">
          <input id="depens_on_achievement" type="checkbox" class=" h-4 w-4 " />

          <label
            for="depens_on_achievement"
            class="mr-2 w-40 text-sm font-medium "
          >
            حسب الإنجاز
          </label>
        </div>

        <div
          class=" flex items-center  justify-around border border-green-300 p-1 rounded-md w-full"
        >
          <div class="flex items-center ml-4">
            <input
              id="done"
              type="radio"
              name="achievement"
              class=" h-4 w-4  border-gray-300"
              value="مفعل"
            />

            <label for="done" class="mr-2 text-sm font-medium ">
              منجز
            </label>
          </div>

          <div class="flex items-center ml-4">
            <input
              id="not_done"
              type="radio"
              name="achievement"
              class=" h-4 w-4 "
            />

            <label for="not_done" class="mr-2  text-sm font-medium ">
              غير منجز
            </label>
          </div>
        </div>
      </div>

      <div class="flex items-center ">
        <div class="ml-2 flex items-center ">
          <input id="state_of_mail" type="checkbox" class=" h-4 w-4 " />

          <label for="state_of_mail" class="mr-2 w-20 text-sm font-medium ">
            حالة الرسالة
          </label>
        </div>

        <div
          class=" flex items-center  justify-around border border-green-300 py-1 px-2 rounded-md w-full"
        >
          <div class="flex items-center ml-4">
            <input
              id="readed"
              type="radio"
              name="state_of_mail"
              class=" h-4 w-4  border-gray-300"
              value="مفعل"
            />

            <label for="readed" class="mr-2 text-sm font-medium ">
              قرأت
            </label>
          </div>

          <div class="flex items-center ml-4">
            <input
              id="not_readed"
              type="radio"
              name="state_of_mail"
              class=" h-4 w-4 "
            />

            <label for="not_readed" class="mr-2 text-sm font-medium ">
              لم تقرأ
            </label>
          </div>
        </div>
      </div>

      <div class="flex items-center w-full col-span-2">
        <div class="flex items-center ">
          <input id="date_of_withdrawal" type="checkbox" class=" h-4 w-4 " />

          <label
            for="date_of_withdrawal"
            class="mr-2 w-40 text-sm font-medium "
          >
            حسب تاريخ السحب
          </label>
        </div>

        <div
          class=" flex items-center  justify-around border border-green-300 p-1 rounded-md w-full"
        >
          <div class="flex items-center ml-4">
            <label for="done" class=" text-sm font-medium ">
              من
            </label>

            <input
              type="date"
              name="achievement"
              class="mr-2"
              value="21/09/2021"
            />
          </div>

          <div class="flex items-center ml-4">
            <input
              id="not_done"
              type="radio"
              name="achievement"
              class=" h-4 w-4 "
            />

            <label for="not_done" class="mr-2  text-sm font-medium ">
              غير منجز
            </label>
          </div>
        </div>
      </div>

      <div class="flex items-center ">
        <div class="ml-2 flex items-center ">
          <input id="state_of_mail" type="checkbox" class=" h-4 w-4 " />

          <label for="state_of_mail" class="mr-2 w-20 text-sm font-medium ">
            حالة الرسالة
          </label>
        </div>

        <div
          class=" flex items-center  justify-around border border-green-300 py-1 px-2 rounded-md w-full"
        >
          <div class="flex items-center ml-4">
            <input
              id="readed"
              type="radio"
              name="state_of_mail"
              class=" h-4 w-4  border-gray-300"
              value="مفعل"
            />

            <label for="readed" class="mr-2 text-sm font-medium ">
              قرأت
            </label>
          </div>

          <div class="flex items-center ml-4">
            <input
              id="not_readed"
              type="radio"
              name="state_of_mail"
              class=" h-4 w-4 "
            />

            <label for="not_readed" class="mr-2 text-sm font-medium ">
              لم تقرأ
            </label>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {};
</script>

<style></style>
