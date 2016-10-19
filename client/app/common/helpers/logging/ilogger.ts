export interface ILogger {
    info(pattern: string, ...params: Array<any>): void;
    warn(pattern: string, ...params: Array<any>): void;
    error(pattern: string, ...params: Array<any>): void;
}