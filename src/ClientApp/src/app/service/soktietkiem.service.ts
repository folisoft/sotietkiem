import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { SavingBookApi } from './savingbook.api';

@Injectable()
export class SoTietKiemService {

    constructor(
        private _savingBookApi: SavingBookApi
    ) { }

    private soTietKiemUrl = `/sotietkiem`;

    moSoTietKiem(request: SoTietKiemRequest): Observable<boolean> {
        let url = this.soTietKiemUrl + `/add`;
        return this._savingBookApi.post(url, request);
    }

    getLoaiTietkiem(): Observable<any> {
        let url = this.soTietKiemUrl + `/getloaitietkiem`;
        return this._savingBookApi.get(url);
    }
}

export class SoTietKiemRequest {
    Mskh: string;
    LoaiTietKiemId: number;
    KhachHang: string;
    Cmnd: string;
    DiaChi: string;
    NgayMoSo: string;
    SoTienGui: number;
    NgayDongSo: string;
}