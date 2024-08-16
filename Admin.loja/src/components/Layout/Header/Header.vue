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

            <template #end>
               <Avatar label="P" class="mr-2" size="xlarge" shape="circle" />

            </template>
        </Toolbar>
    </div>
</template>

<script setup>

</script>

<style lang="scss">
@import './style';
</style>