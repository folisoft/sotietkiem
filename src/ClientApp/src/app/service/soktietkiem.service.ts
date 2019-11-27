import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { SavingBookApi } from './savingbook.api';

@Injectable()
export class SoTietKiemService {

    constructor(
        private _savingBookApi: SavingBookApi
    ) { }

    private soTietKiemUrl = `sotietkiem`;

    moSoTietKiem(request: SoTietKiemRequest): Observable<any> {
        let url = this.soTietKiemUrl;
        return this._savingBookApi.post(url, request);
    }

    getDanhMucSoTK(LoaiTietKiemId: number, mskh: string): Observable<SoTietKiemResponse[]> {
        return this._savingBookApi.get(this.soTietKiemUrl + `?loaitietkiem=${LoaiTietKiemId}&mskh=${mskh}`);
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

export class SoTietKiemResponse {
    mskh: string;
    loaiTietKiemId: string;
    khachHang: string;
    cmnd: string;
    ngayMoSo: string;
    soDu: string;
}