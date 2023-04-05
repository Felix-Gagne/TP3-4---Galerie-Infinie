export class RegisterDTO{
    constructor(public username : string,
        public email : string,
        public password : string,
        public passwordConfirm : string){}
}