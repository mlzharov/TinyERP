import {Input, provide, Component} from "angular2/core";
import {Http} from "angular2/http";
import {Router, ROUTER_DIRECTIVES, ROUTER_PROVIDERS} from "angular2/router";
import {PageFooter, UserQuickProfileInfo, MenuItem as MenuItemDir, MenuSidebar, SidebarFooter} from "./directives/all";

import {MenuItem} from "../../models/layout";
import {ProfileDisplayMode} from "../../models/layout";
import {ErrorMessage} from "../../../common/layouts/default/directives/common/errorMessage";
import {BaseApplication} from "../../models/ui";
@Component({
    selector: "default-authenticated-layout",
    templateUrl: "app/common/layouts/default/authenticatedLayout.html",
    directives: [
        ROUTER_DIRECTIVES, PageFooter, UserQuickProfileInfo,
        MenuItemDir, MenuSidebar, SidebarFooter, ErrorMessage
    ]
})
export class DefaultAuthenticatedLayout extends BaseApplication {
    @Input() isAuthenticated: boolean;
    public ProfileDisplayMode: any = ProfileDisplayMode;
    private router: Router;
    constructor(http: Http, router: Router) {
        super(http);
        this.router = router;
    }
    protected onReady() {
        super.onReady();
        // this.router.navigate(["Login"]);
    }
}
