<script setup>
import { ref, onMounted } from 'vue';



const dataSource = ref({});


onMounted(() => {
    let recaptchaScript = document.createElement('script');
    recaptchaScript.setAttribute('src', 'https://www.google.com/recaptcha/api.js');
    document.head.appendChild(recaptchaScript);

    var onloadCallback = function () {
        recaptchaScript.grecaptcha.render('example3', {
            'sitekey': this.$store.getters.getConfig.GoogleReCaptcha.SiteKey_v2,
        });
    };
    console.log(recaptchaScript.grecaptcha);

});
</script>

<template>
    <div class="login-container">
        <div class="login-container--title">
            <p>Login</p>

        </div>

        <div class="login-container--form">
            <div class="login-container--form__input">

                <label class="block uppercase tracking-wide text-gray-700 text-xs font-bold mb-2" for="grid-last-email">
                    e-mail
                </label>
                <input
                    class="appearance-none block w-full bg-gray-200 text-gray-700 border border-gray-200 rounded py-3 px-4 leading-tight focus:outline-none focus:bg-white focus:border-gray-500"
                    id="grid-last-email" type="email" placeholder="Doe">
            </div>

            <div class="login-container--form__input">
                <label class="block uppercase tracking-wide text-gray-700 text-xs font-bold mb-2" for="grid-last-password">
                    senha
                </label>
                <input
                    class="appearance-none block w-full bg-gray-200 text-gray-700 border border-gray-200 rounded py-3 px-4 leading-tight focus:outline-none focus:bg-white focus:border-gray-500"
                    id="grid-last-password" type="password" placeholder="Doe">
            </div>


            <div class="login-container--form__submit">
                <button @click="logar" class="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 w-full rounded">
                    Logar
                </button>
            </div>


            <a>
                <div class="login-container--register">
                    <button class="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 w-full rounded">
                        registrar
                    </button>
                </div>
            </a>
            <div class="g-recaptcha" :data-sitekey="this.$store.getters.getConfig.GoogleReCaptcha.SiteKey_v2"></div>
        </div>

    </div>
    <div>

    </div>
</template>
<style scoped lang="scss">
@import "./style.scss"
</style>