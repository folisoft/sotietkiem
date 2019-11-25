import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { QuyDinhService } from "./quydinh.service";
import { SavingBookApi } from "./savingbook.api";
import { LoaiTietKiemService } from "./loaitietkiem.service";

@NgModule({
    declarations: [

    ],
    imports: [
        CommonModule,
        FormsModule
    ],
    providers: [
        QuyDinhService,
        LoaiTietKiemService,
        SavingBookApi
    ],
    entryComponents: [
    ]
})

export class ServiceModule {
}