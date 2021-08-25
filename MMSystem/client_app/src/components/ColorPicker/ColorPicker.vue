<template>
  <div class="rounded-full w-10 h-10 m-2 cursor-pointer border border-black" :style="{ backgroundColor: color ? color : '' }" @click="event(color)"></div>
</template>
<script>
export default {
  name: "colorPicker",
  props: ["color","event"],
};
</script>

<style scoped >

</style>
