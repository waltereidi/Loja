<script lang="ts" src="./script.ts"/>
<style lang="scss" scoped src="./style.scss"/>

<template>
    <Card class="center">
        <template #header>
            <img class="login-img py-4" alt="user header"
                src="https://miro.medium.com/v2/resize:fit:720/format:webp/1*xIbfycrM6NsYkicgvMX7ag.jpeg" />
        </template>

        <template #title>
            <p  class="text-center">Login</p>
        </template>

        <template #content>
            <div class="flex flex-column gap-2">
                <label for="username">Email</label>
                <InputText id="username" v-model="formLogin.txtEmail" aria-describedby="username-help"/>
            </div>
            <div class="flex flex-column gap-2">
                <label for="username">Password</label>
                <Password id="username" v-model="formLogin.txtPassword" aria-describedby="username-help"/>
            </div>
        </template>

        <template #footer>
            <div class="flex gap-3 mt-1">
                <div class="g-recaptcha" data-sitekey="6LfmZ2oqAAAAAOtf5-DrKGua0PHoJxLv2kx4tq9y"></div>
                <input type="submit"/>
            </div>
        </template>
        
    </Card>
</template>

