import { IDependencyInjection } from '@/pinia/Interfaces/IDependencyInjection';
import { LogController } from '@/pinia/Controllers/LogController';
import { LogSeverity } from '../Dto/Log';

export class RequestController implements  IDependencyInjection{

    public log:LogController = new LogController("RequestController")
    /**
     * Initilize log
     */
    constructor()
    {
        this.log.addLog( `request constructor` , LogSeverity.Initialization );
    }
    /**
     * @returns {Headers}
     */
    private getDefaultHeader() : Headers
    {
        this.log.addLog("set headers" , LogSeverity.Event)

        const headers = new Headers();
        
        headers.append('Content-Type' , 'application/json; charset=utf-8')
        headers.append('Accept' , '*/*')
        headers.append('Access-Control-Allow-Origin' , '*')
        headers.append('Access-Control-Allow-Methods' , 'GET,PUT,POST,DELETE,PATCH,OPTIONS')
        headers.append('Access-Control-Allow-Headers' , 'Origin, X-Requested-With')

        return headers;
    }
    private JSONtryParse(object:any) : string | null
    {
        try {
            const result = JSON.parse(object);
            return result;

        } catch (e) {
            return null;
        }
    }

    /**
     * @param {string} method 
     * @param {string} url 
     * @param {any} data 
     * @param {Headers} headers 
     */
    public send(method:string ,url:string , data:any , headers?:Headers ) : Promise<any>
    {
        this.log.addLog( `Send ${method} ${url}` , LogSeverity.Event );
        switch(method.toUpperCase()){
            case 'POST': return this.post(url , data , headers);
            case 'GET': return this.get( url , headers);
            case 'DELETE': return this.delete( url , headers);
            case 'PUT': return this.put( url , data , headers );
            default:throw new Error('Invalid operation exception');
        }
    }
    /**
     * @param {url} string 
     * @param {JSON} data 
     * @param {Headers} headers 
     * @returns {Promise<any>}
     */
    public post (url:string , data:any , headers?:Headers) : Promise<any>
    {
        const request = new Request(url ,{
            method: 'POST', 
            body: this.JSONtryParse(data), 
            headers: headers??this.getDefaultHeader()
        })
        this.log.addLog( `POST ${url}` , LogSeverity.Event );
        return fetch(request);
    }
    /**
     * @param {url} string 
     * @param {Headers} headers 
     * @returns {Promise<any>}
     */
    public get(url:string ,headers?:Headers ) : Promise<any>
    {
        const request = new Request(url ,{
            method: 'GET', 
            headers: headers??this.getDefaultHeader()
        })
        this.log.addLog( `GET ${url}` , LogSeverity.Event );
        return fetch(request);
    }
    /**
     * @param {url} string 
     * @param {JSON} data 
     * @param {Headers} headers 
     * @returns {Promise<any>}
     */
    public put(url:string , data:any , headers?:Headers ) : Promise<any>
    {
        const request = new Request(url ,{
            method: 'PUT', 
            body: this.JSONtryParse(data), 
            headers: headers??this.getDefaultHeader()
        })
        this.log.addLog( `PUT ${url}` , LogSeverity.Event );
        return fetch(request);
    }
    /**
     * @param {url} string 
     * @param {Headers} headers 
     * @returns {Promise<any>}
     */
    public delete(url:string ,headers?:Headers ) : Promise<any>
    {
        const request = new Request(url ,{
            method: 'DELETE', 
            headers: headers??this.getDefaultHeader()
        })
        this.log.addLog( `DELETE ${url}` , LogSeverity.Event );
        return fetch(request);
    }

}
