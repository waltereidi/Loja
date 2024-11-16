import { expect, test } from 'vitest'
import { RequestController } from '@/pinia/Controllers/requestController'

const request = new RequestController();
test('request post returns a result',async () => {
    
    const res =await request.post('https://testCase.com' , null )
    //console.log(res)
    expect(res.status).to.not.toBeNull()
})
test('request get returns a result',async () => {
    
    const res =await request.get('https://testCase.com' )
    //console.log(res)
    expect(res.status).to.not.toBeNull()
})
test('request get returns a result',async () => {
    
    const res =await request.put('https://testCase.com' ,null)
    //console.log(res)
    expect(res.status).to.not.toBeNull()
})
test('request get returns a result',async () => {
    
    const res =await request.delete('https://testCase.com' )
    //console.log(res)
    expect(res.status).to.not.toBeNull()
})