import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { GestionarUsuariosComponent } from "./gestionar-usuarios/gestionar-usuarios.component";
import { GestionarAreasComponent } from "./gestionar-areas/gestionar-areas.component";

const routes: Routes = [
    {
        path: 'usuario',
        component: GestionarUsuariosComponent
    },
    {
        path: 'areas',
        component: GestionarAreasComponent
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class AdministracionRoutingModule { }