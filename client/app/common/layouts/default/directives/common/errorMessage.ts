import {Component, Input} from "angular2/core";
import {ValidationError, ValidationException} from "../../../../models/exception";
import {ResourceHelper} from "../../../../helpers/resourceHelper";
import {CommonEvent} from "../../../../event";
import regexHelper from "../../../../helpers/regexHelper";

@Component({
    selector: "error-message",
    templateUrl: "./app/common/layouts/default/directives/common/errorMessage.html"
})
export class ErrorMessage {
    public errors: Array<any> = [];
    @Input() pattern: string = "*";
    constructor() {
        let eventManager: any = window.ioc.resolve("IEventManager");
        eventManager.subscribe(CommonEvent.ValidationFail, (validation: ValidationException) => { this.onError(validation); });
    }
    private onError(validation: ValidationException) {
        let self: ErrorMessage = this;
        let resourceHelper: ResourceHelper = window.ioc.resolve("IResource");
        let errors: Array<ValidationError> = [];
        validation.errors.forEach(function (error: ValidationError) {
            if (!regexHelper.isMatch(self.pattern, error.key)) { return; }
            console.log(String.format("pattern {0}, value: {1}", self.pattern, error.key));
            error.msg = resourceHelper.resolve(error.key);
            errors.push(error);
        });
        this.errors = errors;
    }
}