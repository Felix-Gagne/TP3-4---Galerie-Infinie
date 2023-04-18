import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserServices } from './services/user-services';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  constructor(public router : Router, public service : UserServices){}

  async logout(){
    await this.service.logout();
  }
  
}
