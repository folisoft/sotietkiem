import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthorizeService } from 'src/app/service/authorize.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {

  model = {
    Name: '',
    Email: '',
    Password: '',
    ConfirmPassword: '',
    ReturnUrl: ''
  };
  errors = [];
  invalids = {};

  constructor(
    private authorizeService: AuthorizeService,
    private activatedRoute: ActivatedRoute,
    private router: Router) { }

  async signUp(): Promise<void> {
    this.errors = [];
    this.invalids = {};
    try {
      const result = await this.authorizeService.register(this.model);
      if (result.errors && result.errors.length) {
        this.errors = result.errors;
      }
      if (result.succeeded) {
        this.router.navigate(['login']);
      }
    } catch (silentError) {
      console.log(silentError.error.errors);
      this.invalids = silentError.error.errors || silentError.error;
    }
  }
}
