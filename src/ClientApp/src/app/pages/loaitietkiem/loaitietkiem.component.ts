import { Component, OnInit } from '@angular/core';
import { QuyDinhService, QuyDinhModel } from 'src/app/service/quydinh.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { LoaiTietKiemService, LoaiTietKiemModel } from 'src/app/service/loaitietkiem.service';

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
    this._loaiTietKiemService.getAll().subscribe((res: LoaiTietKiemModel[]) => {
      this.loaiTietKiems = res;
    })
  }

  detail(noidung: any) {

  }
}

