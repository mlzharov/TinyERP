import "rxjs/Rx";
// import {Observable} from "rxjs/Observable";
import {Http, Headers} from "angular2/http";
import {Injectable}  from "angular2/core";
import {PromiseFactory, Promise} from "../models/promise";
import {JsonHeaders} from "../models/http";
import {ValidationException} from "../models/exception";
import {LoadingIndicatorEvent, CommonEvent} from "../event";
import {EventManager} from "../eventManager";
import {HttpCode} from "../event";
import {IConnector} from "./iconnector";
@Injectable()
export class RESTConnector implements IConnector {
    private static http: Http;
    private static eventManager: EventManager;
    constructor() {
        let http: Http = window.appState.getInjector().get(Http);
        this.setHttp(http);
    }
    public setHttp(http: Http) {
        RESTConnector.http = http;
        RESTConnector.eventManager = window.ioc.resolve("IEventManager");
    }
    public getJSON(jsonPath: string) {
        RESTConnector.eventManager.publish(LoadingIndicatorEvent.Show);
        let def = PromiseFactory.create();
        let headers = new JsonHeaders();
        RESTConnector.http.get(jsonPath, { headers: headers })
            .map((response: any) => response.json())
            .subscribe((data: any) => { def.resolve(data); });
        return def;
    }

    public post(url: string, data: any): Promise {
        RESTConnector.eventManager.publish(LoadingIndicatorEvent.Show);
        let def = PromiseFactory.create();
        let headers = new JsonHeaders();
        let dataToSend = JSON.stringify(data);
        RESTConnector.http.post(url, dataToSend, { headers: headers })
            .map((response: any) => response.json())
            .subscribe(
                (data: any) => this.handleResponse(def, data),
                (exception: any) => this.handleException(def, exception)
            );
        return def;
    }

    public put(url: string, data: any): Promise {
        RESTConnector.eventManager.publish(LoadingIndicatorEvent.Show);
        let def = PromiseFactory.create();
        let headers = new JsonHeaders();
        let dataToSend = JSON.stringify(data);
        RESTConnector.http.put(url, dataToSend, { headers: headers })
            .map((response: any) => response.json())
            .subscribe(
            (data: any) => this.handleResponse(def, data),
            (exception: any) => this.handleException(def, exception)
            );
        return def;
    }

    public get(url: string): Promise {
        RESTConnector.eventManager.publish(LoadingIndicatorEvent.Show);
        let def = PromiseFactory.create();
        let headers = new JsonHeaders();
        RESTConnector.http.get(url, { headers: headers })
            .map((response: any) => response.json())
            .subscribe(
            (data: any) => this.handleResponse(def, data),
            (exception: any) => this.handleException(def, exception)
            );
        return def;
    }

    public delete(url: string): Promise {
        RESTConnector.eventManager.publish(LoadingIndicatorEvent.Show);
        let def = PromiseFactory.create();
        let headers = new JsonHeaders();
        RESTConnector.http.delete(url, { headers: headers })
            .map((response: any) => response.json())
            .subscribe(
            (data: any) => this.handleResponse(def, data),
            (exception: any) => this.handleException(def, exception)
            );
        return def;
    }

    private handleResponse(def: Promise, response: any): any {
        RESTConnector.eventManager.publish(LoadingIndicatorEvent.Hide);
        if (response.errors.length === 0) {
            def.resolve(response.data);
            return;
        }
        let validationEror: ValidationException = this.getValidationExceptionFromResponse(response.errors);
        RESTConnector.eventManager.publish(CommonEvent.ValidationFail, validationEror);
        def.reject(response.errors);
    }
    private handleException(def: Promise, exception: any) {
        RESTConnector.eventManager.publish(LoadingIndicatorEvent.Hide);
        let error: ValidationException = this.getError(exception);
        def.reject(error);
        RESTConnector.eventManager.publish(CommonEvent.ValidationFail, error);
    }
    private getValidationExceptionFromResponse(responseErrors: Array<any>) {
        let validationEror: ValidationException = new ValidationException();
        responseErrors.forEach(function (errorItem: any) {
            validationEror.add(errorItem.key, errorItem.params);
        });
        return validationEror;
    }
    private getError(exception: any): ValidationException {
        let validationEror: ValidationException;
        switch (exception.status) {
            case HttpCode.BadRequest:
                validationEror = new ValidationException("common.httpError.badRequest");
                break;
            case HttpCode.NotFound:
                validationEror = new ValidationException("common.httpError.notFound");
                break;
            case HttpCode.UnAuthorized:
                validationEror = new ValidationException("common.httpError.unAuthorized");
                break;
            default:
                validationEror = new ValidationException("common.httpError.genericError");
                break;
        }
        return validationEror;
    }
}