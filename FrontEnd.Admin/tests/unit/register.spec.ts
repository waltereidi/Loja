  import { expect, test } from 'vitest';
import { Register } from '../../src/views/Register/script';

let register = new Register();

test('isPasswordValid', () => {
    const password = '@E123';
    const confirmPassword = '@E123';
    const result = register.isPasswordValid(password,confirmPassword); 
    expect(result).toBe(true)
})

