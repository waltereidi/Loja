import { Module, createStore } from 'vuex';
import { StoreController } from './Controllers/storeController';
import { EnumMessageType, MessageInterface, AppSettings , State , HttpHeaders } from './Entity/store';
import { RequestController } from '@/store/Controllers/requestController';
import appSettings from 'appsettings.json' assert { type: 'json' };
const storeController = new StoreController() ; 

const state :State={
  message : [] ,
  appConfig : appSettings ,
  navMenu : false ,  
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
  
};

const getters = {
  getNavMenu(state:State) : boolean
  {
    return state.navMenu ; 
  },
  request(state: State)
  {
        return null;
  }
}

export default createStore({
  state : state , 
  mutations : mutations , 
  getters : getters , 
  
}) ; 
