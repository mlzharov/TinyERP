import {PromiseFactory} from "../models/promise";
import configHelper from "../helpers/configHelper";
import {Promise} from "../models/promise";

let permissionService = {
    getPermissions: getPermissions
};
export default permissionService;
function getPermissions(): Promise {
    let connector = window.ioc.resolve("IConnector");
    let url = String.format("{0}{1}", configHelper.getAppConfig().api.baseUrl, "permissions");
    return connector.get(url);
}