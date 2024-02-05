<script lang="ts">

import AppFooter from "@/components/App/AppFooter/AppFooter.vue";
import AppHeader from "./components/App/AppHeader/AppHeader.vue";
import AppFooterBottom from "@/components/App/AppFooter/AppFooterBottom.vue";
import AppBody from "@/views/AppBody/AppBody.vue";
import { useToast } from 'primevue/usetoast';
import RequestModel from "./store/Entity/requestModel";
//faze de testes 



export default {

  data() {
    return {
      categoryHeaderDataSource: require("/tests/json/categoryHeader.json"),
      productCategory: require("/tests/json/productCategory.json"),
      request: null,
      response: null,
    }
  },
  methods: {
    async show() {
      const requestParams: RequestModel = {
        url: 'Store/GetTest',
        method: 'GET',
        body: null
      }
      //this.response = this.$store.getters.request(requestParams);
      this.response = await this.$store.dispatch('requestAsync', requestParams);

    }
  },
  components: {
    AppFooter,
    AppHeader,
    AppFooterBottom,
    AppBody,
  },
  mounted() {
    this.$store.commit('setToast', useToast());
  }
}
</script>
<template>
  <Toast />
  <div v-if="response != null">
    {{ response }}
  </div>

  <div class="app-container">
    <button @click="show()">ToastTest</button>
    <AppHeader :datasource="categoryHeaderDataSource"> </AppHeader>
    <router-view />
    <AppBody></AppBody>
    <AppFooter></AppFooter>

  </div>

  <AppFooterBottom />
</template>

<style lang="scss">
@import './index.scss';
</style>
