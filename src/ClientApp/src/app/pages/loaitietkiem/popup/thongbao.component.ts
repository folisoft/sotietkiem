import { Component, OnInit, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { LoaiTietKiemService } from 'src/app/service/loaitietkiem.service';

@Component({
    selector: 'thongbao',
    templateUrl: 'thongbao.component.html',
})

export class ThongbaoComponent implements OnInit {
    @Input() id: number; 
    constructor(
        private _activeModal: NgbActiveModal,
        private _loaiTietKiemService: LoaiTietKiemService,
    ) { }

    ngOnInit() { 

    }

    delete() {
        this._loaiTietKiemService.delete(this.id).subscribe(res => {
            if (res) {
                this._activeModal.close(res);
            }
        });
    }

    close() {
        this._activeModal.close();
    }
}