import {UserInterface , UserInfo } from '@/pinia/Entity/dependencyInjection'
import {RouterInfo , RouteCondition, ConfiguredRouteChange} from '@/pinia/Entity/routerInfo'
import {isFuture } from 'date-fns'

export class RouteController{
    private route:RouterInfo
    private ui:UserInterface
    private user:UserInfo
    /**
     * @returns verify if user is logged in with a valid token or not
     */
    private userToken =():Boolean =>
        this.user != null 
        && this.user.token != null 
        && isFuture(new Date(this.user.token.expiresAt));
    
        
    constructor(route:RouterInfo , ui:UserInterface ,user:UserInfo = null)
    {
        this.route = route;
        this.ui = ui;
        this.user = user;    
    }

    public async routeChanged() : Promise<ConfiguredRouteChange>
    {
        const response =await this.response()
        console.log(this.configureReturn(response))
        return this.configureReturn(response)
    }
    
    private configureReturn(condition:RouteCondition) : ConfiguredRouteChange
    {
        this.configureUserInterface(condition);
        this.configureUserInfo(condition);
        
        this.configureRoute(condition);
        const result:ConfiguredRouteChange = {
            route : this.route , 
            ui : this.ui , 
            user : this.user
        } 
        return result;
    }
    private configureUserInterface(condition:RouteCondition) : void
    {
        switch(condition)
        {
            case RouteCondition.RedirectToHome :this.ui.showNavBar=true; break; 
            case RouteCondition.RedirectToLogin :this.ui.showNavBar=false; break; 
            case RouteCondition.HiddenNavBar :this.ui.showNavBar=false; break; 
            case RouteCondition.ShowNavBar : this.ui.showNavBar=true;break; 
            default : RouteCondition.Contiue; break;
        }
    }
    private configureUserInfo(condition:RouteCondition) : void 
    {
        switch(condition)
        {
            case RouteCondition.RedirectToLogin :this.user =null ;break; 
            default : RouteCondition.Contiue; break;
        }
    }
    private configureRoute(condition:RouteCondition) : void
    {
        switch(condition)
        {
            case RouteCondition.RedirectToHome :this.route.from ='';this.route.to='/Home';break; 
            case RouteCondition.RedirectToLogin :this.route.from ='';this.route.to='/Login'; break; 
            default : RouteCondition.Contiue; break;
        }
    }

    private response() : Promise<RouteCondition>
    {

        
        return new Promise((resolve , reject )=>{
            if(!this.userToken())
            {
                /**
                 * ! Token is expired or inexistent , the user should only access the login
                 */
                return resolve(RouteCondition.RedirectToLogin)
            }
            else if(this.userToken() && this.route.to == '/Login')
            {
                /**
                 * ! Token is still valid and accessed login screen
                 */
                return resolve(RouteCondition.RedirectToHome)
            }
            else
            {
                return resolve(RouteCondition.Contiue)
            }
        })
        
        
    }
    


}