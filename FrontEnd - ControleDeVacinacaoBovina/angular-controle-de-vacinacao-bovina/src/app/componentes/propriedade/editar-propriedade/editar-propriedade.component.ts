import {Component, Input, OnInit, ViewChild} from '@angular/core';
import {Produtor} from "../../../entities/produtor";
import {Municipio} from "../../../entities/municipio";
import {Propriedade} from "../../../entities/propriedade";
import {NgForm} from "@angular/forms";
import {PropriedadeService} from "../../../services/propriedade/propriedade.service";
import {MunicipioService} from "../../../services/municipio/municipio.service";
import {HttpErrorResponse} from "@angular/common/http";

@Component({
  selector: 'app-editar-propriedade',
  templateUrl: './editar-propriedade.component.html',
  styleUrls: ['./editar-propriedade.component.css']
})
export class EditarPropriedadeComponent implements OnInit {

  @Input("propriedade") propriedade: Propriedade = new Propriedade();
  municipios: Municipio[] = [];
  @ViewChild('buttonClose')
  private buttonClose: { nativeElement: { click: () => any; }; } | undefined;

  private error: any;

  constructor(private propriedadeService: PropriedadeService, private municipioService: MunicipioService) { }

  ngOnInit(): void {
    this.municipioService.listarMuncipios().subscribe(
      dados => this.municipios = dados,
      error => console.log(error)
    )
  }

  editarPropriedade(frm: NgForm){
    this.propriedadeService.EditarPropriedade(this.propriedade.idPropriedade,this.propriedade).subscribe(
      dados => {
        this.buttonClose?.nativeElement.click(),
          alert("Propriedade atualizado com sucesso!"),
          window.location.reload()
      },
      error => {
        console.log(error);
        this.registrarErro(error);
      }
    )
  }
  registrarErro(error: HttpErrorResponse) {
    this.error = error.error
    if (this.error.error != undefined)
      alert(this.error.error);
    if(this.error.exception)
      alert("Ops! Ocorreu um Erro, tente novamente ou mais tarde, se esse erro persistir contate a empresa!")
  }
}
