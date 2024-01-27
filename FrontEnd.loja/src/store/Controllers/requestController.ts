import  axios  from 'axios';
import appSettings from '@/../appsettings.json';
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
  
  
    public async post(url: string, body: any)
    {
        axios.post(url, body).then((response) => {
            return response.data;
        }).catch();
    }
    public async get(url: string)
    {
        axios.get(url).then((response) => {
            return response.data;
        }).catch();
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
