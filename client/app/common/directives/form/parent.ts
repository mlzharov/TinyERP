import {Component} from "angular2/core";
@Component({
    selector: "parent",
    template: "<div>content of parent <ng-content select='child'></ng-content></div>",
})
export class Parent { }