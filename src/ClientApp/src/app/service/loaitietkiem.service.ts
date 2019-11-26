import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { SavingBookApi } from './savingbook.api';

@Injectable()
export class LoaiTietKiemService {

	constructor (
        private _savingBookApi: SavingBookApi
    ) { }

    private loaiTietKiemApi = 'loaitietkiem';

    getAll(): Observable <LoaiTietKiemModel[]> {
        return this._savingBookApi.get(this.loaiTietKiemApi);
    }

    create(model: LoaiTietKiemModel): Observable<any> {
        return this._savingBookApi.post(this.loaiTietKiemApi, model);
    }

    update(model: LoaiTietKiemModel) {
        return this._savingBookApi.put(this.loaiTietKiemApi, model);
    }

    delete(id: number) {
        return this._savingBookApi.post(`${this.loaiTietKiemApi}/delete?id=${id}`, null);
    }
}

export class LoaiTietKiemModel {
    id: number;
    tenLoaiTietKiem: string;
    laiSuat: number;
    kyHan: number;
    ngayHieuLuc: Date;
  }