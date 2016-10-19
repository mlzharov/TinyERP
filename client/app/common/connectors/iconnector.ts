import {Http} from "angular2/http";
import {Promise} from "../models/promise";
export interface IConnector {
    setHttp(http: Http): void;
    getJSON(jsonPath: string): Promise;
    post(url: string, data: any): Promise;
    put(url: string, data: any): Promise;
    get(url: string): Promise;
    delete(url: string): Promise;
}