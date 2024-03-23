import { ref , computed } from "vue";
import { defineStore } from 'pinia';
import { RequestController } from './Controllers/requestController'


export const categoryStore = defineStore('dependencyInjection' , {
    
    state: () => {
        return {
            showNavBar: false,
            
            
        }
    },
    getters: {
        getShowNavbar(state) {
            return state.showNavBar;
        }, 
    },
    actions: {
        toggleNavBar() {
            return this.showNavbar = !this.showNavbar;
        },
        setToast(state: State, useToast: any) {
            state.requestController = new RequestController(useToast);
            state.useToast = useToast;
        },
    }



});