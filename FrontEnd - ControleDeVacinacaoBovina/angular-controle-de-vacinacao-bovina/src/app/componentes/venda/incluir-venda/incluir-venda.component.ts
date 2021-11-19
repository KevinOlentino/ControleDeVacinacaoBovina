import { Component, OnInit } from '@angular/core';
import {NgForm} from "@angular/forms";
import {VendaService} from "../../../services/venda/venda.service";
import {Venda} from "../../../entities/venda";
import {Especie} from "../../../entities/especie";
import {FinalidadeDeVenda} from "../../../entities/finalidadedevenda";
import {Propriedade} from "../../../entities/propriedade";

@Component({
  selector: 'app-incluir-venda',
  templateUrl: './incluir-venda.component.html',
  styleUrls: ['./incluir-venda.component.css']
})
export class IncluirVendaComponent implements OnInit {

  venda: Venda = new Venda();
  especies: Especie[] = [];
  finalidesDeVenda: FinalidadeDeVenda[]=[];
  propriedades: Propriedade[] = [];


  constructor(private vendaService: VendaService) { }

  ngOnInit(): void {
  }

  IncluirVenda(frm: NgForm){
    this.vendaService.CadastrarVenda(this.venda).subscribe(
      dados => alert("Venda cadastrada com sucesso!"),
      error => alert("Erro ao cadastrar venda")
    )
  }

}
