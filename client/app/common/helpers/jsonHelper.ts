let jsonHelper = {
    parse: parse
};
export default jsonHelper;
function parse(str: string) {
    return JSON.parse(str);
}