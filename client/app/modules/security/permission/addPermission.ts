import {BasePage} from "../../../common/models/ui";
import {Router, RouteParams} from "angular2/router";
import {Component} from "angular2/core";
import {AddPermissionModel} from "./addPermissionModel";
import {Page, SelectPermission} from "../../../common/directive";
import {ValidationDirective} from "../../../common/directive";
import permissionService from "../_share/services/permissionService";
import {FormMode} from "../../../common/enum";
import route from "../_share/config/route";

@Component({
    templateUrl: "app/modules/security/permission/addPermission.html",
    directives: [ValidationDirective, Page]
})
export class AddPermission extends BasePage {
    public model: AddPermissionModel = new AddPermissionModel();
    private router: Router;
    private mode: FormMode = FormMode.AddNew;
    private itemId: any;
    constructor(router: Router, routeParams: RouteParams) {
        super();
        let self: AddPermission = this;
        self.router = router;
        if (!!routeParams.get("id")) {
            self.mode = FormMode.Edit;
            self.itemId = routeParams.get("id");
            permissionService.get(self.itemId).then(function (item: any) {
                self.model.import(item);
            });
        }
    }
    public onSaveClicked(event: any): void {
        let self: AddPermission = this;
        if (self.mode === FormMode.AddNew) {
            permissionService.create(this.model).then(function () {
                self.router.navigate([route.permission.permissions.name]);
            });
            return;
        }
        permissionService.update(this.model).then(function () {
            self.router.navigate([route.permission.permissions.name]);
        });
    }
    public onCancelClicked(event: any): void {
        let self: AddPermission = this;
        self.router.navigate([route.permission.permissions.name]);
    }

}