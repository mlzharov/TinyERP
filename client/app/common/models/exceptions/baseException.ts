export class BaseException {
    constructor(key: string, msg: string) {
        this.key = key;
        this.msg = msg;
    }
    public key: string;
    public msg: string;
}