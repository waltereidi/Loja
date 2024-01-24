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

export interface State
{
    message? : MessageInterface[] , 
    login: any,
    navMenu: boolean, 
    axios:any
}
export interface HttpHeaders
{
    key: string,
    value:string
}