import {Component }  from "angular2/core";
import {Router} from "angular2/router";
import {BasePage} from "../../../common/models/ui";
import {RolesModel} from "./rolesModel";
import roleService from "../_share/services/roleService";
import {Grid, PageActions, Page} from "../../../common/directive";
import {PageAction} from "../../../common/models/ui";
import route from "../_share/config/route";
@Component({
    templateUrl: "app/modules/security/role/roles.html",
    directives: [Grid, PageActions, Page]
})
export class Roles extends BasePage {
    public actions: Array<PageAction> = [];
    private router: Router;
    constructor(router: Router) {
        super();
        let self: Roles = this;
        self.router = router;
        self.model = new RolesModel(self.i18nHelper);
        self.loadRoles();
        this.model.addPageAction(new PageAction("btnAddRole", "security.roles.addRoleAction", () => self.onAddNewRoleClicked()));
    }
    private onAddNewRoleClicked() {
        this.router.navigate([route.role.addRole.name]);
    }
    public onEditRoleItemClicked(event: any) {
        this.router.navigate([route.role.editRole.name, { id: event.item.id }]);
    }
    public onDeleteRoleItemClicked(event: any) {
        let self: Roles = this;
        roleService.delete(event.item.id).then(function () {
            self.loadRoles();
        });
    }
    private loadRoles() {
        let self: Roles = this;
        roleService.getRoles().then(function (items: Array<any>) {
            self.model.importRoles(items);
        });
    }
}