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
  loaiTietKiem: number;
  tenLoaiTietKiem: string;
  loaiTietKiems = [];

  ngOnInit() {
    this._loaiTietKiemService.getAll().subscribe((res: LoaiTietKiemModel[]) => {
      if (res) {
        this.loaiTietKiems = res.map(item => ({value: item.id, name: item.tenLoaiTietKiem}));
        this.tenLoaiTietKiem = res[0].tenLoaiTietKiem;
        console.log('id',res[0].id);
        this.getBaoCao(Number(res[0].id), this.ngaychon);
      }
    });
  }

  getBaoCao(loaiTietKiem: number, ngayChon: string) {
    this._baoCaoService.getBaoCaoMoDong(loaiTietKiem, ngayChon).subscribe(res => {
      if (res) {
        this.baocaos = res;
      } else {
        this.baocaos = [];
      }
    })
  }

  onChangeDate(event: any) {
    console.log('event',event);
  }

  onChange(event: any) {
    this.tenLoaiTietKiem = event;
    let loai = this.loaiTietKiems.filter(item => item.name == event);
    this.getBaoCao(Number(loai[0].value), this.ngaychon);
  }
}

