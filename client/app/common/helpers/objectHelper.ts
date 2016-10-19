let objectHelper = {
    getByPath: getByPath
};
export default objectHelper;
function getByPath(object: any, path: string) {
    let pathItems: Array<string> = path.split(".");
    let value = object;
    pathItems.forEach(element => {
        value = value[element];
    });
    return value;
}