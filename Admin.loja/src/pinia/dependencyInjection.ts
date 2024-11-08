import { defineStore } from 'pinia';
import { RequestController } from './Controllers/requestController'
import { DepencyInjection }   from '@/pinia/Dto/dependencyInjection'

export const useDi = defineStore('di', {
    
    state: () => {
        return ({
            appToast:null
        } as DepencyInjection)
    },
    getters: {
        getRequestController : (state) =>  new RequestController(state.appToast ) , 
        
    },
    
    },
   



);