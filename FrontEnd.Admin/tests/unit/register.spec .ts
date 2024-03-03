import { Register } from '@/views/Register/script';
const register = new Register();
    
describe('isPasswordEqual', () => {
  it('the password returns true if equals', () => {
    const password = '123';
    const confirmPassword = '123';
    const result = register.isPasswordEqual(password , confirmPassword); 
    expect(result).toBeTruthy()
  })
})

describe('isPasswordContainsUperCasedLetter', () => {
  it('the password returns true if contains atleast one uperCased letter', () => {
    const password = 'E123';
    const confirmPassword = '123';
    const result = register.isPasswordContainsUperCasedLetter(password , confirmPassword); 
    expect(result).toBeTruthy()
  })
})

describe('isPasswordContainsSpecialCharacter', () => {
  it('the password returns true if contains atleast one special character', () => {
    const password = '@123';
    const result = register.isPasswordContainsSpecialCharacter(password); 
    expect(result).toBeTruthy()
  })
})

describe('isPasswordValid', () => {
  it('the password returns true all the validations of password is valid', () => {
    const password = '@E123';
    const confirmPassword = '@E123';
    const result = register.isPasswordValid(password,confirmPassword); 
    expect(result).toBeTruthy()
  })
})