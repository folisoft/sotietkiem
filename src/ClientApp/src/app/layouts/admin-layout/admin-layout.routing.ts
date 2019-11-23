import { Routes } from '@angular/router';

import { DashboardComponent } from '../../pages/dashboard/dashboard.component';
import { TablesComponent } from '../../pages/tables/tables.component';
import { UserProfileComponent } from '../../pages/user-profile/user-profile.component';
import { DanhSachSoTKComponent } from 'src/app/pages/danhsach-sotk/danhsach-sotk.component';

export const AdminLayoutRoutes: Routes = [
    { path: 'thongke', component: DashboardComponent },
    { path: 'user-profile', component: UserProfileComponent },
    { path: 'tables',         component: TablesComponent },
    { path: 'ds-sotk',         component: DanhSachSoTKComponent },
];
