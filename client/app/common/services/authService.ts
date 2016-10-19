import {PromiseFactory} from "../models/promise";
import {CACHE_CONSTANT} from "./cacheService";
import cacheService from "./cacheService";
let authService: any = {
    getUserProfile: getUserProfile,
    setAuth: setAuth,
    getAuth: getAuth,
    removeAuth: removeAuth,
    isAuthenticated: isAuthenticated,
    isAuthorized: isAuthorized
};
export default authService;
function isAuthorized(routeInstruction: any) {
    let profile = getUserProfile();
    return isAuthenticated(profile);
}
function removeAuth(): void {
    cacheService.remove(CACHE_CONSTANT.USER_PROFILE);
    cacheService.remove(CACHE_CONSTANT.TOKEN);
}
function isAuthenticated(profile: any) {
    return !!profile;
}
function setAuth(auth: any) {
    cacheService.set(CACHE_CONSTANT.USER_PROFILE, auth.profile);
    cacheService.set(CACHE_CONSTANT.TOKEN, auth.token);
    console.log("Token", cacheService.get(CACHE_CONSTANT.TOKEN));
}
function getAuth(): any {
    let auth: any = {
        profile: cacheService.get(CACHE_CONSTANT.USER_PROFILE),
        token: cacheService.get(CACHE_CONSTANT.TOKEN)
    };
    return auth;
}
function getUserProfile(): any {
    if (!cacheService.exist(CACHE_CONSTANT.USER_PROFILE)) {
        return null;
    }
    let userProfile = cacheService.get(CACHE_CONSTANT.USER_PROFILE);
    return userProfile;
}