let regexHelper = {
    isMatch: isMatch
};
export default regexHelper;
function isMatch(pattern: string, value: string) {
    let regex = new RegExp(pattern);
    return regex.test(value);
}