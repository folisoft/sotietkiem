import { Component, OnInit, ElementRef } from '@angular/core';
import { ROUTES } from '../sidebar/sidebar.component';
import { Location, LocationStrategy, PathLocationStrategy } from '@angular/common';
import { Router } from '@angular/router';
import { AuthorizeService } from 'src/app/service/authorize.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  public focus;
  public listTitles: any[];
  public location: Location;

  profile;

  constructor(location: Location,  private element: ElementRef, private router: Router,
    private authorizeService: AuthorizeService) {
    this.location = location;
  }

  ngOnInit() {
    this.listTitles = ROUTES.filter(listTitle => listTitle);
    this.getTitle();
  }

  getTitle(){
    this.profile = JSON.parse(localStorage.getItem('currentUser'));
    console.log(this.profile);
    return 'Dashboard';
  }

  async logout() {
    const result = await this.authorizeService.signOut();
    this.router.navigate(['login']);
  }

}
