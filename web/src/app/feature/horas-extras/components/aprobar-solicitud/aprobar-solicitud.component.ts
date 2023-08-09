import { Component, Input, OnInit } from '@angular/core';
import { SolicitudHorasExtra } from '../../models/solicitudHorasExtras';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { HorasExtrasService } from '../../services/horas-extras.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AprobarSolicitudHorasExtra } from '../../models/aprobarSolicitudHorasExtra';

@Component({
  selector: 'app-aprobar-solicitud',
  templateUrl: './aprobar-solicitud.component.html',
  styleUrls: ['./aprobar-solicitud.component.sass']
})
export class AprobarSolicitudComponent implements OnInit {
  @Input() solicitud!: SolicitudHorasExtra;
  @Input() horasExtraService!: HorasExtrasService;
  aprobarSolicitudForm!: FormGroup;
  solicitudAprobada = false;
  constructor(private formBuilder: FormBuilder, public activeModal: NgbActiveModal) { }

  ngOnInit(): void {
    this.inicializarFormulario();
  }

  inicializarFormulario() {
    this.aprobarSolicitudForm = this.formBuilder.group({
      comentario: ['', Validators.required]
    });
  }

  aprobarSolicitud() {
    this.solicitudAprobada = true;
  }

  rechazarSolicitud() {
    this.solicitudAprobada = false;
  }

  enviarSolicitud() {
    if (this.aprobarSolicitudForm.valid) {
      const colaboradorId = sessionStorage.getItem('idColaborador');
      const aprobacion: AprobarSolicitudHorasExtra = {
        aprobado: this.solicitudAprobada,
        colaboradorId: colaboradorId!,
        comentario: this.aprobarSolicitudForm.getRawValue().comentario,
        solicitudId: this.solicitud.id
      };
      this.horasExtraService.aprobarSolicitud(aprobacion).subscribe({
        next: (respuesta: any) => {

        }, error: (err) => {
          alert(err);
        }
      })
    }
  }

  cerrarModal() {
    this.activeModal.dismiss();
  }
}
