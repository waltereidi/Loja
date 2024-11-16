import { LogSeverity } from "../Dto/Log";
import { IDependencyInjection } from "../Interfaces/IDependencyInjection";
import { LogController } from "./LogController";
import { RequestController } from "./requestController";

//** OCP must be used only once per dependency request */
export class DepencyInjectionController implements IDependencyInjection
{
    public log:LogController = new LogController("DepencyInjectionController")
    private serviceName:string; 
    private params:any;

    constructor( serviceName:string , params?:any ){
        this.serviceName = serviceName;
        this.params = params;
        
        this.log.addLog( `constructor ${serviceName} , ${Object.keys(params??{}).join(',') }` , LogSeverity.Initialization);
    }

    //** IOC  the entire operation must be handled here*/
    public getService() : any
    {
        this.log.addLog( `get Service` , LogSeverity.Event);
        switch(this.serviceName.toLocaleLowerCase() ){
            case 'request' : return this.getRequest(); 
            default : throw new Error(`Invalid operation exception ${this.serviceName}`);
        }
    }
    private getRequest() : RequestController
    {
        this.log.addLog( `getRequest` , LogSeverity.Event);
        return new RequestController();
    }


}
