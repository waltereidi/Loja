import { defineStore } from 'pinia';
import { RequestController } from './Controllers/requestController'
import { UserInfo , JwtToken , PiniaState } from './Entity/dependencyInjection'


export const useDi = defineStore('di', {
    
    state: () => {
        return ({
            useToast: null,
            userInfo:null ,
            userInterface:{
                showNavBar:false,
            } ,
            jwtToken:{
                serializedToken : null , 
                createdAt : null , 
                expiresAt: null , 
            }
        }as PiniaState )
    },
    getters: {
        getShowNavbar(state)
        {
            return state.userInterface.showNavBar;
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
        async routeChanged(to:string , from:string)
        {
            switch(to)
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