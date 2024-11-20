import { expect, test , describe , beforeEach , it } from 'vitest';
import { mount } from "@vue/test-utils";
import { setActivePinia, createPinia } from 'pinia'
import App from '@/App.vue'
import { RequestController } from '@/pinia/Controllers/requestController';

describe('Dependency injection store', () => {
  beforeEach(() => {
    // creates a fresh pinia and makes it active
    // so it's automatically picked up by any useStore() call
    // without having to pass it to it: `useStore(pinia)`
    setActivePinia(createPinia())

    const wrapper = mount(App, {})

    expect(wrapper.html()).toContain('Hello world')
  })

})