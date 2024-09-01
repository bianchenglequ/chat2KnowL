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
        <el-row justify="center" style="margin-top:30px;">
          <el-button type="primary" @click="newSession"><el-icon>
              <CirclePlus />
            </el-icon>&nbsp;&nbsp;新建会话</el-button>
        </el-row>
        <div class="session">
          <el-menu background-color="#162e43" active-text-color="#fff" :default-active="activeIndex" text-color="#fff"
          @select="handleSessionSelect">
            <el-menu-item v-for="(item, index) in menuList" :index="index + ''" :key="index"
              :class="{ 'menu-item': true, 'menu-active': index + '' == activeIndex , 'menu-edit-mode': item.editMode}">
              <div style="overflow: hidden;width:98%;text-align: left;">
                <el-icon v-if="!item.editMode">
                  <ChatDotRound />
                </el-icon>
                <span v-if="!item.editMode">{{ item.name }}</span>
                <el-input v-if="item.editMode" ref="refSessionInput" v-model="item.name"></el-input>
              </div>
              <span v-if="!item.editMode" class="buttons buttons-normal">
                <el-icon @click="editSession(item)">
                  <EditPen />
                </el-icon>
                <el-popconfirm title="删除后无法恢复，是否继续删除？" confirm-button-text="删除" cancel-button-text="取消" placement="top"
                  :width="250" @confirm="deleteSession(index)">
                  <template #reference>
                    <el-icon>
                      <Delete />
                    </el-icon>
                  </template>
                </el-popconfirm>
              </span>
              <span v-if="item.editMode" class="buttons">
                <el-icon @click="item.editMode = false">
                  <Select />
                </el-icon>
                <el-icon @click="cancelEditSession(item)">
                  <CloseBold />
                </el-icon>
              </span>
            </el-menu-item>
          </el-menu>
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
        <el-main style="background-color: rgb(249, 251, 252);padding: 10px;">
          <ChatArea/>
        </el-main>
      </el-container>
    </el-container>
  </div>
</template>

<script lang="ts" setup>
import { ref, nextTick } from 'vue'
import ChatArea from '@/components/Chat/ChatArea.vue'
const refSessionInput = ref()

//图片
const mpPhotoPath = require("@/assets/service/mp-photo.jpg")
const mpQrCodePath = require("@/assets/service/mp-qrcode.jpg")
const weixinPath = require("@/assets/service/weixin.png")

//菜单
const activeIndex = ref('0')
const menuList = ref([{ name: "默认会话", editMode: false }])
//新会话
const newSession = () => {
  menuList.value.push({ name: "新会话", editMode: false })
}
//移除会话
const deleteSession = (index: number) => {
  menuList.value.splice(index, 1)
}
//编辑会话
const editSession = (row: any) => {
  menuList.value.map((item) => {
    item.editMode = false
  })
  row.editMode = true
  row.oldName = row.name
  nextTick(() => {
    refSessionInput.value[0].focus()
  })
}
//取消编辑会话
const cancelEditSession = (row:any)=>{
  row.name = row.oldName
  row.editMode = false
}
//选择会话
const handleSessionSelect = (key: string) => {
  activeIndex.value = key
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
  background: #264259;
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
    background: #162e43;
    margin-top: 10px;
    border-radius: 15px;
    padding-top: 20px;
    overflow-y: auto;

    .menu-active {
      background: #264259;
    }

    .menu-item {
      white-space: nowrap;
      overflow: hidden;
      word-break: break-all;

      .buttons {
        right:0;
        background: inherit;
      }

      .buttons-normal {
        position: absolute;
        z-index: 999;
        display: none;
      }
    }

    .menu-item:hover{
      background: #264259;
      .buttons {
        display: block;
      }
    }
    .menu-edit-mode {
      background: #fff;
      border-radius: 5px;

      .el-icon {
        color: #162e43;
      }

      /deep/.el-input__wrapper {
        border: none;
        box-shadow: 0 0 0 0px;
        padding:0;
      }

      /deep/.el-input {
        vertical-align: middle;
      }
    }
    .menu-edit-mode:hover
    {
      .el-icon {
        color: #fff;
      }
    }
  }

  /** 侧边栏工具 */
  .sidebar-tool {
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