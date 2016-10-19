import configHelper from "../../../../common/helpers/configHelper";
import authService from "../../../services/authService";
import {Promise} from "../../../../common/models/promise";

let userService = {
    signout: signout
};
export default userService;
function signout(): Promise {
    let token: string = authService.getAuth().token.value;
    let connector = window.ioc.resolve("IConnector");
    let url = String.format("{0}users/{1}/signout", configHelper.getAppConfig().api.baseUrl, token);
    return connector.post(url, null);
}