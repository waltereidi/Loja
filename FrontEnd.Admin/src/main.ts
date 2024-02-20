import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import admin from './store/admin'
import {createPinia} from 'pinia'
import ToastService from 'primevue/toast'
import PrimeVue from 'primevue/config'
import Toast from 'primevue/toast'

const app = createApp(App);
app.use(PrimeVue , {ripple : true}); 
app.use(ToastService);
app.use(createPinia());
app.use(admin);
app.use(router);
app.mount('#app');
