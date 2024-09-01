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
    createdAt:string|null , 
    expiresAt:string|null, 
}
export interface PiniaState
{
    useToast:any|null , 
    userInfo:UserInfo|null ,
    userInterface:UserInterface ,
    jwtToken:JwtToken|null ,
}
export interface UserInterface 
{
    showNavBar:boolean|null , 
}

