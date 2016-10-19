import {Component, Input, Output, EventEmitter, ViewChildren, ContentChildren, QueryList} from "angular2/core";
import {BaseControl} from "../../../../common/models/ui";
import {Model} from "./wizardModel";
import {FormSelectMode} from "../../../../common/enum";
import {KeyNamePair} from "../../../../common/models/KeyNamePair";
import {FormWizardItem} from "../../../../common/directive";
import guidHelper from "../../../../common/helpers/guidHelper";
@Component({
    selector: "form-wizard",
    templateUrl: "app/common/directives/form/wizard/wizard.html"
})
export class FormWizard extends BaseControl {
    public id: string = "wizard_" + guidHelper.create();
    public model: Model = new Model();
    private dom: any;
    @Output() onFinishClicked: any = new EventEmitter();
    @ContentChildren(FormWizardItem) steps: QueryList<FormWizardItem>;

    constructor() {
        super();
    }
    public onReady() {
        let self: FormWizard = this;
        console.log(self.steps);
        self.model.import(self.steps.toArray());
        window.setTimeout(function () {
            self.dom = window.jQuery("#" + self.id).smartWizard({ onFinish: () => self.onFinishClicked.emit() });
            window.jQuery("#" + self.id + " .buttonNext").addClass("btn btn-default");
            window.jQuery("#" + self.id + " .buttonPrevious").addClass("btn btn-default");
            window.jQuery("#" + self.id + " .buttonFinish").addClass("btn btn-primary btn-finish");
            window.jQuery("#" + self.id + " .stepContainer").remove();
            self.dom.find(".wizard_steps").css("left", "-" + (self.dom.find(".wizard_steps li:first").width() / 2) + "px");
        }, 0);

    }
}