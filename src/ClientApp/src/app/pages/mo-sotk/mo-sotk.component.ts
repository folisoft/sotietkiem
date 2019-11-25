import { Component, OnInit } from '@angular/core';
import { SoTietKiemRequest, SoTietKiemService } from 'src/app/service/soktietkiem.service';
import { NgbDate } from '@ng-bootstrap/ng-bootstrap';
import { ToastService } from 'src/app/service/toast.service';

@Component({
    selector: 'mo-sotk',
    templateUrl: 'mo-sotk.component.html',
    styleUrls: ['./mo-sotk.component.scss']
})

export class MoSoTKComponent implements OnInit {
    constructor(
        private sotietkiemService: SoTietKiemService,
        private toastService: ToastService,
    ) { }
    TableName = 'Mở Sổ iết kiệm';
    soTietKiem = new SoTietKiemRequest();
    loaiTietKiems = [];
    currentDate: NgbDate;
    minDate: any;

    ngOnInit() {
        this.sotietkiemService.getLoaiTietkiem().subscribe(rs => {
            this.loaiTietKiems = rs;
        });

        this.soTietKiem.Mskh = 'TK001';
        this.soTietKiem.LoaiTietKiemId = 1;
        this.soTietKiem.KhachHang = 'Lê Hiếu';
        this.soTietKiem.Cmnd = '365214789';
        this.soTietKiem.DiaChi = 'ấp Định Mỹ, xã Định Môn, huyện Thới Lai, Tp.CT';
        this.soTietKiem.SoTienGui = 1000000;

        let date = new Date();
        this.minDate = {year: date.getFullYear(), month: date.getMonth() + 1, day: date.getDate()};
    }

    moSoTietKiem() {
        this.soTietKiem.NgayMoSo = this.currentDate.year.toString() +
            '-' + (this.currentDate.month).toString() + '-' + this.currentDate.day.toString();

        this.soTietKiem.NgayDongSo = this.currentDate.year.toString() +
            '-' + (this.currentDate.month + 1).toString() + '-' + this.currentDate.day.toString();
        this.sotietkiemService.moSoTietKiem(this.soTietKiem).subscribe(rs => {
            if (rs) {
                this.toastService.show('Mở sổ thành công!', 'Thông báo', { classname: 'bg-success text-light', delay: 2000 });
            } else {
                this.toastService.show('Mở sổ thất bại. Vui lòng thử lại sau!',
                    'Thông báo', { classname: 'bg-danger text-light', delay: 2000 });
            }
        },
        err => {this.toastService.show('Mở sổ thất bại. Vui lòng thử lại sau!', 'Thông báo', { classname: 'bg-danger text-light', delay: 2000 });},
        () => {});
    }
}
