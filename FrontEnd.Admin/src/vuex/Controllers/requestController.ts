import  axios  from 'axios';
import appSettings from '@/../appsettings.json';
export class RequestController {
    
    private useToast: any;
    private token: string;
    constructor(useToast:any)
    {
        this.token = ''; 
        this.useToast = useToast;
        axios.defaults.baseURL = appSettings.ApiUrl;
        axios.defaults.headers.post['Content-Type'] = 'application/json; charset=utf-8';
        axios.defaults.headers.post['Accept'] = '*/*';
        axios.defaults.headers.post['Access-Control-Allow-Origin'] = '*';
        axios.defaults.headers.post['Access-Control-Allow-Methods'] = 'GET,PUT,POST,DELETE,PATCH,OPTIONS';
        axios.defaults.headers.post['Access-Control-Allow-Headers'] = 'Origin, X-Requested-With';
        axios.defaults.headers.put = axios.defaults.headers.post;
        axios.defaults.headers.options = axios.defaults.headers.post;
    }
    public  setToken(token:string):void
    {   
        this.token = `Authorization=Bearer ${token}`;
        axios.defaults.headers.post['Authorization'],
        axios.defaults.headers.put['Authorization'],
        axios.defaults.headers.delete['Authorization'],
        axios.defaults.headers.get['Authorization'] = `Bearer ${token}`;
    }
    private addToastErrorMessage(status:number , message:string )
    { 
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
 
    async post(url: string, body: any)
    {
        try
        {
            return await axios.post(url , body)     
        }
        catch (error)
        {
             this.addToastErrorMessage(error.request.status, error.message);
             return error;
        }
    }
     async get(url: string )
     {
         try
         {
             return await axios.get(url);     
         }
         catch (error)
         {
             this.addToastErrorMessage(error.request.status, error.message);
             return error;
         }         
    }
    async delete(url: string)
    {
        try
        {
           return await axios.delete(url)     
        }
        catch (error)
        {
           this.addToastErrorMessage(error.request.status, error.message);
           return error;
        }
    }
    async put(url: string, body: any)
    {
        try
        {
           return await axios.put(url , body)     
        }
        catch (error)
        {
            this.addToastErrorMessage(error.request.status, error.message);
            return error;
        }
    }
    async postAsync(url: string, body: any)
    {
        return new Promise((resolve, reject) => {
            axios.post(url, body)
                .then(result => resolve(result))
                .catch(error => {
                    this.addToastErrorMessage(error.request.status, error.message);
                    reject(error);
                }); 
        });
    }
    async getAsync(url: string )
     {
         return new Promise((resolve, reject) => {
            axios.get(url)
                .then(result => resolve(result))
                .catch(error => {
                    this.addToastErrorMessage(error.request.status, error.message);
                    reject(error);
                }); 
        });       
    }
    async deleteAsync(url: string)
    {
        return new Promise((resolve, reject) => {
            axios.delete(url)
                .then(result => resolve(result))
                .catch(error => {
                    this.addToastErrorMessage(error.request.status, error.message);
                    reject(error);
                }); 
        });  
    }
    async putAsync(url: string, body: any)
    {
        return new Promise((resolve, reject) => {
            axios.put(url, body)
                .then(result => resolve(result))
                .catch(error => {
                    this.addToastErrorMessage(error.request.status, error.message);
                    reject(error);
                }); 
        });
    }
}
