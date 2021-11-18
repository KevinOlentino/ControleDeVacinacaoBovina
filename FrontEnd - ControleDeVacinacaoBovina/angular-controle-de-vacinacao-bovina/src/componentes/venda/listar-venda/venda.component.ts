import { Venda } from 'src/entities/venda';
import { VendaService } from './../../../services/venda/venda.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-venda',
  templateUrl: './venda.component.html',
  styleUrls: ['./venda.component.css']
})
export class VendaComponent implements OnInit {

  vendas: Venda[] = [];
  idProdutor?: number = Number(localStorage.getItem('idProdutor')?.toString());


  constructor(private vendaService: VendaService) { }

  ngOnInit() {
    this.listarVendasPorOrigem();
  }

  listarVendasPorOrigem(){
    if(this.idProdutor)
    this.vendaService.listarPorOrigem(this.idProdutor).subscribe(
      dados => {this.vendas = dados, console.log(this.vendas)},
      error => console.log(error)
    )
  }

  listarVendasPorDestino(){
    if(this.idProdutor)
    this.vendaService.listarPorDestino(this.idProdutor).subscribe(
      dados => {this.vendas = dados, console.log(this.vendas)},
      error => console.log(error)
    )
  }

}
