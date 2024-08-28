export interface UserInfo
{
    nameInitials:string,
    firstName:string,
    lastName:string,
    token:JwtToken
}
export interface JwtToken
{
    serializedToken:string , 
    createdAt:string , 
    expiresAt:string, 
}
export interface PiniaState
{
    useToast:any , 
    userInfo:UserInfo ,
    userInterface:UserInterface ,
    jwtToken:JwtToken ,
}
export interface UserInterface 
{
    showNavBar:boolean , 
}

