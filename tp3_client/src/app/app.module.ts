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
import { ImageServices } from './services/image-services';
import { PicturePipe } from './pipe/picture.pipe';
import { FullSizeImageComponent } from './full-size-image/full-size-image.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [				
    AppComponent,
      RegisterComponent,
      PublicGalleriesComponent,
      MyGalleriesComponent,
      LoginComponent,
      PicturePipe,
      FullSizeImageComponent
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
  ImageServices,
  {provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi:true}],
  bootstrap: [AppComponent]
})
export class AppModule { }
