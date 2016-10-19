import {UserLoginModel} from "../../users/userLoginModel";
import {PromiseFactory} from "../../../../common/models/promise";
import configHelper from "../../../../common/helpers/configHelper";
import {Promise} from "../../../../common/models/promise";

let userService = {
    signin: signin
};
export default userService;
function signin(signinModel: UserLoginModel): Promise {
    let connector = window.ioc.resolve("IConnector");
    let url = getAPISigninUrl();
    return connector.post(url, signinModel);
}
function getAPISigninUrl(): string {
    return configHelper.getAppConfig().api.baseUrl + "users/signin";
}