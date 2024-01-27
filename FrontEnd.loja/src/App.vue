
<script lang="ts">
import AppFooter from "@/components/App/AppFooter/AppFooter.vue";
import AppHeader from "./components/App/AppHeader/AppHeader.vue";
import AppFooterBottom from "@/components/App/AppFooter/AppFooterBottom.vue";
import AppBody from "@/views/AppBody/AppBody.vue";
//faze de testes 
import { useToast } from "primevue/usetoast";
import Toast from 'primevue/toast'

export default {

  data() {
    return {
      categoryHeaderDataSource: require("/tests/json/categoryHeader.json"),
      productCategory: require("/tests/json/productCategory.json"),

    }
  },
  methods: {
    show() {
      useToast().add({ severity: 'info', summary: 'Info', detail: 'Message Content', life: 3000 });

    }
  },
  components: {
    AppFooter,
    AppHeader,
    AppFooterBottom,
    AppBody,
    Toast
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
