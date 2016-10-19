import {Component, Input, Output, EventEmitter} from "angular2/core";
import {BaseControl}  from "../../../models/ui";
import guidHelper from "../../../helpers/guidHelper";
import httpHelper from "../../../helpers/httpHelper";
import jsonHelper from "../../../helpers/jsonHelper";
import configHelper from "../../../helpers/configHelper";
@Component({
    selector: "form-filesUpload",
    templateUrl: "app/common/directives/form/upload/filesUpload.html"
})
export class FormFilesUpload extends BaseControl {
    public id: string = guidHelper.create();
    @Input() files: Array<any> = [];
    @Output() filesChanged: EventEmitter<any> = new EventEmitter();
    @Input() description: string;
    @Output() onFileUploaded: EventEmitter<any> = new EventEmitter();
    private dropzone: any = {};
    protected onReady() {
        let self: FormFilesUpload = this;
        window.jQuery(String.format("#{0}_form", this.id)).dropzone({
            init: function () {
                self.dropzone = this;
            },
            url: String.format("{0}files", configHelper.getAppConfig().api.baseUrl),
            success: (response: any) => this.fileUploadResponse(response)
        });
    }
    protected onChange() {
        let self: FormFilesUpload = this;
        self.files.forEach(function (file: any) {
            let tempFile = { name: file.fileName, zise: file.size };
            self.dropzone.emit("addedfile", tempFile);
            let photoUrl: string = String.format("{0}/files/{1}/thumbnail", configHelper.getAppConfig().api.baseUrl, file.id);
            self.dropzone.emit("thumbnail", tempFile, photoUrl);
        });
    }

    private isErrorResponse(response: any) {
        let jsonResponse = jsonHelper.parse(response.xhr.responseText);
        return httpHelper.isSuccessStatusCode(response.xhr.status) && httpHelper.isSuccessStatusCode(jsonResponse.status);
    }
    private handleErrorUpload(response: any) {
        let ev: any = {
            type: response.type,
            fileName: response.name,
            fileSize: response.size
        };
        if (httpHelper.isSuccessStatusCode(response.xhr.status)) {
            ev.uploadStatus = {
                status: response.xhr.status,
                file: String.empty,
                errors: [httpHelper.resolve(response.xhr.status)]
            };
            this.onFileUploaded.emit(ev);
            return;
        }
        let jsonResponse = jsonHelper.parse(response.xhr.responseText);
        ev.uploadStatus = {
            status: jsonResponse.status,
            file: String.empty,
            errors: jsonResponse.errors
        };
        this.onFileUploaded.emit(ev);
    }
    private handleSuccessUpload(response: any) {
        let jsonResponse = jsonHelper.parse(response.xhr.responseText);
        let ev: any = {
            type: response.type,
            fileName: response.name,
            fileSize: response.size,
            uploadStatus: {
                status: response.xhr.status,
                file: jsonResponse.data.file,
                errors: []
            }
        };
        jsonResponse.data.forEach((item: any) => this.files.push(item));
        this.filesChanged.emit(this.files);

        this.onFileUploaded.emit(ev);
    }
    public fileUploadResponse(response: any) {
        if (this.isErrorResponse(response)) {
            this.handleErrorUpload(response);
            return;
        }
        this.handleSuccessUpload(response);
    }
}