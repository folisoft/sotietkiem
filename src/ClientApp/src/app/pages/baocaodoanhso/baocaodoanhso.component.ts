import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { BaoCaoService, BaoCaoModel } from 'src/app/service/baocao.service';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'baocaodoanhso',
  templateUrl: './baocaodoanhso.component.html',
  styleUrls: ['./baocaodoanhso.component.scss']
})
export class BaoCaoDoanhSoComponent implements OnInit {

  constructor (
    private _modalService: NgbModal,
    private _baoCaoService: BaoCaoService,
    private dp: DatePipe
  ) { }
  baocaos: BaoCaoModel[] = [];
  ngay = new Date();
  ngaychon = this.dp.transform(new Date(), 'yyyy-MM-dd');
  ngOnInit() {
    this.getBaoCao(this.ngaychon);
  }

  getBaoCao(ngayChon: string) {
    this._baoCaoService.getBaoCaoDoanhSo(ngayChon).subscribe((res:BaoCaoModel[]) => {
      if (res && res.length > 0) {
        this.baocaos = res;
      }
      else {
        this.baocaos = [];
      }
    })
  }

  onChangeDate() {
    this.getBaoCao(this.ngaychon);
  }
}

