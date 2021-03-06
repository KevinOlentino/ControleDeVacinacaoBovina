import { Endereco } from '../../../entities/endereco';
import { Municipio } from '../../../entities/municipio';
import { ProdutorService } from '../../../services/produtor/produtor.service';
import {AfterViewInit, Component, Input, OnInit, ViewChild} from '@angular/core';
import { NgForm } from '@angular/forms';
import { Produtor } from 'src/app/entities/produtor';
import {MunicipioService} from "../../../services/municipio/municipio.service";
import {HttpErrorResponse} from "@angular/common/http";

@Component({
  selector: 'app-produtor',
  templateUrl: './produtor.component.html',
  styleUrls: ['./produtor.component.css']
})

export class ProdutorComponent implements OnInit,AfterViewInit {
  produtor: Produtor = new Produtor();
  municipios: Municipio[] = []
  @ViewChild('frm')
  private frm!: NgForm ;
  @ViewChild('buttonClose')
  private buttonClose: { nativeElement: { click: () => any; }; } | undefined;

  error: any;

  constructor(private produtorService: ProdutorService, private municipioService: MunicipioService) { }

  ngOnInit() {
    this.municipioService.listarMuncipios().subscribe(
      dados => {this.municipios = dados, console.log(this.municipios)},
      error => console.log(error)
    )
  }
  ngAfterViewInit() {
    // @ts-ignore
    document.getElementById('adicionarProdutor').addEventListener('hidden.bs.modal',
      (event) => {
      this.error = undefined;
      this.frm.reset({idMunicipio: 0})
    }, false)
  }

  incluir(frm: NgForm){
   this.produtorService.CadastrarProdutor(this.produtor).subscribe(
     dados => {
       this.buttonClose?.nativeElement.click(),
         alert("Produtor cadastrada com sucesso!"),
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
      console.log(this.error)
    }
  }
}
