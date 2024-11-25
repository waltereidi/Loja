<template>
   <ThemeSwitcher />
    <div v-if="isVisible" class="header card">
        <Toolbar class="toolbar">
            <template #start>
            </template>
            {{ userInfo }}
            <template #end>
                <Avatar :label="nameInitials" class="mr-2" size="xlarge" shape="circle" />
            </template>
        </Toolbar>
    </div>
</template>

<script setup>
import {ref , watch  } from 'vue';
import { useRoute } from 'vue-router';

const isVisible = ref(false);
const route = useRoute();

watch( route, async ( to , from ) => {
    isVisible.value = to.fullPath !== '/' ? true : false;
})
</script>

<style lang="scss" scoped>
@import './style';
</style>