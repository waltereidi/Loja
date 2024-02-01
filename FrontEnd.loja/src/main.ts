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
import { VueRecaptchaPlugin } from 'vue-recaptcha'
import { createHead } from '@vueuse/head';
const app = createApp(App);

app.use(PrimeVue, { ripple: true });
app.use(ToastService);
app.use(createPinia());
app.use(store);
app.use(router);
app.use(VueRecaptchaPlugin, {
  v2SiteKey: '6Lf2cGApAAAAAJecxprIb3ptQtOm6w14xRTucgyO',
  v3SiteKey: '6Lf9cGApAAAAANTZFOZgMamei1LobSMF85aKfMih',
})
app.use(createHead());
/* eslint-disable */
app.component('Toast', Toast);
app.mount('#app');