import {Component, Input, OnInit} from '@angular/core';
import {RegistroVacina} from "../../../entities/registrovacinacao";
import {RegistrovacinaService} from "../../../services/registrovacina/registrovacina.service";

@Component({
  selector: 'app-cancelar-registrovacina',
  templateUrl: './cancelar-registrovacina.component.html',
  styleUrls: ['./cancelar-registrovacina.component.css']
})
export class CancelarRegistrovacinaComponent implements OnInit {

  @Input("registroVacina") registroVacina: RegistroVacina = new RegistroVacina();

  constructor(private registroVacinaService: RegistrovacinaService) { }

  ngOnInit(){
  }

  cancelarRegistroVacina(id: number){
    this.registroVacinaService.CancelarRegistroVacina(id).subscribe(
      dados => alert("Registro de Vacina cancelado com sucesso!"),
      error => alert("Erro ao cancelar registro de vacina!")
    )
  }

}
