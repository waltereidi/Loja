<script lang="ts">
import { useToast } from 'primevue/usetoast';
import { RequestModel } from "./store/Entity/requestModel";
import { ToastMessage } from "./store/Entity/toastMessage";
//faze de testes 



export default {

  data() {
    return {
    }
  },
  methods: {
  },
  components: {
  },
  mounted() {
    this.$store.commit('setToast', useToast());

  }
}
</script>
<template>
  <Toast />
  <div class="app-container">
    <router-view />
  </div>
</template>

<style lang="scss">
@import './index.scss';
</style>
