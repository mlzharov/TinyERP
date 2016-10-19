import {IoCInstanceType} from "./enum";
export class IoCRegistrationItem {
    constructor(name: string, instanceOf: any, type: IoCInstanceType = IoCInstanceType.Singleton) {
        this.name = name;
        this.type = type;
        this.instanceOf = instanceOf;
    }
    public instance: any = null;
    public instanceFn: any = null;
    public name: string;
    public type: IoCInstanceType;
    public instanceOf: any;
}