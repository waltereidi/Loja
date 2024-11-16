import { expect, test } from 'vitest';
import { RouteController } from "@/pinia/Controllers/routeController";
import { UserInterface , UserInfo } from '@/pinia/Types/mainStore';
import { RouterInfo , ConfiguredRouteChange} from '@/pinia/Types/routerInfo';

/**
 * @param RouterInfo is sent from @/router/index.ts every time route changes
 * @param UserInterface datasource must contain all user interface related variables 
 */

test('navBarHiddenOnLoginView',async ()=>{
    const ui:UserInterface = {
        showNavBar:false,  
    }
    
    const route:RouterInfo = {
        to:"/",
        from:""
    }
    /**
     * ? when application starts to the main screen navbar should be hidden
     */
    const controller = new RouteController( route , ui);
    const retorno:ConfiguredRouteChange =await controller.routeChanged();

    expect(retorno.ui.showNavBar)
        .toBe( false );
})

test('navBarHiddenOnLoginView',async ()=>{
    const ui:UserInterface = {
        showNavBar:false,  
    }
    
    const route:RouterInfo = {
        to:"Login",
        from:""
    }
    const user:UserInfo = {
        firstName :'user',
        lastName : '' ,
        nameInitials : 'T',
        jwtToken : {
            createdAt : new Date().valueOf() , 
            expiresAt : new Date().valueOf(), 
            serializedToken :"sdsd"
        }
    }
    /**
     * ? when application starts to the main screen navbar should be hidden
     */
    const controller = new RouteController( route , ui,user);
    const retorno:ConfiguredRouteChange =await controller.routeChanged();

    expect(retorno.ui.showNavBar)
        .toBe( true );
})