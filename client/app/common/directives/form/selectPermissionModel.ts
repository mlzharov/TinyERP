import {KeyNamePair} from "../../models/keyNamePair";
import {FormSelectMode} from "../../enum";

export class SelectPermissionModel {
    public mode: FormSelectMode = FormSelectMode.Item;
    public permissions: Array<any>;
    constructor() {
        this.permissions = [];
    }
    public setPermissions(pers: any) {
        this.permissions = [].concat(pers);
    }
}