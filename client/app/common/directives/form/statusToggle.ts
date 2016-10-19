import {Component, Input, Output, EventEmitter} from "angular2/core";
import {BaseControl} from "../../models/ui";
import guidHelper from "../../helpers/guidHelper";
import {FormToggle} from "./toggle";
import {ItemStatus} from "../../enum";
@Component({
    selector: "form-status-toggle",
    template: "<form-toggle [model]=model (modelChange)=onChanged($event) [options]=options></form-toggle>",
    directives: [FormToggle]
})
export class FormStatusToggle extends BaseControl {
    @Input() model: any;
    @Output() modelChange: EventEmitter<any> = new EventEmitter<any>();
    public options: Array<any> = [
        { value: ItemStatus.Active, text: this.i18nHelper.resolve("common.form.status.active"), active: true },
        { value: ItemStatus.InActive, text: this.i18nHelper.resolve("common.form.status.inactive"), active: false }
    ];
    public onChanged(item: any) {
        this.modelChange.next(item.value);
    }
}