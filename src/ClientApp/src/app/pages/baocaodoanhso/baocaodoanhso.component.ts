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

  tongThu = 0;
  tongChi = 0;
  tongChenhLech = 0;
  showTongCong = false;
  getBaoCao(ngayChon: string) {
    this._baoCaoService.getBaoCaoDoanhSo(ngayChon).subscribe((res:BaoCaoModel[]) => {
      if (res && res.length > 0) {
        this.baocaos = res;

        this.reset();
        this.showTongCong = true;
        this.baocaos.map(item => {
          this.tongThu = this.tongThu + item.tongThu;
          this.tongChi = this.tongChi + item.tongChi;
          this.tongChenhLech = this.tongChenhLech + (item.tongThu - item.tongChi);
        });
      }
      else {
        this.showTongCong = false;
        this.baocaos = [];
      }
    })
  }

  reset() {
    this.tongThu = 0;
    this.tongChi = 0;
    this.tongChenhLech = 0;
  }

  onChangeDate() {
    this.getBaoCao(this.ngaychon);
  }
}

