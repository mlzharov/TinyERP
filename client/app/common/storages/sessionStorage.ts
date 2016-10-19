let sessionStorage: any = {
    exist: exist,
    get: get,
    set: set,
    remove: remove
};
export default sessionStorage;

function exist(key: string): boolean {
    return window.sessionStorage.getItem(key) != null;
}
function remove(key: string) {
    window.sessionStorage.removeItem(key);
}
function set(key: string, data: any) {
    window.sessionStorage.setItem(key, JSON.stringify(data));
}
function get(key: string): any {
    if (!exist(key)) {
        return null;
    }
    let data: any = window.sessionStorage.getItem(key);
    return JSON.parse(data);
}