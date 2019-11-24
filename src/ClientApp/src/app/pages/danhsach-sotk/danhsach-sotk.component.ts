import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { MoSoTkModal } from './danhsach-sotk-modal/mo-sotk-modal.component';
import { Router } from '@angular/router';
import { PhieuGuiRutModal } from './danhsach-sotk-modal/phieu-gui-rut-modal.component';

@Component({
    selector: 'ds-sotk',
    templateUrl: 'danhsach-sotk.component.html',
    styleUrls: ['./danhsach-sotk.component.scss']
})

export class DanhSachSoTKComponent implements OnInit {
    constructor(
        private modalService: NgbModal,
        private router: Router,
    ) { }
    TableName = 'Danh sách Sổ tiết kiệm';
    columnName = [];
    ngOnInit() { 
        this.columnName = COLUMNNAME;
    }

    moSoTK() {
        this.router.navigate(['/mo-sotk']);
        // const modalRef = this.modalService.open(MoSoTkModal,{ centered: true, size: 'lg' });
        // modalRef.result.then(rs => {
        //     console.log(rs);
        // });
    }

    lapPhieuGuiTien() {
        var modalRef = this.modalService.open(PhieuGuiRutModal,{ centered: true, size: 'lg' });
        modalRef.componentInstance.action = 'Gửi';
        modalRef.result.then(rs => {
            console.log(rs);
        });
    }

    lapPhieuRutTien() {
        var modalRef = this.modalService.open(PhieuGuiRutModal,{ centered: true, size: 'lg' });
        modalRef.componentInstance.action = 'Rút';
        modalRef.result.then(rs => {
            console.log(rs);
        });
    }
}

export const COLUMNNAME = [
    {prop: '', name: 'STT'},
    {prop: '', name: 'Mã Số'},
    {prop: '', name: 'Loại Tiết Kiệm'},
    {prop: '', name: 'Khách Hàng'},
    {prop: '', name: 'Số Dư'},
] 