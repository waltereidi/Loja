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
        axios.defaults.headers.post['Content-Type'] = 'application/x-www-form-urlencoded';
        axios.defaults.headers.post['Access-Control-Allow-Origin'] = '*';
        axios.defaults.headers.post['Access-Control-Allow-Origin'] = 'GET, POST, PUT, DELETE';
        axios.defaults.headers.post['Access-Control-Allow-Headers'] = 'Origin, Content-Type, X-Auth-Token';
        axios.defaults.headers.post['Access-Control-Request-Headers'] = 'Content-Type, Authorization';
        axios.defaults.headers.post['Accept'] = '*/*';
        axios.defaults.headers.post['Connection'] = 'keep-alive';
        axios.defaults.headers.post['Accept-Encoding'] = 'gzip, deflate, br';
        axios.defaults.headers.put = axios.defaults.headers.post;
    }
    public  setToken(token:string):void
    {   
        this.token = `Authorization=Bearer ${token}`;
        axios.defaults.headers.post['Authorization'],
        axios.defaults.headers.put['Authorization'] = `Bearer ${token}`;
    }
    private getUrlWithToken(url:string , token:string)
    {
        return url.includes('?')? `${url}&${token}` : `${url}?${token}`;
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
            severity = 'warn    '
        }
            
        if (status >= 500 && status <= 599 || status == 0 )
        {
            life = 4000; 
            summary = 'Server error';
            severity = 'error';
        }

        this.useToast.add({ severity: severity, summary: summary, detail: message, life: life })
    }
    public async postAsync(url: string, body: any):Promise<any>
    {

        axios.post(url, body)
            .then(response => { return response; })
            .catch(error =>
            {
                this.addToastErrorMessage(error.request.status, error.message);
                return error;
            });
    }
    public async getAsync(url: string):Promise<any>
    {
        axios.get(url)
            .then(response => { return response; })
            .catch(error => {
                this.addToastErrorMessage(error.request.status, error.message);
                return error; 
            });
        
    }
    public async deleteAsync(url: string):Promise<any>
    {
        axios.delete(url)
            .then(response => { return response; })
            .catch(error => {
                this.addToastErrorMessage(error.request.status, error.message);
                return error; 
             });
    }
    public async putAsync(url: string, body: any):Promise<any>
    {
        axios.put(url, body)
            .then((response) => { return response; })
            .catch(error => {
                this.addToastErrorMessage(error.request.status, error.message);
                return error;
            });
    }
    public post(url: string, body: any):any
    {

        axios.post(url, body)
            .then(response => { return response; })
            .catch(error =>
            {
                this.addToastErrorMessage(error.request.status, error.message);
                return error;
            });
    }
    public get(url: string):any
    {
        axios.get(url)
            .then(response => { return response; })
            .catch(error => {
                this.addToastErrorMessage(error.request.status, error.message);
                return error; 
            });
        
    }
    public delete(url: string):any
    {
        axios.delete(url)
            .then(response => { return response; })
            .catch(error => {
                this.addToastErrorMessage(error.request.status, error.message);
                return error; 
             });
    }
    public put(url: string, body: any):any
    {
        axios.put(url, body)
            .then((response) => { return response; })
            .catch(error => {
                this.addToastErrorMessage(error.request.status, error.message);
                return error;
            });
    }
}
