import { Module, createStore } from 'vuex';
import { EnumMessageType, MessageInterface, State } from './Entity/vuex';
import { RequestController } from '@/vuex/Controllers/requestController';
import appSettings from '@/../appsettings.json';
import {RequestModel} from './Entity/requestModel';
import { ToastMessage } from './Entity/toastMessage';

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
    addToast(state: State , toast:ToastMessage )
    {
        state.useToast.add({ severity: toast.severity , summary: toast.summary, detail: toast.detail , life: toast.life })
    },
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
    async request(context ,requestParams:RequestModel)
    {
        const httpMethod = requestParams.method.toLowerCase();
        switch (httpMethod)
        {
            case 'get': return await state.requestController.get(requestParams.url); break;
            case 'post': return await state.requestController.post(requestParams.url, requestParams.body); break;
            case 'delete': return await state.requestController.delete(requestParams.url); break;
            case 'put': return await state.requestController.put(requestParams.url, requestParams.body); break;
            default: return null;
        }
    }
}
export default createStore({
    state : state , 
    getters: getters, 
    actions : actions,
    mutations: mutations, 
}) ; 
