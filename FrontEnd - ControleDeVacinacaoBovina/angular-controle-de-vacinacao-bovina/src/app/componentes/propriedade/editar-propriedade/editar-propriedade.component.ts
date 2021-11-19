import { Component, OnInit } from '@angular/core';
import {Produtor} from "../../../entities/produtor";
import {Municipio} from "../../../entities/municipio";
import {Propriedade} from "../../../entities/propriedade";
import {NgForm} from "@angular/forms";
import {PropriedadeService} from "../../../services/propriedade/propriedade.service";

@Component({
  selector: 'app-editar-propriedade',
  templateUrl: './editar-propriedade.component.html',
  styleUrls: ['./editar-propriedade.component.css']
})
export class EditarPropriedadeComponent implements OnInit {

  propriedade!: Propriedade;
  municipios: Municipio[] = [];

  constructor(private propriedadeService: PropriedadeService) { }

  ngOnInit(): void {
  }

  EditarPropriedade(frm: NgForm){
    this.propriedadeService.EditarPropriedade(this.propriedade).subscribe(
      dados => alert("Propriedade alterada com sucesso!"),
      error => alert("Erro ao alterar propriedade")
    )
  }

}
