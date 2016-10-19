import {Component, Input, Output, EventEmitter} from "angular2/core";
import {BaseControl} from "../../models/ui";
import guidHelper from "../../helpers/guidHelper";
import {FormInput} from "./input";
import {ItemStatus, InputValueType} from "../../enum";
@Component({
    selector: "form-currency",
    template: "<form-input [type]=ValueType.Currency [model]=model (modelChange)=onChanged($event) [options]=options></form-input>",
    directives: [FormInput]
})
export class FormCurrency extends BaseControl {
    public ValueType: any = InputValueType;
    @Input() model: any = "";
    @Output() modelChange: EventEmitter<any> = new EventEmitter<any>();
    public options: any = {
        mask: "999,999,999,999,999"
    };
    public onChanged(item: any) {
        this.modelChange.next(item);
    }
}