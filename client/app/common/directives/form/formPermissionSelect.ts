import {Component, Input, Output, EventEmitter} from "angular2/core";
import {BaseControl} from "../../models/ui";
import {SelectPermission} from "./selectPermission";
@Component({
    selector: "form-permission-select",
    templateUrl: "app/common/directives/form/formPermissionSelect.html",
    directives: [SelectPermission]
})
export class FormPermissionSelect extends BaseControl {
    @Input() labelText: string = String.empty;
    @Input() placeHolderText: string = String.empty;
    @Input() model: any;
    @Output() modelChange = new EventEmitter();
    public onPermissionAdded(per: any) {
        this.model.push(per.id);
        this.modelChange.emit(this.model);
    }
    public onPermissionRemoved(per: any) {
        this.model.removeItem(per.id);
        this.modelChange.emit(this.model);
    }
}