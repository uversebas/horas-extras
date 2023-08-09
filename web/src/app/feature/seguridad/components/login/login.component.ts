import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SeguridadService } from '../../services/seguridad.service';
import { Login } from '../../models/login';
import { Token } from '../../models/token';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.sass']
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;

  constructor(private formBuilder: FormBuilder, private seguridadService: SeguridadService, private router: Router) {
  }

  ngOnInit(): void {
    this.inicializarFormulario();
    this.obtenerUsuarios();
  }

  inicializarFormulario() {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  obtenerUsuarios() {
    this.seguridadService.obtenerUsuarios().subscribe(respuesta => {
      console.log(respuesta);
    })
  }

  onSubmit() {
    if (this.loginForm.valid) {
      const login: Login = {
        nombreUsuario: this.loginForm.value.username,
        clave: this.loginForm.value.password
      };
      this.seguridadService.iniciarSesion(login).subscribe({
        next: (respuesta: Token) => {
          this.seguridadService.obtenerClaims(respuesta.token);
          this.router.navigate(['/']);
        }, error: () => {
          alert('Error');
        }
      })
    }
  }

}
