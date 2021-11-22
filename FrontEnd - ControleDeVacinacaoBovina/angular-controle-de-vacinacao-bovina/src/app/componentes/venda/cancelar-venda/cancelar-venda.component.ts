import {Component, Input, OnInit} from '@angular/core';
import {Venda} from "../../../entities/venda";
import {VendaService} from "../../../services/venda/venda.service";

@Component({
  selector: 'app-cancelar-venda',
  templateUrl: './cancelar-venda.component.html',
  styleUrls: ['./cancelar-venda.component.css']
})
export class CancelarVendaComponent implements OnInit {

  @Input(`venda`) venda:Venda = new Venda();

  constructor(private vendaService: VendaService) { }

  ngOnInit(): void {
  }

  cancelarVenda(id: number){
    this.vendaService.CancelarRegistroAnimal(id).subscribe(
      dados => alert("Venda cancelado com sucesso!"),
      error => alert("Erro ao cancelar Venda")
    )
  }

}
