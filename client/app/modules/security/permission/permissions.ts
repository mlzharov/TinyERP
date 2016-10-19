import {Component }  from "angular2/core";
import {Router} from "angular2/router";
import {BasePage} from "../../../common/models/ui";
import {PermissionsModel} from "./permissionsModel";
import permissionService from "../_share/services/permissionService";
import {Grid, PageActions, Page} from "../../../common/directive";
import {PageAction} from "../../../common/models/ui";
import route from "../_share/config/route";
@Component({
    selector: "roles",
    templateUrl: "app/modules/security/permission/permissions.html",
    directives: [Grid, PageActions, Page]
})
export class Permissions extends BasePage {
    private router: Router;
    public model: PermissionsModel;
    constructor(router: Router) {
        super();
        let self: Permissions = this;
        self.router = router;
        self.model = new PermissionsModel(self.i18nHelper);
        self.loadPermissions();
        this.model.addPageAction(new PageAction("btnAddPer", "security.permissions.addPermissionAction", () => self.onAddNewPermissionClicked()));
    }
    private onAddNewPermissionClicked() {
        this.router.navigate([route.permission.addPermission.name]);
    }
    public onEditItemClicked(event: any) {
        this.router.navigate([route.permission.editPermission.name, { id: event.item.id }]);
    }
    public onDeleteItemClicked(event: any) {
        let self: Permissions = this;
        permissionService.delete(event.item.id).then(function () {
            self.loadPermissions();
        });
    }
    private loadPermissions() {
        let self: Permissions = this;
        permissionService.getPermissions().then(function (items: Array<any>) {
            self.model.importPermissions(items);
        });
    }
}