import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { QuyDinhService } from "./quydinh.service";
import { SavingBookApi } from "./savingbook.api";

@NgModule({
    declarations: [

    ],
    imports: [
        CommonModule,
        FormsModule
    ],
    providers: [
        QuyDinhService,
        SavingBookApi
    ],
    entryComponents: [
    ]
})

export class ServiceModule {
}