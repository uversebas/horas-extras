import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './components/login/login.component';
import { SeguridadRoutingModule } from './seguridad-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { SeguridadService } from './services/seguridad.service';
import { JwtModule } from '@auth0/angular-jwt';

export function tokenGetter() {
  return localStorage.getItem('access_token');
}


@NgModule({
  declarations: [
    LoginComponent
  ],
  imports: [
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ['localhost:4200']
      }
    }),
    SeguridadRoutingModule,
    SharedModule,
    CommonModule
  ],
  providers: [SeguridadService]
})
export class SeguridadModule { }
