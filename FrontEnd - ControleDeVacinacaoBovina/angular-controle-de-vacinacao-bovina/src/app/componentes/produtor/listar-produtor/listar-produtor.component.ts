import { AppComponent } from '../../../app.component';
import { ProdutorService } from '../../../services/produtor/produtor.service';
import {Component, OnInit, Output} from '@angular/core';
import { Produtor } from 'src/app/entities/produtor';
import {Router} from "@angular/router";

@Component({
  selector: 'app-listar-produtor',
  templateUrl: './listar-produtor.component.html',
  styleUrls: ['./listar-produtor.component.css']
})
export class ListarProdutorComponent implements OnInit {

  produtores: Produtor[] = [];
  CPF: string = '';
  @Output("produtor") produtor: Produtor = new Produtor();

  constructor(private produtorService: ProdutorService,
              private router: Router,
              private app: AppComponent) { }

  ngOnInit() {
    this.produtorService.ListarTodosProdutores().subscribe(
      dados => {this.produtores = dados, console.log(this.produtores)},
      error => {console.log("Error ao listar produtores",error)}
    )
  }

  selecionarProdutor(id: Number, nome: string){
    this.app.setProdutor(id,nome);
    this.router.navigate([``])
  }

  detalhesProdutor(cpf:string){
    this.router.navigate([`/Produtor/${cpf}`])
  }

  pesquisarPorCPF(){
    this.router.navigate([`/Produtor/${this.CPF}`])
  }

  getProdutor(produtor: Produtor){
    this.produtor.idProdutor = produtor.idProdutor;
    this.produtor.nome = produtor.nome;
    this.produtor.cpf = produtor.cpf;
    this.produtor.endereco.rua = produtor.endereco.rua;
    this.produtor.endereco.numero = produtor.endereco.numero;
    this.produtor.endereco.idEndereco = produtor.endereco.idEndereco;
    this.produtor.endereco.idMunicipio = produtor.endereco.idMunicipio;
  }

}
