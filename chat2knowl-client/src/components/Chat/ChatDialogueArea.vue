<template>
    <div class="dialogue-container">
        <div class="dialogue-chat">
            <el-row class="dialogue-chat-item" v-for="(item, index) in dialogueList" v-bind:key="index">
                <template v-if="item.type == 'user'">
                    <el-col style="flex:1;">
                        <div class="user-content content">
                            {{ item.content }}
                        </div>
                    </el-col>
                    <el-col style="flex: 0 0 30px;">
                        <el-icon class="icon user-icon">
                            <UserFilled />
                        </el-icon>
                    </el-col>
                </template>
                <template v-if="item.type == 'robot'">
                    <el-col style="flex: 0 0 30px;">
                        <el-icon class="robot-icon icon">
                            <Monitor />
                        </el-icon>
                    </el-col>
                    <el-col style="flex:1;">
                        <div class="robot-content content">
                            {{ item.content }}
                        </div>
                    </el-col>
                </template>
            </el-row>
        </div>
        <div class="dialogue-input">
            <el-row style="height: 100%;">
                <el-col style="flex:1;">
                    <el-input
                        v-model="sendMessage"
                        :autosize="{ minRows: 2, maxRows: 4 }"
                        type="textarea"
                        resize="none"
                        placeholder="请输入问题..."
                    />
                </el-col>
                <el-col style="flex: 0 0 30px;padding: 0 10px 0 10px;height: 100%;display: flex;align-items: center;">
                    <el-button type="primary" circle style="font-weight: bolder;">
                        <el-icon>
                            <Position />
                        </el-icon>
                    </el-button>
                </el-col>
            </el-row>
        </div>
    </div>
</template>
<script lang="ts" setup>
import { ref, defineProps, onMounted, watch } from 'vue'
//存储待发送的消息
const sendMessage = ref("")

// 定义对话信息的接口类型
interface dialogueInfo {
    type: String,
    content: String
}
// 定义一个可响应式的对话列表
const dialogueList = ref()

// 定义组件的属性，其中包含一个对话信息的数组
const props = defineProps<{
    dialogueList: Array<dialogueInfo>
}>()

// 在组件挂载后执行的钩子函数
onMounted(() => {
    // 初始化对话列表的数据
    dialogueList.value = props.dialogueList
})

// 监听属性的变化
watch(props, async (newProps) => {
    // 当属性中的对话列表发生变化时，更新对话列表的数据
    dialogueList.value = newProps.dialogueList
})
</script>
<style scoped>
.dialogue-container {
    display: flex;
    flex-direction: column;
    height: 100%;

    .dialogue-chat {
        flex-grow: 1;
        padding-right: 10px;
        overflow-y: auto;

        .dialogue-chat-item {
            margin-bottom: 10px;
            font-size: 15px;

            .icon {
                padding: 5px;
                border-radius: 50%;
                font-size: 20px;
                font-weight: bolder;
            }

            .robot-icon {
                background-color: #4C83F3;
                color: #fff;
            }

            .user-icon {
                background-color: #4C83F3;
                color: #fff;
            }

            .content {
                padding: 15px;
                border-radius: 10px;
                overflow: hidden;
                min-width: 40%;
            }

            .robot-content {
                background-color: #F2F3F5;
                text-align: left;
                margin-left: 10px;
                float: left;
            }

            .user-content {
                background-color: #4C83F3;
                text-align: right;
                margin-right: 10px;
                color: #fff;
                padding: 15px;
                float: right;
            }
        }
    }

    .dialogue-input {
        padding-top: 10px;
    }
}
</style>