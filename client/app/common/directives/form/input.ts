import {Component, Input, Output, EventEmitter} from "angular2/core";
import {BaseControl} from "../../models/ui";
import guidHelper from "../../helpers/guidHelper";
import {ItemStatus, InputValueType} from "../../enum";
@Component({
    selector: "form-input",
    templateUrl: "app/common/directives/form/input.html",
})
export class FormInput extends BaseControl {
    public id: string = String.format("input-{0}", guidHelper.create());
    public ValueType: any = InputValueType;
    @Input() type: InputValueType;
    @Input() model: string = "";
    @Output() modelChange: EventEmitter<any> = new EventEmitter<any>();
    @Input() options: any = {};
    protected onReady() {
        if (this.options && !String.isNullOrWhiteSpace(this.options.mask)) {
            window.jQuery("#" + this.id).inputmask(this.options);
        }
    }
    public onChanged(item: any) {
        this.modelChange.next(item);
    }
}