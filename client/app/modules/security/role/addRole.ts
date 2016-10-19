import {BasePage} from "../../../common/models/ui";
import {Router, RouteParams} from "angular2/router";
import {Component} from "angular2/core";
import {AddRoleModel} from "./addRoleModel";
import {Page, SelectPermission, Form, FormTextInput, FormFooter, FormTextArea, FormPermissionSelect} from "../../../common/directive";
import {ValidationDirective} from "../../../common/directive";
import roleService from "../_share/services/roleService";
import {FormMode} from "../../../common/enum";
import route from "../_share/config/route";
@Component({
    templateUrl: "app/modules/security/role/addRole.html",
    directives: [Page, Form, FormTextInput, FormFooter, FormTextArea, FormPermissionSelect]
})
export class AddRole extends BasePage {
    public model: AddRoleModel = new AddRoleModel();
    private router: Router;
    private mode: FormMode = FormMode.AddNew;
    private itemId: any;
    constructor(router: Router, routeParams: RouteParams) {
        super();
        let self: AddRole = this;
        self.router = router;
        if (!!routeParams.get("id")) {
            self.mode = FormMode.Edit;
            self.itemId = routeParams.get("id");
            roleService.get(self.itemId).then(function (roleItem: any) {
                self.model.import(roleItem);
            });
        }
    }
    public onSaveClicked(event: any): void {
        let self: AddRole = this;
        if (self.mode === FormMode.AddNew) {
            roleService.create(this.model).then(function () {
                self.router.navigate([route.role.roles.name]);
            });
            return;
        }
        roleService.update(this.model).then(function () {
            self.router.navigate([route.role.roles.name]);
        });
    }
    public onCancelClicked(event: any): void {
        let self: AddRole = this;
        self.router.navigate([route.role.roles.name]);
    }
    // public onPermissionAdded(per: any) {
    //     this.model.permissions.push(per.id);
    // }
    // public onPermissionRemoved(per: any) {
    //     this.model.permissions.removeItem(per.id);
    // }
}