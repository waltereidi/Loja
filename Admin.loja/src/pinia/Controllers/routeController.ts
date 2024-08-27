import {UserInterface , UserInfo } from '@/pinia/Entity/dependencyInjection'
import {RouterInfo} from '@/pinia/Entity/routerInfo'
export class RouteController{
    private route:RouterInfo
    private ui:UserInterface
    private user:UserInfo

    constructor(route:RouterInfo , ui:UserInterface ,user:UserInfo = null)
    {
        this.route = route;
        this.ui = ui;
        this.user = user      
    }
    public routeChanged()
    {
        

        return this.ui;
    }
    


}