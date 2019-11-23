import { Component, OnInit } from '@angular/core';
import { QuyDinhService } from 'src/app/service/quydinh.service';

@Component({
  selector: 'quydinh',
  templateUrl: './quydinh.component.html',
  styleUrls: ['./quydinh.component.scss']
})
export class QuydinhComponent implements OnInit {

  constructor(
    private _quyDinhService: QuyDinhService
  ) { }
  quydinhs: QuyDinhModel[] = [];
  ngOnInit() {
    this._quyDinhService.getAll().subscribe((res: QuyDinhModel[]) => {
      debugger;
      this.quydinhs = res;
    })
  }

}
export class QuyDinhModel {
  Msqd: number;
  Ngay: Date;
  NoiDung: string;
}
