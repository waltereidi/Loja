<script lang="ts" setup>
import { DepencyInjectionController } from '@/pinia/Controllers/dependencyInjectionController'
import { ToastSeverity } from '@/pinia/Interfaces/IConfigureToast'
import { useMainStore } from '@/pinia/mainStore'
import { ref } from 'vue';

const store = useMainStore();
const txtEmail = ref(null);
const txtPassword = ref(null);

const submit= async ()=>{
    const form =document.getElementById('frmLogin');
    console.log(form)

    store.toast( $refs.txtEmail, ToastSeverity.success)
}

</script>
<style lang="scss" scoped src="./style.scss"/>

<template>
    <Card class="center">

        <template #header>
            <img class="login-img py-4" alt="user header"
                src="https://miro.medium.com/v2/resize:fit:720/format:webp/1*xIbfycrM6NsYkicgvMX7ag.jpeg" />
        </template>

        <template #title>
            <p  class="text-center">Login</p>
        </template>

        <template #content>
            <form id="frmLogin">
                <div class="flex flex-column gap-2">
                <label for="username">Email</label>
                <InputText id="username" v-model="txtEmail" aria-describedby="username-help"/>
            </div>
            <div class="flex flex-column gap-2">
                <label for="username">Password</label>
                <Password id="username" v-model="txtPassword" aria-describedby="username-help"/>
            </div>
            </form>
        </template>

        <template #footer>
            <div class="flex gap-3 mt-1">
                <Button label="Primary" @click="submit" class="theme-primary"/>
            </div>
        </template>
    </Card>
</template>

