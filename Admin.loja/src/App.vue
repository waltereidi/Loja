<script lang="ts">
import { useToast } from 'primevue/usetoast';
import { RequestModel } from "./vuex/Entity/requestModel";
import { ToastMessage } from "./vuex/Entity/toastMessage";
import { useDi } from '@/pinia/dependencyInjection'

import NavBar from "./components/Layout/NavBar.vue"
export default {
  setup() {
    const di = useDi();
    di.constructor(useToast());

  },
  data() {
    return {
      di: null
    }
  },
  components: {
    NavBar,
  },
  beforeCreate() {
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
