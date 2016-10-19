import {HttpStatusCode} from "../enum";
let httpHelper = {
    isSuccessStatusCode: isSuccesssStatusCode,
    resolve: resolve
};
export default httpHelper;
function resolve(statusCode: number) {
    let errorString = "common.httpError.genericError";
    switch (statusCode) {
        case 404:
        default:
            errorString = "common.httpError.notFound";
    }
    return errorString;
}
function isSuccesssStatusCode(statusCode: number) {
    return statusCode === HttpStatusCode.OK;
}