import {ValidationException} from "../../../common/models/exception";
export class UserLoginModel {
    public email: string = "";
    public pwd: string = "";
    public isValid(): boolean {
        let validationErrors: ValidationException = new ValidationException();
        if (!this.email) {
            validationErrors.add("registration.signin.emailRequired");
        }
        if (!this.pwd) {
            validationErrors.add("registration.signin.pwdRequired");
        }
        validationErrors.throwIfHasError();
        return !validationErrors.hasError();
    }
}