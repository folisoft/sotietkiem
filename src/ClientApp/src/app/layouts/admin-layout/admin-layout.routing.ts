import { Routes } from '@angular/router';

import { TablesComponent } from '../../pages/tables/tables.component';
import { UserProfileComponent } from '../../pages/user-profile/user-profile.component';
import { QuydinhComponent } from 'src/app/pages/quydinh/quydinh.component';
import { DanhSachSoTKComponent } from 'src/app/pages/danhsach-sotk/danhsach-sotk.component';
import { MoSoTKComponent } from 'src/app/pages/mo-sotk/mo-sotk.component';
import { ThongKeComponent } from 'src/app/pages/thongke/thongke.component';
import { LoaiTietKiemComponent } from 'src/app/pages/loaitietkiem/loaitietkiem.component';
import { DinhMucComponent } from 'src/app/pages/dinhmuc/dinhmuc.component';
import { BaoCaoDoanhSoComponent } from 'src/app/pages/baocaodoanhso/baocaodoanhso.component';
import { BaoCaoMoDongComponent } from 'src/app/pages/baocaomodong/baocaomodong.component';

export const AdminLayoutRoutes: Routes = [
    { path: '', component: BaoCaoMoDongComponent },
    // { path: 'thongke', component: ThongKeComponent },
    { path: 'ds-sotk', component: DanhSachSoTKComponent },
    { path: 'mo-sotk', component: MoSoTKComponent },
    { path: 'user-profile', component: UserProfileComponent },
    { path: 'quydinh', component: QuydinhComponent },
    { path: 'loaitietkiem', component: LoaiTietKiemComponent },
    { path: 'dinhmuc', component: DinhMucComponent },
    { path: 'baocaodoanhso', component: BaoCaoDoanhSoComponent },
    { path: 'baocaomodong', component: BaoCaoMoDongComponent },
    // { path: 'tables', component: TablesComponent }
];
