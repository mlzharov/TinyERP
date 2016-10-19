export class MenuItem {
    constructor(text: string, url: string, cssClass: string, ...subItems: Array<MenuItem>) {
        this.text = text;
        this.url = url;
        this.class = cssClass;
        this.items = subItems.length > 0 ? subItems : new Array<MenuItem>();
    }
    text: string = "";
    url: string = "";
    class: string = "";
    items: Array<MenuItem> = new Array<MenuItem>();
}
export interface IModule {
    path: string;
    nameKey: string;
    menus: Array<MenuItem>;
    routes: any;
    addRoutes(routes: any): void;
}
export class Module implements IModule {
    constructor(path: string, nameKey: string) {
        this.path = path;
        this.nameKey = nameKey;
        this.menus = new Array<MenuItem>();
        this.routes = [];
    }
    public path: string;
    public nameKey: string;
    public menus: Array<MenuItem> = [];
    public routes: any = [];
    public addRoutes(routes: any) {
        if (!routes.length && routes.length <= 0) {
            this.routes.push(routes);
            return;
        }
        for (let index = 0; index < routes.length; index++) {
            let route = routes[index];
            this.routes.push(route);
        }
    }
}
export class Route {
    constructor(path: string, name: string, component: any, isDefault: boolean = false) {
        this.path = path;
        this.name = name;
        this.component = component;
        this.useAsDefault = isDefault;
    }
    public path: string;
    public name: string;
    public component: any;
    public useAsDefault: boolean;
}
export enum ProfileDisplayMode {
    AvatarAndName,
    Quick
}