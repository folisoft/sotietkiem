import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { SavingBookApi } from './savingbook.api';

@Injectable()
export class QuyDinhService {

	constructor (
        private _savingBookApi: SavingBookApi
    ) { }

    getAll(): Observable <QuyDinhModel[]> {
        return this._savingBookApi.get(`/quydinh`);
    }
}

export class QuyDinhModel {
    msqd: string;
    ngay: Date;
    noiDung: string;
  }