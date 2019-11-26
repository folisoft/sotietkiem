import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { SavingBookApi } from './savingbook.api';

@Injectable()
export class BaoCaoService {

	constructor (
        private _savingBookApi: SavingBookApi
    ) { }

    getBaoCaoDoanhSo(ngaychon: string): Observable <BaoCaoModel[]> {
        return this._savingBookApi.get(`baocao/doanhso?day=${ngaychon}`);
    }

    getBaoCaoMoDong(loaiTietKiem:number, thang: string): Observable <BaoCaoMoDongModel[]> {
        return this._savingBookApi.get(`baocao/modong?loaiTietKiem=${loaiTietKiem}&thang=${thang}`);
    }
}

export class BaoCaoModel {
    loaiTietKiemId: number;
    tenLoaiTietKiem: string;
    tongThu: number;
    tongChi: number;
  }

export class BaoCaoMoDongModel {
ngay: Date;
tongMo: number;
tongDong: number;
}