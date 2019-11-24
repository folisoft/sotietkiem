import { Component, OnInit } from '@angular/core';
import { QuyDinhService, QuyDinhModel } from 'src/app/service/quydinh.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { NoidungPopup } from './popup/noidung-popup';

@Component({
  selector: 'quydinh',
  templateUrl: './quydinh.component.html',
  styleUrls: ['./quydinh.component.scss']
})
export class QuydinhComponent implements OnInit {

  constructor (
    private _modalService: NgbModal,
    private _quyDinhService: QuyDinhService
  ) { }
  quydinhs: QuyDinhModel[] = [];
  ngOnInit() {
    this._quyDinhService.getAll().subscribe((res: QuyDinhModel[]) => {
      this.quydinhs = res;
    })
  }

  detail(noidung: any) {
    const modalRef = this._modalService
               .open(NoidungPopup, {windowClass: 'bootstrap-popup in', backdropClass: 'sq-payment-modal-backdrop', size: 'lg', centered: true});      
		modalRef.componentInstance.noidung = noidung;
		modalRef.result.then((result) => {
			if(result == true) {
			}
		}, (reason) => {});
  }
}

