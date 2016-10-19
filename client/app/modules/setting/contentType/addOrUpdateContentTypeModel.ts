import {KeyNamePair} from "../../../common/models/keyNamePair";
export class Model {
    public id: string = String.empty;
    public name: string = String.empty;
    public key: string = String.empty;
    public description: string = String.empty;
    public parameters: Array<any> = [];
    public import(item: any) {
        this.id = item.id;
        this.name = item.name;
        this.key = item.key;
        this.description = item.description;
        if (item.parameters) {
            this.parameters = item.parameters;
        }
    }
}