import  axios  from 'axios';;
import appSettings from 'appsettings.json' assert { type: 'json' };
import { useToast } from 'primevue/usetoast';
import Toast from 'primevue/toast';
export class RequestController {

    constructor()
    {
        axios.defaults.baseURL = appSettings.ApiUrl;
        axios.defaults.headers.post['Content-Type'] = 'application/x-www-form-urlencoded';
    }
    public  setToken(token:string):void
    {   
        axios.defaults.headers.common['Authorization'] = `Bearer ${token}`;
    }
    public request(url: string, body: any,type:string)
    {


        return null; 
    }
    public async requestAsync(url:string, body:any, type:string)
    {
        return null;
    }
    private async send(url:string , body:any , type:string)
    {
        let result;
        switch (type)
        {
            case 'get': this.get(url); break;
            case 'post': this.post(url ,body); break;
            case 'delete': this.delete(url, body); break;
            case 'put': this.put(url, body); break;
            
        }
    }
    private post(url: string, body: any)
    {
        let result;
        axios.post(url, body).then((response) => {
            result = response;
        }).catch();
    }
    private get(url: string)
    {

    }
    private delete(url: string, body: any)
    {
        
    }
    private put(put: string, body: any)
    {

    }
}
