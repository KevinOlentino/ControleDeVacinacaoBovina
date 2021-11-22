import { ProdutorService } from '../../../services/produtor/produtor.service';
import { NgForm } from '@angular/forms';
import {Component, Input, OnInit} from '@angular/core';
import { Produtor } from 'src/app/entities/produtor';
import {Municipio} from "../../../entities/municipio";
import {MunicipioService} from "../../../services/municipio/municipio.service";

@Component({
  selector: 'app-editar-produtor',
  templateUrl: './editar-produtor.component.html',
  styleUrls: ['./editar-produtor.component.css']
})
export class EditarProdutorComponent implements OnInit {

  @Input("produtor") produtor: Produtor = new Produtor();
  municipios: Municipio[] = [];

  constructor(private produtorService: ProdutorService, private municipioService: MunicipioService) { }

  ngOnInit() {
    this.municipioService.listarMuncipios().subscribe(
      dados => this.municipios = dados,
      error => console.log(error)
    )
  }

  EditarProdutor(frm: NgForm){
    this.produtorService.EditarProdutor(this.produtor.idProdutor,this.produtor).subscribe(
      dados => {alert("Produtor alterado com sucesso"), console.log(dados)},
      error => {alert("Erro ao alterar Produtor"), console.log(error)}
    )
  }

}
