import {Hashtable} from "../list/hashtable";
import {AuthenticatedEvent, ApplicationStateEvent} from "../../event";
import {IConnector} from "../../connectors/iconnector";
import {ResourceHelper} from "../../helpers/resourceHelper";
import {EventManager} from "../../eventManager";
import {Http} from "angular2/http";
import {OnActivate, ComponentInstruction} from "angular2/router";
import {OnInit, AfterContentInit, AfterViewInit, AfterViewChecked, OnDestroy, OnChanges } from "angular2/core";
import {ComponentType} from "../../event";
import authService from "../../services/authService";
import {AuthenticationMode} from "../../enum";
import guidHelper from "../../helpers/guidHelper";
export class BaseComponent implements OnInit, AfterContentInit, AfterViewInit, OnDestroy, OnActivate, OnChanges {
    protected connector: IConnector;
    protected eventManager: EventManager;
    protected events: Hashtable<any>;
    public i18n: any;
    protected i18nHelper: ResourceHelper;
    public id: string = guidHelper.create();
    constructor(http: Http, componentType: any = ComponentType.Layout) {
        this.connector = window.ioc.resolve("IConnector");
        this.eventManager = window.ioc.resolve("IEventManager");
        let resourceHelper: ResourceHelper = window.ioc.resolve("IResource");
        this.i18nHelper = resourceHelper;
        this.i18n = resourceHelper.getResourceData();
        this.events = new Hashtable<any>();
        if (componentType === ComponentType.Layout) {
            this.connector.setHttp(http);
        }
    }
    routerOnActivate(next: ComponentInstruction): boolean | Promise<boolean> {
        let authenticationMode = next.routeData.data["authentication"];
        if (!authenticationMode || authenticationMode === AuthenticationMode.None) { return true; }
        let isAuthenticated: boolean = authService.isAuthorized(next);
        if (!isAuthenticated) {
            this.eventManager.publish(ApplicationStateEvent.UnAuthorizeRequest, next);
        }
        return isAuthenticated;
    }
    ngOnInit() {
        this.onInit();
        let self: BaseComponent = this;
        this.events.getKeys().forEach(function (key) {
            let handler: any = self.events.get(key);
            self.eventManager.subscribe(key, handler);
        });
    }
    ngAfterContentInit() {
        this.onBeforeReady();
    }
    ngAfterViewInit() {
        this.onReady();
    }
    ngOnDestroy() {
        let self: BaseComponent = this;
        this.events.getKeys().forEach(function (key) {
            self.eventManager.unsubscribe(key);
        });
        this.onUnload();
    }
    ngOnChanges() {
        this.onChange();
    }
    protected onChange() { }
    protected setResources(resources: Array<string>) {
        let resourceHelper: ResourceHelper = window.ioc.resolve("IResource");
        resourceHelper.load(resources);
    }
    protected onInit() {
    }
    protected onBeforeReady() {
    }
    protected onReady() {
    }
    protected onUnload() {
    }
    public registerEvent(key: string, handler: any): void {
        this.events.set(key, handler);
    }
}