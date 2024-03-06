<script lang="ts">
import { useToast } from 'primevue/usetoast';
import { RequestModel } from "./vuex/Entity/requestModel";
import { ToastMessage } from "./vuex/Entity/toastMessage";
import NavBar from "./components/Layout/NavBar.vue"

//faze de testes 
export default {
  mounted() {
    this.$store.commit('setToast', useToast());
  },
  components: {
    NavBar,
  }
}
</script>

<template>
  <Toast />
  <div class="app-container">
    <div class="navBar">
      <NavBar></NavBar>
    </div>
    <div class="routerView">
      <router-view />
    </div>
  </div>
</template>

<style lang="scss">
.app-container {
  display: flex;
  flex-flow: row wrap;
  flex-basis: content;
  flex-wrap: nowrap;
}

.navBar {
  flex: 1 1 auto;
  justify-content: flex-start;

}

.routerView {
  flex: 1 1 auto;
}
</style>
