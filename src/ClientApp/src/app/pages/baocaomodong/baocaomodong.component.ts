import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { BaoCaoService, BaoCaoMoDongModel } from 'src/app/service/baocao.service';
import { DatePipe } from '@angular/common';
import { SoTietKiemRequest } from 'src/app/service/soktietkiem.service';
import { LoaiTietKiemService, LoaiTietKiemModel } from 'src/app/service/loaitietkiem.service';

@Component({
  selector: 'baocaomodong',
  templateUrl: './baocaomodong.component.html',
  styleUrls: ['./baocaomodong.component.scss']
})
export class BaoCaoMoDongComponent implements OnInit {

  constructor (
    private _modalService: NgbModal,
    private _baoCaoService: BaoCaoService,
    private dp: DatePipe,
    private _loaiTietKiemService: LoaiTietKiemService,
  ) { }
  baocaos: BaoCaoMoDongModel[] = [];
  ngay = new Date();
  ngaychon = this.dp.transform(new Date(), 'yyyy-MM-dd');
  thang:any;
  loaiTietKiemId: number = 0;
  tenLoaiTietKiem: string;
  loaiTietKiems = [];

  ngOnInit() {
    this.thang = this.dp.transform(new Date(this.ngaychon), 'MM');
    this._loaiTietKiemService.getAll().subscribe((res: LoaiTietKiemModel[]) => {
      if (res) {
        this.loaiTietKiems = res.map(item => ({value: item.id, name: item.tenLoaiTietKiem}));
        this.tenLoaiTietKiem = res[0].tenLoaiTietKiem;
        this.loaiTietKiemId = Number(res[0].id);
        this.getBaoCao(this.loaiTietKiemId, this.ngaychon);
      }
    });
  }

  tongMo = 0;
  tongDong = 0;
  tongChenhLech = 0;
  showTongCong = false;
  getBaoCao(loaiTietKiem: number, ngayChon: string) {
    this._baoCaoService.getBaoCaoMoDong(loaiTietKiem, ngayChon).subscribe((res: BaoCaoMoDongModel[]) => {
      if (res && res.length > 0) {
        this.baocaos = res;

        this.reset();
        this.showTongCong = true;
        this.baocaos.map(item => {
          this.tongMo = this.tongMo + item.tongMo;
          this.tongDong = this.tongDong + item.tongDong;
          this.tongChenhLech = this.tongChenhLech + (item.tongMo + item.tongDong);
        });
      } else {
        this.showTongCong = false;
        this.baocaos = [];
      }
    })
  }

  reset() {
    this.tongMo = 0;
    this.tongDong = 0;
    this.tongChenhLech = 0;
  }

  onChangeDate(event: any) {
    if (event.length <= 0) {
      this.ngaychon = this.dp.transform(new Date(), 'yyyy-MM-dd');
    }
    this.thang = this.dp.transform(new Date(this.ngaychon), 'MM');
    this.getBaoCao(this.loaiTietKiemId, this.ngaychon);
  }

  onChange(event: any) {
    this.tenLoaiTietKiem = event;
    let loai = this.loaiTietKiems.filter(item => item.name == event);
    this.loaiTietKiemId = Number(loai[0].value);
    this.getBaoCao(this.loaiTietKiemId, this.ngaychon);
  }
}

