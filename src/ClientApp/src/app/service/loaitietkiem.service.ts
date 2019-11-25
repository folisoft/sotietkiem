import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { SavingBookApi } from './savingbook.api';

@Injectable()
export class LoaiTietKiemService {

	constructor (
        private _savingBookApi: SavingBookApi
    ) { }

    getAll(): Observable <LoaiTietKiemModel[]> {
        return this._savingBookApi.get(`api/loaitietkiem`);
    }

    create(model: LoaiTietKiemModel): Observable<any> {
        return this._savingBookApi.post(`api/loaitietkiem`, model);
    }

    update(model: LoaiTietKiemModel) {
        return this._savingBookApi.put(`api/loaitietkiem`, model);
    }

    delete(id: number) {
        return this._savingBookApi.post(`api/loaitietkiem/delete?id=${id}`, null);
    }
}

export class LoaiTietKiemModel {
    id: number;
    tenLoaiTietKiem: string;
    laiSuat: number;
    ngayHieuLuc: Date;
  }