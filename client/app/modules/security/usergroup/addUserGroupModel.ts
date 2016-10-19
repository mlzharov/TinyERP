import {KeyNamePair} from "../../../common/models/keyNamePair";
export class AddUserGroupModel {
     public id: string = String.empty;
    public name: string = String.empty;
    public description: string = String.empty;
    public permissionIds: Array<KeyNamePair>;
    constructor(data: any = {}) {
        this.permissionIds = !!data.permissionIds ? data.permissionIds : [];
        this.name = data.name;
        this.description = data.description;
    }
    public import(item: any) {
        this.id = item.id;
        this.name = item.name;
        this.description = item.description;
        this.permissionIds = item.permissionIds;
    }
}