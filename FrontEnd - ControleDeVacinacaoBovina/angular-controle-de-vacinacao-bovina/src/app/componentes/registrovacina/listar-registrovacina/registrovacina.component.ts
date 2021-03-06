import { RegistrovacinaService } from '../../../services/registrovacina/registrovacina.service';
import { RegistroVacina } from '../../../entities/registrovacinacao';
import {AfterViewInit, Component, OnInit} from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import {PropriedadeService} from "../../../services/propriedade/propriedade.service";
import {Propriedade} from "../../../entities/propriedade";

@Component({
  selector: 'app-registrovacina',
  templateUrl: './registrovacina.component.html',
  styleUrls: ['./registrovacina.component.css']
})
export class RegistrovacinaComponent implements OnInit, AfterViewInit{

  registroVacinas: RegistroVacina[] = [];
  registroVacina: RegistroVacina = new RegistroVacina();
  idPropriedade: number = 0;
  idProdutor?: number = Number(localStorage.getItem('idProdutor')?.toString());
  propriedades: Propriedade[] = [];

  constructor(private registroVacinaService: RegistrovacinaService, private propriedadeService: PropriedadeService) { }

  ngOnInit() {
    if(this.idProdutor)
      this.propriedadeService.ListarPorProdutor(this.idProdutor).subscribe(
        dados => {this.propriedades = dados, console.log(this.propriedades)},
        error => console.log(error)
      )
  }

  ngAfterViewInit() {
    document.addEventListener('submit',
      (event) => {
        this.SelecionarPropriedade();
        console.log("Atualizado")
      }, false)
  }

  SelecionarPropriedade(){
    if(this.idPropriedade != 0)
    this.registroVacinaService.ListarPorPropriedade(this.idPropriedade).subscribe(
      dados => {this.registroVacinas = dados, console.log(this.registroVacinas)},
      error => {console.log(error)}
    )
    else
      console.log("atualizado");
      this.registroVacinas = [];
  }
  cancelarRegistroVacina(registroVacina: RegistroVacina){
    this.registroVacina = registroVacina;
  }
}
