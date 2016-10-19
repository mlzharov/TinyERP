import {ComponentType} from "../../event";
import {BaseComponent} from "./baseComponent";
export class BaseControl extends BaseComponent {
    constructor() {
        super(null, ComponentType.Control);
    }
}