import {Input, Component } from "angular2/core";
import {ResourceHelper} from "../../helpers/resourceHelper";
import {BaseControl} from "../../models/ui";
import {PageActionsModel} from "./pageActionsModel";

@Component({
    selector: "page-actions",
    templateUrl: "app/common/directives/page/pageActions.html"
})
export class PageActions extends BaseControl {
    public model: PageActionsModel = new PageActionsModel([]);
    @Input() actions: Array<any>;
    constructor() {
        super();
    }
    protected onInit() {
        this.model = new PageActionsModel(this.actions);
    }
    public onActionItemClicked(action: any) {
        console.log(action);
        if (!action || !action.handler) { return; }
        action.handler();
    }
}