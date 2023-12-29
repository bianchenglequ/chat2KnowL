const path = require('path')
const HtmlWebpackPlugin = require('html-webpack-plugin');
const { defineConfig } = require('@vue/cli-service')

function resolve(dir) {
  return path.join(__dirname, dir)
}

module.exports = defineConfig({
  transpileDependencies: true,
  chainWebpack: (config) => {
    config
      .plugin('html')
      .use(new HtmlWebpackPlugin({
        title:"Chat2KnowL - AI智能回答文档",
        filename: "index.html",
        templateParameters: {
          BASE_URL: `/`
        },
        template: resolve("./public/index.html"),
        inlineSource: ".(js|css)$",
        inject: "body",
      }))
  }
})
