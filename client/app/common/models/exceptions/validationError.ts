export class ValidationError {
    constructor(key: string, params: any) {
        this.key = key;
        this.params = params;
        this.msg = "";
    }
    public key: string = undefined;
    public params: any = {};
    public msg: string = "";
}