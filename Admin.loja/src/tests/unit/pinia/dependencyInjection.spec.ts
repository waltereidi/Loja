import { expect, test , describe , beforeEach , it } from 'vitest';
import { DepencyInjectionController } from '@/pinia/Controllers/dependencyInjectionController'
import { RequestController } from '@/pinia/Controllers/requestController';

it( 'di returns request controller'  , ()=>{

  const di = new DepencyInjectionController('request')
  const request = di.getService();
  
  expect(request).toBeInstanceOf(RequestController)

})