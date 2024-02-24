<!-- eslint-disable vue/multi-word-component-names -->
<script lang="ts" >
import { ref } from 'vue';
import InputText from 'primevue/inputtext';
import { RequestModel } from '@/vuex/Entity/requestModel';
import { useVuelidate } from '@vuelidate/core'
import { required, email } from '@vuelidate/validators'
import Password from 'primevue/password';

export default {
    setup() {
        return { v$: useVuelidate() }
    },
    data() {
        return {
            txtEmail: '',
            txtPassword: '',
        }
    },
    method: {
        async Login() {
            let request: RequestModel = {
                url: `${this.$router.currentRoute}/Login`,
                body: {
                    username: this.txtEmail,
                    password: this.txtPassword,
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
            txtEmail: { required, email },
            txtPassword: { required }
        }
    }
}
</script>
<template>
    <div class="login center-container">
        <div class="flex flex-column gap-2">
            <label for="username">Email</label>
            <InputText id="username" v-model="txtEmail" aria-describedby="username-help"
                :invalid="this.v$.txtEmail.valid" />
            <small id="username-help">Enter your username.</small>
        </div>
        <div class="flex flex-column gap-2">
            <label for="username">Password</label>
            <Password id="username" v-model="txtPassword" aria-describedby="username-help"
                :invalid="this.v$.txtPassword.valid" toggleMask />
            <small id="username-help">Enter your password.</small>
        </div>
    </div>
</template>
<style lang="scss" scoped>
@import './style.scss';
</style>