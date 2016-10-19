import {Injector} from "angular2/core";
export interface IApplicationState {
    registerEvents(): void;
    setInjector(injector: Injector): void;
    getInjector(): Injector;
}