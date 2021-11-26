import {AfterViewInit, Component, Input, OnInit, ViewChild} from '@angular/core';
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
export class EditarPropriedadeComponent implements OnInit,AfterViewInit {

  @Input("propriedade") propriedade: Propriedade = new Propriedade();
  municipios: Municipio[] = [];
  @ViewChild('buttonClose')
  private buttonClose: { nativeElement: { click: () => any; }; } | undefined;
  @ViewChild('frm')
  private frm!: NgForm;

  error: any;

  constructor(private propriedadeService: PropriedadeService, private municipioService: MunicipioService) { }

  ngOnInit(): void {
    this.municipioService.listarMuncipios().subscribe(
      dados => this.municipios = dados,
      error => console.log(error)
    )
  }

  ngAfterViewInit() {
    // @ts-ignore
    document.getElementById('editarPropriedade').addEventListener('hidden.bs.modal',
      (event) => {
        this.error = ''
        this.frm.form.reset();
      }, false)
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
    if(this.error.errors != undefined){
      let error: string[] = [];
      this.error = this.error.errors;
      if(this.error["Endereco.Rua"][0] != undefined)
        this.error.Rua = this.error["Endereco.Rua"][0]
      if(this.error["Endereco.Numero"][0] != undefined)
        this.error.Numero = this.error["Endereco.Numero"][0]
      if(this.error["Endereco.IdMunicipio"][0] != undefined)
        this.error.Municipio = this.error["Endereco.IdMunicipio"][0]
    }
  }
}
