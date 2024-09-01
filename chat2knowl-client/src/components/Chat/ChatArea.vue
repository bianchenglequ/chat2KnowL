<template>
  <el-container class="chat-area">
    <el-aside width="300px" class="chat-file-area">
    </el-aside>
    <el-aside class="chat-file-preview-area">
    </el-aside>
    <el-main class="chat-dialogue-area">
    </el-main>
  </el-container>
</template>
<script lang="ts" setup>
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