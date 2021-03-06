import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

declare interface RouteInfo {
    path: string;
    title: string;
    icon: string;
    class: string;
}
export const ROUTES: RouteInfo[] = [
    // { path: '/thongke', title: 'Báo cáo Thống kê',  icon: 'ni-chart-bar-32 text-primary', class: '' },
    { path: '/ds-sotk', title: 'Tra cứu sổ tiết kiệm',  icon: 'ni-collection text-info', class: '' },
    { path: '/mo-sotk', title: 'Mở sổ tiết kiệm',  icon: 'ni-fat-add text-primary', class: '' },
    { path: '/loaitietkiem', title: 'Loại tiết kiệm',  icon:'ni-paper-diploma text-info', class: '' },
    { path: '/dinhmuc', title: 'Định mức',  icon:'ni-paper-diploma text-info', class: '' },
    { path: '/quydinh', title: 'Quy định',  icon:'ni-key-25 text-info', class: '' },
    { path: '/baocaodoanhso', title: 'Báo cáo doanh số',  icon:'ni-key-25 text-info', class: '' },
    { path: '/baocaomodong', title: 'Báo cáo mở đóng',  icon:'ni-key-25 text-info', class: '' },
];

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {

  public menuItems: any[];
  public isCollapsed = true;

  currentRoute: string;
  constructor(private router: Router) { }

  ngOnInit() {
    this.getCurrentRouteURL();
    this.menuItems = ROUTES.filter(menuItem => menuItem);
    this.router.events.subscribe((event) => {
      this.isCollapsed = true;
   });
  }

  getCurrentRouteURL() {
    this.currentRoute = this.router.url;
  }
}
