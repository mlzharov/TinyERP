import {Component, Input}  from "angular2/core";
import {Router} from "angular2/router";
import {ProfileDisplayMode} from "../../../../models/layout";
import authService from "../../../../services/authService";
import userService from "../../services/userService";
import configHelper from "../../../../helpers/configHelper";
import {AuthenticatedEvent} from "../../../../event";
import {BaseControl} from "../../../../models/ui";
@Component({
    selector: "user-quick-profile-info",
    templateUrl: "app/common/layouts/default/directives/users/quickProfileInfo.html"
})
export class UserQuickProfileInfo extends BaseControl {
    public userProfile: any = null;
    private router: Router;
    private authService: any;
    constructor(router: Router) {
        super();
        this.router = router;
        this.displayMode = ProfileDisplayMode.Quick;
        this.authService = authService;
        this.userProfile = this.authService.getUserProfile();
    }
    public ProfileDisplayMode: any = ProfileDisplayMode;
    @Input() public displayMode: ProfileDisplayMode;
    public onLogOutClicked(): boolean {
        let self: UserQuickProfileInfo = this;
        userService.signout().then(function (logoutResult: any) {
            self.authService.removeAuth();
            self.eventManager.publish(AuthenticatedEvent.AuthenticationChanged, false);
            self.router.navigate([configHelper.getAppConfig().loginUrl]);
        });
        return false;
    }
}