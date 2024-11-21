import { defineStore } from 'pinia';
import { MainStoreServices} from '@/pinia/Types/mainStore'
import { ToastSeverity ,IConfigureToast } from './Interfaces/IConfigureToast';

export const useMainStore = defineStore('mainStore', {
    
    state: () => {
        return ({
            useToast: null,
        } as MainStoreServices )
    },
    actions: {
        async setToast(useToast:any){
            this.$state.useToast = useToast;
        },
        async toast(message:string , severity:ToastSeverity): Promise<void>
        {
            this.useToast.add({
                severity: severity.toString(), 
                summary: severity.toString() ,
                detail: message,
                life: 3000
            })   

        },
        async toastMessage(toast:IConfigureToast ) : Promise<void> 
        {
            this.useToast.add({
                severity: toast.severity.toString(), 
                summary: toast.summary ,
                detail: toast.detail, 
                life: toast.life
            })   

        },

    },
   



});