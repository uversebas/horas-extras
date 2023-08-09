import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { CrearSolicitudComponent } from "./components/crear-solicitud/crear-solicitud.component";
import { MisSolicitudesComponent } from "./components/mis-solicitudes/mis-solicitudes.component";
import { SolicitudesGestionarComponent } from "./components/solicitudes-gestionar/solicitudes-gestionar.component";

const routes: Routes = [
    {
        path: 'crear',
        component: CrearSolicitudComponent
    },
    {
        path: 'mis-solicitudes',
        component: MisSolicitudesComponent
    },
    {
        path: 'gestionar',
        component: SolicitudesGestionarComponent
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class HorasExtrasRoutingModule { }