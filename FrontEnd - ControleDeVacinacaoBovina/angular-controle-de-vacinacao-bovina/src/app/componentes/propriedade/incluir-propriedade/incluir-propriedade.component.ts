import { Component, OnInit } from '@angular/core';
import {Propriedade} from "../../../entities/propriedade";
import {Municipio} from "../../../entities/municipio";
import {NgForm} from "@angular/forms";
import {PropriedadeService} from "../../../services/propriedade/propriedade.service";
import {MunicipioService} from "../../../services/municipio/municipio.service";

@Component({
  selector: 'app-incluir-propriedade',
  templateUrl: './incluir-propriedade.component.html',
  styleUrls: ['./incluir-propriedade.component.css']
})
export class IncluirPropriedadeComponent implements OnInit {

  propriedade: Propriedade = new Propriedade();
  municipios: Municipio[] = [];
  idProdutor?: number = Number(localStorage.getItem('idProdutor')?.toString());

  constructor(private propriedadeService: PropriedadeService, private municipioService: MunicipioService) { }

  ngOnInit(): void {
    this.municipioService.listarMuncipios().subscribe(
      dados => {this.municipios = dados, console.log(this.municipios)},
      error => console.log(error)
    )
  }

  IncluirPropriedade(frm: NgForm){

    if(this.idProdutor){
      this.propriedade.idProdutor = this.idProdutor;
    }

    this.propriedadeService.CadastrarPropriedade(this.propriedade).subscribe(
      dados => alert("Propriedade cadastrada com sucesso!"),
      error => alert("Erro ao cadastrar propriedade")
    )

  }

}
