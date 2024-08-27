
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