import {KeyNamePair} from "../../../common/models/keyNamePair";
export class AddPermissionModel {
    public id: string = String.empty;
    public name: string = String.empty;
    public description: string = String.empty;
    public key: string = String.empty;
    constructor(data: any = {}) {
        this.key = data.key;
        this.name = data.name;
        this.description = data.description;
    }
    public import(item: any) {
        this.id = item.id;
        this.name = item.name;
        this.key = item.key;
        this.description = item.description;
    }
}