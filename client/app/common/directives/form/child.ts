import {Component} from "angular2/core";
@Component({
    selector: "child",
    template: "<ng-content></ng-content>"
})
export class Child { }