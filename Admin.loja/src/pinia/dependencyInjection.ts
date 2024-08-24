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
            this.showNavBar = isVisible;
        },
        async setLogin(login: any)
        {
            this.showNavBar = true;
        },
    }



});