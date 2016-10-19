import configHelper from "../../../../common/helpers/configHelper";
import {Promise} from "../../../../common/models/promise";
let securityService = {
    getUserGroups: getUserGroups,
    createUserGroup: createUserGroup,
    deleteUserGroup: deleteUserGroup,
    getUserGroup: getUserGroup,
    updateUserGroup: updateUserGroup
};
export default securityService;
function updateUserGroup(item: any): Promise {
    let connector = window.ioc.resolve("IConnector");
    let url = String.format("{0}userGroups/{1}", configHelper.getAppConfig().api.baseUrl, item.id);
    return connector.put(url, item);
}
function getUserGroup(id: any): Promise {
    let connector = window.ioc.resolve("IConnector");
    let url = String.format("{0}userGroups/{1}", configHelper.getAppConfig().api.baseUrl, id);
    return connector.get(url);
}
function getUserGroups(): Promise {
    let connector = window.ioc.resolve("IConnector");
    let url = String.format("{0}userGroups", configHelper.getAppConfig().api.baseUrl);
    return connector.get(url);
}
function createUserGroup(item: any): Promise {
    let connector = window.ioc.resolve("IConnector");
    let url = String.format("{0}userGroups", configHelper.getAppConfig().api.baseUrl);
    return connector.post(url, item);
}

function deleteUserGroup(id: any): Promise {
    let connector = window.ioc.resolve("IConnector");
    let url = String.format("{0}usergroups/{1}", configHelper.getAppConfig().api.baseUrl, id);
    return connector.delete(url);
}