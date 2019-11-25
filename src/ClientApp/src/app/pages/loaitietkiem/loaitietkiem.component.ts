import { Component, OnInit } from '@angular/core';
import { QuyDinhService, QuyDinhModel } from 'src/app/service/quydinh.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { LoaiTietKiemService, LoaiTietKiemModel } from 'src/app/service/loaitietkiem.service';
import { ThemLoaiTietKiemComponent } from './popup/themloaitietkiem.component';
import { ThongbaoComponent } from './popup/thongbao.component';

@Component({
  selector: 'loaitietkiem',
  templateUrl: './loaitietkiem.component.html',
  styleUrls: ['./loaitietkiem.component.scss']
})
export class LoaiTietKiemComponent implements OnInit {

  constructor (
    private _modalService: NgbModal,
    private _loaiTietKiemService: LoaiTietKiemService
  ) { }

  loaiTietKiems: LoaiTietKiemModel[] = [];

  ngOnInit() {
    this.get();
  }

  get() {
    this._loaiTietKiemService.getAll().subscribe((res: LoaiTietKiemModel[]) => {
      this.loaiTietKiems = res;
    })
  }

  create() {
    const modalRef = this._modalService
               .open(ThemLoaiTietKiemComponent, {windowClass: 'bootstrap-popup in', backdropClass: 'sq-payment-modal-backdrop', size: 'lg', centered: true, backdrop: 'static'});      
		modalRef.result.then((result) => {
			if(result == true) {
        
        this.get();
			}
		}, (reason) => {});
  }

  update(loaiTietKiem: LoaiTietKiemModel) {
    const modalRef = this._modalService
        .open(ThemLoaiTietKiemComponent, {windowClass: 'bootstrap-popup in', backdropClass: 'sq-payment-modal-backdrop', size: 'lg', centered: true, backdrop: 'static'});      
        modalRef.componentInstance.loaiTietKiem = loaiTietKiem;
        modalRef.result.then((result) => {
          if(result == true) {
            this.get();
          }
        }, (reason) => {});
  }

  delete(id: number) {
    const modalRef = this._modalService
        .open(ThongbaoComponent, {windowClass: 'bootstrap-popup in', backdropClass: 'sq-payment-modal-backdrop', size: 'lg', centered: true, backdrop: 'static'});      
        modalRef.componentInstance.id = id;
        modalRef.result.then((result) => {
          if(result == true) {
            this.get();
          }
        }, (reason) => {});
  }
}

