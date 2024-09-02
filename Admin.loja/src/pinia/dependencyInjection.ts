import { defineStore, Pinia } from 'pinia';
import { RequestController } from './Controllers/requestController'
import { PiniaState } from '@/pinia/Entity/dependencyInjection'
import { RouterInfo , ConfiguredRouteChange, RouteCondition } from '@/pinia/Entity/routerInfo';
import { RouteController } from '@/pinia/Controllers/routeController';
import { isProxy, toRaw } from 'vue';
import { SessionController } from './Controllers/sessionController';

export const useDi = defineStore('di', {
    
    state: () => {
        return ({
            useToast: null,
            userInfo:null ,
            userInterface:{
                showNavBar:null,
            }
        } as PiniaState )
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
        async routeChanged(routeInfo:RouterInfo) : Promise<RouterInfo>
        {
            if(this.userInfo == null){
                const sessionController = new SessionController();
                this.userInfo= sessionController.getUserInfoFromCookies();
            }
            //Instances a new routeController
            const routeController = new RouteController(routeInfo , 
                isProxy(this.userInterface)?toRaw(this.userInterface):this.userInterface , 
                isProxy(this.userInfo)?toRaw(this.userInfo):this.userInfo );

            //Computes the values based on route , user interface and user info from login
            const routeConfig:ConfiguredRouteChange =await routeController.routeChanged();
            //Receives modified values
            this.userInterface =  routeConfig.ui;
            
            this.userInfo = routeConfig.user;

            return routeConfig.route;//return route
        },
        async setLogin(login: any)
        {
            const sessionController = new SessionController();

            this.userInfo= sessionController.getUserInfoFromCookies();
        },

    },
   



});