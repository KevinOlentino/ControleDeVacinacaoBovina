import {Component, Input, OnInit, ViewChild} from '@angular/core';
import {Especie} from "../../../entities/especie";
import {Animal} from "../../../entities/animal";
import {AnimalService} from "../../../services/animal/animal.service";
import {HttpErrorResponse} from "@angular/common/http";
import {NgForm} from "@angular/forms";

@Component({
  selector: 'app-cancelar-animal',
  templateUrl: './cancelar-animal.component.html',
  styleUrls: ['./cancelar-animal.component.css'],
})
export class CancelarAnimalComponent implements OnInit {

  @Input(`animal`) animal: Animal = new Animal();
  @ViewChild('buttonClose')
  private buttonClose: { nativeElement: { click: () => any; }; } | undefined;

  private error: any;

  constructor(private animalService: AnimalService) { }

  ngOnInit(): void {}

  cancelarAnimal(id: number){
    this.animalService.CancelarRegistroAnimal(id).subscribe(
      dados => {
        this.buttonClose?.nativeElement.click(),
          alert("Entrada de animal cancelada com sucesso!"),
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
