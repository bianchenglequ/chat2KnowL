<template>
    <link rel="resource" type="application/l10n" :href="pdfProperties">
    <vue-pdf-app v-if="props.pdfFilePath" :pdf="props.pdfFilePath" :config="pdfConfig"/>
</template>
<script lang="ts" setup>
import { ref, defineProps } from 'vue'
import VuePdfApp from 'vue3-pdf-app'
import 'vue3-pdf-app/dist/icons/main.css'

//定义组件属性
const props = defineProps({
  pdfFilePath: {
    type: String,
    default: ''
  }
})

//配置PDF查看器属性文件的URL
const pdfProperties = new URL("viewer.properties", import.meta.url).href
//初始配置
const pdfConfig = ref({
  sidebar: {
    viewThumbnail: true,
    viewOutline: true,
    viewAttachments: true,
  },
  secondaryToolbar: {
    secondaryPresentationMode: true,
    secondaryOpenFile: true,
    secondaryPrint: true,
    secondaryDownload: true,
    secondaryViewBookmark: true,
    firstPage: true,
    lastPage: true,
    pageRotateCw: true,
    pageRotateCcw: true,
    cursorSelectTool: true,
    cursorHandTool: true,
    scrollVertical: true,
    scrollHorizontal: true,
    scrollWrapped: true,
    spreadNone: true,
    spreadOdd: true,
    spreadEven: true,
    documentProperties: true,
  },
  toolbar: {
    toolbarViewerLeft: {
      findbar: true,
      previous: true,
      next: true,
      pageNumber: true,
    },
    toolbarViewerRight: {
      presentationMode: false,
      openFile: false,
      print: false,
      download: false,
      viewBookmark: false,
    },
    toolbarViewerMiddle: {
      zoomOut: false,
      zoomIn: false,
      scaleSelectContainer: true,
    },
    secondaryToolbar:false
  },
  errorWrapper: false
})
</script>