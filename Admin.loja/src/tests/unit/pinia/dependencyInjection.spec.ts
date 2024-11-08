import { expect, test , describe , beforeEach , it } from 'vitest';
import { useDi } from '@/pinia/dependencyInjection'
import { setActivePinia, createPinia } from 'pinia'

import { RequestController } from '@/pinia/Controllers/requestController';

describe('Dependency injection store', () => {
  beforeEach(() => {
    // creates a fresh pinia and makes it active
    // so it's automatically picked up by any useStore() call
    // without having to pass it to it: `useStore(pinia)`
    setActivePinia(createPinia())
  })

  it('returns instanced request controller', () => {
    const di = useDi()
    const request = di.getRequestController
    expect(request).toBeInstanceOf(RequestController)
  })

})