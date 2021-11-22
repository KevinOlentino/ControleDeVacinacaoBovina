import { AppComponent } from '../../../app.component';
import { AnimalService } from '../../../services/animal/animal.service';
import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import { Animal } from 'src/app/entities/animal';

@Component({
  selector: 'app-animal',
  templateUrl: './animal.component.html',
  styleUrls: ['./animal.component.css']
})

export class AnimalComponent implements OnInit {

  constructor(private animalService: AnimalService, private app: AppComponent) { }

  animais:Animal[]= [];
  idProdutor?: number = Number(localStorage.getItem('idProdutor')?.toString());
  @Output() animal: Animal = new Animal();

  ngOnInit() {
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
