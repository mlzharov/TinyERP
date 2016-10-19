import {KeyNamePair} from "../../models/keyNamePair";
import {FormSelectMode} from "../../enum";

export class SelectModel {
    public mode: FormSelectMode = FormSelectMode.Item;
    public items: Array<any> = [];
    public import(items: any) {
        this.items = [].concat(items);
    }
}