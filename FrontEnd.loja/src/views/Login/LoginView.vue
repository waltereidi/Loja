<script lang="ts">
    export default { 

    }
</script>
<template>
    <div class="login-container">
        <div class="login-container--title">
            <p>Login</p>

        </div>
        <div class="login-container--form">
            
            <div class="login-container--form__input">
                
                <label class="block uppercase tracking-wide text-gray-700 text-xs font-bold mb-2" for="grid-last-name">
                    e-mail
                </label>
                <input class="appearance-none block w-full bg-gray-200 text-gray-700 border border-gray-200 rounded py-3 px-4 leading-tight focus:outline-none focus:bg-white focus:border-gray-500" id="grid-last-name" type="email" placeholder="Doe">
            </div>

            <div class="login-container--form__input">
                <label class="block uppercase tracking-wide text-gray-700 text-xs font-bold mb-2" for="grid-last-name">
                    senha
                </label>
                <input class="appearance-none block w-full bg-gray-200 text-gray-700 border border-gray-200 rounded py-3 px-4 leading-tight focus:outline-none focus:bg-white focus:border-gray-500" id="grid-last-name" type="password" placeholder="Doe">
            </div>

            
            <div class="login-container--form__submit">
                <button class="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 w-full rounded">
                    Login
                </button>
            </div>

            <a href="/Register">
                <div class="login-container--register">
                    <button class="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 w-full rounded">
                        registrar
                    </button>
                
                </div>
            </a>

        </div>
    </div>


</template>
<style scoped lang="scss">
    @import "./style.scss"
</style>