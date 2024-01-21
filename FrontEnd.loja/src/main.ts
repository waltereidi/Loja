import { createApp } from 'vue'
import App from './App.vue'
import './registerServiceWorker'
import router from './router'
import store from './store/store'
import './index.scss'
import { createPinia } from 'pinia';

createApp(App).use(createPinia()).use(store).use(router).mount('#app')
