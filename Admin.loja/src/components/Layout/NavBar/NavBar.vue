<template>
    <div v-if="isVisible" class="mobileNavBar-container">
        <div class="card flex justify-content-center flex-column">
            <div class="navBar-close">
                    <i  class="pi pi-times" style="font-size:1.5rem;color: green"></i>            
                </div>
            <PanelMenu :model="items" class="w-full md:w-20rem">
                <template #item="{ item }">
                    <router-link v-if="item.route" v-slot="{ href, navigate }" :to="item.route" custom>
                        <a v-ripple class="flex align-items-center cursor-pointer text-color px-3 py-2" :href="href"
                            @click="navigate">
                            <span :class="item.icon" />
                            <span class="ml-2 text-color">{{ item.label }}</span>
                        </a>
                    </router-link>
                    <a v-else v-ripple class="flex align-items-center cursor-pointer text-color px-3 py-2"
                        :href="item.url" :target="item.target">
                        <span :class="item.icon" />
                        <span class="ml-2">{{ item.label }}</span>
                        <span v-if="item.items" class="pi pi-angle-down text-primary ml-auto" />
                    </a>
                </template>
            </PanelMenu>
        </div>
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


const items = ref([
    {
        label: 'Home',
        icon: 'pi-chart-line',
        command: () => {
            router.push('/Home');
        }
    },
    {
        label: 'Store',
        icon: 'pi pi-database',
        items: [
            {
                label: 'Categories',
                icon: 'pi pi-list',
                command: () => {
                    router.push('/Store/Categories');
                }
            },
            {
                label: 'Users',
                icon: 'pi pi-user',
                command: () => {
                    router.push('/Store/Users');
                }
            }
        ]
    }
]); 
</script>

<style lang="scss">
@import './style';
</style>