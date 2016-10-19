import {ILogger} from "./ilogger";
export class ConsoleLogger implements ILogger {
    public info(pattern: string, ...params: Array<any>): void {
        let strToWrite = String.format([pattern].concat(params));
        console.info(strToWrite);
    }
    public warn(pattern: string, ...params: Array<any>): void {
        let strToWrite = String.format([pattern].concat(params));
        console.warn(strToWrite);
    }
    public error(pattern: string, ...params: Array<any>): void {
        let strToWrite = String.format([pattern].concat(params));
        console.error(strToWrite);
    }
}