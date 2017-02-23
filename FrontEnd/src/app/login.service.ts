import { Injectable } from '@angular/core';
import{Http, Headers, Response} from '@angular/http';
import 'rxjs/Rx';

@Injectable()
export class LoginService {

  constructor(private http:Http) { }

  pushData(user: any) {
    const myJSON = JSON.stringify(user);
    const headers = new Headers();
    headers.append( 'Content-Type', 'application/json' );
    return this.http.post("http://localhost:11681/api/user/login",myJSON,{headers:headers}).map((response:Response)=>response.json()
    );
  }
}
