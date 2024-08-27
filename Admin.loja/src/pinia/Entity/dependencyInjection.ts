export interface UserInfo
{
    nameInitials:String,
    firstName:String,
    lastName:String,
    token:JwtToken
}
export interface JwtToken
{
    serializedToken:String , 
    createdAt:String , 
    expiresAt:String, 
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

