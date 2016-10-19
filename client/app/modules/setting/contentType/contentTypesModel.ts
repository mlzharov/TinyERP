import {ItemStatus} from "../../../common/enum";
export class Model {
    public options: any = {};
    public eventKey: string = "contenttypes_ondatasource_changed";
    public actions: Array<any> = [];
    constructor(resourceHelper: any) {
        this.options = {
            columns: [
                { field: "name", title: resourceHelper.resolve("setting.contentTypes.grid.name") },
                { field: "key", title: resourceHelper.resolve("setting.contentTypes.grid.name") },
                { field: "description", title: resourceHelper.resolve("setting.contentTypes.grid.description") }
            ],
            data: [],
            enableEdit: true,
            enableDelete: true
        };
    }
    public addPageAction(action: any) {
        this.actions.push(action);
    }
    public import(items: Array<any>) {
        let eventManager = window.ioc.resolve("IEventManager");
        eventManager.publish(this.eventKey, items);
    }
}