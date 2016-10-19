import {Component, Input, Output, EventEmitter} from "angular2/core";
import {DisplayMode, ParameterValueType} from "../../../../common/enum";
import {ValidationException} from "../../../../common/models/exceptions/validationException";
import {ValidationDirective} from "../../../../common/directive";
import {BaseControl} from "../../../../common/models/ui";
import guidHelper from "../../../../common/helpers/guidHelper";
@Component({
    selector: "parameters",
    templateUrl: "app/modules/setting/_share/directives/parameters.html",
    directives: [ValidationDirective]
})
export class Parameters extends BaseControl {
    public ParameterValueType: any = ParameterValueType;
    @Input() model: Array<any> = [];
    @Output() modelChanges = new EventEmitter();
    public DisplayMode: any = DisplayMode;
    public onAddParameterClicked() {
        this.model.push({
            id: guidHelper.create(),
            name: String.empty,
            value: String.empty,
            key: String.empty,
            mode: DisplayMode.Add,
            isRequired: false,
            isEncoded: false,
            valueType: ParameterValueType.String
        });
        this.modelChanges.emit(this.model);
    }
    public onEditClicked(item: any) {
        item.origin = JSON.parse(JSON.stringify(item));
        item.mode = DisplayMode.Edit;
    }
    public onDeleteClicked(item: any) {
        this.model.removeItem(item);
        this.modelChanges.emit(this.model);
    }
    public getDisplayMode(item: any) {
        let mode: DisplayMode = !!item && !!item.mode ? item.mode : DisplayMode.View;
        return mode;
    }
    public onSaveClicked(item: any) {
        if (this.validate(item) === false) { return; }
        item.mode = DisplayMode.View;
        this.modelChanges.emit(this.model);
    }
    private validate(item: any): boolean {
        let validation: ValidationException = new ValidationException();
        if (String.isNullOrWhiteSpace(item.name)) {
            validation.add("setting.parameters.validation.nameIsRequired");
        }
        if (this.model.any((currItem: any) => { return currItem.id !== item.id && currItem.name === item.name; })) {
            validation.add("setting.parameters.validation.nameAlreadyExisted");
        }

        if (String.isNullOrWhiteSpace(item.key)) {
            validation.add("setting.parameters.validation.keyIsRequired");
        }
        if (this.model.any((currItem: any) => { return currItem.id !== item.id && currItem.key === item.key; })) {
            validation.add("setting.parameters.validation.keyAlreadyExisted");
        }

        if (item.isRequired === true && String.isNullOrWhiteSpace(item.value)) {
            validation.add("setting.parameters.validation.valueIsRequired");
        }
        validation.throwIfHasError();
        return !validation.hasError();
    }
    public getValueType(item: any) {
        return ParameterValueType[item.valueType];
    }
    public onCancelClicked(item: any) {
        if (item.mode === DisplayMode.Add) {
            this.model.pop();
        }
        else {
            item.id = item.origin.id;
            item.name = item.origin.name;
            item.value = item.origin.value;
            item.key = item.origin.key;
            item.isRequired = item.origin.isRequired;
            item.isEncoded = item.origin.isEncoded;
            item.valueType = item.origin.valueType;
            item.mode = DisplayMode.View;
        }
        this.modelChanges.emit(this.model);
    }
}