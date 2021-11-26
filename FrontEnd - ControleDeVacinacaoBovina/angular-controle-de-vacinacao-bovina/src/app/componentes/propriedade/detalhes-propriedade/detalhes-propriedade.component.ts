import {Component, OnInit} from '@angular/core';
import {PropriedadeService} from "../../../services/propriedade/propriedade.service";
import {RebanhoService} from "../../../services/rebanho/rebanho.service";
import {ActivatedRoute, Router} from "@angular/router";
import {Propriedade} from "../../../entities/propriedade";
import {Rebanho} from "../../../entities/rebanho";
import {VendaService} from "../../../services/venda/venda.service";
import {RegistrovacinaService} from "../../../services/registrovacina/registrovacina.service";
import {RegistroVacina} from "../../../entities/registrovacinacao";
import {Venda} from "../../../entities/venda";
import {AnimalService} from "../../../services/animal/animal.service";
import {Animal} from "../../../entities/animal";

@Component({
  selector: 'app-detalhes-propriedade',
  templateUrl: './detalhes-propriedade.component.html',
  styleUrls: ['./detalhes-propriedade.component.css']
})
export class DetalhesPropriedadeComponent implements OnInit {

  constructor(private propriedadeService: PropriedadeService,
              private rebanhoService: RebanhoService,
              private vendaService: VendaService,
              private registroVacinaService: RegistrovacinaService,
              private animalService: AnimalService,
              private route: ActivatedRoute,
              private router: Router) {
  }

  propriedade: Propriedade = new Propriedade();
  rebanhos: Rebanho[] =[];
  registroVacinas: RegistroVacina[] = [];
  vendas: Venda[]=[];
  animals: Animal[]=[];

  ngOnInit(): void {
    const inscricaoEstadual = String(this.route.snapshot.paramMap.get('inscricaoEstadual'))
    this.propriedadeService.ObterPorInscricaoEstadual(inscricaoEstadual).subscribe(
      dados => {
        this.propriedade = dados,
          this.renderizarItems(this.propriedade.idPropriedade)
      },
      error => {
        alert("Propriedade não encontrada!"),
          this.router.navigate(['/Propriedade'])
      }
    )
  }

  renderizarItems(id: number) {
    this.rebanho(id);
    this.venda(id);
    this.registroVacina(id);
    this.animal(id);
  }
  rebanho(id:number){
    this.rebanhoService.listarPorPropriedade(id).subscribe(
      dados => this.rebanhos = dados,
      error => console.log(error)
    )
  }
  venda(id:number){
    this.vendaService.listarPorOrigem(id).subscribe(
      dados => this.vendas = dados,
      error => console.log(error)
    )
  }
  registroVacina(id:number){
    this.registroVacinaService.ListarPorPropriedade(id).subscribe(
      dados => this.registroVacinas = dados,
      error => console.log(error)
    )
  }
  animal(id: number){
    this.animalService.listarPorPropriedade(id).subscribe(
      dados => this.animals = dados,
      error => console.log(error)
    )
  }
  redirecionarParaProdutor(){
    this.router.navigate([`/Produtor/${this.propriedade.produtor.cpf}`])
  }

}
