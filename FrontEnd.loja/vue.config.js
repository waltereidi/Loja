module.exports = {
  chainWebpack: config => {
    config.module
      .rule('vue')
      .use('vue-loader')
      .tap(options => {
        options.compilerOptions = {
          // treat any tag that starts with ion- as custom elements
          isCustomElement: tag => tag==='ThemeButton'||tag==='Checkbox'
        }
        return options
      })
  },
  configureWebpack:{
    resolve:{
      extensions:[".ts"],
    }
  }
}