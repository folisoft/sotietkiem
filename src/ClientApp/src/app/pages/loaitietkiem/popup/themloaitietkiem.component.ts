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
    ngOnInit() { 
        this.ngayHieuLuc = this.dp.transform(this.loaiTietKiem.ngayHieuLuc, 'yyyy-MM-dd');
    }

    save() {
        this.loaiTietKiem.ngayHieuLuc = new Date(this.ngayHieuLuc);
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

    close() {
        this._activeModal.close();
    }
}