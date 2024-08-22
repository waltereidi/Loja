<template>
   <ThemeSwitcher />
    <div class="header card">
        <Toolbar class="toolbar">
            <template #start>
                <div class="toolbar-start flex items-center gap-2 ">
                          
                  <IconField>
                     <InputIcon class="pi pi-search" />
                     <InputText v-model="value1" placeholder="Search" />
                  </IconField>            
                </div>
            </template>
            {{ userInfo}}
            <template #end>
               <Avatar :label="userInfo" class="mr-2" size="xlarge" shape="circle" />
                    
            </template>
        </Toolbar>
    </div>
</template>

<script setup>
import { useDi } from '@/pinia/dependencyInjection'
import { ref } from 'vue'

let userInfo = ref()
const request = useDi().getRequestController
request.send("getAsync" , "api/Admin/Authentication/getUserInfo").then((result)=>userInfo=ref(result))


</script>

<style lang="scss">
@import './style';
</style>