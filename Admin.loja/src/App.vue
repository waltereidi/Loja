
<script setup>
import NavBar from "@/components/Layout/NavBar/NavBar.vue"
import Header from "@/components/Layout/Header/Header.vue"
import {ref , watch } from 'vue';
import { useRoute } from 'vue-router';

let showNavBar = ref(false);
let mobileNavBar = ref(false);

// di.init(useToast) 
const route = useRoute();

watch( route, async ( to , from ) => {
  if( to.fullPath !== '/' )
    showNavBar.value = true;
})

</script>
<template>
    <Toast></Toast>
  
  
  <div class="app-container">
    <div v-if="showNavBar" :class="{ 'navBarMobile':mobileNavBar, 'navBar': !mobileNavBar }">
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
@import url('./style.scss');
</style>
