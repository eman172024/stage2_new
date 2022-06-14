<template>
  <div class="">
    <img id="tesrr" :src="imageToCanvas" alt="" class="hidden" />

    <div class="flex justify-center text-center mt-12">
      <div class="flex flex-col">
        <div class="flex justify-between">
          <button
            type="button"
            @click="passToggleShowModal()"
            class="close absolute top-4 right-10 text-white  transform cursor-pointer bg-red-600 w-4 sm:w-10 h-4 sm:h-10 rounded-full flex justify-center items-center"
          >
            <svg
              class="stroke-current text-white"
              width="25"
              height="25"
              viewBox="0 0 25 25"
              fill="none"
              xmlns="http://www.w3.org/2000/svg"
            >
              <path
                d="M18.5417 6.12378L6.54175 18.1238"
                stroke-width="2"
                stroke-linecap="round"
                stroke-linejoin="round"
              ></path>
              <path
                d="M6.54175 6.12378L18.5417 18.1238"
                stroke-width="2"
                stroke-linecap="round"
                stroke-linejoin="round"
              ></path>
            </svg>
          </button>

          <div
            class="rounded w-10 h-10"
            :style="{ backgroundColor: color }"
          ></div>

          <Tool
            :event="() => setTool('eraser')"
            :iconClass="'fas fa-eraser fa-lg'"
            :class="{
              'cursor-pointer text-yellow-600':
                currentActiveMethod === 'eraser',
            }"
          />

          <Tool
            :event="() => setTool('freeDrawing')"
            :iconClass="'fas fa-pencil-alt fa-lg'"
            :class="{
              'cursor-pointer text-yellow-600':
                currentActiveMethod === 'freeDrawing',
            }"
          />

          <Tool
            :event="() => setTool('text')"
            :iconClass="'fas fa-font fa-lg'"
            :class="{
              'cursor-pointer text-yellow-600': currentActiveMethod === 'text',
            }"
          />
          <Tool
            :event="() => setTool('circle')"
            :iconClass="'far fa-circle fa-lg'"
            :class="{
              'cursor-pointer text-yellow-600':
                currentActiveMethod === 'circle',
            }"
          />

          <Tool
            :event="() => applyCropping()"
            :iconClass="'far fa-check-circle fa-lg'"
            v-show="croppedImage"
            :class="{
              'cursor-pointer text-yellow-600': currentActiveMethod === 'crop',
            }"
          />

          <div
            class="absolute top-4 left-10 text-white  transform cursor-pointer  rounded-full flex justify-center items-center"
          >
            <button
              @click="saveImage()"
              class="top-10 left-10 px-6 py-2 bg-blue-400 rounded-md text-white"
            >
              <!-- <Tool :event="() => saveImage()" :iconClass="'fas fa-save fa-lg'"  /> -->
              حفظ
            </button>
          </div>
        </div>
        <Editor
          :canvasWidth="canvasWidth"
          :canvasHeight="canvasHeight"
          ref="editor"
        />
      </div>
      <div class="colors flex flex-col m-8 items-center justify-start pt-8">
        <ColorPicker :color="'#000000'" :event="changeColor" />
        <ColorPicker :color="'#0000FF'" :event="changeColor" />
        <ColorPicker :color="'#FFFF00'" :event="changeColor" />
        <ColorPicker :color="'#FF0000'" :event="changeColor" />
        <ColorPicker :color="'#808080'" :event="changeColor" />
        <ColorPicker :color="'#FFFFFF'" :event="changeColor" />
      </div>
    </div>
  </div>
</template>

<script>
import Editor from "vue-image-markup";
import Tool from "./Tool/Tool";
import ColorPicker from "./ColorPicker/ColorPicker";
import "@fortawesome/fontawesome-free/css/all.css";
import "@fortawesome/fontawesome-free/js/all.js";
export default {
  components: {
    ColorPicker,
    Tool,
    Editor,
  },
  data() {
    return {
      currentActiveMethod: null,
      params: {},
      color: "black",
      imageUrl: "",
      croppedImage: false,

      imagesrc: "",
    };
  },
  props: {
    canvasWidth: {
      default: 1000,
    },
    event: {
      type: Function,
    },

    iconClass: {
      type: String,
    },
    canvasHeight: {
      default: 1440,
    },
    imageToCanvas: String,
  },

  mounted() {
    this.imageUrl = document.getElementById("tesrr").src;
    if (this.imageUrl) {
      this.$refs.editor.setBackgroundImage(this.imageUrl);
      this.croppedImage = this.$refs.editor.croppedImage;
    }
    this.$watch(
      () => {
        return this.$refs.editor.croppedImage;
      },
      (val) => {
        this.croppedImage = val;
      }
    );
  },
  methods: {
    passToggleShowModal() {
      this.$emit("clicked-show-detail");
    },
    applyCropping() {
      this.currentActiveMethod = "";
      this.$refs.editor.applyCropping();
    },
    changeColor(colorHex) {
      this.color = colorHex;
      this.$refs.editor.changeColor(colorHex);
    },
    saveImage() {
      let image = this.$refs.editor.saveImage();

      this.$emit("passMarginalizedDocumentsToparent", image);

      this.$emit("clicked-show-detail");

      // this.saveImageAsFile(image);
    },
    // saveImageAsFile(base64) {
    //   let link = document.createElement("a");
    //   link.setAttribute("href", base64);
    //   link.setAttribute("download", "image-markup");
    //   link.click();
    // },
    setTool(type, params) {
      this.currentActiveMethod = type;
      this.$refs.editor.set(type, params);
    },
  },
};
</script>

<style>
.custom-editor {
  margin-top: 20px;
}
canvas {
  border: 1px solid #00000021;
}
</style>
