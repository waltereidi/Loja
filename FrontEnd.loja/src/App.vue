<script lang="ts">

import AppFooter from "@/components/App/AppFooter/AppFooter.vue";
import AppHeader from "./components/App/AppHeader/AppHeader.vue";
import AppFooterBottom from "@/components/App/AppFooter/AppFooterBottom.vue";
import AppBody from "@/views/AppBody/AppBody.vue";
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
      return null;
    }
  },
  components: {
    AppFooter,
    AppHeader,
    AppFooterBottom,
    AppBody,
  }
}
</script>
<template>
  <div class="app-container">
    <AppHeader :datasource="categoryHeaderDataSource"> </AppHeader>
    <router-view />
    <AppBody></AppBody>
    <AppFooter></AppFooter>
    <Toast />
    <Button label="Show" @click="show()">sdsd</Button>

  </div>
  <AppFooterBottom />
</template>

<style lang="scss">
@import './index.scss';
</style>
