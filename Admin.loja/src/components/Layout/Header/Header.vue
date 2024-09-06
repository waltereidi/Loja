<template>
   <ThemeSwitcher />
    <div class="header card">
        <Toolbar class="toolbar">
            <template #start>
                <div class="toolbar-start flex  items-center gap-2 ">
                          
                  <IconField>
                     <InputIcon class="pi pi-search" />
                     <InputText v-model="value1" placeholder="Search" />
                  </IconField>            
                </div>
            </template>
            {{ userInfo}}
            <template #end>
               <Avatar :label="nameInitials" class="mr-2" size="xlarge" shape="circle" />
                    
            </template>
        </Toolbar>
    </div>
</template>

<script setup>
import { useDi } from '@/pinia/dependencyInjection'
import { onMounted, ref } from 'vue'

let userInfo = ref()
let nameInitials = ref(null)
onMounted(()=>{
    const ui = useDi().getUserInfo;
    console.log(ui)
    nameInitials.value = ui.nameInitials     
});





</script>

<style lang="scss">
@import './style';
</style>