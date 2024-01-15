<template>
  <div class="chat">
    <el-container>
      <el-aside width="200px">
        <div class="header-content">
          <div>
            <img alt="Vue logo" class="logo" src="@/assets/logo.png">
          </div>
          <div class="prod-name">ChatKnowL</div>
          <div class="prod-des">AI智能回答文档</div>
        </div>
        <div class="session">
        </div>
        <div class="sidebar-tool">
          <a href="https://github.com/bianchenglequ/chat2KnowL" target="_blank">
            <el-button type="primary"><i class="iconfont icon-github"></i>&nbsp;&nbsp;Gtihub</el-button>
          </a>
        </div>
        <div class="sidebar-tool">
          <el-popover placement="right" :width="230" trigger="focus">
            <template #reference>
              <el-button type="primary"><el-avatar :size="20" :src="mpPhotoPath" />&nbsp;&nbsp;编程乐趣</el-button>
            </template>
            <div class="popover">
              <el-row justify="center" class="title">
                欢迎关注公众号
              </el-row>
              <el-row justify="center" class="tip">
                扫码二维码 </el-row>
              <el-row justify="center">
                <img style="width:110px;height: 110px;" :src="mpQrCodePath">
              </el-row>
            </div>
          </el-popover>
        </div>
        <div class="sidebar-tool" style="padding-bottom: 30px;">
          <el-popover placement="right" :width="230" trigger="focus">
            <template #reference>
              <el-button type="primary"><el-icon>
                  <ChatDotRound />
                </el-icon>&nbsp;&nbsp;联系作者</el-button>
            </template>
            <div class="popover">
              <el-row justify="center" class="title">
                欢迎加我好友
              </el-row>
              <el-row justify="center" class="tip">
                扫码二维码 </el-row>
              <el-row justify="center">
                <img style="width:110px;height: 110px;" :src="weixinPath">
              </el-row>
            </div>
          </el-popover>
        </div>
      </el-aside>
      <el-container>
        <el-header>
          <el-row justify="end" class="menu">
            <router-link to="/">
              <el-link type="primary">
                <el-icon class="el-icon--right">
                  <HomeFilled />
                </el-icon>首页
              </el-link>
            </router-link>
          </el-row>
        </el-header>
        <el-main>主要区域</el-main>
      </el-container>
    </el-container>
  </div>
</template>

<script>
import mpPhotoPath from "@/assets/service/mp-photo.jpg"
import mpQrCodePath from "@/assets/service/mp-qrcode.jpg"
import weixinPath from "@/assets/service/weixin.png"

export default {
  data() {
    return {
      mpPhotoPath: mpPhotoPath,
      mpQrCodePath: mpQrCodePath,
      weixinPath: weixinPath
    }
  }
}
</script>

<style scoped>
.chat {
  height: 100%;
}

.chat .el-container {
  height: 100%;
}

/** 侧边栏 */
.chat .el-aside {
  background: #162e43;
  display: flex;
  flex-direction: column;

  /** 头部 */
  .header-content {
    color: #fff;
    text-align: center;
    padding-top: 40px;

    /** 设置logo样式*/
    .logo {
      border-radius: 5px;
      width: 50px;
    }

    .prod-name {
      font-weight: bolder;
      padding-top: 10px;
    }

    .prod-des {
      font-size: 12px;
    }
  }

  /** 会话 */
  .session {
    flex-grow: 1;
  }

  /** 侧边栏工具 */
  .sidebar-tool {
    background: #264259;
    padding: 15px 10px 10px 10px;

    .el-button {
      width: 80%;
      height: 40px;
    }
  }
}

.el-popover .popover {
  background: #409EFF;
  color: #fff;
  padding: 30px 30px 50px 30px;

  .title {
    font-size: 18px;
    line-height: 20px;
    font-weight: bolder;
  }

  .tip {
    font-size: 14px;
    line-height: 50px;
  }
}

.chat .el-header {
  border-bottom: 1px solid #ddd;

  .menu {
    padding-top: 20px;
    font-size: 18px;
  }
}
</style>