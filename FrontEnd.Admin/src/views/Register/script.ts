export class Register {
    public isPasswordEqual(password, confirmPassword){
        return password !== confirmPassword ? false : true;
    }
    public isPasswordContainsUperCasedLetter(password){
        return password.toLowerCase() === password ? false : true;
    }

    public isPasswordContainsSpecialCharacter(password){
        let isValid = false;
        //does any character is a special character
        password.split('').forEach((value) => {
            //65 ~ 90 A-Z , 97 ~ 122 a-z
            isValid = ((value.charCodeAt(0) >= 65 && value.charCodeAt(0) <= 90)
                || (value.charCodeAt(0) >= 97 && value.charCodeAt(0) <= 122)) ? isValid : true;
        });
        return isValid;
    }
    public isPasswordLengthBiggerThanEight(password){
        return password.length >= 8 ? true : false;
    }
    public isPasswordValid(password , confirmPassword) {
        return this.isPasswordEqual(password, confirmPassword)
            && this.isPasswordContainsSpecialCharacter(password)
            && this.isPasswordContainsUperCasedLetter(confirmPassword)
            && this.isPasswordLengthBiggerThanEight(password);
    }
}
