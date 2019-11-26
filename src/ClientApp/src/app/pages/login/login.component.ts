import { Component, OnInit, OnDestroy } from '@angular/core';
import { AuthorizeService, AuthenticationResultStatus } from 'src/app/service/authorize.service';
import { BehaviorSubject } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  public message = new BehaviorSubject<string>(null);

  public model: any;

  constructor(
    private authorizeService: AuthorizeService,
    private activatedRoute: ActivatedRoute,
    private router: Router) { }

  async ngOnInit() {
   
  }


  async login(): Promise<void> {
    this.model.ReturnUrl = "";
    const result = await this.authorizeService.signIn(this.model);
  }
}