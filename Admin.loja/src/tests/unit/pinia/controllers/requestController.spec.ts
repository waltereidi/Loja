import { expect, test } from 'vitest'
import { RequestController } from '@/pinia/Controllers/requestController'
import { LogSeverity } from '@/pinia/Dto/Log';

const request = new RequestController();
test('add log returns has error when add success false log', () => {
    
    const result = request.get('http://testCase.com')
    
})
test('curry' ,() =>{

    expect(request.postCurry('')('')('')).toBe('')

})
