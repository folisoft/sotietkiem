import { Component, Input } from '@angular/core';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
    selector: 'phieu-gui-rut-modal',
    templateUrl: './phieu-gui-rut-modal.component.html'
})
export class PhieuGuiRutModal {
    constructor(private activeModal: NgbActiveModal) { }

    @Input() action: string;

    
}