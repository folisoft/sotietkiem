import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'ds-sotk',
    templateUrl: 'danhsach-sotk.component.html',
    styleUrls: ['./danhsach-sotk.component.scss']
})

export class DanhSachSoTKComponent implements OnInit {
    constructor() { }
    TableName = 'Danh sách Sổ tiết kiệm';
    columnName = [];
    ngOnInit() { 
        this.columnName = COLUMNNAME;
    }
}

export const COLUMNNAME = [
    {prop: '', name: 'STT'},
    {prop: '', name: 'Mã Số'},
    {prop: '', name: 'Loại Tiết Kiệm'},
    {prop: '', name: 'Khách Hàng'},
    {prop: '', name: 'Số Dư'},
] 