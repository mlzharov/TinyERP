import {ElementRef, Input, Directive } from "angular2/core";
import {EventManager} from "../eventManager";
import {ResourceHelper} from "../helpers/resourceHelper";
import {ValidationMode, ValidationException} from "../models/exception";
import {ValidationEvent} from "../event";
@Directive({
    selector: "[validation]"
})
export class ValidationDirective {
    private el: HTMLInputElement;
    private errorKeys: Array<string>;
    @Input("validation") set keys(keys: Array<string>) {
        this.errorKeys = keys;
    }
    constructor(html: ElementRef) {
        let self: ValidationDirective = this;
        this.el = html.nativeElement;
        let eventManager: EventManager = window.ioc.resolve("IEventManager");
        eventManager.subscribe(ValidationEvent.ValidationFail, (error: ValidationException) => self.onValidationFailed(error));
    }
    private onValidationFailed(exception: ValidationException) {
        let errors: Array<any> = exception.errors;
        if (!errors || errors.length === 0) {
            this.hideError();
            return;
        }
        let self: ValidationDirective = this;
        let error = errors.firstOrDefault(function (item: any) {
            return self.errorKeys.indexOf(item.key) >= 0;
        });
        if (!!error && !!error.key) {
            self.showError(error);
            return;
        }
        self.hideError();
    }
    private showError(error: any) {
        let resourceHelper: ResourceHelper = window.ioc.resolve("IResource");
        let errorMessage: string = resourceHelper.resolve(error.key);
        window.jQuery(this.el).addClass(ValidationMode.Invalid);
        this.el.setAttribute("origin-title", this.el.title);
        this.el.title = errorMessage;

    }
    private hideError() {
        window.jQuery(this.el).removeClass(ValidationMode.Invalid);
        let holderText = this.el.getAttribute("origin-title");
        if (!!holderText) {
            this.el.title = holderText;
        }
    }
}