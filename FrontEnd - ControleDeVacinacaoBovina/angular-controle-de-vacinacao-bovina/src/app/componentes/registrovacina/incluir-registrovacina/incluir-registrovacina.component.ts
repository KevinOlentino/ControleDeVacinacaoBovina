import { Component, OnInit } from '@angular/core';
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
export class IncluirRegistrovacinaComponent implements OnInit {

  idProdutor?: number = Number(localStorage.getItem('idProdutor')?.toString());
  registroVacina: RegistroVacina = new RegistroVacina();
  animais: Animal[] = [];
  vacinas: Vacina[] = [];

  constructor(private registroVacinaService: RegistrovacinaService, private animalService: AnimalService,
              private vacinaService: VacinaService) {
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

  ngOnInit(): void {
    if(this.idProdutor)
      this.animalService.listarPorProdutor(this.idProdutor).subscribe(
        dados => {this.animais = dados, console.log(this.animais)},
        error => {console.log("Error ao procurar animal",error)}
      )


  }

  IncluirRegistroVacina(frm: NgForm){
    this.registroVacinaService.CadastrarProdutor(this.registroVacina).subscribe(
      dados => alert("Registro Vacina cadastrada com sucesso!"),
      error => alert("Erro ao cadastrar registro vacina")
    )
  }

}
