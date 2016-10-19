export class UserGroupsModel {
    public options: any = {};
    public eventKey: string = "userGroups_ondatasource_changed";
    public actions: Array<any> = [];
    constructor(i18nHelper: any) {

        this.options = {
            columns: [
                { field: "name", title: i18nHelper.resolve("security.userGroups.grid.name"), index: 0 },
                { field: "key", title: i18nHelper.resolve("security.userGroups.grid.key"), index: 1 },
                { field: "description", title: i18nHelper.resolve("security.userGroups.grid.description"), index: 2 }
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