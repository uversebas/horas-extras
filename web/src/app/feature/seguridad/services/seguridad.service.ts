import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { HttpService } from 'src/app/core/services/http.service';
import { environment } from 'src/environments/enviroment';
import { Login } from '../models/login';
import { Observable } from 'rxjs';
import { Token } from '../models/token';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable()
export class SeguridadService extends HttpService {

  constructor(protected override http: HttpClient, private jwtHelper: JwtHelperService) { super(http); }

  public obtenerUsuarios() {
    const endpoint = `${environment.endpoint}Seguridad`;
    return this.doGet<any>(endpoint);
  }

  public iniciarSesion(login: Login): Observable<Token> {
    const endpoint = `${environment.endpoint}Seguridad/IniciarSesion`;
    return this.doPost<Login, Token>(endpoint, login);
  }

  obtenerClaims(token: string) {
    if (token) {
      const decodedToken = this.jwtHelper.decodeToken(token);
      sessionStorage.setItem('token', token);
      sessionStorage.setItem('idColaborador', decodedToken['idColaborador']);
    }
  }
}
