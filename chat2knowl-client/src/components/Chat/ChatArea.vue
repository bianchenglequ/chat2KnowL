<template>
  <el-container class="chat-area">
    <el-aside width="300px" class="chat-file-area">
      <ChatFileArea :fileList="fileList"/>
    </el-aside>
    <el-aside class="chat-file-preview-area" :style="{ width: `${draggable.getAdjustedWidth()}px` }">
      <el-row style="height: 100%;">
        <el-col style="flex: 1;border: 1px solid #ccc;">
          <PDFViewer :pdfFilePath="pdfFilePath"/>
        </el-col>
        <el-col style="flex: 0 0 30px;cursor: e-resize;" @mousedown="draggable.startDrag">
          <el-icon style="top:50%;font-size: 20px;font-weight: bolder;">
            <Switch />
          </el-icon>
        </el-col>
      </el-row>
    </el-aside>
    <el-main class="chat-dialogue-area">
    </el-main>
  </el-container>
</template>
<script lang="ts" setup>
import {ref, onMounted} from 'vue'
import ChatFileArea from '@/components/Chat/ChatFileArea.vue'
import draggable from "@/utils/draggable"
import PDFViewer from '@/components/PDFViewer/PDFViewer.vue'

// 定义一个响应式变量fileList，用于存储文档列表
const fileList = ref()
//用于存储PDF文件路径
const pdfFilePath = ref('')

// 在组件挂载后执行初始化操作
onMounted(()=>{
   //获取聊天信息
  getChat() 
})

// 获取聊天信息
const getChat = () => {
  // TODO: 从后端获取聊天记录的实际逻辑
  // 目前仅为模拟数据，实际开发中需替换为真正的数据获取逻辑
  fileList.value = [{ name: ".Net面试题", editMode: false }, { name: "C#基础知识", editMode: false }]
  pdfFilePath.value = 'chat2KnowL.pdf' 
}
</script>
<style scoped>
.chat-area{
  margin: 0;
  padding: 0;
  background: #fff;

  .chat-file-area{
    border: 1px solid #ccc;
    padding: 10px 5px 0 5px;
  }

  .chat-file-preview-area{
    margin: 0 0px 0 10px;
  }

  .chat-dialogue-area{
    border: 1px solid #ccc;
    padding-right: 0px;
  }
}
</style>