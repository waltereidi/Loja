import  axios  from 'axios';
import appSettings from '@/../appsettings.json';
export class RequestController {
    
    private useToast:any
    constructor(useToast:any)
    {
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
        axios.defaults.headers.post['Authorization'],
        axios.defaults.headers.put['Authorization'] = `Bearer ${token}`;
    }
  
    private addToastErrorMessage(status:number , message:string )
    { 
        let severity: string;
        let summary: string;
        let life: number; 
        switch (status)
        {
            case 0: severity = 'error'; summary = 'Network Error'; break;    
            case 401: severity = 'warn'; summary = 'Unauthorized user'; break;
            case 404: severity = 'error'; summary = 'Request Not found'; break;
            case 200 : severity = 'success'; summary = 'OK'; break;
        }
        if (status >= 200 && status <= 299)
            life = 3000;
        if (status >= 300 && status <= 399)
            life = 5000;
        if (status >= 400 && status <= 499)
            life = 5000;
        if (status >= 500 && status <= 599)
            life = 4000; 

        this.useToast.add({ severity: severity, summary: summary, detail: message, life: life })
    }
    public async post(url: string, body: any)
    {
        axios.post(url, body).then((response) => {
            return response.data;
            
        }).catch();
    }
    public  get(url: string)
    {
        axios.get(url).then(result => alert(result))
            .catch(error => {
                this.addToastErrorMessage(error.request.status, error.message);                
            });
        
    }
    public async delete(url: string)
    {
        axios.delete(url).then((response) => {
            return response.data;
        }).catch();
    }
    public async put(url: string, body: any)
    {
        axios.put(url, body).then((response) => {
            return response.data;
        }).catch();
    }
}
