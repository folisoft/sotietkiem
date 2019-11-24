import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Router } from '@angular/router';

@Component({
    selector: 'thongke',
    templateUrl: 'thongke.component.html',
    styleUrls: ['./thongke.component.scss']
})

export class ThongKeComponent implements OnInit {
    constructor(
        private modalService: NgbModal,
        private router: Router,
    ) { }
    TableDoanhSo = 'Báo cáo Doanh sổ Hoạt động Ngày';
    TableMoDong = 'Báo cáo Mở/Đóng sổ Tháng';
    columnNameDoanhSo = [];
    columnNameMoDong = [];

    ngOnInit() { 
        this.columnNameDoanhSo = COLUMNDOANHSO;
        this.columnNameMoDong = COLUMNMODONG;
    }
}

export const COLUMNDOANHSO = [
    {prop: '', name: 'STT'},
    {prop: '', name: 'Loại Tiết Kiệm'},
    {prop: '', name: 'Tổng Thu'},
    {prop: '', name: 'Tổng Chi'},
    {prop: '', name: 'Chênh Lệch'},
]

export const COLUMNMODONG = [
    {prop: '', name: 'STT'},
    {prop: '', name: 'Ngày'},
    {prop: '', name: 'Sổ Mở'},
    {prop: '', name: 'Sổ Đóng'},
    {prop: '', name: 'Chênh Lệch'},
] 