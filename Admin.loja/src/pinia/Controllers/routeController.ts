import {UserInterface , UserInfo } from '@/pinia/Entity/dependencyInjection'
import {RouterInfo , RouteCondition, ConfiguredRouteChange, RouteConditionResponse} from '@/pinia/Entity/routerInfo'
import {isFuture } from 'date-fns'

export class RouteController{
    private route:RouterInfo
    private ui:UserInterface
    private user:UserInfo|null
    /**
     * @returns verify if user is logged in with a valid token or not
     */
    private userToken =():Boolean =>
        this.user != null 
        && this.user.jwtToken != null 
        && isFuture(new Date(this.user.jwtToken.expiresAt));
    
        
    constructor(route:RouterInfo , ui:UserInterface ,user:UserInfo|null = null)
    {
        this.route = route;
        this.ui = ui;
        this.user = user;    
    }

    public async routeChanged() : Promise<ConfiguredRouteChange>
    {
        const response =await this.response()
        return this.configureReturn(response)
    }
    
    private configureReturn(condition:RouteConditionResponse) : ConfiguredRouteChange
    {
        this.configureUserInterface(condition.ui);
        this.configureUserInfo(condition.user);
        
        this.configureRoute(condition.route);
        const result:ConfiguredRouteChange = {
            route : this.route , 
            ui : this.ui , 
            user : this.user
        } 
        console.log(condition)
        console.log(result)
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
            case RouteCondition.RedirectToHome :
                this.route.to ='Home';break; 

            case RouteCondition.RedirectToLogin :
                this.route.to  ='Login';break; 

            default : RouteCondition.Contiue; break;
        }
    }

    private response() : Promise<RouteConditionResponse>
    {

        
        return new Promise((resolve , reject )=>{
            if(!this.userToken())
            {
                /**
                 * ! Token is expired or inexistent , the user should only access the login
                 */
                return resolve({
                    route:RouteCondition.RedirectToLogin,
                    user:RouteCondition.Contiue, 
                    ui:RouteCondition.HiddenNavBar,
                })
            }
            else if(this.userToken() && this.route.to == 'Login')
            {
                /**
                 * ! Token is still valid and accessed login screen
                 */
                return resolve({
                    route: RouteCondition.RedirectToHome, 
                    ui : RouteCondition.ShowNavBar, 
                    user : RouteCondition.Contiue ,
                })
            }
            else
            {
                return resolve({
                    route: RouteCondition.Contiue , 
                    ui : RouteCondition.Contiue ,
                    user : RouteCondition.Contiue ,
                })
            }
        })
        
        
    }
    


}