export class PermissionsModel {
    public options: any = {};
    public eventKey: string = "permissions_ondatasource_changed";
    public actions: Array<any> = [];
    constructor(resourceHelper: any) {
        this.options = {
            columns: [
                { field: "name", title: resourceHelper.resolve("security.permissions.grid.name"), index: 0 },
                { field: "key", title: resourceHelper.resolve("security.permissions.grid.key"), index: 1 },
                { field: "description", title: resourceHelper.resolve("security.permissions.grid.description"), index: 2 }
            ],
            data: [],
            enableEdit: true,
            enableDelete: true
        };
    }
    public addPageAction(action: any) {
        this.actions.push(action);
    }
    public importPermissions(items: Array<any>) {
        let eventManager = window.ioc.resolve("IEventManager");
        eventManager.publish(this.eventKey, items);
    }
}