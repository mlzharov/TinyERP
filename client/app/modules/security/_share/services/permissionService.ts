import configHelper from "../../../../common/helpers/configHelper";
import {Promise} from "../../../../common/models/promise";
let permissionService = {
    getPermissions: getPermissions,
    create: create,
    delete: remove,
    get: get,
    update: update
};
export default permissionService;
function update(item: any): Promise {
    let connector = window.ioc.resolve("IConnector");
    let url = String.format("{0}permissions/{1}", configHelper.getAppConfig().api.baseUrl, item.id);
    return connector.put(url, item);
}
function get(id: any): Promise {
    let connector = window.ioc.resolve("IConnector");
    let url = String.format("{0}permissions/{1}", configHelper.getAppConfig().api.baseUrl, id);
    return connector.get(url);
}
function remove(id: any): Promise {
    let connector = window.ioc.resolve("IConnector");
    let url = String.format("{0}permissions/{1}", configHelper.getAppConfig().api.baseUrl, id);
    return connector.delete(url);
}
function getPermissions(): Promise {
    let connector = window.ioc.resolve("IConnector");
    let url = String.format("{0}permissions", configHelper.getAppConfig().api.baseUrl);
    return connector.get(url);
}
function create(per: any): Promise {
    let connector = window.ioc.resolve("IConnector");
    let url = String.format("{0}permissions", configHelper.getAppConfig().api.baseUrl);
    return connector.post(url, per);
}