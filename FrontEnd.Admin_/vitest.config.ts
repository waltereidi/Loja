import { defineConfig } from 'vite'
import path from 'path'
export default defineConfig({
  test: {
    // ... Specify options here.
    },
     resolve: {
    alias: {
      '@components': path.resolve(__dirname, './src/'),
      // …
    },
  },
})