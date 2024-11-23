
<script setup>
import NavBar from "@/components/Layout/NavBar/NavBar.vue"
import Header from "@/components/Layout/Header/Header.vue"
import {ref , watch } from 'vue';
import { useRoute } from 'vue-router';

const showNavBar = ref(false);
const showHeader = ref(false);
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
        <NavBar :showNavBar="showNavBar"></NavBar>
    
    <div class="view-container">
          <Header :showHeader="showHeader"></Header>
        
          <router-view class="routerView" />

    </div>
    
  </div>
</template>

<style lang="scss">
@import url('./style.scss');
</style>
