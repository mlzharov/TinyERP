import {Component, Input, Output, EventEmitter} from "angular2/core";
import {BaseControl} from "../../../common/models/ui";
import {SelectModel} from "./selectModel";
import {FormSelectMode} from "../../../common/enum";
import {KeyNamePair} from "../../../common/models/KeyNamePair";
@Component({
    selector: "form-select",
    templateUrl: "app/common/directives/form/select.html"
})
export class FormSelect extends BaseControl {
    public model: SelectModel = new SelectModel();
    public SelectMode: any = FormSelectMode;
    public cssClass: string = String.empty;
    public mode: FormSelectMode = FormSelectMode.Item;
    private dom: any;

    @Input() placeHolder: string;
    @Input() values: Array<string> = [];
    @Output() valuesChange = new EventEmitter();
    @Input() maxSelectedItems = 5;
    @Input() getItems: any = () => { };
    protected onReady() {
        let self: FormSelect = this;
        let iconenctor = window.ioc.resolve("IConnector");
        self.getItems().then(function (items: Array<any>) {
            self.model.import(items);
            window.setTimeout(function () {
                self.dom.val(self.values).trigger("change");
            }, 0);

        });

        this.dom = window.jQuery(String.format("#{0}", self.id)).select2({
            maximumSelectionLength: self.maxSelectedItems,
            placeholder: self.placeHolder,
            allowClear: true
        });
        this.dom.on("select2:select", function (item: any) {
            if (self.maxSelectedItems === 1) {
                self.values = [item.params.data.id];
            } else {
                self.values.push(item.params.data.id);
            }
            self.valuesChange.emit(self.values);
            return true;
        });
        this.dom.on("select2:unselect", function (item: any) {
            self.values = self.values.removeItem(item.params.data.id);
            self.valuesChange.emit(self.values);
            return true;
        });
    }
}