export class PageAction {
    public key: string = String.empty;
    public id: string = String.empty;
    public handler: (sender: any, args: any) => void;
    constructor(id: string, key: string, handler: any) {
        this.id = id;
        this.key  = key;
        this.handler  = handler;
    }
}