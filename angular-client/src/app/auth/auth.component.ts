import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.scss']
})
export class AuthComponent implements OnInit {

  form: FormGroup;
  private returnUrl: string;
  constructor(private authService: AuthService, private router: Router, 
    private activated: ActivatedRoute) { }

  ngOnInit() {
    this.activated.queryParams.subscribe(params => {
        this.returnUrl = params["returnUrl"];
    });

    this.form = new FormGroup({
      username: new FormControl(null),
      password: new FormControl(null)
    });
  }

  ngSubmit() {
    const username = this.form.get('username').value;
    const password = this.form.get('password').value;
    this.authService.authenticate(username, password).subscribe(() => {
      const url = this.returnUrl || '/';
      this.router.navigate([url]);
    }, (error) => {
      this.form.setErrors({
        notAuthorized: true
      });
    });
  }

}
