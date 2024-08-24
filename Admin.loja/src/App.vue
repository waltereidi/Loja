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

  },
  computed : {
        computedGetShowNavBar : function() {
             if(this.di.getShowNavbar) {
               // perform some logic on preference
               // logic results true or false
               return true
             }
             
             return false
        }
    }
}
</script>

<template>
  <Toast />
  <ToastUnauthorized />
  
  <div class="app-container">
    <div class="navBar">
      <NavBar  v-if="computedGetShowNavBar" ></NavBar>
    </div>
    <div class="view-container">
        <Header  v-if="computedGetShowNavBar"  ></Header>
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
