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

  private _user: Observable<IUser>;

  constructor(private _api: SavingBookApi) {}

  public isAuthenticated(): Observable<boolean> {
    return this.getUser().pipe(map(u => !!u));
  }

  public getUser(): Observable<IUser | null> {
    return this._user;
  }

  public getAccessToken(): Observable<string> {
    return from(this._user)
      .pipe(mergeMap(() => from(this._user)),
        map(user => user && user.access_token));
  }
  
  public async register(model): Promise<any> {
    let user: any = null;
    try {
      user = await this._api.post('account/register', model).toPromise();
      return user;

    } catch (silentError) {
      // User might not be authenticated, fallback to popup authentication
      console.log(silentError);

    }
  }


  public async signIn(model): Promise<any> {
    let user: any = null;
    try {
      user = await this._api.post('account/login', model).toPromise();
      localStorage.setItem('currentUser', user);
      return user;

    } catch (silentError) {
      // User might not be authenticated, fallback to popup authentication
      console.log(silentError);

    }
  }

  public async signOut(): Promise<any> {
    try {
      var rs = await this._api.post('account/signout', this._user);
      localStorage.setItem('currentUser', null)
      this._user = null;
      return rs;
    } catch (popupSignOutError) {
      console.log(popupSignOutError);
    }
  }
}
