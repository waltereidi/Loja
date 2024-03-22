import { Module, createStore } from 'vuex';
import { EnumMessageType, MessageInterface, State } from './Entity/vuex';
import { RequestController } from '@/vuex/Controllers/requestController';
import appSettings from '@/../appsettings.json';
import {RequestModel} from './Entity/requestModel';
import { ToastMessage } from './Entity/toastMessage';
import createPersistedState from 'vuex-persistedstate'
import  Cookies from 'js-cookie'

const state :State={
    message: [],
    login : null,
    isNavBarVisible: true,  
    requestController: null,
    config: appSettings, 
    useToast: null , 
};

const mutations = {
 
    openMenu(state:State)
    {
        state.isNavBarVisible = true; 
    },
    closeMenu(state:State)
    {
        state.isNavBarVisible = false; 
    },
    setLogin(state: State, login: any)
    {   
        state.requestController.setToken(login.token);
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
        return state.isNavBarVisible ; 
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
    },
    async requestAsync(context ,requestParams:RequestModel)
    {
        const httpMethod = requestParams.method.toLowerCase();
        switch (httpMethod)
        {
            case 'get': return  state.requestController.get(requestParams.url); break;
            case 'post': return  state.requestController.post(requestParams.url, requestParams.body); break;
            case 'delete': return  state.requestController.delete(requestParams.url); break;
            case 'put': return  state.requestController.put(requestParams.url, requestParams.body); break;
            default: return null;
        }
    }

}
export default createStore({
    state : state , 
    getters: getters, 
    actions : actions,
    mutations: mutations, 
    plugins: [createPersistedState({
    storage: {
      getItem: key => Cookies.get(key),
      setItem: (key, value) => Cookies.set(key, value, { expires: 3, secure: true }),
      removeItem: key => Cookies.remove(key)
    }
  })],
}) ; 
