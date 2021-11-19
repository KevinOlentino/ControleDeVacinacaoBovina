import { ProdutorService } from '../../../services/produtor/produtor.service';
import { NgForm } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { Produtor } from 'src/app/entities/produtor';
import {Municipio} from "../../../entities/municipio";

@Component({
  selector: 'app-editar-produtor',
  templateUrl: './editar-produtor.component.html',
  styleUrls: ['./editar-produtor.component.css']
})
export class EditarProdutorComponent implements OnInit {

  produtor!: Produtor;
  municipios: Municipio[] = [];

  constructor(private produtorService: ProdutorService) { }

  ngOnInit() {

  }

  EditarProdutor(frm: NgForm){
    this.produtorService.EditarProdutor(this.produtor).subscribe(
      dados => {alert("Produtor alterado com sucesso"), console.log(dados)},
      error => {alert("Erro ao alterar Produtor"), console.log(error)}
    )
  }

}
