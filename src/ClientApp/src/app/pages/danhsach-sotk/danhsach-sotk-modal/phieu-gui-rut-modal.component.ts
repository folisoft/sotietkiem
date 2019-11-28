import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal, NgbModal, NgbDate } from '@ng-bootstrap/ng-bootstrap';
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
    @Input() cmnd: string;
    request = new ThemGuiRutTienRequest();
    ngay: NgbDate;
    minDate: any;

    ngOnInit() {
        this.request.MSKH = this.mskh;
        this.request.KhachHang = this.khachhang;
        const currentDate = new Date();

        this.minDate = { year: currentDate.getFullYear(), month: currentDate.getMonth() + 1, day: currentDate.getDate() };
    }

    submit() {
        this.request.Ngay = this.ngay.year + '-' + (this.ngay.month) + '-' + this.ngay.day;
        this.setAction();
        this.guiRutTienService.themGuiRut(this.request).subscribe(rs => {
            this.activeModal.close(rs);
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
