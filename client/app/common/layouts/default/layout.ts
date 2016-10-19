import {Injector} from "angular2/core";
import {provide, Component, OnInit, AfterContentInit, AfterViewInit, OnDestroy} from "angular2/core";
import {CORE_DIRECTIVES} from "angular2/common";
import {Http, HTTP_PROVIDERS, XHRBackend} from "angular2/http";
import {Router, RouteConfig, RouteParams, ROUTER_DIRECTIVES, ROUTER_PROVIDERS} from "angular2/router";

import {DefaultAuthenticatedLayout} from "./authenticatedLayout";
import {DefaultUnauthenticatedLayout} from "./unauthenticatedLayout";
import configHelper from "../../helpers/configHelper";
import authService from "../../services/authService";
import {AuthenticatedEvent, LoadingIndicatorEvent, ApplicationStateEvent} from "../../event";
import {IoCFactory, IoCContainer} from "../../models/ioc/all";
import {LoadingIndicator} from "./directives/common/loadingIndicator";
import {BaseApplication} from "../../models/ui";
import {IApplicationState} from "../../models/app/iapplicationState";
import {ILogger} from "../../helpers/logging/ilogger";

let routes = configHelper.getRoutes();
// configIoC();
@Component({
    selector: "default-layout",
    templateUrl: "app/common/layouts/default/layout.html",
    directives: [
        CORE_DIRECTIVES,
        DefaultAuthenticatedLayout,
        LoadingIndicator
    ]
})
@RouteConfig(routes)
export class DefaultLayout extends BaseApplication {
    public isAuthenticated: boolean = false;
    private router: Router;
    constructor(injector: Injector, http: Http, router: Router) {
        super(http);
        this.router = router;
        this.onInitialized();
    }
    private onInitialized() {
        let self: any = this;
        let appState: IApplicationState = window.ioc.resolve("IApplicationState");
        if (!!appState) {
            appState.registerEvents();
        }
        this.registerEvent(AuthenticatedEvent.AuthenticationChanged, function (authenticated: boolean) {
            self.isAuthenticated = authenticated;
        });
        let profile: any = authService.getUserProfile();
        if (authService.isAuthenticated(profile)) {
            this.isAuthenticated = true;
        }
    }
}