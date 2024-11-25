<template>
    <div>
        <div :class="{ 'visible' : toggleMobile , 'hidden' : !toggleMobile }">
                <Button class="mobileOpenNavBar" icon="pi pi-ellipsis-v" @click="openNavBar()" aria-haspopup="true" aria-controls="overlay_menu" />
            </div>
        <div v-if="isVisible" class="navBar-container bg-white">
            
            <div :class="{ 'visible' : !toggleMobile , 'hidden' : toggleMobile }">
                <div class="w-full">
                    <div class="card flex justify-content-center flex-column gap-3 px-3">
                    <div class="navBar-close">
                        <i @click="closeNavBar()" class="pi pi-times" style="font-size:1.5rem;color: green"></i>
                    </div>
                    <PanelMenu :model="items" class="w-full md:w-20rem">
                        <template #item="{ item }">
                            <router-link v-if="item.route" v-slot="{ href, navigate }" :to="item.route" custom>
                                <a  class="flex align-items-center cursor-pointer text-color px-3 py-2" :href="href"
                                    @click="navigate">
                                    <span :class="item.icon" />
                                    <span class="ml-2 text-color">{{ item.label }}</span>
                                </a>
                            </router-link>
                            <a v-else  class="flex align-items-center cursor-pointer text-color px-3 py-2"
                                :href="item.url" :target="item.target">
                                <span :class="item.icon" />
                                <span class="ml-2">{{ item.label }}</span>
                                <span v-if="item.items" class="pi pi-angle-down text-primary ml-auto" />
                            </a>
                        </template>
                    </PanelMenu>
                    </div>
                </div>
                
            </div>
            
        </div>

    </div>
</template>

<script setup>

import {ref , watch  } from 'vue';
import { useRoute , useRouter  } from 'vue-router';

const isVisible = ref(false);
const route = useRoute();
const toggleMobile = ref(false)

watch( route, async ( to , from ) => {
    isVisible.value = to.fullPath !== '/' ? true : false;
})
const openNavBar =()=>toggleMobile.value = false;
const closeNavBar =()=>toggleMobile.value = true;

const routerNavBar = useRouter();

const items = ref([
    {
        label: 'Home',
        icon: 'pi-chart-line',
        command: () => {
            routerNavBar.push('/Home');
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
                    routerNavBar.push('/Store/Categories');
                }
            },
            {
                label: 'Users',
                icon: 'pi pi-user',
                command: () => {
                    routerNavBar.push('/Store/Users');
                }
            }
        ]
    }
]); 
</script>

<style lang="scss" scoped>
@import './style';
</style>