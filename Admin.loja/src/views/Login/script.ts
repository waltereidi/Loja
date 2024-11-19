import { useVuelidate } from '@vuelidate/core'
import { required, email } from '@vuelidate/validators'
import { DepencyInjectionController } from '@/pinia/Controllers/dependencyInjectionController'

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
            const request = new DepencyInjectionController('request').getService()

            request.send("api/Admin/Authentication/Login", body)
                 .then((result) => {
                     this.$router.push('/');
                 });
        },
    }
}