import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ThemGuiRutTienRequest, GuiRutTienService } from 'src/app/service/guiruttien.service';

@Component({
    selector: 'phieu-gui-rut-modal',
    templateUrl: './phieu-gui-rut-modal.component.html'
})
export class PhieuGuiRutModal implements OnInit {
    constructor(
        private activeModal: NgbActiveModal,
        private guiRutTienService: GuiRutTienService,
        ) { }

    @Input() action: string;
    @Input() khachhang: string;
    @Input() mskh: string;
    request = new ThemGuiRutTienRequest();
    ngay: string;

    ngOnInit() {
        this.request.MSKH = this.mskh;
        this.request.KhachHang = this.khachhang;
        const currentDate = new Date();
        this.ngay = currentDate.toLocaleDateString();
        this.request.Ngay = currentDate.getFullYear() + '-' + (currentDate.getMonth() + 1) + '-' + currentDate.getDate();
    }

    submit() {
        this.setAction();
        this.guiRutTienService.themGuiRut(this.request).subscribe(rs => {
            console.log(rs);
        });
    }

    setAction() {
        if (this.action === 'Gửi') {
            this.request.Action = 'GUI';
        }
        if (this.action === 'Rút') {
            this.request.Action = 'RUT';
        }
    }
}
