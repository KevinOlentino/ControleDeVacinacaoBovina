import {AfterViewInit, Component, OnInit, ViewChild} from '@angular/core';
import {Propriedade} from "../../../entities/propriedade";
import {Municipio} from "../../../entities/municipio";
import {FormBuilder, NgForm} from "@angular/forms";
import {PropriedadeService} from "../../../services/propriedade/propriedade.service";
import {MunicipioService} from "../../../services/municipio/municipio.service";
import {HttpErrorResponse} from "@angular/common/http";

@Component({
  selector: 'app-incluir-propriedade',
  templateUrl: './incluir-propriedade.component.html',
  styleUrls: ['./incluir-propriedade.component.css']
})
export class IncluirPropriedadeComponent implements OnInit, AfterViewInit {

  propriedade: Propriedade = new Propriedade();
  municipios: Municipio[] = [];
  idProdutor?: number = Number(localStorage.getItem('idProdutor')?.toString());
  @ViewChild('frm')
  private frm!: NgForm;
  @ViewChild('buttonClose')
  private buttonClose: { nativeElement: { click: () => any; }; } | undefined;

  private error: any;

  constructor(private propriedadeService: PropriedadeService, private municipioService: MunicipioService) {
  }

  ngOnInit(): void {
    this.municipioService.listarMuncipios().subscribe(
      dados => {
        this.municipios = dados, console.log(this.municipios)
      },
      error => console.log(error)
    )
  }
  ngAfterViewInit() {
    // @ts-ignore
    document.getElementById('adicionarPropriedade').addEventListener('hidden.bs.modal',
      (event) => {
        this.frm.form.reset({idMunicipio: 0});
      }, false)
  }

  IncluirPropriedade(frm: NgForm) {
    if (this.idProdutor)
      this.propriedade.idProdutor = this.idProdutor;
    this.propriedadeService.CadastrarPropriedade(this.propriedade).subscribe(
      dados => {
          this.buttonClose?.nativeElement.click(),
            alert("Propriedade cadastrada com sucesso!"),
          window.location.reload()
      },
      error => {
        this.registrarErro(error);
      }
    )
  }
  registrarErro(error: HttpErrorResponse) {
    this.error = error.error
    if (this.error.error != undefined)
      alert(this.error.error);
  }
}
