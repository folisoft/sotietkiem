import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { SavingBookApi } from './savingbook.api';

@Injectable()
export class DinhMucService {

	constructor (
        private _savingBookApi: SavingBookApi
    ) { }

    get(): Observable <DinhMucModel> {
        return this._savingBookApi.get(`dinhmuc`);
    }

    update(model: DinhMucModel) {
        return this._savingBookApi.put(`dinhmuc`, model);
    }
}

export class DinhMucModel {
    id: number;
    tienGuiLanDauToiThieu: number;
  }