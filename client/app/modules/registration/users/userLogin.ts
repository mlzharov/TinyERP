import {Component}  from "angular2/core";
import {UserLoginModel} from "./userLoginModel";
import {Router} from "angular2/router";

import userService from "../_share/services/userService";
import configHelper from "../../../common/helpers/configHelper";
import authService from "../../../common/services/authService";
import {AuthenticatedEvent, CommonEvent} from "../../../common/event";
import {ValidationException} from "../../../common/models/exception";
import {BasePage} from "../../../common/models/ui";
import {ValidationDirective} from "../../../common/directive";

@Component({
    selector: "user-login",
    templateUrl: "app/modules/registration/users/userLogin.html",
    directives: [ValidationDirective]
})
export class UserLogin extends BasePage {
    public model: UserLoginModel = new UserLoginModel();
    private router: Router;
    constructor(router: Router) {
        super();
        this.router = router;
        // this.setResources(["signin"]);
        // this.i18n.load(['signin']);
    }
    public onForgotPasswordClicked(event: any) {
        // this.router.navigate(["Forgot Password"]);
        // console.log(this.i18n.resolve('signin.yourEmail'));
    }
    public onSignInClicked(event: any) {
        let self: UserLogin = this;
        if (!this.model.isValid()) { return; }
        userService.signin(this.model).then(function (token: any) {
            authService.setAuth(token);
            self.eventManager.publish(AuthenticatedEvent.AuthenticationChanged, true);
            self.router.navigate([configHelper.getAppConfig().defaultUrl]);
        });
        return false;
    }
}