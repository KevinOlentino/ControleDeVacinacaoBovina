import {AfterViewInit, Component, OnInit, ViewChild} from '@angular/core';
import {NgForm} from "@angular/forms";
import {RegistrovacinaService} from "../../../services/registrovacina/registrovacina.service";
import {RegistroVacina} from "../../../entities/registrovacinacao";
import {Animal} from "../../../entities/animal";
import {Vacina} from "../../../entities/vacina";
import {AnimalService} from "../../../services/animal/animal.service";
import {VacinaService} from "../../../services/vacina/vacina.service";
import {HttpErrorResponse} from "@angular/common/http";
import {Rebanho} from "../../../entities/rebanho";
import {RebanhoService} from "../../../services/rebanho/rebanho.service";

@Component({
  selector: 'app-incluir-registrovacina',
  templateUrl: './incluir-registrovacina.component.html',
  styleUrls: ['./incluir-registrovacina.component.css']
})
export class IncluirRegistrovacinaComponent implements OnInit, AfterViewInit {

  idProdutor?: number = Number(localStorage.getItem('idProdutor')?.toString());
  registroVacina: RegistroVacina = new RegistroVacina();
  rebanhos: Rebanho[] = [];
  vacinas: Vacina[] = [];

  @ViewChild('frm')
  private frm!: NgForm;
  @ViewChild('buttonClose')
  private buttonClose: { nativeElement: { click: () => any; }; } | undefined;

  private error: any;

  constructor(private registroVacinaService: RegistrovacinaService, private rebanhoService: RebanhoService,
              private vacinaService: VacinaService) {
  }

  ngOnInit(): void {
    if (this.idProdutor)
      this.rebanhoService.listarPorProdutor(this.idProdutor).subscribe(
        dados => {
          this.rebanhos = dados.filter((value: Rebanho) => {
            return value.quantidadeVacinada < value.quantidadeTotal;
          }), console.log(this.rebanhos)
        },
        error => {
          console.log("Error ao procurar animal", error)
        }
      )

    this.vacinaService.listarVacina().subscribe(
      dados => {
        this.vacinas = dados, console.log(this.vacinas)
      },
      error => console.log(error)
    )
  }

  ngAfterViewInit() {
    // @ts-ignore
    document.getElementById('adicionarRegistroVacina').addEventListener('hidden.bs.modal',
      (event) => {
        this.frm.form.reset({"idAnimal": 0, "idVacina": 0})
      }, false)
  }

  incluirRegistroVacina(frm: NgForm) {
    this.registroVacinaService.CadastrarProdutor(this.registroVacina).subscribe(
      dados => {
        this.buttonClose?.nativeElement.click(),
        alert("Registro Vacina cadastrada com sucesso!"),
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
