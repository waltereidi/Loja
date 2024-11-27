
<script setup>
import NavBar from "@/components/Layout/NavBar/NavBar.vue"
import Header from "@/components/Layout/Header/Header.vue"

</script>
<template>
  <Toast></Toast>
  
  <div class="app-container max-w-full">
      <NavBar></NavBar>
        
    
    <div class="view-container p-3 gap-3 w-full">
          <Header></Header>
        
          <router-view class="routerView" />
    </div>
  </div>
</template>

<style lang="scss">
@import url('./style.scss');
@import url('./theme.scss');
</style>
