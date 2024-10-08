import { useVuelidate } from '@vuelidate/core'
import { required, email } from '@vuelidate/validators'
import { useDi } from '@/pinia/dependencyInjection'

export default {
    setup() {
        return { v$: useVuelidate() }
    },
    data() {
        return {
            formLogin: {
                txtEmail: '',
                txtPassword: '',
            },
            di:  useDi(),
            request: useDi().getRequestController,
        }
    },
    validations() {
        return {
            formLogin: {
                txtEmail: { required, email },
                txtPassword: { required }
            }
        }
    },
    methods: {
        async submit() {
            
            const body = {
                Email: this.formLogin.txtEmail,
                Password: this.formLogin.txtPassword,
            }

            this.request.send('postAsync' ,"api/Admin/Authentication/Login", body)
                .then((result) => {
                    useDi().setLogin(result);
                    this.$router.push('/Home');
                });
        }
    }
}