import { defineStore } from 'pinia';
import { MainStore ,UserInfo } from '@/pinia/Dto/mainStore'
import { RouterInfo , ConfiguredRouteChange } from '@/pinia/Dto/routerInfo';
import { RouteController } from '@/pinia/Controllers/routeController';
import { isProxy, toRaw } from 'vue';
import { SessionController } from './Controllers/sessionController';

export const useMainStore = defineStore('mainStore', {
    
    state: () => {
        return ({
            useToast: null,
            userInfo:null ,
        } as MainStore )
    },
    getters: {
        getUserInfo(state) : UserInfo|null
        {
            return state.userInfo;
        },
    },
    actions: {
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

    },
   



});