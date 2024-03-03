export class Register {
    public isPasswordEqual(password, confirmPassword){
        return password !== confirmPassword ? false : true;
    }
    public isPasswordContainsUperCasedLetter(password, confirmPassword){
        return password.toLowerCase() === confirmPassword ? false : true;
    }

    public isPasswordContainsSpecialCharacter(password){
        let isValid = false;
        //does any character is a special character
        password.split().forEach((value) => {
            //65 ~ 90 A-Z , 97 ~ 122 a-z
            isValid = value.charAt(0) >= 65 && value.charAt(0) <= 90
                || value.charAt(0) >= 97 && value.charAt(0) <= 122 ? isValid : true;
        });
        return isValid;
    }
    public isPasswordValid(password , confirmPassword) {
        return this.isPasswordEqual(password, confirmPassword)
            && this.isPasswordContainsSpecialCharacter(password)
            && this.isPasswordContainsUperCasedLetter(password, confirmPassword);
    }
}
