import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { SavingBookApi } from './savingbook.api';

@Injectable()
export class GuiRutTienService {

    constructor(
        private _savingBookApi: SavingBookApi
    ) { }

    private guiRutTienUrl = `guirutien`;

    themGuiRut(request: ThemGuiRutTienRequest): Observable<any> {
        return this._savingBookApi.post(this.guiRutTienUrl, request);
    }
}

export class ThemGuiRutTienRequest {
    MSKH: string;
    KhachHang: string;
    SoTien: number;
    Ngay: string;
    Action: string;
}