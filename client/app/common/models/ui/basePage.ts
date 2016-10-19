import {ComponentType} from "../../event";
import {BaseComponent} from "./baseComponent";
export class BasePage extends BaseComponent {
    public model: any;
    constructor() {
        super(null, ComponentType.Page);
    }
}