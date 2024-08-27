import { defineStore } from 'pinia';
import { RequestController } from './Controllers/requestController'
import { UserInfo , JwtToken } from './Entity/dependencyInjection'


export const useDi = defineStore('di', {
    
    state: () => {
        return {
            showNavBar:null,
            useToast: null,
            UserInfo:null 
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
        async setShowNavbar(path:String)
        {
            switch(path)
            {
                case '/': this.showNavBar = false;break;
                default : this.showNavBar = true;break;
            }
        },
        async setLogin(login: any)
        {
            
        },
    },
    persist: {
        storage: sessionStorage,
        paths: ['showNavBar'],
        serializer: {
            serialize: JSON.stringify,
            deserialize: JSON.parse,
          }

    },



});