import { expect, test , describe , beforeEach , it } from 'vitest';
import { mount } from '@vue/test-utils'
import { setActivePinia, createPinia } from 'pinia'
import { useMainStore } from '@/pinia/mainStore';
import App from '@/App.vue'
import { useToast } from 'primevue/usetoast';
import { ToastSeverity } from '@/pinia/Interfaces/IConfigureToast';

describe('Dependency injection store', () => {
  beforeEach(() => {
    // creates a fresh pinia and makes it active
    // so it's automatically picked up by any useStore() call
    // without having to pass it to it: `useStore(pinia)`
    setActivePinia(createPinia())
    
    
  })

  test('test' , () => { 
    const store = useMainStore();

    const wrapper = mount(App)
    store.setToast(useToast())
    
    store.toast('message' , ToastSeverity.success );
    expect(wrapper.find('.messagecontent').exists()).toBe(true)
  
  })
})