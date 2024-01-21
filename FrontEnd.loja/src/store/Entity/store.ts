export enum EnumMessageType {
    error = 0 , 
    success = 1 , 
    warning = 2 , 
    loading = 3 , 
    notification = 4 ,
  }
 export interface MessageInterface {
    message : string , 
    type : EnumMessageType, 
  }
 export interface StoreConfig {
    authorization : string , 
  }
 export interface State{
    message? : MessageInterface[] , 
    appConfig : StoreConfig ,
    navMenu : boolean , 
  }