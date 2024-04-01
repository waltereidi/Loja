<script lang="ts">
import { useToast } from "primevue/usetoast";
import { ref } from 'vue';
import { useDi } from "@/pinia/dependencyInjection";
import { email, required } from "@vuelidate/validators";
import { useVuelidate } from "@vuelidate/core";
export default {
    setup() {
        return { v$: useVuelidate() }
    },
    data() {
        return {
            formLogin: {
                txtEmail: '',
                txtPassword: '',
            },
            di: null,
            request: null,
            visible: false,
        }
    },
    methods: {
        async submit() {
            const url = "api/Admin/Login";
            const body = {
                Email: this.formLogin.txtEmail,
                Password: this.formLogin.txtPassword,
            }

            this.request.postAsync(url, body)
                .then((result) => {
                    this.di.setLogin(result);
                    this.visible = false;
                });
        }
    },
    validations() {
        return {
            formLogin: {
                txtEmail: { required, email },
                txtPassword: { required }
            }
        }
    },
    beforeMount() {
        this.di = useDi();
        this.request = this.di.getRequestController;

    }
}
</script>
<template>
    <div class="card flex justify-content-center">
        <Toast position="bottom-center" group="bc" @close="onClose">
            <template #message="slotProps">

                <div class="flex flex-column gap-2">
                    <label for="username">Email</label>
                    <InputText id="username" v-model="formLogin.txtEmail" aria-describedby="username-help"
                        :invalid="this.v$.formLogin.txtEmail.$invalid" />
                </div>
                <div class="flex flex-column gap-2">
                    <label for="username">Password</label>
                    <Password id="username" v-model="formLogin.txtPassword" aria-describedby="username-help"
                        :invalid="this.v$.formLogin.txtPassword.$invalid" :feedback="false" toggleMask />
                </div>

                <Button class="p-button-sm" label="Sign in" @click="onReply()"></Button>
            </template>
        </Toast>
    </div>
</template>
