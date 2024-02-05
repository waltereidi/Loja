import { Module, createStore } from 'vuex';
import { EnumMessageType, MessageInterface, State } from './Entity/store';
import { RequestController } from '@/store/Controllers/requestController';
import appSettings from '@/../appsettings.json';
import RequestModel from './Entity/requestModel';

const state :State={
    message: [],
    login : null,
    navMenu: false,  
    requestController: null,
    config: appSettings, 
    useToast: null , 
};

const mutations = {
 
    openMenu(state:State)
    {
        state.navMenu = true; 
    },
    closeMenu(state:State)
    {
        state.navMenu = false; 
    },
    setLogin(state: State, login: any)
    {   
        state.requestController.setToken(login);
        state.login = login;
    },
    setToast(state: State, useToast: any)
    {
        state.requestController = new RequestController(useToast);
        state.useToast = useToast;
    },
    addToast(state: State)
    {
        state.useToast.add({ severity: 'info', summary: 'Info Message', detail: 'Message Content', life: 3000 })
        state.useToast.add({ severity: 'warn', summary: 'Warn Message', detail: 'Message Content', life: 3000 });
    },
    async test(state: State)
    {
        return 1;
    }
    
};

const getters = {
    getNavMenu(state:State) : boolean
    {
        return state.navMenu ; 
    },
    getLogin(state: State)
    {
        return state.login;
    },
    getConfig(state:State)
    {
        return state.config;
    },
}
const actions = {

    request(context ,requestParams:RequestModel):any
    {
        const httpMethod = requestParams.method.toLowerCase();
        let result: any;
        switch (httpMethod)
        {
            case 'get': result= state.requestController.get(requestParams.url); break;
            case 'post': result= state.requestController.post(requestParams.url, requestParams.body); break;
            case 'delete': result= state.requestController.delete(requestParams.url); break;
            case 'put': result= state.requestController.put(requestParams.url, requestParams.body); break;
            default: result= null;
        }
        return result;
    },
    async requestAsync(context ,requestParams:RequestModel) :Promise<any>
    {
        return 1;
        const httpMethod = requestParams.method.toLowerCase();
        switch (httpMethod)
        {
            case 'get': return await state.requestController.getAsync(requestParams.url); break;
            case 'post': return state.requestController.postAsync(requestParams.url, requestParams.body); break;
            case 'delete': return state.requestController.deleteAsync(requestParams.url); break;
            case 'put': return state.requestController.putAsync(requestParams.url, requestParams.body); break;
            default: return null;
        }
    },
}
export default createStore({
    state : state , 
    getters: getters, 
    actions : actions,
    mutations: mutations, 
    
}) ; 
