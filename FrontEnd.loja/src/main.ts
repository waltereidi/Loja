import 'primevue/resources/themes/lara-light-green/theme.css';
import { createApp } from 'vue'
import App from './App.vue'
import './registerServiceWorker'
import router from './router'
import store from './store/store'
import './index.scss'
import { createPinia } from 'pinia';
import ToastService from 'primevue/toastservice';
import PrimeVue from 'primevue/config';
import Toast from 'primevue/toast';
import { VueRecaptchaPlugin } from 'vue-recaptcha'
const app = createApp(App);

app.use(PrimeVue, { ripple: true });
app.use(ToastService);
app.use(createPinia());
app.use(store);
app.use(router);
app.use(VueRecaptchaPlugin, {
    v2SiteKey: '6Lf2cGApAAAAAJecxprIb3ptQtOm6w14xRTucgyO',
});
/* eslint-disable */
app.component('Toast', Toast);
app.mount('#app');