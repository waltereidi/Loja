import  axios  from 'axios';
import appSettings from '@/../appsettings.json';
import { useToast } from 'primevue/usetoast';
export class RequestController {
    

    constructor()
    {
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
        axios.defaults.headers.post['Authorization'] = `Bearer ${token}`;
        axios.defaults.headers.put['Authorization'] = `Bearer ${token}`;
    }
  
  
    public async post(url: string, body: any)
    {
        axios.post(url, body).then((response) => {
            return response.data;
            
        }).catch();
    }
    public  get(url: string)
    {
        axios.get(url).then(result=>alert(result));
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
