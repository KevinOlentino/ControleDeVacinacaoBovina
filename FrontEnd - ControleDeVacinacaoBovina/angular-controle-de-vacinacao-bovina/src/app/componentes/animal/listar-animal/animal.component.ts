import { AppComponent } from '../../../app.component';
import { AnimalService } from '../../../services/animal/animal.service';
import {Component, OnInit, Output} from '@angular/core';
import { Animal } from 'src/app/entities/animal';
import {Propriedade} from "../../../entities/propriedade";
import {PropriedadeService} from "../../../services/propriedade/propriedade.service";

@Component({
  selector: 'app-animal',
  templateUrl: './animal.component.html',
  styleUrls: ['./animal.component.css']
})

export class AnimalComponent implements OnInit {

  constructor(private animalService: AnimalService, private propriedadeService: PropriedadeService, private app: AppComponent) { }

  animais:Animal[]= [];
  propriedades: Propriedade[] =[];
  idPropriedade: number = 0;
  idProdutor?: number = Number(localStorage.getItem('idProdutor')?.toString());
  @Output() animal: Animal = new Animal();

  ngOnInit() {
    if(this.idProdutor)
      this.propriedadeService.ListarPorProdutor(this.idProdutor).subscribe(
        dados => {this.propriedades = dados, console.log(this.propriedades)},
        error => console.log(error)
      )
    this.selecionarTodos();
  }

  selecionarPropriedade(){
    if(this.idPropriedade != 0)
    this.animalService.listarPorPropriedade(this.idPropriedade).subscribe(
      dados => {this.animais = dados, console.log(this.animais)},
      error => {console.log(error), this.animais = []}
    )
    else
      this.selecionarTodos();
  }

  selecionarTodos(){
    if(this.idProdutor)
      this.animalService.listarPorProdutor(this.idProdutor).subscribe(
        dados => {this.animais = dados, console.log(this.animais)},
        error => {console.log("Error ao procurar animal",error)}
      )
  }

  cancelar(animal: Animal){
    this.animal = animal;
  }

}
