<template>
    <el-row justify="space-between" style="padding-bottom: 10px;">
        <el-col :span="8">
            <el-button style="border: none;background-color: #fff;color: #606266;">
                <el-icon><Menu /></el-icon>资源列表
            </el-button>
        </el-col>
        <el-col :span="10">
            <el-upload>
                <el-button type="primary">
                    <el-icon><CirclePlus/></el-icon>&nbsp;&nbsp;添加文档
                </el-button>
            </el-upload>
        </el-col>
    </el-row>
    <el-menu background-color="#fff" :default-active="activeIndex" style="border:none;border-top: 1px solid #ccc;"
        @select="handleFileSelect">
        <el-menu-item v-for="(item, index) in fileList" :index="index + ''" :key="index"
            :class="{ 'menu-item': true, 'menu-active': index + '' == activeIndex, 'menu-edit-mode': item.editMode }">
            <div style="overflow: hidden;width:98%;text-align: left;">
                <el-icon style="color:red;" v-if="!item.editMode">
                    <Document />
                </el-icon>
                <span v-if="!item.editMode">{{ item.name }}</span>
                <el-input v-if="item.editMode" ref="refFileInput" v-model="item.name"></el-input>
            </div>
            <span v-if="!item.editMode" class="buttons buttons-normal">
                <el-icon @click="editFile(item)">
                    <EditPen />
                </el-icon>
                <el-popconfirm title="删除后无法恢复，是否继续删除？" confirm-button-text="删除" cancel-button-text="取消" placement="top"
                    :width="250" @confirm="deleteFile(index)">
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
                <el-icon @click="cancelEditFile(item)">
                    <CloseBold />
                </el-icon>
            </span>
        </el-menu-item>
    </el-menu>
</template>

<script lang="ts" setup>
import { ref, nextTick, defineProps, watch } from 'vue'

// 用于存储当前激活的文件索引
const activeIndex = ref('0')
// 引用文件输入元素，以便在编辑文件时自动获取焦点
const refFileInput = ref()

// 定义文件信息的接口
interface fileInfo {
    id:String,
    editMode: Boolean,
    name: String
}
// 文件列表，存储所有文件的信息
const fileList = ref()

// 定义组件属性，接收父组件传入的文件列表
const props = defineProps<{
    fileList: Array<fileInfo>
}>()

// 监听属性变化，当父组件传递的文件列表变化时，更新本地文件列表
watch(props, async (newProps) => {
    fileList.value = newProps.fileList
})

// 删除指定索引的文件
const deleteFile = (index: number) => {
    fileList.value.splice(index, 1)
}
// 编辑指定文件，开启编辑模式
const editFile = (row: any) => {
    // 将所有文件的编辑模式设置为false
    fileList.value.map((item: any) => {
        item.editMode = false
    })
    // 将当前文件的编辑模式设置为true，并保存原始文件名
    row.editMode = true
    row.oldName = row.name
    // 下一个Tick中获取文件输入框的焦点
    nextTick(() => {
        refFileInput.value[0].focus()
    })
}
// 取消编辑文件，将文件名恢复为原始值，并关闭编辑模式
const cancelEditFile = (row: any) => {
    row.name = row.oldName
    row.editMode = false
}
// 选择文件，当用户选择文件时，更新当前激活文件索引
const handleFileSelect = (key: string) => {
    activeIndex.value = key
}
</script>

<style scoped>
 /* 定义菜单项的样式 */
.menu-item {
    white-space: nowrap;
    overflow: hidden;
    word-break: break-all;
    background: #fff;
    color: #000;
    border: none;
    border-bottom: 1px solid #f1f1f1;

     /* 定义按钮容器的样式 */
    .buttons {
        right: 0;
        background: inherit;
    }

     /* 定义默认按钮的样式 */
    .buttons-normal {
        position: absolute;
        z-index: 999;
        display: none;
    }
}
 /* 菜单项选中状态的样式 */
.menu-active {
    background: #f1f1f1;
}
/* 鼠标悬停菜单项时的样式 */
.menu-item:hover {
    .buttons {
        display: block;
    }
}
 /* 编辑模式下的菜单项样式 */
.menu-edit-mode {
    border-radius: 5px;
    /* 图标颜色 */
    .el-icon {
        color: #606266;
    }
    /*自定义输入框样式*/
    /deep/.el-input__wrapper {
        border: none;
        box-shadow: 0 0 0 0px;
        padding: 0;
    }
    /* 垂直居中对齐输入框 */
    /deep/.el-input {
        vertical-align: middle;
    }
}
</style>