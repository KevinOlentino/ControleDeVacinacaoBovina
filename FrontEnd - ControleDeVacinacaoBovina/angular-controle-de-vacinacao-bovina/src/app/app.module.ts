import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AnimalComponent } from 'src/app/componentes/animal/listar-animal/animal.component';
import { ProdutorComponent } from 'src/app/componentes/produtor/incluir-produtor/produtor.component';
import { RegistrovacinaComponent } from 'src/app/componentes/registrovacina/listar-registrovacina/registrovacina.component';
import { VendaComponent } from 'src/app/componentes/venda/listar-venda/venda.component';
import { PropriedadeComponent } from 'src/app/componentes/propriedade/listar-propriedade/propriedade.component';
import { ListarProdutorComponent } from 'src/app/componentes/produtor/listar-produtor/listar-produtor.component';
import {EditarProdutorComponent} from "./componentes/produtor/editar-produtor/editar-produtor.component";
import { EditarPropriedadeComponent } from './componentes/propriedade/editar-propriedade/editar-propriedade.component';
import { IncluirAnimalComponent } from './componentes/animal/incluir-animal/incluir-animal.component';
import { IncluirPropriedadeComponent } from './componentes/propriedade/incluir-propriedade/incluir-propriedade.component';
import { IncluirRegistrovacinaComponent } from './componentes/registrovacina/incluir-registrovacina/incluir-registrovacina.component';
import { IncluirVendaComponent } from './componentes/venda/incluir-venda/incluir-venda.component';
import { CancelarAnimalComponent } from './componentes/animal/cancelar-animal/cancelar-animal.component';
import { CancelarVendaComponent } from './componentes/venda/cancelar-venda/cancelar-venda.component';
import { CancelarRegistrovacinaComponent } from './componentes/registrovacina/cancelar-registrovacina/cancelar-registrovacina.component';


@NgModule({
  declarations: [
    AppComponent,
    AnimalComponent,
    ProdutorComponent,
    RegistrovacinaComponent,
    VendaComponent,
    PropriedadeComponent,
    ListarProdutorComponent,
    EditarProdutorComponent,
    EditarPropriedadeComponent,
    IncluirAnimalComponent,
    IncluirPropriedadeComponent,
    IncluirRegistrovacinaComponent,
    IncluirVendaComponent,
    CancelarAnimalComponent,
    CancelarVendaComponent,
    CancelarRegistrovacinaComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
