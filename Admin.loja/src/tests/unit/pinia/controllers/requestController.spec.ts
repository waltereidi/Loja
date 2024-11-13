import { expect, test } from 'vitest'
import { RequestController } from '@/pinia/Controllers/requestController'
import { LogSeverity } from '@/pinia/Dto/Log';

test('add log returns has error when add success false log', () => {
    const request = new RequestController();
    const result = request.get('http://testCase.com')
        .then((result) =>expect( result.status).toBe(200))
    
    

    
})
