import { defineConfig } from 'vitest/config'
import vue from '@vitejs/plugin-vue'
import vueJsx from '@vitejs/plugin-vue'
import plugin from '@vitejs/plugin-vue';

export default defineConfig({
  plugins: [

    vue({
      // Try adding these options if you're having compilation issues
      template: {
        compilerOptions: {
          // Add any specific compiler options
        }
      }
    })
  ],
  test: {
    alias: {
      '@': new URL('./src/', import.meta.url).pathname, 
    
    },
    globals: true,
    environment: 'jsdom', // Ensure this is set
      deps: {
        inline: ['vue'] // Sometimes helps with compilation
      },
      include: ['src/tests/**/*.spec.ts'],
      setupFiles: './src/main.ts'     
  },
})