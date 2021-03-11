import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ClientesComponent } from './clientes/clientes.component';

const routes: Routes = [
  {
    path: '',
    component: ClientesComponent,
    children: [
      {
        path: '',
        component: ClientesComponent,
        data: null
      },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
