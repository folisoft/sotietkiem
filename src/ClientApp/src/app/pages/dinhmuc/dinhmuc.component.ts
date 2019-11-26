import { Component, OnInit } from '@angular/core';
import { QuyDinhService, QuyDinhModel } from 'src/app/service/quydinh.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { DinhMucService, DinhMucModel } from 'src/app/service/dinhmuc.service';

@Component({
  selector: 'dinhmuc',
  templateUrl: './dinhmuc.component.html',
  styleUrls: ['./dinhmuc.component.scss']
})
export class DinhMucComponent implements OnInit {

  constructor (
    private _modalService: NgbModal,
    private _dinhMucService: DinhMucService
  ) { }

  dinhMuc = new DinhMucModel();
  isSaved = false;
  ngOnInit() {
    this._dinhMucService.get().subscribe((res: DinhMucModel) => {
      this.dinhMuc = res;
    })
  }

  save() {
    this._dinhMucService.update(this.dinhMuc).subscribe((res: DinhMucModel) => {
      this.dinhMuc = res;
      this.isSaved = true;
    })
  }
}

