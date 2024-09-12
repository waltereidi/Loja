<template>
     
     <div label="sdsd"  @click="visible=true">
        <slot></slot> 
     </div>
    <Dialog  v-model:visible="visible" modal header="Edit Profile" :style="{ width: '25rem' }">
    <template #header>
        <div class="inline-flex items-center justify-center gap-2">
            <Avatar image="https://primefaces.org/cdn/primevue/images/avatar/amyelsner.png" shape="circle" />
            <span class="font-bold whitespace-nowrap">Amy Elsner</span>
        </div>
    </template>
    <span class="text-surface-500 dark:text-surface-400 block mb-8">Update your information.</span>
    <div class="flex items-center gap-4 mb-4">
        <label for="username" class="font-semibold w-24">Username</label>
        <InputText id="username" class="flex-auto" autocomplete="off" />
    </div>
    <div class="flex items-center gap-4 mb-2">
        <label for="email" class="font-semibold w-24">Email</label>
        <InputText id="email" class="flex-auto" autocomplete="off" />
    </div>
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

