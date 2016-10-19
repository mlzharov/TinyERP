import configHelper from "../../../../common/helpers/configHelper";
import {Promise} from "../../../../common/models/promise";
let service = {
    getContentTypes: getContentTypes,
    deleteContentType: deleteContentType,
    getContentType: getContentType,
    createContentType: createContentType,
    updateContentType: updateContentType
};
export default service;
function getContentTypes(): Promise {
    let connector = window.ioc.resolve("IConnector");
    let url = String.format("{0}contenttypes", configHelper.getAppConfig().api.baseUrl);
    return connector.get(url);
}
function deleteContentType(id: any): Promise {
    let connector = window.ioc.resolve("IConnector");
    let url = String.format("{0}contenttypes/{1}", configHelper.getAppConfig().api.baseUrl, id);
    return connector.delete(url);
}

function getContentType(itemId: any): Promise {
    let connector = window.ioc.resolve("IConnector");
    let url = String.format("{0}contenttypes/{1}", configHelper.getAppConfig().api.baseUrl, itemId);
    return connector.get(url);
}
function createContentType(model: any): Promise {
    let connector = window.ioc.resolve("IConnector");
    let url = String.format("{0}contenttypes", configHelper.getAppConfig().api.baseUrl);
    return connector.post(url, model);
}
function updateContentType(item: any): Promise {
    let connector = window.ioc.resolve("IConnector");
    let url = String.format("{0}contenttypes/{1}", configHelper.getAppConfig().api.baseUrl, item.id);
    return connector.put(url, item);
}