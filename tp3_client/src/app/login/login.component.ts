import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(public router : Router) { }

  ngOnInit() {
  }

  login(){
    // Retourner à la page d'accueil
    this.router.navigate(['/publicGalleries']);
  }

}
