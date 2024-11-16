
export type RouterInfo = {
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
export type RouteConditionResponse = {
    route:RouteCondition , 
    ui:RouteCondition , 
    user:RouteCondition,
}
