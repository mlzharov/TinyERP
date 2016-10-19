import {Route, MenuItem, IModule} from "../models/layout";
import appConfig from "../../config/appConfig";
let configHelper = {
    getModuleMenuItems: getModuleMenuItems,
    getRoutes: getRoutes,
    getAppConfig: getAppConfig
};
export default configHelper;
function getAppConfig() {
    return appConfig;
}
function getRoutes() {
    let items: any = [];
    appConfig.modules.forEach(function (module: IModule) {
        items = items.concat(module.routes);
    });
    return items;
}
function getModuleMenuItems(): Array<MenuItem> {
    let items: Array<MenuItem> = new Array<MenuItem>();
    appConfig.modules.forEach(function (module: IModule) {
        items = appendModuleMenuItems(items, module);
    });
    return items;
}
function appendModuleMenuItems(items: Array<MenuItem>, module: IModule) {
    module.menus.forEach(function (menuItem: any) {
        console.log(menuItem.text);
        items.push(menuItem);
    });
    return items;
}