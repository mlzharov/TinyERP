export class GridModel {
    private static NumberOfInstance = 0;
    public id: string = String.format("_grid{0}", GridModel.NumberOfInstance);
    public data: Array<any> = [];
    private options: any = null;
    constructor(options: any) {
        GridModel.NumberOfInstance++;
        this.data = options.data;
        this.options = options;
    }
    public getColumns(): Array<any> {
        let columns: Array<any> = [];
        if (!this.options || String.isNullOrWhiteSpace(this.options.columns)) { return columns; }
        this.options.columns.forEach(function (column: any, index: number) {
            columns.push({ "data": column.field, title: column.title, "targets": index, "defaultContent": !!column.content ? column.content : String.empty, "render": !!column.render ? column.render : null });
        });
        let actionContent = this.getActions();
        if (!String.isNullOrWhiteSpace(actionContent)) {
            columns.push({ width: "20%", orderable: false, data: null, title: "", targets: columns.length, defaultContent: actionContent });
        }
        return columns;
    }
    /* Resolve static text to i18n later */
    private getActions() {
        let html: string = String.empty;
        if (this.options.enableEdit === true) {
            html += "<input type=button class=\"btn btn-default grid-edit-item\" id=\"editGridItem\" value=\"Edit\"/>";
        }
        if (this.options.enableDelete === true) {
            html += "<input type=button class=\"btn btn-danger grid-delete-item\" id=\"deleteGridItem\" value=\"Delete\"/>";
        }
        return html;
    }

}