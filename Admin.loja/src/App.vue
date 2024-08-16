<script lang="ts">
import { useToast } from 'primevue/usetoast';
import { useDi } from '@/pinia/dependencyInjection'
import ToastUnauthorized from "./components/Toast/ToastUnauthorized.vue"
import NavBar from "./components/Layout/NavBar/NavBar.vue"
import Header from "./components/Layout/Header/Header.vue";
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
    ToastUnauthorized,
    Header,
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
    <div class="view-container">
        <Header></Header>
        <div class="routerView">
          <router-view />
        </div>
    </div>
    
  </div>
</template>

<style lang="scss">
.view-container{
  display:flex; 
  flex-flow:column;
  flex:1 1 auto;
}
.app-container {
  display: flex;
  flex-flow: row;
  gap:24px;
  padding:24px;

}
.routerView {
  display: flex;
  flex: 1 1 auto;
}
</style>
