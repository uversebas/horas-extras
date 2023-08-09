import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SessionService {
  private nombreUsuarioObs$: BehaviorSubject<string> = new BehaviorSubject<string>('');
  constructor() { }

  get getNombreUsuario ()
  {
    return this.nombreUsuarioObs$.asObservable();
  }
  
  set setNombreUsuarioValue( valor: string)
  {
    this.nombreUsuarioObs$.next(valor);
  }

  iniciarSesion() { }

  cerrarSesion() { }
}
