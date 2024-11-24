import { UserInfo } from '@/pinia/Types/session'

export class SessionController { 

    public setUserInfoSession(userInfo:UserInfo) :void
    {
        sessionStorage.setItem('userInfo.fisrtName' , userInfo.firstName)
        sessionStorage.setItem('userInfo.lastName' , userInfo.lastName)
        sessionStorage.setItem('userInfo.nameInitials' , userInfo.nameInitials)
        sessionStorage.setItem('userInfo.jwtToken.createdAt' , userInfo.jwtToken.createdAt.getTime().toString())
        sessionStorage.setItem('userInfo.jwtToken.expiresAt' , userInfo.jwtToken.expiresAt.getTime().toString())
    }
    public getUserInfoSession() :UserInfo | null
    {
        const fname:string = String(sessionStorage.getItem('userInfo.fisrtName'))
        const lName:string = String(sessionStorage.getItem('userInfo.lastName'))
        const nInitial:string = String(sessionStorage.getItem('userInfo.nameInitials'))
        const jwtCreatedAt:number =Number(sessionStorage.getItem('userInfo.jwtToken.createdAt'))
        const jwtExpiresAt:number = Number(sessionStorage.getItem('userInfo.jwtToken.expiresAt'))

        if(fname == 'null' 
            || lName == 'null' 
            || jwtCreatedAt == null 
            || jwtExpiresAt == null 
            || jwtCreatedAt == 0 
            || jwtExpiresAt == 0 )
            return null;

        return {
            firstName : fname,
            lastName : lName,
            nameInitials : nInitial ,
            jwtToken:{
                createdAt:new Date(jwtCreatedAt),
                expiresAt:new Date(jwtExpiresAt)
            }
        }
    }
    

}   