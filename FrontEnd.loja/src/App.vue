<script lang="ts">

import AppFooter from "@/components/App/AppFooter/AppFooter.vue";
import AppHeader from "./components/App/AppHeader/AppHeader.vue";
import AppFooterBottom from "@/components/App/AppFooter/AppFooterBottom.vue";
import AppBody from "@/views/AppBody/AppBody.vue";
import { useToast } from 'primevue/usetoast';
//faze de testes 

export default {

  data() {
    return {
      categoryHeaderDataSource: require("/tests/json/categoryHeader.json"),
      productCategory: require("/tests/json/productCategory.json"),
    }
  },
  methods: {
    async show() {

      const request: any = this.$store.getters.getRequestController;
      const i = await request.get('Store/GetTest');
      this.$store.commit('addToast');
      return null;
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
