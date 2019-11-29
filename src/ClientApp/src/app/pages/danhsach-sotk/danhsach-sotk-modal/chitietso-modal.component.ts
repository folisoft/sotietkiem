import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { GuiRutTienService } from 'src/app/service/guiruttien.service';

@Component({
    selector: 'chitietso-modal',
    templateUrl: './chitietso-modal.component.html'
})
export class ChiTietSoModal implements OnInit{
    constructor(
        private activeModal: NgbActiveModal,
        private guiRutTienService: GuiRutTienService,
        ) { }
    
    @Input() khachhang: string;
    @Input() ngaymoso: string;
    @Input() cmnd: string;
    @Input() sodu: number;
    @Input() mskh: string;

    rows = [];
    columns = [];

    ngOnInit() {
        this.columns = COLUMNHEADER;
        this.guiRutTienService.getPhieuGuiRut(this.mskh).subscribe(rs => {
            this.rows = rs;
        });
    }
}

export const COLUMNHEADER = [
    { prop: '', name: 'STT' },
    {prop: 'nghiepvu', name: 'Nghiệp vụ'},
    {prop: 'ngay', name: 'Ngày thực hiện'},
    {prop: 'sotien', name: 'Số Tiền'},
    {prop: 'soducuoiky', name: 'Số Dư Cuối Kỳ'},
]