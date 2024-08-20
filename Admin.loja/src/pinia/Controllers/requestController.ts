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
        }
            
        if (status >= 400 && status <= 499)
        {
            life = 5000;
            summary = 'Invalid input'
            severity = 'warn'
        }
            
        if (status >= 500 && status <= 599 || status == 0 )
        {
            life = 4000; 
            summary = 'Server error';
            severity = 'error';
        }

        this.useToast.add({ severity: severity, summary: summary, detail: message, life: life })
    }
    public async send( request:string , url:string , data?:any ) 
    {
        var result = null;
        switch(request.toLocaleLowerCase())
        {
            case 'post' : result = await this.post(url , data);break;
            case 'postasync' : result =  await this.postAsync(url , data);break;
            case 'get' : result =  await this.get(url);break;
            case 'getasync' : result =  await this.getAsync(url);break;
            case 'put' : result =  await this.put(url,data);break;
            case 'putasync' : result =  await this.putAsync(url , data);break;
            case 'delete' : result =  await this.delete(url );break;
            case 'deleteasync' : result =  await this.deleteAsync(url );break;
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
 
    private async post(url: string, body: any) :Promise<any>
    {
        try
        {
            return await axios.post(url , body)     
        }
        catch (error)
        {
            console.warn(error);
             this.addToastErrorMessage(error.request.status, error.message);
             return error;
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
             console.warn(error);
             this.addToastErrorMessage(error.request.status, error.message);
             return error;
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
            console.warn(error);
            this.addToastErrorMessage(error.request.status, error.message);
            return error;
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
            console.warn(error);
            this.addToastErrorMessage(error.request.status, error.message);
            return error;
        }
    }
    private async postAsync(url: string, body: any):Promise<any>
    {
    
        return new Promise((resolve, reject) => {
            axios.post(url, body )
                .then(result => resolve(result?.data))
                .catch(error => {
                    console.warn(error);
                    this.addToastErrorMessage(error.request.status, error.request.responseText);
                    reject(error);
                }); 
        });
    }
    private async getAsync(url: string ):Promise<any>
    {
         return new Promise((resolve, reject) => {
            axios.get(url)
                .then(result => resolve(result?.data))
                .catch(error => {
                    console.warn(error);
                    this.addToastErrorMessage(error.request.status, error.request.responseText);
                    reject(error);
                }); 
        });       
    }
    private async deleteAsync(url: string):Promise<any>
    {
        return new Promise((resolve, reject) => {
            axios.delete(url)
                .then(result => resolve(result?.data))
                .catch(error => {
                    console.warn(error);
                    this.addToastErrorMessage(error.request.status, error.request.responseText);
                    reject(error);
                }); 
        });  
    }
    private async putAsync(url: string, body: any):Promise<any>
    {
   
        return new Promise((resolve, reject) => {
            axios.put(url, body)
                .then(result => resolve(result?.data))
                .catch(error => {
                    console.warn(error);
                    this.addToastErrorMessage(error.request.status, error.request.responseText);
                    reject(error);
                }); 
        });
    }
}
