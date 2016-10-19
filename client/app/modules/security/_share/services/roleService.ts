import configHelper from "../../../../common/helpers/configHelper";
import {Promise} from "../../../../common/models/promise";
let roleServices = {
    getRoles: getRoles,
    create: create,
    update: update,
    delete: remove,
    get: get
};
export default roleServices;
function getRoles(): Promise {
    let connector = window.ioc.resolve("IConnector");
    let url = String.format("{0}roles", configHelper.getAppConfig().api.baseUrl);
    return connector.get(url);
}
function get(id: any): Promise {
    let connector = window.ioc.resolve("IConnector");
    let url = String.format("{0}roles/{1}", configHelper.getAppConfig().api.baseUrl, id);
    return connector.get(url);
}
function create(role: any): Promise {
    let connector = window.ioc.resolve("IConnector");
    let url = String.format("{0}roles", configHelper.getAppConfig().api.baseUrl);
    return connector.post(url, role);
}
function update(role: any): Promise {
    let connector = window.ioc.resolve("IConnector");
    let url = String.format("{0}roles/{1}", configHelper.getAppConfig().api.baseUrl, role.id);
    return connector.put(url, role);
}
function remove(id: any): Promise {
    let connector = window.ioc.resolve("IConnector");
    let url = String.format("{0}roles/{1}", configHelper.getAppConfig().api.baseUrl, id);
    return connector.delete(url);
}