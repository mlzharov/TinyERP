import {BasePage} from "../../../common/models/ui";
import {Router, RouteParams} from "angular2/router";
import {Component} from "angular2/core";
import {AddUserGroupModel} from "./addUserGroupModel";
import {SelectPermission} from "../../../common/directive";
import {ValidationDirective, Page} from "../../../common/directive";
import securityService from "../_share/services/securityService";
import {FormMode} from "../../../common/enum";
import route from "../_share/config/route";
@Component({
    templateUrl: "app/modules/security/userGroup/addUserGroup.html",
    directives: [SelectPermission, ValidationDirective, Page]
})
export class AddUserGroup extends BasePage {
    public model: AddUserGroupModel = new AddUserGroupModel();
    private router: Router;
    private mode: FormMode = FormMode.AddNew;
    private itemId: any;
    constructor(router: Router, routeParams: RouteParams) {
        super();
        let self: AddUserGroup = this;
        self.router = router;
        if (!!routeParams.get("id")) {
            self.mode = FormMode.Edit;
            self.itemId = routeParams.get("id");
            securityService.getUserGroup(self.itemId).then(function (roleItem: any) {
                self.model.import(roleItem);
            });
        }
    }
    public onSaveClicked(event: any): void {
        let self: AddUserGroup = this;

        if (self.mode === FormMode.AddNew) {
            securityService.createUserGroup(this.model).then(function () {
                self.router.navigate([route.userGroup.userGroups.name]);
            });
            return;
        }
        securityService.updateUserGroup(this.model).then(function () {
            self.router.navigate([route.userGroup.userGroups.name]);
        });
    }
    public onCancelClicked(event: any): void {
        let self: AddUserGroup = this;
        self.router.navigate([route.userGroup.userGroups.name]);
    }

    public onPermissionAdded(per: any) {
        this.model.permissionIds.push(per.id);
    }
    public onPermissionRemoved(per: any) {
        this.model.permissionIds.removeItem(per.id);
    }

}