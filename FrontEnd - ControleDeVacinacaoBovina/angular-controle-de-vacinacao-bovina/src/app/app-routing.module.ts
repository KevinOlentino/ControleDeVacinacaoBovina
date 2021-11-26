import { ListarProdutorComponent } from './componentes/produtor/listar-produtor/listar-produtor.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AnimalComponent } from 'src/app/componentes/animal/listar-animal/animal.component';
import { PropriedadeComponent } from 'src/app/componentes/propriedade/listar-propriedade/propriedade.component';
import { VendaComponent } from 'src/app/componentes/venda/listar-venda/venda.component';
import { RegistrovacinaComponent } from 'src/app/componentes/registrovacina/listar-registrovacina/registrovacina.component';
import {BemVindoComponent} from "./componentes/bem-vindo/bem-vindo.component";
import {DetalhesPropriedadeComponent} from "./componentes/propriedade/detalhes-propriedade/detalhes-propriedade.component";
import {DetalhesProdutorComponent} from "./componentes/produtor/detalhes-produtor/detalhes-produtor.component";

const routes: Routes = [
  {path: "", component: BemVindoComponent},
  {path: "Animal", component: AnimalComponent},
  {path: "Propriedade", component: PropriedadeComponent},
  {path: "Venda", component: VendaComponent},
  {path: "Produtor", component: ListarProdutorComponent},
  {path: "RegistroVacina",component: RegistrovacinaComponent},
  {path: "Propriedade/:inscricaoEstadual", component: DetalhesPropriedadeComponent},
  {path: "Produtor/:cpf", component: DetalhesProdutorComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
