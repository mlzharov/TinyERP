import {Injector} from "angular2/core";
import {Router} from "angular2/router";
import {Http} from "angular2/http";
import {BaseLayout} from "./baseLayout";
import {LoadingIndicatorEvent, ApplicationStateEvent} from "../../event";
export class BaseApplication extends BaseLayout {
    constructor(http: Http) {
        super(http);
        // let router: Router = injector.get(RootRouter);
        // console.log("Router in application:", router);
    }
    protected onInit() {
        super.onInit();
        this.eventManager.publish(ApplicationStateEvent.Init);
    }
    protected onBeforeReady() {
        super.onBeforeReady();
        this.eventManager.publish(ApplicationStateEvent.BeforeReady);
    }
    protected onReady() {
        super.onReady();
        this.eventManager.publish(ApplicationStateEvent.Ready);
    }
    protected onUnload() {
        super.onUnload();
        this.eventManager.publish(ApplicationStateEvent.Unload);
    }
}