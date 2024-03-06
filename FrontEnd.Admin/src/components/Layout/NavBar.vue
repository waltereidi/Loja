<template>
    <div :class="{ 'navMenu': this.$store.getters.getNavMenu, 'hide': !this.$store.getters.getNavMenu }">
        <div class="card flex justify-content-center">
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
import { ref } from "vue";
import { useRouter } from 'vue-router';

const router = useRouter();

const items = ref([
    {
        label: 'Router',
        icon: 'pi pi-palette',
        items: [
            {
                label: 'Styled',
                icon: 'pi pi-eraser',
                route: '/theming'
            },
            {
                label: 'Unstyled',
                icon: 'pi pi-heart',
                route: '/unstyled'
            }
        ]
    },
    {
        label: 'Programmatic',
        icon: 'pi pi-link',
        command: () => {
            router.push('/introduction');
        }
    },
    {
        label: 'External',
        icon: 'pi pi-home',
        items: [
            {
                label: 'Vue.js',
                icon: 'pi pi-star',
                url: 'https://vuejs.org/'
            },
            {
                label: 'Vite.js',
                icon: 'pi pi-bookmark',
                url: 'https://vuejs.org/'
            }
        ]
    }
]);
</script>

<style lang="scss">
@import './style';
</style>