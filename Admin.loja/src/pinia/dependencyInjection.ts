import { ref , computed } from "vue";
import { defineStore } from 'pinia';
import { RequestController } from './Controllers/requestController'
import { parse, stringify } from 'zipson';

export const useDi = defineStore('di', {
    
    state: () => {
        return {
            showNavBar:Boolean,
            useToast: null,
        }
    },
    getters: {
        getShowNavbar(state)
        {
            return state.showNavBar;
        }, 
        getRequestController(state)
        {
            return new RequestController(state.useToast );
        },

    },
    actions: {
        async init(useToast: any )
        {
            this.useToast = useToast;
        },
        async showNavbar(isVisible:boolean)
        {

            var storage = sessionStorage.getItem("di");

            this.showNavBar = isVisible;
        },
        async setLogin(login: any)
        {
            
        },
    },
    persist: {
        storage: sessionStorage,
        paths: ['showNavBar'],
        afterRestore: (ctx) => {
            console.log(ctx)
            
            console.log(`just restored '${ctx.store.$id}'`)
            },
        beforeRestore: (ctx) => {
            
            console.log(`about to restore '${ctx.store.$id}'`)
        }

    },



});