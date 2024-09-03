import { ref, onBeforeUnmount } from 'vue'

// 初始化窗口宽度
const currentWidth = ref(0)
// 初始化屏幕宽度
const startX = ref(0)
// 初始化宽度
const IntWidth = ref(0)
// 是否可以改变宽度
const isAbleChange = ref(false)

/**
 * 根据当前宽度和限制计算合适的宽度
 * @param initWidth 初始宽度，默认为750
 * @param miniWidth 最小宽度，默认为200
 * @param maxWidth 最大宽度，默认为1000
 * @returns 计算后的合适宽度
 */
const getAdjustedWidth = (initWidth: number = 750, miniWidth: number = 200, maxWidth: number = 1000) => {
  let width = initWidth - currentWidth.value
  if (width < miniWidth) {
    width = miniWidth
  }
  if (width > maxWidth) {
    width = maxWidth
  }

  return width
}

/**
 * 鼠标按下事件处理程序
 * @param e 鼠标事件
 */
const handleMouseDown = (e: any) => {
  isAbleChange.value = true
  startX.value = e.clientX
  IntWidth.value = currentWidth.value
  document.addEventListener('mousemove', handleMouseMove)
  document.addEventListener('mouseup', handleMouseUp)
}

/**
 * 鼠标抬起事件处理程序
 */
const handleMouseUp = () => {
  isAbleChange.value = false
  document.removeEventListener('mousemove', handleMouseMove)
  document.removeEventListener('mouseup', handleMouseUp)
}

/**
 * 鼠标移动事件处理程序
 * @param e 鼠标事件
 */
const handleMouseMove = (e: any) => {
  if (!isAbleChange.value) return
  const moveX = e.clientX - startX.value
  currentWidth.value = IntWidth.value - moveX
}

// 在组件卸载前移除事件监听器
onBeforeUnmount(() => {
  document.removeEventListener('mousemove', handleMouseMove)
  document.removeEventListener('mouseup', handleMouseUp)
})

// 导出拖拽相关函数
const draggable = { getAdjustedWidth,  startDrag: handleMouseDown}
export default draggable