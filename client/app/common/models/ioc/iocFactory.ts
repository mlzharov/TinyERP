declare var require: (moduleId: string) => any;
import {Hashtable} from "../list/hashtable";
import {IoCRegistrationItem} from "./iocRegistrationItem";
import {IoCInstanceType} from "./enum";
import {InvalidOperation} from "../exception";
import {IoCBuilder} from "./all";
import configHelper from "../../helpers/configHelper";
import iocRegistrations from "../../../config/ioc";

export class IoCFactory {
    public static create(): IoCContainer {
        return new IoCContainer();
    }
}
export class IoCContainer {
    private registrations: Hashtable<IoCRegistrationItem> = new Hashtable<IoCRegistrationItem>();

    public import(filePath: string): void {
        let iocItems = iocRegistrations; //  require(filePath);
        let self = this;
        iocItems.forEach(function (iocConfig: any) {
            let key: string = iocConfig.name;
            self.registrations.set(key, iocConfig);
        });
    }
    public resolve(name: string): any {
        if (!this.registrations.exist(name)) {
            throw new InvalidOperation("Can not resolve {0} from ioc container", name);
        }
        let registration: IoCRegistrationItem = this.registrations.get(name);

        let instance: any = this.getInstance(registration);
        return instance;
    }
    private getInstance(registration: IoCRegistrationItem): any {
        let instance: any = null;
        switch (registration.type) {
            case IoCInstanceType.Transient:
                instance = IoCBuilder.createTrainsent(registration);
                break;
            case IoCInstanceType.Singleton:
                instance = IoCBuilder.createSingleton(registration);
            default:
                break;
        }
        return instance;
    }

}