import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GestionarUsuariosComponent } from './gestionar-usuarios/gestionar-usuarios.component';
import { GestionarAreasComponent } from './gestionar-areas/gestionar-areas.component';
import { AdministracionRoutingModule } from './administracion-routing.module';



@NgModule({
  declarations: [
    GestionarUsuariosComponent,
    GestionarAreasComponent
  ],
  imports: [
    AdministracionRoutingModule,
    CommonModule
  ]
})
export class AdministracionModule { }
