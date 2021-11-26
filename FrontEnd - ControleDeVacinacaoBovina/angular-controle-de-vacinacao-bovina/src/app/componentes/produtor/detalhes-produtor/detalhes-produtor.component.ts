import { Component, OnInit } from '@angular/core';
import {Produtor} from "../../../entities/produtor";
import {ActivatedRoute, Router} from "@angular/router";
import {PropriedadeService} from "../../../services/propriedade/propriedade.service";
import {RebanhoService} from "../../../services/rebanho/rebanho.service";
import {VendaService} from "../../../services/venda/venda.service";
import {RegistrovacinaService} from "../../../services/registrovacina/registrovacina.service";
import {Propriedade} from "../../../entities/propriedade";
import {Rebanho} from "../../../entities/rebanho";
import {RegistroVacina} from "../../../entities/registrovacinacao";
import {Venda} from "../../../entities/venda";
import {ProdutorService} from "../../../services/produtor/produtor.service";

@Component({
  selector: 'app-detalhes-produtor',
  templateUrl: './detalhes-produtor.component.html',
  styleUrls: ['./detalhes-produtor.component.css']
})

export class DetalhesProdutorComponent implements OnInit {

  produtor: Produtor = new Produtor()
  propriedades: Propriedade[] = [];
  rebanhos: Rebanho[] =[];

  constructor(private propriedadeService: PropriedadeService,
              private rebanhoService: RebanhoService,
              private produtorService: ProdutorService,
              private route: ActivatedRoute,
              private router: Router) { }

  ngOnInit(): void {
    const cpf = String(this.route.snapshot.paramMap.get('cpf'))
    this.produtorService.ObterPorCPF(cpf).subscribe(
      dados => {
        this.produtor = dados,
          this.renderizarItems(this.produtor.idProdutor)
      },
      error => {
        alert("Produtor não encontrada!"),
          this.router.navigate(['/Produtor'])
      }
    )
  }

  renderizarItems(id: number) {
    this.rebanho(id);
    this.propriedade(id)
  }
  rebanho(id:number){
    this.rebanhoService.listarPorProdutor(id).subscribe(
      dados => this.rebanhos = dados,
      error => console.log(error)
    )
  }
  propriedade(id: number){
    this.propriedadeService.ListarPorProdutor(id).subscribe(
      dados => this.propriedades = dados,
      error => console.log(error)
    )
  }

  redirecionarParaPropriedade(inscricaoEstadual: string){
    this.router.navigate([`/Propriedade/${inscricaoEstadual}`])
  }
}
