import  axios  from 'axios';
export class RequestController {
    private useToast: any;
    constructor(useToast:any ,token:string = null)
    {
        this.useToast = useToast;
        this.setDefaultHeaders();
        if(token != null)
            this.setToken(token);
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
    private setToken(token:string):void
    {   
        axios.defaults.headers.post['Authorization'],
        axios.defaults.headers.put['Authorization'],
        axios.defaults.headers.delete['Authorization'],
        axios.defaults.headers.get['Authorization'] = `Bearer ${token}`;
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
    private unauthorizedRedirect()
    {
        this.useToast.add({ severity: 'warn', summary: 'Session expired, please log in again', group: 'bc' });
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
                .then(result => resolve(result?.data))
                .catch(error => {
                    this.addToastErrorMessage(error.request.status, error.request.responseText);
                    reject(error);
                }); 
        });
    }
    async getAsync(url: string )
     {
         return new Promise((resolve, reject) => {
            axios.get(url)
                .then(result => resolve(result?.data))
                .catch(error => {
                    this.addToastErrorMessage(error.request.status, error.request.responseText);
                    reject(error);
                }); 
        });       
    }
    async deleteAsync(url: string)
    {
        return new Promise((resolve, reject) => {
            axios.delete(url)
                .then(result => resolve(result?.data))
                .catch(error => {
                    this.addToastErrorMessage(error.request.status, error.request.responseText);
                    reject(error);
                }); 
        });  
    }
    async putAsync(url: string, body: any)
    {
        return new Promise((resolve, reject) => {
            axios.put(url, body)
                .then(result => resolve(result?.data))
                .catch(error => {
                    this.addToastErrorMessage(error.request.status, error.request.responseText);
                    reject(error);
                }); 
        });
    }
}
