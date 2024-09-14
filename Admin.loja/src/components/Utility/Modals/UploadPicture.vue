<template>
     
     <div @click="visible=true">
        <slot name="open"></slot> 
     </div>
    <Dialog  v-model:visible="visible" modal header="Edit Profile" :style="{ width: '25rem' }">
    <template #header>
        <div class="inline-flex items-center justify-center gap-2">
            <Avatar image="https://primefaces.org/cdn/primevue/images/avatar/amyelsner.png" shape="circle" />
            <span class="font-bold whitespace-nowrap">Amy Elsner</span>
        </div>
    </template>
    <slot name="upload"></slot>
    <template #footer>
        <Button label="Cancel" text severity="secondary" @click="visible = false" autofocus />
        <Button label="Save" outlined severity="secondary" @click="visible = false" autofocus />
    </template>
</Dialog>

</template>

<script setup lang="ts">
import { ref } from "vue";
import { useRouter } from 'vue-router';
import { useDi } from '@/pinia/dependencyInjection';
let visible = ref(false);



</script>

