<script lang="ts">
import { RequestModel } from '@/vuex/Entity/requestModel';
import { useVuelidate } from '@vuelidate/core'
import { required, email } from '@vuelidate/validators'
export default {
    setup() {
        return { v$: useVuelidate() }
    },
    data() {
        return {
            formLogin: {
                txtEmail: '',
                txtPassword: '',
            }

        }
    },
    methods: {
        async submit() {
            //return this.$router.push('/Home');

            // eslint-disable-next-line no-unreachable
            let request: RequestModel = {
                url: "Admin/Login",
                body: {
                    Email: this.formLogin.txtEmail,
                    Password: this.formLogin.txtPassword,
                },
                method: 'POST'
            }

          
        }
    },
    validations() {
        return {
            formLogin: {
                txtEmail: { required, email },
                txtPassword: { required }
            }
        }
    }
}
</script>

<template>
    <Card class="center">
        <template #header>
            <img class="login-img" alt="user header"
                src="https://miro.medium.com/v2/resize:fit:720/format:webp/1*xIbfycrM6NsYkicgvMX7ag.jpeg" />
        </template>

        <template #title>Login</template>

        <template #content>
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
        </template>

        <template #footer>
            <div class="flex gap-3 mt-1">
                <Button label="Submit" @click="submit" :disabled="this.v$.formLogin.$invalid">Submit</Button>
            </div>
        </template>

    </Card>
</template>

<style lang="scss" scoped>
@import './style.scss';
</style>