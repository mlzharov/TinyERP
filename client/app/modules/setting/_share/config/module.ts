import {IModule, Module, MenuItem} from "../../../../common/models/layout";
import {AuthenticationMode} from "../../../../common/enum";

import {ContentTypes} from "../../contentType/contentTypes";
import {AddOrUpdateContentType} from "../../contentType/addOrUpdateContentType";
import route from "./route";

let module: IModule = createModule();
export default module;
function createModule() {
    let module = new Module("app/modules/settting", "settting");
    module.menus.push(
        new MenuItem(
            "Setting", route.setting.contentTypes.name, "fa fa-cogs",
            new MenuItem("ContentTypes", route.setting.contentTypes.name, "")
        )
    );
    module.addRoutes([
        { path: route.setting.contentTypes.path, name:  route.setting.contentTypes.name, component: ContentTypes, data: { authentication: AuthenticationMode.Require }},
        { path: route.setting.addContentType.path, name:  route.setting.addContentType.name, component: AddOrUpdateContentType, data: { authentication: AuthenticationMode.Require }},
        { path: route.setting.editContentType.path, name:  route.setting.editContentType.name, component: AddOrUpdateContentType, data: { authentication: AuthenticationMode.Require }}
    ]);
    return module;
}