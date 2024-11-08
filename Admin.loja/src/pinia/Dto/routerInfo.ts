import { UserInfo,UserInterface } from "./dependencyInjection";

export interface RouterInfo
{
    to:any , 
    from:any ,
}
export enum RouteCondition
{
    HiddenNavBar , 
    ShowNavBar , 
    RedirectToHome , 
    RedirectToLogin , 
    Contiue,
}
export interface RouteConditionResponse
{
    route:RouteCondition , 
    ui:RouteCondition , 
    user:RouteCondition,
}
export interface ConfiguredRouteChange
{
    user:UserInfo|null,  
    ui:UserInterface, 
    route:RouterInfo
}