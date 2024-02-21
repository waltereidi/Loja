import 'primevue/resources/themes/lara-light-green/theme.css';

import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import admin from './vuex/admin'
import { createPinia } from 'pinia';
import ToastService from 'primevue/toastservice';
import PrimeVue from 'primevue/config';
import Toast from 'primevue/toast';

const app = createApp(App);
createApp(App)
    .use(admin)
    .use(router)
    .use(PrimeVue, { ripple: false })
    .use(ToastService)
    .use(createPinia())
    /*eslint-disable*/
    app.component('Toast' , Toast)
    .mount('#app')
