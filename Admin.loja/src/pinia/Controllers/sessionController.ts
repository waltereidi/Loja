import { UserInfo } from '@/pinia/Entity/dependencyInjection'
import cookie from 'cookiejs';


export class SessionController { 

    public getUserInfoFromCookies() :UserInfo
    {
        const result:UserInfo = {
            firstName : cookie.get('firstName').toString() , 
            lastName :  cookie.get('lastName').toString() , 
            nameInitials : cookie.get('nameInitials').toString() , 
            jwtToken : {
                createdAt :parseFloat(cookie.get('createdAt')?.toString()), 
                expiresAt :parseFloat(cookie.get('expiresAt')?.toString()),
                serializedToken :  null ,
            }
        }
        return result ; 
    }
}