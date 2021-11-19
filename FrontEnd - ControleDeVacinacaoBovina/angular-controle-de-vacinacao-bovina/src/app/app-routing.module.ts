import { ListarProdutorComponent } from './componentes/produtor/listar-produtor/listar-produtor.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AnimalComponent } from 'src/app/componentes/animal/listar-animal/animal.component';
import { PropriedadeComponent } from 'src/app/componentes/propriedade/listar-propriedade/propriedade.component';
import { ProdutorComponent } from 'src/app/componentes/produtor/incluir-produtor/produtor.component';
import { VendaComponent } from 'src/app/componentes/venda/listar-venda/venda.component';
import { RegistrovacinaComponent } from 'src/app/componentes/registrovacina/listar-registrovacina/registrovacina.component';
import {IncluirAnimalComponent} from "./componentes/animal/incluir-animal/incluir-animal.component";
import {IncluirPropriedadeComponent} from "./componentes/propriedade/incluir-propriedade/incluir-propriedade.component";
import {IncluirRegistrovacinaComponent} from "./componentes/registrovacina/incluir-registrovacina/incluir-registrovacina.component";
import {IncluirVendaComponent} from "./componentes/venda/incluir-venda/incluir-venda.component";

const routes: Routes = [
  {path: "Animal", component: AnimalComponent},
  {path: "RegistroVacina/:id", component: RegistrovacinaComponent},
  {path: "Propriedade", component: PropriedadeComponent},
  {path: "Venda", component: VendaComponent},
  {path: "Venda/Add", component: IncluirVendaComponent},
  {path: "Produtor", component: ListarProdutorComponent},
  {path: "Produtor/Add", component: ProdutorComponent},
  {path: "Animal/Add", component: IncluirAnimalComponent},
  {path: "Propriedade/Add",component: IncluirPropriedadeComponent},
  {path: "RegistroVacina",component: IncluirRegistrovacinaComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
