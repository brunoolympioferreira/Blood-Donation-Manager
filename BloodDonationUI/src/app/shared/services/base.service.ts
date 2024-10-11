import { HttpHeaders } from "@angular/common/http";
import { environment } from "../../../environments/environment";
import { LocalStorageUtils } from "../utils/local-storage";

export abstract class BaseService {
    public LocalStorage = new LocalStorageUtils();
    protected URL: string = environment.url

    protected getHeaderJson() {
        return {
            headers: new HttpHeaders({
                'Content-type': 'application/json'
            })
        };
    }

    protected getAuthHeaderJson() {
        return {
            headers: new HttpHeaders({
                'Content-type': 'application/json',
                'Authorization': `Bearer ${this.LocalStorage.getUserToken()}`
            })
        };
    }

    protected extractData(response: any) {
        return response || {};
    }
}