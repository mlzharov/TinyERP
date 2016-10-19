import {KeyNamePair} from "../../../common/models/keyNamePair";
export class AddRoleModel {
    public name: string = String.empty;
    public description: string = String.empty;
    public id: string = String.empty;
    public permissions: Array<string> = [];
    public import(item: any) {
        if (!item) { return; }
        this.id = item.id;
        this.name = item.name;
        this.description = item.description;
        this.permissions = !!item.permissions ? item.permissions : [];
        // this.permissions = item.permissions;
    }
}