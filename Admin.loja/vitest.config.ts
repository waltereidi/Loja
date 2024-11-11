import { defineConfig } from 'vitest/config'

export default defineConfig({
  test: {
    alias: {
      '@/': new URL('./src/', import.meta.url).pathname, 
      '#/': new URL('./', import.meta.url).pathname, 
    }
  }
})