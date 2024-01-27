import { Module, createStore } from 'vuex';
import { EnumMessageType, MessageInterface, State } from './Entity/store';
import { RequestController } from '@/store/Controllers/requestController';

const state :State={
    message: [],
    login : null,
    navMenu: false,  
    requestController:new RequestController(),
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
    getRequestController(state:State)
    {
        return state.requestController;
    }
}

export default createStore({
    state : state , 
    mutations : mutations , 
    getters : getters , 
  
}) ; 
