import {Component }  from "angular2/core";
import {Router} from "angular2/router";
import {BasePage} from "../../../common/models/ui";
import {UserGroupsModel} from "./userGroupsModel";
import securityService from "../_share/services/securityService";
import {Grid, PageActions, Page} from "../../../common/directive";
import {PageAction} from "../../../common/models/ui";
import route from "../_share/config/route";
@Component({
    templateUrl: "app/modules/security/userGroup/userGroups.html",
    directives: [Grid, PageActions, Page]
})
export class UserGroups extends BasePage {
    public actions: Array<PageAction> = [];
    private router: Router;
    constructor(router: Router) {
        super();
        let self: UserGroups = this;
        self.router = router;
        self.model = new UserGroupsModel(this.i18nHelper);
        self.reload();
        this.model.addPageAction(new PageAction("btnAddUserGroup", "security.userGroups.addUserGroupAction", () => self.onAddNewUserGroupClicked()));
    }
    private onAddNewUserGroupClicked() {
        this.router.navigate([route.userGroup.addUserGroup.name]);
    }
    public onEditItemClicked(event: any) {
        this.router.navigate([route.userGroup.editUserGroup.name, { id: event.item.id }]);
    }
    public onDeleteItemClicked(event: any) {
        let self: UserGroups = this;
        securityService.deleteUserGroup(event.item.id).then(function () {
            self.reload();
        });
    }
    private reload() {
        let self: UserGroups = this;
        securityService.getUserGroups().then(function (items: Array<any>) {
            self.model.import(items);
        });
    }
}