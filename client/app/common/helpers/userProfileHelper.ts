import {CACHE_CONSTANT} from "../services/cacheService";
import cacheService from "../services/cacheService";
import configHelper from "./configHelper";

let userProfileHelper: any = {
    getLang: getLang
};
export default userProfileHelper;
function getLang() {
    let defaultLang: string = configHelper.getAppConfig().localization.lang;

    if (!cacheService.exist(CACHE_CONSTANT.USER_PROFILE)) {
        return defaultLang;
    }
    let userProfile = cacheService.get(CACHE_CONSTANT.USER_PROFILE);
    return !!userProfile.lang && !String.isNullOrWhiteSpace(userProfile.lang) ? userProfile.languageCode : defaultLang;
}
