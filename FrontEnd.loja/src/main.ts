import 'primevue/resources/themes/lara-light-green/theme.css';
import { createApp } from 'vue'
import App from './App.vue'
import './registerServiceWorker'
import router from './router'
import store from './store/store'
import { createPinia } from 'pinia';
import ToastService from 'primevue/toastservice';
import PrimeVue from 'primevue/config';
import Toast from 'primevue/toast';
import { createHead } from '@vueuse/head';
const app = createApp(App);

app.use(PrimeVue, { ripple: true });
app.use(ToastService);
app.use(createPinia());
app.use(store);
app.use(router);
app.use(createHead());
/* eslint-disable */
app.component('Toast', Toast);
app.mount('#app');