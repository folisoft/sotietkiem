import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


import { AdminLayoutRoutes } from './admin-layout.routing';
import { TablesComponent } from '../../pages/tables/tables.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { UserProfileComponent } from '../../pages/user-profile/user-profile.component';
import { QuydinhComponent } from 'src/app/pages/quydinh/quydinh.component';
import { DanhSachSoTKComponent } from 'src/app/pages/danhsach-sotk/danhsach-sotk.component';
import { MoSoTKComponent } from 'src/app/pages/mo-sotk/mo-sotk.component';
import { PhieuGuiRutModal } from 'src/app/pages/danhsach-sotk/danhsach-sotk-modal/phieu-gui-rut-modal.component';
import { ThongKeComponent } from 'src/app/pages/thongke/thongke.component';

// import { ToastrModule } from 'ngx-toastr';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(AdminLayoutRoutes),
    FormsModule,
    HttpClientModule,
    NgbModule,
  ],
  declarations: [
    UserProfileComponent,
    QuydinhComponent,
    TablesComponent,
    DanhSachSoTKComponent,
    MoSoTKComponent,
    ThongKeComponent,

    // MoSoTkModal,
    // PhieuRutModal,
    PhieuGuiRutModal,
  ],
  exports: [],
  entryComponents: [
    // MoSoTkModal,
    // PhieuRutModal,
    PhieuGuiRutModal,
  ]
})

export class AdminLayoutModule {}
