import { expect, test } from 'vitest';
import { RouteController } from "@/pinia/Controllers/routeController";
import { UserInterface , UserInfo } from '@/pinia/Entity/dependencyInjection';
import { RouterInfo , ConfiguredRouteChange} from '@/pinia/Entity/routerInfo';
import { addDays } from 'date-fns';

/**
 * @param RouterInfo is sent from @/router/index.ts every time route changes
 * @param UserInterface datasource must contain all user interface related variables 
 */

test('navBarHiddenOnLoginView',async ()=>{
    const ui:UserInterface = {
        showNavBar:null,  
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
        showNavBar:null,  
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
            createdAt : new Date().toString() , 
            expiresAt : addDays( new Date() , 10).toString(), 
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