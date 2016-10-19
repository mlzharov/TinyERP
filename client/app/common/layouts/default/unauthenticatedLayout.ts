import {Component} from "angular2/core";
import {Router, ROUTER_DIRECTIVES} from "angular2/router";
import {PageFooter} from "./directives/all";

import configHelper from "../../helpers/configHelper";
import {ErrorMessage} from "../../../common/layouts/default/directives/common/errorMessage";

@Component({
    selector: "default-unauthenticated-layout",
    templateUrl: "app/common/layouts/default/unauthenticatedLayout.html",
    directives: [ROUTER_DIRECTIVES, PageFooter, ErrorMessage]
})
export class DefaultUnauthenticatedLayout {
    constructor(private router: Router) {
        router.navigate([configHelper.getAppConfig().loginUrl]);
    }
}
