import {Component, OnInit, NgModule, Injectable, Input} from '@angular/core';
import {NgbActiveModal} from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'noidung-popup',
  templateUrl: './noidung-popup.html',
  styleUrls: ['./noidung-popup.scss']
})

export class NoidungPopup implements OnInit {
  @Input() noidung: string;  
  constructor(
        private _activeModal: NgbActiveModal){
  }
  
  ngOnInit() {    

  }

  close() {
    this._activeModal.close();
  }
}