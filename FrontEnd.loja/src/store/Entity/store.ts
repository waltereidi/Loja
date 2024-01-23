export enum EnumMessageType {
    error = 0 , 
    success = 1 , 
    warning = 2 , 
    loading = 3 , 
    notification = 4 ,
  }
export interface MessageInterface
{
    message : string , 
    type : EnumMessageType, 
}
export interface AppSettings
{
    ApiUrl : string , 
}
export interface State
{
    message? : MessageInterface[] , 
    appConfig: AppSettings,
    navMenu : boolean , 
}
export interface HttpHeaders
{
    key: string,
    value:string
}