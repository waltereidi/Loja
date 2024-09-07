
<script setup>
import { useDi } from '@/pinia/dependencyInjection'
import { useToast } from 'primevue/usetoast';
import ToastUnauthorized from "./components/Toast/ToastUnauthorized.vue"
import NavBar from "./components/Layout/NavBar/NavBar.vue"
import Header from "./components/Layout/Header/Header.vue"
import {ref} from 'vue';

const di = useDi()
let showNavBar = ref(false);
di.init(useToast) 
di.$subscribe(( mutation , state ) =>
{
  showNavBar.value = state.showNavBar;
})

</script>
<template>
  <Toast />
  <ToastUnauthorized />
  
  <div class="app-container">
    
    <div v-if="showNavBar" class="navBar">
        <NavBar ></NavBar>
    </div>
    
    <div class="view-container">
        <div v-if="showNavBar" class="header">
          <Header></Header>
        </div>
        
        <div class="routerView">
          <router-view />
        </div>
    </div>
    
  </div>
</template>

<style lang="scss">
.navBar {
  flex:0 0 auto;
  
}
.header{
  width: 100%;
}
.view-container{
  display:flex; 
  flex-flow:column;
  justify-items: center;
  align-items: center;
  flex:1 1 auto;
}
.app-container {
  display: flex;
  flex-flow: row wrap;
  gap:24px;
  padding:24px;

}
.routerView {
  display: flex;
  height: 100%;
  flex:1 1 auto;
  justify-content: center;
  width: 100%;
}
</style>
