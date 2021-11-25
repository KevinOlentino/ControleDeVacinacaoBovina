import {Component, Input, OnInit, ViewChild} from '@angular/core';
import {Venda} from "../../../entities/venda";
import {VendaService} from "../../../services/venda/venda.service";
import {HttpErrorResponse} from "@angular/common/http";

@Component({
  selector: 'app-cancelar-venda',
  templateUrl: './cancelar-venda.component.html',
  styleUrls: ['./cancelar-venda.component.css']
})
export class CancelarVendaComponent implements OnInit {

  @Input(`venda`) venda:Venda = new Venda();
  @ViewChild('buttonClose')
  private buttonClose: { nativeElement: { click: () => any; }; } | undefined;

  private error: any;

  constructor(private vendaService: VendaService) { }

  ngOnInit(): void {
  }

  cancelarVenda(id: number){
    this.vendaService.CancelarRegistroAnimal(id).subscribe(
      dados => {
        this.buttonClose?.nativeElement.click(),
          alert("Venda cancelada com sucesso!"),
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
