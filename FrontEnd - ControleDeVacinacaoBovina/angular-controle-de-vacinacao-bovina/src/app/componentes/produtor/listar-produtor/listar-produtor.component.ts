import { AppComponent } from '../../../app.component';
import { ProdutorService } from '../../../services/produtor/produtor.service';
import { Component, OnInit } from '@angular/core';
import { Produtor } from 'src/app/entities/produtor';

@Component({
  selector: 'app-listar-produtor',
  templateUrl: './listar-produtor.component.html',
  styleUrls: ['./listar-produtor.component.css']
})
export class ListarProdutorComponent implements OnInit {

  produtores: Produtor[] = [];

  constructor(private produtorService: ProdutorService, private app: AppComponent) { }

  ngOnInit() {
    this.produtorService.ListarTodosProdutores().subscribe(
      dados => {this.produtores = dados, console.log(this.produtores)},
      error => {console.log("Error ao listar produtores",error)}
    )
  }

  selecionarProdutor(id: Number, nome: string){
    this.app.setProdutor(id,nome);
  }

}
