
<script setup>
import NavBar from "@/components/Layout/NavBar/NavBar.vue"
import Header from "@/components/Layout/Header/Header.vue"

</script>
<template>
  <Toast></Toast>
  
  <div class="app-container">
        <NavBar></NavBar>
    
    <div class="view-container">
          <Header></Header>
        
          <router-view class="routerView" />
    </div>
  </div>
</template>

<style lang="scss">
@import url('./style.scss');
</style>
