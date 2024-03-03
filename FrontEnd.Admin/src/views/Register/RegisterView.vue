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
                txtEmail: String,
                txtPassword: String,
                txtConfirmPassword: String,
                txtFirstName: String,
                txtLastName: String
            }
        }
    },
    method: {
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

            <FloatLabel>
                <InputText v-model="formCadastro.txtEmail" />
                <label>Email</label>
            </FloatLabel>
            <FloatLabel>
                <InputText v-model="formCadastro.txtFirstName" />
                <label>First Name</label>
            </FloatLabel>
            <FloatLabel>
                <InputText v-model="formCadastro.txtLastName" />
                <label>Last Name</label>
            </FloatLabel>

            <Password v-model="formCadastro.txtPassword" toggleMask
                :invalid="!this.v$.formCadastro.Password.txtPassword.$invalid" />

            <Password v-model="formCadastro.txtConfirmPassword" toggleMask />



        </template>

        <template #footer>

        </template>
    </Card>
</template>