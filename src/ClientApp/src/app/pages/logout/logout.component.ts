import { Component } from '@angular/core';
import { AuthorizeService } from '../../service/authorize.service';
import { BehaviorSubject } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.css']
})
export class LogoutComponent {
  public message = new BehaviorSubject<string>(null);
  public model: any;

  constructor(
    private authorizeService: AuthorizeService,
    private activatedRoute: ActivatedRoute,
    private router: Router) { }


  private async logout() {
    if (this.authorizeService.isAuthenticated) {
      const result = await this.authorizeService.signOut();
    } else {
      this.message.next('You successfully logged out!');
    }
  }

}
