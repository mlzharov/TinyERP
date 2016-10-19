/// <reference path="extension.d.ts" />
import { bootstrap } from "angular2/platform/browser";
import {LocationStrategy, HashLocationStrategy} from "angular2/platform/common";
import {provide, enableProdMode, Injector} from "angular2/core";
import {HTTP_PROVIDERS, Http} from "angular2/http";
import {ROUTER_PROVIDERS, Router} from "angular2/router";
import {DefaultLayout} from "./common/layouts/default/layout";
import configHelper from "./common/helpers/configHelper";
import {IoCFactory, IoCContainer} from "./common/models/ioc/all";
import {ApplicationStateFactory} from "./applicationState";
import { ReflectiveInjector } from "angular2/core";
import {ResourceHelper} from "./common/helpers/resourceHelper";

let injector = ReflectiveInjector.resolveAndCreate([HTTP_PROVIDERS, ROUTER_PROVIDERS]);
configInjector(injector);
configIoC();
// enableProdMode();
bootstrap(DefaultLayout, [
  HTTP_PROVIDERS,
  ROUTER_PROVIDERS
])
  .then((appRef: any) => onAppBootstraped(appRef))
  .catch(err => handleError(err));

function handleError(err: any) {
  console.error(err);
}
function onAppBootstraped(appRef: any) {
  configInjector(appRef.injector);
}
function configInjector(injector: any) {
  ApplicationStateFactory.getInstance().setInjector(injector);
  window.appState = ApplicationStateFactory.getInstance();
}
function configIoC() {
  let config: any = configHelper.getAppConfig();
  let ioc: IoCContainer = IoCFactory.create();
  ioc.import(config.ioc);
  window.ioc = ioc;
  let resourceHelper: ResourceHelper = window.ioc.resolve("IResource");
  resourceHelper.load(["common", "registration", "security", "productManagement", "store", "setting"]);
}