import { environment } from './../../environments/environment';

let _API: string = '';
let _WEBURL: string = '';

if (environment.production) {
    _API = '/api/';
    _WEBURL = '/';
} else {
    _API = 'http://localhost:5000/api/';
    _WEBURL = '/';
}
export const API = _API;
export const WEBURL = _WEBURL;
