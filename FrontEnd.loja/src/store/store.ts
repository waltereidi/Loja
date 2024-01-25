import { Module, createStore } from 'vuex';
import { EnumMessageType, MessageInterface, State } from './Entity/store';
import { RequestController } from '@/store/Controllers/requestController';
import axios from 'axios';
import appSettings from 'appsettings.json' assert { type: 'json' };

axios.defaults.baseURL = appSettings.ApiUrl;
axios.defaults.headers.post['Content-Type'] = 'application/x-www-form-urlencoded';
axios.defaults.validateStatus = function (status) {
    if (status >= 200)
        return true;
    return status >= 200 && status < 300; // padr�o
};

const state :State={
    message: [],
    login : null,
    navMenu: false,  
    axios: axios,
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
        state.axios =axios.defaults.headers.common['Authorization'] = login.Authorization;
        state.login = login;
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
    axios(state:State)
    {
        return state.axios;
    }
}

export default createStore({
    state : state , 
    mutations : mutations , 
    getters : getters , 
  
}) ; 
