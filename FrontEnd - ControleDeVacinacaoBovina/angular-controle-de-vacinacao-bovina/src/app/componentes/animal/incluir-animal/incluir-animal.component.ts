import { Component, OnInit } from '@angular/core';
import {NgForm} from "@angular/forms";
import {AnimalService} from "../../../services/animal/animal.service";
import {Animal} from "../../../entities/animal";
import {Propriedade} from "../../../entities/propriedade";
import {Especie} from "../../../entities/especie";
import {EspecieService} from "../../../services/especie/especie.service";
import {PropriedadeService} from "../../../services/propriedade/propriedade.service";

@Component({
  selector: 'app-incluir-animal',
  templateUrl: './incluir-animal.component.html',
  styleUrls: ['./incluir-animal.component.css']
})
export class IncluirAnimalComponent implements OnInit {

  animal: Animal = new Animal();
  propriedades: Propriedade[] = [];
  especies: Especie [] = []
  idProdutor?: number = Number(localStorage.getItem('idProdutor')?.toString());

  constructor(private animalService: AnimalService, private especieService: EspecieService,
              private propriedadeService: PropriedadeService) { }

  ngOnInit(): void {
    if(this.idProdutor)
      this.propriedadeService.ListarPorProdutor(this.idProdutor).subscribe(
        dados => {this.propriedades = dados, console.log(this.propriedades)},
        error => console.log(error)
      )

    this.especieService.listarEspecies().subscribe(
      dados => {this.especies = dados, console.log(this.especies)},
      error => console.log(error)
    )
  }

  Incluir(frm: NgForm){
    this.animalService.CadastrarAnimais(this.animal).subscribe(
      dados => {alert("Animal cadastrado com sucesso!"), console.log(dados)},
      error => {alert("Erro ao cadastrar Animal"),console.log(error)}
    )
  }
}
