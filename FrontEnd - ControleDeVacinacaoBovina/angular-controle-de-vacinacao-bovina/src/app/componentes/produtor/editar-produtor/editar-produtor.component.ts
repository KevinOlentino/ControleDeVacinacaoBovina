import {ProdutorService} from '../../../services/produtor/produtor.service';
import {NgForm} from '@angular/forms';
import {AfterViewInit, Component, Input, OnInit, ViewChild} from '@angular/core';
import {Produtor} from 'src/app/entities/produtor';
import {Municipio} from "../../../entities/municipio";
import {MunicipioService} from "../../../services/municipio/municipio.service";
import {HttpErrorResponse} from "@angular/common/http";

@Component({
  selector: 'app-editar-produtor',
  templateUrl: './editar-produtor.component.html',
  styleUrls: ['./editar-produtor.component.css']
})
export class EditarProdutorComponent implements OnInit, AfterViewInit {

  @Input("produtor") produtor: Produtor = new Produtor();
  municipios: Municipio[] = [];
  @ViewChild('buttonClose')
  private buttonClose: { nativeElement: { click: () => any; }; } | undefined;
  @ViewChild('frm')
  private frm!: NgForm ;

  error: any;

  constructor(private produtorService: ProdutorService, private municipioService: MunicipioService) {
  }

  ngOnInit() {
    this.municipioService.listarMuncipios().subscribe(
      dados => this.municipios = dados,
      error => console.log(error)
    )
  }

  ngAfterViewInit() {
    // @ts-ignore
    document.getElementById('editarProdutor').addEventListener('hidden.bs.modal',
      (event) => {
        this.error = undefined;
        this.frm.reset()
      }, false)
  }

  editarProdutor(frm: NgForm) {
    this.produtorService.EditarProdutor(this.produtor.idProdutor, this.produtor).subscribe(
      dados => {
        this.buttonClose?.nativeElement.click(),
          alert("Produtor atualizado com sucesso!"),
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
