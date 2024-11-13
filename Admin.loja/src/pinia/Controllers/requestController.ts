import axios from 'axios';
import { IDependencyInjection } from '@/pinia/Interfaces/IDependencyInjection';
import { LogController } from '@/pinia/Controllers/LogController';
import { LogSeverity } from '../Dto/Log';

export class RequestController implements  IDependencyInjection{
    public log:LogController = new LogController("RequestController")
    constructor()
    {
        this.log.addLog( `request constructor` , LogSeverity.Initialization );
        this.setDefaultHeaders();
    }
    public getConfigurations(){
        return axios.defaults.headers;
    }
    private setDefaultHeaders() {
        this.log.addLog( `started configuration` , LogSeverity.Event );

        //axios.defaults.baseURL = appSettings.ApiUrl;
        axios.defaults.headers.post['Content-Type'] = 'application/json; charset=utf-8';
        axios.defaults.headers.post['Accept'] = '*/*';
        axios.defaults.headers.post['Access-Control-Allow-Origin'] = '*';
        axios.defaults.headers.post['Access-Control-Allow-Methods'] = 'GET,PUT,POST,DELETE,PATCH,OPTIONS';
        axios.defaults.headers.post['Access-Control-Allow-Headers'] = 'Origin, X-Requested-With';
        axios.defaults.headers.put = axios.defaults.headers.post;
        axios.defaults.headers.options = axios.defaults.headers.post;
        
        axios.defaults.transformRequest =(data, headers)=>{
            // Do whatever you want to transform the data
            return data;
          };

        axios.defaults.transformResponse = (data) =>{
            // Do whatever you want to transform the data
        
            return data;
        };


        this.log.addLog( `configured axios ${axios.defaults}` , LogSeverity.Parameter );
    }
    public post =(url:string , data:any ) => axios.post( url ,data );
    public get =(url:string ) => axios.post( url );
    public put =(url:string , data:any ) => axios.put( url ,data );
    public delete =(url:string ) => axios.delete( url);

}
