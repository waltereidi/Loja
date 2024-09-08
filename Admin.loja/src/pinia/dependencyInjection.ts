import { defineStore } from 'pinia';
import { RequestController } from './Controllers/requestController'
import { PiniaState ,UserInfo } from '@/pinia/Entity/dependencyInjection'
import { RouterInfo , ConfiguredRouteChange } from '@/pinia/Entity/routerInfo';
import { RouteController } from '@/pinia/Controllers/routeController';
import { isProxy, toRaw } from 'vue';
import { SessionController } from './Controllers/sessionController';

export const useDi = defineStore('di', {
    
    state: () => {
        return ({
            useToast: null,
            userInfo:null ,
            showNavBar:false,
            mobileNavBar:false,
        } as PiniaState )
    },
    getters: {
        getUserInfo(state) : UserInfo|null
        {
            return state.userInfo;
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
                {showNavBar : this.showNavBar}, 
                isProxy(this.userInfo)?toRaw(this.userInfo):this.userInfo );

            //Computes the values based on route , user interface and user info from login
            const routeConfig:ConfiguredRouteChange =await routeController.routeChanged();
            //Receives modified values
            this.showNavBar =  routeConfig.ui.showNavBar;
            
            this.userInfo = routeConfig.user;

            return routeConfig.route;//return route
        },
        async setLogin(login: any)
        {
            const sessionController = new SessionController();

            this.userInfo= sessionController.getUserInfoFromCookies();
        },
        /**
         * ! Change state from mobileNavBar and lock screen overflow
         * used in App and header component
         */
        async openMobileNavBar(openMenu:boolean)
        {
            this.mobileNavBar = openMenu;
            if(openMenu)
                document.body.style.overflow ='hidden'
            else
                document.body.style.overflow ='auto'
        }
    },
   



});