import "primeflex/primeflex.css";
import "primevue/resources/primevue.min.css"; /* Deprecated */
import "primeicons/primeicons.css";
import "primevue/resources/themes/aura-light-green/theme.css";

import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import vuex from './vuex/vuex'
import { createPinia } from 'pinia';
import ToastService from 'primevue/toastservice';
import PrimeVue from 'primevue/config';
import Toast from 'primevue/toast';
import Button from 'primevue/button';
import InputText from 'primevue/inputtext';
import Password from 'primevue/password';
import FloatLabel from 'primevue/floatlabel';
import Card from 'primevue/card';
import InlineMessage from 'primevue/inlinemessage';
import PanelMenu from 'primevue/panelmenu';
import DataTable from "primevue/datatable";
import Column from 'primevue/column';
import ColumnGroup from 'primevue/columngroup';   // optional
import Row from 'primevue/row';                   // optional
const app = createApp(App);

app.use(PrimeVue, { ripple: true });
app.use(ToastService);
app.use(createPinia());
app.use(vuex);
app.use(router);
/* eslint-disable */
app.component('Toast', Toast);
app.component('Button', Button);
app.component('Password', Password);
app.component('InputText', InputText);
app.component('FloatLabel', FloatLabel);
app.component('Password', Password);
app.component('InlineMessage', InlineMessage);
app.component('Card', Card);
app.component('PanelMenu', PanelMenu);
app.component('DataTable', DataTable);
app.component('Column', Column);
app.component('ColumnGroup', ColumnGroup);
app.component('Row', Row);
app.mount('#app');