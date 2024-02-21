<script lang="ts">
import { useToast } from 'primevue/usetoast';
import { RequestModel } from "./vuex/Entity/requestModel";
import { ToastMessage } from "./vuex/Entity/toastMessage";
//faze de testes 
export default {

  mounted() {
    this.$admin.commit('setToast', useToast());
  }
}
</script>
<template>
  <Toast />
  <router-view />
</template>

<style lang="scss"></style>
