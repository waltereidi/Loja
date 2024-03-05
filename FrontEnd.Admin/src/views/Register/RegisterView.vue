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
            },
            register: new Register(),
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
            <div class="container">
                <div class="container--doubled">
                    <FloatLabel>
                        <InputText v-model="formCadastro.txtFirstName" />
                        <label>First Name</label>
                    </FloatLabel>
                </div>
                <div class="container--doubled">
                    <FloatLabel>
                        <InputText v-model="formCadastro.txtLastName" />
                        <label>Last Name</label>
                    </FloatLabel>
                </div>
                <div class="container--single">
                    <FloatLabel>
                        <InputText v-model="formCadastro.txtEmail" />
                        <label>Email</label>
                    </FloatLabel>
                </div>
                <div class="container--doubled">
                    <FloatLabel>
                        <Password v-model="formCadastro.txtPassword" inputId="password"
                            :invalid="!register.isPasswordValid(this.formCadastro.txtPassword, this.formCadastro.txtConfirmPassword)"
                            toggleMask>

                            <template #header>
                                <h6>Pick a password</h6>
                            </template>

                            <template #footer>
                                <Divider />
                                <InlineMessage
                                    :severity="register.isPasswordContainsUperCasedLetter(this.formCadastro.txtPassword) ? 'success' : 'error'">
                                    At least one uppercase</InlineMessage>
                                <br>
                                <InlineMessage
                                    :severity="register.isPasswordContainsSpecialCharacter(this.formCadastro.txtPassword) ? 'success' : 'error'">
                                    At least one numeric or special character</InlineMessage>
                                <br>
                                <InlineMessage
                                    :severity="register.isPasswordLengthBiggerThanEight(this.formCadastro.txtPassword) ? 'success' : 'error'">
                                    Minimum 8 characters</InlineMessage>
                                <br>
                            </template>

                        </Password>
                        <label for="password">Password</label>
                    </FloatLabel><!-- Complex password input end-->
                </div>
                <div class="container--doubled">
                    <FloatLabel>
                        <Password v-model="formCadastro.txtConfirmPassword" inputId="confirmPassword"
                            :invalid="!register.isPasswordValid(this.formCadastro.txtPassword, this.formCadastro.txtConfirmPassword)"
                            toggleMask />
                        <label for="confirmPassword">Retype Password</label>
                    </FloatLabel>
                </div>
            </div>
        </template><!-- Form end -->

        <template #footer>
            <Button label="Submit" @click="submit" :disabled="this.v$.formCadastro.$invalid">Submit</Button>
        </template>
    </Card>
</template>

<style lang="scss">
@import './style.scss';
</style>