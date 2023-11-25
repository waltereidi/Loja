import { StoreConfig } from "../Entity/store";
export class StoreController { 
    getAppConfig() : StoreConfig
    {
        const retorno:StoreConfig={
            authorization : 'Bearer '
        };
        return retorno ; 
    }

}