<script lang="ts">
import { useToast } from 'primevue/usetoast';
import { useDi } from '@/pinia/dependencyInjection'
import ToastUnauthorized from "./components/Toast/ToastUnauthorized.vue"
import NavBar from "./components/Layout/NavBar/NavBar.vue"
import Header from "./components/Layout/Header/Header.vue"


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
  beforeCreate() {

    useDi().init(useToast());
    console.log(useDi().getShowNavbar)

  },
  computed : {
        computedGetShowNavBar():Array<number>{
          console.log(useDi().getShowNavbar ? [1] : null)
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
      <div v-for="nav in computedGetShowNavBar" >
        <NavBar ></NavBar>
      </div>
      
    </div>
    <div class="view-container">
      <div v-for="nav in computedGetShowNavBar" >
        <Header ></Header>
      </div>
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
