import {ElementRef, Input, Output, Component, EventEmitter } from "angular2/core";
import {Http } from "angular2/http";
import {EventManager} from "../../eventManager";
import {ResourceHelper} from "../../helpers/resourceHelper";
import {ValidationMode, ValidationException} from "../../models/exception";
import {ValidationEvent} from "../../event";
import {BaseControl} from "../../models/ui";
import {GridModel} from "./gridModel";
@Component({
    selector: "grid",
    templateUrl: "app/common/directives/grid/grid.html"
})
export class Grid extends BaseControl {
    public model: GridModel;
    private errorKeys: Array<string>;
    private grid: any;
    @Input() eventKey: string = String.empty;
    @Input() options: any = {};
    @Output() onItemEditClicked = new EventEmitter();
    @Output() onItemDeleteClicked = new EventEmitter();

    constructor() {
        super();
    }
    protected onInit() {
        let self: Grid = this;
        self.model = new GridModel(self.options);
        if (!String.isNullOrWhiteSpace(self.eventKey)) {
            self.registerEvent(self.eventKey, function (data: any) { self.onDataSourceChanged(data); });
        }
    }
    private onDataSourceChanged(items: Array<any>) {
        let self: Grid = this;
        self.grid.clear();
        self.grid.rows.add(items).draw();
    }
    protected onReady() {
        let $ = window.jQuery;
        let self: Grid = this;
        $(document).ready(function () {
            self.grid = $("#" + self.model.id).DataTable({
                data: self.model.data,
                columnDefs: self.model.getColumns()
            });
            self.bindEvents();
        });
    }
    private bindEvents() {
        let self: Grid = this;
        let $ = window.jQuery;
        $("#" + self.model.id + " tbody").on("click", ".grid-edit-item", function () {
            let data = self.grid.row($(this).parents("tr")).data();
            self.onItemEditClicked.emit({ item: data, gtid: self.grid });
        });

        $("#" + self.model.id + " tbody").on("click", ".grid-delete-item", function () {
            let data = self.grid.row($(this).parents("tr")).data();
            self.onItemDeleteClicked.emit({ item: data, gtid: self.grid });
        });
    }
}