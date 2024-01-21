import { Module, createStore } from 'vuex';
import { StoreController } from './Controllers/storeController';
import { EnumMessageType , MessageInterface , StoreConfig , State } from './Entity/store';

const storeController = new StoreController() ; 

const state :State={
  message : [] ,
  appConfig : storeController.getAppConfig() ,
  navMenu : false ,  
};

const mutations = {
  test(state:State )
  {
    state.appConfig.authorization ='Bearer Token';
  }, 
  openMenu(state:State)
  {
    state.navMenu = true; 
  },
  closeMenu(state:State)
  {
    state.navMenu = false; 
  }
};

const getters = {
  getAuthorization(state:State)
  {
    return state.appConfig.authorization;
  },
  getNavMenu(state:State) : boolean
  {
    return state.navMenu ; 
  }
}

export default createStore({
  state : state , 
  mutations : mutations , 
  getters : getters , 
  
}) ; 
