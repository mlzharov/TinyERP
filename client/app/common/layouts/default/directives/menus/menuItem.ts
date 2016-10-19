import {Component, OnInit, Input}  from "angular2/core";
import {MenuItem as MenuItemModel} from "../../../../models/layout";
import {RouteConfig, RouterLink, ROUTER_DIRECTIVES} from "angular2/router";
import configHelper from "../../../../helpers/configHelper";
@Component({
    selector: "menu-item",
    templateUrl: "app/common/layouts/default/directives/menus/menuItem.html",
    directives: [ROUTER_DIRECTIVES, RouterLink, MenuItem]
})
export class MenuItem {
    @Input() items: Array<MenuItemModel>;
    @Input() isChild: boolean;
    ngOnInit() {
        console.log("item ne", this.items);
    }
}