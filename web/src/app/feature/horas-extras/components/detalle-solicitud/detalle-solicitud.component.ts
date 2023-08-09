import { Component, Input } from '@angular/core';
import { SolicitudHorasExtra } from '../../models/solicitudHorasExtras';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-detalle-solicitud',
  templateUrl: './detalle-solicitud.component.html',
  styleUrls: ['./detalle-solicitud.component.sass']
})
export class DetalleSolicitudComponent {
  @Input() solicitud!: SolicitudHorasExtra;
  constructor(public activeModal: NgbActiveModal) {}

  cerrarModal() {
    this.activeModal.dismiss();
  }

  mostrarRazonesRechazo() {
    return this.solicitud.estado !== 'Pendiente';
  }
}
