import { Observable } from "rxjs";
import * as CONFIG from '../config/gobal';
import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';


@Injectable()
export class SavingBookApi {
    apiEnpoint: string;

    constructor(private _http: HttpClient) {

        this.apiEnpoint = CONFIG.API;
    }

    get<T>(apiUrl: string): Observable<T> | any {
        let url = this.apiEnpoint.concat(apiUrl);
        let options = this._getHttpHeader();

        return this._http.get(url, options)
            .pipe(map((rs: any) => {
                if (rs.ok) {
                    if (rs._body) {
                        return <T>rs;
                    } else {
                        return rs.ok;
                    }
                } else {
                    return rs;
                }
            }));
    }

    post<T>(apiUrl: string, body: any): Observable<T> | any {
        let url = this.apiEnpoint.concat(apiUrl);
        let options = this._getHttpHeader();

        return this._http.post(url, body, options)
            .pipe(map((rs: any) => {
                if (rs.ok) {
                    if (rs._body) {
                        return <T>rs;
                    } else {
                        return rs.ok;
                    }
                } else {
                    return rs;
                }
            }));
    }

    put<T>(apiUrl: string, body: any): Observable<T> | any {
        let url = this.apiEnpoint.concat(apiUrl);
        let options = this._getHttpHeader();

        return this._http.put(url, body, options)
            .pipe(map((rs: any) => {
                if (rs.ok) {
                    if (rs._body) {
                        return <T>rs;
                    } else {
                        return rs.ok;
                    }
                } else {
                    return rs;
                }
            }));
    }

    delete<T>(apiUrl: string): Observable<T> | any {
        let url = this.apiEnpoint.concat(apiUrl);
        let options = this._getHttpHeader();
        return this._http.delete(url, options)
            .pipe(map((rs: any) => {
                if (rs.ok) {
                    if (rs._body) {
                        return <T>rs;
                    } else {
                        return rs.ok;
                    }
                } else {
                    return rs;
                }
            }));
    }

    private _getAccessToken(): string {
        var profile: any = JSON.parse(sessionStorage.getItem('auth'));
        return profile ? profile.access_token : null;
    }

    private _getHttpHeader() {
        let accessToken = this._getAccessToken();
        // var headers = new HttpHeaders({ 'Authorization': `Bearer ${accessToken}` });
        var headers = new HttpHeaders({ 'Content-Type': `application/json` });
        var options = {
            headers: headers
        };
        return options;
    }
}