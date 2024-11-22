import { DepencyInjectionController } from '@/pinia/Controllers/dependencyInjectionController'
import { ToastSeverity } from '@/pinia/Interfaces/IConfigureToast'
import { useMainStore } from '@/pinia/mainStore'
import { ref } from 'vue';
export default {
    setup() {
        const store = useMainStore();
        store.toast('sdsds' ,ToastSeverity.warn);
        const txtEmail = ref(null);
        const txtPassword = ref(null);
        return {
            formLogin : {
                txtEmail,
            txtPassword
            }
            
        }
    },
}