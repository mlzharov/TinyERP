declare interface Window {
    ioc: any;
    jQuery: any;
    appState: any;
}
interface StringConstructor {
    format(...params: Array<any>): string;
    isNullOrWhiteSpace(value: string): boolean;
    empty: string;
    firstCharToLower(str: string): string;
}
declare interface Array<T> {
    firstOrDefault(callback: any): any;
    removeItem(item: any): Array<any>;
    any(callback: any): boolean;
}
interface RouteData {
    authentication: any;
}