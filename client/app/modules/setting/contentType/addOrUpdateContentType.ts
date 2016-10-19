import {BasePage} from "../../../common/models/ui";
import {Router, RouteParams} from "angular2/router";
import {Component} from "angular2/core";
import {Model} from "./addOrUpdateContentTypeModel";
import {SelectPermission, Page} from "../../../common/directive";
import {ValidationDirective, FormStatusToggle, FormSelect} from "../../../common/directive";
import settingService from "../_share/services/settingService";
import {FormMode, Guid} from "../../../common/enum";
import route from "../_share/config/route";
import {Parameters} from "../_share/directives/parameters";

@Component({
    templateUrl: "app/modules/setting/contentType/addOrUpdateContentType.html",
    directives: [ValidationDirective, FormStatusToggle, FormSelect, Parameters, Page]
})
export class AddOrUpdateContentType extends BasePage {
    public model: Model = new Model();
    private router: Router;
    private mode: FormMode = FormMode.AddNew;
    private itemId: any;
    constructor(router: Router, routeParams: RouteParams) {
        super();
        let self = this;
        self.router = router;
        if (!!routeParams.get("id")) {
            self.mode = FormMode.Edit;
            self.itemId = routeParams.get("id");
            settingService.getContentType(self.itemId).then(function (item: any) {
                self.model.import(item);
            });
        }
    }
    public onSaveClicked(event: any): void {
        let self = this;
        if (self.mode === FormMode.AddNew) {
            settingService.createContentType(this.model).then(function () {
                self.router.navigate([route.setting.contentTypes.name]);
            });
            return;
        }
        settingService.updateContentType(this.model).then(function () {
            self.router.navigate([route.setting.contentTypes.name]);
        });
    }
    public onCancelClicked(event: any): void {
        let self = this;
        self.router.navigate([route.setting.contentTypes.name]);
    }

}