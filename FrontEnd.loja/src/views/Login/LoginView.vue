<script setup>
import { ref, onMounted } from 'vue';

const dataSource = ref({});
function logar() {
    alert(window.grecaptcha.getResponse());
}

function onSuccess(googleUser) {
    console.log('Logged in as: ' + googleUser.getBasicProfile().getName());
}
function onFailure(error) {
    console.log(error);
}
onMounted(() => {

    window.gapi.signin2.render('my-signin2', {
        'scope': 'profile email',
        'width': 315,
        'height': 40,
        'longtitle': true,
        'theme': 'dark',
    });
    var onloadCallback = function () {
        window.grecaptcha.render('googleRecaptcha_v2', {
            'sitekey': this.$store.getters.getConfig.GoogleReCaptcha.SiteKey_v2
        })
    };

})
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
            <div id="my-signin2"></div>
            <div class="g-recaptcha" id="googleRecaptcha_v2"
                :data-sitekey="this.$store.getters.getConfig.GoogleReCaptcha.SiteKey_v2">
            </div>


            <div id="spinner"
                style="background: #4267b2;border-radius: 5px;color: white;height: 40px;text-align: center;width: 250px;">
                <div class="fb-login-button" data-max-rows="1" data-size="large" data-button-type="continue_with"
                    data-use-continue-as="true"></div>
            </div>
        </div>

    </div>
    <div>

    </div>
</template>
<style scoped lang="scss">
@import "./style.scss"
</style>