export type UserInfo = {
    nameInitials:string,
    firstName:string,
    lastName:string,
    jwtToken:JwtToken
}

export type JwtToken = {
    createdAt:Date, 
    expiresAt:Date, 
}
