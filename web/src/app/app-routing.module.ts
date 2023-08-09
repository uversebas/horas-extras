import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: 'seguridad', loadChildren: () => import('./feature/seguridad/seguridad.module').then(m => m.SeguridadModule)},
  { path: 'horas-extras', loadChildren: () => import('./feature/horas-extras/horas-extras.module').then(m => m.HorasExtrasModule)},
  { path: 'administracion', loadChildren: () => import('./feature/administracion/administracion.module').then(m => m.AdministracionModule)},
  { path: '', loadChildren: () => import('./feature/home/home.module').then(m => m.HomeModule)}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
