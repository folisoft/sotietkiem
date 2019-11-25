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
}

export class LoaiTietKiemModel {
    id: number;
    tenLoaiTietKiem: string;
    laiSuat: number;
    ngayHieuLuc: Date;
  }