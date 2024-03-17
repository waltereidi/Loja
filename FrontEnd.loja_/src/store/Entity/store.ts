import { RequestController } from "../Controllers/requestController"

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
    requestController: RequestController,
    config: any,
    useToast:any,
}
export interface HttpHeaders
{
    key: string,
    value:string
}