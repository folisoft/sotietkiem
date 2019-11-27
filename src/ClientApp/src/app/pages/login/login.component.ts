import { Component, OnInit, OnDestroy } from '@angular/core';
import { AuthorizeService, AuthenticationResultStatus } from 'src/app/service/authorize.service';
import { BehaviorSubject } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  public message = new BehaviorSubject<string>(null);

  model = {
    Email: '',
    Password: '',
    RememberMe: false,
    ReturnUrl: ''
  };
  errors = [];
  invalids = {};

  constructor(
    private authorizeService: AuthorizeService,
    private activatedRoute: ActivatedRoute,
    private router: Router) { }


  async login(): Promise<void> {
    this.errors = [];
    this.invalids = {};
    try {
      const result = await this.authorizeService.signIn(this.model);
      if (result.errors && result.errors.length) {
        this.errors = result.errors;
      }
      if (result.succeeded) {
        const profile = await this.authorizeService.profile();
        localStorage.setItem('currentUser', profile);
        this.router.navigate(['']);
      }
    } catch (silentError) {
      console.log(silentError);
      this.invalids = silentError.error.errors || silentError.error;
    }
  }
}
