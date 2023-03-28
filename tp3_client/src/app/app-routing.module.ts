import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { MyGalleriesComponent } from './myGalleries/myGalleries.component';
import { PublicGalleriesComponent } from './publicGalleries/publicGalleries.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
  {path:"", redirectTo:"/publicGalleries", pathMatch:"full"},
  {path:"publicGalleries", component:PublicGalleriesComponent},
  {path:"myGalleries", component:MyGalleriesComponent},
  {path:"register", component:RegisterComponent},
  {path:"login", component:LoginComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
