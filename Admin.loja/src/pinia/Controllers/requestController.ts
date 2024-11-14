import { IDependencyInjection } from '@/pinia/Interfaces/IDependencyInjection';
import { LogController } from '@/pinia/Controllers/LogController';
import { LogSeverity } from '../Dto/Log';

export class RequestController implements  IDependencyInjection{
    public log:LogController = new LogController("RequestController")
    constructor()
    {
        this.log.addLog( `request constructor` , LogSeverity.Initialization );
    }
    
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
    /**
     * Curry
     */
    post = (url:string , data:any , headers:any, request:Request ) =>
    {
        // const request = new Request(url ,{
        //     method: 'POST', 
        //     body: data, 
        //     headers: headers??this.getDefaultHeader()
        // })
        return fetch(request);
    }
    

    private curry(fn:any){
        return fn.length === 0 
        ? fn()
        : (x:any) => (fn.bind(null , x ));
    }
    f1 = this.curry(post)
    type Curry<P, R> = P extends [infer H]
    ? (arg: H) => R // only 1 arg
    : P extends [infer H, ...infer T] // 2 or more args
    ? (arg: H) => Curry<[...T], R>
    : never;
    
    public get(url:string )
    {


    }
    public put =(url:string , data:any ) => axios.put( url ,data );
    public delete =(url:string ) => axios.delete( url);

}
