import sessionStorage from "../storages/sessionStorage";
export const CACHE_CONSTANT: any = {
    USER_PROFILE: "user_profile",
    TOKEN: "token"
};
let cacheService: any = {
    get: get,
    exist: exist,
    set: set,
    remove: remove
};
export default cacheService;
function remove(key: string) {
    sessionStorage.remove(key);
}
function exist(key: string): boolean {
    return sessionStorage.exist(key);
}
function get(key: string): any {
    return sessionStorage.get(key);
}
function set(key: string, data: any): any {
    return sessionStorage.set(key, data);
}