import {Component, Input, OnInit} from '@angular/core';
import {Especie} from "../../../entities/especie";
import {Animal} from "../../../entities/animal";
import {AnimalService} from "../../../services/animal/animal.service";

@Component({
  selector: 'app-cancelar-animal',
  templateUrl: './cancelar-animal.component.html',
  styleUrls: ['./cancelar-animal.component.css'],
})
export class CancelarAnimalComponent implements OnInit {

  @Input(`animal`) animal: Animal = new Animal();

  constructor(private animalService: AnimalService) { }

  ngOnInit(): void {
  }

  cancelarAnimal(id: number){
    this.animalService.CancelarRegistroAnimal(id).subscribe(
      dados => alert("Animal cancelado com sucesso!"),
      error => alert("Erro ao cancelar animal")
    )
  }

}
