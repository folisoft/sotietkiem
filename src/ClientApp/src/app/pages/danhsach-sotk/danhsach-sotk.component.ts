import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { MoSoTkModal } from './danhsach-sotk-modal/mo-sotk-modal.component';
import { Router } from '@angular/router';
import { PhieuGuiRutModal } from './danhsach-sotk-modal/phieu-gui-rut-modal.component';
import { SoTietKiemService, SoTietKiemResponse } from 'src/app/service/soktietkiem.service';
import { LoaiTietKiemService, LoaiTietKiemModel } from 'src/app/service/loaitietkiem.service';

@Component({
    selector: 'ds-sotk',
    templateUrl: 'danhsach-sotk.component.html',
    styleUrls: ['./danhsach-sotk.component.scss']
})

export class DanhSachSoTKComponent implements OnInit {
    constructor(
        private modalService: NgbModal,
        private router: Router,
        private soTietKiemService: SoTietKiemService,
        private _loaiTietKiemService: LoaiTietKiemService,
    ) { }
    TableName = 'Danh sách Sổ tiết kiệm';
    columnName = [];
    rows: SoTietKiemResponse[];
    loaiTietKiems = [];
    idLoaiDuocChon: any;
    searchKey = '';

    ngOnInit() { 
        this.columnName = COLUMNNAME;

        this._loaiTietKiemService.getAll().subscribe((res: LoaiTietKiemModel[]) => {
            this.loaiTietKiems = res.map(item => ({value: item.id, name: item.tenLoaiTietKiem}));
        });
        this.idLoaiDuocChon = '';
        this.getData();
    }

    moSoTK() {
        this.router.navigate(['/mo-sotk']);
    }

    getData() {
        this.soTietKiemService.getDanhMucSoTK(this.idLoaiDuocChon, this.searchKey).subscribe(rs => {
            this.rows = rs;
        });
    }

    lapPhieuGuiTien(row) {
        var modalRef = this.modalService.open(PhieuGuiRutModal,{ centered: true, size: 'lg' });
        modalRef.componentInstance.action = 'Gửi';
        modalRef.componentInstance.mskh = row.mskh;
        modalRef.componentInstance.khachhang = row.khachHang;
        modalRef.componentInstance.cmnd = row.cmnd;
        modalRef.result.then(rs => {
            this.getData();
        })
        .catch(err => {});
    }

    lapPhieuRutTien(row) {
        var modalRef = this.modalService.open(PhieuGuiRutModal, { centered: true, size: 'lg' });
        modalRef.componentInstance.action = 'Rút';
        modalRef.componentInstance.mskh = row.mskh;
        modalRef.componentInstance.khachhang = row.khachHang;
        modalRef.componentInstance.cmnd = row.cmnd;
        modalRef.result.then(rs => {
            this.getData();
        })
        .catch(err => {});
    }


}

export const COLUMNNAME = [
    {prop: '', name: 'STT'},
    // {prop: 'mskh', name: 'Mã Số'},
    {prop: 'loaiTietKiemId', name: 'Loại Tiết Kiệm'},
    {prop: 'khachHang', name: 'Khách Hàng'},
    {prop: 'cmnd', name: 'CMND'},
    {prop: 'ngayMoSo', name: 'Ngày mở sổ'},
    {prop: 'ngayDongSo', name: 'Ngày đóng sổ'},
    {prop: 'soDu', name: 'Số Dư'},
]
