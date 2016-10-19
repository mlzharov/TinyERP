import {IoCRegistrationItem} from "./iocRegistrationItem";
export class IoCBuilder {
    // will check again
    public static createTrainsent(registration: IoCRegistrationItem): any {
        if (!!registration.instanceFn) {
            return registration.instanceFn();
        }
        registration.instanceFn = () => { return registration.instanceOf(); };
        return registration.instanceFn();
    }
    public static createSingleton(registration: IoCRegistrationItem): any {
        if (!!registration.instance) {
            return registration.instance;
        }
        let instance = new registration.instanceOf();
        registration.instance = instance;
        return instance;
    }
}