<script lang="ts">
import { useToast } from 'primevue/usetoast';
import { useDi } from '@/pinia/dependencyInjection'
import ToastUnauthorized from "./components/Toast/ToastUnauthorized.vue"
import NavBar from "./components/Layout/NavBar.vue"
export default {
  setup() {
    const di = useDi();
    di.init(useToast());

  },
  data() {
    return {
      di: null
    }
  },
  components: {
    NavBar,
    ToastUnauthorized
  },
  beforeCreate() {

  }
}
</script>

<template>
  <Toast />
  <ToastUnauthorized />

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
}

.navBar {
  display: flex;
  flex: 0 0 auto;
}

.routerView {
  display: flex;
  flex: 1 1 auto;
}
</style>
