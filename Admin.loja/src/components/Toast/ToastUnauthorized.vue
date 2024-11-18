<script setup>
import { useToast } from "primevue/usetoast";
import { ref, reactive, computed } from 'vue';
import { DepencyInjectionController,} from "@/pinia/Controllers/dependencyInjectionController";
import { email, required } from "@vuelidate/validators";
import { useVuelidate } from "@vuelidate/core";

const visible = ref(true);
const toast = useToast();

const request = new DepencyInjectionController('request').getService();
const form = reactive({
    txtEmail: "",
    txtPassword: ""
});
const rules = computed(() => {
    return {
        txtEmail: { required, email },
        txtPassword: { required }
    }
});
const v$ = useVuelidate(rules, form);
const submit = () => {
    const url = "/api/Admin/Login";
    const body = {
        Email: form.txtEmail,
        Password: form.txtPassword,
    }

    request.postAsync(url, body)
        .then((result) => {
            di.setLogin(result);
            toast.removeGroup('bc');
            visible.value = false;
        });

}

const onClose = () => {
    visible.value = false;
}

</script>

<template>
    <div class="card flex justify-content-center">
        <Toast position="bottom-center" group="bc" @close="onClose">
            <template #message="slotProps">
                <div class="toast-content">
                    <div class="flex flex-column gap-2">
                        <label for="username">Email</label>
                        <InputText id="username" v-model="form.txtEmail" aria-describedby="username-help"
                            :invalid="v$.txtEmail.$invalid" />
                    </div>
                    <div class="flex flex-column gap-2">
                        <label for="username">Password</label>
                        <Password id="username" v-model="form.txtPassword" aria-describedby="username-help"
                            :invalid="v$.txtPassword.$invalid" :feedback="false" toggleMask />
                    </div>

                    <Button class="p-button-sm" label="Sign in" @click="submit()"></Button>
                </div>
            </template>
        </Toast>
    </div>
</template>
<style lang="scss" scoped>
@import './style.scss';
</style>