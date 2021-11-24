import {AfterViewInit, Component, OnInit, ViewChild} from '@angular/core';
import {NgForm} from "@angular/forms";
import {RegistrovacinaService} from "../../../services/registrovacina/registrovacina.service";
import {RegistroVacina} from "../../../entities/registrovacinacao";
import {Animal} from "../../../entities/animal";
import {Vacina} from "../../../entities/vacina";
import {AnimalService} from "../../../services/animal/animal.service";
import {VacinaService} from "../../../services/vacina/vacina.service";

@Component({
  selector: 'app-incluir-registrovacina',
  templateUrl: './incluir-registrovacina.component.html',
  styleUrls: ['./incluir-registrovacina.component.css']
})
export class IncluirRegistrovacinaComponent implements OnInit,AfterViewInit {

  idProdutor?: number = Number(localStorage.getItem('idProdutor')?.toString());
  registroVacina: RegistroVacina = new RegistroVacina();
  animais: Animal[] = [];
  vacinas: Vacina[] = [];
  @ViewChild('frm')
  private frm!: NgForm ;

  constructor(private registroVacinaService: RegistrovacinaService, private animalService: AnimalService,
              private vacinaService: VacinaService) {}

  ngOnInit(): void {
    if(this.idProdutor)
      this.animalService.listarPorProdutor(this.idProdutor).subscribe(
        dados => {this.animais = dados, console.log(this.animais)},
        error => {console.log("Error ao procurar animal",error)}
      )

    this.vacinaService.listarVacina().subscribe(
      dados => {this.vacinas = dados, console.log(this.vacinas)},
      error => console.log(error)
    )
  }

  ngAfterViewInit() {
    // @ts-ignore
    document.getElementById('adicionarRegistroVacina').addEventListener('hidden.bs.modal',
      (event) => {
        this.frm.reset()
      }, false)
  }

  IncluirRegistroVacina(frm: NgForm){
    console.log(this.registroVacina);
    this.registroVacinaService.CadastrarProdutor(this.registroVacina).subscribe(
      dados => {alert("Registro Vacina cadastrada com sucesso!"), console.log(dados)},
      error => {alert("Erro ao cadastrar registro vacina"), console.log(error)}
    )
  }

}
