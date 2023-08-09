import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { SessionService } from '../../services/session.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.sass']
})
export class ToolbarComponent {
  esUsuarioLogueado = false;
  public nombre$: Observable<string>;

  constructor(private router: Router, private sessionService: SessionService) {
    this.nombre$ = this.sessionService.getNombreUsuario;
  }

  login() {
    this.router.navigate(['/seguridad/login']);
  }
  logout() {
    this.sessionService.cerrarSesion();
  }
}
