import { expect, test , describe , beforeEach } from 'vitest';
import { mount} from '@vue/test-utils'
import NavBar from '@/components/Layout/NavBar.vue'
import PrimeVue from 'primevue/config';

describe('Header test', () => {

  test('test' ,async () => { 

    type toastComponent = Record<string, object>;
    const com:toastComponent = {
      "Toast": Toast
    }

    const wrapper = mount(Header, {
      global: {
        plugins: [PrimeVue],
        
        components: { com },
        
      },


    })
    wrapper.
     
    expect(wrapper.find('.messagecontent').exists()).toBe(true)
    
  
  })
    
  
  
  })