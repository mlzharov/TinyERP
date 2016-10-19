import {Component, Input, Output, EventEmitter} from "angular2/core";
import {BaseControl} from "../../models/ui";
import {ValidationDirective} from "../../directive";
@Component({
    selector: "form-textarea",
    templateUrl: "app/common/directives/form/formTextArea.html",
    directives: [ValidationDirective]
})
export class FormTextArea extends BaseControl {
    @Input() labelText: string = String.empty;
    @Input() placeHolderText: string = String.empty;
    @Input() model: any;
    @Output() modelChange = new EventEmitter();
    public onValueChanged(evt: any) {
        this.modelChange.emit(evt.target.value);
    }
}