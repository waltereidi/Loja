export interface UserInfo
{
    nameInitials:string|null,
    firstName:string|null,
    lastName:string|null,
    jwtToken:JwtToken|null
}
export interface JwtToken
{
    serializedToken:string|null , 
    createdAt:number|null , 
    expiresAt:number|null, 
}
export interface PiniaState
{
    useToast:any|null , 
    userInfo:UserInfo|null ,
    userInterface:UserInterface ,
}
export interface UserInterface 
{
    showNavBar:boolean|null , 
}

