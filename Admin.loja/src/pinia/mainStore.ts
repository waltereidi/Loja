import { defineStore } from 'pinia';
import { MainStoreServices} from '@/pinia/Types/mainStore'
import { ToastSeverity ,IConfigureToast } from './Interfaces/IConfigureToast';
import { useToast } from "primevue/usetoast";
export const useMainStore = defineStore('mainStore', {
    
    state: () => {
        return ({
            useToast: useToast(),
        } as MainStoreServices )
    },
    actions: {
        async toast(message:string , severity:ToastSeverity , useToast:any = null): Promise<void>
        {
            this.useToast = this.useToast ?? useToast;
            this.useToast.add({
                severity: ToastSeverity[severity], 
                summary: severity.toString() ,
                detail: message,
                life: 3000
            })   

        },
        async toastMessage(toast:IConfigureToast ) : Promise<void> 
        {
            this.useToast.add({
                severity: ToastSeverity[toast.severity], 
                summary: toast.summary ,
                detail: toast.detail, 
                life: toast.life
            })   

        },

    },
   



});