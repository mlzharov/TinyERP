export class PageActionsModel {
    public default: any = {};
    public items: Array<any> = [];
    constructor(actions: Array<any>) {
        if (actions && actions.length > 0) {
            this.default = actions[0];
            actions.shift();
        }
        this.items = actions;
    }
}