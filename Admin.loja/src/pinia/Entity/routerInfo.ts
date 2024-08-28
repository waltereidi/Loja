import { UserInfo,UserInterface } from "./dependencyInjection";

export interface RouterInfo
{
    to:string , 
    from:string ,
}
export enum RouteCondition
{
    HiddenNavBar , 
    ShowNavBar , 
    RedirectToHome , 
    RedirectToLogin , 
    Contiue,
}
export interface ConfiguredRouteChange
{
    user:UserInfo,  
    ui:UserInterface, 
    route:RouterInfo
}