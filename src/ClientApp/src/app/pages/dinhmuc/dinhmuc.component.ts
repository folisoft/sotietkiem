import { Component, OnInit } from '@angular/core';
import { QuyDinhService, QuyDinhModel } from 'src/app/service/quydinh.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { DinhMucService, DinhMucModel } from 'src/app/service/dinhmuc.service';
import { ToastService } from 'src/app/service/toast.service';

@Component({
  selector: 'dinhmuc',
  templateUrl: './dinhmuc.component.html',
  styleUrls: ['./dinhmuc.component.scss']
})
export class DinhMucComponent implements OnInit {

  constructor (
    private _modalService: NgbModal,
    private _dinhMucService: DinhMucService,
    private _toastService: ToastService,
  ) { }

  dinhMuc = new DinhMucModel();
  
  ngOnInit() {
    this._dinhMucService.get().subscribe((res: DinhMucModel) => {
      this.dinhMuc = res;
    })
  }

  save() {
    this._dinhMucService.update(this.dinhMuc).subscribe((res: DinhMucModel) => {
      this.dinhMuc = res;
      this._toastService.show("Lưu thành công", 'Thông báo', { classname: 'bg-success text-light', delay: 2000 });
    })
  }
}

