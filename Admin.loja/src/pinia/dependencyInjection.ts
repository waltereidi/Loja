import { ref , computed } from "vue";
import { defineStore } from 'pinia';
import { RequestController } from './Controllers/requestController'


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
            const token:string= sessionStorage.getItem('token')??null;
            return new RequestController(state.useToast ,token);
        },

    },
    actions: {
        async init(useToast: any )
        {
            this.useToast = useToast;
        },
        async showNavbar(isVisible:boolean)
        {
            this.showNavBar = isVisible;
        },
        async setLogin(login: any)
        {
            sessionStorage.clear();
            Object.keys(login)
                .forEach((f) => {
                    login[f] = sessionStorage.setItem(f, login[f]);
            });
        },
    }



});