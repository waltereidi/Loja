import { defineConfig } from 'vitest/config'

import vueJsx from '@vitejs/plugin-vue'
import plugin from '@vitejs/plugin-vue';

export default defineConfig({
  plugins: [plugin(),vueJsx()],
  test: {
    alias: {
      '@': new URL('./src/', import.meta.url).pathname, 
    }
  }
})