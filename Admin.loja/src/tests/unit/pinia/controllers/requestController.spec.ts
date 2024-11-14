import { expect, test } from 'vitest'
import { RequestController } from '@/pinia/Controllers/requestController'
import { LogSeverity } from '@/pinia/Dto/Log';

const request = new RequestController();
test('request get returns a result', () => {
    
    const result = request.get('http://testCase.com')
        .then((result)=>console.log(result))
    
})
