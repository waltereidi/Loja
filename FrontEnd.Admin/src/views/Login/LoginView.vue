<!-- eslint-disable vue/multi-word-component-names -->
<script lang="ts" >
import { ref } from 'vue';
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
    method: {
        async submit() {
            let request: RequestModel = {
                url: `${this.$router.currentRoute}/Login`,
                body: {
                    username: this.formLogin.txtEmail,
                    password: this.formLogin.txtPassword,
                },
                method: 'POST'
            }
            const result = await this.$store.dispatch('request', request);
            if (result.status == 200) {
                this.$store.commit('setLogin', result.data);
                this.$router.push('/Home');
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
    <div class="center">
        <div class="container">
            <div class="container--title">Login</div>

            <div class="container--content">
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
            </div>

            <div class="container--actions">
                <Button label="Submit" @click="submit" :disabled="this.v$.formLogin.$invalid">Submit</Button>
                <router-link to="/register" rel="noopener">
                    <Button label="Register" link>Register</Button>
                </router-link>

            </div>
        </div>
    </div>
</template>
<style lang="scss" scoped>
@import './style.scss';
</style>