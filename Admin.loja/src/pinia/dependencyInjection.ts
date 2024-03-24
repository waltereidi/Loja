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
        getShowNavbar(state) {
            return state.showNavBar;
        }, 
        getRequestController(state) {
            return new RequestController(state.useToast);
        },

    },
    actions: {
        toggleNavBar() {
            return this.showNavbar = !this.showNavbar;
        },
        setToast(state: State, useToast: any) {
            state.useToast = useToast;
        },
    }



});