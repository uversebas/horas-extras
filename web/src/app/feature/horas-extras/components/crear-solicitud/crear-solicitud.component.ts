import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EnumTipoSolicitud } from '../../models/enum-tipoSolicitud';
import { Router } from '@angular/router';
import { HorasExtrasService } from '../../services/horas-extras.service';
import { CrearSolicitudHorasExtra } from '../../models/crearSolicitudHorasExtra';

@Component({
  selector: 'app-crear-solicitud',
  templateUrl: './crear-solicitud.component.html',
  styleUrls: ['./crear-solicitud.component.sass']
})
export class CrearSolicitudComponent implements OnInit {

  crearSolicitudForm!: FormGroup;
  tiposSolicitud = EnumTipoSolicitud;
  radioDias = EnumTipoSolicitud.dias;
  radioDinero = EnumTipoSolicitud.dinero;
  tipoSolicitud = EnumTipoSolicitud.dias;

  constructor(private formBuilder: FormBuilder, private router: Router, private horasExtrasService: HorasExtrasService) { }

  ngOnInit(): void {
    this.inicializarFormulario();
  }

  inicializarFormulario() {
    this.crearSolicitudForm = this.formBuilder.group({
      cantidadDias: ['', [Validators.required, Validators.min(1)]],
      motivo: ['', Validators.required]
    });
  }

  onChangeTipoSolicitud(tipo: any) {
    this.tipoSolicitud = EnumTipoSolicitud[tipo as keyof typeof EnumTipoSolicitud];
  }

  enverSolicitud() {
    if (this.crearSolicitudForm.valid) {
      const idColaborador = sessionStorage.getItem('idColaborador');
      const solicitud: CrearSolicitudHorasExtra = {
        colaboradorId: idColaborador!,
        cantidadDias: this.crearSolicitudForm.getRawValue().cantidadDias,
        motivo: this.crearSolicitudForm.getRawValue().motivo,
        tipoSolicitud: this.tipoSolicitud
      };
      this.horasExtrasService.crearSolicitud(solicitud).subscribe({
        next: (respuesta: any) => {

        }, error: (err) => {
          alert(err);
        }
      })
    }
  }

  cancelar() {
    this.router.navigate(['/']);
  }
}
