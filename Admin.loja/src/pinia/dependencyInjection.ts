import { ref , computed } from "vue";
import { defineStore } from 'pinia';
import { RequestController } from './Controllers/requestController'


export const useDi = defineStore('di' , {
    
    state: () => {
        return {
            showNavBar: false,
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
            return new RequestController(state.useToast , token);
        },

    },
    actions: {
        toggleNavBar()
        {
            return this.showNavbar = !this.showNavbar;
        },
        setToast(useToast: any)
        {
            this.useToast = useToast;
        },
        setLogin(login: any)
        {
            Object.keys(login)
                .forEach((f) => {
                    login[f] = sessionStorage.setItem(f, login[f]);
            });
        },
    }



});