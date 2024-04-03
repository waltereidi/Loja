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
    private unauthorizedRedirect():void
    {

        
        this.useToast.add({ severity: 'success', summary: 'Session expired, please log in again', group: 'bc' });
        this.redirectUnauthorized = false;
    }
 
    async post(url: string, body: any) :Promise<any>
    {
        try
        {
            const header = {
                headers: {
                    Authorization: `Bearer ${window.sessionStorage.getItem('token')}`
                }
            };
            return await axios.post(url , body, header)     
        }
        catch (error)
        {
            console.warn(error);
             this.addToastErrorMessage(error.request.status, error.message);
             return error;
        }
    }
     async get(url: string ):Promise<any>
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
    async delete(url: string):Promise<any>
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
    async put(url: string, body: any):Promise<any>
    {
        try
        {
            const header = {
                headers: {
                    Authorization: `Bearer ${window.sessionStorage.getItem('token')}`
                }
            };
           return await axios.put(url , body , header)     
        }
        catch (error)
        {
            console.warn(error);
            this.addToastErrorMessage(error.request.status, error.message);
            return error;
        }
    }
    async postAsync(url: string, body: any):Promise<any>
    {
        const header = {
                headers: {
                    Authorization: `Bearer ${window.sessionStorage.getItem('token')}`
                }
            };
        return new Promise((resolve, reject) => {
            axios.post(url, body , header)
                .then(result => resolve(result?.data))
                .catch(error => {
                    console.warn(error);
                    this.addToastErrorMessage(error.request.status, error.request.responseText);
                    reject(error);
                }); 
        });
    }
    async getAsync(url: string ):Promise<any>
    {
        axios.defaults.headers.get['Authorization'] = `Bearers ${window.sessionStorage.getItem('token')}`;
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
    async deleteAsync(url: string):Promise<any>
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
    async putAsync(url: string, body: any):Promise<any>
    {
        const header = {
                headers: {
                    Authorization: `Bearer ${window.sessionStorage.getItem('token')}`
                }
            };
        return new Promise((resolve, reject) => {
            axios.put(url, body , header)
                .then(result => resolve(result?.data))
                .catch(error => {
                    console.warn(error);
                    this.addToastErrorMessage(error.request.status, error.request.responseText);
                    reject(error);
                }); 
        });
    }
}
