import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CrearSolicitudComponent } from './components/crear-solicitud/crear-solicitud.component';
import { MisSolicitudesComponent } from './components/mis-solicitudes/mis-solicitudes.component';
import { SolicitudesGestionarComponent } from './components/solicitudes-gestionar/solicitudes-gestionar.component';
import { AprobarSolicitudComponent } from './components/aprobar-solicitud/aprobar-solicitud.component';
import { HorasExtrasRoutingModule } from './horas-extras-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { HorasExtrasService } from './services/horas-extras.service';
import { DetalleSolicitudComponent } from './components/detalle-solicitud/detalle-solicitud.component';



@NgModule({
  declarations: [
    CrearSolicitudComponent,
    MisSolicitudesComponent,
    SolicitudesGestionarComponent,
    AprobarSolicitudComponent,
    DetalleSolicitudComponent
  ],
  imports: [
    HorasExtrasRoutingModule,
    CommonModule,
    SharedModule
  ],
  providers: [HorasExtrasService]
})
export class HorasExtrasModule { }
