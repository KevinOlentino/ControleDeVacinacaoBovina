import { ProdutorComponent } from './../componentes/produtor/produtor.component';
import { VendaComponent } from './../componentes/venda/venda.component';
import { PropriedadeComponent } from './../componentes/propriedade/propriedade.component';
import { RegistrovacinaComponent } from './../componentes/registrovacina/registrovacina.component';
import { AnimalComponent } from './../componentes/animal/animal.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {path: "Animal", component: AnimalComponent},
  {path: "RegistroVacina", component: RegistrovacinaComponent},
  {path: "Propriedade", component: PropriedadeComponent},
  {path: "Venda", component: VendaComponent},
  {path: "Produtor", component: ProdutorComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
