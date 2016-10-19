import {Component, Input} from "angular2/core";
import {BaseControl} from "../../../../common/models/ui";
import guidHelper from "../../../../common/helpers/guidHelper";
@Component({
    selector: "form-wizardItem",
    templateUrl: "app/common/directives/form/wizard/wizardItem.html"
})
export class FormWizardItem extends BaseControl {
    public id: string = "wizard_item_" + guidHelper.create();
    @Input() title: string;
    @Input() description: string;
}