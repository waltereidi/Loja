<script lang="ts">
import { RequestModel } from '@/vuex/Entity/requestModel';
import { useVuelidate } from '@vuelidate/core'
import { required, email } from '@vuelidate/validators'
import Password from 'primevue/password';
import { Register } from './script';

export default {
    setup() {
        return { v$: useVuelidate() }
    },
    data() {
        return {
            formCadastro: {
                txtEmail: '',
                txtPassword: '',
                txtConfirmPassword: '',
                txtFirstName: '',
                txtLastName: ''
            }
        }
    },
    methods: {
        async submit() {
            return this.$router.push('/');

        }
    },
    validations() {
        return {
            formCadastro: {
                txtEmail: { required, email },
                txtFirtName: { required },
                txtLastName: { required },
            }
        }
    }
}


</script>

<template>
    <Card class="center">
        <template #header>
            <h2>Cadastro</h2>
        </template>

        <template #content>
            <div class="flex flex-column gap-2">
                <FloatLabel>
                    <InputText v-model="formCadastro.txtEmail" />
                    <label>Email</label>
                </FloatLabel>
            </div>
            <div class="flex flex-column gap-2">
                <FloatLabel>
                    <InputText v-model="formCadastro.txtFirstName" />
                    <label>First Name</label>
                </FloatLabel>
            </div>
            <div class="flex flex-column gap-2">
                <FloatLabel>
                    <InputText v-model="formCadastro.txtLastName" />
                    <label>Last Name</label>
                </FloatLabel>
            </div>
            <Password v-model="formCadastro.txtPassword">
                <template #header>
                    <h6>Pick a password</h6>
                </template>

                <template #footer>
                    <Divider />
                    <p class="mt-2">Suggestions</p>
                    <ul class="pl-2 ml-2 mt-0" style="line-height: 1.5">
                        <li>At least one lowercase</li>
                        <li>At least one uppercase</li>
                        <li>At least one numeric</li>
                        <li>Minimum 8 characters</li>
                    </ul>
                </template>
            </Password>

            <div class="flex flex-column gap-2">
                <FloatLabel>
                    <Password v-model="formCadastro.txtConfirmPassword" inputId="password" toggleMask />
                    <label for="password">Retype Password</label>
                </FloatLabel>
            </div>
        </template>

        <template #footer>
            <Button label="Submit" @click="submit" :disabled="this.v$.formCadastro.$invalid">Submit</Button>
        </template>
    </Card>
</template>

<style>
@import './style.scss';
</style>