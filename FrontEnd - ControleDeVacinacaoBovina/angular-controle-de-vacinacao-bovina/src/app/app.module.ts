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
import {EditarAnimalComponent} from "./componentes/animal/editar-animal/editar-animal/editar-animal.component";


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
    EditarAnimalComponent
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
