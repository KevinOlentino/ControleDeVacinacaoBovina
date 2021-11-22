import {Component, Input, OnInit} from '@angular/core';
import {Produtor} from "../../../entities/produtor";
import {Municipio} from "../../../entities/municipio";
import {Propriedade} from "../../../entities/propriedade";
import {NgForm} from "@angular/forms";
import {PropriedadeService} from "../../../services/propriedade/propriedade.service";
import {MunicipioService} from "../../../services/municipio/municipio.service";

@Component({
  selector: 'app-editar-propriedade',
  templateUrl: './editar-propriedade.component.html',
  styleUrls: ['./editar-propriedade.component.css']
})
export class EditarPropriedadeComponent implements OnInit {

  @Input("propriedade") propriedade: Propriedade = new Propriedade();
  municipios: Municipio[] = [];

  constructor(private propriedadeService: PropriedadeService, private municipioService: MunicipioService) { }

  ngOnInit(): void {
    this.municipioService.listarMuncipios().subscribe(
      dados => this.municipios = dados,
      error => console.log(error)
    )
  }

  EditarPropriedade(frm: NgForm){
    this.propriedadeService.EditarPropriedade(this.propriedade.idPropriedade,this.propriedade).subscribe(
      dados => alert("Propriedade alterada com sucesso!"),
      error => alert("Erro ao alterar propriedade")
    )
  }


}
