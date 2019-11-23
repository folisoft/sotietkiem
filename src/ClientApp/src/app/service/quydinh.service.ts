import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { SavingBookApi } from './savingbook.api';

@Injectable()
export class QuyDinhService {

	constructor (
        private _savingBookApi: SavingBookApi
    ) { }

    public headers: Headers;

    getAll(): Observable<any> {
        return this._savingBookApi.get(`api/quydinh`);
    }
}