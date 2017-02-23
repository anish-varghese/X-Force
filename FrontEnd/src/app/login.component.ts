import { Component } from '@angular/core';
import { HeaderComponent } from './header.component';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { LoginService } from './login.service'
import { SearchComponent } from './search/search.component';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent {
  constructor(private loginservice: LoginService, private router: Router) { }
  public ValidationFlag: boolean = false;

  onsubmit(username: string, password: string) {
    this.loginservice.pushData({ username: username, password: password })
      .subscribe(data => {
        var valid = data.Status;
        if (!valid) {
          document.getElementById("errorMessage").textContent = "Incorrect username or password!!!";
        }
        else {

          if (data.Name && data.Id) {
            // store user details and jwt token in local storage to keep user logged in between page refreshes
            localStorage.setItem('currentUser', JSON.stringify(data));
            this.router.navigate(['/home']);
          }
        } });
  }
}
