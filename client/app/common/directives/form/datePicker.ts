import {Component, Input, Output, EventEmitter} from "angular2/core";
import {BaseControl} from "../../models/ui";
import guidHelper from "../../helpers/guidHelper";
@Component({
    selector: "form-datepicker",
    templateUrl: "app/common/directives/form/datePicker.html",
    host: {
        "[value]": "model"
    }
})
export class FormDatePicker extends BaseControl {
    public id: string = String.format("date-picker-{0}", guidHelper.create());
    @Input() model: any;
    @Output() modelChange: EventEmitter<any> = new EventEmitter<any>();
    @Output() onValueChanged = new EventEmitter();
    protected onReady() {
        let self: FormDatePicker = this;
        window.jQuery("#" + this.id).daterangepicker({
            singleDatePicker: true
        }, function (selectedValue: any) {
            self.modelChange.next(selectedValue);
        });
    }
}