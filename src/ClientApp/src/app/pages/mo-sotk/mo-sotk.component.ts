import { Component, OnInit } from '@angular/core';
import { SoTietKiemRequest, SoTietKiemService } from 'src/app/service/soktietkiem.service';
import { NgbDate } from '@ng-bootstrap/ng-bootstrap';
import { ToastService } from 'src/app/service/toast.service';
import { LoaiTietKiemService, LoaiTietKiemModel } from 'src/app/service/loaitietkiem.service';
import { Router } from '@angular/router';

@Component({
    selector: 'mo-sotk',
    templateUrl: 'mo-sotk.component.html',
    styleUrls: ['./mo-sotk.component.scss']
})

export class MoSoTKComponent implements OnInit {
    constructor(
        private sotietkiemService: SoTietKiemService,
        private toastService: ToastService,
        private _loaiTietKiemService: LoaiTietKiemService,
        private router: Router,
    ) { }
    TableName = 'Mở Sổ Tiết kiệm';
    soTietKiem = new SoTietKiemRequest();
    loaiTietKiems = [];
    currentDate = new NgbDate(null, null, null);
    minDate: any;

    ngOnInit() {
        this._loaiTietKiemService.getAll().subscribe((res: LoaiTietKiemModel[]) => {
            this.loaiTietKiems = res.map(item => ({ value: item.id, name: item.tenLoaiTietKiem }));
        });

        this.soTietKiem.LoaiTietKiemId = 1;
        this.soTietKiem.Mskh = 'TK001';
        this.soTietKiem.KhachHang = 'Lê Hiếu';
        this.soTietKiem.Cmnd = '365214789';
        this.soTietKiem.DiaChi = 'ấp Định Mỹ, xã Định Môn, huyện Thới Lai, Tp.CT';
        this.soTietKiem.SoTienGui = 1000000;

        const date = new Date();
        this.minDate = { year: date.getFullYear(), month: date.getMonth() + 1, day: date.getDate() };
    }

    moSoTietKiem() {
        let validate = this.validateToast();
        if (validate) {
            this.soTietKiem.NgayMoSo = this.currentDate.year.toString() +
                '-' + (this.currentDate.month).toString() + '-' + this.currentDate.day.toString();
            this.moSo();
        }
    }

    moSo() {
        this.sotietkiemService.moSoTietKiem(this.soTietKiem).subscribe(rs => {
            if (rs.status) {
                this.toastService.show(rs.message, 'Thông báo', { classname: 'bg-success text-light', delay: 1400 });
                setTimeout(() => { this.router.navigate(['ds-sotk']); }, 1500);
            } else {
                this.toastService.show(rs.message,
                    'Thông báo', { classname: 'bg-danger text-light', delay: 4000 });
            }
        },
            err => {
                this.toastService.show('Mở sổ thất bại. Vui lòng thử lại sau!',
                    'Thông báo', { classname: 'bg-danger text-light', delay: 2000 });
            },
            () => { });
    }

    validateToast(): boolean {
        if (this.soTietKiem.Mskh === '' || this.soTietKiem.KhachHang === ''
            || this.soTietKiem.Cmnd === '' || this.soTietKiem.DiaChi === ''
            || this.currentDate.year === null || this.soTietKiem.SoTienGui === null) {
            this.toastService.show('Vui lòng điền đầy đủ thông tin Mở sổ.', 'Thông báo',
                { classname: 'bg-danger text-light', delay: 4000 });
            return false;
        }
        return true;
    }
}
