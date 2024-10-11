import { UserModel } from './../../core/models/user.model';
import { Injectable } from "@angular/core";
import { BaseService } from "./base.service";
import { HttpClient } from "@angular/common/http";
import { map } from 'rxjs';

@Injectable()
export class LoginService extends BaseService {
    constructor(private http: HttpClient) { super() }

    login(user: UserModel) {
        let response = this.http
            .post(this.URL + 'login', user, this.getAuthHeaderJson())
            .pipe(
                map(this.extractData)
            )

        return response;
    }
}