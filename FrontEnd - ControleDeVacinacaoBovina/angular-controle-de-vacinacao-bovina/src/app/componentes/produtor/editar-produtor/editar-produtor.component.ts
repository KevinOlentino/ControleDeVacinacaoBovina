import {ProdutorService} from '../../../services/produtor/produtor.service';
import {NgForm} from '@angular/forms';
import {Component, Input, OnInit, ViewChild} from '@angular/core';
import {Produtor} from 'src/app/entities/produtor';
import {Municipio} from "../../../entities/municipio";
import {MunicipioService} from "../../../services/municipio/municipio.service";
import {HttpErrorResponse} from "@angular/common/http";

@Component({
  selector: 'app-editar-produtor',
  templateUrl: './editar-produtor.component.html',
  styleUrls: ['./editar-produtor.component.css']
})
export class EditarProdutorComponent implements OnInit {

  @Input("produtor") produtor: Produtor = new Produtor();
  municipios: Municipio[] = [];
  @ViewChild('buttonClose')
  private buttonClose: { nativeElement: { click: () => any; }; } | undefined;

  private error: any;

  constructor(private produtorService: ProdutorService, private municipioService: MunicipioService) {
  }

  ngOnInit() {
    this.municipioService.listarMuncipios().subscribe(
      dados => this.municipios = dados,
      error => console.log(error)
    )
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
    if(this.error.exception)
      alert("Ops! Ocorreu um Erro, tente novamente ou mais tarde, se esse erro persistir contate a empresa!")
  }

}
