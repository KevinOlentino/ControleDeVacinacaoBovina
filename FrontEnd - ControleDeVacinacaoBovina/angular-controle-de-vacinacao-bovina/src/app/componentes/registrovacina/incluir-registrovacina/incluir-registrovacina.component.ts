import { Component, OnInit } from '@angular/core';
import {NgForm} from "@angular/forms";
import {RegistrovacinaService} from "../../../services/registrovacina/registrovacina.service";
import {RegistroVacina} from "../../../entities/registrovacinacao";
import {Animal} from "../../../entities/animal";
import {Vacina} from "../../../entities/vacina";

@Component({
  selector: 'app-incluir-registrovacina',
  templateUrl: './incluir-registrovacina.component.html',
  styleUrls: ['./incluir-registrovacina.component.css']
})
export class IncluirRegistrovacinaComponent implements OnInit {

  registroVacina: RegistroVacina = new RegistroVacina();
  animais: Animal[] = [];
  vacinas: Vacina[] = [];

  constructor(private registroVacinaService: RegistrovacinaService) { }

  ngOnInit(): void {
  }

  IncluirRegistroVacina(frm: NgForm){
    this.registroVacinaService.CadastrarProdutor(this.registroVacina).subscribe(
      dados => alert("Registro Vacina cadastrada com sucesso!"),
      error => alert("Erro ao cadastrar registro vacina")
    )
  }

}
