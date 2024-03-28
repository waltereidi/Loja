<template>
    <div class="card flex justify-content-center">
        <Toast position="bottom-center" group="bc" @close="onClose">
            <template #message="slotProps">
                <div class="flex flex-column align-items-start" style="flex: 1">
                    <div class="flex align-items-center gap-2">
                        <span class="font-bold text-900">Unauthorized</span>
                    </div>
                    <div class="font-medium text-lg my-3 text-900">{{ slotProps.message.summary }}</div>
                    <Button class="p-button-sm" label="Logout" @click="onReply()"></Button>
                </div>
            </template>
        </Toast>
    </div>
</template>

<script setup>
import { useToast } from "primevue/usetoast";
import { ref } from 'vue';
const toast = useToast();
const visible = ref(false);



const onReply = () => {
    toast.removeGroup('bc');
    window.location.href = '/';
    visible.value = false;
}

const onClose = () => {
    visible.value = false;
}
</script>