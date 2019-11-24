import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
    selector: 'mo-sotk',
    templateUrl: 'mo-sotk.component.html',
    styleUrls: ['./mo-sotk.component.scss']
})

export class MoSoTKComponent implements OnInit {
    constructor(
        private modalService: NgbModal,
    ) { }
    TableName = 'Mở Sổ iết kiệm';
    ngOnInit() { 
    }
}