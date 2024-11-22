import { expect, test , describe , beforeEach } from 'vitest';
import { mount } from '@vue/test-utils'
import { setActivePinia, createPinia } from 'pinia'
import { useMainStore } from '@/pinia/mainStore';
import Toast from 'primevue/toast';

import App from '@/App.vue'

describe('Dependency injection store', () => {
  beforeEach(() => {
    // creates a fresh pinia and makes it active
    // so it's automatically picked up by any useStore() call
    // without having to pass it to it: `useStore(pinia)`
    setActivePinia(createPinia())
    
    
  })

  test('test' ,async () => { 
    const store = useMainStore();
    const wrapper = mount(App)
     
    expect(wrapper.find('.messagecontent').exists()).toBe(true)
    
  
  })
    
  
  
  })