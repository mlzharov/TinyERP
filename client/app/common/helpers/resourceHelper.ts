import {PromiseFactory, Promise} from "../models/promise";
import {Hashtable} from "../models/list/hashtable";
import appConfig from "../../config/appConfig";
import objectHelper from "./objectHelper";
import configHelper from "../helpers/configHelper";
import userProfileHelper from "../helpers/userProfileHelper";
export class ResourceHelper {
    private resources: Hashtable<any>;
    private callbacks: Array<Hashtable<any>>;
    constructor() {
        this.resources = new Hashtable<any>();
        this.callbacks = new Array<Hashtable<any>>();
    }
    public getResourceData() {
        return this.resources.data;
    }
    public load(modules: Array<string>) {
        let self: ResourceHelper = this;
        modules.forEach(function (module: string) {
            if (self.resources.exist(module)) { return; }
            self.loadResource(module);
        });
    }
    public resolve(key: string) {
        if (!key || key.split(".").length < 2) {
            throw "Invalid resource key: " + key;
        }
        let keyItems = key.split(".");
        let moduleName = keyItems.shift();
        let resourceObject = this.resources.get(moduleName);
        let value: string = objectHelper.getByPath(resourceObject, keyItems.join("."));
        return value;
        // let def = PromiseFactory.create();
        /*if (!this.resources.exist(moduleName)) {
            let callbacks = this.callbacks[key];
            if (!callbacks) {
                this.callbacks[moduleName] = new Hashtable<any>();
                callbacks = this.callbacks[moduleName];
            }
            callbacks.set(keyItems.join("."), function (value: string) {
                def.resolve(value);
            });
            let self = this;
            this.loadResource(moduleName).then((args: any) => { self.onNewResourceLoaded(args); });
        } else {
            let resourceObject = this.resources.get(moduleName);
            let value = objectHelper.getByPath(resourceObject, keyItems.join("."));
            def.resolve(value);

        }*/
        // return def;
    }
    private loadResource(moduleName: string): Promise {
        let def = PromiseFactory.create();
        let lang: string = userProfileHelper.getLang();
        let resourcePath = String.format("{0}{1}.{2}.json", configHelper.getAppConfig().localeUrl, moduleName, lang);
        let connector = window.ioc.resolve("IConnector");
        let self: ResourceHelper = this;
        connector.getJSON(resourcePath).then(function (data: any) {
            self.resources.set(moduleName, data);
            def.resolve({ module: moduleName, json: data });
        });
        return def;
    }
    private onNewResourceLoaded(params: any) {
        let moduleJson: any = params.json;
        let callbackes: Hashtable<any> = this.callbacks[params.module];
        let items: Array<string> = callbackes.getKeys();
        items.forEach(function (key: string) {
            let callback = callbackes.get(key);
            let value = objectHelper.getByPath(moduleJson, key);
            if (callback) {
                callback(value);
                callbackes.remove(key);
            }

        });
    }
}