import { Component, OnInit, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { LoaiTietKiemModel, LoaiTietKiemService } from 'src/app/service/loaitietkiem.service';
import { DatePipe } from '@angular/common';

@Component({
    selector: 'themloaitietkiem',
    templateUrl: 'themloaitietkiem.component.html',
    styleUrls: ['./themloaitietkiem.component.scss']
})

export class ThemLoaiTietKiemComponent implements OnInit {
    @Input() loaiTietKiem = new LoaiTietKiemModel(); 
    constructor(
        private _activeModal: NgbActiveModal,
        private _loaiTietKiemService: LoaiTietKiemService,
        private dp: DatePipe
    ) { }
    ngayHieuLuc:any;
    tenLoaiTietKiemInvalid = false;
    kyHanInvalid = false;
    laiSuatInvalid = false;
    ngayHieuLucInvalid = false;

    ngOnInit() { 
        this.ngayHieuLuc = this.dp.transform(this.loaiTietKiem.ngayHieuLuc, 'yyyy-MM-dd');
    }

    checkValidate() {
        if (!this.loaiTietKiem.tenLoaiTietKiem || this.loaiTietKiem.tenLoaiTietKiem.length <= 0) {
            this.tenLoaiTietKiemInvalid = true;
            return false;
        } else {
            this.tenLoaiTietKiemInvalid = false;
        }
        if (!this.loaiTietKiem.laiSuat || this.loaiTietKiem.laiSuat == 0) {
            this.laiSuatInvalid = true;
            return false;
        } else {
            this.laiSuatInvalid = false;
        }
        if (!this.loaiTietKiem.kyHan) {
            this.kyHanInvalid = true;
            return false;
        } else {
            this.kyHanInvalid = false;
        }
        if (!this.loaiTietKiem.ngayHieuLuc || this.loaiTietKiem.ngayHieuLuc <= new Date('2010/01/01')) {
            this.ngayHieuLucInvalid = true;
            return false;
        } else {
            this.ngayHieuLucInvalid = false;
        }

        return true;
    }

    save() {
        this.loaiTietKiem.ngayHieuLuc = new Date(this.ngayHieuLuc);
        if (this.checkValidate()) {
            if (this.loaiTietKiem.id) {
                this._loaiTietKiemService.update(this.loaiTietKiem).subscribe(res => {
                    if (res) {
                        this._activeModal.close(res);
                    }
                  })
            }
            else {
                this._loaiTietKiemService.create(this.loaiTietKiem).subscribe(res => {
                    if (res) {
                        this._activeModal.close(res);
                    }
                  })
            }
        }
    }

    close() {
        this._activeModal.close();
    }
}