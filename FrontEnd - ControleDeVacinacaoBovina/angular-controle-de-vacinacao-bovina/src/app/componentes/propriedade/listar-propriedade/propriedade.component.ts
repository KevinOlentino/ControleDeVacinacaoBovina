import { Propriedade } from '../../../entities/propriedade';
import { PropriedadeService } from '../../../services/propriedade/propriedade.service';
import {Component, OnInit, Output} from '@angular/core';
import {Router} from "@angular/router";

@Component({
  selector: 'app-propriedade',
  templateUrl: './propriedade.component.html',
  styleUrls: ['./propriedade.component.css']
})
export class PropriedadeComponent implements OnInit {

  constructor(private propriedadeService: PropriedadeService, private router: Router) { }

  idProdutor?: number = Number(localStorage.getItem('idProdutor')?.toString());
  propriedades: Propriedade[] = [];
  inscricaoEstadual: string = '';
  @Output("propriedade") propriedade: Propriedade = new Propriedade();

  ngOnInit() {
    if(this.idProdutor)
    this.propriedadeService.ListarPorProdutor(this.idProdutor).subscribe(
      dados => {this.propriedades = dados, console.log(this.propriedades)},
      error => console.log(error)
    )
  }

  getPropriedade(propriedade: Propriedade){
    this.propriedade.idPropriedade = propriedade.idPropriedade;
    this.propriedade.idEndereco = propriedade.idEndereco;
    this.propriedade.idProdutor = propriedade.idProdutor;
    this.propriedade.nome = propriedade.nome;
    this.propriedade.endereco.rua = propriedade.endereco.rua;
    this.propriedade.endereco.numero = propriedade.endereco.numero;
    this.propriedade.endereco.idEndereco = propriedade.endereco.idEndereco;
    this.propriedade.endereco.idMunicipio = propriedade.endereco.idMunicipio;
  }

  redirecionarParaPropriedade(inscricaoEstadual: string){
    console.log(`/Propriedade/${inscricaoEstadual}`)
    this.router.navigate([`/Propriedade/${inscricaoEstadual}`])
  }

  redirecionarPesquisa(){
    this.router.navigate([`/Propriedade/${this.inscricaoEstadual}`])
  }


}
