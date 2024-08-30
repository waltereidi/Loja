import { defineStore } from 'pinia';
import { RequestController } from './Controllers/requestController'
import { UserInfo , JwtToken , PiniaState } from '@/pinia/Entity/dependencyInjection'
import { RouterInfo , ConfiguredRouteChange, RouteCondition } from '@/pinia/Entity/routerInfo';
import { RouteController } from '@/pinia/Controllers/routeController';
import { isProxy, toRaw } from 'vue';

export const useDi = defineStore('di', {
    
    state: () => {
        return ({
            useToast: null,
            userInfo:null ,
            userInterface:{
                showNavBar:null,
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
        async routeChanged(routeInfo:RouterInfo)
        {
            //Instances a new routeController
            const routeController = new RouteController(routeInfo , 
                isProxy(this.userInterface)?toRaw(this.userInterface):this.userInterface , 
                isProxy(this.userInfo)?toRaw(this.userInfo):this.userInfo );

            //Computes the values based on route , user interface and user info from login
            const routeConfig:ConfiguredRouteChange =await routeController.routeChanged();
            //Receives modified values
            this.userInterface =  routeConfig.ui;
            this.user = routeConfig.user;

            return this.route;//return route
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