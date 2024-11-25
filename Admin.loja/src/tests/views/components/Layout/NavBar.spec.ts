import { expect, test , describe , beforeEach } from 'vitest';
import { mount} from '@vue/test-utils'
import NavBar from '@/components/Layout/NavBar/NavBar.vue'
import PrimeVue from 'primevue/config';
import { createRouter, createWebHistory } from 'vue-router'
import { routes } from "@/router/index.ts"


describe('navBar test', () => {

  const router = createRouter({
    history: createWebHistory(),
    routes: routes,
  })

  test('navBar is visible when route is different than /' ,async () => { 
    const wrapper = mount(NavBar, {
      global: {
        plugins: [PrimeVue, router],
      }
    })
    router.push('/sdsd')
    await router.isReady()

    expect(wrapper.find('.navBar-container').exists()).toBe(true)
  })
    
})