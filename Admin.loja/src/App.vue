<script lang="ts">
import { useToast } from 'primevue/usetoast';
import { useDi } from '@/pinia/dependencyInjection'
import ToastUnauthorized from "./components/Toast/ToastUnauthorized.vue"
import NavBar from "./components/Layout/NavBar/NavBar.vue"
import Header from "./components/Layout/Header/Header.vue";

export default {
  setup() {
  },
  data() {
    return {
      di: useDi()
    }
  },
  components: {
    NavBar,
    ToastUnauthorized,
    Header,
  },
  beforeMount() {

    this.di.init(useToast());
    
    console.log("sdsd")

    this.di.showNavbar(false);

    console.log(this.di.getShowNavbar);
  },
  computed : {
        computedGetShowNavBar(){
             return useDi().getShowNavbar ? [1] : null;
        }
    }
}
</script>

<template>
  <Toast />
  <ToastUnauthorized />
  
  <div class="app-container">
    <div class="navBar">
      <div v-for="nav in this.computedGetShowNavBar" ><NavBar ></NavBar></div>
      <router-view  name="navbar" />
      
    </div>
    <div class="view-container">
      <router-view name="header" />
      <div v-for="nav in this.computedGetShowNavBar" ><Header ></Header></div>
        
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
  justify-items: center;
  align-items: center;
  padding: 20px;
  flex:0 0 100%;
}
.app-container {
  display: flex;
  flex-flow: row;
  gap:24px;
  padding:24px;
  height: 100%;
  width: 100%;
}
.routerView {
  display: flex;
  height: 100%;
  flex: 1 1 auto;
}
</style>
