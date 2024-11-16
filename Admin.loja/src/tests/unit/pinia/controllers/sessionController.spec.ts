import { expect, test } from 'vitest';
import { SessionController } from "@/pinia/Controllers/sessionController";

/**
 * @param RouterInfo is sent from @/router/index.ts every time route changes
 * @param UserInterface datasource must contain all user interface related variables 
 */

test('deserialize Cookies',async ()=>{
    const session = new SessionController()
    const userInfo = session.getUserInfoFromCookies();
    console.log(userInfo);

})
