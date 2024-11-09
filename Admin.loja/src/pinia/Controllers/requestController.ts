import axios from 'axios';


export class RequestController {
    private useToast: any;
    private redirectUnauthorized: boolean = true;
    constructor(useToast:any)
    {
        this.useToast = useToast;
        this.setDefaultHeaders();
    }
    private setDefaultHeaders() {
        //axios.defaults.baseURL = appSettings.ApiUrl;
        axios.defaults.headers.post['Content-Type'] = 'application/json; charset=utf-8';
        axios.defaults.headers.post['Accept'] = '*/*';
        axios.defaults.headers.post['Access-Control-Allow-Origin'] = '*';
        axios.defaults.headers.post['Access-Control-Allow-Methods'] = 'GET,PUT,POST,DELETE,PATCH,OPTIONS';
        axios.defaults.headers.post['Access-Control-Allow-Headers'] = 'Origin, X-Requested-With';
        axios.defaults.headers.put = axios.defaults.headers.post;
        axios.defaults.headers.options = axios.defaults.headers.post;
    }
    private addToastErrorMessage(status:number , message:string )
    { 
        if (status == 401)
            return this.unauthorizedRedirect();
        
        //Severity types : info , success , warn , error 
        let severity: string;
        let summary: string;
        let life: number; 
        
        if (status >= 300 && status <= 399)
        {
            life = 5000;
            summary = 'Multiple Choices';
            severity = 'info'
        }else if(status >= 400 && status <= 499)
        {
            life = 5000;
            summary = 'Invalid input'
            severity = 'warn'
        }else(status >= 500 && status <= 599 || status == 0 )
        {
            life = 4000; 
            summary = 'Server error';
            severity = 'error';
        }

        this.useToast.add({ severity: severity, summary: summary, detail: message, life: life })
    }
    public async send( request:string , url:string , data?:any ) 
    {
        let result = null;
        switch(request.toLocaleLowerCase())
        {
            case 'post' : result = await this.post(url , data);break;
            case 'get' : result =  await this.get(url);break;
            case 'put' : result =  await this.put(url,data);break;
            case 'delete' : result =  await this.delete(url );break;
            default:throw new Error("InvalidOperationException");
        } 
        // returning order (result.value.result)??result.value -> 
        return result.result ?? result;
    }
    private unauthorizedRedirect():void
    {
        if ( document.querySelector("div[data-pc-section='message'] > div"))
            return;

        this.useToast.add({ severity: 'success', summary: 'Session expired, please log in again', group: 'bc' });
        this.redirectUnauthorized = false;
    }
    private handleRequestErrorMessage(error : any){
        console.warn(error);
        if(this.useToast != null )
            this.addToastErrorMessage(error.request.status, error.message);

        return error 
    }
    private async post(url: string, body: any) :Promise<any>
    {
        try
        {
            return await axios.post(url , body)     
        }
        catch (error)
        {
            return this.handleRequestErrorMessage(error)
        }
    }
     private async get(url: string ):Promise<any>
     {
         try
         {
             return await axios.get(url);     
         }
         catch (error)
         {
            return this.handleRequestErrorMessage(error)
         }         
    }
    private async delete(url: string):Promise<any>
    {
        try
        {
           return await axios.delete(url)     
        }
        catch (error)
        {
            return this.handleRequestErrorMessage(error)
        }
    }
    private async put(url: string, body: any):Promise<any>
    {
        try
        {
           return await axios.put(url , body )     
        }
        catch (error)
        {
            return this.handleRequestErrorMessage(error)
        }
    }
 
}
