import {IModule, Module, MenuItem} from "../../../../common/models/layout";

import {Roles} from "../../role/roles";
import {AddRole} from "../../role/addRole";

import {Permissions} from "../../permission/permissions";
import {AddPermission} from "../../permission/addPermission";

import {UserGroups} from "../../usergroup/userGroups";
import {AddUserGroup} from "../../usergroup/addUserGroup";

import {AuthenticationMode} from "../../../../common/enum";
import route from "./route";
let module: IModule = createModule();
export default module;
function createModule() {
    let module = new Module("app/modules/secutiry", "secutiry");
    module.menus.push(
        new MenuItem(
            "Security", route.role.roles.name, "fa fa-user-md",
            new MenuItem("Roles", route.role.roles.name, ""),
            new MenuItem("Permissions", route.permission.permissions.name, ""),
            new MenuItem("User Groups", route.userGroup.userGroups.name, "")
        )
    );
    module.addRoutes([
        { path: route.role.roles.path, name: route.role.roles.name, component: Roles, data: { authentication: AuthenticationMode.Require }, useAsDefault: true },
        { path: route.role.addRole.path, name: route.role.addRole.name, component: AddRole, data: { authentication: AuthenticationMode.Require } },
        { path: route.role.editRole.path, name: route.role.editRole.name, component: AddRole, data: { authentication: AuthenticationMode.Require } },

        { path: route.permission.permissions.path, name: route.permission.permissions.name, component: Permissions, data: { authentication: AuthenticationMode.Require } },
        { path: route.permission.addPermission.path, name: route.permission.addPermission.name, component: AddPermission, data: { authentication: AuthenticationMode.Require } },
        { path: route.permission.editPermission.path, name: route.permission.editPermission.name, component: AddPermission, data: { authentication: AuthenticationMode.Require } },

        { path: route.userGroup.userGroups.path, name: route.userGroup.userGroups.name, component: UserGroups, data: { authentication: AuthenticationMode.Require } },
        { path: route.userGroup.addUserGroup.path, name: route.userGroup.addUserGroup.name, component: AddUserGroup, data: { authentication: AuthenticationMode.Require } },
        { path: route.userGroup.editUserGroup.path, name: route.userGroup.editUserGroup.name, component: AddUserGroup, data: { authentication: AuthenticationMode.Require } }
    ]);
    return module;
}