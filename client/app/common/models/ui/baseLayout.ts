import {ComponentType} from "../../event";
import {Http} from "angular2/http";
import {BaseComponent} from "./baseComponent";
export class BaseLayout extends BaseComponent {
    constructor(http: Http) {
        super(http, ComponentType.Layout);
    }
}