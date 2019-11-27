import { Injectable } from '@angular/core';
import { from, Observable } from 'rxjs';
import { map, mergeMap } from 'rxjs/operators';
import { SavingBookApi } from './savingbook.api';

export type IAuthenticationResult =
  SuccessAuthenticationResult |
  FailureAuthenticationResult |
  RedirectAuthenticationResult;

export interface SuccessAuthenticationResult {
  status: AuthenticationResultStatus.Success;
  state: any;
}

export interface FailureAuthenticationResult {
  status: AuthenticationResultStatus.Fail;
  message: string;
}

export interface RedirectAuthenticationResult {
  status: AuthenticationResultStatus.Redirect;
}

export enum AuthenticationResultStatus {
  Success,
  Redirect,
  Fail
}

export interface IUser {
  name: string;
  access_token: string;
}

@Injectable({
  providedIn: 'root'
})
export class AuthorizeService {

  user;

  constructor(private _api: SavingBookApi) {}

  public isAuthenticated(): boolean {
    return this.user != null;
  }

  public getUser(): Observable<IUser | null> {
    return this.user;
  }
  
  public async register(model): Promise<any> {
      return await this._api.post('account/register', model).toPromise();
  }


  public async signIn(model): Promise<any> {
    const rs = await this._api.post('account/login', model).toPromise();
    return rs;
  }

  public async profile(email): Promise<any> {
    const rs = await this._api.get(`account/profile?email=${email}`).toPromise();
    return rs;
  }

  public async signOut(): Promise<any> {
    try {
      const rs = await this._api.post('account/logout', null);
      sessionStorage.removeItem('currentUser');
      this.user = null;
      return rs;
    } catch (popupSignOutError) {
      console.log(popupSignOutError);
    }
  }
}
