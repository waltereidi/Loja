<template>
   <ThemeSwitcher />
    <div class="header card">
        <Toolbar class="toolbar">
            <template #start>
                <div class="toolbar-start flex items-center gap-2">
                    <div class="card flex justify-start">
                        <Breadcrumb :home="home" :model="items" />
                    </div>
                    
                    
                </div>
            </template>
            {{ userInfo }}
            <template #end>
                <IconField class="mr-3" >
                    <InputIcon class="pi pi-search" />
                    <InputText v-model="value1" placeholder="Search" />
                </IconField>            
                <Avatar :label="nameInitials" class="mr-2" size="xlarge" shape="circle" />
            </template>
        </Toolbar>
    </div>
</template>

<script setup>
import Breadcrumb from 'primevue/breadcrumb';
import { useDi } from '@/pinia/dependencyInjection'
import { onMounted, ref } from 'vue'

let userInfo = ref()
let nameInitials = ref(null)
onMounted(()=>{
    const ui = useDi().getUserInfo;
    console.log(ui)
    nameInitials.value = ui.nameInitials     
});

const home = ref({
    icon: 'pi pi-home'
});
const items = ref([
    { label: 'Electronics' }, 
    { label: 'Computer' }, 
    { label: 'Accessories' }, 
    { label: 'Keyboard' }, 
    { label: 'Wireless' }
]);



</script>

<style lang="scss">
@import './style';
</style>