<template>
  <div class="home">
    <div class="main">
      <el-row>
        <img alt="Vue logo" class="logo" src="../assets/logo.png">
      </el-row>
      <el-row>欢迎来到ChatKnowL!</el-row>
      <el-row>
        提供Al分析、阅读、问答工具，助你快速了解文档内容。
      </el-row>
      <router-link to="/chat">
        <el-button class="chat" type="primary">点击这里开启</el-button>
      </router-link>
    </div>
  </div>
</template>

<style scoped>
/*设置页面背景、页面的高度、间距设置为0*/
.home {
  background: #f7f7f7;
  height: 100%;
}

/*设置Home为页面上下居中*/
.home .main {
  height: 85%;
  /* 设置为 Flexbox */
  display: flex;
  flex-direction: column;
  /* 水平居中对齐 */
  justify-content: center;
  /* 垂直居中对齐 */
  align-items: center;
  line-height: 45px;
  font-family: "微软雅黑", "宋体";
  font-weight: bold;
}

/* 设置logo样式*/
.logo {
  border-radius: 5px;
  width: 60px;
  margin-bottom: 5px;
}

/* 设置按钮样式 */
.chat.el-button {
  padding: 20px 15px;
  margin-top: 20px;
}</style>
