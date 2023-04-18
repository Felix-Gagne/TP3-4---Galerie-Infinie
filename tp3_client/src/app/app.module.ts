import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material.module';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { RegisterComponent } from './register/register.component';
import { PublicGalleriesComponent } from './publicGalleries/publicGalleries.component';
import { MyGalleriesComponent } from './myGalleries/myGalleries.component';
import { LoginComponent } from './login/login.component';
import { GalleryServices } from './services/gallery-services';
import { UserServices } from './services/user-services';
import { AuthInterceptor } from './auth.interceptor';

@NgModule({
  declarations: [				
    AppComponent,
      RegisterComponent,
      PublicGalleriesComponent,
      MyGalleriesComponent,
      LoginComponent
   ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    HttpClientModule
  ],
  providers: [GalleryServices,
  UserServices,
  {provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi:true}],
  bootstrap: [AppComponent]
})
export class AppModule { }
